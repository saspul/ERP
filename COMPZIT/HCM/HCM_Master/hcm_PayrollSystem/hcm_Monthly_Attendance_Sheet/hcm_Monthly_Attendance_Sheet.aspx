<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Monthly_Attendance_Sheet.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Attendance_Sheet_hcm_Monthly_Attendance_Sheet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
     <script src="/js/jQuery/jquery-2.2.3.min.js"></script>
    <script src="../../../../js/HCM/Common.js"></script> 
     <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />


    <script>
        var old;
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
    
            var rb = document.getElementById("<%=rbtnCropDept.ClientID%>");
            var radio = rb.getElementsByTagName("input");
            var label = rb.getElementsByTagName("label");

            old = radio[0].value;



            localStorage.clear();

            document.getElementById("txtefctvedate").value = document.getElementById('<%=hiddenCurrentDate.ClientID %>').value;
            var holidaySts = document.getElementById('<%=HiddenFieldHldySts.ClientID %>').value;
            var LoadSts = document.getElementById('<%=HiddenFieldLoadSts.ClientID %>').value;
            if (LoadSts == "0") {
                if (holidaySts == "1") {
                    var radio = $noCon("[id*=rbtnCropDept] label:contains(HOLIDAY OT)").closest("td").find("input");
                    radio.prop("checked", true);
                    document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Hol";
                }
                else {
                    var radio = $noCon("[id*=rbtnCropDept] label:contains(NORMAL OT)").closest("td").find("input");
                    radio.prop("checked", true);
                    document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Nor";

                }
            }


        });
        $noCon(document).ready(function () {


            var rb = document.getElementById("<%=rbtnCropDept.ClientID%>");
            var radio = rb.getElementsByTagName("input");
            var label = rb.getElementsByTagName("label");
            for (var i = 0; i < radio.length; i++) {
                if (radio[i].checked) {

                    old = radio[i].value;
                    break;
                }
            }
            $noCon("[id*=rbtnCropDept]").find("input").click(function () {





                var newR = "Hol";
                var radio = $noCon("[id*=rbtnCropDept] label:contains(NORMAL OT)").closest("td").find("input");
                if (radio.is(":checked")) {
                    newR = "Nor";
                }


                var chkvalue;
                var rb = document.getElementById("<%=rbtnCropDept.ClientID%>");
                var radio = rb.getElementsByTagName("input");
                var label = rb.getElementsByTagName("label");
                for (var i = 0; i < radio.length; i++) {
                    if (radio[i].checked) {

                        newR = radio[i].value;
                        chkvalue = radio[i].value;
                        break;
                    }
                }

                var categoryCount = document.getElementById('<%=HiddenCategoryCount.ClientID %>').value;

                if (categoryCount > 1) {
                    if (old != newR) {
                        ezBSAlert({
                            type: "confirm",
                            messageText: "Are you sure you want to change the OT Category?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                old = newR;
                                if (old == "Hol") {
                                    document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Nor";
                              }
                              else {
                                  document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Hol";
                              }
                              return false;
                          }
                          else {

                              if (old == "Hol") {
                                  var radio = $noCon("[id*=rbtnCropDept] label:contains(HOLIDAY OT)").closest("td").find("input");
                                  radio.prop("checked", true);
                                  document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Hol";
                              }
                              else {
                                  var radio = $noCon("[id*=rbtnCropDept] label:contains(NORMAL OT)").closest("td").find("input");
                                  radio.prop("checked", true);
                                  document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Nor";

                               }
                               return false;
                           }

                        });

                   }
               }
            })
        });



    </script>
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
           var confirmbox = 0;

           function IncrmntConfrmCounter() {

               confirmbox++;
           }
           function ConfirmCancelUpld() {
               if (confirmbox > 0) {
                   if (confirm("Are you sure you want to cancel this page?")) {
                       window.location.href = "hcm_Monthly_Attendance_Sheet_List.aspx";

                   }
                   else {

                   }
               }
               else {
                   window.location.href = "hcm_Monthly_Attendance_Sheet_List.aspx";

               }
               return false;
           }
           function ConfirmCancelUpldList() {


               if (confirmbox > 0) {
                   if (confirm("Are you sure you want to leave this page?")) {
                       window.location.href = "hcm_Monthly_Attendance_Sheet_List.aspx";

                   }
                   else {

                   }
               }
               else {
                   window.location.href = "hcm_Monthly_Attendance_Sheet_List.aspx";

               }
               return false;
           }
    </script>
    
 <link type="text/css" href="CSS/ui.all.css" rel="stylesheet" />    
 <script type="text/javascript" src="Scripts/ui.core.js"></script>    
 <script type="text/javascript" src="Scripts/ui.progressbar.js"></script>  

  
    <script>
        function FupSelectedFileName() {
            IncrmntConfrmCounter();
            document.getElementById('<%=Label1.ClientID%>').innerHTML = document.getElementById('<%=FileUploader.ClientID %>').value;
        }

    </script>
   
    <style>
          .custom-file-upload {
            margin-left: 34%;
    border: 1px solid #ccc;
    display: inline-block;
    padding: 3px 8px;
    cursor: pointer;
    position:relative;
    z-index:2;
    font-family:Calibri;
    background:white;
    height:78%;
    width:12.8%;
    
}
        .custom-file-upload:hover {
            box-shadow: -2px 5px 3px rgba(0, 59, 29, 0.2);
        }
        .fillform {
            width: 78%;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }

        .searchlist_btn_rght {
            cursor:pointer;
        }
         input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;            
        }
       
        .model {
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
    </style>
    <script type="text/javascript">

        var $noCon = jQuery.noConflict();

        function confirmUpdate() {


            if (document.getElementById("<%=HiddenFieldDupIdsDb.ClientID%>").value == "") {

                if (confirm("Are you sure you want to add the following monthly attendance sheet to the table")) {
                }
                else {
                    return false;
                }
            }
            else {

                if (confirm("One or more employees have the duplicated records already.Do you wish to overwrite them?")) {
                    document.getElementById("<%=HiddenFieldOverWriteSts.ClientID%>").value = "1";
                }
                else {
                    document.getElementById("<%=HiddenFieldOverWriteSts.ClientID%>").value = "0";
                }

            }
        }
        function ShowError() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some Error Occured. Please Review The Details In Uploaded File !";
        }

        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Monthly attendance sheet updated as per the document";

        }


        function ErrorMessage() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Uploaded CSV File Is Not Correct Format, Please Choose The Correct Format CSV File";
        }

        function ShowLoading() {
            document.getElementById('divLoading').style.display = "block";
            document.getElementById('lblFileUpload').style.display = "none";

        }
        function HideLoading() {
            document.getElementById('divLoading').style.display = "none";
            document.getElementById('lblFileUpload').style.display = "";
        }


        function ConfirmMessage() {

            document.getElementById("<%=HiddenFieldCancelIDs.ClientID%>").value = "";
        }
        function FileValidate() {

            document.getElementById("txtefctvedate").style.borderColor = "";
            document.getElementById("divDpartmnt").style.border = "";
            document.getElementById("divDpartmnt").style.borderColor = "";


            document.getElementById("<%=HiddenFieldCancelIDs.ClientID%>").value = "";



            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var fileUploader = document.getElementById("<%=FileUploader.ClientID%>").value;
            var Extension = fileUploader.substring(fileUploader.lastIndexOf('.') + 1).toLowerCase();
            document.getElementById('divErrorTotal').style.visibility = "hidden";
            document.getElementById("<%=FileUploader.ClientID%>").style.borderColor = "";

            if (fileUploader == "") {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Please Choose CSV File";
                document.getElementById("<%=FileUploader.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=FileUploader.ClientID%>").focus();
                ret = false;
            }
            else {

                if (Extension == "csv") {
                    ret = true;
                }
                else {
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "The specified file could not be uploaded. File type not supported. Allowed type is csv";
                    document.getElementById("<%=FileUploader.ClientID%>").focus();
                    ret = false;
                }
            }



            if (ret == true) {
                var isAnyCheckBoxChecked = false;
                var checkBoxes = document.getElementById("<%= rbtnCropDept.ClientID %>").getElementsByTagName("input");

                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].type == "radio") {
                        if (checkBoxes[i].checked) {
                            isAnyCheckBoxChecked = true;
                            break;
                        }
                    }
                }



                if (!isAnyCheckBoxChecked) {
                    // alert("No CheckBox is Checked.");
                    document.getElementById("divDpartmnt").style.border = "1px solid";
                    document.getElementById("divDpartmnt").style.borderColor = "Red";
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Please select an O.T category";
                    ret = false;
                }

            }
            if (ret == true) {


                var RcptdatepickerDate = document.getElementById("txtefctvedate").value;

                if (RcptdatepickerDate == "") {
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Please enter a date";
                    document.getElementById("txtefctvedate").focus();
                    document.getElementById("txtefctvedate").style.borderColor = "red";
                    ret = false;
                }
                else {
                    document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value = RcptdatepickerDate;

                }

            }



            if (ret == false) {
                CheckSubmitZero();

            }
            if (ret == true) {
                document.getElementById('<%=HiddenFieldLoadSts.ClientID %>').value = 1;
                ShowLoading();
            }
            return ret;
        }


        function VisibleNote() {
            var $noCon = jQuery.noConflict();
            if ($noCon('#divNote:visible').length == 0) {
                document.getElementById('divNote').style.display = "";
                document.getElementById('headingNote').style.fontWeight = "";
            }
            else {
                document.getElementById('divNote').style.display = "none";
                document.getElementById('headingNote').style.fontWeight = "bold";
            }
            return false;
        }

        function ViewMissingProductCodeDup() {
            HideLoading();

            document.getElementById('divRateUpdate').style.display = "none";
            if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {
                document.getElementById('divRateMissing').style.display = "";
                document.getElementById('h2CostPriceError').style.display = "none";
                document.getElementById('h2CostPriceNoError').style.display = "";
                document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "";
                document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";

            }
            else {
                document.getElementById('divRateMissing').style.display = "";
            }

            return false;

        }


        function ViewMissingProductCode() {
            HideLoading();

            document.getElementById('divRateUpdate').style.display = "none";

            var ErrorCount = document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value;
            var IncorrectEmpCodeCount = document.getElementById("<%=HiddenIncorrectEmpCodeCount.ClientID%>").value;
            var IncorrectOTCount = document.getElementById("<%=HiddenIncorrectOTCount.ClientID%>").value;
            var IncorrectRemarksCount = document.getElementById("<%=HiddenIncorrectRemarksCount.ClientID%>").value;
            var AlreadyConfirmedCount = document.getElementById("<%=HiddenAlreadyConfirmedCount.ClientID%>").value;
            var IncorrectProjectCodeCount = document.getElementById("<%=HiddenIncorrectProjectCodeCount.ClientID%>").value;

            var IncorrectDaysCount = document.getElementById("<%=HiddenIncorrectDayCount.ClientID%>").value;
            var IncorrectOTCategCount = document.getElementById("<%=HiddenIncorrectOTCatgCount.ClientID%>").value;

            var dDate = document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;
            var TotalErrorEmp = document.getElementById("<%=HiddenTotalErrorEmp.ClientID%>").value;





            document.getElementById('btnViewIncorrectRemarks').innerHTML = "Incorrect Remarks <span style=\"color: #a94442;\">(" + IncorrectRemarksCount + ")</span>";
            document.getElementById('btnViewIncorrectOT').innerHTML = "Incorrect OT <span style=\"color: #a94442;\">(" + IncorrectOTCount + ")</span>";
            document.getElementById('btnViewIncorrectEmpCode').innerHTML = "Incorrect Employee Code <span style=\"color: #a94442;\">(" + IncorrectEmpCodeCount + ")</span>";
            document.getElementById('btnViewIncorrectAttendance').innerHTML = "Incorrect Attendance <span style=\"color: #a94442;\">(" + ErrorCount + ")</span>";
            document.getElementById('btnViewAlreadyConfirmed').innerHTML = "Already Confirmed / Processed <span style=\"color: #a94442;\">(" + AlreadyConfirmedCount + ")</span>";
            document.getElementById('btnViewIncorrectProjectCode').innerHTML = "Incorrect Project Code <span style=\"color: #a94442;\">(" + IncorrectProjectCodeCount + ")</span>";
            document.getElementById('lblDateError').innerHTML = document.getElementById('<%=HiddenFieldMonthAndYear.ClientID %>').value;
         //   document.getElementById('lblDateError').innerHTML = "Date : " + dDate;
            document.getElementById('lblNofEmpError').innerHTML = "Total number of employees : " + TotalErrorEmp;

            document.getElementById('btnViewIncorrectDays').innerHTML = "Incorrect Days <span style=\"color: #a94442;\">(" + IncorrectDaysCount + ")</span>";
            document.getElementById('btnViewIncorrectOTCateg').innerHTML = "Incorrect OT Category <span style=\"color: #a94442;\">(" + IncorrectOTCategCount + ")</span>";


            //hide if no error
            if (AlreadyConfirmedCount == '0')
                document.getElementById('btnViewAlreadyConfirmed').style.display = "none";

            if (IncorrectRemarksCount == '0')
                document.getElementById('btnViewIncorrectRemarks').style.display = "none";

            if (IncorrectOTCount == '0')
                document.getElementById('btnViewIncorrectOT').style.display = "none";

            if (IncorrectEmpCodeCount == '0')
                document.getElementById('btnViewIncorrectEmpCode').style.display = "none";

            if (ErrorCount == '0')
                document.getElementById('btnViewIncorrectAttendance').style.display = "none";


            if (IncorrectProjectCodeCount == '0')
                document.getElementById('btnViewIncorrectProjectCode').style.display = "none";


            if (IncorrectDaysCount == '0')
                document.getElementById('btnViewIncorrectDays').style.display = "none";

            if (IncorrectOTCategCount == '0')
                document.getElementById('btnViewIncorrectOTCateg').style.display = "none";



            if (ErrorCount == '0' && IncorrectEmpCodeCount == '0' && IncorrectOTCount == '0' && IncorrectRemarksCount == '0' && AlreadyConfirmedCount == '0' && IncorrectProjectCodeCount == '0' && IncorrectDaysCount == '0' && IncorrectOTCategCount == '0') {

                var dDate = document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;
                var TotalCurrectEmp = document.getElementById("<%=HiddenTotalCurrectEmp.ClientID%>").value;
                document.getElementById('lblDateCurrect').innerHTML = document.getElementById('<%=HiddenFieldMonthAndYear.ClientID %>').value;
              //  document.getElementById('lblDateCurrect').innerHTML = "Date : " + dDate;

                document.getElementById('lblNofEmpCurrect').innerHTML = "Total number of employees : " + TotalCurrectEmp;

                if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {
                    document.getElementById('divRateMissing').style.display = "";
                    document.getElementById('h2CostPriceError').style.display = "none";
                    document.getElementById('h2CostPriceNoError').style.display = "";
                    document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "";
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";

                }
                else {   

                    document.getElementById('divRateMissing').style.display = "";
                }

                if (document.getElementById("<%=HiddenFieldDupListCount.ClientID%>").value == '0') {
                    document.getElementById("MyModalDuplicate").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";
                }
                else {
                    document.getElementById("MyModalDuplicate").style.display = "block";
                    document.getElementById("freezelayer").style.display = "";
                }

            }
            else {

                document.getElementById('divMissingCode').style.display = "";

                if (ErrorCount != '0')
                    document.getElementById('btnViewIncorrectAttendance').click();
                else if (IncorrectEmpCodeCount != '0')
                    document.getElementById('btnViewIncorrectEmpCode').click();
                else if (IncorrectOTCount != '0')
                    document.getElementById('btnViewIncorrectOT').click();
                else if (IncorrectRemarksCount != '0')
                    document.getElementById('btnViewIncorrectRemarks').click();
                else if (AlreadyConfirmedCount != '0')
                    document.getElementById('btnViewAlreadyConfirmed').click();
                else if (IncorrectProjectCodeCount != '0')
                    document.getElementById('btnViewIncorrectProjectCode').click();
                else if (IncorrectDaysCount != '0')
                    document.getElementById('btnViewIncorrectDays').click();
                else if (IncorrectOTCategCount != '0')
                    document.getElementById('btnViewIncorrectOTCateg').click();
            }



            return false;
        }

        function ClosModalView() {

            var tbClientPermitFileUpload = localStorage.getItem("tbClientJobSheduling");//Retrieve the stored data
            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];

            document.getElementById("<%=HiddenFieldCorrectListJson.ClientID%>").value = "";

            var EditAttchmnt = document.getElementById("<%=HiddenRateAmendmentList.ClientID%>").value;
            var findAtt2 = '\\"\\[';
            var reAtt2 = new RegExp(findAtt2, 'g');
            var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

            var findAtt3 = '\\]\\"';
            var reAtt3 = new RegExp(findAtt3, 'g');
            var resAtt3 = resAtt2.replace(reAtt3, '\]');

            var jsonAtt = $noCon.parseJSON(resAtt3);
            for (var key in jsonAtt) {

                var EmpCodeList = jsonAtt[key].EMPCODE;
                var EmployeeList = jsonAtt[key].EMPLOYEE;
                var DesgList = jsonAtt[key].DESG;
                var JobList = jsonAtt[key].PROJECT_CODE;
                var AttList = jsonAtt[key].ATTENDANCE;
                var OTList = jsonAtt[key].OT;
                var RemarkList = jsonAtt[key].REMARKS;
                var IdleHrList = jsonAtt[key].IDLEHOUR;
                var FinalOtList = jsonAtt[key].FINALOT;
                var RoundedOtList = jsonAtt[key].ROUNDEDOT;

                var DayList = jsonAtt[key].DAY;
                var OTCatgList = jsonAtt[key].OT_CATEGORY;

                //Start:-Serialize    


                var $add = jQuery.noConflict();
                var client = JSON.stringify({

                    EMPCODE: "" + EmpCodeList + "",
                    EMPLOYEE: "" + EmployeeList + "",
                    DESG: "" + DesgList + "",
                    PROJECT_CODE: "" + JobList + "",
                    ATTENDANCE: "" + AttList + "",
                    OT: "" + OTList + "",
                    REMARKS: "" + RemarkList + "",
                    IDLEHOUR: "" + IdleHrList + "",
                    FINALOT: "" + FinalOtList + "",
                    ROUNDEDOT: "" + RoundedOtList + "",
                    DAY: "" + DayList + "",
                    OT_CATEGORY: "" + OTCatgList + ""

                });
                tbClientPermitFileUpload.push(client);

                //End:-Serialize
            }

            localStorage.setItem("tbClientJobSheduling", JSON.stringify(tbClientPermitFileUpload));
            $add("#cphMain_HiddenFieldCorrectListJson").val(JSON.stringify(tbClientPermitFileUpload));

            if (confirm("Are you sure you want to cancel this page?")) {
                document.getElementById("MyModalDuplicate").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
            }
            else {

            }
            return false;
        }

        function DeleteRow(number) {



            if (confirm("Are you sure you want to remove the row from monthly attendance sheet?")) {



                var row = document.getElementById("row" + number);
                row.parentNode.removeChild(row);


                var CanclIds = document.getElementById("<%=HiddenFieldCancelIDs.ClientID%>").value;

                if (CanclIds == '') {
                    document.getElementById("<%=HiddenFieldCancelIDs.ClientID%>").value = number;

                }
                else {

                    document.getElementById("<%=HiddenFieldCancelIDs.ClientID%>").value = document.getElementById("<%=HiddenFieldCancelIDs.ClientID%>").value + ',' + number;
                }


                if (($noCon('#ReportTable tbody').find('tr').length) == 0) {
                    document.getElementById("<%=btnRateMissingUpdate.ClientID%>").style.display = "none";

                }
                return false;
            }
            else {
                return false;
            }

        }



        //pagenation functions
        function MissingCodeRecord(Mode) {




            var NextId = document.getElementById("<%=HiddenCodeMissingNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenCodeMissingList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';

            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, function (response) {
                var MissingCodeList = response;
                document.getElementById('cphMain_divMissingCodeReport').innerHTML = MissingCodeList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnMissingCodePrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMissingCodePrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMissingCodePrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenCodeMissingNext.ClientID%>").value = MissingCodeList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCodeMissingNext.ClientID%>").value)) {
                        document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenCodeMissingNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnMissingCodePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnMissingCodePrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnMissingCodePrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }





        //pagenation functions Employee code
        function IncorrectEmployeeCodeRecord(Mode) {


            var NextId = document.getElementById("<%=HiddenIncorrectEmpCodeNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenIncorrectEmpCodeList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenIncorrectEmpCodeCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';

            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, function (response) {
                var IncorrectEmpCodeList = response;
                document.getElementById('cphMain_divIncorrectEmpCode').innerHTML = IncorrectEmpCodeList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnIncorrectEmpCodePrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectEmpCodePrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectEmpCodePrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnIncorrectEmpCodeNext.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectEmpCodeNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectEmpCodeNext.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenIncorrectEmpCodeNext.ClientID%>").value = IncorrectEmpCodeList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenIncorrectEmpCodeCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenIncorrectEmpCodeNext.ClientID%>").value)) {
                        document.getElementById("<%=btnIncorrectEmpCodeNext.ClientID%>").disabled = true;
                        document.getElementById("<%=btnIncorrectEmpCodeNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectEmpCodeNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenIncorrectEmpCodeNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnIncorrectEmpCodePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnIncorrectEmpCodePrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectEmpCodePrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }


        //pagenation functions OT
        function IncorrectOTRecord(Mode) {


            var NextId = document.getElementById("<%=HiddenIncorrectOTNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenIncorrectOTList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenIncorrectOTCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';

            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, function (response) {
                var IncorrectOTList = response;
                document.getElementById('cphMain_divIncorrrectOT').innerHTML = IncorrectOTList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnIncorrectOTPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectOTPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectOTPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnIncorrectOTNext.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectOTNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectOTNext.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenIncorrectOTNext.ClientID%>").value = IncorrectOTList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenIncorrectOTCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenIncorrectOTNext.ClientID%>").value)) {
                        document.getElementById("<%=btnIncorrectOTNext.ClientID%>").disabled = true;
                        document.getElementById("<%=btnIncorrectOTNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectOTNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenIncorrectOTNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnIncorrectOTPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnIncorrectOTPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectOTPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }


        function IncorrectDaysRecord(Mode) {


            var NextId = document.getElementById("<%=HiddenIncorrectDaysNext.ClientID%>").value;
                var MissingCode = document.getElementById("<%=HiddenIncorrectDayList.ClientID%>").value;
                var TotalCount = document.getElementById("<%=HiddenIncorrectDayCount.ClientID%>").value
                if (Mode == '1')
                    var Mode = '1';
                else
                    var Mode = '0';

                var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, function (response) {
                    var IncorrectDaysList = response;
                    document.getElementById('cphMain_divIncorrectDays').innerHTML = IncorrectDaysList[0];

                    if (Mode == '1') {
                        document.getElementById("<%=btnIncorrectDaysPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectDaysPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectDaysPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnIncorrectDaysNext.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectDaysNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectDaysNext.ClientID%>").style.cursor = 'pointer';
                }

                    document.getElementById("<%=HiddenIncorrectDaysNext.ClientID%>").value = IncorrectDaysList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenIncorrectDayCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenIncorrectDaysNext.ClientID%>").value)) {
                        document.getElementById("<%=btnIncorrectDaysNext.ClientID%>").disabled = true;
                        document.getElementById("<%=btnIncorrectDaysNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectDaysNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenIncorrectDaysNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnIncorrectDaysPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnIncorrectDaysPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectDaysPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }


        //OT Categ
        function IncorrectOTCategoryRecord(Mode) {
            var NextId = document.getElementById("<%=HiddenIncorrectOTCatgNext.ClientID%>").value;
             var MissingCode = document.getElementById("<%=HiddenIncorrectOTCatgList.ClientID%>").value;
             var TotalCount = document.getElementById("<%=HiddenIncorrectOTCatgCount.ClientID%>").value
             if (Mode == '1')
                 var Mode = '1';
             else
                 var Mode = '0';

             var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, function (response) {
                 var IncorrectOTCategList = response;
                 document.getElementById('cphMain_divIncorrectOTCatg').innerHTML = IncorrectOTCategList[0];

                 if (Mode == '1') {
                     document.getElementById("<%=btnIncorrectOTCatgPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectOTCatgPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectOTCatgPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnIncorrectOTCatgNext.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectOTCatgNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectOTCatgNext.ClientID%>").style.cursor = 'pointer';
                }

                 document.getElementById("<%=HiddenIncorrectOTCatgNext.ClientID%>").value = IncorrectOTCategList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenIncorrectOTCatgCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenIncorrectOTCatgNext.ClientID%>").value)) {
                        document.getElementById("<%=btnIncorrectOTCatgNext.ClientID%>").disabled = true;
                        document.getElementById("<%=btnIncorrectOTCatgNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectOTCatgNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenIncorrectOTCatgNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnIncorrectOTCatgPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnIncorrectOTCatgPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectOTCatgPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }



        //pagenation functions Remarks
        function IncorrectRemarksRecord(Mode) {


            var NextId = document.getElementById("<%=HiddenIncorrectRemarksNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenIncorrectRemarksList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenIncorrectRemarksCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';

            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, function (response) {
                var IncorrectRemarksList = response;
                document.getElementById('cphMain_divIncorrectRemarks').innerHTML = IncorrectRemarksList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnIncorrectRemarksPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectRemarksPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectRemarksPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnIncorrectRemarksNext.ClientID%>").disabled = false;
                    document.getElementById("<%=btnIncorrectRemarksNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnIncorrectRemarksNext.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenIncorrectRemarksNext.ClientID%>").value = IncorrectRemarksList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenIncorrectRemarksCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenIncorrectRemarksNext.ClientID%>").value)) {
                        document.getElementById("<%=btnIncorrectRemarksNext.ClientID%>").disabled = true;
                        document.getElementById("<%=btnIncorrectRemarksNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectRemarksNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenIncorrectRemarksNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnIncorrectRemarksPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnIncorrectRemarksPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnIncorrectRemarksPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }



        //pagenation functions Remarks
        function AlreadyConfirmedRecord(Mode) {


            var NextId = document.getElementById("<%=HiddenAlreadyConfirmedNext.ClientID%>").value;
            var MissingCode = document.getElementById("<%=HiddenAlreadyConfirmedList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenAlreadyConfirmedCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';

            var Create = PageMethods.ServiceListToHtmlIncrct(MissingCode, NextId, Mode, TotalCount, function (response) {
                var AlreadyConfirmedList = response;
                document.getElementById('cphMain_divAlreadyConfirmed').innerHTML = AlreadyConfirmedList[0];

                if (Mode == '1') {
                    document.getElementById("<%=btnAlreadyConfirmedPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnAlreadyConfirmedPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnAlreadyConfirmedPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnAlreadyConfirmedNext.ClientID%>").disabled = false;
                    document.getElementById("<%=btnAlreadyConfirmedNext.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnAlreadyConfirmedNext.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenAlreadyConfirmedNext.ClientID%>").value = AlreadyConfirmedList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenAlreadyConfirmedCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenAlreadyConfirmedNext.ClientID%>").value)) {
                        document.getElementById("<%=btnAlreadyConfirmedNext.ClientID%>").disabled = true;
                        document.getElementById("<%=btnAlreadyConfirmedNext.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnAlreadyConfirmedNext.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenAlreadyConfirmedNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnAlreadyConfirmedPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnAlreadyConfirmedPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnAlreadyConfirmedPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }




        function RateMissingRecord(Mode) {

            var CmnIdleHr = document.getElementById("cphMain_txtIdleHrCmn").value;

            var NextId = document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value;
            var RateMissing = document.getElementById("<%=HiddenFieldCorrectListJson.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtml(RateMissing, NextId, Mode, TotalCount, CmnIdleHr, function (response) {
                var RateMissingList = response;
                document.getElementById('cphMain_divCostPriceMissingReport').innerHTML = RateMissingList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value = RateMissingList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value)) {
                        document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }




        function BlurIdleHr(x) {



            var RoundedOT = document.getElementById("txtIdleHr" + x).value.trim();

            if (RoundedOT.match(/^\d+(\.\d+)?$/) && RoundedOT <= 24) {
                var pieces = RoundedOT.split(".");
                if (pieces.length > 1) {
                    if (pieces[1].length > 2)
                        document.getElementById("txtIdleHr" + x).value = parseFloat(RoundedOT).toFixed(2);
                }
            }
            else {
                document.getElementById("txtIdleHr" + x).value = "0";
            }

            var IdleHr = document.getElementById("txtIdleHr" + x).value.trim();
            var OT = document.getElementById("txtOT" + x).value.trim();
            if (OT != "") {


                IdleHr = parseFloat(IdleHr);
                OT = parseFloat(OT);

                if (IdleHr >= OT) {
                    document.getElementById("txtFinalOT" + x).value = "0";
                    document.getElementById("txtRndedOT" + x).value = "0";
                }
                else {

                    var Reslt = OT - IdleHr;
                    var pieces = Reslt.toString().split(".");
                    if (pieces.length > 1 && pieces[1].length > 2) {
                        document.getElementById("txtFinalOT" + x).value = Reslt.toFixed(2);
                        document.getElementById("txtRndedOT" + x).value = Reslt.toFixed(2);
                    }
                    else {
                        document.getElementById("txtFinalOT" + x).value = Reslt;
                        document.getElementById("txtRndedOT" + x).value = Reslt;
                    }
                }

            }




            //Start:-New code

            var tbClientPermitFileUpload = localStorage.getItem("tbClientJobSheduling");//Retrieve the stored data
            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];



            var EmpCodeLoop = document.getElementById("txtEmpCode" + x).value;
            var JobLoop = document.getElementById("txtJob" + x).value;
            var AttLoop = document.getElementById("txtAtt" + x).value;
            var OTLoop = document.getElementById("txtOT" + x).value;
            var RemarkLoop = document.getElementById("txtRemark" + x).value;
            var EmployeeLoop = document.getElementById("txtEmployee" + x).value;
            var DesgLoop = document.getElementById("txtDesignation" + x).value;
            var IdleHourLoop = document.getElementById("txtIdleHr" + x).value;
            var FinalOTLoop = document.getElementById("txtFinalOT" + x).value;
            var RoundedOTLoop = document.getElementById("txtRndedOT" + x).value;


            var $FileE = jQuery.noConflict();
            tbClientPermitFileUpload[x - 1] = JSON.stringify({
                EMPCODE: "" + EmpCodeLoop + "",
                EMPLOYEE: "" + EmployeeLoop + "",
                DESG: "" + DesgLoop + "",
                PROJECT_CODE: "" + JobLoop + "",
                ATTENDANCE: "" + AttLoop + "",
                OT: "" + OTLoop + "",
                REMARKS: "" + RemarkLoop + "",
                IDLEHOUR: "" + IdleHourLoop + "",
                FINALOT: "" + FinalOTLoop + "",
                ROUNDEDOT: "" + RoundedOTLoop + ""
            });

            localStorage.setItem("tbClientJobSheduling", JSON.stringify(tbClientPermitFileUpload));
            $FileE("#cphMain_HiddenFieldCorrectListJson").val(JSON.stringify(tbClientPermitFileUpload));
            // alert(document.getElementById("<%=HiddenFieldCorrectListJson.ClientID%>").value);
            //End:-New code

        }
        function BlurIdleHrCmn() {


            var RoundedOT = document.getElementById("cphMain_txtIdleHrCmn").value.trim();
            if (RoundedOT.match(/^\d+(\.\d+)?$/) && RoundedOT <= 24) {
                var pieces = RoundedOT.split(".");
                if (pieces[1].length > 2)

                    document.getElementById("cphMain_txtIdleHrCmn").value = parseFloat(RoundedOT).toFixed(2);
            }
            else {
                document.getElementById("cphMain_txtIdleHrCmn").value = "0";
            }





        }

        function BlurRoundedOT(x) {


            var RoundedOT = document.getElementById("txtRndedOT" + x).value.trim();
            if (RoundedOT.match(/^\d+(\.\d+)?$/) && RoundedOT <= 24) {
                var pieces = RoundedOT.split(".");
                if (pieces.length > 1) {
                    if (pieces[1].length > 2)
                        document.getElementById("txtRndedOT" + x).value = parseFloat(RoundedOT).toFixed(2);
                }
            }
            else {
                document.getElementById("txtRndedOT" + x).value = "0";
            }


            //Start:-New code

            var tbClientPermitFileUpload = localStorage.getItem("tbClientJobSheduling");//Retrieve the stored data
            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];



            var EmpCodeLoop = document.getElementById("txtEmpCode" + x).value;
            var JobLoop = document.getElementById("txtJob" + x).value;
            var AttLoop = document.getElementById("txtAtt" + x).value;
            var OTLoop = document.getElementById("txtOT" + x).value;
            var RemarkLoop = document.getElementById("txtRemark" + x).value;
            var EmployeeLoop = document.getElementById("txtEmployee" + x).value;
            var DesgLoop = document.getElementById("txtDesignation" + x).value;
            var IdleHourLoop = document.getElementById("txtIdleHr" + x).value;
            var FinalOTLoop = document.getElementById("txtFinalOT" + x).value;
            var RoundedOTLoop = document.getElementById("txtRndedOT" + x).value;


            var $FileE = jQuery.noConflict();
            tbClientPermitFileUpload[x - 1] = JSON.stringify({
                EMPCODE: "" + EmpCodeLoop + "",
                EMPLOYEE: "" + EmployeeLoop + "",
                DESG: "" + DesgLoop + "",
                PROJECT_CODE: "" + JobLoop + "",
                ATTENDANCE: "" + AttLoop + "",
                OT: "" + OTLoop + "",
                REMARKS: "" + RemarkLoop + "",
                IDLEHOUR: "" + IdleHourLoop + "",
                FINALOT: "" + FinalOTLoop + "",
                ROUNDEDOT: "" + RoundedOTLoop + ""
            });

            localStorage.setItem("tbClientJobSheduling", JSON.stringify(tbClientPermitFileUpload));
            $FileE("#cphMain_HiddenFieldCorrectListJson").val(JSON.stringify(tbClientPermitFileUpload));
            //alert(document.getElementById("<%=HiddenFieldCorrectListJson.ClientID%>").value);
            //End:-New code

        }

        function BlurRemark(x) {


            //Start:-New code

            var tbClientPermitFileUpload = localStorage.getItem("tbClientJobSheduling");//Retrieve the stored data
            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];



            var EmpCodeLoop = document.getElementById("txtEmpCode" + x).value;
            var JobLoop = document.getElementById("txtJob" + x).value;
            var AttLoop = document.getElementById("txtAtt" + x).value;
            var OTLoop = document.getElementById("txtOT" + x).value;
            var RemarkLoop = document.getElementById("txtRemark" + x).value;
            var EmployeeLoop = document.getElementById("txtEmployee" + x).value;
            var DesgLoop = document.getElementById("txtDesignation" + x).value;
            var IdleHourLoop = document.getElementById("txtIdleHr" + x).value;
            var FinalOTLoop = document.getElementById("txtFinalOT" + x).value;
            var RoundedOTLoop = document.getElementById("txtRndedOT" + x).value;


            var $FileE = jQuery.noConflict();
            tbClientPermitFileUpload[x - 1] = JSON.stringify({
                EMPCODE: "" + EmpCodeLoop + "",
                EMPLOYEE: "" + EmployeeLoop + "",
                DESG: "" + DesgLoop + "",
                PROJECT_CODE: "" + JobLoop + "",
                ATTENDANCE: "" + AttLoop + "",
                OT: "" + OTLoop + "",
                REMARKS: "" + RemarkLoop + "",
                IDLEHOUR: "" + IdleHourLoop + "",
                FINALOT: "" + FinalOTLoop + "",
                ROUNDEDOT: "" + RoundedOTLoop + ""
            });

            localStorage.setItem("tbClientJobSheduling", JSON.stringify(tbClientPermitFileUpload));
            $FileE("#cphMain_HiddenFieldCorrectListJson").val(JSON.stringify(tbClientPermitFileUpload));
            //alert(document.getElementById("<%=HiddenFieldCorrectListJson.ClientID%>").value);
            //End:-New code
        }


        function changeCbx(x) {

            var rowcount = document.getElementById("<%=HiddenFieldDupListCount.ClientID%>").value;
            var EmpCode = document.getElementById("tdEmpCode" + x).innerHTML;

            for (var i = 1; i <= rowcount; i++) {
                if (x != i) {

                    var EmpCodeLoop = document.getElementById("tdEmpCode" + i).innerHTML;

                    if (EmpCodeLoop == EmpCode) {

                        if (document.getElementById("cbx" + x).checked == true) {
                            document.getElementById("cbx" + i).disabled = true;
                        }
                        else {
                            document.getElementById("cbx" + i).disabled = false;
                        }
                    }
                }
            }


        }


        function OverWriteDup() {

            var tbClientPermitFileUpload = localStorage.getItem("tbClientJobSheduling");//Retrieve the stored data
            tbClientPermitFileUpload = JSON.parse(tbClientPermitFileUpload); //Converts string to object

            if (tbClientPermitFileUpload == null) //If there is no data, initialize an empty array
                tbClientPermitFileUpload = [];


            document.getElementById("<%=HiddenFieldCorrectListJson.ClientID%>").value = "";


            var rowcount = document.getElementById("<%=HiddenFieldDupListCount.ClientID%>").value;
             var flag = 0;
             for (var i = 1; i <= rowcount; i++) {
                 if (document.getElementById("cbx" + i).checked == true) {
                     flag = 1;
                 }
             }
             if (flag == 1) {
                 if (confirm("Are you sure you want to over-write the selected records??")) {

                     var count = document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value;



                    var EditAttchmnt = document.getElementById("<%=HiddenRateAmendmentList.ClientID%>").value;
                    var findAtt2 = '\\"\\[';
                    var reAtt2 = new RegExp(findAtt2, 'g');
                    var resAtt2 = EditAttchmnt.replace(reAtt2, '\[');

                    var findAtt3 = '\\]\\"';
                    var reAtt3 = new RegExp(findAtt3, 'g');
                    var resAtt3 = resAtt2.replace(reAtt3, '\]');

                    var jsonAtt = $noCon.parseJSON(resAtt3);

                    for (var key in jsonAtt) {

                        var EmpCodeList = jsonAtt[key].EMPCODE;
                        var EmployeeList = jsonAtt[key].EMPLOYEE;
                        var DesgList = jsonAtt[key].DESG;
                        var JobList = jsonAtt[key].PROJECT_CODE;
                        var AttList = jsonAtt[key].ATTENDANCE;
                        var OTList = jsonAtt[key].OT;

                        var RemarkList = jsonAtt[key].REMARKS;
                        var IdleHrList = jsonAtt[key].IDLEHOUR;
                        var FinalOtList = jsonAtt[key].FINALOT;
                        var RoundedOtList = jsonAtt[key].ROUNDEDOT;
                        var DayList = jsonAtt[key].DAY;
                        var OTCatgList = jsonAtt[key].OT_CATEGORY;




                        for (var i = 1; i <= rowcount; i++) {


                            if (document.getElementById("cbx" + i).checked == true) {

                                var EmpCodeLoop = document.getElementById("tdEmpCode" + i).innerHTML;
                                var JobLoop = document.getElementById("tdJob" + i).innerHTML;

                                var AttLoop = document.getElementById("tdAtt" + i).innerHTML;
                                var OTLoop = document.getElementById("tdOT" + i).innerHTML;
                                var RemarkLoop = document.getElementById("tdRemark" + i).innerHTML;
                                var EmployeeLoop = document.getElementById("tdEmployee" + i).innerHTML;
                                var DesgLoop = document.getElementById("tdDesignation" + i).innerHTML;
                                var Day = document.getElementById("tdDay" + i).innerHTML;
                                var OTCatg = document.getElementById("tdOTCatg" + i).innerHTML;





                                if (EmpCodeList == EmpCodeLoop && DayList == Day) {

                                    var FinalOt = "";
                                    var IdleHr = parseFloat(document.getElementById("cphMain_txtIdleHrCmn").value);
                                    if (OTLoop == "") {
                                        OTLoop = "0";
                                    }

                                    OTLoop = parseFloat(OTLoop);
                                    if (IdleHr >= OTLoop) {

                                        FinalOt = "0";
                                    }
                                    else {

                                        var Reslt = OTLoop - IdleHr;
                                        var pieces = Reslt.toString().split(".");
                                        if (pieces.length > 1 && pieces[1].length > 2) {
                                            FinalOt = Reslt.toFixed(2);

                                        }
                                        else {
                                            FinalOt = Reslt;
                                        }
                                    }




                                    JobList = JobLoop;
                                    AttList = AttLoop;
                                    OTList = OTLoop;

                                    RemarkList = RemarkLoop;
                                    EmployeeList = EmployeeLoop;
                                    DesgList = DesgLoop;
                                    IdleHrList = IdleHr;
                                    FinalOtList = FinalOt;
                                    RoundedOtList = FinalOt;
                                    DayList = Day;
                                    OTCatgList = OTCatg;


                                }//Json if
                            }//Dup


                        }

                        //Start:-Serialize    


                        var $add = jQuery.noConflict();
                        var client = JSON.stringify({

                            EMPCODE: "" + EmpCodeList + "",
                            EMPLOYEE: "" + EmployeeList + "",
                            DESG: "" + DesgList + "",
                            PROJECT_CODE: "" + JobList + "",
                            ATTENDANCE: "" + AttList + "",
                            OT: "" + OTList + "",
                            REMARKS: "" + RemarkList + "",
                            IDLEHOUR: "" + IdleHrList + "",
                            FINALOT: "" + FinalOtList + "",
                            ROUNDEDOT: "" + RoundedOtList + "",
                            DAY: "" + DayList + "",
                            OT_CATEGORY: "" + OTCatgList + "",

                        });
                        tbClientPermitFileUpload.push(client);




                        //End:-Serialize
                    }//For loop


                    document.getElementById("MyModalDuplicate").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";

                    localStorage.setItem("tbClientJobSheduling", JSON.stringify(tbClientPermitFileUpload));

                    $add("#cphMain_HiddenFieldCorrectListJson").val(JSON.stringify(tbClientPermitFileUpload));
                    var CmnIdleHr = document.getElementById("cphMain_txtIdleHrCmn").value;
                    document.getElementById('cphMain_divCostPriceMissingReport').innerHTML = "";




                    var RateMissing = document.getElementById("<%=HiddenFieldCorrectListJson.ClientID%>").value;
                    var Create = PageMethods.CorrectListLoad(RateMissing, CmnIdleHr, function (response) {
                        document.getElementById('cphMain_divCostPriceMissingReport').innerHTML = response;
                    });
                }
            }
            else {
                alert("No records were selected");
            }





            return false;
        }



        function ViewDuplication() {
            document.getElementById('divMissingCode').style.display = "none";

            if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {

                document.getElementById('divRateMissing').style.display = "";
                document.getElementById('h2CostPriceError').style.display = "none";
                document.getElementById('h2CostPriceNoError').style.display = "";
                document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "";
                document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";

            }
            else {
                document.getElementById('divRateMissing').style.display = "";
            }

            if (document.getElementById("<%=HiddenFieldDupListCount.ClientID%>").value == '0') {
                document.getElementById("MyModalDuplicate").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
            }
            else {
                document.getElementById("MyModalDuplicate").style.display = "block";
                document.getElementById("freezelayer").style.display = "";
            }

            var dDate = document.getElementById("<%=Hiddentxtefctvedate.ClientID%>").value;
            var TotalCurrectEmp = document.getElementById("<%=HiddenTotalCurrectEmp.ClientID%>").value;
            document.getElementById('lblDateCurrect').innerHTML=document.getElementById('<%=HiddenFieldMonthAndYear.ClientID %>').value;
            //document.getElementById('lblDateCurrect').innerHTML = "Date : " + dDate;
            document.getElementById('lblNofEmpCurrect').innerHTML = "Total number of employees : " + TotalCurrectEmp;


            return false;

        }

        function BackFromCodeMissing() {
            document.getElementById('divMissingCode').style.display = "none";
            document.getElementById('divRateUpdate').style.display = "";
            return false;
        }
    </script>
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     <div class="cont_rght" style="padding: 20px 0 0;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <div id="divAlert" style="visibility: hidden">
            
        </div>
   <%--      evm-0027--%>

           <asp:HiddenField ID="HiddenCategoryCount" runat="server" />
      <%--   end--%>
        <asp:HiddenField ID="HiddenCount" runat="server" />
         <asp:HiddenField ID="HiddenNewCurrentMisMatchCount" runat="server" />
        <asp:HiddenField ID="HiddenFile" runat="server" />
        <asp:HiddenField ID="HiddenOrgId" runat="server" />
        <asp:HiddenField ID="HiddenCorpId" runat="server" />
        <asp:HiddenField ID="HiddenUserId" runat="server" />
        <asp:HiddenField ID="HiddenItemCreateList" runat="server" />
        <asp:HiddenField ID="HiddenRateAmendmentList" runat="server" />


          <asp:HiddenField ID="HiddenFieldCorrectListJson" runat="server" />


           <asp:HiddenField ID="HiddenFieldOldVal" runat="server" value="0"/>

          <asp:HiddenField ID="HiddenFieldLoadSts" runat="server" value="0"/>

          <asp:HiddenField ID="HiddenFieldHldySts" runat="server" />

        <asp:HiddenField ID="HiddenCodeMissingCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodemissingPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeMissingNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeMissingList" runat="server" value="0"/>
      
        <asp:HiddenField ID="hiddenCurrentDate" runat="server" />

          <asp:HiddenField ID="HiddenFieldCancelIDs" runat="server" />

           <asp:HiddenField ID="HiddenFieldDupIdsDb" runat="server" />


          <asp:HiddenField ID="HiddenFieldOverWriteSts" runat="server" />


          <asp:HiddenField ID="HiddenFieldDupListCount" runat="server" value="0" />
         
        <asp:HiddenField ID="HiddenCostPriceMissingCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCostPriceMissingPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCostPriceMissingNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCostPriceMissingList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenRateUpdateCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenRateUpdatePrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenRateUpdateNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenRateUpdateList" runat="server" value="0"/>
         <asp:HiddenField ID="HiddenCorrectListCopy" runat="server" value="0"/>

  <asp:HiddenField ID="HiddenIncorrectEmpCodeNext" runat="server" value="0"/>
  <asp:HiddenField ID="HiddenIncorrectEmpCodeCount" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenIncorrectEmpCodeList" runat="server" value="0"/>

  <asp:HiddenField ID="HiddenIncorrectProjectCodeNext" runat="server" value="0"/>
  <asp:HiddenField ID="HiddenIncorrectProjectCodeCount" runat="server" value="0"/>
  <asp:HiddenField ID="HiddenIncorrectProjectCodeList" runat="server" value="0"/>




  <asp:HiddenField ID="HiddenIncorrectOTCount" runat="server" value="0"/>
  <asp:HiddenField ID="HiddenIncorrectOTList" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenIncorrectOTNext" runat="server" value="0"/>

  <asp:HiddenField ID="HiddenIncorrectRemarksCount" runat="server" value="0"/>
  <asp:HiddenField ID="HiddenIncorrectRemarksList" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenIncorrectRemarksNext" runat="server" value="0"/>

           <asp:HiddenField ID="HiddenAlreadyConfirmedCount" runat="server" value="0"/>
  <asp:HiddenField ID="HiddenAlreadyConfirmedList" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenAlreadyConfirmedNext" runat="server" value="0"/>
 <asp:HiddenField ID="hiddenCorpGlobalFutureDays" runat="server" value="0"/>

 <asp:HiddenField ID="HiddenTotalCurrectEmp" runat="server" value="0"/>
 <asp:HiddenField ID="HiddenTotalErrorEmp" runat="server" value="0"/>

         <asp:HiddenField ID="HiddenIncorrectDayCount" runat="server" value="0"/>
         <asp:HiddenField ID="HiddenIncorrectDayList" runat="server" value="0"/>
          <asp:HiddenField ID="HiddenIncorrectDaysNext" runat="server" value="0"/>


         <asp:HiddenField ID="HiddenIncorrectOTCatgCount" runat="server" value="0"/>
         <asp:HiddenField ID="HiddenIncorrectOTCatgList" runat="server" value="0"/>
         <asp:HiddenField ID="HiddenIncorrectOTCatgNext" runat="server" value="0"/>

         <asp:HiddenField ID="HiddenFieldMonthAndYear" runat="server" value="0"/>


         <div id="divLoading" class="model" style="display:none;"  >
            <div class="eachform" style="width:12%; height:55%; padding-left:42%; padding-top:10%;">
                 <img src="/../Images/Other Images/LoadingMail.gif" style="width:75%" />
                 </div>
    </div>
        <br />
        <div id="divRateUpdate" class="fillform" style="background-color: #f4f6f0; width:100%;">

            <div id="divList" class="list"  onclick="return ConfirmCancelUpldList();"  runat="server" style="position:fixed; right:4%; top:26%;height:26.5px;"> </div>

         
       
        <div id="divReportCaption" style="margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <a id="a_Caption" style="margin-left:1%;color: rgb(83, 101, 51);" >Monthly Attendance Sheet</a>
        </div>
            <br />
            <br />
             
              <div class="eachform" style="width:96%; margin-left: 1%;float:left;">  
                    <h2 style="font-family:Calibri;">Month & Year*</h2>             
                        <select class="form1" id="ddlMonth" runat="server" style="margin-left: 24%;float: left;width:20%;height:33px;margin-bottom: 1%;" >
                        </select> 
                        <select class="form1" id="ddlYear" runat="server" style="margin-left: 0.5%;float: left;width:10%;height:33px;margin-bottom: 1%;">
                   </select> 
                 </div>


               <div class="eachform" style="float:left;width:50%;margin-left:1%; display:none;">
                <h2 style="font-family:Calibri;">Date*</h2>
                
               <div id="divDate"  style="float:right;width: 33%;">
                  
                      <input id="txtefctvedate" name="txtefctvedate" type="text" class="Tabletxt form-control datepicker"  data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" onchange="show()" style="width:77%;margin-left:-5%;" onkeypress="return DisableEnter(event);" onkeydown="return DisableEnter(event);" />
                                                    <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" value="0"/>
                                                                        <script>
                                                                            var FutureDate = document.getElementById('<%=hiddenCorpGlobalFutureDays.ClientID %>').value;
                                                                            var $noCon4 = jQuery.noConflict();
                                                                            $noCon4('#txtefctvedate').datepicker({
                                                                                autoclose: true,
                                                                                format: 'dd-mm-yyyy',
                                                                                endDate: FutureDate

                                                                            });

                                                                            function show() {

                                                                                IncrmntConfrmCounter();
                                                                                $noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtefctvedate').val());

                                                                                var date = $noCon4('#txtefctvedate').val().trim();

                                                                                var orgID = '<%= Session["ORGID"] %>';
                                                                                var corptID = '<%= Session["CORPOFFICEID"] %>';
                                                                                if (date != "") {
                                                                                    var Details = PageMethods.CheckHoliday(date, orgID, corptID, function (response) {






                                                                                        if (response == "true") {


                                                                                            var radio = $noCon4("[id*=rbtnCropDept] label:contains(HOLIDAY OT)").closest("td").find("input");

                                                                                            radio.prop("checked", true);
                                                                                            document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Hol";

                                                                                        }
                                                                                        else {


                                                                                            var radio = $noCon4("[id*=rbtnCropDept] label:contains(NORMAL OT)").closest("td").find("input");

                                                                                            radio.prop("checked", true);
                                                                                            document.getElementById('<%=HiddenFieldOldVal.ClientID %>').value = "Nor";

                                                                                        }

                                                                                    });
                                                                                }

                                                                            }
                                                                            </script> 
                     
                       </div>
              

            </div>

              <div class="eachform" id="DeptDiv" style="float: left; width: 80%;margin-left:1%;display:none;">
                                <h2 style="font-family:Calibri;" >OT Category*</h2>
                                <div id="divDpartmnt">
                                     <asp:RadioButtonList ID="rbtnCropDept" runat="server" CellPadding="10" class="form2" ></asp:RadioButtonList>
                                </div>
                                  <div id="divCompzitModuleNoList" runat="server" style=" font-family: Calibri;">
                                    <asp:Label ID="Label2" runat="server" Text="No OT Category Available." style="margin-left:31%; color: red;"></asp:Label>
                                  </div>
                            </div>



             <div class="eachform" style="width:33%; margin-left: 1%;float:right;display:none;">  
                    <h2 style="font-family:Calibri;">Day*</h2>             
                <div  style="width:89%;">
                    <asp:CheckBox ID="cbxHolidaySts" Text="" runat="server" Checked="false" class="form2" onkeypress="return DisableEnter(event)" />
                    <h2 >Holiday</h2>
                  </div>
                </div>

              <div class="eachform" style="width:96%; margin-left: 1%;float:left;">  
                    <h2 style="font-family:Calibri;">Idle Hour*</h2>             
              
                <asp:TextBox ID="txtIdleHrCmn" runat="server" class="form1" MaxLength="5" Style="margin-left: 27.5%;float: left;width:13.5%;height:33px;" Text="0"  onkeydown="return isNumberDec(event)" onkeypress="return isNumberDec(event)" onchange="IncrmntConfrmCounter();" onblur="return BlurIdleHrCmn();"></asp:TextBox>
                </div>
                
            <div id="divFileUploader" class="eachform" style="height: 40px;margin-top:0.5%;">
                <h2 style="padding-top: 0.4%; padding-left:1%;font-family:Calibri;">Export File*</h2>
                

               <label id="lblFileUpload" for="cphMain_FileUploader" class="custom-file-upload"  style="margin-left:25.6%;color:black" ><img src="/../Images/Icons/cloud_upload.jpg"/>Upload File </label>
               <asp:FileUpload ID="FileUploader" class="imageUpload" onchange="FupSelectedFileName()" runat="server" Accept=".csv"  
                   style="display:none;padding-left:24.5%;"/>

               
               <asp:Label ID="Label1" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
             
                <a href="/CustomFiles/csvTemplate/Monthly attendance with header.csv">  <img src="../../../../Images/Icons/CSV.PNG" title="Sample CSV File" style="margin-left: 1%;" /></a>

                 </div>


                  <%--#1--%>


           <div style="width:70%;margin:auto;float:left">
               <div class="eachform" style="margin-left: 48%;margin-bottom: 2%;">
                    <asp:CheckBox ID="cbxImprtHasHeader" Text="" runat="server" Checked="false" class="form2" Style="margin-top: -0.4%;"  onkeypress=" return DisableEnter(event);" />
                    <label style="font-family: Calibri; color: #7b826e; cursor: pointer;" for="cphMain_cbxImprtHasHeader">My data has Headers</label>
                </div>

               <div class="eachform" style="width:96%; margin-left: 14.5%;float:left;">  
                    <h2 style="font-family:Calibri;"></h2>             
              
                 <asp:CheckBox ID="cbxConsolidate" Text=""    runat="server" Checked="false" class="form2" Style="margin-left: 34.7%;float: left;" onkeypress=" return DisableEnter(event);" />
                    <label style="font-family: Calibri; color: #7b826e; cursor: pointer;" for="cphMain_cbxConsolidate">Consolidate Errors</label>

               </div>

        </div>




            <%--#1--%>

            <br />


            <div class="eachform">
                <div class="subform" style="margin-left: 34.5%;">                   
                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Process" OnClick="btnAdd_Click"  OnClientClick="return FileValidate();" />
                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancelUpld();"  />
                </div>
            </div>



            <div id="prntTable" class="table-responsive" runat="server" style="display:none">
                 </div>
             <div id="prntCrrntNewMisMatchTable" class="table-responsive" runat="server" style="display:none">
            </div>


            <div id="div2" class="eachform" "  >
                  <h2 id="headingNote" style="color: rgb(83, 101, 51); padding-left:1%; cursor:pointer; font-weight: bold;font-family:Calibri;" onclick="VisibleNote()" >Condition+</h2>                  
                  </div>
               <div id="divNote" class="eachform" style="padding-left:1%; color: red; font-family:Calibri; display:none">
                 <asp:Label ID="lblNote" runat="server" Text="Note: Required CSV File Must Contain Day, Employee Code, Project Code And Attendance Fields."></asp:Label> 
                   </div>

        </div>


       

         


    <div id="divMissingCode" class="fillform" style="background-color:  rgb(213, 219, 201); display:none; width:100%">        
              <div id="div1" style="margin-left:1%;margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <a id="a1" style="margin-left:0%;color: rgb(83, 101, 51);">Incorrect List</a>
        </div>
              <div class="eachform">
                <div class="subform" style="float:right; width:45%"> 
                    <asp:Button ID="btnCodeMissingNext" runat="server" class="btn btn-primary" Text="Next>>" style="float:right; margin-right: 9%;" OnClientClick="return ViewDuplication();"/>                  
                    <asp:Button ID="btnCodeMissingCancel" runat="server" class="btn btn-primary" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />
                    <asp:Button ID="btnCodeMissingBack" runat="server" class="btn btn-primary" Text="<<Back" style="float:right; margin-right: 3%;" OnClientClick="return BackFromCodeMissing();" />                                                                                                                                          
                </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Following records in uploaded file contain either missing fields or mismatched fields.These records will be excluded while importing.</h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Next" button to continue.</h2>
                 </div>
       



        <div id="divTabs">
  
<div class="tab">
  <button class="tablinks"  id="btnViewIncorrectAttendance" onclick="return OpenIncorrectList(event, 'divIncorrectAttendanceTab')">Attendance</button>
  <button class="tablinks"  id="btnViewIncorrectEmpCode" onclick="return OpenIncorrectList(event, 'divIncorrectEmpCodeTab')">Employee Code</button>
  <button class="tablinks" id="btnViewIncorrectOT" onclick="return OpenIncorrectList(event, 'divIncorrectOTTab')">OT</button>
  <button class="tablinks" id="btnViewIncorrectRemarks" onclick="return OpenIncorrectList(event, 'divIncorrectRemarksTab')">Remarks</button> 
    <button class="tablinks" id="btnViewAlreadyConfirmed" onclick="return OpenIncorrectList(event, 'divAlreadyConfirmedTab')">Already Confirmed / Processed</button>
    <button class="tablinks" id="btnViewIncorrectProjectCode" onclick="return OpenIncorrectList(event, 'divIncorrectProjectCodeTab')">Project Code</button>
    <button class="tablinks" id="btnViewIncorrectDays" onclick="return OpenIncorrectList(event, 'divIncorrectDaysTab')">Days</button>
    <button class="tablinks" id="btnViewIncorrectOTCateg" onclick="return OpenIncorrectList(event, 'divIncorrectOTCatgTab')">OT Category</button>
</div>

   <div>
       <br />
    <label id="lblDateError" class="" style="width:25%;float:left;padding-left: 1.3%;font-size: 17px;"></label>
    <label id="lblNofEmpError" class="" style="width:30%;float:left;font-size: 17px;"></label>
  </div>
<br/>


<div id="divIncorrectAttendanceTab" class="tabcontent">
  <h3>Incorrect Attendance</h3>
    <div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnMissingCodePrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return MissingCodeRecord(0);" />
             <asp:Button ID="btnMissingCodeNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return MissingCodeRecord(1);"/>
                 </div>
              <div id="divMissingCodeReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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

<div id="divIncorrectEmpCodeTab" class="tabcontent">
  <h3>Incorrect Employee Code</h3>
  <div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnIncorrectEmpCodePrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return IncorrectEmployeeCodeRecord(0);" />
             <asp:Button ID="btnIncorrectEmpCodeNext" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return IncorrectEmployeeCodeRecord(1);"/>
                 </div>
              <div id="divIncorrectEmpCode" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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

<div id="divIncorrectProjectCodeTab" class="tabcontent">
  <h3>Incorrect Project Code</h3>
  <div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnIncorrectProjectCodePrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return IncorrectProjectCodeRecord(0);" />
             <asp:Button ID="btnIncorrectProjectCodeNext" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return IncorrectProjectCodeRecord(1);"/>

                 </div>
              <div id="divIncorrectProjectCode" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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





<div id="divIncorrectOTTab" class="tabcontent">
  <h3>Incorrect OT</h3>
  <div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnIncorrectOTPrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return IncorrectOTRecord(0);" />
             <asp:Button ID="btnIncorrectOTNext" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return IncorrectOTRecord(1);"/>
                 </div>
              <div id="divIncorrrectOT" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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
    <div id="divIncorrectRemarksTab" class="tabcontent">
  <h3>Incorrect Remarks</h3>
<div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnIncorrectRemarksPrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return IncorrectRemarksRecord(0);" />
             <asp:Button ID="btnIncorrectRemarksNext" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return IncorrectRemarksRecord(1);"/>
                 </div>
              <div id="divIncorrectRemarks" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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



 <div id="divAlreadyConfirmedTab" class="tabcontent">
  <h3>Already Confirmed / Processed</h3>
<div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnAlreadyConfirmedPrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return AlreadyConfirmedRecord(0);" />
             <asp:Button ID="btnAlreadyConfirmedNext" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return AlreadyConfirmedRecord(1);"/>
                 </div>
              <div id="divAlreadyConfirmed" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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

            <div id="divIncorrectDaysTab" class="tabcontent">
  <h3>Incorrect Days</h3>
  <div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnIncorrectDaysPrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return IncorrectDaysRecord(0);" />
             <asp:Button ID="btnIncorrectDaysNext" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return IncorrectDaysRecord(1);"/>
                 </div>
              <div id="divIncorrectDays" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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

<div id="divIncorrectOTCatgTab" class="tabcontent">
  <h3>Incorrect OT Category</h3>
  <div class="eachform" style="margin-left:2%;padding-top: 2%;">
             <asp:Button ID="btnIncorrectOTCatgPrevious"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" disabled="disabled" style="float:left;" OnClientClick="return IncorrectOTCategoryRecord(0);" />
             <asp:Button ID="btnIncorrectOTCatgNext" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return IncorrectOTCategoryRecord(1);"/>
                 </div>
              <div id="divIncorrectOTCatg" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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



    </div>



        




        </div>

   



          


              

        

         <div id="divRateMissing" class="fillform" style="background-color:  rgb(213, 219, 201); display:none; width:100%">        
              <div id="div9" style="margin-left:1%;margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <img src="" style="vertical-align: middle;"  />
            <a id="a7" style="margin-left:0%;color: rgb(83, 101, 51);" >Correct List</a>
        </div>
             <div class="eachform">
                <div class="subform" style="float:right">                                        
                    <asp:Button ID="btnRateMissingUpdate" runat="server" class="btn btn-primary" Text="Save" OnClientClick="return confirmUpdate();" OnClick="btnUpdate_Click"  style="float:right; margin-right: 9%;width:26%;"/>  
                    <asp:Button ID="btnRateMissingCancel" runat="server" class="btn btn-primary" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />                                
                </div>
            </div>
             <div class="eachform">
            <h2 id="h2CostPriceError" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;"></h2>
            <h2 id="h2CostPriceNoError" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C; display:none;"></h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Save" button to add following records in uploaded file to the table.</h2>
                 </div>

                <div>
       <br />
    <label id="lblDateCurrect" class="" style="width:25%;float:left;padding-left: 2.2%;font-size: 17px;"></label>
    <label id="lblNofEmpCurrect" class="" style="width:30%;float:left;font-size: 17px;"></label>
  </div>


             <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnCostPriceMissingPrevious" disabled="disabled"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return RateMissingRecord(0);"/>
                    <asp:Button ID="btnCostPriceMissingNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return RateMissingRecord(1);" />
              </div>
              <div id="divCostPriceMissingReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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



    </div>


           


         <div id="MyModalDuplicate" class="MyModalDuplicate" >
         <div id="divDuplicate">
             <div id="divSubHeader" style="height: 30px;background-color: #6f7b5a;">
                 
            <label style="margin-left: 38%;font-size: 22px;color: #fff;font-family: calibri;">Duplicated Employee List</label>

                   <img class="closeCancelView" style= "margin-top: .5%; margin-right: 1%;float: right; cursor: pointer;" onclick="return ClosModalView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
             </div>            
             
             <div id="divErrorNotificationSb" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotificationSb" runat="server"></asp:Label>
                </div>

             <div id="divDupTable" runat="server" style="float: left;width: 96%;margin-left: 1%;padding: 11px;">
             </div>
            
               <asp:Button ID="btnOverWrite" class="btn btn-primary" runat="server" Text="Over Write" style="width: 105px; float:left;margin-left:37%;margin-top: 0%;margin-bottom:0.5%;"  onClientClick="return OverWriteDup();"   />     
               <input type="button" id="btnSubCncl" class="btn btn-primary" style="width: 90px; float:left;margin-left:1%;margin-top: 0%;margin-bottom:0.5%;" onclick="return ClosModalView();" value="Cancel" />

         </div>

         </div>



        <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;display:none;"
                class="freezelayer" id="freezelayer">
                    </div>



    <style>
        .tdT {
            padding:0 0 0 0;
        }

         .MyModalDuplicate {
    display: none;
    position: fixed;
    z-index: 100;
    padding-top: 0%;
    left: 8%;
    top: 25%;
    width: 84%;
    max-height: 65%;
    overflow: auto;
    background-color: white;
    border: 3px solid;
    border-color: #6f7b5a;
}

           .open > .dropdown-menu {
            display: none;
        }
            #divDpartmnt {
            text-align: left;
            overflow: auto;
            margin-left: 41%;
            max-height: 161px;
            font-family: Calibri;
            box-shadow: 0px 0px 3px rgb(3, 185, 57);
            border-radius: 7px;
            background: #edf6dc;
            font-weight: bold;
            font-size: 15px;
            color: #4b7206;
            padding: 0px 19px 0px;
        }
            input[type="radio"] {
    display: inline;
}
                   
       .datepicker table tr td, .datepicker table tr th {
    text-align: center;
    width: 10px;
    height: 0px;
    border-radius: 0px;
    border: none;
    visibility:visible
}
    </style>
    <script>
        function isNumberDec(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
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
            else if (keyCodes == 190 || keyCodes == 110) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                return true;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }
    </script>

  




<style>

     /* Style the tab */
.tab {
  overflow: hidden;
  border: 1px solid #ccc;
  background-color: #f1f1f1;
}

/* Style the buttons that are used to open the tab content */
.tab button {
  background-color: inherit;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  transition: 0.3s;
}

/* Change background color of buttons on hover */
.tab button:hover {
  background-color: #ddd;
}

/* Create an active/current tablink class */
.tab button.active {
  background-color: #ccc;
}

/* Style the tab content */
.tabcontent {
  display: none;
  padding: 6px 12px;
  border: 1px solid #ccc;
  border-top: none;
} 





</style>


  

    



    <script>
        function OpenIncorrectList(evt, cityName) {
            // alert(cityName)
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(cityName).style.display = "block";
            evt.currentTarget.className += " active";
            return false;
        }
</script>

</asp:Content>



