<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Product_Rate_Amendment.aspx.cs" Inherits="Transaction_gen_Product_Rate_Amendment_gen_Product_Rate_Amendment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script> 
    <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
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
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
         });
    </script>
    <script>
        function FupSelectedFileName() {
            document.getElementById('<%=Label1.ClientID%>').innerHTML = document.getElementById('<%=FileUploader.ClientID %>').value;
        }

    </script>
    <script type="text/javascript">

        function ShowError() {
            $("#divWarning").html("Some error occured. Please review the details in uploaded file !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
       
        function SuccessUpdation() {
            $("#divWarning").html("Product rate updated as per the document");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }        
        function ErrorMessage() {
            $("#divWarning").html("Uploaded csv file is not correct format, Please choose the correct format csv file");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
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
            document.getElementById("<%=FileUploader.ClientID%>").style.borderColor = "";
        
            if (fileUploader == "") {
                $("#divWarning").html("Please choose the rate amendment csv file");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=FileUploader.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=FileUploader.ClientID%>").focus();
                ret=false;
            }
            else {

                if (Extension == "csv") {
                    ret=true;
                }
                else {
                    $("#divWarning").html("The specified file could not be uploaded. File type not supported. Allowed type is csv");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=FileUploader.ClientID%>").focus();
                    ret= false;
                }
            }
            if (ret == false) {
                CheckSubmitZero();

            }
            if (ret == true)
            {
                ShowLoading();
            }
            return ret;
        }

        function ViewMissingProductCode() {
            HideLoading();
            document.getElementById('divRateUpdate').style.display = "none";
            if (document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value == '0') {
               
                if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                    if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

                        if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {

                            document.getElementById('divRateMissing').style.display = "";
                            document.getElementById('h2CostPriceError').style.display = "none";
                            document.getElementById('h2CostPriceNoError').style.display = "";
                            document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "none";
                            document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                            document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";                            
                            document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").style.display = "none";
                            document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").style.display = "none";
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
            document.getElementById('divMissingCode').style.display = "none";

            if (document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value == '0') {

                if (document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value == '0') {

                    if (document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value == '0') {

                        document.getElementById('divRateMissing').style.display = "";
                        document.getElementById('h2CostPriceError').style.display = "none";
                        document.getElementById('h2CostPriceNoError').style.display = "";
                        document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "none";
                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                        document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";                            
                        document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").style.display = "none";
                        document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").style.display = "none";     

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
                    document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").style.display = "none";
                    document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").style.display = "none"; 

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
            document.getElementById("<%=btnCodeMismatchCreateB.ClientID%>").style.display = "none";
            //document.getElementById('h2CreateProducts').style.display = "none";
            //document.getElementById('h2CreateProductsDivision').style.display = "";
            return false;
        }

        function Validation_Item_Creation() {
            var Division = document.getElementById("<%=ddlDivision.ClientID%>").value;
            $("div#divDiv input.ui-autocomplete-input").css("borderColor", "");
            if (Division == "--Select A Division--") {
                document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlDivision.ClientID%>").focus();
                $("div#divDiv input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divDiv input.ui-autocomplete-input").select();
                $("div#divDiv input.ui-autocomplete-input").focus();
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
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to close item creation?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById('divDivision').style.display = "none";
                        document.getElementById("<%=btnCodeMismatchCreate.ClientID%>").style.display = "";
                        document.getElementById("<%=btnCodeMismatchCreateB.ClientID%>").style.display = "";
                        document.getElementById("<%=ddlDivision.ClientID%>").selectedIndex = "0";
                        //document.getElementById('h2CreateProducts').style.display = "";
                        //document.getElementById('h2CreateProductsDivision').style.display = "none";
                        return false;
                }
                else {
                    return false;
                }
            });
            }
            else {
                document.getElementById('divDivision').style.display = "none";
                document.getElementById("<%=btnCodeMismatchCreate.ClientID%>").style.display = "";
                document.getElementById("<%=btnCodeMismatchCreateB.ClientID%>").style.display = "";
                document.getElementById("<%=ddlDivision.ClientID%>").selectedIndex = "0";
                //document.getElementById('h2CreateProducts').style.display = "";
                //document.getElementById('h2CreateProductsDivision').style.display = "none";
                return false;
            }
            return false;
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
                document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").style.display = "none"; 

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
                document.getElementById('h2CostPriceNoError').style.display = "";
                document.getElementById("<%=divCostPriceMissingReport.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.display = "none";                            
                document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").style.display = "none";
                document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").style.display = "none";   

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
            if(Mode=='1')
                var Mode = '1';
            else
                var Mode = '0';
            
            var Create = PageMethods.ServiceListToHtml(MissingCode, NextId, Mode, TotalCount,0, function (response) {
                var MissingCodeList = response;
                document.getElementById('cphMain_divMissingCodeReport').innerHTML = MissingCodeList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnMissingCodePrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMissingCodePrevious.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnMissingCodePreviousB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMissingCodePreviousB.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnMissingCodeNextRecordsB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMissingCodeNextRecordsB.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenCodeMissingNext.ClientID%>").value = MissingCodeList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenCodeMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCodeMissingNext.ClientID%>").value)) {
                        document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnMissingCodeNextRecords.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnMissingCodeNextRecordsB.ClientID%>").disabled = true;
                        document.getElementById("<%=btnMissingCodeNextRecordsB.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenCodeMissingNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnMissingCodePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnMissingCodePrevious.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnMissingCodePreviousB.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnMissingCodePreviousB.ClientID%>").style.cursor = 'default';
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
                    var Create = PageMethods.ServiceListToHtml(DuplicateCode, NextId, Mode, TotalCount,0, function (response) {
                        var DuplicateCodeList = response;
                        document.getElementById('cphMain_divDuplicationCodeReport').innerHTML = DuplicateCodeList[0];
                        if (Mode == '1') {
                            document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").disabled = false;
                            document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").style.cursor = 'pointer';
                            document.getElementById("<%=btnDuplicationCodePreviousB.ClientID%>").disabled = false;
                            document.getElementById("<%=btnDuplicationCodePreviousB.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").disabled = false;
                            document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").style.cursor = 'pointer';
                            document.getElementById("<%=btnDuplicationCodeNextRecordsB.ClientID%>").disabled = false;
                            document.getElementById("<%=btnDuplicationCodeNextRecordsB.ClientID%>").style.cursor = 'pointer';
                }

                        document.getElementById("<%=HiddenCodeDuplicateNext.ClientID%>").value = DuplicateCodeList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenCodeDuplicateCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCodeDuplicateNext.ClientID%>").value)) {
                        document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnDuplicationCodeNextRecords.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnDuplicationCodeNextRecordsB.ClientID%>").disabled = true;
                        document.getElementById("<%=btnDuplicationCodeNextRecordsB.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenCodeDuplicateNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnDuplicationCodePrevious.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnDuplicationCodePreviousB.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnDuplicationCodePreviousB.ClientID%>").style.cursor = 'default';
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

            var Create = PageMethods.ServiceListToHtml(MismatchCode, NextId, Mode, TotalCount,0, function (response) {
                var MismatchCodeList = response;
                document.getElementById('cphMain_divMismatchCodeReport').innerHTML = MismatchCodeList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnMismatchCodePreviousB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMismatchCodePreviousB.ClientID%>").style.cursor = 'pointer';
                        }
                        else {
                            document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnMismatchCodeNextRecordsB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnMismatchCodeNextRecordsB.ClientID%>").style.cursor = 'pointer';
                        }

                            document.getElementById("<%=HiddenCodeMismatchNext.ClientID%>").value = MismatchCodeList[1];
                        if (Mode == '1') {

                            if (parseInt(document.getElementById("<%=HiddenCodeMismatchcount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCodeMismatchNext.ClientID%>").value)) {
                        document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").disabled = true;
                                document.getElementById("<%=btnMismatchCodeNextRecords.ClientID%>").style.cursor = 'default';
                                document.getElementById("<%=btnMismatchCodeNextRecordsB.ClientID%>").disabled = true;
                                document.getElementById("<%=btnMismatchCodeNextRecordsB.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenCodeMismatchNext.ClientID%>").value == '100') {
                        document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnMismatchCodePrevious.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnMismatchCodePreviousB.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnMismatchCodePreviousB.ClientID%>").style.cursor = 'default';
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

               var Create = PageMethods.ServiceListToHtml(MissingName, NextId, Mode, TotalCount,0, function (response) {
                   var MissingNameList = response;
                   document.getElementById('cphMain_divProductNameMissingReport').innerHTML = MissingNameList[0];
                   if (Mode == '1') {
                       document.getElementById("<%=btnNameMissingPrevious.ClientID%>").disabled = false;
                       document.getElementById("<%=btnNameMissingPrevious.ClientID%>").style.cursor = 'pointer';
                       document.getElementById("<%=btnNameMissingPreviousB.ClientID%>").disabled = false;
                       document.getElementById("<%=btnNameMissingPreviousB.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").disabled = false;
                       document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").style.cursor = 'pointer';
                       document.getElementById("<%=btnNameMissingNextRecordsB.ClientID%>").disabled = false;
                       document.getElementById("<%=btnNameMissingNextRecordsB.ClientID%>").style.cursor = 'pointer';
                }

                   document.getElementById("<%=HiddenNameMissingNext.ClientID%>").value = MissingNameList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenNameMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenNameMissingNext.ClientID%>").value)) {
                        document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnNameMissingNextRecords.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnNameMissingNextRecordsB.ClientID%>").disabled = true;
                        document.getElementById("<%=btnNameMissingNextRecordsB.ClientID%>").style.cursor = 'default';
                    }
                }
                else {
                    if (document.getElementById("<%=HiddenNameMissingNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnNameMissingPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNameMissingPrevious.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnNameMissingPreviousB.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNameMissingPreviousB.ClientID%>").style.cursor = 'default';
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
            var Create = PageMethods.ServiceListToHtml(DuplicateName, NextId, Mode, TotalCount,0, function (response) {
                var DuplicateNameList = response;
                document.getElementById('cphMain_divProductNameDuplicateReport').innerHTML = DuplicateNameList[0];
                if (Mode == '1') {
                   document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnNameDuplicatePreviousB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnNameDuplicatePreviousB.ClientID%>").style.cursor = 'pointer';
                        }
                        else {
                            document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnNameDuplicateNextRecordsB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnNameDuplicateNextRecordsB.ClientID%>").style.cursor = 'pointer';
                        }

                        document.getElementById("<%=HiddenNameDuplicateNext.ClientID%>").value = DuplicateNameList[1];
                        if (Mode == '1') {

                            if (parseInt(document.getElementById("<%=HiddenNameDuplicateCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenNameDuplicateNext.ClientID%>").value)) {
                        document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").disabled = true;
                                document.getElementById("<%=btnNameDuplicateNextRecords.ClientID%>").style.cursor = 'default';
                                document.getElementById("<%=btnNameDuplicateNextRecordsB.ClientID%>").disabled = true;
                                document.getElementById("<%=btnNameDuplicateNextRecordsB.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenNameDuplicateNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNameDuplicatePrevious.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnNameDuplicatePreviousB.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNameDuplicatePreviousB.ClientID%>").style.cursor = 'default';
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
            var Create = PageMethods.ServiceListToHtml(ExceedLength, NextId, Mode, TotalCount,0, function (response) {
                var ExceedLengthList = response;
                document.getElementById('cphMain_divExceedLengthReport').innerHTML = ExceedLengthList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnExceedLengthPreviousB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnExceedLengthPreviousB.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnExceedlengthNextRecordsB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnExceedlengthNextRecordsB.ClientID%>").style.cursor = 'pointer';
                }

                document.getElementById("<%=HiddenExceedLengthNext.ClientID%>").value = ExceedLengthList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenExceedLengthCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenExceedLengthNext.ClientID%>").value)) {
                                document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnExceedlengthNextRecords.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnExceedlengthNextRecordsB.ClientID%>").disabled = true;
                        document.getElementById("<%=btnExceedlengthNextRecordsB.ClientID%>").style.cursor = 'default';
                            }
                        }
                        else {

                            if (document.getElementById("<%=HiddenExceedLengthNext.ClientID%>").value == '100') {

                                document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").disabled = "disabled";
                                document.getElementById("<%=btnExceedLengthPrevious.ClientID%>").style.cursor = 'default';
                                document.getElementById("<%=btnExceedLengthPreviousB.ClientID%>").disabled = "disabled";
                                document.getElementById("<%=btnExceedLengthPreviousB.ClientID%>").style.cursor = 'default';
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
                    var Create = PageMethods.ServiceListToHtml(NewProducts, NextId, Mode, TotalCount,0, function (response) {
                        var NewProductsList = response;
                        document.getElementById('cphMain_divNewItemsReport').innerHTML = NewProductsList[0];
                        if (Mode == '1') {
                            document.getElementById("<%=btnNewItemsPrevious.ClientID%>").disabled = false;
                            document.getElementById("<%=btnNewItemsPrevious.ClientID%>").style.cursor = 'pointer';
                            document.getElementById("<%=btnNewItemsPreviousB.ClientID%>").disabled = false;
                            document.getElementById("<%=btnNewItemsPreviousB.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").disabled = false;
                            document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").style.cursor = 'pointer';
                            document.getElementById("<%=btnNewItemsNextRecordsB.ClientID%>").disabled = false;
                            document.getElementById("<%=btnNewItemsNextRecordsB.ClientID%>").style.cursor = 'pointer';
                }

                        document.getElementById("<%=HiddenNewProductsNext.ClientID%>").value = NewProductsList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenNewProductsCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenNewProductsNext.ClientID%>").value)) {
                        document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnNewItemsNextRecords.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnNewItemsNextRecordsB.ClientID%>").disabled = true;
                        document.getElementById("<%=btnNewItemsNextRecordsB.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenNewProductsNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnNewItemsPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNewItemsPrevious.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnNewItemsPreviousB.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnNewItemsPreviousB.ClientID%>").style.cursor = 'default';
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
            var Create = PageMethods.ServiceListToHtml(RateMissing, NextId, Mode, TotalCount,0, function (response) {
                var RateMissingList = response;
                document.getElementById('cphMain_divCostPriceMissingReport').innerHTML = RateMissingList[0];
                if (Mode == '1') {
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").disabled = false;
                    document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").style.cursor = 'pointer';
                        }
                        else {
                            document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").disabled = false;
                    document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.cursor = 'pointer';
                    document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").disabled = false;
                    document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").style.cursor = 'pointer';
                        }

                document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value = RateMissingList[1];
                        if (Mode == '1') {

                            if (parseInt(document.getElementById("<%=HiddenCostPriceMissingCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value)) {
                        document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").disabled = true;
                                document.getElementById("<%=btnCostPriceMissingNextRecords.ClientID%>").style.cursor = 'default';
                                document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").disabled = true;
                                document.getElementById("<%=btnCostPriceMissingNextRecordsB.ClientID%>").style.cursor = 'default';
                    }
                }
                else {

                    if (document.getElementById("<%=HiddenCostPriceMissingNext.ClientID%>").value == '100') {

                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnCostPriceMissingPrevious.ClientID%>").style.cursor = 'default';

                        document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").disabled = "disabled";
                        document.getElementById("<%=btnCostPriceMissingPreviousB.ClientID%>").style.cursor = 'default';
                    }
                }
                    })
            return false;
        }


        function RateAmendmentRecord(Mode) {
            var NextId = document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value;
                    var RateAmendment = document.getElementById("<%=HiddenRateAmendmentList.ClientID%>").value;
                    var TotalCount = document.getElementById("<%=HiddenRateUpdateCount.ClientID%>").value
                    if (Mode == '1')
                        var Mode = '1';
                    else
                        var Mode = '0';
                    var Create = PageMethods.ServiceListToHtml(RateAmendment, NextId, Mode, TotalCount,1, function (response) {
                        var RateAmendmentList = response;
                        document.getElementById('cphMain_divRateAmendmentReport').innerHTML = RateAmendmentList[0];
                        if (Mode == '1') {
                            document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").disabled = false;
                            document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").style.cursor = 'pointer';
                            document.getElementById("<%=btnRateAmendmentPreviousB.ClientID%>").disabled = false;
                            document.getElementById("<%=btnRateAmendmentPreviousB.ClientID%>").style.cursor = 'pointer';
                }
                else {
                    document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").disabled = false;
                            document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").style.cursor = 'pointer';
                            document.getElementById("<%=btnRateAmendmentNextRecordsB.ClientID%>").disabled = false;
                            document.getElementById("<%=btnRateAmendmentNextRecordsB.ClientID%>").style.cursor = 'pointer';
                }

                        document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value = RateAmendmentList[1];
                if (Mode == '1') {

                    if (parseInt(document.getElementById("<%=HiddenRateUpdateCount.ClientID%>").value) <= parseInt(document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value)) {
                                document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").disabled = true;
                        document.getElementById("<%=btnRateAmendmentNextRecords.ClientID%>").style.cursor = 'default';
                        document.getElementById("<%=btnRateAmendmentNextRecordsB.ClientID%>").disabled = true;
                        document.getElementById("<%=btnRateAmendmentNextRecordsB.ClientID%>").style.cursor = 'default';
                            }
                        }
                        else {

                            if (document.getElementById("<%=HiddenRateUpdateNext.ClientID%>").value == '100') {

                                document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").disabled = "disabled";
                                document.getElementById("<%=btnRateAmendmentPrevious.ClientID%>").style.cursor = 'default';
                                document.getElementById("<%=btnRateAmendmentPreviousB.ClientID%>").disabled = "disabled";
                                document.getElementById("<%=btnRateAmendmentPreviousB.ClientID%>").style.cursor = 'default';
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
            var WinPrint = window.open('../gen_Product_Rate_Amendment/Report.html', 'PrdctnDtlReportPrint', 'menubar=1,resizable=1,scrollbars=1,width=900,height=650,top=100,left=210');
            WinPrint.focus();
        }
        function reportCrntNew() {
            var WinPrint = window.open('../gen_Product_Rate_Amendment/Report_MisMatchCrrntNew.html', 'PrdctnDtlReport', 'menubar=1,resizable=1,scrollbars=1,width=900,height=650,top=100,left=210');
            WinPrint.focus();
        }
        function ConfirmMessage() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to cancel the rate amendment process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "gen_Product_Rate_Amendment.aspx";
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
       </asp:ScriptManager>
         <ol class="breadcrumb">
     <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
    <li class="active">Product Rate Amendment</li>
  </ol>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
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
     <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr">
         <div id="divLoading" class="model" style="display:none;"  >
            <div class="eachform" style="width:12%; height:55%; padding-left:42%; padding-top:10%;">
                 <img src="../../Images/Other Images/LoadingMail.gif" style="width:75%" />
                 </div>
         </div>

          <div id="divRateUpdate" class="pro_rt1">
              <h2>Product Rate Amendment</h2>
              <div class="form-group fg2 sa_fg3 sa_640">
                  <label for="email" class="fg2_la1 pad_l">Choose File: <span class="spn1">&nbsp;</span></label>
                  <asp:FileUpload ID="FileUploader" class="imageUpload" onchange="FupSelectedFileName()" runat="server" Accept=".csv" Style="display: none;" />
                  <label id="lblFileUpload" tabindex="0" for="cphMain_FileUploader" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i>Import data from CSV file</label>
                  <div id="Label1" class="file_n" runat="server"></div>
              </div>


              <div class="fg5 sa_fg3 sa_640">
                  <label class="form1 mar_bo mar_tp">
                      <span class="button-checkbox">
                          <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
                          <input type="checkbox" class="hidden" id="cbxImprtHasHeader" runat="server" onkeypress=" return DisableEnter(event);" />
                      </span>
                      <p class="pz_s">My Data has Headers</p>
                  </label>
              </div>

              <div class="fg5 fg2_adn pull-right">
                  <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                  <a class="btn tab_but1 butn5" style="padding-top:5px;" href="/CustomFiles/csvTemplate/ProductRateAmendmentSample.csv"><i class="fa fa-download"></i>Download CSV Template</a>
              </div>

              <div class="clearfix"></div>
              <div class="devider"></div>

              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnAdd" runat="server" class="btn sub1 bt_pro_rt2" Text="Proceed" OnClick="btnAdd_Click" OnClientClick="return FileValidate();" />
                      <asp:Button ID="btnCancel" runat="server" class="btn sub4 bt_pro_rt1" Text="Cancel" PostBackUrl="gen_Product_Rate_Amendment.aspx" />
                  </div>
              </div>
          </div>




          <div id="divMissingCode" class="pro_rt3" style="display: none;">
              <h2>Product Code Missing</h2>
              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnCodeMissingBack" runat="server" class="btn sub3 cl_div_b" Text="<< Back" OnClientClick="return BackFromCodeMissing();" />
                      <asp:Button ID="btnCodeMissingCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                      <asp:Button ID="btnCodeMissingNext" runat="server" class="btn sub3 cl_div_n" Text="Next >>" OnClientClick="return ViewDuplication();" />

                  </div>
              </div>
              <p>
                  <li><i class="fa fa-arrow-circle-right"></i>Product code(s) has not been specified for the following records in uploaded file.These records will be excluded while importing.Use "Next" button to continue.</li>
              </p>
              <div class="clearfix"></div>
              <div class="devider"></div>

              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnMissingCodePrevious" class="btn sub3 cl_div_b" runat="server" Text="Show Previous 100 Records" disabled="disabled" OnClientClick="return MissingCodeRecord(0);" />
                      <asp:Button ID="btnMissingCodeNextRecords" class="btn sub3 cl_div_n" runat="server" Text="Show Next 100 Records" OnClientClick="return MissingCodeRecord(1);" />
                  </div>
              </div>
              <div id="divMissingCodeReport" class="r_640" runat="server">
              </div>
               <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnMissingCodePreviousB" class="btn sub3 cl_div_b" runat="server" Text="Show Previous 100 Records" disabled="disabled" OnClientClick="return MissingCodeRecord(0);" />
                      <asp:Button ID="btnMissingCodeNextRecordsB" class="btn sub3 cl_div_n" runat="server" Text="Show Next 100 Records" OnClientClick="return MissingCodeRecord(1);" />
                  </div>
              </div>
              <div class="clearfix"></div>
              <div class="free_sp"></div>
              <div class="devider"></div>

              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnCodeMissingBackB" runat="server" class="btn sub3 cl_div_b" Text="<< Back" OnClientClick="return BackFromCodeMissing();" />
                      <asp:Button ID="btnCodeMissingCancelB" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                      <asp:Button ID="btnCodeMissingNextB" runat="server" class="btn sub3 cl_div_n" Text="Next >>" OnClientClick="return ViewDuplication();" />
                  </div>
              </div>
          </div>


          <div id="divDuplicateCode" class="pro_rt3" style="display: none;">

              <h2 id="a2">Product Code Duplicate</h2>
              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnCodeDuplicationBack" runat="server" class="btn sub3 cl_div_b" Text="<< Back" OnClientClick="return BackFromCodeDuplication();" />
                      <asp:Button ID="btnCodeDuplicationCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                      <asp:Button ID="btnCodeDuplicationNext" runat="server" class="btn sub3 cl_div_n" Text="Next >>" OnClientClick="return ViewMismatch();" />
                  </div>
              </div>

              <p>
                  <li><i class="fa fa-arrow-circle-right"></i>Product code(s) has been duplicated for the following records in uploaded file.These records will be excluded while importing.Use "Next" button to continue.</li>
              </p>
              <div class="clearfix"></div>
              <div class="devider"></div>
              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnDuplicationCodePrevious" disabled="disabled" runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records" OnClientClick="return DuplicateCodeRecord(0);" />
                      <asp:Button ID="btnDuplicationCodeNextRecords" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records" OnClientClick="return DuplicateCodeRecord(1);" />
                  </div>
              </div>
              <div id="divDuplicationCodeReport" class="r_640" runat="server">
              </div>
               <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnDuplicationCodePreviousB" disabled="disabled" runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records" OnClientClick="return DuplicateCodeRecord(0);" />
                      <asp:Button ID="btnDuplicationCodeNextRecordsB" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records" OnClientClick="return DuplicateCodeRecord(1);" />
                  </div>
              </div>
              <div class="clearfix"></div>
              <div class="free_sp"></div>
              <div class="devider"></div>

              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnCodeDuplicationBackB" runat="server" class="btn sub3 cl_div_b" Text="<< Back" OnClientClick="return BackFromCodeDuplication();" />
                      <asp:Button ID="btnCodeDuplicationCancelB" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                      <asp:Button ID="btnCodeDuplicationNextB" runat="server" class="btn sub3 cl_div_n" Text="Next >>" OnClientClick="return ViewMismatch();" />
                  </div>
              </div>
          </div>





          <div id="divMismatchCode"  class="pro_rt2" style="display:none;">        
            <h2 id="a3" >New Product Confirmation</h2>
                  <div class="sub_cont pull-right">
          <div class="save_sec">                   
                 <asp:Button ID="btnCodeMismatchBack" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromItemCreation();" />                                                                           
                 <asp:Button ID="btnCodeMismatchCreate" runat="server" class="btn sub1 cl_div" Text="Create"  OnClientClick="return ViewDivisionDetails();" />                      
                <asp:Button ID="btnCodeMismatchcancel" runat="server" class="btn sub4" Text="Cancel"   OnClientClick="return ConfirmMessage();" />                
                <asp:Button ID="btnCodeMismatchNext" runat="server" class="btn sub3 cl_div_n" Text="Next >>" OnClientClick="return JumpToItemCreate();" />       
                <asp:Button ID="btnCodeMismatchClose" runat="server" class="cancel" Text="Close" style="display:none"  />            
                </div>
            </div>
               <p id="h2CreateProducts"><li><i class="fa fa-arrow-circle-right"></i> Product code(s) for the following records are not found in product master.</li>
          <li><i class="fa fa-arrow-circle-right"></i> Select a corporate division and use SAVE button to creative new product or select "Next" button to exclude these records.</li>
        </p>

        <div class="clearfix"></div>
              <div id="divDivision" class="box_rgt_dv flt_r" style="display:none;">
                   <div class="form-group fg6 sa_fg4 flt_r" id="divDiv">
            <label for="email" class="fg2_la1 flt_r" style="width: 90%;">Division:<span class="spn1"></span></label>
                        <asp:DropDownList ID="ddlDivision" class="form-control fg2_inp1 flt_r" runat="server"></asp:DropDownList>
          </div>
          <div class="clearfix"></div>
               
                   <div class="sub_cont pull-right">
          <div class="save_sec flt_r">
                <asp:Button ID="btnNewItemCreate" runat="server" class="btn sub1" Text="Save"  OnClientClick="return Validation_Item_Creation();"/>                   
                      <asp:Button ID="btnNewItemCreateClose" runat="server" class="btn sub4" Text="Close"   OnClientClick="return CloseCreateItem();" />                            
                   </div>
            </div>
 </div>
                   <div class="clearfix"></div>
        <div class="devider"></div>
             <div class="sub_cont pull-right">
          <div class="save_sec"> 
                    <asp:Button ID="btnMismatchCodePrevious"  disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return MismatchCodeRecord(0);" />
                    <asp:Button ID="btnMismatchCodeNextRecords" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return MismatchCodeRecord(1);"  />
              </div>
                  </div>
              <div id="divMismatchCodeReport" class="r_640" runat="server" >
        </div>  
              <div class="sub_cont pull-right">
          <div class="save_sec"> 
                    <asp:Button ID="btnMismatchCodePreviousB"  disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return MismatchCodeRecord(0);" />
                    <asp:Button ID="btnMismatchCodeNextRecordsB" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return MismatchCodeRecord(1);"  />
              </div>
                  </div>   
<div class="clearfix"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
            <asp:Button ID="btnCodeMismatchBackB" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromItemCreation();" />                                                                           
                 <asp:Button ID="btnCodeMismatchCreateB" runat="server" class="btn sub1 cl_div" Text="Create"  OnClientClick="return ViewDivisionDetails();" />                      
                <asp:Button ID="btnCodeMismatchcancelB" runat="server" class="btn sub4" Text="Cancel"   OnClientClick="return ConfirmMessage();" />                
                <asp:Button ID="btnCodeMismatchNextB" runat="server" class="btn sub3 cl_div_n" Text="Next >>" OnClientClick="return JumpToItemCreate();" />       
                <asp:Button ID="btnCodeMismatchCloseB" runat="server" class="cancel" Text="Close" style="display:none"  />   
          </div>
        </div>

        </div>







                <div id="divProductNameMissing"  class="pro_rt3" style=" display:none;">                    
            <h2 id="a4" >Product Name Missing</h2>
               <div class="sub_cont pull-right">
          <div class="save_sec">        
                <asp:Button ID="btnProductNameMissingBack" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromNameMissing();" />                                                    
                    <asp:Button ID="btnProductNameMissingCreate" runat="server" class="btn sub1 cl_div" Text="Create" OnClientClick="return ViewProductNameDuplicate();" />                                 
                    <asp:Button ID="btnProductNameMissingCancel" runat="server" class="btn sub4" Text="Cancel"  OnClientClick="return ConfirmMessage();" />                                    
                  
                </div>
            </div>
             <p><li><i class="fa fa-arrow-circle-right"></i>Product Name(s) has not been specified for the following records in uploaded file.These records will be excluded while creating new products.Use "Create" button to continue.</li></p>

                     <div class="clearfix"></div>
              <div class="devider"></div>
              <div class="sub_cont pull-right">
                  <div class="save_sec">
                    <asp:Button ID="btnNameMissingPrevious"   disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records" OnClientClick="return MissingNameRecord(0);" />
                    <asp:Button ID="btnNameMissingNextRecords"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return MissingNameRecord(1);" />
              </div>
                   </div>
              <div id="divProductNameMissingReport" class="r_640" runat="server" >
        </div>    
                     <div class="sub_cont pull-right">
                  <div class="save_sec">
                    <asp:Button ID="btnNameMissingPreviousB"   disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records" OnClientClick="return MissingNameRecord(0);" />
                    <asp:Button ID="btnNameMissingNextRecordsB"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return MissingNameRecord(1);" />
              </div>
                   </div>
                     <div class="clearfix"></div>
              <div class="free_sp"></div>
              <div class="devider"></div>

              <div class="sub_cont pull-right">
                  <div class="save_sec">
                      <asp:Button ID="btnProductNameMissingBackB" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromNameMissing();" />                                                    
                    <asp:Button ID="btnProductNameMissingCreateB" runat="server" class="btn sub1 cl_div" Text="Create" OnClientClick="return ViewProductNameDuplicate();" />                                 
                    <asp:Button ID="btnProductNameMissingCancelB" runat="server" class="btn sub4" Text="Cancel"  OnClientClick="return ConfirmMessage();" />     
                  </div>
              </div>        
        </div>





                        <div id="divProductNameDuplicate" class="pro_rt3" style="display:none;">        
            
            <h2 id="a5" >Product Name Duplicate</h2>
           <div class="sub_cont pull-right">
          <div class="save_sec">
                <asp:Button ID="btnRateMissingBack" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromNameDuplicate();" />                                                                
                     <asp:Button ID="btnProductNameDuplicateCreate" runat="server" class="btn sub1 cl_div" Text="Create" OnClientClick="return ViewExceedLength();"/>
                     <asp:Button ID="btnProductNameDuplicateCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />                 
                  
                </div>
            </div>
              <p><li><i class="fa fa-arrow-circle-right"></i>Product Name(s) has been duplicated for the following records in uploaded file.These records will be excluded while creating new products.Use "Create" button to continue.</li></p>

                            <div class="clearfix"></div>
              <div class="devider"></div>
              <div class="sub_cont pull-right">
                  <div class="save_sec">
                    <asp:Button ID="btnNameDuplicatePrevious"   disabled="disabled" runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return DuplicateNameRecord(0);" />
                    <asp:Button ID="btnNameDuplicateNextRecords" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return DuplicateNameRecord(1);"/>
              </div>
                   </div>
              <div id="divProductNameDuplicateReport" class="r_640" runat="server">
        </div>
                             <div class="sub_cont pull-right">
                  <div class="save_sec">
                    <asp:Button ID="btnNameDuplicatePreviousB"   disabled="disabled" runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return DuplicateNameRecord(0);" />
                    <asp:Button ID="btnNameDuplicateNextRecordsB" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return DuplicateNameRecord(1);"/>
              </div>
                   </div>
  <div class="clearfix"></div>
              <div class="free_sp"></div>
              <div class="devider"></div>

              <div class="sub_cont pull-right">
                  <div class="save_sec">
                        <asp:Button ID="btnRateMissingBackB" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromNameDuplicate();" />                                                                
                     <asp:Button ID="btnProductNameDuplicateCreateB" runat="server" class="btn sub1 cl_div" Text="Create" OnClientClick="return ViewExceedLength();"/>
                     <asp:Button ID="btnProductNameDuplicateCancelB" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />    
                  </div>
              </div>    
        </div>





        <div id="divExceedLengthProduct" class="pro_rt3" style=" display:none;">                   
            <h2 id="a9" >Exceed Length Records</h2>
           <div class="sub_cont pull-right">
          <div class="save_sec">         
               <asp:Button ID="btnExceedLengthBack" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromExceedLength();" />                                                   
                     <asp:Button ID="btnExceedLengthCreate" runat="server" class="btn sub1 cl_div" Text="Create" OnClientClick="return CreateItems();"/>
                     <asp:Button ID="btnExceedLengthCancel" runat="server" class="btn sub4" Text="Cancel"  OnClientClick="return ConfirmMessage();" />                 
                   
               </div>
            </div>
              <p><li><i class="fa fa-arrow-circle-right"></i>Any of the field(s) are exceeds its length in the following records in uploaded file.These records will be excluded while creating new products.Use "Create" button to continue.</li></p>
            <div class="clearfix"></div>
              <div class="devider"></div>
              <div class="sub_cont pull-right">
                  <div class="save_sec">
                    <asp:Button ID="btnExceedLengthPrevious" disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return ExceedLengthRecord(0);"/>
                    <asp:Button ID="btnExceedlengthNextRecords"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return ExceedLengthRecord(1);"/>
              </div>
                   </div>
              <div id="divExceedLengthReport" class="r_640" runat="server" >
        </div>
             <div class="sub_cont pull-right">
                  <div class="save_sec">
                    <asp:Button ID="btnExceedLengthPreviousB" disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return ExceedLengthRecord(0);"/>
                    <asp:Button ID="btnExceedlengthNextRecordsB"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return ExceedLengthRecord(1);"/>
              </div>
                   </div>
             <div class="clearfix"></div>
              <div class="free_sp"></div>
              <div class="devider"></div>

              <div class="sub_cont pull-right">
                  <div class="save_sec">
                       <asp:Button ID="btnExceedLengthBackB" runat="server" class="btn sub3 cl_div_b" Text="<< Back"  OnClientClick="return BackFromExceedLength();" />                                                   
                     <asp:Button ID="btnExceedLengthCreateB" runat="server" class="btn sub1 cl_div" Text="Create" OnClientClick="return CreateItems();"/>
                     <asp:Button ID="btnExceedLengthCancelB" runat="server" class="btn sub4" Text="Cancel"  OnClientClick="return ConfirmMessage();" />       
                  </div>
              </div>  
        </div>



        <div id="divItemCreate" class="pro_rt6" style="display:none;">        
             <h2>New Product List</h2>
               <div class="sub_cont pull-right">
          <div class="save_sec">           
                    <asp:Button ID="btnNewItemUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return ViewRateMissing();"/>                             
                    <asp:Button ID="btnNewItemCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />                                      
                </div>
            </div>
                <p ><li id="h2ItemCreate"><i class="fa fa-arrow-circle-right"></i> Following products are created successfully.Use "Update" button to continue with product rate amendment.</li>
        </p>
            <p  ><li id="h2NoItemCreate" style="display:none;"><i class="fa fa-arrow-circle-right"></i> No new products were created.Use "Update" button to continue with product rate amendment.</li>
        </p>
        <div class="clearfix"></div>
        <div class="devider"></div>

           
          <div class="sub_cont pull-right">
          <div class="save_sec"> 
                    <asp:Button ID="btnNewItemsPrevious" disabled="disabled"   runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return NewProductsRecord(0);" />
                    <asp:Button ID="btnNewItemsNextRecords"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return NewProductsRecord(1);"/>
              </div>
                </div>
              <div id="divNewItemsReport" class="r_640" runat="server" >
        </div>      
              <div class="sub_cont pull-right">
          <div class="save_sec"> 
                    <asp:Button ID="btnNewItemsPreviousB" disabled="disabled"   runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return NewProductsRecord(0);" />
                    <asp:Button ID="btnNewItemsNextRecordsB"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return NewProductsRecord(1);"/>
              </div>
                </div>
             <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
           <asp:Button ID="btnNewItemUpdateB" runat="server" class="btn sub1" Text="Update" OnClientClick="return ViewRateMissing();"/>                             
           <asp:Button ID="btnNewItemCancelB" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" /> 
          </div>
        </div>      
        </div>





        <div id="divRateMissing" class="pro_rt3" style="display:none;">        
             <h2>Invalid Cost Price</h2>
              <div class="sub_cont pull-right">
          <div class="save_sec">                                    
                    <asp:Button ID="btnRateMissingUpdate" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click"/>  
                    <asp:Button ID="btnRateMissingCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />                                
                </div>
            </div>
             <p ><li id="h2CostPriceError"><i class="fa fa-arrow-circle-right"></i> Cost Price(s) has not been specified/not valid in the following records in uploaded file.These records will be excluded while importing.Use "Update" button to continue with product rate Amendment.</li>
        </p>
             <p ><li id="h2CostPriceNoError" style="display:none;"><i class="fa fa-arrow-circle-right"></i> Cost Price(s) has been specified in uploaded file were correct.Use "Update" button to continue with product rate Amendment.</li>
        </p>
        <div class="clearfix"></div>
        <div class="devider"></div>

             <div class="sub_cont pull-right">
          <div class="save_sec"> 
                    <asp:Button ID="btnCostPriceMissingPrevious" disabled="disabled"   runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return RateMissingRecord(0);"/>
                    <asp:Button ID="btnCostPriceMissingNextRecords" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return RateMissingRecord(1);" />
              </div>
                 </div>
              <div id="divCostPriceMissingReport" class="r_640" runat="server">
        </div>
              <div class="sub_cont pull-right">
          <div class="save_sec"> 
                    <asp:Button ID="btnCostPriceMissingPreviousB" disabled="disabled"   runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return RateMissingRecord(0);"/>
                    <asp:Button ID="btnCostPriceMissingNextRecordsB" runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return RateMissingRecord(1);" />
              </div>
                 </div>
             <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
            <asp:Button ID="btnRateMissingUpdateB" runat="server" class="btn sub1" Text="Update" OnClick="btnUpdate_Click"/>  
                    <asp:Button ID="btnRateMissingCancelB" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" /> 
          </div>
        </div>
        </div>





        <div id="divRateAmendmentList" class="pro_rt4" style="display:none;">        
              <h2>Product Rate Amendment List</h2>
            <div class="sub_cont pull-right">
          <div class="save_sec">                                       
                    <asp:Button ID="btnRateAmendmentClose" runat="server" class="btn sub1" Text="Close" />               
                </div>
        </div>
            <p><li><i class="fa fa-arrow-circle-right"></i> These products are updated successfully.</li>
        </p>
        <div class="clearfix"></div>
        <div class="devider"></div>

                    <div class="sub_cont pull-right">
          <div class="save_sec">
                    <asp:Button ID="btnRateAmendmentPrevious" disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return RateAmendmentRecord(0);"/>
                    <asp:Button ID="btnRateAmendmentNextRecords"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return RateAmendmentRecord(1);"/>
              </div>
                          </div>
              <div id="divRateAmendmentReport" class="r_640" runat="server" >
        </div>  
            
                    <div class="sub_cont pull-right">
          <div class="save_sec">
                    <asp:Button ID="btnRateAmendmentPreviousB" disabled="disabled"  runat="server" class="btn sub3 cl_div_b" Text="Show Previous 100 Records"  OnClientClick="return RateAmendmentRecord(0);"/>
                    <asp:Button ID="btnRateAmendmentNextRecordsB"  runat="server" class="btn sub3 cl_div_n" Text="Show Next 100 Records"  OnClientClick="return RateAmendmentRecord(1);"/>
              </div>
                          </div>  
             <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
          <asp:Button ID="btnRateAmendmentCloseB" runat="server" class="btn sub1" Text="Close" />  
          </div>
        </div>         
        </div>



           </div>
       </div>
      </div>
    <style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
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
</asp:Content>

