<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_End_Service_Leave_Settlement.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_End_Service_Leave_Stlmnt_hcm_End_Service_Leave_Stlmnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <style>
        body {
            font-family: Calibri;
        }
    </style>
    <%--	End Of Service Settlement--%>

    <script src="/js/jQuery/jquery-2.2.3.min.js"></script>

    <script src="/js/bootstrap/bootstrap.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <%--<link href="/css/HCM/main.css" rel="stylesheet" />--%>
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />

    <script type="text/javascript">
      
        function LoadEmployeeDetailsByID() {
           
            if (document.getElementById("<%=ddlEmployee.ClientID%>").value != "--SELECT EMPLOYEE--") {
                var intEmployeeID = document.getElementById("<%=ddlEmployee.ClientID%>").value;
                var intCorpID = '<%=Session["CORPOFFICEID"]%>';
                var intOrgID = '<%=Session["ORGID"]%>';
                var objOrg = {};
                objOrg.intEmployeeID = intEmployeeID
                objOrg.intCorpID = intCorpID;
                objOrg.intOrgID = intOrgID;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_End_Service_Leave_Settlement.aspx/LoadEmployeeDetailsByID",
                    data: JSON.stringify(objOrg),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        result = response.d;
                        if (result[0] != "" && result[0] != null) {
                            document.getElementById("txtDateOfLeaving").value = result[4];
                            document.getElementById("txtEmpStatusID").value = result[2];                          
                            switch (result[2]) {
                                case "1":
                                    document.getElementById("txtEmpStatus").value = "Resignation";
                                    break;
                                case "2":
                                    document.getElementById("txtEmpStatus").value = "Termination";
                                    break;
                                case "3":
                                    document.getElementById("txtEmpStatus").value = "Retirement";
                                    break;
                                case "4":
                                    document.getElementById("txtEmpStatus").value = "Abscond";
                                    break;
                                case "5":
                                    document.getElementById("txtEmpStatus").value = "Death";
                                    break;
                                case "6":
                                    document.getElementById("txtEmpStatus").value = "Resume";
                                    break;
                                case "7":
                                    document.getElementById("txtEmpStatus").value = "Under Police custody";
                                    break;
                                case "8":
                                    document.getElementById("txtEmpStatus").value = "Other";
                                    break;
                                default:
                                    document.getElementById("txtEmpStatus").value = "";
                            }

                            document.getElementById("<%=lblRefNo.ClientID%>").innerText = result[3];
                            document.getElementById("cphMain_cbxGrtJoinDate").checked = false;
                            if (result[5] == "1") {
                                document.getElementById("cphMain_divCbxGrt").style.display = "block";
                            }
                            else {
                                document.getElementById("cphMain_divCbxGrt").style.display = "none";
                            }
                        }
                    },
                    failure: function (response) {
                        //alert(response.d);

                    }
                });

            }
            else {
                document.getElementById("txtDateOfLeaving").value = "";
                document.getElementById("txtEmpStatusID").value = "0";
                document.getElementById("<%=lblRefNo.ClientID%>").innerText = "";
                document.getElementById("txtEmpStatus").value = "";
            }

          
                document.getElementById("divSelmntDetails").style.display = "none";
                IncrmntConfrmCounter();
        }
        function CalculateEmployeeData() {
            IncrmntConfrmCounter();
            var intEmployeeID = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            var intCorpID = '<%=Session["CORPOFFICEID"]%>';
            if (intCorpID == '') {

            }
            var intOrgID = '<%=Session["ORGID"]%>';
            if (intOrgID == '') {

            }
            var stringDateofLeaving = document.getElementById("txtDateOfLeaving").value;
            if (intEmployeeID != "--SELECT EMPLOYEE--" && intCorpID != '' && intOrgID != '' && stringDateofLeaving != '') {

                var objOrg2 = {};
                objOrg2.intEmployeeID = intEmployeeID
                objOrg2.intCorpID = intCorpID;
                objOrg2.intOrgID = intOrgID
                objOrg2.stringDateofLeaving = stringDateofLeaving;
                objOrg2.intGrtFromJoinSts = 0;
                objOrg2.DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                if (document.getElementById("cphMain_cbxGrtJoinDate").checked == true) {
                    objOrg2.intGrtFromJoinSts = 1;
                }
                objOrg2.IndividualRound = document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value;
                objOrg2.ZeroWorkFixed = document.getElementById("<%=HiddenFieldWorkdayFixedPayrlMode.ClientID%>").value;
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_End_Service_Leave_Settlement.aspx/LoadEmployeeDetails",
                    data: JSON.stringify(objOrg2),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        result = response.d;
                        if (result != "" && result != null) {

                        
                            if (result.strDecision == "") {
                               
                                document.getElementById("<%=HiddenFieldPrevMntRejoinDate.ClientID%>").value = result.strPrevMnthRejoin;
                                document.getElementById("<%=HiddenFieldPrevArrAmt.ClientID%>").value = result.PrevMnthArrAmt;
                                document.getElementById("lblPrevMnthArrAmt").value = result.PrevMnthArrAmt;

                                if (parseFloat(result.PrevMnthArrAmt) >= 0) {
                                    document.getElementById("<%=lblArrearPrev.ClientID%>").innerHTML = "Arrear Amount Addition";
                                 }
                                 else {
                                     document.getElementById("<%=lblArrearPrev.ClientID%>").innerHTML = "Arrear Amount Deduction";
                                    document.getElementById("lblPrevMnthArrAmt").value = parseFloat(result.PrevMnthArrAmt) * -1;
                                 }


                                document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value = result.strFromDate;
                                document.getElementById("<%=HiddenFieldAddDtls.ClientID%>").value = result.strAddDtls;
                                document.getElementById("<%=HiddenFieldDedDtls.ClientID%>").value = result.strDedDtls;
                                document.getElementById("<%=HiddenFieldChangeSts.ClientID%>").value = "1";
                                
                                //txtOpenLeaveSalary
                                document.getElementById("<%=HiddenFieldLeaveDeductCnt.ClientID%>").value = result.strLeaveDaysDeduct;

                                document.getElementById("txtTotalPay").value = result.deciTotalPay;
                             //   alert(result.deciBasicPay);
                                document.getElementById("txtBasicPay").value = result.deciBasicPay;
                                document.getElementById("txtAddition").value = result.deciAddition;
                                document.getElementById("txtDeduction").value = result.deciDeduction;
                                document.getElementById("txtLastRejoinDate").value = result.strLastRejoinDate;
                                document.getElementById("txtMessAmt").value = result.strMessDedctn;
                                document.getElementById("<%=HiddenMessDedctn.ClientID%>").value = result.strMessDedctn;
                             //   alert(result.deciLeaveSalaryDays);
                                document.getElementById("txtLeaveDays").value = result.deciLeaveSalaryDays;
                               
                                document.getElementById("txtGratuityDays").value = result.intGratuityDays;
                                document.getElementById("txtGratuity").value = result.deciGratuityAmt;
                                document.getElementById("txtLeaveSalary").value = result.deciLeaveSalAmt;
                                document.getElementById("txtCurrentMonthSal").value = result.deciCurrentMonSalary;
                                document.getElementById("txtPrevMonthSal").value = result.deciPrevMonSalary;

                                document.getElementById("txtOverTimeAddition").value = result.deciOverTimeAddition;
                                document.getElementById("txtPaymentDeduction").value = result.deciPaymentDeduction;
                                document.getElementById("<%=hiddenSettlDate.ClientID%>").value = result.strSettlmentDate;

                                document.getElementById("<%=txtNetAmount.ClientID%>").value = result.deciNetAmt;
                                document.getElementById("<%=hiddenNetAmount.ClientID%>").value = result.deciNetAmt;
                                
                                document.getElementById("txtLeaveDaysOpen").value = result.deciOpenLeaveDays;
                            
                                document.getElementById("txtOpenLeaveSalary").value = result.deciOpenLeaveSalary;
                 
                                document.getElementById("txtLvArrearAmt").value = result.deciLvArrearAmnt;
                                
                                document.getElementById("<%=txtOtherAmount.ClientID%>").value = result.deciOtherManualAddAmnt;
                                document.getElementById("<%=txtOtherDeductions.ClientID%>").value = result.deciOtherManualDeductAmnt;

                                document.getElementById("<%=HiddenFieldPrevOtherAddAmt.ClientID%>").value = result.deciPrevOtherManualAddAmnt;
                                document.getElementById("<%=HiddenFieldPrevOtherDeductAmt.ClientID%>").value = result.deciPrevOtherManualDeductAmnt;

                                document.getElementById("<%=HiddenFieldPrevAddition.ClientID%>").value = result.deciPrevAdditionAmt;
                                document.getElementById("<%=HiddenFieldPrevOvertimeAmt.ClientID%>").value = result.deciPrevOvertimeAmt;
                                document.getElementById("<%=HiddenFieldPrevDeduction.ClientID%>").value = result.deciPrevDeductionAmt;
                                document.getElementById("<%=HiddenFieldPrevPaymntDedAmt.ClientID%>").value = result.PrevPaymntDedAmt;

                                document.getElementById("<%=HiddenFieldPrevMessAmt.ClientID%>").value = result.deciPrevMessAmnt;
                                //  alert(result.strOtherAddition); txtPrevMonthSal
                               // alert(result.strOtherDeduction);

                                $("#aIdPrevMonthSal").attr('data-content', result.strPrevSalaryDtls);

                                $("#aIdOtherAddition").attr('data-content', result.strOtherAddition);
                                $("#aIdOtherDeduction").attr('data-content', result.strOtherDeduction);

                                if (result.intTicketAmtSts = "0") {
                                    document.getElementById("<%=txtTicketAmount.ClientID%>").disabled = true;
                                }
                                AmountChecking('txtLvArrearAmt');


                                AmountChecking('txtLeaveDaysOpen');
                                AmountChecking('txtOpenLeaveSalary');

                           //     AmountChecking('txtLeaveDays');

                                AmountChecking('txtGratuityDays');

                                AmountChecking('txtTotalPay');
                                AmountChecking('txtDeduction');
                                AmountChecking('txtBasicPay');
                                AmountChecking('txtAddition');
                                AmountChecking('txtGratuity');
                                AmountChecking('txtLeaveSalary');
                                AmountChecking('txtCurrentMonthSal');
                                AmountChecking('txtPrevMonthSal');
                                AmountChecking('cphMain_txtOtherAmount');
                                AmountChecking('cphMain_txtOtherDeductions');
                                AmountChecking('cphMain_txtTicketAmount');
                                AmountChecking('cphMain_txtNetAmount');
                                AmountChecking('txtOverTimeAddition');
                                AmountChecking('txtPaymentDeduction');
                                AmountChecking('txtMessAmt');
                                AmountChecking('lblPrevMnthArrAmt');

                                
                                document.getElementById("divSelmntDetails").style.display = "";
                            }
                            else if (result.strDecision == "Not resumed") {
                                SuccessMsg("DUP", "Employee is not resumed");
                            }
                            else if (result.strDecision == "Salary process pending") {
                                SuccessMsg("DUP", "Previous month salary processing pending");
                            }
                            else if (result.strDecision == "Paid leave pending") {
                                SuccessMsg("DUP", "Leave settlement pending");
                            }
                            //neww
                            else if (result.strDecision == "MissingAttendance") {
                                SuccessMsg("DUP", "Sorry!Some days attendance missing.");
                            }
                            //neww
                        }
                    },
                    failure: function (response) {                       
                    }
                });
            }
            else {
                SuccessMsg("DUP", "Select an employee");
            }
            return false;
        }


        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            var editID = document.getElementById("<%=hiddenEditID.ClientID%>").value;
            var viewID = document.getElementById("<%=hiddenViewID.ClientID%>").value;
            var editData = document.getElementById("<%=hiddenEditData.ClientID%>").value;
            if (editID != 0) {

            }
            else if (viewID != 0) {

            }

            if (editData != "") {

                document.getElementById("cphMain_cbxGrtJoinDate").checked = false;
                if (document.getElementById("<%=HiddenFieldShowCbx.ClientID%>").value == "1") {
                    document.getElementById("cphMain_divCbxGrt").style.display = "block";
                }
                else {
                    document.getElementById("cphMain_divCbxGrt").style.display = "none";
                }
               
                        
                

                var find2 = '\\"\\[';
                var re2 = new RegExp(find2, 'g');
                var res2 = editData.replace(re2, '\[');

                var find3 = '\\]\\"';
                var re3 = new RegExp(find3, 'g');
                var res3 = res2.replace(re3, '\]');

                var json = $noCon.parseJSON(res3);

                for (var key in json) {
                    if (json.hasOwnProperty(key)) {
                        if (json[key].SRVCLVE_STLMT_ID != "") {
                            // alert(json[key].LANGCODE);

                          
                            document.getElementById("lblPrevMnthArrAmt").value = json[key].SRVCLVE_PREV_MNTH_ARR_AMT;
                            if (parseFloat(json[key].SRVCLVE_PREV_MNTH_ARR_AMT) >= 0) {
                                document.getElementById("<%=lblArrearPrev.ClientID%>").innerHTML = "Arrear Amount Addition";
                             }
                             else {
                                document.getElementById("<%=lblArrearPrev.ClientID%>").innerHTML = "Arrear Amount Deduction";
                                document.getElementById("lblPrevMnthArrAmt").value = parseFloat(json[key].SRVCLVE_PREV_MNTH_ARR_AMT) * -1;
                             }




                            document.getElementById("txtLeaveDaysOpen").value = json[key].SRVCLVE_OPEN_LEAVE_DAYS;
                            //alert(json[key].SRVCLVE_OPEN_LEAVE_SALARY);
                            document.getElementById("txtOpenLeaveSalary").value = json[key].SRVCLVE_OPEN_LEAVE_SALARY;
                          
                            document.getElementById("txtLvArrearAmt").value = json[key].SRVCLVE_LV_ARREAR_AMNT;

                            document.getElementById("divSelmntDetails").style.display = "";
                            var totalPay = json[key].SRVCLVE_STLMT_ADDITION - json[key].SRVCLVE_STLMT_DEDUCTION;
                            //totalPay = totalPay - json[key].SRVCLVE_STLMT_DEDUCTION;

                            document.getElementById("txtTotalPay").value = totalPay;

                            document.getElementById("txtBasicPay").value = json[key].SRVCLVE_STLMT_BASICPAY;
                            document.getElementById("txtAddition").value = json[key].SRVCLVE_STLMT_ADDITION;
                            document.getElementById("txtDeduction").value = json[key].SRVCLVE_STLMT_DEDUCTION;
                            document.getElementById("txtLastRejoinDate").value = json[key].LAST_REJOIN_DATE;

                            document.getElementById("txtLeaveDays").value = json[key].LVE_SAL_ELIGIBLE_DAYS;
                            AmountChecking('txtLeaveDays');
                            document.getElementById("txtGratuityDays").value = json[key].GRATUITY_ELIGIBLE_DAYS;
                            document.getElementById("txtGratuity").value = json[key].GRATUITY_AMOUNT;
                            document.getElementById("txtLeaveSalary").value = json[key].LVE_SAL_AMOUNT;
                            document.getElementById("txtCurrentMonthSal").value = json[key].CUR_MONTH_SAL;
                            
                            document.getElementById("txtPrevMonthSal").value = json[key].PREV_MONTH_SAL;

                            document.getElementById("txtDateOfLeaving").value = json[key].DATE_OF_LEAVING;
                            document.getElementById("txtEmpStatusID").value = json[key].EMPLOYEE_STS;

                            document.getElementById("txtOverTimeAddition").value = json[key].SRVLVE_OT_ADDITION;
                            document.getElementById("txtPaymentDeduction").value = json[key].SRVLVE_PYMT_DEDUCTION;
                            document.getElementById("txtMessAmt").value = document.getElementById("<%=HiddenMessDedctn.ClientID%>").value;
                            if (document.getElementById("<%=HiddenFieldIndividualRound.ClientID%>").value == "1") {
                               // document.getElementById("txtOpenLeaveSalary").value = parseFloat(document.getElementById("txtOpenLeaveSalary").value).toFixed(0);
                              //  document.getElementById("txtOpenLeaveSalary").value = parseFloat(document.getElementById("txtOpenLeaveSalary").value).toFixed(0);
                                document.getElementById("txtLvArrearAmt").value = parseFloat(document.getElementById("txtLvArrearAmt").value).toFixed(0);
                                document.getElementById("txtBasicPay").value = parseFloat(document.getElementById("txtBasicPay").value).toFixed(0);
                                document.getElementById("txtAddition").value = parseFloat(document.getElementById("txtAddition").value).toFixed(0);
                                document.getElementById("txtDeduction").value = parseFloat(document.getElementById("txtDeduction").value).toFixed(0);
                                document.getElementById("txtGratuity").value = parseFloat(document.getElementById("txtGratuity").value).toFixed(0);
                                document.getElementById("txtLeaveSalary").value = parseFloat(document.getElementById("txtLeaveSalary").value).toFixed(0);
                                document.getElementById("txtCurrentMonthSal").value = parseFloat(document.getElementById("txtCurrentMonthSal").value).toFixed(0);
                                document.getElementById("txtPrevMonthSal").value = parseFloat(document.getElementById("txtPrevMonthSal").value).toFixed(0);
                                document.getElementById("txtOverTimeAddition").value = parseFloat(document.getElementById("txtOverTimeAddition").value).toFixed(0);
                                document.getElementById("txtPaymentDeduction").value = parseFloat(document.getElementById("txtPaymentDeduction").value).toFixed(0);
                                document.getElementById("txtMessAmt").value = parseFloat(document.getElementById("txtMessAmt").value).toFixed(0);
                            }
                            if (document.getElementById("<%=HiddenFieldPreviousMonthDetails.ClientID%>").value != "") {
                                $("#aIdPrevMonthSal").attr('data-content', document.getElementById("<%=HiddenFieldPreviousMonthDetails.ClientID%>").value);
                               }
                             else {
                                $("#aIdPrevMonthSal").css("display", "none");
                              }


                            if (document.getElementById("<%=HiddenFieldOtherAddDtls.ClientID%>").value != "") {
                                $("#aIdOtherAddition").attr('data-content', document.getElementById("<%=HiddenFieldOtherAddDtls.ClientID%>").value);
                            }
                            else {
                                $("#aIdOtherAddition").css("display", "none");
                            }
                            if (document.getElementById("<%=HiddenFieldOtherDeductDtls.ClientID%>").value != "") {
                                $("#aIdOtherDeduction").attr('data-content', document.getElementById("<%=HiddenFieldOtherDeductDtls.ClientID%>").value);
                            }
                            else {
                                $("#aIdOtherDeduction").css("display", "none");
                            }


                            if (json[key].SRVCLVE_GRTUTY_JOINDATE_STS == "1") {
                                document.getElementById("cphMain_cbxGrtJoinDate").checked = true;
                            }



                            var EmpSts = json[key].EMPLOYEE_STS;
                            EmpSts = EmpSts.toString();
                            switch (EmpSts) {
                                case "1":
                                    document.getElementById("txtEmpStatus").value = "Resignation";
                                    break;
                                case "2":
                                    document.getElementById("txtEmpStatus").value = "Retirement";
                                    break;
                                case "3":
                                    document.getElementById("txtEmpStatus").value = "Termination";
                                    break;
                                case "4":
                                    document.getElementById("txtEmpStatus").value = "Other";
                                    break;
                                default:
                                    document.getElementById("txtEmpStatus").value = "";
                            }


                          
                           


                            AmountChecking('txtLeaveDaysOpen');
                           AmountChecking('txtOpenLeaveSalary');
                            AmountChecking('txtLvArrearAmt');
                            AmountChecking('txtTotalPay');
                            AmountChecking('txtDeduction');
                            AmountChecking('txtBasicPay');
                            AmountChecking('txtAddition');
                            AmountChecking('txtGratuity');
                            AmountChecking('txtLeaveSalary');
                            AmountChecking('txtCurrentMonthSal');
                            AmountChecking('txtPrevMonthSal');
                            AmountChecking('cphMain_txtOtherAmount');
                            AmountChecking('cphMain_txtOtherDeductions');
                            AmountChecking('cphMain_txtTicketAmount');
                            AmountChecking('cphMain_txtNetAmount');
                            AmountChecking('txtOverTimeAddition');
                            AmountChecking('txtPaymentDeduction');
                            AmountChecking('txtMessAmt');
                            AmountChecking('lblPrevMnthArrAmt');
                            
                        }
                    }
                }

            }

            //messages
            var SuccessMsg = document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value;

            if (SuccessMsg == "SAVE") {
                AddSuccesMessage();
            }
            else if (SuccessMsg == "UPDATE") {
                UpdateSuccesMessage();
            }
            else if (SuccessMsg == "CONFIRM") {
                ConfirmSuccesMessage();
            }
            else if (SuccessMsg == "DELETE") {
                DeleteSuccesMessage();
            }
            document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value = "0";

        });
        //show messages 
        function AddSuccesMessage() {

            // SuccessMsg("SAVE", " End Of Service Settlement details inserted successfully.");
            // document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details inserted successfully.";

            $noCon("#success-alert").html("End Of Service Settlement details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        } function UpdateSuccesMessage() {

            // SuccessMsg("SAVE", "End Of Service Settlement details updated successfully.");
            //  document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details updated successfully.";
            $noCon("#success-alert").html("End Of Service Settlement details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        } function ConfirmSuccesMessage() {

            //SuccessMsg("SAVE", "End Of Service Settlement confirmed successfully.");
            // document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details confirmed successfully.";
            $noCon("#success-alert").html("End Of Service Settlement details confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function DeleteSuccesMessage() {

            //SuccessMsg("SAVE", "End Of Service Settlement cancelled successfully.");
            // document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details cancelled successfully.";
            $noCon("#success-alert").html("End Of Service Settlement details cancelled successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }

        function CancelNotPosible() {

            SuccessMsg("SAVE", "Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            //$noCon("#success-alert").html("End Of Service Settlement details inserted successfully.");
            //$noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            //});
            //$noCon("#success-alert").alert();

            return false;
        }
    </script>
    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {

            confirmbox++;


        }
        function isNumberCustom(evt, textboxid) {
 
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //alert(keyCodes);
            var txtPerVal = document.getElementById(textboxid).value;
            // alert(txtPerVal);
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
                if (textboxid == textboxid) {
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
                    //alert("55");
                    return false;
                }

            }

            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
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
        function calcNetAmnt() {
            IncrmntConfrmCounter();
            var TotalPay = document.getElementById("txtTotalPay").value.trim();
            TotalPay = TotalPay.replace(/,/g, "");
            var Gratuity = document.getElementById("txtGratuity").value.trim();
            Gratuity = Gratuity.replace(/,/g, "");

            var OpenLeaveSal = document.getElementById("txtOpenLeaveSalary").value.trim();
            OpenLeaveSal = OpenLeaveSal.replace(/,/g, "");


            var LvArrearAmnt = document.getElementById("txtLvArrearAmt").value.trim();
            LvArrearAmnt = LvArrearAmnt.replace(/,/g, "");

            var LeaveSalary = document.getElementById("txtLeaveSalary").value.trim();
            LeaveSalary = LeaveSalary.replace(/,/g, "");
            var CurrentMonthSal = document.getElementById("txtCurrentMonthSal").value.trim();
            CurrentMonthSal = CurrentMonthSal.replace(/,/g, "");
            var PrevMonthSal = document.getElementById("txtPrevMonthSal").value.trim();
            PrevMonthSal = PrevMonthSal.replace(/,/g, "");

            //Evm-0023-(28-05-19) Remove Addition,deduction(txtTotalPay) amount from Net amount
          //  var NetAmnt = parseFloat(TotalPay) + parseFloat(Gratuity) + parseFloat(LeaveSalary) + parseFloat(CurrentMonthSal) + parseFloat(PrevMonthSal) + parseFloat(OpenLeaveSal) - parseFloat(LvArrearAmnt);
          //  var NetAmnt = parseFloat(Gratuity) + parseFloat(LeaveSalary) + parseFloat(CurrentMonthSal) + parseFloat(PrevMonthSal) + parseFloat(OpenLeaveSal) - parseFloat(LvArrearAmnt);
            var NetAmnt = parseFloat(Gratuity) + parseFloat(LeaveSalary) + parseFloat(CurrentMonthSal) + parseFloat(PrevMonthSal)  - parseFloat(LvArrearAmnt);

            var TicketAmount = document.getElementById("<%=txtTicketAmount.ClientID%>").value.trim();
            TicketAmount = TicketAmount.replace(/,/g, "");

            var OtherAmount = document.getElementById("<%=txtOtherAmount.ClientID%>").value.trim();
            OtherAmount = OtherAmount.replace(/,/g, "");
          //  alert("Enter1")

            var OtherDeductions = document.getElementById("<%=txtOtherDeductions.ClientID%>").value.trim();
            OtherDeductions = OtherDeductions.replace(/,/g, "");
            //var NetAmnt = document.getElementById("<%=hiddenNetAmount.ClientID%>").value;

            if (TicketAmount == "" || isNaN(TicketAmount)) {
                TicketAmount = 0
            }

            if (OtherAmount == "" || isNaN(OtherAmount)) {
                OtherAmount = 0
            }
            if (OtherDeductions == "" || isNaN(OtherDeductions)) {
                OtherDeductions = 0
            }

           
            
            var Total = parseFloat(NetAmnt) + parseFloat(TicketAmount) + parseFloat(OtherAmount) + parseFloat(document.getElementById("<%=HiddenFieldPrevArrAmt.ClientID%>").value);





            //alert(NetAmnt + TicketAmount + OtherAmount);

            NetAmnt = Total - OtherDeductions;
            
            document.getElementById("<%=txtNetAmount.ClientID%>").value = Math.round(NetAmnt);

            AmountChecking('cphMain_txtNetAmount');
        }
        function ConfirmClearEndSrv() {
            if (confirmbox > 0) {

                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to clear?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "hcm_End_Service_Leave_Settlement.aspx";
                        return false;

                    }
                    else {
                        return false;
                    }
                });
            } else {
                window.location.href = "hcm_End_Service_Leave_Settlement.aspx";
                return false;


            }
            return false;
        }

        function validateSave() {
            calcNetAmnt();
            document.getElementById("<%=hiddenNetAmount.ClientID%>").value = document.getElementById("<%=txtNetAmount.ClientID%>").value.trim();
            // alert(document.getElementById("<%=hiddenNetAmount.ClientID%>").value);

            document.getElementById("<%=txtComments.ClientID%>").value = document.getElementById("<%=txtComments.ClientID%>").value.substring(0, 450);
            RemoveTag('cphMain_txtComments');
            return true;
        }
        function ConfirmCancel() {
            if (confirmbox > 0)
                CancelAlert("hcm_End_Service_Leave_Stlmnt_List.aspx");
            else
                window.location.href = "hcm_End_Service_Leave_Stlmnt_List.aspx";
            return false;
        }




        function openInNewTab() {
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var strId = '<%=Session["EDIT_ID"]%>';


            //  txtLeaveDaysOpen strTotal_leave_salary strMess_amount
            var objOrg = {};
            objOrg.strCorpID = strCorpID;
            objOrg.strOrgIdID = strOrgIdID;
            objOrg.strId = strId;
            objOrg.strRejoin_date = document.getElementById("txtLastRejoinDate").value;
            objOrg.strCurrentMonthBasicPay = document.getElementById("txtBasicPay").value;
            objOrg.strMonthlySalaryTillDate = document.getElementById("txtCurrentMonthSal").value;
            objOrg.strAddition_amount = document.getElementById("txtAddition").value;
            objOrg.strDeduction_amount = document.getElementById("txtDeduction").value;
            objOrg.strMess_amount = document.getElementById("txtMessAmt").value;
            objOrg.strOvertime_amount = document.getElementById("txtOverTimeAddition").value;
            objOrg.strPayment_deduction = document.getElementById("txtPaymentDeduction").value;
            objOrg.strEos_reason = document.getElementById("txtEmpStatus").value;
            objOrg.strPrevMonthSal = document.getElementById("txtPrevMonthSal").value;
            objOrg.strLeaveArrearAmmount = document.getElementById("txtLvArrearAmt").value;
            objOrg.strTotal_eligible_days = document.getElementById("txtLeaveDays").value;
            objOrg.strTotal_gratuity_eligible_days = document.getElementById("txtGratuityDays").value;
            objOrg.strTotal_gratuity_amount = document.getElementById("txtGratuity").value;
            objOrg.strTotal_leave_salary = document.getElementById("txtLeaveSalary").value;
            
            objOrg.strNetAmount = document.getElementById("cphMain_txtNetAmount").value;
            objOrg.strOther_AmountAddition  = document.getElementById("cphMain_txtOtherAmount").value;
            objOrg.strOtherDeductions  = document.getElementById("cphMain_txtOtherDeductions").value;
            objOrg.strTicketAmount = document.getElementById("cphMain_txtTicketAmount").value;

            objOrg.strDecimalCount = document.getElementById("cphMain_hiddenDecimalCount").value;
            objOrg.strDfltCurrencyMstrId = document.getElementById("cphMain_hiddenDfltCurrencyMstrId").value;


            objOrg.strLeaveDaysOpen = document.getElementById("txtLeaveDaysOpen").value;
            objOrg.strLeaveSalaryOpen = document.getElementById("txtOpenLeaveSalary").value;
            objOrg.strPRevArrAmnt = document.getElementById("lblPrevMnthArrAmt").value;
            objOrg.strPRevArrAmntOrg = document.getElementById("<%=HiddenFieldPrevArrAmt.ClientID%>").value;
 

            if (strCorpID != "" && strCorpID != null && strOrgIdID != "" && strOrgIdID != null && strId != "") {
                     $.ajax({
                         type: "POST",
                         async: false,
                         contentType: "application/json; charset=utf-8",
                         url: "hcm_End_Service_Leave_Settlement.aspx/GenerateReport",
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


    </script>

        <script>
            $(document).ready(function () {
                $('[data-toggle="popover"]').popover();
            });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:HiddenField ID="HiddenFieldFromDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldAddDtls" runat="server" />
    <asp:HiddenField ID="HiddenFieldDedDtls" runat="server" />
    <asp:HiddenField ID="HiddenFieldChangeSts" runat="server" />
      <asp:HiddenField ID="HiddenFieldPrevArrAmt" runat="server" value="0"/>
     <asp:HiddenField ID="HiddenFieldPrevMntRejoinDate" runat="server"/>

    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
<asp:HiddenField ID="hiddenCurrencyAbbrv" runat="server" />
    <asp:HiddenField ID="HiddnEnableCacel" runat="server" />
    <script src="/js/HCM/Common.js"></script>

      <asp:HiddenField ID="HiddenFieldShowCbx" runat="server" />

    <asp:HiddenField ID="hiddenEditID" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenViewID" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenEditData" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenNetAmount" runat="server" />
    <asp:HiddenField ID="HiddenSuccessMsgType" runat="server" />

    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
    <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
     <asp:HiddenField ID="hiddenSettlDate" runat="server" />
    <asp:HiddenField ID="HiddenMessDedctn" runat="server" />
    
     <asp:HiddenField ID="HiddenFieldLeaveDeductCnt" runat="server" />
          <asp:HiddenField ID="HiddenFieldPrevOtherAddAmt" runat="server" />
      <asp:HiddenField ID="HiddenFieldPrevOtherDeductAmt" runat="server" />
          <asp:HiddenField ID="HiddenFieldOtherAddDtls" runat="server" />
      <asp:HiddenField ID="HiddenFieldOtherDeductDtls" runat="server" />


     <asp:HiddenField ID="HiddenFieldPrevAddition" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldPrevOvertimeAmt" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldPrevDeduction" runat="server" Value="0"/>
     <asp:HiddenField ID="HiddenFieldPrevPaymntDedAmt" runat="server" Value="0"/>
    <asp:HiddenField ID="HiddenFieldPrevMessAmt" runat="server" Value="0"/>

     <asp:HiddenField ID="HiddenFieldPreviousMonthDetails" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenEndOfStlmntID" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldWorkdayFixedPayrlMode" runat="server" Value="0" />
    

    <div id="main" role="main">

        <div id="ribbon" style="display: none">
            <span id="refresh" class="btn btn-ribbon" data-action="resetWidgets" data-title="refresh" rel="tooltip" data-placement="bottom" data-original-title="<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." data-html="true">
                <i class="fa fa-refresh"></i>
            </span>
        </div>
        <div id="content">
            <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <section id="widget-grid" class="">

                <div class="row">


                    <div id="divList" class="list" onclick="ConfirmCancel();" runat="server" style="position: fixed; right: 0.5%; top: 22%; height: 26.5px; z-index: 1;"></div>         
                         <div id="divprint" visible="false" runat="server" style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 0%; font-family: Calibri;" class="print">
     <a id="print_cap" onclick="return openInNewTab();" target="_blank" data-title="Leave Settlement" href="#" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print</span></a>                               
   </div>
    <asp:Button ID="btnPrint" runat="server" Style="display: none" Text="Print" OnClick="btnPrint_Click" />
    <div id="divPrintPayslip" visible="false" runat="server" style="cursor: default; float: right; height: 25px; margin-right: 1.5%; font-family: Calibri;" class="print">
     <a id="A1" onclick="return openInNewTabPayslip();" target="_blank" data-title="Pay Slip" href="#" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print Pay Slip</span></a>                               
   </div>

                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div id="wid-id-0">

                            <header>

                                <label id="lblHeader" class="pageh2" runat="server">End Of Service Settlement</label>

                            </header>
        
                                                       
                            <%--<button type="button"  style="float: right;" onclick="return PrintElem('divPrintContent')" class="btn btn-primary">Print</button>--%>
                            <div class="smart-form" style="float: left; width: 93.5%;">

                                <div id="TabContainer" runat="server" style="float: left; width: 100%;">
                                </div>


                                <div style="float: left; width: 98%; background: white; margin-top: 2%; padding-left: 1%;">
                                    <div id="divPrintContent" >
                                    <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left; width: 35%;">Employee*</label>
                                                <label class="select" style="float: left; width: 60%;">
                                                    <%--<asp:DropDownList runat="server" ID="ddlEmployee" onchange="LoadEmployeeDetailsByID();"></asp:DropDownList>--%>
                                                   <asp:DropDownList runat="server" ID="ddlEmployee" onkeypress="return DisableEnter(event);" CssClass="form-control" onchange="LoadEmployeeDetailsByID()" ></asp:DropDownList>
                                                </label>
                                            </section>
                                        </div>
                                        <div style="width: 50%; float: left;">
                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left; width: 35%;">Date of Leaving*</label>
                                                <label class="input" style="float: left; width: 60%;">
                                                    <input type="text" id="txtDateOfLeaving" tabindex="-1" onkeypress="return DisableEnter(event)" readonly="true" name="txtDateOfLeaving" style="text-transform: uppercase; margin-right: 4%;" />
                                                </label>
                                            </section>
                                        </div>
                                    </div>
                                    <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left; width: 35%;">REF#</label>
                                                <label class="input" style="float: left; width: 60%;">
                                                    <asp:Label runat="server" ID="lblRefNo" CssClass="lblh2" Style="float: left; width: 100%;"></asp:Label>

                                                </label>


                                            </section>


                                        </div>

                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 7%;">
                                                <label class="lblh2" style="float: left; width: 35%;">Employee Status*</label>


                                                <label class="input" style="float: left; width: 60%;">

                                                    <input type="text" id="txtEmpStatus" name="txtEmpStatus" onkeypress="return DisableEnter(event)" tabindex="-1" readonly="true" style="float: left;" />
                                                    <input type="text" id="txtEmpStatusID" name="txtEmpStatusID" tabindex="-1" readonly="true" style="display: none; float: left;" />




                                                </label>

                                            </section>


                                        </div>
                                    </div>

                                    <div style="width: 100%; float: left;" class="formdiv">
                                        <div style="width: 50%; float: left;">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left; width: 35%;">Comments/Remarks</label>

                                                <label class="input" style="float: left; width: 60%;">
                                                    <asp:TextBox ID="txtComments" class="form-control" onkeypress="return isTag(event);" onkeydown="return textCounter(cphMain_txtComments,450);" onkeyup="return textCounter(cphMain_txtComments,450);" onblur="return textCounter(cphMain_txtComments,450)" runat="server" Style="text-transform: uppercase; resize: none; height: 62px;" TextMode="MultiLine"></asp:TextBox>

                                                </label>

                                            </section>


                                        </div>

                                        <div style="width: 25%; float: left;display:none;" class="smart-form" id="divCbxGrt" runat="server">
                                            <section style="width: 100%; margin-left: 13%;">                                   
                                                <label class="checkbox" style="font-family: Calibri; font-size: 17px; text-align: left; color: #909c7b;">
                                                    <input name="cphMain_cbxGrtJoinDate" id="cbxGrtJoinDate" runat="server" onkeydown="return DisableEnter(event);" type="checkbox" />
                                                    <i></i>Gratuity From Join Date</label>
                                            </section>
                                        </div>

                                        <div style="width: 25%; float: left;" class="container">
                                            <asp:Button ID="btnCalculate" runat="server" Style="height: 31px; margin: 10px 0 0 5px; padding: 0 22px; font: 300 15px/29px 'Calibri',Helvetica,Arial,sans-serif; cursor: pointer; float: left; margin-left: 41%;" class="btn btn-primary" Text="Calculate" OnClientClick="return CalculateEmployeeData();" />


                                        </div>

                                    </div>

                                    <div id="divSelmntDetails" style="display: none; clear: both; width: 100%; border: .5px solid #9ba48b; width: 98%; margin-top: 2%; padding: 1%; float: left; margin-bottom: 2%;">


                                        <label id="Label1" class="pageh2" style="" runat="server">Settlement Details</label>


                                        <div style="clear: both; width: 100%; border: .5px solid #9ba48b; background-color: #f3f3f3; width: 98%; margin-top: 2%; padding: 1%; float: left; margin-bottom: 2%;">
                                            <div style="width: 100%; float: left;" class="formdiv">
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Basic Pay</label>

                                                        <input type="text" id="txtBasicPay" name="txtBasicPay" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                    </section>


                                                </div>

                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Addition</label>
                                                        <div id="div1">
                                                            <input type="text" id="txtAddition" name="txtAddition" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                        </div>
                                                    </section>


                                                </div>
                                            </div>
                                            <div style="width: 100%; float: left;" class="formdiv">
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Deduction</label>

                                                        <input type="text" id="txtDeduction" name="txtDeduction" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                    </section>


                                                </div>

                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Over Time Addition</label>
                                                        <div id="div5">
                                                            <input type="text" id="txtOverTimeAddition" name="txtOverTimeAddition" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                        </div>
                                                    </section>


                                                </div>
                                            </div>
                                            <div style="width: 100%; float: left;" class="formdiv">

                                                 <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Payment Deduction</label>

                                                        <input type="text" id="txtPaymentDeduction" name="txtPaymentDeduction" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                    </section>


                                                </div>
                                                
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Mess Amount</label>
                                                        <div id="div9">
                                                            <input type="text" id="txtMessAmt" name="txtMessAmt" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                        </div>
                                                    </section>


                                                </div>
                                               
                                                
                                               
                                                <div style="width: 50%; float: left;display:none;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Total Pay</label>
                                                        <div id="div4">
                                                            <input type="text" id="txtTotalPay" name="txtTotalPay" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />
                                                        </div>
                                                    </section>


                                                </div>
                                            </div>

                                             <div style="width: 100%; float: left;" class="formdiv">

                                                 <div style="width: 50%; float: left;display:none;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Open Leave Salary</label>

                                                        <input type="text" id="txtOpenLeaveSalary" name="txtOpenLeaveSalary" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                    </section>


                                                </div>
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Leave Arrear Amount</label>
                                                        <div id="div11">
                                                            <input type="text" id="txtLvArrearAmt" name="txtLvArrearAmt" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                        </div>
                                                    </section>


                                                </div>
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;" id="lblArrearPrev" runat="server">Arrear Amount</label>
                                                        <div id="div12">
                                                            <input type="text" id="lblPrevMnthArrAmt" name="lblPrevMnthArrAmt" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" class="lblh2" style="border: #f3f3f3; background: #f3f3f3; float: left; width: 35%;" />

                                                        </div>
                                                    </section>


                                                </div>
                                                                                   
                                               
                                            </div>
                                        </div>

                                        <div style="width: 100%; float: left;" class="formdiv">
                                            <div style="width: 50%; float: left;">

                                                <section style="width: 95%; margin-left: 5%;">
                                                    <label class="lblh2" style="float: left; width: 35%;">Last Resume Date</label>

                                                    <label class="input" style="float: left; width: 60%;">
                                                        <input type="text" id="txtLastRejoinDate" name="txtLastRejoinDate" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; margin-right: 4%;" />
                                                    </label>

                                                </section>


                                            </div>

                                            <div style="width: 50%; float: left;">

                                                <section style="width: 95%; margin-left: 7%;">
                                                    <label class="lblh2" style="float: left; width: 35%;">Total Eligible Days</label>
                                                    <div id="div2">
                                                        <label class="input" style="float: left; width: 60%;">
                                                            <input type="text" id="txtLeaveDays" name="txtLeaveDays" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; text-align: right; margin-right: 4%;" />

                                                        </label>
                                                    </div>
                                                </section>


                                            </div>
                                        </div>
                                        <div style="width: 100%; float: left;" class="formdiv">
                                            <div style="width: 50%; float: left;">

                                                <section style="width: 95%; margin-left: 5%;">
                                                    <label class="lblh2" style="float: left; width: 35%;">Eligible Days For Gratuity</label>

                                                    <label class="input" style="float: left; width: 60%;">
                                                        <input type="text" id="txtGratuityDays" name="txtGratuityDays" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; text-align: right; margin-right: 4%;" />
                                                    </label>

                                                </section>


                                            </div>
                                             <div style="width: 50%; float: left;display:none;">

                                                <section style="width: 95%; margin-left: 7%;">
                                                    <label class="lblh2" style="float: left; width: 35%;">Open Eligible Days For Leave Salary</label>
                                                    <div id="div10">
                                                        <label class="input" style="float: left; width: 60%;">
                                                            <input type="text" id="txtLeaveDaysOpen" name="txtLeaveDaysOpen" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; text-align: right; margin-right: 4%;" />

                                                        </label>
                                                    </div>
                                                </section>


                                            </div>

                                        </div>

                                        <div style="clear: both; width: 100%; border: .5px solid #9ba48b; background-color: #f3f3f3; width: 98%; margin-top: 2%; padding: 1%; float: left; margin-bottom: 2%;">
                                            <div style="width: 100%; float: left;" class="formdiv">
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Gratuity</label>

                                                        <label class="input" style="float: left; width: 60%;">
                                                            <input type="text" id="txtGratuity" name="txtGratuity" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; text-align: right; margin-right: 4%;" />
                                                        </label>

                                                    </section>


                                                </div>

                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Leave Salary</label>
                                                        <div id="div3">
                                                            <label class="input" style="float: left; width: 60%;">
                                                                <input type="text" id="txtLeaveSalary" name="txtLeaveSalary" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; text-align: right; margin-right: 4%;" />

                                                            </label>
                                                        </div>
                                                    </section>


                                                </div>
                                            </div>
                                            <div style="width: 100%; float: left;" class="formdiv">
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Month Salary(Till date)</label>

                                                        <label class="input" style="float: left; width: 60%;">
                                                            <input type="text" id="txtCurrentMonthSal" name="txtCurrentMonthSal" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; text-align: right; margin-right: 4%;" />
                                                        </label>

                                                    </section>


                                                </div>

                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Previous Month Salary</label>
                                                        <div id="div6">
                                                            <label class="input" style="float: left; width: 60%;">
                                                                <input type="text" id="txtPrevMonthSal" name="txtPrevMonthSal" tabindex="-1" onkeypress="return DisableEnter(event);" readonly="true" style="text-transform: uppercase; text-align: right; margin-right: 4%;" />
                                                                <a id="aIdPrevMonthSal" href="#" data-toggle="popover" data-placement="bottom"  data-content="" onclick="return false;">Show Details</a>


                                                            </label>
                                                        </div>
                                                    </section>


                                                </div>
                                            </div>
                                            <div style="width: 100%; float: left;" class="formdiv">
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Other Amount(If any)</label>

                                                        <label class="input" style="float: left; width: 60%;">
                                                            <asp:TextBox ID="txtOtherAmount" onchange="calcNetAmnt();" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event, 'cphMain_txtOtherAmount');" onkeyup="return addCommas('cphMain_txtOtherAmount');" onblur="return AmountChecking('cphMain_txtOtherAmount');" runat="server" MaxLength="12" Style="text-transform: uppercase; text-align: right; margin-right: 4%;" readonly></asp:TextBox>
                                                            <a id="aIdOtherAddition" href="#" data-toggle="popover" data-placement="bottom"  data-content="" onclick="return false;">Show Details</a>

                                                        </label>

                                                    </section>


                                                </div>

                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Ticket Amount</label>
                                                        <div id="div7">
                                                            <label class="input" style="float: left; width: 60%;">
                                                                <asp:TextBox ID="txtTicketAmount" onchange="calcNetAmnt();" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event,'cphMain_txtTicketAmount');" onkeyup="return addCommas('cphMain_txtTicketAmount');" onblur="return AmountChecking('cphMain_txtTicketAmount');" runat="server" MaxLength="12" Style="text-transform: uppercase; text-align: right; margin-right: 4%;" readonly></asp:TextBox>

                                                            </label>
                                                        </div>
                                                    </section>


                                                </div>
                                            </div>
                                            <div style="width: 100%; float: left;" class="formdiv">
                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 5%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Other Deductions(if any)</label>

                                                        <label class="input" style="float: left; width: 60%;">
                                                            <asp:TextBox ID="txtOtherDeductions" onchange="calcNetAmnt();" onkeypress="return isTag(event);" onkeydown="return isNumberAmount(event, 'cphMain_txtOtherDeductions');" onkeyup="return addCommas('cphMain_txtOtherDeductions');" onblur="return AmountChecking('cphMain_txtOtherDeductions');" runat="server" MaxLength="12" Style="text-transform: uppercase; text-align: right; margin-right: 4%;" readonly></asp:TextBox>
                                                            <a id="aIdOtherDeduction" href="#" data-toggle="popover" data-placement="bottom"  data-content="" onclick="return false;">Show Details</a>

                                                        </label>

                                                    </section>


                                                </div>

                                                <div style="width: 50%; float: left;">

                                                    <section style="width: 95%; margin-left: 7%;">
                                                        <label class="lblh2" style="float: left; width: 35%;">Net Amount</label>
                                                        <div id="div8">
                                                            <label class="input" style="float: left; width: 60%;">
                                                                <asp:TextBox ID="txtNetAmount" Enabled="false" onkeypress="return isTag(event);" onblur="return RemoveTag('cphMain_txtNetAmount');" runat="server" MaxLength="20" Style="text-transform: uppercase; text-align: right; margin-right: 4%;"></asp:TextBox>

                                                            </label>
                                                        </div>
                                                    </section>


                                                </div>
                                            </div>
                                        </div>

                                         <footer id="footerEndSrv" style="background: white; float: right; border-top: none">
                                            <asp:Button ID="btnAdd" runat="server" Style="float: left;" class="btn btn-primary" Text="Save" OnClick="btnAddClose_Click" OnClientClick="return validateSave();" />
                                            <asp:Button ID="btnAddClose" runat="server" Style="float: left;" class="btn btn-primary" Text="Save & Close" OnClick="btnAddClose_Click" OnClientClick="return validateSave();" />
                                            <asp:Button ID="btnUpdate" runat="server" Visible="false" Style="float: left;" class="btn btn-primary" Text="Update" OnClick="btnAddClose_Click" OnClientClick="return validateSave();" />
                                            <asp:Button ID="btnUpdateClose" runat="server" Visible="false" Style="float: left;" class="btn btn-primary" Text="Update & Close" OnClick="btnAddClose_Click" OnClientClick="return validateSave();" />
                                            <asp:Button ID="btnConfirm" runat="server" Visible="false" Style="float: left;" class="btn btn-primary" Text="Confirm" OnClientClick="return confirmAlertEndSrv();" />
                                            <asp:Button ID="btnCon" runat="server" Style="display: none; float: left;" class="btn btn-primary" Text="Confirm" OnClick="btnAddClose_Click" />
                                            <%--OnClick="btnAddClose_Click"--%>
                                            <script>
                                                function confirmAlertEndSrv() {
                                                    if (validateSave()) {
                                                        ezBSAlert({
                                                            type: "confirm",
                                                            messageText: "Are you sure you want to confirm?",
                                                            alertType: "info"
                                                        }).done(function (e) {
                                                            if (e == true) {
                                                                document.getElementById('<%= btnCon.ClientID %>').click();

                                                                return false;

                                                            }
                                                            else {
                                                                return false;
                                                            }
                                                        });
                                                        return false;
                                                    }


                                                }
                                            </script>
                                            <asp:Button ID="btnClear" runat="server" Style="float: left;" class="btn btn-primary" Text="Clear" OnClientClick="return ConfirmClearEndSrv();" OnClick="btnClear_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Style="float: left;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancel();" />

                                        </footer>
                                        </div>
                                        </div>
                                       
                                    




                                </div>

                            </div>
                        </div>

                    </article>
                </div>
            </section>
        </div>
    </div>
       <div id="divPrintCaption" runat="server" style="display:none; height: 150px">

        </div>

                    <div id="divPrintReport" runat="server" style="display:none;"></div>


    
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
        function openInNewTabPayslip() {

             document.getElementById("<%=btnPrint.ClientID%>").click();
                     return false;
                 }
    </script>
  
</asp:Content>

