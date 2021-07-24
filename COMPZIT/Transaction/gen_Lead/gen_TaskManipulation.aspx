<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_TaskManipulation.aspx.cs" Inherits="Transaction_gen_Lead_gen_TaskManipulation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script> 
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
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
    <script type="text/javascript">
       
        function SuccessCancelationTask() {
            $("#success-alert").html("Follow-Up/Task closed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function ErrorMsg() {
            $("#divWarning").html("Some error occured.Please review entered information !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }

        function CancelAlertTask(href) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close this task?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location = href;
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;          
        }

        function GetIndividual(href) {
  
                window.location = href;
                return false;
          
        }
        function SuccessUpdationTask() {
            $("#success-alert").html("Follow-Up/Task Details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
          
        }
        function LeadAlreadyClosed() {
            $("#divWarning").html("Follow-Up/Task details not updated as opportunity has been closed.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });         
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

        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
        </script>
        <%-----------------------------------------------------FOR TASK------------------------------------------------------------------%>

    <script>

        var $Mo = jQuery.noConflict();
       
        function PlusWeek() {

            var DropdownListWeek = document.getElementById("<%=ddlPlusWeek.ClientID%>");
            var SelectedValueWeek = DropdownListWeek.value;

            var dateDateCntrlr = new Date();
            if (SelectedValueWeek != '--Select Week--') {
                var week = parseInt(SelectedValueWeek);

                dateDateCntrlr.setDate(dateDateCntrlr.getDate() + week * 7);
            }
            var dd = dateDateCntrlr.getDate();
            var mm = dateDateCntrlr.getMonth() + 1; //January is 0!

            var yyyy = dateDateCntrlr.getFullYear();
            if (dd < 10) {
                dd = '0' + dd
            }
            if (mm < 10) {
                mm = '0' + mm
            }
            var ddmmyyyyDate = dd + '-' + mm + '-' + yyyy;

            document.getElementById("<%=txtTaskDate.ClientID%>").value = ddmmyyyyDate;

            return false;
        }



        function EditModalTask(objname, subEvent, TaskId, TaskSubjctId, TaskSubjctName, TaskDueDate, TaskDueHr, TaskDueMin, TaskDueAM_PM, Descptn, TaskSts) {
          
            document.getElementById('<%=btnTaskUpd.ClientID%>').style.display = "";             
            document.getElementById('<%=hiddenTaskId.ClientID%>').value = TaskId;
            document.getElementById("H2").innerText = "Edit Follow-Up / Task";
            //for options in Task Subject

            var OptionsSbjct = document.getElementById("<%=divOptionsTaskSubject.ClientID%>").innerHTML;

             var DfltOptnSbjct = '<option  value="--SELECT SUBJECT--">--SELECT SUBJECT--</option>';
             var TotalOptnSbjct = "";
             if (OptionsSbjct == "") {
                 TotalOptnSbjct = DfltOptnSbjct;
             }
             else {

                 TotalOptnSbjct = DfltOptnSbjct + OptionsSbjct;

             }

             var TaskSbjctHtml = ' <select id="ddlTaskSubject"  class="form-control fg2_inp1" > ';
            //  </select> </td>
             TaskSbjctHtml += TotalOptnSbjct;
             TaskSbjctHtml += ' </select>  ';

             document.getElementById('SpanddlTask').innerHTML = TaskSbjctHtml;

            
             document.getElementById("ddlTaskSubject").style.borderColor = "";
             document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
             document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";

            document.getElementById("ddlTaskSubject").disabled = false;
            document.getElementById("<%=ddlTaskHr.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTaskMin.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDate.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").disabled = false;
            document.getElementById("<%=cbxTaskStatus.ClientID%>").disabled = false;
            document.getElementById("<%=ddlPlusWeek.ClientID%>").disabled = false;
           


            var desiredValueSbjct = TaskSubjctId;
            var elSbjct = document.getElementById("ddlTaskSubject");
            for (var i = 0; i < elSbjct.options.length; i++) {
                if (elSbjct.options[i].value == desiredValueSbjct) {
                    elSbjct.selectedIndex = i;
                    break;
                }
            }

            var TSbjct = document.getElementById("ddlTaskSubject").value;
            //  alert(LHead);
            if (TSbjct == "--SELECT SUBJECT--" || TSbjct == "") {
                //add option code
                $Mo("#ddlTaskSubject").append($Mo('<option>', {
                    value: TaskSubjctId,
                    text: TaskSubjctName
                }));
                var AdesiredValueSource = TaskSubjctId;
                var AelSbjct = document.getElementById("ddlTaskSubject");
                for (var i = 0; i < AelSbjct.options.length; i++) {
                    if (AelSbjct.options[i].value == AdesiredValueSource) {
                        AelSbjct.selectedIndex = i;
                        break;
                    }
                }
            }
            var desiredValueHr = TaskDueHr;
            var elHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
            for (var i = 0; i < elHr.options.length; i++) {
                if (elHr.options[i].value == desiredValueHr) {
                    elHr.selectedIndex = i;
                    break;
                }
            }

            var desiredValueMin = TaskDueMin;
            var elMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
             for (var i = 0; i < elMin.options.length; i++) {
                 if (elMin.options[i].value == desiredValueMin) {
                     elMin.selectedIndex = i;
                     break;
                 }
             }

             var desiredValueAMPM = TaskDueAM_PM;
             var elAMPM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
            for (var i = 0; i < elAMPM.options.length; i++) {
                if (elAMPM.options[i].value == desiredValueAMPM) {
                    elAMPM.selectedIndex = i;
                    break;
                }
            }
            document.getElementById("<%=txtTaskDate.ClientID%>").value = TaskDueDate;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").value = Descptn;

            if (TaskSts == 'ACTIVE') {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = true;

            }
            else {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = false;
            }
            $('#myModal_3').modal('show');
            return false;
        }

        function ViewModalTask(objname, subEvent, TaskSubjctId, TaskSubjctName, TaskDueDate, TaskDueHr, TaskDueMin, TaskDueAM_PM, Descptn, TaskSts) {
       
            document.getElementById('<%=btnTaskUpd.ClientID%>').style.display = "none";
            document.getElementById("H2").innerText = "View Follow-Up / Task";
            //for options in Task Subject

            var OptionsSbjct = document.getElementById("<%=divOptionsTaskSubject.ClientID%>").innerHTML;

            var DfltOptnSbjct = '<option  value="--SELECT SUBJECT--">--SELECT SUBJECT--</option>';
            var TotalOptnSbjct = "";
            if (OptionsSbjct == "") {
                TotalOptnSbjct = DfltOptnSbjct;
            }
            else {

                TotalOptnSbjct = DfltOptnSbjct + OptionsSbjct;

            }

            var TaskSbjctHtml = ' <select id="ddlTaskSubject"  class="form-control fg2_inp1" > ';
            //  </select> </td>
            TaskSbjctHtml += TotalOptnSbjct;
            TaskSbjctHtml += ' </select>  ';

            document.getElementById('SpanddlTask').innerHTML = TaskSbjctHtml;

          
             document.getElementById("ddlTaskSubject").style.borderColor = "";
             document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
             document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";

            document.getElementById("ddlTaskSubject").disabled = true;
            document.getElementById("<%=ddlTaskHr.ClientID%>").disabled = true;
            document.getElementById("<%=ddlTaskMin.ClientID%>").disabled = true;
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").disabled = true;
            document.getElementById("<%=txtTaskDate.ClientID%>").disabled = true;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").disabled = true;
            document.getElementById("<%=cbxTaskStatus.ClientID%>").disabled = true;
            document.getElementById("<%=ddlPlusWeek.ClientID%>").disabled = true;
          


            var desiredValueSbjct = TaskSubjctId;
            var elSbjct = document.getElementById("ddlTaskSubject");
            for (var i = 0; i < elSbjct.options.length; i++) {
                if (elSbjct.options[i].value == desiredValueSbjct) {
                    elSbjct.selectedIndex = i;
                    break;
                }
            }

            var TSbjct = document.getElementById("ddlTaskSubject").value;
            //  alert(LHead);
            if (TSbjct == "--SELECT SUBJECT--" || TSbjct == "") {
                //add option code
                $Mo("#ddlTaskSubject").append($Mo('<option>', {
                    value: TaskSubjctId,
                    text: TaskSubjctName
                }));
                var AdesiredValueSource = TaskSubjctId;
                var AelSbjct = document.getElementById("ddlTaskSubject");
                for (var i = 0; i < AelSbjct.options.length; i++) {
                    if (AelSbjct.options[i].value == AdesiredValueSource) {
                        AelSbjct.selectedIndex = i;
                        break;
                    }
                }
            }
            var desiredValueHr = TaskDueHr;
            var elHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
            for (var i = 0; i < elHr.options.length; i++) {
                if (elHr.options[i].value == desiredValueHr) {
                    elHr.selectedIndex = i;
                    break;
                }
            }

            var desiredValueMin = TaskDueMin;
            var elMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
            for (var i = 0; i < elMin.options.length; i++) {
                if (elMin.options[i].value == desiredValueMin) {
                    elMin.selectedIndex = i;
                    break;
                }
            }

            var desiredValueAMPM = TaskDueAM_PM;
            var elAMPM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
             for (var i = 0; i < elAMPM.options.length; i++) {
                 if (elAMPM.options[i].value == desiredValueAMPM) {
                     elAMPM.selectedIndex = i;
                     break;
                 }
             }
             document.getElementById("<%=txtTaskDate.ClientID%>").value = TaskDueDate;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").value = Descptn;

            if (TaskSts == 'ACTIVE') {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = true;

            }
            else {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = false;
            }
            $('#myModal_3').modal('show');
            return false;
        }
        function CloseModalTask() {
            if (document.getElementById('<%=btnTaskUpd.ClientID%>').style.display == "none") {
                 document.getElementById("<%=txtTaskDate.ClientID%>").value = "";
                document.getElementById("<%=txtTaskDescptn.ClientID%>").value = "";
                $('#myModal_3').modal('hide');
                document.getElementById('<%=hiddenTaskId.ClientID%>').value = "";
                return false;
            }
            else {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to close?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=txtTaskDate.ClientID%>").value = "";
                        document.getElementById("<%=txtTaskDescptn.ClientID%>").value = "";
                        $('#myModal_3').modal('hide');

                        document.getElementById('<%=hiddenTaskId.ClientID%>').value = "";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
            }
            return false;
        }  
        function CheckTask() {
            // alert('CheckFollowUp');
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            document.getElementById("<%=hiddenTaskSubjctId.ClientID%>").value = "";
            // replacing < and > tags


            var TDateWithoutReplace = document.getElementById("<%=txtTaskDate.ClientID%>").value;
            var TDatereplaceText1 = TDateWithoutReplace.replace(/</g, "");
            var TDatereplaceText2 = TDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTaskDate.ClientID%>").value = TDatereplaceText2;

            var TdescWithoutReplace = document.getElementById("<%=txtTaskDescptn.ClientID%>").value;
            var TdescreplaceText1 = TdescWithoutReplace.replace(/</g, "");
            var TdescreplaceText2 = TdescreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTaskDescptn.ClientID%>").value = TdescreplaceText2;



            document.getElementById("ddlTaskSubject").style.borderColor = "";
            document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";


            var DropdownListSbjct = document.getElementById("ddlTaskSubject");
            var SelectedValueSbjct = DropdownListSbjct.value;
            document.getElementById("<%=hiddenTaskSubjctId.ClientID%>").value = SelectedValueSbjct;
            var HiddenSbjct = document.getElementById("<%=hiddenTaskSubjctId.ClientID%>").value
            var TDescptn = document.getElementById("<%=txtTaskDescptn.ClientID%>").value;

            //date
            var Taskdate = document.getElementById("<%=txtTaskDate.ClientID%>").value;

            var Tdata = Taskdate.split("-");

      
            if (isNaN(Date.parse(Tdata[2] + "-" + Tdata[1] + "-" + Tdata[0])) || SelectedValueSbjct == "--SELECT SUBJECT--" || HiddenSbjct == "--SELECT SUBJECT--" || HiddenSbjct == "" || TDescptn.length > 500) {

                $("#divErrorRsnTask").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                });
                //   alert(isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])));
                //  alert(SelectedValueSrc);
                if (SelectedValueSbjct == "--SELECT SUBJECT--") {

                    document.getElementById("ddlTaskSubject").focus();

                    document.getElementById("ddlTaskSubject").style.borderColor = "Red";
                    ret = false;
                }


                // using ISO 8601 Date String
                if (isNaN(Date.parse(Tdata[2] + "-" + Tdata[1] + "-" + Tdata[0]))) {
                    document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaskDate.ClientID%>").focus();
                    ret = false;

                }

                if (TDescptn.length > 500) {
                    document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaskDescptn.ClientID%>").focus();
                    ret = false;

                }
            }

            if (ret == true) {
                //// AFTER if validation is true in above case
                //check if software date is less than current date
                var TaskdatepickerDate = document.getElementById("<%=txtTaskDate.ClientID%>").value;
                var arrDatePickerDate = TaskdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                //   alert('dateDateCntrlr ' + dateDateCntrlr);
                // alert('dateCurrentDate ' + dateCurrentDate);
                if (dateDateCntrlr < dateCurrentDate) {
                    document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaskDate.ClientID%>").focus();
                    $("#divErrorRsnTask").html("Sorry, Follow-Up/Task due date cannot be less than current date !.");
                    $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    ret = false;
                }
                else if (dateDateCntrlr > dateCurrentDate) {
                    // alert('greater');
                }

                else {
                    var CurrentDate = new Date();
                    //  alert(CurrentDate);
                    var hours = CurrentDate.getHours();

                    var minutes = ("0" + (CurrentDate.getMinutes())).slice(-2);

                    var DropdownListHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
                    var SelectedValueHr = DropdownListHr.value;

                    var DropdownListMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
                    var SelectedValueMin = DropdownListMin.value;

                    var DropdownListAM_PM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
                    var SelectedValueAM_PM = DropdownListAM_PM.value;


                    if (SelectedValueAM_PM == "PM" && SelectedValueHr != 12) {

                        SelectedValueHr = parseInt(SelectedValueHr) + 12;
                    }
                    if (SelectedValueAM_PM == "AM" && SelectedValueHr == 12) {

                        SelectedValueHr = 0;
                    }
                    SelectedValueHr = parseInt(SelectedValueHr);
                    SelectedValueMin = parseInt(SelectedValueMin);
                    // alert('SelectedValueHr ' + SelectedValueHr);
                    //  alert('SelectedValueMin ' + SelectedValueMin);

                    if (hours > SelectedValueHr) {
                        $("#divErrorRsnTask").html("Sorry, Follow-Up/Task due time cannot be less than current time !.");
                        $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        ret = false;
                    }
                    else if (hours == SelectedValueHr) {
                        if (minutes > SelectedValueMin) {
                            $("#divErrorRsnTask").html("Sorry, Follow-Up/Task due time cannot be less than current time !.");
                            $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            ret = false;

                        }

                    }

            }
    }



    if (ret == true) {
        $('#myModal_3').modal('hide');

    }
    if (ret == false) {
        CheckSubmitZero();

    }
            // alert(ret);
    return ret;
}

    </script>

       <%-----------------------------------------------------FOR CANCEL TASK------------------------------------------------------------------%>



    <script>

        var $Mo = jQuery.noConflict();




        function OpenModalCancelTask(objname, subEvent, TaskId, TaskInsDate, TaskInsHr, TaskInsMin, TaskInsAM_PM, TaskCurDate, TaskCurHr, TaskCurMin, TaskCurAM_PM) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close this Follow-Up/Task?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById('<%=btnCancelTaskSave.ClientID%>').style.display = "";
                    document.getElementById('<%=hiddenTaskId.ClientID%>').value = TaskId;

                    document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>").value = '';
                    document.getElementById("<%=lblACancelTaskHr.ClientID%>").value = '';
                    document.getElementById("<%=lblACancelTaskMin.ClientID%>").value = '';





                    document.getElementById("<%=ddlCCancelTaskHr.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlCCancelTaskMin.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "";


                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").disabled = true;

                    $('#myModal_3_cls').modal('show');


                    document.getElementById("<%=lblACancelTaskHr.ClientID%>").value = TaskInsHr;

                    document.getElementById("<%=lblACancelTaskMin.ClientID%>").value = TaskInsMin;

                    document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>").value = TaskInsAM_PM;



                    var desiredValueCHr = TaskCurHr;
                    var elCHr = document.getElementById("<%=ddlCCancelTaskHr.ClientID%>");
                    for (var i = 0; i < elCHr.options.length; i++) {
                        if (elCHr.options[i].value == desiredValueCHr) {
                            elCHr.selectedIndex = i;
                            break;
                        }
                    }

                    var desiredValueCMin = TaskCurMin;
                    var elCMin = document.getElementById("<%=ddlCCancelTaskMin.ClientID%>");
                for (var i = 0; i < elCMin.options.length; i++) {
                    if (elCMin.options[i].value == desiredValueCMin) {
                        elCMin.selectedIndex = i;
                        break;
                    }
                }

                var desiredValueC_AMPM = TaskCurAM_PM;
                var elC_AMPM = document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>");
                for (var i = 0; i < elC_AMPM.options.length; i++) {
                    if (elC_AMPM.options[i].value == desiredValueC_AMPM) {
                        elC_AMPM.selectedIndex = i;
                        break;
                    }
                }
                document.getElementById("<%=txtACancelTaskDate.ClientID%>").value = TaskInsDate;
                document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value = TaskCurDate;


                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }


        function CloseModalCancelTask() {
            //   alert('close');
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without completing  closing process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").value = "";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value = "";
                    $('#myModal_3_cls').modal('hide');
                    document.getElementById('<%=hiddenTaskId.ClientID%>').value = "";
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;

        }
            function CheckCancelTask() {
                // alert('CheckFollowUp');
                var ret = true;
                if (CheckIsRepeat() == true) {
                }
                else {
                    ret = false;
                    return ret;
                }

                // replacing < and > tags

                var ATDateWithoutReplace = document.getElementById("<%=txtACancelTaskDate.ClientID%>").value;
            var ATDatereplaceText1 = ATDateWithoutReplace.replace(/</g, "");
            var ATDatereplaceText2 = ATDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtACancelTaskDate.ClientID%>").value = ATDatereplaceText2;

            var CTDateWithoutReplace = document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value;
            var CTDatereplaceText1 = CTDateWithoutReplace.replace(/</g, "");
            var CTDatereplaceText2 = CTDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value = CTDatereplaceText2;






      
            document.getElementById("<%=txtACancelTaskDate.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlCCancelTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCCancelTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "";

            //date
            var ATaskdate = document.getElementById("<%=txtACancelTaskDate.ClientID%>").value;
            var CTaskdate = document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value;

            var ATdata = ATaskdate.split("-");
            var CTdata = CTaskdate.split("-");

          

            if (isNaN(Date.parse(CTdata[2] + "-" + CTdata[1] + "-" + CTdata[0]))) {

                $("#divErrorRsnCancelTask").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                });
                //   alert(isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])));
                //  alert(SelectedValueSrc);



                // using ISO 8601 Date String
                if (isNaN(Date.parse(CTdata[2] + "-" + CTdata[1] + "-" + CTdata[0]))) {
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").focus();
                    ret = false;

                }


            }

            if (ret == true) {
                //// AFTER if validation is true in above case
                //check if software date is less than current date
                var CTaskdatepickerDate = document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value;
                var CarrDatePickerDate = CTaskdatepickerDate.split("-");
                var CdateDateCntrlr = new Date(CarrDatePickerDate[2], CarrDatePickerDate[1] - 1, CarrDatePickerDate[0]);

                var ATaskdatepickerDate = document.getElementById("<%=txtACancelTaskDate.ClientID%>").value;
                var AarrDatePickerDate = ATaskdatepickerDate.split("-");
                var AdateDateCntrlr = new Date(AarrDatePickerDate[2], AarrDatePickerDate[1] - 1, AarrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                //alert('AdateDateCntrlr ' + AdateDateCntrlr);
               // alert('CdateDateCntrlr ' + CdateDateCntrlr);
               // alert('dateCurrentDate ' + dateCurrentDate);
                if (CdateDateCntrlr < AdateDateCntrlr) {
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").focus();
                    $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed date cannot be less than inserted date !.");
                    $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    ret = false;
                }
                else if (CdateDateCntrlr > dateCurrentDate) {
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").focus();
                    $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed date cannot be greater than current date !.");
                    $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    ret = false;
                }
            if (ret == true) {


                if (CTaskdatepickerDate == ATaskdatepickerDate) {
                   // alert(CdateDateCntrlr);
                  // alert(AdateDateCntrlr);
                    var AlblListHr = document.getElementById("<%=lblACancelTaskHr.ClientID%>");
                    var ASelectedValueHr = AlblListHr.innerHTML;

                    var AlblListMin = document.getElementById("<%=lblACancelTaskMin.ClientID%>");
                    var ASelectedValueMin = AlblListMin.innerHTML;

                    var AlblListAM_PM = document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>");
                    var ASelectedValueAM_PM = AlblListAM_PM.innerHTML;

                        var CDropdownListHr = document.getElementById("<%=ddlCCancelTaskHr.ClientID%>");
                        var CSelectedValueHr = CDropdownListHr.value;

                        var CDropdownListMin = document.getElementById("<%=ddlCCancelTaskMin.ClientID%>");
                        var CSelectedValueMin = CDropdownListMin.value;

                        var CDropdownListAM_PM = document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>");
                        var CSelectedValueAM_PM = CDropdownListAM_PM.value;


                        if (CSelectedValueAM_PM == "PM" && CSelectedValueHr != 12) {

                            CSelectedValueHr = parseInt(CSelectedValueHr) + 12;
                        }
                        if (CSelectedValueAM_PM == "AM" && CSelectedValueHr == 12) {

                            CSelectedValueHr = 0;
                        }
                        if (ASelectedValueAM_PM == "PM" && ASelectedValueHr != 12) {

                            ASelectedValueHr = parseInt(ASelectedValueHr) + 12;
                        }
                        if (ASelectedValueAM_PM == "AM" && ASelectedValueHr == 12) {

                            ASelectedValueHr = 0;
                        }
                        CSelectedValueHr = parseInt(CSelectedValueHr);
                        CSelectedValueMin = parseInt(CSelectedValueMin);

                        ASelectedValueHr = parseInt(ASelectedValueHr);
                        ASelectedValueMin = parseInt(ASelectedValueMin);
                        // alert('SelectedValueHr ' + SelectedValueHr);
                        //  alert('SelectedValueMin ' + SelectedValueMin);

                        if (ASelectedValueHr > CSelectedValueHr) {
                            $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be less than inserted time !.");
                            $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            ret = false;
                        }
                        else if (ASelectedValueHr == CSelectedValueHr) {
                            if (ASelectedValueMin > CSelectedValueMin) {
                                $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be less than inserted time !.");
                                $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                ret = false;

                            }

                        }

                }
                if (ret == true) {

                    if (CTaskdatepickerDate == CurrentDateDate) {
                        var CurrentDate = new Date();
                        //  alert(CurrentDate);
                        var hours = CurrentDate.getHours();

                        var minutes = ("0" + (CurrentDate.getMinutes())).slice(-2);

                        var DropdownListHr = document.getElementById("<%=ddlCCancelTaskHr.ClientID%>");
                            var SelectedValueHr = DropdownListHr.value;

                            var DropdownListMin = document.getElementById("<%=ddlCCancelTaskMin.ClientID%>");
                            var SelectedValueMin = DropdownListMin.value;

                            var DropdownListAM_PM = document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>");
                            var SelectedValueAM_PM = DropdownListAM_PM.value;


                            if (SelectedValueAM_PM == "PM" && SelectedValueHr != 12) {

                                SelectedValueHr = parseInt(SelectedValueHr) + 12;
                            }
                            if (SelectedValueAM_PM == "AM" && SelectedValueHr == 12) {

                                SelectedValueHr = 0;
                            }
                            SelectedValueHr = parseInt(SelectedValueHr);
                            SelectedValueMin = parseInt(SelectedValueMin);
                            //   alert('SelectedValueHr ' + SelectedValueHr);
                            //  alert('SelectedValueMin ' + SelectedValueMin);

                            if (hours < SelectedValueHr) {
                                $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be greater than current time !.");
                                $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                ret = false;
                            }
                            else if (hours == SelectedValueHr) {
                                if (minutes < SelectedValueMin) {
                                    $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be greater than current time !.");
                                    $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                                    });
                                    ret = false;

                                }

                            }

                    }
                }

            }
        }



        if (ret == true) {
            $('#myModal_3_cls').modal('hide');

        }
        if (ret == false) {
            CheckSubmitZero();

        }
            // alert(ret);
        return ret;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenTaskId" runat="server" />
    <asp:HiddenField ID="hiddenTaskSubjctId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="HiddenFieldListMode" runat="server" />

    <ol class="breadcrumb">
   <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li class="active">Tasks</li>
      </ol>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
	<div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1 class="h1_con">Tasks</h1>
        <!-- <h3>Listing Open Follow-Up / Task</h3> -->

      <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_640"></div>

  </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
      

<!-------working area_closed---->

</div> 
      <div id="divOptionsTaskSubject" runat="server" style="display: none">
    </div>


    <!-- Modal3 -->
<div class="modal fade" id="myModal_3" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top:7%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H2">Follow-Up / Task</h5>
        <button type="button" class="close" onclick="return CloseModalTask();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mod_bd1_800">
             <div class="myAlert-bottom alert alert-danger" id="divErrorRsnTask" style="height:auto;left: 5%;right: 5%;">
             </div>
        <div class="form-group fg4 sa_2">
             <label for="email" class="fg2_la1">Subject:<span class="spn1">*</span></label>
              <span id="SpanddlTask"></span>         
        </div>
        <div class="form-group fg6_510 sa_2 mar_at flt_l">
              <label for="pwd" class="fg2_la1">Due Week:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlPlusWeek" class="form-control fg2_inp1  inp_mst inp_wd_100" runat="server" onchange="return PlusWeek();"></asp:DropDownList>
        </div>

        <div class="clearfix"></div>

        <div class="form-group fg12">

          <div class="form-group fg4 sa_2">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">Due Date:<span class="spn1">*</span> </label>
              <div id="datepicker8" class="input-group date" data-date-format="DD-MM-YYYY">
                 <asp:TextBox ID="txtTaskDate" class="form-control inp_bdr inp_mst cls_in1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                   <script>
                       var $cssf = jQuery.noConflict();
                       $cssf('#cphMain_txtTaskDate').datepicker({
                           autoclose: true,
                           format: 'dd-mm-yyyy',
                           timepicker: false,
                           startDate: new Date(),
                       });
                            </script>
              </div>
            </div>
          </div>
                
                <div class="fg2 sa_2 time_w">
                  <label for="pwd" class="fg2_la1">Due Time:<span class="spn1">*</span></label>
                      <asp:DropDownList ID="ddlTaskHr" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>

             <div class="fg2 sa_2 time_w">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                   <asp:DropDownList ID="ddlTaskMin" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>
             <div class="time_bx sa_2">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                  <asp:DropDownList ID="ddlTask_AM_PM" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>
        </div>
          
                   
        <div class="form-group fg12 sa_2">
          <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
          <textarea id="txtTaskDescptn" rows="3" cols="48" class="form-control flt_l inp_wd_100" placeholder="Description" runat="server" onkeypress="return isTag('cphMain_txtTaskDescptn', event);" onkeydown="textCounter(cphMain_txtTaskDescptn,450);" onkeyup="textCounter(cphMain_txtTaskDescptn,450);" style="resize: none;"></textarea>
        </div>

           <div class="form-group fg2 fg2_mr sa_fg1">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1"></span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input type="checkbox" id="cbxTaskStatus"  runat="server" checked="checked"/>
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
                      


        <div class="clearfix"></div>
        <div class="free_sp"></div>


      </div>
      <div class="modal-footer">
           <asp:Button ID="btnTaskUpd" runat="server" class="btn sub1" Text="Update" OnClientClick="return CheckTask();" OnClick="btnTaskUpd_Click" />
           <button type="submit" class="btn sub4" onclick="return CloseModalTask();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>



<!-- Modal3 -->
<div class="modal fade" id="myModal_3_cls" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top:7%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H3">Close Follow-Up / Task</h5>
        <button type="button" class="close" onclick="return CloseModalCancelTask();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mod_bd1_800">
            <div class="myAlert-bottom alert alert-danger" id="divErrorRsnCancelTask" style="height:auto;left: 5%;right: 5%;">
             </div>
       
        <div class="form-group fg6 sa_2">
          <label for="email" class="fg2_la1">Added Date:<span class="spn1"></span></label>
              <asp:TextBox ID="txtACancelTaskDate" class="form-control fg2_inp1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>          
        </div>
        

        <div class="form-group fg6">
          <label for="pwd" class="fg2_la1">Added Time:<span class="spn1">*</span></label>
          <div class="fg4 sa_2 time_w">
               <asp:TextBox ID="lblACancelTaskHr" class="form-control fg2_inp1"  runat="server" disabled=""></asp:TextBox>   
         </div>

         <div class="fg4 sa_2 time_w">
              <asp:TextBox ID="lblACancelTaskMin" class="form-control fg2_inp1"  runat="server" disabled=""></asp:TextBox> 
          
         </div>
         <div class="fg4 sa_2">
              <asp:TextBox ID="lblACancelTask_AM_PM" class="form-control fg2_inp1"  runat="server" disabled=""></asp:TextBox> 
             
         </div>
        </div>

        <div class="clearfix"></div>
        <div class="free_sp" style="margin-top: 0px;"></div>
        <div class="devider"></div>

        <div class="form-group fg6 sa_2">
          <div class="tdte">
            <label for="pwd" class="fg2_la1">Completed Date:<span class="spn1">*</span> </label>
            <div id="datepicker6" class="input-group date" data-date-format="DD-MM-YYYY">
                 <asp:TextBox ID="txtCCancelTaskDate" class="form-control inp_bdr inp_mst cls_in1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return isNumberDate(event);"></asp:TextBox>
              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                 <script>
                     var $cssdf = jQuery.noConflict();
                     $cssdf('#cphMain_txtCCancelTaskDate').datepicker({
                         autoclose: true,
                         format: 'dd-mm-yyyy',
                         timepicker: false,
                         endDate: new Date(),
                     });
                            </script>
            </div>
          </div>
        </div>

        <div class="form-group fg6">
          <label for="pwd" class="fg2_la1">Completed Time:<span class="spn1">*</span></label>
          <div class="fg4 sa_2 time_w">
               <asp:DropDownList ID="ddlCCancelTaskHr" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>             
         </div>

         <div class="fg4 sa_2 time_w">
              <asp:DropDownList ID="ddlCCancelTaskMin" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>         
         </div>
         <div class="fg4 sa_2">
              <asp:DropDownList ID="ddlCCancel_AM_PM" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList> 
         </div>
        </div> 
      </div>
      <div class="modal-footer">
       <asp:Button ID="btnCancelTaskSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckCancelTask();" OnClick="btnCancelTaskSave_Click" />
       <button type="submit" class="btn sub4" onclick="return CloseModalCancelTask();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>


 <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
 <script>   
     function PrintClick() {
         var orgID = '<%= Session["ORGID"] %>';
         var corptID = '<%= Session["CORPOFFICEID"] %>';
         var userID = '<%= Session["USERID"] %>';
         var ListingMode = document.getElementById("<%=HiddenFieldListMode.ClientID%>").value;
         if (corptID != "" && corptID != null && orgID != "" && orgID != null && userID != "" && userID != null) {
             $.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "gen_TaskManipulation.aspx/PrintList1",
                 data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",userID: "' + userID + '",ListingMode: "' + ListingMode + '"}',
                 dataType: "json",
                 success: function (data) {
                     if (data.d != "") {
                         window.open(data.d, '_blank');
                     }
                 }
             });
         }
         else {
             window.location = '/Security/Login.aspx';
         }
         return false;

     }
 </script>
     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             Load_dt();
             getdata(1);
         });

         function LoadList() {           
             getdata(1);
             return false;
         }

         //Efficiently Paging Through Large Amounts of Data
         var intOrderByColumn = 0;
         var intOrderByStatus = 0;
         var intToltalSearchColumns = 0;

         //------------Load column filters and table----------

         function Load_dt() {

             var strPagingTable = '';
             strPagingTable += '<div id="divHeader_dt"></div>';
             strPagingTable += '<div class="r_640"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_640" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "gen_TaskManipulation.aspx/LoadStaticDatafordt";
             $.ajax({
                 type: 'POST',
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     $("#divHeader_dt").html(result.d[0]);
                     $("#thPagingTable_SearchColumns").html(result.d[1]);
                     intToltalSearchColumns = result.d[2];
                     //bind on paste event to enable search on paste via mouse
                     $("input").on('paste', function (e) {
                         setTimeout(function () { $(e.target).keyup(); }, 100);
                     });
                 },
                 error: function () {
                     Error();
                 }
             });
         }

         //-----------Load datatable & pagination----------

         function getdata(strPageNumber) {
             document.getElementById("divPagingTable_processing").style.display = "";
             var strPageSize = 10;
             var strCommonSearchString = "";
             var strInputColumnSearch = "";//individual column search

             if (document.getElementById("txtCommonSearch_dt")) {
                 strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                 strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
             }

             if (document.getElementById("ddl_page_size")) {
                 strPageSize = document.getElementById("ddl_page_size").value;
             }

             var strOrgId = '<%= Session["ORGID"] %>';
             var strCorpId = '<%= Session["CORPOFFICEID"] %>';
             var userID = '<%= Session["USERID"] %>';
             var ListingMode = document.getElementById("<%=HiddenFieldListMode.ClientID%>").value;          
             var url = "gen_TaskManipulation.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.userID = userID;
             objData.ListingMode = ListingMode;
             objData.PageNumber = strPageNumber;
             objData.PageMaxSize = strPageSize;
             objData.strCommonSearchTerm = strCommonSearchString;
             objData.OrderColumn = intOrderByColumn;
             objData.OrderMethod = intOrderByStatus;
             objData.strInputColumnSearch = strInputColumnSearch;

             $.ajax({

                 type: 'POST',
                 data: JSON.stringify(objData),
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     document.getElementById("divPagingTable_processing").style.display = "none";
                     $('#tblPagingTable tbody').html(result.d[0]);
                     $("#cphMain_divReport").html(result.d[1]);//datatable

                     var intToltalColumns = document.getElementById('tblPagingTable').rows[1].cells.length;
                     if (document.getElementById("td_No_data_row_dt")) {
                         $("#td_No_data_row_dt").attr('colspan', intToltalColumns);
                     }

                     //enable sort icon 

                     if (intOrderByStatus == 1) {
                         $("#tdColumnHead_" + intOrderByColumn).addClass("asc");
                     }
                     else {
                         $("#tdColumnHead_" + intOrderByColumn).addClass("desc");
                     }



                 },
                 error: function () {
                     Error();
                 }
             });
             return false;
         }


         
         function SetOrderByValue(intOrderBy) {
             intOrderByColumn = intOrderBy;
             if (intOrderByStatus == 1) {
                 intOrderByStatus = 0;
             }
             else {
                 intOrderByStatus = 1;
             }
             //redraw
             getdata(1);
         }
         function ValidateSearchInputData(strSearchString) {
             var text = strSearchString;
             var replaceText1 = text.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             var replaceText3 = replaceText2.replace(/'/g, "");
             strSearchString = replaceText3;
             if (strSearchString.length > 100) {
                 strSearchString = strSearchString.substring(0, 100);
             }
             else {
             }
             return strSearchString;
         }

         //Efficiently Paging Through Large Amounts of Data

         //setup before functions
         var typingTimer;                //timer identifier
         var doneTypingInterval = 1000;  //time in ms (5 seconds)

         function SettypingTimer(evt) {
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13 || keyCodes == 9) {
                 return false;
             }
             //on keyup, start the countdown
             clearTimeout(typingTimer);
             typingTimer = setTimeout(doneTyping, doneTypingInterval);
         }

         //user is "finished typing," do something
         function doneTyping() {
             //do something
             getdata(1);
         }
         //--------------------------------------Pagination--------------------------------------
    </script>   
</asp:Content>
