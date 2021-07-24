<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Master_Fileupload_CSV.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Vehicle_Master_gen_Vehicle_Master_Fileupload_CSV" %>

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

    <script src="/js/side-menu/sidebar-menu.js" type="text/javascript"></script>

 <link type="text/css" href="CSS/ui.all.css" rel="stylesheet" />    
 <script type="text/javascript" src="Scripts/jquery-1.3.2.js"></script>    
 <script type="text/javascript" src="Scripts/ui.core.js"></script>    
 <script type="text/javascript" src="Scripts/ui.progressbar.js"></script>  
 <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script>
        function FupSelectedFileName() {

            document.getElementById('<%=Label1.ClientID%>').innerHTML = document.getElementById('<%=FileUploader.ClientID %>').value;
        }

    </script>
     <%--  for giving pagination to the html table--%>
    <%--<script src="../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="../../css/StyleSheetPagination.css" type="text/css" />
     <script>
         var $p = jQuery.noConflict();
         $p(document).ready(function () {
             $p('#ReportTable').DataTable({
                 "pagingType": "full_numbers",
                 "bSort": false

             });
         });


    </script>--%>
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
    height:67%;
    
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
        .DisableClass {
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



        function confirmUpdate() {
           
            if (confirm("Are you sure you want to add the following vehicle list to the table")) {
            }
            else {
                return false;
            }
        }
        function ShowError() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some Error Occured. Please Review The Details In Uploaded File !";
        }

        function ShowErrorDate() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Error in date format!";
        }

        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Vehicle details Updated As Per The Document";
        }
        function HideFileUploader() {
            document.getElementById('rowCrntNew').style.display = "none";
            document.getElementById('ContactHeadOne').style.display = "";
            document.getElementById('divFileUploader').style.display = "none";
            document.getElementById('divMisMatchLink').style.display = "";
            document.getElementById('divMisMatchLink').style.fontFamily = "calibri";
            var Count = document.getElementById("<%=HiddenCount.ClientID%>").value;
            var CountNewCurrentMisMatch = document.getElementById("<%=HiddenNewCurrentMisMatchCount.ClientID%>").value;
            if (Count == 1) {
                document.getElementById("<%=lblAlert.ClientID%>").innerHTML = " You have " + Count + " Mismatch Record";
                document.getElementById('ContactHeadOne').innerHTML = "Show Mismatch Entry";
            }
            else if (Count > 1) {
                document.getElementById("<%=lblAlert.ClientID%>").innerHTML = " You have " + Count + " Mismatch Records";
                document.getElementById('ContactHeadOne').innerHTML = "Show Mismatch Entries";
            }
            else {
                document.getElementById("<%=lblAlert.ClientID%>").innerHTML = " You have " + Count + " Mismatch Record";
                document.getElementById('ContactHeadOne').innerHTML = "";
            }

        if (Count == 0) {
            document.getElementById('ContactHeadOne').style.display = "none";
        }

        document.getElementById("<%=lblCrntNewAlert.ClientID%>").innerHTML = "";



            if (CountNewCurrentMisMatch != 0) {
                document.getElementById('rowCrntNew').style.display = "";
                if (CountNewCurrentMisMatch == 1) {
                    document.getElementById("<%=lblCrntNewAlert.ClientID%>").innerHTML = CountNewCurrentMisMatch + " Product will be updated with New Rate";
                    document.getElementById('LinkCrntNew').innerHTML = "Show Product";
                }
                else {

                    document.getElementById("<%=lblCrntNewAlert.ClientID%>").innerHTML = CountNewCurrentMisMatch + " Products will be updated with New Rate";
                    document.getElementById('LinkCrntNew').innerHTML = "Show Products";
                }
            }
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
        function FileValidate() {
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
            if (ret == false) {
                CheckSubmitZero();

            }
            if (ret == true) {
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

        function ViewMissingProductCode() {
            HideLoading();
            //alert('missing code');
            document.getElementById('divRateUpdate').style.display = "none";
            if (document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                    if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

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
                    }
                    else {
                        document.getElementById('divMismatchCode').style.display = "";

                    }

                }
                else {
                    document.getElementById('divDuplicateCode').style.display = "";
                }

            }
            else {

                document.getElementById('divMissingCode').style.display = "";
            }
            return false;
        }

        function ViewDuplication() {
           
            document.getElementById('divMissingCode').style.display="none";

            if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

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

                }
                else {
                    document.getElementById('divMismatchCode').style.display = "";
                }

            }
            else {
                document.getElementById('divDuplicateCode').style.display = "";
            }

            return false;

        }

        function ViewMismatch() {
            
            document.getElementById('divDuplicateCode').style.display = "none";
            if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {

                    document.getElementById('divRateMissing').style.display = "";
                    document.getElementById('h2CostPriceError').style.display = "none";
                    document.getElementById('h2CostPriceNoError').style.display = "";
                    document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "none";
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";


                }
                else {
                    document.getElementById('divRateMissing').style.display = "";
                }

            }
            else {
                document.getElementById('divMismatchCode').style.display = "";
            }
            return false;
        }

        function ViewDivisionDetails() {
            document.getElementById('divDivision').style.display = "";
            document.getElementById("<%=btnCodeMismatchCreate.ClientID%>").style.display = "none";
            document.getElementById('h2CreateProducts').style.display = "none";
            document.getElementById('h2CreateProductsDivision').style.display = "";
            return false;
        }

        function Validation_Item_Creation() {
            var Division = document.getElementById("<%=ddlDivision.ClientID%>").value;
            if (Division == "--Select A Division--") {
                document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlDivision.ClientID%>").focus();
                return false;
            }
            else {
                document.getElementById('divMismatchCode').style.display = "none";
                if (document.getElementById("<%=HiddenNameMissingCount.ClientID%>").value == '0') {

                    if (document.getElementById("<%=HiddenNameDuplicateCount.ClientID%>").value == '0') {

                        if (document.getElementById("<%=HiddenExceedLengthCount.ClientID%>").value == '0') {

                            CreateItems();
                        }
                        else {
                            document.getElementById('divExceedLengthProduct').style.display = "";
                        }
                    }
                    else {
                        document.getElementById('divProductNameDuplicate').style.display = "";
                    }
                }
                else {
                    document.getElementById('divProductNameMissing').style.display = "";
                }
                return false;
            }
            return false;
        }

        function ViewProductNameDuplicate() {
            document.getElementById('divProductNameMissing').style.display = "none";
            if (document.getElementById("<%=HiddenNameDuplicateCount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenExceedLengthCount.ClientID%>").value == '0') {

                    CreateItems();
                }
                else {
                    document.getElementById('divExceedLengthProduct').style.display = "";
                }

            }
            else {
                document.getElementById('divProductNameDuplicate').style.display = "";
            }
            return false;
        }

        function ViewExceedLength() {
            document.getElementById('divProductNameDuplicate').style.display = "none";
            if (document.getElementById("<%=HiddenExceedLengthCount.ClientID%>").value == '0') {

                CreateItems();
            }
            else {
                document.getElementById('divExceedLengthProduct').style.display = "";
            }
            return false;
        }

        function CloseCreateItem() {
            var Division = document.getElementById("<%=ddlDivision.ClientID%>").value;
            if (Division != "--Select A Division--") {
                if (confirm('Do You Want To Close Item Creation ?') == true) {
                    document.getElementById('divDivision').style.display = "none";
                    document.getElementById("<%=btnCodeMismatchCreate.ClientID%>").style.display = "";
                    document.getElementById("<%=ddlDivision.ClientID%>").selectedIndex = "0";
                    document.getElementById('h2CreateProducts').style.display = "";
                    document.getElementById('h2CreateProductsDivision').style.display = "none";
                    return false;
                }
                else {
                    return false;
                }
            }
            else {
                document.getElementById('divDivision').style.display = "none";
                document.getElementById("<%=btnCodeMismatchCreate.ClientID%>").style.display = "";
                document.getElementById("<%=ddlDivision.ClientID%>").selectedIndex = "0";
                document.getElementById('h2CreateProducts').style.display = "";
                document.getElementById('h2CreateProductsDivision').style.display = "none";
                return false;
            }
        }

        function CreateItems() {
            ShowLoading();
            var OrgId = document.getElementById("<%=HiddenOrgId.ClientID%>").value;
            var CorpId = document.getElementById("<%=HiddenCorpId.ClientID%>").value;
            var UserId = document.getElementById("<%=HiddenUserId.ClientID%>").value;
            var DivId = document.getElementById("<%=ddlDivision.ClientID%>").value;
            var ItemCreateList = document.getElementById("<%=HiddenItemCreateList.ClientID%>").value;

            var Create = PageMethods.Create_Products(OrgId, CorpId, UserId, DivId, ItemCreateList, function (response) {

                var Output = response;
                if (Output[0] == "Fail") {
                    ShowError();
                }
                else {
                    if (Output[1] == "0") {
                        document.getElementById('h2ItemCreate').style.display = "none";
                        document.getElementById('h2NoItemCreate').style.display = "";

                    }
                }

                document.getElementById('divExceedLengthProduct').style.display = "none";
                document.getElementById('divItemCreate').style.display = "";
                HideLoading();
                return false;
            });

            return false;
        }

        function ViewRateMissing() {
            document.getElementById('divItemCreate').style.display = "none";
            if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {

                document.getElementById('divRateMissing').style.display = "";
                document.getElementById('h2CostPriceError').style.display = "none";
                document.getElementById('h2CostPriceNoError').style.display = "";
                document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";


            }
            else {
                document.getElementById('divRateMissing').style.display = "";
            }
            return false;
        }

        function RateUpdateList() {
            document.getElementById('divRateUpdate').style.display = "none";
            document.getElementById('divRateAmendmentList').style.display = "";
        }

        function JumpToItemCreate() {
            document.getElementById('divMismatchCode').style.display = "none";

            if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {

                document.getElementById('divRateMissing').style.display = "";
                document.getElementById('h2CostPriceError').style.display = "none";
                document.getElementById('h2CostPriceNoError').style.display = "none";
                document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";


            }
            else {
                document.getElementById('divRateMissing').style.display = "";
            }

            return false;
        }


        function BackFromExceedLength() {

            document.getElementById('divExceedLengthProduct').style.display = "none";

            if (document.getElementById("<%=HiddenNameDuplicateCount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenNameMissingCount.ClientID%>").value == '0') {

                    if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

                        if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                            if (document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value == '0') {

                                document.getElementById('divRateUpdate').style.display = "";
                            }
                            else {
                                document.getElementById('divMissingCode').style.display = "";
                            }

                        }
                        else {
                            document.getElementById('divDuplicateCode').style.display = "";
                        }
                    }
                    else {
                        document.getElementById('divMismatchCode').style.display = "";
                    }

                }
                else {
                    document.getElementById('divProductNameMissing').style.display = "";
                }
            }
            else {
                document.getElementById('divProductNameDuplicate').style.display = "";
            }

            return false;

        }

        function BackFromNameDuplicate() {

            document.getElementById('divProductNameDuplicate').style.display = "none";

            if (document.getElementById("<%=HiddenNameMissingCount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

                    if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                        if (document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value == '0') {

                            document.getElementById('divRateUpdate').style.display = "";
                        }
                        else {
                            document.getElementById('divMissingCode').style.display = "";
                        }

                    }
                    else {
                        document.getElementById('divDuplicateCode').style.display = "";
                    }
                }
                else {
                    document.getElementById('divMismatchCode').style.display = "";
                }

            }
            else {
                document.getElementById('divProductNameMissing').style.display = "";
            }
            return false;
        }

        function BackFromNameMissing() {
            document.getElementById('divProductNameMissing').style.display = "none";
            if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                    if (document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value == '0') {

                        document.getElementById('divRateUpdate').style.display = "";
                    }
                    else {
                        document.getElementById('divMissingCode').style.display = "";
                    }

                }
                else {
                    document.getElementById('divDuplicateCode').style.display = "";
                }
            }
            else {
                document.getElementById('divMismatchCode').style.display = "";
            }
            return false;
        }

        function BackFromItemCreation() {
            document.getElementById('divMismatchCode').style.display = "none";
            if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value == '0') {

                    document.getElementById('divRateUpdate').style.display = "";
                }
                else {
                    document.getElementById('divMissingCode').style.display = "";
                }

            }
            else {
                document.getElementById('divDuplicateCode').style.display = "";
            }
            return false;
        }

        function BackFromCodeDuplication() {
            document.getElementById('divDuplicateCode').style.display = "none";
            if (document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value == '0') {

                document.getElementById('divRateUpdate').style.display = "";
            }
            else {
                document.getElementById('divMissingCode').style.display = "";
            }
            return false;
        }

        function BackFromCodeMissing() {
            document.getElementById('divMissingCode').style.display = "none";
            document.getElementById('divRateUpdate').style.display = "";
            return false;
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

            var Create = PageMethods.ServiceListToHtml(MissingCode, NextId, Mode, TotalCount, function (response) {
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


        function DuplicateCodeRecord(Mode) {
            var NextId = document.getElementById("<%=HiddenCodeDuplicateNext.ClientID%>").value;
            var DuplicateCode = document.getElementById("<%=HiddenCodeDuplicateList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtml(DuplicateCode, NextId, Mode, TotalCount, function (response) {
                var DuplicateCodeList = response;
                document.getElementById('cphMain_divDuplicationCodeReport').innerHTML = DuplicateCodeList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").disabled = false;
                            document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").style.background = '#9ba48b';
                            document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").style.cursor = 'pointer';
                        }
                        else {
                            document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").disabled = false;
                            document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").style.background = '#9ba48b';
                            document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").style.cursor = 'pointer';
                        }

                        document.getElementById("<%=HiddenCodeDuplicateNext.ClientID%>").value = DuplicateCodeList[1];
                        if (Mode == '1') {

                            if (parseInt(document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCodeDuplicateNext.ClientID%>").value)) {
                        document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenCodeDuplicateNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").style.cursor = 'default';
                    }
                }
                    })
            return false;
        }


        function MismatchCodeRecord(Mode) {

            var NextId = document.getElementById("<%=HiddenCodeMismatchNext.ClientID%>").value;
            var MismatchCode = document.getElementById("<%=HiddenCodeMismatchList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';

            var Create = PageMethods.ServiceListToHtml(MismatchCode, NextId, Mode, TotalCount, function (response) {
                var MismatchCodeList = response;
                document.getElementById('cphMain_divMismatchCodeReport').innerHTML = MismatchCodeList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenCodeMismatchNext.ClientID%>").value = MismatchCodeList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCodeMismatchNext.ClientID%>").value)) {
                                document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").disabled = true;
                                document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").style.background = '#9c9c9c';
                                document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").style.cursor = 'default';
                            }
                        }
                        else {

                            if (document.getElementById("<%=HiddenCodeMismatchNext.ClientID%>").value == '100') {

                                document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }


        function MissingNameRecord(Mode) {

            var NextId = document.getElementById("<%=HiddenNameMissingNext.ClientID%>").value;
            var MissingName = document.getElementById("<%=HiddenNameMissingList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenNameMissingCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';

            var Create = PageMethods.ServiceListToHtml(MissingName, NextId, Mode, TotalCount, function (response) {
                var MissingNameList = response;
                document.getElementById('cphMain_divProductNameMissingReport').innerHTML = MissingNameList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnNameMissingPrevious.ClientID%>").disabled = false;
                       document.getElementById("<%=btnNameMissingPrevious.ClientID%>").style.background = '#9ba48b';
                       document.getElementById("<%=btnNameMissingPrevious.ClientID%>").style.cursor = 'pointer';
                   }
                   else {
                       document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").disabled = false;
                       document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").style.background = '#9ba48b';
                       document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").style.cursor = 'pointer';
                   }

                   document.getElementById("<%=HiddenNameMissingNext.ClientID%>").value = MissingNameList[1];
                   if (Mode == '1') {

                       if (parseInt(document.getElementById("<%=HiddenNameMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenNameMissingNext.ClientID%>").value)) {
                        document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenNameMissingNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnNameMissingPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNameMissingPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnNameMissingPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
               })
            return false;
        }


        function DuplicateNameRecord(Mode) {
            var NextId = document.getElementById("<%=HiddenNameDuplicateNext.ClientID%>").value;
            var DuplicateName = document.getElementById("<%=HiddenNameDuplicateList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenNameDuplicateCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtml(DuplicateName, NextId, Mode, TotalCount, function (response) {
                var DuplicateNameList = response;
                document.getElementById('cphMain_divProductNameDuplicateReport').innerHTML = DuplicateNameList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenNameDuplicateNext.ClientID%>").value = DuplicateNameList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenNameDuplicateCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenNameDuplicateNext.ClientID%>").value)) {
                                document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").disabled = true;
                                document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").style.background = '#9c9c9c';
                                document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").style.cursor = 'default';
                            }
                        }
                        else {

                            if (document.getElementById("<%=HiddenNameDuplicateNext.ClientID%>").value == '100') {

                                document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").style.cursor = 'default';
                    }
                }
            })
            return false;
        }



        function ExceedLengthRecord(Mode) {
            var NextId = document.getElementById("<%=HiddenExceedLengthNext.ClientID%>").value;
            var ExceedLength = document.getElementById("<%=HiddenExceedLengthList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenNameDuplicateCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtml(ExceedLength, NextId, Mode, TotalCount, function (response) {
                var ExceedLengthList = response;
                document.getElementById('cphMain_divExceedLengthReport').innerHTML = ExceedLengthList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").style.background = '#9ba48b';
                    document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenExceedLengthNext.ClientID%>").value = ExceedLengthList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenExceedLengthCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenExceedLengthNext.ClientID%>").value)) {
                        document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenExceedLengthNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").disabled = "disabled";
                                document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").style.background = '#9c9c9c';
                                document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").style.cursor = 'default';
                            }
                        }
            })
                    return false;
                }


                function NewProductsRecord(Mode) {
                    var NextId = document.getElementById("<%=HiddenNewProductsNext.ClientID%>").value;
            var NewProducts = document.getElementById("<%=HiddenNewProductList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenNewProductsCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtml(NewProducts, NextId, Mode, TotalCount, function (response) {
                var NewProductsList = response;
                document.getElementById('cphMain_divNewItemsReport').innerHTML = NewProductsList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnNewItemsPrevious.ClientID%>").disabled = false;
                            document.getElementById("<%=btnNewItemsPrevious.ClientID%>").style.background = '#9ba48b';
                            document.getElementById("<%=btnNewItemsPrevious.ClientID%>").style.cursor = 'pointer';
                        }
                        else {
                            document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").disabled = false;
                            document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").style.background = '#9ba48b';
                            document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").style.cursor = 'pointer';
                        }

                        document.getElementById("<%=HiddenNewProductsNext.ClientID%>").value = NewProductsList[1];
                        if (Mode == '1') {

                            if (parseInt(document.getElementById("<%=HiddenNewProductsCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenNewProductsNext.ClientID%>").value)) {
                        document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenNewProductsNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnNewItemsPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNewItemsPrevious.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnNewItemsPrevious.ClientID%>").style.cursor = 'default';
                    }
                }
                    })
            return false;
        }


        function RateMissingRecord(Mode) {
            var NextId = document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value;
            var RateMissing = document.getElementById("<%=HiddenCostPriceMissingList.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtml(RateMissing, NextId, Mode, TotalCount, function (response) {
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


        function RateAmendmentRecord(Mode) {
            var NextId = document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value;
            var RateAmendment = document.getElementById("<%=HiddenCorrectListCopy.ClientID%>").value;
            var TotalCount = document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value
            if (Mode == '1')
                var Mode = '1';
            else
                var Mode = '0';
            var Create = PageMethods.ServiceListToHtml(RateAmendment, NextId, Mode, TotalCount, function (response) {
                var RateAmendmentList = response;
                document.getElementById('cphMain_divRateAmendmentReport').innerHTML = RateAmendmentList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").disabled = false;
                            document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").style.background = '#9ba48b';
                            document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").style.cursor = 'pointer';
                        }
                        else {
                            document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").disabled = false;
                            document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").style.background = '#9ba48b';
                            document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").style.cursor = 'pointer';
                        }

                        document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value = RateAmendmentList[1];
                        if (Mode == '1') {

                            if (parseInt(document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value)) {
                        document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").style.background = '#9c9c9c';
                        document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").disabled = "disabled";
                                document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").style.background = '#9c9c9c';
                                document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").style.cursor = 'default';
                            }
                        }
                    })
                    return false;
                }

    </script>
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
         <%--it opens a window --%>
        function report() {
            var WinPrint = window.open('../gen_Vehicle_Master/Report.html', 'PrdctnDtlReportPrint', 'menubar=1,resizable=1,scrollbars=1,width=900,height=650,top=100,left=210');
            WinPrint.focus();
        }
        function reportCrntNew() {
            var WinPrint = window.open('../gen_Vehicle_Master/Report_MisMatchCrrntNew.html', 'PrdctnDtlReport', 'menubar=1,resizable=1,scrollbars=1,width=900,height=650,top=100,left=210');
            WinPrint.focus();
        }
        function ConfirmMessage() {
            if (confirm("Are You Sure You Want To Cancel Process?")) {
                window.location.href = "gen_Vehicle_Master_Fileupload_CSV.aspx";
            }
            else {
                return false;
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        //function ProgressBar () {          
        //     // jquery Progress bar function.    
        //     $("#progressbar").progressbar({ value: 0 });    
        //     $("#lbldisp").hide();        
        //     //button click event    
        //     $("#btnGetData").click(function () {    
        //         $("#btnGetData").attr("disabled", "disabled")    
        //         $("#lbldisp").show();    
        //         //call back function    
        //         var intervalID = setInterval(updateProgress, 250);
        //         //var $ = jQuery.noConflict();
        //         alert('hello');
        //         $.ajax({    
        //             type: "POST",    
        //             url: "gen_Product_Rate_Amendment.aspx/GetText",    
        //             data: "{}",    
        //             contentType: "application/json; charset=utf-8",    
        //             dataType: "json",    
        //             async: true,    
        //             success: function (msg) {    
        //                 $("#progressbar").progressbar("value", 100);    
        //                 $("#lblStatus").hide();    
        //                 $("#lbldisp").hide();    
        //                 $("#result").text(msg.d);                            
        //                 clearInterval(intervalID);    
        //             }    
        //         });    
        //         return false;    
        //     });
        //     return false;
        // };    
        //This function is the callback function which is executed in every 250 milli seconds. Until the ajax call is success this method is invoked and the progressbar value is changed.    
        //function updateProgress() {               
        //    var value = $("#progressbar").progressbar("option", "value");    
        //    if (value < 100) {    
        //        $("#progressbar").progressbar("value", value + 1);    
        //        $("#lblStatus").text((value + 1).toString() +"%");                
        //    }    
        //}                   
   </script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <div class="cont_rght">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <div id="divAlert" style="visibility: hidden">
            
        </div>

        <asp:HiddenField ID="hiddenError" runat="server" />


        <asp:HiddenField ID="HiddenCount" runat="server" />
         <asp:HiddenField ID="HiddenNewCurrentMisMatchCount" runat="server" />
        <asp:HiddenField ID="HiddenFile" runat="server" />
        <asp:HiddenField ID="HiddenOrgId" runat="server" />
        <asp:HiddenField ID="HiddenCorpId" runat="server" />
        <asp:HiddenField ID="HiddenUserId" runat="server" />
        <asp:HiddenField ID="HiddenItemCreateList" runat="server" />
        <asp:HiddenField ID="HiddenRateAmendmentList" runat="server" />

        <asp:HiddenField ID="HiddenCodeMissingCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodemissingPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeMissingNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeMissingList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenCodeDuplicateCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeDuplicatePrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeDuplicateNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeDuplicateList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenCodeMismatchcount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeMismatchPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeMismatchNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCodeMismatchList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenNameMissingCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNameMissingPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNameMissingNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNameMissingList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenNameDuplicateCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNameDuplicatePrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNameDuplicateNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNameDuplicateList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenExceedLengthCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenExceedLengthPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenExceedLengthNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenExceedLengthList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenNewProductsCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNewProductsPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNewProductsNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenNewProductList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenCostPriceMissingCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCostPriceMissingPrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCostPriceMissingNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenCostPriceMissingList" runat="server" value="0"/>

        <asp:HiddenField ID="HiddenRateUpdateCount" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenRateUpdatePrevious" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenRateUpdateNext" runat="server" value="0"/>
        <asp:HiddenField ID="HiddenRateUpdateList" runat="server" value="0"/>
         <asp:HiddenField ID="HiddenCorrectListCopy" runat="server" value="0"/>
         <div id="divLoading" class="model" style="display:none;"  >
            <div class="eachform" style="width:12%; height:55%; padding-left:42%; padding-top:10%;">
                 <img src="/../Images/Other Images/LoadingMail.gif" style="width:75%" />
                 </div>
    </div>
        <br />
        <div id="divRateUpdate" class="fillform" style="background-color: rgb(225, 242, 225); width:100%;">

            <div id="divList" class="list"  onclick="location.href='gen_Vehicle_Master_List.aspx'"  runat="server" style="position:fixed; right:4%; top:26%;height:26.5px;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>
            <div id="divReportCaption" style="margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
          
            <a id="a_Caption" style="margin-left:1%;" >Add Vehicle</a>
        </div>
            <br />
            <br />
             
            <div id="divFileUploader" class="eachform" style="height: 40px;">
                <h2 style="padding-top: 0.4%; padding-left:1%">Choose File*</h2>
                

               <label id="lblFileUpload" for="cphMain_FileUploader" class="custom-file-upload" tabindex="0" style="margin-left:24.6%;color:black" ><img src="/../Images/Icons/cloud_upload.jpg"/>Upload File </label>
               <asp:FileUpload ID="FileUploader" class="imageUpload" onchange="FupSelectedFileName()" runat="server" Accept=".csv"  
                   style="display:none;padding-left:24.5%;"/>

                <!--<asp:TextBox ID="TextBox1" Text="No File selected"  runat="server"></asp:TextBox>-->
               <asp:Label ID="Label1" runat="server" Text="No File selected" Style="font-family: Calibri; font-size: medium;"></asp:Label>
            
            <a href="/CustomFiles/csvTemplate/Vehicle_importing.csv" style="float: right;margin-right: 30%;">  <img src="../../../Images/Icons/CSV.PNG" title="Sample CSV File" /></a>
            
            </div>
             <div class="subform" style="margin-left: 34.3%;margin-bottom: 2%;">
                    <asp:CheckBox ID="cbxImprtHasHeader" Text="" runat="server" Checked="false" class="form2" Style="margin-top: -0.4%;"  onkeypress=" return DisableEnter(event);" />

                    <label style="font-family: Calibri; color: #7b826e; cursor: pointer;" for="cphMain_cbxImprtHasHeader">My data has Headers</label>
                </div>
             <div id="divMisMatchLink" class="eachform" style="height: 50px; font-family:Calibri; color: rgb(83, 101, 51); display:none">
                 <table style="margin-top: -3%; margin-left: 7%;">
                   <tr>
                         <td>
                         You can update the Product Rates now,
                             </td>
                        
                         </tr>
                       <tr>
                         <td>
                 <asp:Label ID="lblAlert" runat="server"></asp:Label>      
                                <span id="ContactHeadOne" style="padding-top:0%; color: rgb(83, 101, 51); cursor:pointer; width:110%; font-family:Calibri; font-size: 18px; font-weight: bold;" OnClick="report()">Show Mismatch Entries</span>      
                             </td>
                        
                         </tr>
                       <tr id="rowCrntNew">
                         <td>
                 <asp:Label ID="lblCrntNewAlert" runat="server"></asp:Label>   
                               <span id="LinkCrntNew" style="padding-top:0%; color: rgb(83, 101, 51); cursor:pointer; width:110%; font-family:Calibri; font-size: 18px; font-weight: bold;" OnClick="reportCrntNew()">Show Products</span>         
                             </td>
                      
                         </tr>
                     </table>
                 </div>
            <br />
            <div class="eachform">
                <div class="subform" style="margin-left: 34.5%;">                   
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Proceed" OnClick="btnAdd_Click"  OnClientClick="return FileValidate();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel"  PostBackUrl="gen_Vehicle_Master_Fileupload_CSV.aspx" />
                </div>
            </div>

            <div id="prntTable" class="table-responsive" runat="server" style="display:none">
                 </div>
             <div id="prntCrrntNewMisMatchTable" class="table-responsive" runat="server" style="display:none">
        </div>
            <div id="div2" class="eachform" "  >

                  <h2 id="headingNote" style="color: rgb(83, 101, 51); padding-left:1%; cursor:pointer; font-weight: bold;" OnClick="VisibleNote()" >Condition+</h2>                  
                  </div>
             <div id="divNote" class="eachform" style="padding-left:1%; color: red; font-family:Calibri; display:none">
                 <asp:Label ID="lblNote" runat="server" Text="Note: Required CSV File Must Contain All Mandatory Fields For Adding A Vehicle.Date Field Should Be In DD-MM-YYYY Format."></asp:Label> 
                   </div>

        </div>


        <div id="divMissingCode" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div1" style="margin-left:1%;margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <img src="/Images/BigIcons/Vehicle-Master.png" style="vertical-align: middle;"  />
            <a id="a1" style="margin-left:0%;">Incorrect Vehicle List</a>
        </div>
              <div class="eachform">
                <div class="subform" style="float:right; width:45%"> 
                    <asp:Button ID="btnCodeMissingNext" runat="server" class="save" Text="Next>>" style="float:right; margin-right: 9%;" OnClientClick="return ViewDuplication();"/>                  
                    <asp:Button ID="btnCodeMissingCancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />
                    <asp:Button ID="btnCodeMissingBack" runat="server" class="save" Text="<<Back" style="float:right; margin-right: 3%;" OnClientClick="return BackFromCodeMissing();" />                                                                                                                                          
                </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Following records in uploaded file contain either missing fields,duplicate fields or mismatched fields.These records will be excluded while importing.</h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Next" button to continue.</h2>
                 </div>
             <div class="eachform" style="margin-left:2%;">
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

                <div id="divDuplicateCode" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div4" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/Rate-Updation48x48.png" style="vertical-align: middle;"  />
            <a id="a2" >Vehicle Register Number Duplicate</a>
        </div>
             <div class="eachform">
                <div class="subform" style="float:right; width:45%">                      
                    <asp:Button ID="btnCodeDuplicationNext" runat="server" class="cancel" Text="Next>>" OnClientClick="return ViewMismatch();" style="float:right; margin-right: 9%;"/>
                    <asp:Button ID="btnCodeDuplicationCancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;"  OnClientClick="return ConfirmMessage();" />                                      
                    <asp:Button ID="btnCodeDuplicationBack" runat="server" class="save" Text="<<Back" style="float:right; margin-right: 3%;" OnClientClick="return BackFromCodeDuplication();" />                                                                               
                </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Vehicle register number(s) has been duplicated for the following records in uploaded file.These records will be excluded while importing.</h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Next" button to continue.</h2>
                 </div>
                     <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnDuplicationCodePrevious"  Width="19%" disabled="disabled" runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return DuplicateCodeRecord(0);"/>
                    <asp:Button ID="btnDuplicationCodeNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return DuplicateCodeRecord(1);"/>
</div>
              <div id="divDuplicationCodeReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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

          <div id="divMismatchCode" class="fillform" style="background-color: rgb(225, 242, 225);display:none ;width:100%">        
              <div id="div5" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/Rate-Updation48x48.png" style="vertical-align: middle;"  />
            <a id="a3" >Vehicle Register Number Mismatch</a>
        </div>
                  <div class="eachform">
                <div class="subform" style="float:right; width:45%;">                     
                    <asp:Button ID="btnCodeMismatchNext" runat="server" class="cancel" Text="Next>>" OnClientClick="return JumpToItemCreate();" style="float:right; margin-right: 9%;" />                                        
                    <asp:Button ID="btnCodeMismatchcancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;"  OnClientClick="return ConfirmMessage();" />
                    <asp:Button ID="btnCodeMismatchCreate" runat="server" class="cancel" Text="Create" style="float:right; margin-right: 3%;" OnClientClick="return ViewDivisionDetails();" />                  
                    <asp:Button ID="btnCodeMismatchBack" runat="server" class="save" Text="<<Back" style="float:right; margin-right: 3%;" OnClientClick="return BackFromItemCreation();" />                                         
                     <asp:Button ID="btnCodeMismatchClose" runat="server" class="cancel" Text="Close" style="margin-right: 9%; float:right; display:none"  />            
                </div>
            </div>
              <div id="divDivision" class="eachform" style="display:none;">
                <asp:DropDownList ID="ddlDivision" Height="30px" Width="25%" class="form1" runat="server" Style="margin-right: 5%; margin-top: 2%;" ></asp:DropDownList>
                   <h2 style="float:right;margin-top: 2.5%;margin-right: 2%;">Division*</h2>
                   <div class="eachform" style="margin-top: 1%;">
                      <asp:Button ID="btnNewItemCreateClose" runat="server" class="cancel" Text="Close" style="margin-right: 5%; float:right;"  OnClientClick="return CloseCreateItem();" />
                       <asp:Button ID="btnNewItemCreate" runat="server" class="cancel" Text="OK" style="margin-right: 1%; float:right;"  OnClientClick="return Validation_Item_Creation();"/>                          
                   </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Vehicle register number(s) for the following records are not found in vehicle master.</h2>
                 <h2 id="h2CreateProducts" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Select "Create" button to create these records as new vehicles or select "Next" button to exclude these records.</h2>
                 <h2 id="h2CreateProductsDivision" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C; display:none;">Choose a division to create new products or select "Next" button to exclude these records.</h2>
                 </div>
           <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnMismatchCodePrevious"  Width="19%" disabled="disabled"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return MismatchCodeRecord(0);" />
                    <asp:Button ID="btnMismatchCodeNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return MismatchCodeRecord(1);"  />
              </div>
              <div id="divMismatchCodeReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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
                <div id="divProductNameMissing" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div6" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/Rate-Updation48x48.png" style="vertical-align: middle;"  />
            <a id="a4" >Product Name Missing</a>
        </div>
              <div class="eachform">
                <div class="subform" style="float:right; width:45%">                      
                    <asp:Button ID="btnProductNameMissingCreate" runat="server" class="save" Text="Create>>" OnClientClick="return ViewProductNameDuplicate();" style="float:right; margin-right: 9%;"/>                                 
                    <asp:Button ID="btnProductNameMissingCancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />                                    
                    <asp:Button ID="btnProductNameMissingBack" runat="server" class="save" Text="<<Back" style="float:right; margin-right: 3%;" OnClientClick="return BackFromNameMissing();" />                                       
                </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Product Name(s) has not been specified for the following records in uploaded file.These records will be excluded while creating new products.</h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Create" button to continue.</h2>
                 </div>
                    <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnNameMissingPrevious"  Width="19%" disabled="disabled"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return MissingNameRecord(0);" />
                    <asp:Button ID="btnNameMissingNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return MissingNameRecord(1);" />
              </div>
              <div id="divProductNameMissingReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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

                        <div id="divProductNameDuplicate" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div7" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/Rate-Updation48x48.png" style="vertical-align: middle;"  />
            <a id="a5" >Product Name Duplicate</a>
        </div>
            <div class="eachform">
                <div class="subform" style="float:right; width:45%">                            
                     <asp:Button ID="btnProductNameDuplicateCreate" runat="server" class="save" Text="Create>>" OnClientClick="return ViewExceedLength();" style="float:right; margin-right: 9%;"/>
                     <asp:Button ID="btnProductNameDuplicateCancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />                 
                    <asp:Button ID="btnRateMissingBack" runat="server" class="save" Text="<<Back" style="float:right; margin-right: 3%;" OnClientClick="return BackFromNameDuplicate();" />                                 
                </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Product Name(s) has been duplicated for the following records in uploaded file.These records will be excluded while creating new products.</h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Create" button to continue.</h2>
                 </div>
                            <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnNameDuplicatePrevious"  Width="19%" disabled="disabled" runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return DuplicateNameRecord(0);" />
                    <asp:Button ID="btnNameDuplicateNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return DuplicateNameRecord(1);"/>
              </div>
              <div id="divProductNameDuplicateReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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


        <div id="divExceedLengthProduct" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div11" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/Rate-Updation48x48.png" style="vertical-align: middle;"  />
            <a id="a9" >Exceed Length Records</a>
        </div>
            <div class="eachform">
                <div class="subform" style="float:right; width:45%">                            
                     <asp:Button ID="btnExceedLengthCreate" runat="server" class="save" Text="Create>>" OnClientClick="return CreateItems();" style="float:right; margin-right: 9%;"/>
                     <asp:Button ID="btnExceedLengthCancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />                 
                    <asp:Button ID="btnExceedLengthBack" runat="server" class="save" Text="<<Back" style="float:right; margin-right: 3%;" OnClientClick="return BackFromExceedLength();" />                                 
               </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Any of the field(s) are exceeds its length in the following records in uploaded file.These records will be excluded while creating new vehicles.</h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Create" button to continue.</h2>
                 </div>
            <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnExceedLengthPrevious" disabled="disabled"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return ExceedLengthRecord(0);"/>
                    <asp:Button ID="btnExceedlengthNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return ExceedLengthRecord(1);"/>
              </div>
              <div id="divExceedLengthReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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


                                <div id="divItemCreate" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div8" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="../../Images/BigIcons/Rate-Updation48x48.png" style="vertical-align: middle;"  />
            <a id="a6" >New Vehicles</a>
        </div>
              <div class="eachform">
                <div class="subform" style="float:right">           
                    <asp:Button ID="btnNewItemUpdate" runat="server" class="save" Text="Update>>" OnClientClick="return ViewRateMissing();" style="float:right; margin-right: 9%;"/>                             
                    <asp:Button ID="btnNewItemCancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />                                      
                </div>
            </div>
             <div class="eachform">
            <h2 id="h2ItemCreate" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">These vehicles were created Successfully.</h2>
                  <h2 id="h2NoItemCreate" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C; display:none;">No new vehicles were created.</h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Update" button to add following vehicle list.</h2>
                 </div>
                                    <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnNewItemsPrevious" disabled="disabled"  Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return NewProductsRecord(0);" />
                    <asp:Button ID="btnNewItemsNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return NewProductsRecord(1);"/>
              </div>
              <div id="divNewItemsReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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

         <div id="divRateMissing" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div9" style="margin-left:1%;margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           <img src="/Images/BigIcons/Vehicle-Master.png" style="vertical-align: middle;"  />
            <a id="a7" style="margin-left:0%;" >Correct Vehicle List</a>
        </div>
             <div class="eachform">
                <div class="subform" style="float:right">                                        
                    <asp:Button ID="btnRateMissingUpdate" runat="server" class="save" Text="Update>>" OnClientClick="return confirmUpdate();" OnClick="btnUpdate_Click"  style="float:right; margin-right: 9%;"/>  
                    <asp:Button ID="btnRateMissingCancel" runat="server" class="cancel" Text="Cancel" style="float:right; margin-right: 3%;" OnClientClick="return ConfirmMessage();" />                                
                </div>
            </div>
             <div class="eachform">
            <h2 id="h2CostPriceError" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;"></h2>
            <h2 id="h2CostPriceNoError" style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C; display:none;"></h2>
                 <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">Use "Update" button to add following records in uploaded file to the table.</h2>
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

                 <div id="divRateAmendmentList" class="fillform" style="background-color: rgb(225, 242, 225); display:none; width:100%">        
              <div id="div10" style="margin-left:1%;margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Vehicle-Master.png" style="vertical-align: middle;"  />
            <a id="a8" style="margin-left:0%;" >Vehicle List</a>
        </div>
            <div class="eachform">
                <div class="subform" style="float:right">                                        
                    <asp:Button ID="btnRateAmendmentClose" runat="server" class="cancel" Text="Close" style="margin-right: 9%; float:right"  />               
                </div>
            </div>
             <div class="eachform">
            <h2 style="padding-left:1%; font-weight: bold; font-family:Calibri; color: #3B799C;">These vehicle(s) updated sucessfully</h2>                 
                 </div>
                     <div class="eachform" style="margin-left:2%;">
                    <asp:Button ID="btnRateAmendmentPrevious" disabled="disabled" Width="19%"  runat="server" class="searchlist_btn_rght" Text="Show Previous 100 Records" style="float:left;" OnClientClick="return RateAmendmentRecord(0);"/>
                    <asp:Button ID="btnRateAmendmentNextRecords" Width="19%" runat="server" class="searchlist_btn_rght" Text="Show Next 100 Records" style="float:left;" OnClientClick="return RateAmendmentRecord(1);"/>
              </div>
              <div id="divRateAmendmentReport" class="table-responsive" runat="server" style="width:96%;margin-left:2%;overflow:auto;">
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
  
<%--   <div id="result"></div><br />    
   <asp:Label runat="server"  ID="lbldisp" Text= "Percentage Completed : "/>    
   <asp:Label   runat="server" ID="lblStatus" />    
   <br />    
   <asp:Button ID="btnGetData" runat="server" Text="Get Data" OnClientClick="return ProgressBar();" />    

    </div>--%>

    </div>
</asp:Content>

