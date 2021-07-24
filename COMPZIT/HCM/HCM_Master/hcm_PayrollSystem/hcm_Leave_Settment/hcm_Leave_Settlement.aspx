<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Leave_Settlement.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_End_Of_Service_Settmnt_hcm_End_Of_Service_Settmnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/js/jQuery/jquery-2.2.3.min.js"></script>
    <script src="/js/bootstrap/bootstrap.min.js"></script>
    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
        <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
    <%--<link href="/css/HCM/main.css" rel="stylesheet" />--%>
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script>

        var confirmbox = 0;

        function IncrmntConfrmCounter() {

            confirmbox++;
        }

        function ConfirmCancel() {
            if (confirmbox > 0)
                CancelAlert("hcm_Leave_Settlement_List.aspx");
            else
                window.location.href = "hcm_Leave_Settlement_List.aspx";
            return false;
        }


        function ConfirmMessageLIST() {
            if (confirmbox > 0)
                ConfirmMessage("hcm_Leave_Settlement_List.aspx");
            else
                window.location.href = "hcm_Leave_Settlement_List.aspx";
            return false;
        }

        function Confirm() {
            $('#TableLeave').find('tr').each(function () {
                var row = $(this);

                var rowid = row.find('input[type="checkbox"]').val();
                if (document.getElementById('cbMandatory' + rowid).checked == true) {
                    document.getElementById("<%=hiddenSettldDate.ClientID%>").value = row.find('#tdLeaveFrmDate' + rowid).html();
                }
            });
            
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=btnConfrmDeflt.ClientID%>").click();
                    return true;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        //show messages 
        function AddSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details inserted successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }
        function UpdateSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details updated successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }
        function ConfirmSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details confirmed successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }
        function DeleteSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details cancelled successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }


    </script>


    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            $noCon(window).scrollTop(0);

            AmountChecking('cphMain_txtLevSalary');
            AmountChecking('cphMain_txtPrevMonthSalary');
            AmountChecking('cphMain_txtCurntMnthSalary');
            AmountChecking('cphMain_txtTicktAmt');
            AmountChecking('cphMain_txtOtherAmt');
            AmountChecking('cphMain_txtOtherDeductn');
            AmountChecking('cphMain_txtNetAmt');
            AmountCheckingLbl('cphMain_lblBasicPay');
            AmountCheckingLbl('cphMain_lblAddition');
            AmountCheckingLbl('cphMain_lblDeduction');
            AmountCheckingLbl('cphMain_lblTotalPay');
            AmountCheckingLbl('cphMain_lblSalaryPerDay');
            AmountCheckingLbl('cphMain_lblOvertm');
            AmountCheckingLbl('cphMain_lblInstlmnt');
            AmountCheckingLbl('cphMain_lblPrevMnthArrAmt');



            $noCon("#divddlEmployee input.ui-autocomplete-input").focus();
            $noCon("#divddlEmployee input.ui-autocomplete-input").select();

            document.getElementById("divSalary").style.display = "none";
            document.getElementById("<%=divPrintCaption.ClientID%>").style.visibility = "hidden";
            document.getElementById("<%=divPrintReport.ClientID%>").style.visibility = "hidden";

            $("#preSalaryPop").attr('data-content', document.getElementById("<%=HiddenFieldPrevSalaryDtls.ClientID%>").value);

            if (document.getElementById("<%=HiddenFieldOtherAddDtls.ClientID%>").value != "") {
                $("#aIdOtherAddition").attr('data-content', document.getElementById("<%=HiddenFieldOtherAddDtls.ClientID%>").value);
                $("#aIdOtherAddition").css("display", "");
            }
            else {
                $("#aIdOtherAddition").css("display", "none");
            }
            if (document.getElementById("<%=HiddenFieldOtherDeductDtls.ClientID%>").value != "") {
                $("#aIdOtherDeduction").attr('data-content', document.getElementById("<%=HiddenFieldOtherDeductDtls.ClientID%>").value);
                $("#aIdOtherDeduction").css("display", "");
            }
            else {
                $("#aIdOtherDeduction").css("display", "none");
            }



            //messages
            var session = '<%=Session["SUCCESS"]%>';

            if (session == "SAVE") {
                AddSuccesMessage();
            }
            else if (session == "UPDATE") {
                UpdateSuccesMessage();
            }
            else if (session == "CONFIRM") {
                ConfirmSuccesMessage();
            }
            else if (session == "DELETE") {
                DeleteSuccesMessage();
            }
            //else {
            //   
            //}
            '<%Session["SUCCESS"] = '"' + null + '"'; %>';

            if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "" && document.getElementById("<%=hiddenEdit.ClientID%>").value != null) {

                //viewing
                if (document.getElementById("<%=hiddenView.ClientID%>").value != "" && document.getElementById("<%=hiddenView.ClientID%>").value != null) {

                    var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                    document.getElementById("<%=hiddenEmpId.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                    document.getElementById("divSalary").style.display = "";
                //   EmpDtlsDisplay();
                }
                else {
                    var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                    document.getElementById("<%=hiddenEmpId.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                    document.getElementById("divSalary").style.display = "";
                    document.getElementById("<%=txtRemarks.ClientID%>").focus();
                    //EmpDtlsDisplay();
                }
                if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "") {
                 //   if (document.getElementById("<%=hiddenView.ClientID%>").value == "") {
                    if (document.getElementById("cphMain_typResident").checked == true) {
                            LoadLeaveDate();
                        }
                    else if (document.getElementById("cphMain_typeNonResident").checked == true) {
                            EmpDtlsDisplay();
                        }
                 //  }
                }
            }
            else {
                if (session != "SAVE" && session != "UPDATE" && session != "CONFIRM" && session != "DELETE")
              //  ModeChange('typResident');
                document.getElementById("cphMain_typResident").checked = true;
                document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "0";
                document.getElementById("cphMain_DivLeave").style.display = "";
                document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblEligibleSettlmtOpen.ClientID%>").innerHTML = "";

                //   document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";
                document.getElementById("cphMain_DivDate").style.display = "none";
                //alert("ooooo");
               // LoadLeaveDate();
            }
            if (document.getElementById("cphMain_typResident").checked == true) {
                document.getElementById("cphMain_DivLeave").style.display = "";
            }
            else if (document.getElementById("cphMain_typeNonResident").checked == true) {

                document.getElementById("cphMain_DivLeave").style.display = "none";

            }
        });


        var $noconflic = jQuery.noConflict();
        function LoadLeaveDate(field) {
        
            if (field != "typeNonResident" && field != "typResident") {
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";

                $noconflic("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "");
            }

            if (document.getElementById("<%=ddlEmployee.ClientID%>").value == "--SELECT EMPLOYEE--" || document.getElementById("<%=ddlEmployee.ClientID%>").value == 0) {

                document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblEligibleSettlmtOpen.ClientID%>").innerHTML = "";

                document.getElementById("divSalary").style.display = "none";
          
              
                if (field != "typeNonResident" && field != "typResident") {
                  // document.getElementById("<%=btnProcess.ClientID%>").style.pointerEvents = "none";
   $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    $noconflic("#divddlEmployee input.ui-autocomplete-input").focus();
                    $noconflic("#divddlEmployee input.ui-autocomplete-input").select();
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                $noconflic("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "red");
                }

             
                return false;

            }
            if (document.getElementById("<%=hiddenEdit.ClientID%>").value == "" || document.getElementById("<%=hiddenEdit.ClientID%>").value == null) {
                //adding

                document.getElementById("divSalary").style.display = "none";
            }
                if (document.getElementById("<%=ddlEmployee.ClientID%>").value != "0") {
                    var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                    document.getElementById("<%=hiddenEmpId.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                }
            
            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%= Session["ORGID"] %>';
            var LeaveId = 0;
            if (document.getElementById("<%=HiddenLeaveId.ClientID%>").value != "") {
                LeaveId = document.getElementById("<%=HiddenLeaveId.ClientID%>").value;
            }
            var Confirm = 0;
            if (document.getElementById("<%=hiddenView.ClientID%>").value != "") {
                Confirm = 1;
            }
            var varDisplyLeave = 0;
            if (document.getElementById("<%=HiddenLeaveSettledDays.ClientID%>").value != "" && document.getElementById("<%=HiddenLeaveSettledDays.ClientID%>").value != null) {
                varDisplyLeave = document.getElementById("<%=HiddenLeaveSettledDays.ClientID%>").value;
             }
            if (document.getElementById("<%=HiddenSettlementMode.ClientID%>").value == "0") {
                var Details = PageMethods.LoadEmployeeLeaveDate(EmpId, CorpId, OrgId, LeaveId, Confirm, varDisplyLeave, function (response) {
                    if (response != "" && response != null) {
                        //  $("#TableLeave tr").remove();
                        document.getElementById("cphMain_DivLeaveDate").innerHTML = response;
                    }
                    else {
                        document.getElementById("cphMain_DivLeaveDate").innerHTML = "";
                    }
                });
            }
            else {
                if (document.getElementById("<%=hiddenView.ClientID%>").value == "") {
                    EmpDtlsDisplay();
                }
            }
            setTimeout(callafterDelay, 450);




        
        }
        function callafterDelay() {
            if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "") {
                if (document.getElementById("<%=HiddenLeaveId.ClientID%>").value != "") {
                    if (document.getElementById("<%=hiddenView.ClientID%>").value == "") {
                        EmpDtlsDisplay();
                    }
                }

            }
        }
        function CheckboxCheck(LeaveId) {
            $('#TableLeave').find('tr').each(function () {
                var row = $(this);
                var rowid = row.find('input[type="checkbox"]').val();
                document.getElementById('cbMandatory' + rowid).checked = false;
                    document.getElementById('cbMandatory' + LeaveId).checked = true;
            });
            EmpDtlsDisplay();

            //var addRowtable = document.getElementById("TableLeave");
            //var TableRowCount = document.getElementById("TableLeave").rows.length;
            //if (TableRowCount != 0) {
            //    for (var i = 0; i < addRowtable.rows.length; i++) {
            //        var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
            //        if (TableRowCount != 0) {
            //            if (LeaveId != xLoop) {
            //                document.getElementById('cbMandatory' + xLoop).disabled = true;
            //            }
            //            if (LeaveId == 0) {
            //                document.getElementById('cbMandatory' + xLoop).disabled = false;
            //            }
            //        }
            //    }
            //}
        }



       




                    //    document.getElementById("<%=HiddenLeaveId.ClientID%>").value = LeaveId;

                    //    }

                    //    if (tdOpenLeave == "") {
                    //        tdOpenLeave = row.find('#tdLeaveTotalCount' + rowid).html();
                    //    }

                    //    if (tdLeaveTaken == "") {
                    //        tdLeaveTaken = row.find('#tdLeaveTakenCount' + rowid).html();
                    //    }
                    //    if (tdLeaveDate == "") {
                    //        tdLeaveDate = row.find('#tdLeaveDate' + rowid).html();
                    //    }
                    //    if (tdLeaveBalance_Settle == "") {
                    //        tdLeaveBalance_Settle = row.find('#tdLeaveBalance_Settle' + rowid).html();
                    //    }
                    //}
                    //    });


        

        function EmpDtlsDisplay(field) {
            
            if (field != "typeNonResident" && field != "typResident") {
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";

                $noconflic("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "");
            }

            if (document.getElementById("<%=ddlEmployee.ClientID%>").value == "--SELECT EMPLOYEE--" || document.getElementById("<%=ddlEmployee.ClientID%>").value == 0) {



                document.getElementById("divSalary").style.display = "none";
               
   
                if (field != "typeNonResident" && field != "typResident") {
               
                  //  document.getElementById("<%=btnProcess.ClientID%>").style.pointerEvents = "none";
                    document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                    document.getElementById("<%=lblEligibleSettlmtOpen.ClientID%>").innerHTML = "";

                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    $noconflic("#divddlEmployee input.ui-autocomplete-input").focus();
                    $noconflic("#divddlEmployee input.ui-autocomplete-input").select();
                });
                $noCon("#divWarning").alert();
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                $noconflic("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "red");
                }

                return false;

            }

            if (document.getElementById("<%=hiddenEdit.ClientID%>").value == "" || document.getElementById("<%=hiddenEdit.ClientID%>").value == null) {
                //adding

                document.getElementById("divSalary").style.display = "none";
            }
                if (document.getElementById("<%=ddlEmployee.ClientID%>").value != "0") {
                    var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                    document.getElementById("<%=hiddenEmpId.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                }
            //}

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;

            var Details = PageMethods.TicktReqrd(EmpId, CorpId, OrgId, function (response) {
                if (document.getElementById("cphMain_typeNonResident").checked == false) {
                    if (response == "0") {
                        document.getElementById("<%=txtTicktAmt.ClientID%>").disabled = true;
                    }
                    else {
                        document.getElementById("<%=txtTicktAmt.ClientID%>").disabled = false;
                    }
                }
            });
            var LeaveId = "";
            var tdOpenLeave = "";
            var tdLeaveTaken = "";
            var tdLeaveDate = "";
            var tdLeaveBalance_Settle = "";
            var Mode = document.getElementById("<%=HiddenSettlementMode.ClientID%>").value;
            if (Mode == "0") {
                $('#TableLeave').find('tr').each(function () {
                    var row = $(this);

                    var rowid = row.find('input[type="checkbox"]').val();
                    if (document.getElementById('cbMandatory' + rowid).checked == true) {
                        if (LeaveId == "") {
                            LeaveId = row.find('#tdLeaveID' + rowid).html();
                         //   document.getElementById("<%=HiddenLeaveId.ClientID%>").value = LeaveId;

                        }

                        if (tdOpenLeave == "") {
                            tdOpenLeave = row.find('#tdLeaveTotalCount' + rowid).html();
                        }

                        if (tdLeaveTaken == "") {
                            tdLeaveTaken = row.find('#tdLeaveTakenCount' + rowid).html();
                        }
                        if (tdLeaveDate == "") {
                            tdLeaveDate = row.find('#tdLeaveDate' + rowid).html();
                        }
                        if (tdLeaveBalance_Settle == "") {
                            tdLeaveBalance_Settle = row.find('#tdLeaveBalance_Settle' + rowid).html();
                        }
                    }
                });

                if (LeaveId == "") {
                    document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                    document.getElementById("<%=lblEligibleSettlmtOpen.ClientID%>").innerHTML = "";
                    document.getElementById("cphMain_DivFixedAllowance").style.display = "none";
                    return false;
                }
            }
            var varDate = null;
            if (document.getElementById("cphMain_typeNonResident").checked == true) {
                if (document.getElementById("cphMain_txtdate").value == "") {
                    document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                    $noconflic("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $noconflic("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noconflic("#divWarning").alert();
                    $noconflic(window).scrollTop(0);
                    return false;
                }
                else {
                   
                    var CurrentDate = document.getElementById("<%=hiddenDate.ClientID%>").value.trim();
                    var arrDatePickerDateCurr = CurrentDate.split("-");
                    var TodayDate = new Date(arrDatePickerDateCurr[2], arrDatePickerDateCurr[1] - 1, arrDatePickerDateCurr[0]);


                    var probdate = document.getElementById("<%=txtdate.ClientID%>").value.trim();
                    var arrDatePickerDate1 = probdate.split("-");
                    var probdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);


                    var limit = document.getElementById("<%=HiddenFieldEligibleDaysLmt.ClientID%>").value;
                    var timeDiff = Math.abs(probdate.getTime() - TodayDate.getTime());
                    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));

                    if (parseInt(diffDays) > parseInt(limit)) {
                        document.getElementById("cphMain_txtdate").value = "";
                        document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                        $noconflic("#divWarning").html("Settlement date and current date difference cannot be greater than " + limit + " days.");
                        $noconflic("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $noconflic("#divWarning").alert();
                        $noconflic(window).scrollTop(0);
                        return false;
                        }
                    if (document.getElementById("cphMain_txtdate").value != "") {
                        varDate = document.getElementById("cphMain_txtdate").value;
                    }
                }
            }
            var IndividualRound = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;
            var OffDaysSts = document.getElementById("<%=HiddenOFfdaysSts.ClientID%>").value;
            var Details = PageMethods.EmployeeDetails(EmpId, CorpId, OrgId,DecimalCnt,LeaveId,tdOpenLeave,tdLeaveTaken,tdLeaveDate,tdLeaveBalance_Settle,Mode,varDate,IndividualRound,OffDaysSts, function (response) {


                if (response[34] != "" && response[34] != null) {
                    document.getElementById("<%=HiddenFieldOnProbationSts.ClientID%>").value = response[34];
                }


                if (response[31] != "" && response[31] != null) {
                    document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value = response[31];
                }
                if (response[32] != "" && response[32] != null) {
                    document.getElementById("<%=HiddenFieldToDate.ClientID%>").value = response[32];
                 }


                if (response[29] != "" && response[29] != null) {

                    document.getElementById("<%=lblRefNo.ClientID%>").innerHTML = response[0];

                 }


                if (response[0] != "" && response[0] != null) {

                    document.getElementById("<%=lblRefNo.ClientID%>").innerHTML = response[0];

                }
                else {
                    document.getElementById("<%=lblRefNo.ClientID%>").innerHTML = "";
                }
                if (response[1] != "" && response[1] != null) {

                    document.getElementById("<%=lblRejoinDate.ClientID%>").innerHTML = response[1];
                    document.getElementById("<%=hiddenRejoinDt.ClientID%>").value = response[1];
                }
                else {
                    document.getElementById("<%=lblRejoinDate.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenRejoinDt.ClientID%>").value = "";
                }



                if (response[33] != "" && response[33] != null) {

                    document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = response[33];
                    document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = response[33];
                }
                else {
                    document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                    document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";
                }
           



                if (document.getElementById("<%=hiddenView.ClientID%>").value == "") {
                    if (response[30] != "" && response[30] != null) {
                       
                        document.getElementById("<%=lblEligibleSettlmtOpen.ClientID%>").innerHTML = response[30];
                        document.getElementById("<%=HiddenFieldOpenLeaveDays.ClientID%>").value = response[30];

                    }
                    else {
                        document.getElementById("<%=lblEligibleSettlmtOpen.ClientID%>").innerHTML = "";
                        document.getElementById("<%=HiddenFieldOpenLeaveDays.ClientID%>").value = "";
                    }
                }

               


                if (response[13] =="true") {
                    document.getElementById("cphMain_DivFixedAllowance").style.display = "";
                    document.getElementById("cphMain_cbxFA").checked = false;
                    
                }
                else {
                    document.getElementById("cphMain_DivFixedAllowance").style.display = "none";
                }
                if (response[14] != "" && response[14] != null) {
                    document.getElementById("<%=HiddenLeaveTypeId.ClientID%>").value = response[14];
                }
                if (response[15] != "" && response[15] != null) {
                    document.getElementById("<%=HiddenNoLeaveDeduct.ClientID%>").value = response[15];
                }
                           
            });
           if (document.getElementById("<%=hiddenEdit.ClientID%>").value == "") {
                document.getElementById("<%=btnProcess.ClientID%>").style.pointerEvents = "";
           }
        }

        function SettlmtDtlsDisplay() {
            if (document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value != "0" && document.getElementById("<%=HiddenFieldOnProbationSts.ClientID%>").value=="0") {
                if (ValidateSettlment() == true) {

                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure you want to process?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {

                          

                            var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
                            var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;

                            var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
                            var SettlmtDays = document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value;
                            if (document.getElementById("<%=txtTicktAmt.ClientID%>").value != "" || document.getElementById("<%=txtTicktAmt.ClientID%>").value != null) {
                                var Tickt = document.getElementById("<%=txtTicktAmt.ClientID%>").value;
                            }
                            if (document.getElementById("<%=txtOtherAmt.ClientID%>").value != "" || document.getElementById("<%=txtOtherAmt.ClientID%>").value != null) {
                                var OtherAmt = document.getElementById("<%=txtOtherAmt.ClientID%>").value;
                            }
                            if (document.getElementById("<%=txtOtherDeductn.ClientID%>").value != "" || document.getElementById("<%=txtOtherDeductn.ClientID%>").value != null) {
                                var OtherDeductnAmt = document.getElementById("<%=txtOtherDeductn.ClientID%>").value;
                            }

                            var RejoinDt = document.getElementById("<%=hiddenRejoinDt.ClientID%>").value;
                            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                            var LeaveId = "";
                            var tdOpenLeave = "";
                            var tdLeaveTaken = "";
                            var tdLeaveDate = "";
                            var FixedAllowanceCheck = 0;

                            var Mode = document.getElementById("<%=HiddenSettlementMode.ClientID%>").value;
                            if (Mode == "0") {
                                $('#TableLeave').find('tr').each(function () {
                                    var row = $(this);

                                    var rowid = row.find('input[type="checkbox"]').val();
                                    if (document.getElementById('cbMandatory' + rowid).checked == true) {
                                        if (LeaveId == "") {
                                            LeaveId = row.find('#tdLeaveID' + rowid).html();
                                            document.getElementById("<%=HiddenLeaveId.ClientID%>").value = LeaveId;
                                        }

                                        if (tdOpenLeave == "") {
                                            tdOpenLeave = row.find('#tdLeaveTotalCount' + rowid).html();
                                        }

                                        if (tdLeaveTaken == "") {
                                            tdLeaveTaken = row.find('#tdLeaveTakenCount' + rowid).html();
                                        }

                                        if (tdLeaveDate == "") {
                                            tdLeaveDate = row.find('#tdLeaveDate' + rowid).html();
                                        }

                                    }
                                });
                                if (document.getElementById("cphMain_DivFixedAllowance").style.display == "none") {
                                    FixedAllowanceCheck = 0;

                                }
                                else {
                                    if (document.getElementById("cphMain_cbxFA").checked == true) {
                                        FixedAllowanceCheck = 1;
                                    }
                                    else {
                                        FixedAllowanceCheck = 0;
                                    }
                                }
                            }
                            var varDate = null;
                            if (document.getElementById("cphMain_txtdate").value != "") {
                                varDate = document.getElementById("cphMain_txtdate").value;
                            }

                            var CrncyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;
                            var IndividualRound = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;
                            var ZeroWorkFixed = document.getElementById("<%=HiddenFieldWorkdayFixedPayrlMode.ClientID%>").value;

                            var Details = PageMethods.SalaryDtls(EmpId, SettlmtDays, RejoinDt, DecimalCnt, CorpId, OrgId, LeaveId, tdLeaveTaken, tdLeaveDate, FixedAllowanceCheck,varDate,Mode,CrncyId,IndividualRound,ZeroWorkFixed, function (response) {          

                                document.getElementById("<%=lblPrevMnthArrAmt.ClientID%>").innerHTML = response[48];
                                document.getElementById("<%=HiddenFieldPrevArrAmt.ClientID%>").value = response[48];
                                document.getElementById("<%=HiddenFieldPrevMntRejoinDate.ClientID%>").value = response[49];

                                if (parseFloat(response[48]) >= 0) {
                                    document.getElementById("<%=lblArrearPrev.ClientID%>").innerHTML = "Arrear Amount Addition";
                                }
                                else {
                                    document.getElementById("<%=lblArrearPrev.ClientID%>").innerHTML = "Arrear Amount Deduction";
                                    document.getElementById("<%=lblPrevMnthArrAmt.ClientID%>").innerHTML = parseFloat(response[48])*-1;
                                }
                                


                                if (response[28] != "" && response[28] != null) {
                                    document.getElementById("divSalary").style.display = "none";

                                    if (response[28] == "Not rejoined") {
                                        $noCon("#divWarning").html("Sorry!All leaves are settled.");
                                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                        });
                                    }
                                    else if (response[28] == "Salary process pending") {
                                        $noCon("#divWarning").html("Sorry! Previous month salary processing pending.");
                                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                        });
                                    }
                                    else if (response[28] == "MissingAttendance") {
                                        $noCon("#divWarning").html("Sorry!Some days attendance missing.");
                                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                        });
                                    }
                                }
                                else {
                                    document.getElementById("<%=HiddenFieldChangeSts.ClientID%>").value = 1;
                                    if (response[46] != "" && response[46] != null) {
                                        document.getElementById("<%=HiddenFieldAddDtls.ClientID%>").value = response[46];
                                    }
                                    if (response[47] != "" && response[47] != null) {
                                        document.getElementById("<%=HiddenFieldDedDtls.ClientID%>").value = response[47];
                                    }
                                    if (response[44] != "" && response[44] != null) {
                                       document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value = response[44];
                                    }
                                    if (response[45] != "" && response[45] != null) {
                                         document.getElementById("<%=HiddenFieldToDate.ClientID%>").value = response[45];
                                    }
                                    document.getElementById("<%=HiddenFieldPrevAddition.ClientID%>").value = response[32];
                                    document.getElementById("<%=HiddenFieldPrevOvertimeAmt.ClientID%>").value = response[33];
                                    document.getElementById("<%=HiddenFieldPrevArrearAmt.ClientID%>").value = response[34];
                                    document.getElementById("<%=HiddenFieldPrevDeduction.ClientID%>").value = response[35];
                                    document.getElementById("<%=HiddenFieldPrevPaymntAmt.ClientID%>").value = response[36];
                                    document.getElementById("<%=HiddenFieldPrevMessAmt.ClientID%>").value = response[37];

                                    document.getElementById("<%=HiddenFieldPrevOtherAddAmt.ClientID%>").value = response[40];
                                    document.getElementById("<%=HiddenFieldPrevOtherDeductAmt.ClientID%>").value = response[41];


                                    document.getElementById("divSalary").style.display = "";
                                    $("#preSalaryPop").attr('data-content', response[29]);
 
                                   
                                    if (response[30] != "" && response[30] != null) {
                                        document.getElementById("<%=lblOpenLeaveSal.ClientID%>").innerHTML = response[30];
                                        document.getElementById("<%=HiddenFieldOpenLeaveSalary.ClientID%>").value = response[30];
                                        
                                     }
                                     else {
                                        document.getElementById("<%=lblOpenLeaveSal.ClientID%>").innerHTML = ""; 
                                        document.getElementById("<%=HiddenFieldOpenLeaveSalary.ClientID%>").value ="";
                                     }

                                    if (response[31] != "" && response[31] != null) {
                                         document.getElementById("<%=lblLeavArrearAmnt.ClientID%>").innerHTML = response[31];
                                         document.getElementById("<%=HiddenFieldLeavArrearAmnt.ClientID%>").value = response[31];

                                     }
                                     else {
                                         document.getElementById("<%=lblLeavArrearAmnt.ClientID%>").innerHTML = "";
                                         document.getElementById("<%=HiddenFieldLeavArrearAmnt.ClientID%>").value = "";
                                     }




                                    if (response[0] != "" && response[0] != null) {

                                        document.getElementById("<%=lblBasicPay.ClientID%>").innerHTML = response[0];
                                        document.getElementById("<%=hiddenBasicPay.ClientID%>").value = response[0];
                                    }
                                    else {
                                        document.getElementById("<%=lblBasicPay.ClientID%>").innerHTML = "";
                                        document.getElementById("<%=hiddenBasicPay.ClientID%>").value = "";
                                    }
                                    if (response[1] != "" && response[1] != null) {


                                        document.getElementById("<%=lblAddition.ClientID%>").innerHTML = response[1];
                                        document.getElementById("<%=hiddenAllownce.ClientID%>").value = response[1];
                                    }
                                    else {
                                        document.getElementById("<%=lblAddition.ClientID%>").innerHTML = "";
                                        document.getElementById("<%=hiddenAllownce.ClientID%>").value = "";
                                    }

                                    if (response[2] != "" && response[2] != null) {

                                        document.getElementById("<%=lblDeduction.ClientID%>").innerHTML = response[2];
                                        document.getElementById("<%=hiddenDeductn.ClientID%>").value = response[2];
                                    }
                                    else {
                                        document.getElementById("<%=lblDeduction.ClientID%>").innerHTML = "";
                                        document.getElementById("<%=hiddenDeductn.ClientID%>").value = "";
                                    }

                                    if (response[3] != "" && response[3] != null) {

                                        document.getElementById("<%=lblTotalPay.ClientID%>").innerHTML = response[3];
                                        document.getElementById("<%=hiddenTotalPay.ClientID%>").value = response[3];
                                    }
                                    else {
                                        document.getElementById("<%=lblTotalPay.ClientID%>").innerHTML = "";
                                        document.getElementById("<%=hiddenTotalPay.ClientID%>").value = "";
                                    }


                                    if (response[4] != "" && response[4] != null) {

                                        document.getElementById("<%=lblSalaryPerDay.ClientID%>").innerHTML = response[4];
                                        document.getElementById("<%=hiddenSalaryPerDay.ClientID%>").value = response[4];
                                    }
                                    else {
                                        document.getElementById("<%=lblSalaryPerDay.ClientID%>").innerHTML = "";
                                        document.getElementById("<%=hiddenSalaryPerDay.ClientID%>").value = "";
                                    }

                                    if (response[5] != "" && response[5] != null) {
                                      //  alert("Yes")

                                        //evm-0023-06-04 start
                                        //var LevSalary = response[5]; cmd19
                                        var LevSalary = parseFloat(response[5]);
                                      //  var LevSalary = parseFloat(response[5]) + parseFloat(document.getElementById("cphMain_lblOpenLeaveSal").innerHTML);
                                        document.getElementById("<%=txtLevSalary.ClientID%>").value = LevSalary;                                        
                                    }
                                    else {
                                        document.getElementById("<%=txtLevSalary.ClientID%>").value = "";
                                    }

                                    if (response[6] != "" && response[6] != null) {

                                        document.getElementById("<%=txtPrevMonthSalary.ClientID%>").value = response[6];
                                        document.getElementById("<%=hiddenPrvsmnt.ClientID%>").value = response[6];
                                    }
                                    else {
                                        document.getElementById("<%=txtPrevMonthSalary.ClientID%>").value = "";
                                        document.getElementById("<%=hiddenPrvsmnt.ClientID%>").value = "";
                                    }

                                    if (response[7] != "" && response[7] != null) {

                                        document.getElementById("<%=txtCurntMnthSalary.ClientID%>").value = response[7];
                                    }
                                    else {
                                        document.getElementById("<%=txtCurntMnthSalary.ClientID%>").value = "";
                                    }

                                    if (response[8] != "" && response[8] != null) {

                                        document.getElementById("<%=txtNetAmt.ClientID%>").value = response[8];
                                        AmountChecking('cphMain_txtNetAmt');
                                        document.getElementById("<%=hiddenNetAmt.ClientID%>").value = response[8];
                                    }
                                    else {
                                        document.getElementById("<%=txtNetAmt.ClientID%>").value = "0";
                                    }
                                    if (response[9] != "" && response[9] != null) {
                                        document.getElementById("<%=txtLstSettlddate.ClientID%>").value = response[9];
                                        document.getElementById("<%=hiddenSettldDate.ClientID%>").value = response[9];
                                    }
                                    else {
                                        document.getElementById("<%=txtLstSettlddate.ClientID%>").value = "";
                                        document.getElementById("<%=hiddenSettldDate.ClientID%>").value = "";
                                    }
                                    if (Mode == "0") {
                                        var LeaveFrmDate = "";
                                        $('#TableLeave').find('tr').each(function () {
                                            var row = $(this);

                                            var rowid = row.find('input[type="checkbox"]').val();
                                            if (document.getElementById('cbMandatory' + rowid).checked == true) {
                                                LeaveFrmDate = row.find('#tdLeaveFrmDate' + rowid).html();
                                            }
                                        });
                                        if (LeaveFrmDate == response[9]) {
                                            document.getElementById("<%=txtLstSettlddate.ClientID%>").value = "";
                                        }
                                    }
                                    if (response[10] != "" && response[10] != null) {
                                        document.getElementById("<%=lblOvertm.ClientID%>").innerHTML = response[10];
                                        document.getElementById("<%=hiddenOvertm.ClientID%>").value = response[10];
                                    }
                                    else {
                                        document.getElementById("<%=lblOvertm.ClientID%>").innerHTML = "0";
                                        document.getElementById("<%=hiddenOvertm.ClientID%>").value = "";
                                    }

                                    if (response[11] != "" && response[11] != null) {
                                        document.getElementById("<%=lblInstlmnt.ClientID%>").innerHTML = response[11];
                                        document.getElementById("<%=hiddenDeductnMstr.ClientID%>").value = response[11];
                                    }
                                    else {
                                        document.getElementById("<%=lblInstlmnt.ClientID%>").innerHTML = "0";
                                        document.getElementById("<%=hiddenDeductnMstr.ClientID%>").value = "";
                                    }
                                    if (response[12] != "" && response[12] != null) {
                                        document.getElementById("<%=MessDedctn.ClientID%>").innerHTML = response[12];
                                        document.getElementById("<%=hiddenMessAmount.ClientID%>").value = response[12];
                                    }
                                    if (response[13] != "" && response[13] != null) {
                                        if (response[13] == "1") {
                                            $noconflic("#divWarning").html("Check any paid leave pending.");
                                            $noconflic("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                                            });
                                            $noconflic("#divWarning").alert();
                                            $noconflic(window).scrollTop(0);
                                            document.getElementById("divSalary").style.display = "none";
                                        }
                                    }


                                    if (response[38] != "" && response[38] != null) {
                                        document.getElementById("<%=txtOtherAmt.ClientID%>").value = response[38];
                                        document.getElementById("<%=hiddenOtherAdditionAmt.ClientID%>").value = response[38];
                                    }

                                    if (response[42] != "" && response[42] != "null" && response[42] != null) {
                                        $("#aIdOtherAddition").attr('data-content', response[42]);
                                        $("#aIdOtherAddition").css("display", "");
                                    }
                                    else {
                                        $("#aIdOtherAddition").css("display", "none");
                                    }

                                    if (response[39] != "" && response[39] != null) {
                                        document.getElementById("<%=txtOtherDeductn.ClientID%>").value = response[39];
                                        document.getElementById("<%=hiddenOtherDeductionAmt.ClientID%>").value = response[39];
                                    }
                                    if (response[43] != "" && response[43] != "null" && response[43] != null) {
                                        $("#aIdOtherDeduction").attr('data-content', response[43]);
                                        $("#aIdOtherDeduction").css("display", "");
                                    }
                                    else {
                                        $("#aIdOtherDeduction").css("display", "none");
                                    }


                                    AmountCheckingLbl('cphMain_lblAddition');
                                    AmountCheckingLbl('cphMain_lblTotalPay');
                                    AmountCheckingLbl('cphMain_lblDeduction');
                                    AmountCheckingLbl('cphMain_MessDedctn');
                                    AmountChecking('cphMain_txtLevSalary');
                                    AmountChecking('cphMain_txtPrevMonthSalary');
                                    AmountChecking('cphMain_txtCurntMnthSalary');
                                    AmountChecking('cphMain_txtTicktAmt');
                                    AmountChecking('cphMain_txtOtherAmt');
                                    AmountChecking('cphMain_txtOtherDeductn');
                                    AmountChecking('cphMain_txtNetAmt');
                                    AmountCheckingLbl('cphMain_lblBasicPay');


                                    AmountCheckingLbl('cphMain_lblSalaryPerDay');
                                    AmountCheckingLbl('cphMain_lblOvertm');
                                    AmountCheckingLbl('cphMain_lblInstlmnt');
                                    AmountCheckingLbl('cphMain_lblPrevMnthArrAmt');
                                }
                            });

                        }

                        else {
                            return false;
                        }
                    });
                }
            }
            else {

                if (document.getElementById("<%=HiddenFieldOnProbationSts.ClientID%>").value == "1") {
                    $noCon("#divWarning").html("Sorry! Employee is on probation period.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                }
                else {
                    $noCon("#divWarning").html("Sorry! Your all leaves are settled.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                }

            }

            return false;

        }

        function SalChange(obj) {

            AmountChecking(obj);

            var txt = document.getElementById(obj).value.trim();
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

            var EmpId = document.getElementById("<%=hiddenEmpId.ClientID%>").value;
            var SettlmtDays = document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value;

           var LevSal = "0";
           var PrevMnth = "0";
           var CurrntMnth = "0";
           var Tickt = "0";
           var OtherAmt = "0";
           var OtherDeductnAmt = "0";
           var PrevArrAmnt = document.getElementById("<%=HiddenFieldPrevArrAmt.ClientID%>").value;
           if (document.getElementById("<%=txtLevSalary.ClientID%>").value != "" && document.getElementById("<%=txtLevSalary.ClientID%>").value != null) {
                LevSal = document.getElementById("<%=txtLevSalary.ClientID%>").value;
            }

            if (document.getElementById("<%=txtPrevMonthSalary.ClientID%>").value != "" && document.getElementById("<%=txtPrevMonthSalary.ClientID%>").value != null) {
               PrevMnth = document.getElementById("<%=txtPrevMonthSalary.ClientID%>").value;
            }


            if (document.getElementById("<%=txtCurntMnthSalary.ClientID%>").value != "" && document.getElementById("<%=txtCurntMnthSalary.ClientID%>").value != null) {
               CurrntMnth = document.getElementById("<%=txtCurntMnthSalary.ClientID%>").value;
            }

            if (document.getElementById("<%=txtTicktAmt.ClientID%>").value != "" && document.getElementById("<%=txtTicktAmt.ClientID%>").value != null) {
               Tickt = document.getElementById("<%=txtTicktAmt.ClientID%>").value;
            }

            if (document.getElementById("<%=txtOtherAmt.ClientID%>").value != "" && document.getElementById("<%=txtOtherAmt.ClientID%>").value != null) {
               OtherAmt = document.getElementById("<%=txtOtherAmt.ClientID%>").value;
            }

            if (document.getElementById("<%=txtOtherDeductn.ClientID%>").value != "" && document.getElementById("<%=txtOtherDeductn.ClientID%>").value != null) {
               OtherDeductnAmt = document.getElementById("<%=txtOtherDeductn.ClientID%>").value;
            }
            if (document.getElementById("<%=lblOpenLeaveSal.ClientID%>").innerHTML != "" && document.getElementById("<%=lblOpenLeaveSal.ClientID%>").innerHTML != null) {
               strOpenLeaveSal = document.getElementById("<%=lblOpenLeaveSal.ClientID%>").innerHTML;
            }
            if (document.getElementById("<%=lblLeavArrearAmnt.ClientID%>").innerHTML != "" && document.getElementById("<%=lblLeavArrearAmnt.ClientID%>").innerHTML != null) {
               strLeavArrearAmnt = document.getElementById("<%=lblLeavArrearAmnt.ClientID%>").innerHTML;
            }

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var IndividualRound = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;
            var Details = PageMethods.SalaryDtlsChanged(EmpId, SettlmtDays, LevSal, PrevMnth, CurrntMnth, Tickt, OtherAmt, OtherDeductnAmt, DecimalCnt, strOpenLeaveSal, strLeavArrearAmnt,IndividualRound,PrevArrAmnt, function (response) {

               if (response[0] != "" && response[0] != null) {

                   document.getElementById("<%=txtNetAmt.ClientID%>").value = response[0];
                    AmountChecking('cphMain_txtNetAmt');
                    addCommas('cphMain_txtNetAmt');
                    document.getElementById("<%=hiddenNetAmt.ClientID%>").value = response[0];
                }
                else {
                    document.getElementById("<%=txtNetAmt.ClientID%>").value = "0";
                }
                if (response[1] != "" && response[1] != null) {
                    document.getElementById("<%=txtTicktAmt.ClientID%>").value = response[1];
                    AmountChecking('cphMain_txtTicktAmt');
                    addCommas('cphMain_txtTicktAmt');
                }
            });
        }

        function Clear() {

            if (confirmbox > 0) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to clear?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {

                        $noCon('form').each(function () { this.reset() });
                        document.getElementById("<%=ddlEmployee.ClientID%>").value = "--SELECT EMPLOYEE--";
                        document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblAddition.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblBasicPay.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblDeduction.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblRefNo.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblRejoinDate.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblSalaryPerDay.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblTotalPay.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblInstlmnt.ClientID%>").innerHTML = "";
                        document.getElementById("<%=lblOvertm.ClientID%>").innerHTML = "";
                        document.getElementById("cphMain_DivLeaveDate").innerHTML = "";
                        document.getElementById("<%=HiddenLeaveId.ClientID%>").value = "";
                        document.getElementById("<%=btnProcess.ClientID%>").style.pointerEvents = "none";
                        $noconflic("#divddlEmployee input.ui-autocomplete-input").focus();
                        $noconflic("#divddlEmployee input.ui-autocomplete-input").select();
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }

            else {
                $noCon('form').each(function () { this.reset() });
                document.getElementById("<%=ddlEmployee.ClientID%>").value = "--SELECT EMPLOYEE--";
                document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblAddition.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblBasicPay.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblDeduction.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblRefNo.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblRejoinDate.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblSalaryPerDay.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblTotalPay.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblInstlmnt.ClientID%>").innerHTML = "";
                document.getElementById("<%=lblOvertm.ClientID%>").innerHTML = "";
                document.getElementById("cphMain_DivLeaveDate").innerHTML = "";
                document.getElementById("<%=HiddenLeaveId.ClientID%>").value = "";
                document.getElementById("<%=btnProcess.ClientID%>").style.pointerEvents = "none";
                $noconflic("#divddlEmployee input.ui-autocomplete-input").focus();
                $noconflic("#divddlEmployee input.ui-autocomplete-input").select();
                return false;
            }

        }


        function addCommas(textboxid) {
            RemoveTag(textboxid);
            nStr = document.getElementById(textboxid).value;
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

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
                document.getElementById('' + textboxid + '').value = x1;
                //return x1;
            else
                document.getElementById('' + textboxid + '').value = x1 + "." + x2;
            // return x1 + "." + x2;



        }

        function AmountChecking(textboxid) {

            var txtPerVal = document.getElementById(textboxid).value;
         
            txtPerVal = txtPerVal.replace(/,/g, "");
         


            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').value = "";
                    return false;
                }
                else {
                    //// uncomment this to avoid - numbers
                    // if (txtPerVal < 0) {
                    // document.getElementById('' + textboxid + '').value = "";
                    //return false;
                    // }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').value = n;

                }
            }

            addCommas(textboxid);
        }

        function AmountCheckingLbl(textboxid) {

            var txtPerVal = document.getElementById(textboxid).innerHTML;

            txtPerVal = txtPerVal.replace(/,/g, "");



            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').innerHTML = "";
                    return false;
                }
                else {
                    //// uncomment this to avoid - numbers
                    // if (txtPerVal < 0) {
                    // document.getElementById('' + textboxid + '').value = "";
                    //return false;
                    // }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);

                    }
                    document.getElementById('' + textboxid + '').innerHTML = n;

                }
            }

            addCommasLbl(textboxid);
        }
        function addCommasLbl(textboxid) {


            nStr = document.getElementById(textboxid).innerHTML;
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

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
                document.getElementById('' + textboxid + '').innerHTML = x1;
                //return x1;
            else
                document.getElementById('' + textboxid + '').innerHTML = x1 + "." + x2;
            // return x1 + "." + x2;

        }


    </script>

         <script>
             function PrintElem(elem) {
                 var mywindow = window.open('', '_blank');

                 mywindow.document.write('<html><head><title>' + document.title + '</title>');

                 mywindow.document.write('<link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />');
                 mywindow.document.write('<link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />');
                 mywindow.document.write('<link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />');
                 mywindow.document.write('<link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />');
                 mywindow.document.write('<link href="/css/HCM/main.css" rel="stylesheet" />');
                 mywindow.document.write('<link href="/css/HCM/CommonCss.css" rel="stylesheet" />');
                 mywindow.document.write('</head><body >');
                 // mywindow.document.write('<h1>' + document.title + '</h1>');

                 mywindow.document.write('<div  id="printimg" onclick="window.print();" class="formtxt" style="cursor: pointer;float: right">');

                 mywindow.document.write('<img src="/Images/Other Images/imgPrint.png" /><strong style="font-size:15px;">Print &nbsp &nbsp</strong></div>');

                 mywindow.document.write(document.getElementById(elem).innerHTML);
                 mywindow.document.write('</body></html>');

                 mywindow.document.close(); // necessary for IE >= 10
                 mywindow.focus(); // necessary for IE >= 10*/

                 //mywindow.print();
                 //mywindow.close();
                // ValidateSettlment
                 return true;
             }
             function ModeChange(field) {
                 if (confirmbox > 0) {
                     ezBSAlert({
                         type: "confirm",
                         messageText: "Are you sure you want to change the mode?",
                         alertType: "info"
                     }).done(function (e) {
                         if (e == true) {
                             if (field == "typResident") {
                                 document.getElementById("cphMain_typResident").checked = true;
                                 document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "0";
                                 document.getElementById("cphMain_DivLeave").style.display = "";
                                 document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                                 //   document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";
                                 document.getElementById("cphMain_DivDate").style.display = "none";
                                 LoadLeaveDate(field);
                             }
                             else {
                                 document.getElementById("cphMain_typeNonResident").checked = true;
                                 document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "1";
                                 document.getElementById("cphMain_DivLeave").style.display = "none";
                                 document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                                 //    document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";

                                 document.getElementById("cphMain_DivDate").style.display = "";
                                 EmpDtlsDisplay(field);


                             }
                         }
                         else {
                             if (field == "typResident") {
                                 document.getElementById("cphMain_typResident").checked = true;
                                 document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "0";
                                 document.getElementById("cphMain_DivLeave").style.display = "";
                                 document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                                 //   document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";
                                 document.getElementById("cphMain_DivDate").style.display = "none";
                                 LoadLeaveDate(field);
                             }
                             else {
                                 document.getElementById("cphMain_typeNonResident").checked = true;
                                 document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "1";
                                 document.getElementById("cphMain_DivLeave").style.display = "none";
                                 document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                                 //    document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";

                                 document.getElementById("cphMain_DivDate").style.display = "";

                                 EmpDtlsDisplay(field);

                             }
                         }
                         //  if (document.getElementById("cphMain_typResident").checked == true) {
                         //       document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "0";
                         //      document.getElementById("cphMain_DivLeave").style.display = "";
                         //      document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                         //   document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";
                         //       document.getElementById("cphMain_DivDate").style.display = "none";
                         //alert("ooooo");
                         //       LoadLeaveDate();
                         //   }
                         //   else if (document.getElementById("cphMain_typeNonResident").checked == true) {
                         //       document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "1";
                         //      document.getElementById("cphMain_DivLeave").style.display = "none";
                         //      document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                         //    document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";

                         //      document.getElementById("cphMain_DivDate").style.display = "";

                         //      EmpDtlsDisplay();

                         //   }
                     });

                     //  }
                 }
                 else {
                     if (field == "typResident") {
                         document.getElementById("cphMain_typResident").checked = true;
                         document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "0";
                         document.getElementById("cphMain_DivLeave").style.display = "";
                         document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                         //   document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";
                         document.getElementById("cphMain_DivDate").style.display = "none";
                         LoadLeaveDate(field);
                     }
                     else {
                         document.getElementById("cphMain_typeNonResident").checked = true;
                         document.getElementById("<%=HiddenSettlementMode.ClientID%>").value = "1";
                         document.getElementById("cphMain_DivLeave").style.display = "none";
                         document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
                         //    document.getElementById("<%=hiddenSettlmtDays.ClientID%>").value = "";

                         document.getElementById("cphMain_DivDate").style.display = "";

                         EmpDtlsDisplay(field);


                     }
                 }
                 return false;

             }
    </script>
    <script>
        $(document).ready(function () {
            $('[data-toggle="popover"]').popover();
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:HiddenField ID="HiddenFieldOnProbationSts" runat="server" value="0"/>
     <asp:HiddenField ID="HiddenFieldFromDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldToDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldChangeSts" runat="server" />

    <asp:HiddenField ID="HiddenFieldAddDtls" runat="server" />
    <asp:HiddenField ID="HiddenFieldDedDtls" runat="server" />
     <asp:HiddenField ID="HiddenFieldPrevArrAmt" runat="server" value="0"/>
     <asp:HiddenField ID="HiddenFieldPrevMntRejoinDate" runat="server"/>

     <asp:HiddenField ID="HiddenFieldEligibleDaysLmt" runat="server" />

    <asp:HiddenField ID="hiddenDate" runat="server" />
     <asp:HiddenField ID="hiddenEmpId" runat="server" />
         <asp:HiddenField ID="hiddenSettlmtDays" runat="server" />
         <asp:HiddenField ID="hiddenRejoinDt" runat="server" />
             <asp:HiddenField ID="HiddenLeaveId" runat="server" />
             <asp:HiddenField ID="hiddenBasicPay" runat="server" />
                 <asp:HiddenField ID="hiddenDeductn" runat="server" />
             <asp:HiddenField ID="hiddenAllownce" runat="server" />
                 <asp:HiddenField ID="hiddenCorpId" runat="server" />
                     <asp:HiddenField ID="hiddenOrgId" runat="server" />
                         <asp:HiddenField ID="hiddenTotalPay" runat="server" />
                             <asp:HiddenField ID="hiddenSalaryPerDay" runat="server" />
                            <asp:HiddenField ID="hiddenNetAmt" runat="server" />
                                <asp:HiddenField ID="hiddenEdit" runat="server" />
     <asp:HiddenField ID="hiddenView" runat="server" />
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
         <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
          <asp:HiddenField ID="hiddenSettldDate" runat="server" />
              <asp:HiddenField ID="hiddenOvertm" runat="server" />
              <asp:HiddenField ID="hiddenDeductnMstr" runat="server" />
      <asp:HiddenField ID="hiddenMessAmount" runat="server" />
    <asp:HiddenField ID="HiddenSettlementMode" runat="server" />
    <asp:HiddenField ID="HiddenLeaveTypeLeave" runat="server" />
    <asp:HiddenField ID="HiddenNoLeaveDeduct" runat="server" />
    <asp:HiddenField ID="HiddenLeaveTypeId" runat="server" />
    <asp:HiddenField ID="HiddenLeaveSettledDays" runat="server" />
    <asp:HiddenField ID="hiddenPrvsmnt" runat="server" />


      <asp:HiddenField ID="HiddenFieldOpenLeaveDays" runat="server" />
      <asp:HiddenField ID="HiddenFieldOpenLeaveSalary" runat="server" />
     <asp:HiddenField ID="HiddenFieldLeavArrearAmnt" runat="server" />


     <asp:HiddenField ID="HiddenFieldPrevAddition" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldPrevOvertimeAmt" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldPrevArrearAmt" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldPrevDeduction" runat="server" Value="0"/>
     <asp:HiddenField ID="HiddenFieldPrevPaymntAmt" runat="server" Value="0"/>
     <asp:HiddenField ID="HiddenFieldPrevMessAmt" runat="server" Value="0"/>
     <asp:HiddenField ID="HiddenFieldPrevSalaryDtls" runat="server" />
      <asp:HiddenField ID="hiddenOtherAdditionAmt" runat="server" />
      <asp:HiddenField ID="hiddenOtherDeductionAmt" runat="server" />

      <asp:HiddenField ID="HiddenFieldPrevOtherAddAmt" runat="server" />
      <asp:HiddenField ID="HiddenFieldPrevOtherDeductAmt" runat="server" />
      <asp:HiddenField ID="HiddenFieldOtherAddDtls" runat="server" />
      <asp:HiddenField ID="HiddenFieldOtherDeductDtls" runat="server" />
     <asp:HiddenField ID="HiddenOFfdaysSts" runat="server" value="0"/>
     <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" value="0"/>
     <asp:HiddenField ID="HiddenFieldWorkdayFixedPayrlMode" runat="server" value="0"/>
    
     <div id="divList" class="list" onclick="ConfirmMessageLIST();" runat="server" style="position: fixed; right: 0%; top: 23%; height: 26.5px; z-index: 1;">
     </div>


  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <script src="/js/HCM/Common.js"></script>
      <div id="main" role="main">

<div class="alert alert-success" id="divdatealert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button>
</div>

   <div class="alert alert-warning" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

        <div id="content">

   <div id="divprint" visible="false" runat="server" style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 5%; font-family: Calibri;" class="print">
     <a id="print_cap" onclick="return openInNewTab();" target="_blank" data-title="Leave Settlement" href="#" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print</span></a>                               
   </div>
    <asp:Button ID="btnPrint" runat="server" Style="display: none" Text="Print" OnClick="btnPrint_Click" />
    <div id="divPrintPayslip" visible="false" runat="server" style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 5%; font-family: Calibri;" class="print">
     <a id="A1" onclick="return openInNewTabPayslip();" target="_blank" data-title="Pay Slip" href="#" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print Pay Slip</span></a>                               
   </div>


<%--    <div id="divprint">
     <button type="button"  style="float: right;margin-top: 1%;" onclick="return PrintElem('divPrintContent')" class="btn btn-primary">Print</button>                             
   </div>--%>
<%--            <div class="row">
                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-4">
                    <h1 class="page-title txt-color-blueDark">
                        <i class="fa-fw fa fa-home"></i>
                        Leave Settlement
                    </h1>
                </div>
            </div>--%>

<%--            <section id="widget-grid" class="">

                <div class="row">--%>
<%--                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">--%>
<%--                        <div class="jarviswidget" id="wid-id-0">--%>

                            <header>

                                <label id="lblHeader" class="pageh2"  runat="server">Edit Leave Settlement</label>

                            </header>

                            <div id="divprintDtl" class="smart-form" style="float: left; width: 93.5%;">

                           <div id="divPrintContent" runat="server" >

                                <div id="divEmp" style="float:left;width:98%;margin-top: 1%;border: 1px solid;padding: 10px;">


                                   <div style="width: 100%; float: left;margin-top: 1%;" class="formdiv">
                                        <div id="div1" style="width: 50%; float: left; ">
                                      <label class="lblh2" style="float: left;width: 37%;margin-left: 5%;margin-top:0%;">Settlement Mode</label>
                                      <div   class="smart-form" style="float: left; width: 57%;">
                                           <div class="inline-group" style="padding-top: 3px; float: left; margin-bottom: 1px;padding-left: 1%;">
                                             <label class="radio">
                                                 <input type="radio"  tabindex="5" checked="true" onchange="ModeChange('typResident');"  onkeypress="return DisableEnter(event)" runat="server" id="typResident" style="display:block" name="optradio"  />
                                                   <i></i>Based On Requested Leave
                                             </label>
                                             <label class="radio">
                                                 <input type="radio" id="typeNonResident" tabindex="6" onchange="ModeChange('typeNonResident');"  onkeypress="return DisableEnter(event)" runat="server" style="display:block" name="optradio" />
                                                    <i></i>Based On Eligible Days
                                             </label>
                                            </div>
                                      </div>
                                     </div>

                                         <div style="width: 50%; float: left;">
                                            <div id="divRef">
                                            <section style="width: 95%; margin-left: 7%;margin-top:1%;">
                                                <label class="lblh2" style="float: left;width: 19%;margin-top:0%;">Ref#</label>
                                                <asp:Label ID="lblRefNo" runat="server" style="float: left;width: 80%;"></asp:Label>
                                            </section>
                                           </div>
                                        </div>

                                    </div>
                                <div id="div2" style="width:100%;margin-top: 1%;" class="formdiv">
                                   <div class="col-md-6">
                               <div id="divddlEmployee" style="width: 100%; float: left; ">
                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left;width: 40%;">Employee*</label>   
                                                 <label class="select" style="float: left;width: 52%;">                                     
                                                <asp:DropDownList runat="server" ID="ddlEmployee" onkeypress="return DisableEnter(event);" CssClass="form-control" onchange="LoadLeaveDate()" ></asp:DropDownList>
                                                 </label>
                                            </section>
                                        </div>
                                   </div>
                               <div id="DivDate" runat="server" class="form-group col-md-4" style="padding-left: 3.4%;">
                              <label for="example-text-input" class="lblh2">Date<span>*</span></label>
                              <div class="col-md-8">
                                          <input id="txtdate" readonly="readonly"  style="background-color: #fff;" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="EmpDtlsDisplay();"  class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                      </div>
                                       <script>

                                           var presenrdate = document.getElementById("<%=hiddenDate.ClientID%>").value;
                                           var arrpresenrdate = presenrdate.split("-");
                                           var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);
                                         
                                          
                                           var dateToday = new Date();
                                           $noCon('#cphMain_txtdate').datepicker({
                                               autoclose: true,
                                               format: 'dd-mm-yyyy',
                                               startDate: PresentFulDate,
                                           });
                                           </script>
                            </div>
                               </div>
                                 <div id="divEmplDtls" style="width:100%;">

                                  <div style="width: 98%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left;margin-top: 2%;margin-left: 0%;">                               

                                         <div style="width: 50%; float: left;">

                                            <section style="width: 100%; margin-left: 2.5%;margin-top:1%;">
                                                <label class="lblh2" style="float: left;width: 40%;margin-top:0%">Total Eligible days</label>
                                                <asp:Label ID="lblEligibleSettlmt" runat="server" ></asp:Label>
                                            </section>

                                        </div>

                                         <div style="width: 50%; float: left;">

                                            <section style="width: 100%; margin-left: 7%;margin-top:1%;">
                                                <label class="lblh2" style="float: left;width: 27%;margin-top:0%;">Join/Resume Date</label>
                                                <asp:Label ID="lblRejoinDate" style="margin-left: 11%;" runat="server" ></asp:Label>
                                            </section>

                                        </div>

                                         <div style="width: 50%; float: left;display:none;">

                                            <section style="width: 100%; margin-left: 2.5%;margin-top:1%;">
                                                <label class="lblh2" style="float: left;width: 40%;margin-top:0%">Open Eligible Settlement days</label>
                                                <asp:Label ID="lblEligibleSettlmtOpen" runat="server" ></asp:Label>
                                            </section>

                                        </div>

                                </div>
                                        
                                     
                                     
                                     <div id="divLeaveTypes" runat="server" style="width: 98%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left;margin-top: 2%;margin-left: 0%;display:none;">                               

                                        

                                     </div>
                                     
                                     
                                                         

                                    <div style="width: 100%; float: left;" class="formdiv">
                                      <div style="width: 50%; float: left;">

                                          <section style="width: 95%; margin-left: 5%;">
                                             <label class="lblh2" style="float: left;width: 27%;">Comments/Remarks</label>        
                                               <label class="select" style="float: right;width: 60%;">
                                              <asp:TextBox ID="txtRemarks" class="form-control" onkeypress="return isTag(event);" onblur="RemoveTag('cphMain_txtRemarks');" onkeydown="textCounter(cphMain_txtRemarks,450)"  runat="server" MaxLength="18" Style=" margin-right: 4%; width: 100%; height: 65px;resize: none;font-family:Calibri;" TextMode="MultiLine" onchange="IncrmntConfrmCounter()" ></asp:TextBox>                               
                                              </label>
                                            </section>
                                      
                                          </div>
<div id="DivLeave" runat="server" style="width: 40%; float: left;padding-left: 4%;">
      <label class="lblh2" style="float: left;width: 16%;">Leaves</label>

 <div id="DivLeaveDate" runat="server" style="width: 60%; float: left;padding-left: 4%;">
     </div>
     </div>

                                    </div>
                                     <br />
                                     <br />
                                     <br />
                                                 <div style="width: 100%;padding-top:3%; float: left;" class="formdiv">
                                          <div id="DivFixedAllowance" runat="server" style="width: 50%;display:none; float: left;">
                                                   <section style="width: 114%; margin-left: 5%;">
                                                    <div   class="smart-form"> 
                                                         <label class="lblh2" for="inputPassword" style="margin-bottom:3px;width: 33%;float: left;">Fixed allowance Applicable</label>
                                                               <div class="col-sm-8">
                                                                        <div   class="smart-form" style="float: left;">    
                                                                                <label class="checkbox">Yes
                                                                                <input type="checkbox" id="cbxFA" onkeypress="return DisableEnter(event)" runat="server" />
                                                                                <i  ></i> </label>
                                                                        </div>
                                                               </div>   
                                                    </div>
                                            </section>
                                              </div>
                                         <asp:Button ID="btnProcess" runat="server" Style="float: left; margin-left: 80%;width: 8%;height: 28px;margin-top:-3%;" class="btn btn-primary" Text="Process"  OnClientClick="return SettlmtDtlsDisplay();" />

</div>  
                                     </div>
                                    </div>

     <div id="divSalary" style="float:left;width:100%;margin-top:2%">
          
        <label id="lblSettlmtDtls" class="pageh2"  runat="server">Settlement details</label>
                              
        <div style="width: 98%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left;margin-top: 2%;">

            <div style="width: 100%; float: left;" class="formdiv">

                    <div style="width: 50%; float: left;">

                          <section style="width: 95%; margin-left: 7%;">
                              <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Basic Pay</label>
                              <asp:Label ID="lblBasicPay" runat="server" ></asp:Label>
                           </section>

                     </div>

                    <div style="width: 50%; float: left;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Addition</label>
                                <asp:Label ID="lblAddition" runat="server" ></asp:Label>
                             </section>

                   </div>

                   <div style="width: 50%; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Deduction</label>
                                <asp:Label ID="lblDeduction" runat="server" ></asp:Label>
                             </section>

                   </div>

                   <div style="width: 50%;display:none; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Total Pay</label>
                                <asp:Label ID="lblTotalPay" runat="server" ></asp:Label>
                             </section>

                   </div>

                    <div style="width: 50%; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Salary/Day</label>
                                <asp:Label ID="lblSalaryPerDay" runat="server" ></asp:Label>
                             </section>

                   </div>
                   <div style="width: 50%; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Overtime Addition</label>
                                <asp:Label ID="lblOvertm" runat="server" ></asp:Label>
                             </section>

                   </div>
                  <div style="width: 50%; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Payment Deduction</label>
                                <asp:Label ID="lblInstlmnt" runat="server" ></asp:Label>
                             </section>

                   </div>

                   <div style="width: 50%; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Mess Deduction</label>
                                <asp:Label ID="MessDedctn" runat="server" ></asp:Label>
                             </section>

                   </div>
                  <div style="width: 50%; float: left;margin-top: 1%;display:none;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Open Leave Salary</label>
                                <asp:Label ID="lblOpenLeaveSal" runat="server" ></asp:Label>
                             </section>

                   </div>
                    <div style="width: 50%; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;">Leave Arrear Amount</label>
                                <asp:Label ID="lblLeavArrearAmnt" runat="server" ></asp:Label>
                             </section>

                   </div>
                <div style="width: 50%; float: left;margin-top: 1%;">

                            <section style="width: 95%; margin-left: 7%;">
                               <label class="lblh2" style="float: left;width: 27%;margin-top: 0%;" id="lblArrearPrev" runat="server">Arrear Amount Addition</label>
                                <asp:Label ID="lblPrevMnthArrAmt" runat="server" ></asp:Label>
                             </section>

                   </div>
             </div>

       </div>













                <div style="width: 50%; float: left;margin-top:2%">
                     <section style="width: 95%; margin-left: 5%;">
                             <label class="lblh2" style="float: left;width: 30%;margin-left:3%;">Last Settled Date</label>
                             <label class="input" style="float: left;width: 60%;">
                            <asp:TextBox ID="txtLstSettlddate" Name="txtLstSettlddate" onblur="return RemoveTag('cphMain_txtLstSettlddate');" onkeypress="return isTag(event);" runat="server" MaxLength="18" Style="text-transform: uppercase; margin-right: 4%;width:98.5%;" onchange="IncrmntConfrmCounter()"></asp:TextBox>
                         </label>
                     </section>
                 </div>

            <div id="divSettlmt" style="background: white;float:left;width:98%;margin-top: 1%;border: 1px solid;padding: 10px;margin-bottom:1%;">

                        <div style="width: 100%; float: left;" class="formdiv">
                              <div style="width: 50%; float: left;">
                                  <section style="width: 95%; margin-left: 5%;">
                                       <label class="lblh2" style="float: left;width: 32%;">Leave Salary</label>
                                        <label class="input" style="float: left;width: 60%;">
                                        <asp:TextBox ID="txtLevSalary" Name="txtLevSalary"  onblur="return SalChange('cphMain_txtLevSalary');" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtLevSalary');" onkeyup="return addCommas('cphMain_txtLevSalary');" runat="server" MaxLength="10" Style="text-align: right; margin-right: 4%;" onchange="IncrmntConfrmCounter()" readonly></asp:TextBox>
                                       </label>
                                  </section>
                              </div>
                              <div style="width: 50%; float: left;">
                                  <section style="width: 95%; margin-left: 5%;">
                                       <label class="lblh2" style="float: left;width: 32%;">Previous Month Salary</label>
                                        <label class="input" style="float: left;width: 60%;">
                                        <asp:TextBox ID="txtPrevMonthSalary" Name="txtPrevMonthSalary" Enabled="false" onblur="return SalChange('cphMain_txtPrevMonthSalary');" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtPrevMonthSalary');" onkeyup="return addCommas('cphMain_txtPrevMonthSalary');" runat="server" MaxLength="10" Style="text-align: right; margin-right: 4%;" onchange="IncrmntConfrmCounter()"></asp:TextBox>
                                        <a id="preSalaryPop" href="#" data-toggle="popover" data-placement="bottom"  data-content="" onclick="return false;">Show Details</a>
                                        </label>
                                  </section>
                                
                              </div>
                      </div>

                 

                        <div style="width: 100%; float: left;" class="formdiv">
                              <div style="width: 50%; float: left;">
                                  <section style="width: 95%; margin-left: 5%;">
                                       <label class="lblh2" style="float: left;width: 32%;">Current Month Salary</label>
                                        <label class="input" style="float: left;width: 60%;">
                                        <asp:TextBox ID="txtCurntMnthSalary"  Name="txtCurntMnthSalary" onblur="return SalChange('cphMain_txtCurntMnthSalary');" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtCurntMnthSalary');" onkeyup="return addCommas('cphMain_txtCurntMnthSalary');" runat="server" MaxLength="10" Style="text-align: right; margin-right: 4%;" onchange="IncrmntConfrmCounter()" readonly ></asp:TextBox>
                                       </label>
                                  </section>
                              </div>
                              <div style="width: 50%; float: left;">
                                  <section style="width: 95%; margin-left: 5%;">
                                       <label class="lblh2" style="float: left;width: 32%;">Ticket Amount</label>
                                        <label class="input" style="float: left;width: 60%;">
                                        <asp:TextBox ID="txtTicktAmt"  Name="txtTicktAmt" onblur="return SalChange('cphMain_txtTicktAmt');" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtTicktAmt');" onkeyup="return addCommas('cphMain_txtTicktAmt');" runat="server" MaxLength="10" Style="text-align: right; margin-right: 4%;" onchange="IncrmntConfrmCounter()"></asp:TextBox>
                                       </label>
                                  </section>
                              </div>
                      </div>

                       <div style="width: 100%; float: left;" class="formdiv">
                              <div style="width: 50%; float: left;">
                                  <section style="width: 95%; margin-left: 5%;">
                                       <label class="lblh2" style="float: left;width: 32%;">Other Amount</label>
                                        <label class="input" style="float: left;width: 60%;">
                                        <asp:TextBox ID="txtOtherAmt"  Name="txtOtherAmt" onblur="return SalChange('cphMain_txtOtherAmt');" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtOtherAmt');" onkeyup="return addCommas('cphMain_txtOtherAmt');" runat="server" MaxLength="10" Style="text-align: right; margin-right: 4%;" onchange="IncrmntConfrmCounter()" readonly></asp:TextBox>
                                        <a id="aIdOtherAddition" href="#" data-toggle="popover" data-placement="bottom"  data-content="" onclick="return false;">Show Details</a>

                                       </label>
                                  </section>
                              </div>
                              <div style="width: 50%; float: left;">
                                  <section style="width: 95%; margin-left: 5%;">
                                       <label class="lblh2" style="float: left;width: 32%;">Other Deduction</label>
                                        <label class="input" style="float: left;width: 60%;">
                                        <asp:TextBox ID="txtOtherDeductn"  Name="txtOtherDeductn" onblur="return SalChange('cphMain_txtOtherDeductn');" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtOtherDeductn');" onkeyup="return addCommas('cphMain_txtOtherDeductn');" runat="server" MaxLength="10" Style="text-align: right;margin-right: 4%;" onchange="IncrmntConfrmCounter()" readonly></asp:TextBox>
                                        <a id="aIdOtherDeduction" href="#" data-toggle="popover" data-placement="bottom"  data-content="" onclick="return false;">Show Details</a>

                                            <br/>


                                       </label>
                                  </section>
                              </div>
                      </div>

                       <div style="width: 100%; float: left;" class="formdiv">
                              <div style="width: 50%; float: left;">
                                  <section style="width: 95%; margin-left: 5%;">
                                       <label class="lblh2" style="float: left;width: 32%;">Net Amount</label>
                                        <label class="input" style="float: left;width: 60%;">
                                        <asp:TextBox ID="txtNetAmt"  Name="txtNetAmt" onblur="return RemoveTag('cphMain_txtNetAmt');" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtNetAmt');" onkeyup="return addCommas('cphMain_txtNetAmt');" runat="server" MaxLength="10" Style="margin-right: 4%;text-align: right;" onchange="IncrmntConfrmCounter()"></asp:TextBox>
                                       </label>
                                  </section>
                              </div>

                      </div>

                                <footer style="background: white;border-color: white;float: right;">
                                    <asp:Button ID="btnSave" runat="server" Style="float: left;" class="btn btn-primary" Text="Save"  OnClientClick="return ValidateSettlment();" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnSaveClose" runat="server" Style="float: left;" class="btn btn-primary" Text="Save & Close"  OnClientClick="return ValidateSettlment();" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnConfirm" Visible="false" runat="server" Style="float: left;" class="btn btn-primary" Text="Confirm"  OnClientClick="return Confirm();" />
                                    <asp:Button ID="btnUpdate" Visible="false" runat="server" Style="float: left;" class="btn btn-primary" Text="Update"  OnClientClick="return ValidateSettlment();" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnUpdateClose" Visible="false" runat="server" Style="float: left;" class="btn btn-primary" Text="Update & Close"  OnClientClick="return ValidateSettlment();"  OnClick="btnSave_Click"/>
                                    <asp:Button ID="btnCancel" runat="server" Style="float: left;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancel();"  />
                                    <asp:Button ID="btnClear" runat="server" Style="float: left;" class="btn btn-primary" Text="Clear" OnClientClick="return Clear();"/>
                                    <asp:Button ID="btnConfrmDeflt" runat="server" Style="display: none;float: left;" class="btn btn-primary" OnClick="btnSave_Click"/>

                                </footer>

                </div>

         </div>
  </div>



                            </div>
<%--                        </div>--%>
<%--                    </article>--%>
<%--                </div>
            </section>--%>
        </div>

              <div id="divPrintCaption" runat="server" style="display: none; height: 150px">

        </div>

                    <div id="divPrintReport" runat="server" style="display:none"></div>
</div>


   <script>


       function ValidateSettlment() {
           var LeaveSelect = false;
           var ret = true;
           document.getElementById("<%=txtRemarks.ClientID%>").value = document.getElementById("<%=txtRemarks.ClientID%>").value.substring(0, 450);

           document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";

           $noconflic("div#divddlEmployee input.ui-autocomplete-input").css("borderColor", "");

           document.getElementById("<%=btnProcess.ClientID%>").style.pointerEvents = "";

           if (document.getElementById("<%=ddlEmployee.ClientID%>").value == "--SELECT EMPLOYEE--" || document.getElementById("<%=ddlEmployee.ClientID%>").value == 0 || document.getElementById("<%=ddlEmployee.ClientID%>").value == "" || document.getElementById("<%=ddlEmployee.ClientID%>").value == null) {

               document.getElementById("divSalary").style.display = "none";
               document.getElementById("<%=lblEligibleSettlmt.ClientID%>").innerHTML = "";
               document.getElementById("<%=lblEligibleSettlmtOpen.ClientID%>").innerHTML = "";

               $noconflic("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
               $noconflic("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   $noconflic("#divddlEmployee input.ui-autocomplete-input").focus();
                   $noconflic("#divddlEmployee input.ui-autocomplete-input").select();
               });
               $noconflic("#divWarning").alert();
               document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
               document.getElementById("<%=btnProcess.ClientID%>").style.pointerEvents = "none";
               $noconflic("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "red");
               document.getElementById("<%=ddlEmployee.ClientID%>").value = "--SELECT EMPLOYEE--";

               ret = false;

           }
           $('#TableLeave').find('tr').each(function () {
               var row = $(this);
               var rowid = row.find('input[type="checkbox"]').val();
               if (document.getElementById('cbMandatory' + rowid).checked == true) {
                   LeaveSelect = true;
               }
           });
           if (document.getElementById("cphMain_typResident").checked == true) {
               if (LeaveSelect == false) {
                   $noconflic("#divWarning").html("Select atleast one leave to settle");
                   $noconflic("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noconflic("#divWarning").alert();
                   $noconflic(window).scrollTop(0);


                   ret = false;
               }
             }
           else if (document.getElementById("cphMain_typeNonResident").checked == true) {
              
               
               if (document.getElementById("cphMain_txtdate").value == "") {
                   document.getElementById("cphMain_txtdate").style.borderColor = "Red";
                   $noconflic("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                   $noconflic("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noconflic("#divWarning").alert();
                   $noconflic(window).scrollTop(0);
                   ret = false;
               }
               else if ($('#TableLeave').find('tr').length > 0) {
                   $noconflic("#divWarning").html("Check any paid leave pending.");
                   $noconflic("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noconflic("#divWarning").alert();
                   $noconflic(window).scrollTop(0);
                   ret = false;
               }

           }
           return ret;
       }
   </script>

                      <style>
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

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });
    </script>
     <script>
    function openInNewTab() {
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
        var strId = document.getElementById("cphMain_hiddenView").value;

        var LastSeetldHiddenDate = "";
            $('#TableLeave').find('tr').each(function () {
            var row = $(this);

            var rowid = row.find('input[type="checkbox"]').val();
            if (document.getElementById('cbMandatory' + rowid).checked == true) {
                LastSeetldHiddenDate = row.find('#tdLeaveFrmDate' + rowid).html();
                 }
             });

            var objOrg = {};
            objOrg.strCorpID = strCorpID;
            objOrg.strOrgIdID = strOrgIdID;
            objOrg.strId = strId;
            objOrg.LastSeetldHiddenDate = LastSeetldHiddenDate;
            objOrg.IndividualRound = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;
            if (strCorpID != "" && strCorpID != null && strOrgIdID != "" && strOrgIdID != null && strId != "") {
                     $.ajax({
                         type: "POST",
                         async: false,
                         contentType: "application/json; charset=utf-8",
                         url: "hcm_Leave_Settlement.aspx/GenerateReport",
                         data: JSON.stringify(objOrg),
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
         function openInNewTabPayslip() {


             $('#TableLeave').find('tr').each(function () {
                 var row = $(this);

                 var rowid = row.find('input[type="checkbox"]').val();
                 if (document.getElementById('cbMandatory' + rowid).checked == true) {
                     document.getElementById("<%=hiddenSettldDate.ClientID%>").value = row.find('#tdLeaveFrmDate' + rowid).html();
                }
            });


             document.getElementById("<%=btnPrint.ClientID%>").click();
             return false;
         }
         </script>
</asp:Content>

