<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Projects.aspx.cs" Inherits="Master_gen_Projects_gen_Projects" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/hcm_ns.css" rel="stylesheet" />
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
     <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
                $au('#cphMain_ddlProjectManager').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingEmployee').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();
                $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
        });
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
        });
    </script>
      <script type="text/javascript">
          function PassSavedProjectToLead(intProjectId) {
              if (window.opener != null && !window.opener.closed) {
                  var txtName = window.opener.document.getElementById("cphMain_txtProject");
                  txtName.value = document.getElementById("<%=txtProjectName.ClientID%>").value;
                  window.opener.GetValueFromChildProject(intProjectId);
             }
             window.close();
          }
          function PassSavedProjectToRFG(intProjectId)
          {      
              if (window.opener != null && !window.opener.closed) {                
                  window.opener.GetValueFromChildProject(intProjectId);
              }           
              window.close();
          }
          function PassSavedProjectToPRCHS(PrjctId, PrjctName) {
              if (window.opener != null && !window.opener.closed) {
                  window.opener.GetValueFromChildProject(PrjctId, PrjctName);
              }
              window.close();
          }        
</script>
    <script language="javascript" type="text/javascript">
        var submit = 0;
        function CheckIsRepeat() {
            if (++submit > 1) {
                // alert('An attempt was made to submit this form more than once; this extra attempt will be ignored.');
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
        //start-0006
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }
        function ConfirmMessage() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_ProjectsList.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_ProjectsList.aspx";

            }
            return false;
        }
        function AlertClearAll() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to clear all the data from this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "gen_Projects.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "gen_Projects.aspx";
                return false;
            }
            return false;
        }
    </script>
    <script type="text/javascript">

        function DuplicationInternalRefNum() {
            $("#divWarning").html("Duplication error!. Internal ref# can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtInternalRefNum.ClientID%>").style.borderColor = "Red";
        }

        function DuplicationName() {
            $("#divWarning").html("Duplication error!. Project name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=txtProjectName.ClientID%>").style.borderColor = "Red";
        }

        function SuccessConfirmation() {
            $("#success-alert").html("Project details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Project details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function NameValidate() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtProjectName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtProjectName.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtContactMail.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtContactMail.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtContactPhone.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtContactPhone.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtTenderRFQ.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTenderRFQ.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtClientRefNUm.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtClientRefNUm.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtEmployeeName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtEmployeeName.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtInternalRefNum.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtInternalRefNum.ClientID%>").value = replaceText2; 

            document.getElementById("<%=txtProjectName.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
            $au("div#divDivs input.ui-autocomplete-input").css("borderColor", "");
            $au("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");
            $au("div#divProjectManager input.ui-autocomplete-input").css("borderColor", "");
            document.getElementById("<%=txtClientRefNUm.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtInternalRefNum.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTenderRFQ.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtContactPhone.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtContactMail.ClientID%>").style.borderColor = "";

            var Name = document.getElementById("<%=txtProjectName.ClientID%>").value.trim();
            var TenderRef = document.getElementById("<%=txtTenderRFQ.ClientID%>").value.trim();
            var InterRef = document.getElementById("<%=txtInternalRefNum.ClientID%>").value.trim();
            var ClientRef = document.getElementById("<%=txtClientRefNUm.ClientID%>").value.trim();

            var Divddl = document.getElementById("<%=ddlDivision.ClientID%>");
            var DivText = Divddl.options[Divddl.selectedIndex].text;

            var Custddl = document.getElementById("<%=ddlExistingCustomer.ClientID%>");
            var CustText = Custddl.options[Custddl.selectedIndex].text;

            var Empddl = document.getElementById("<%=ddlExistingEmployee.ClientID%>");
            var EmpText = Empddl.options[Empddl.selectedIndex].text;

            var Mngrddl = document.getElementById("<%=ddlProjectManager.ClientID%>");
            var MngrText = Mngrddl.options[Mngrddl.selectedIndex].text;

            var MobileNum = document.getElementById("<%=txtContactPhone.ClientID%>").value;
            var ContactEmail = document.getElementById("<%=txtContactMail.ClientID%>").value;
            var ddlWarehouse = document.getElementById("<%=ddlWarehouse.ClientID%>").value;

            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

          
            if (document.getElementById("<%=cbxAwarded.ClientID%>").checked == true) {

                if (InterRef == "") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtInternalRefNum.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtInternalRefNum.ClientID%>").focus();
                    ret = false;

                }
                if (MngrText == "--SELECT EMPLOYEE--") {
                   
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $au("div#divProjectManager input.ui-autocomplete-input").css("borderColor", "Red");
                    $au("div#divProjectManager input.ui-autocomplete-input").focus();
                    $au("div#divProjectManager input.ui-autocomplete-input").select();
                    ret = false;

                }
            }
            else {
                if (TenderRef == "") {
               
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtTenderRFQ.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTenderRFQ.ClientID%>").focus();
                    ret = false;

                }
            }
            if (MobileNum != "") {
                if (!mobileregular.test(MobileNum)) {
                    $("#divWarning").html("Please enter a valid mobile number.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtContactPhone.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtContactPhone.ClientID%>").focus();
                    ret = false;
                }
            }
            if (ContactEmail != "") {
                if (!filter.test(ContactEmail)) {
                    $("#divWarning").html("Please enter a valid email address.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=txtContactMail.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtContactMail.ClientID%>").focus();
                    ret = false;
                    }
                }
            if (DivText == "--SELECT DIVISION--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlDivision.ClientID%>").focus();
                $au("div#divDivs input.ui-autocomplete-input").css("borderColor", "Red");
                $au("div#divDivs input.ui-autocomplete-input").focus();
                $au("div#divDivs input.ui-autocomplete-input").select();
                ret = false;

            }

     
                if (CustText == "--SELECT CUSTOMER--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    $au("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "Red");
                    $au("div#divExistingCust input.ui-autocomplete-input").focus();
                    $au("div#divExistingCust input.ui-autocomplete-input").select();
                    ret = false;

                }


            if (Name == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtProjectName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtProjectName.ClientID%>").focus();
                ret = false;

            }
            if (ret == false) {
                CheckSubmitZero();
            }
            else {
                document.getElementById("<%=hiddenWarehouseIds.ClientID%>").value = $('#cphMain_ddlWarehouse').val();
                if (document.getElementById("<%=hiddenWarehouseIds.ClientID%>").value != "") {
                    document.getElementById("<%=hiddenSelctdPrimaryWrhs.ClientID%>").value = $('#cphMain_ddlPrimaryWrhs :selected').val();
                }
            }

            return ret;
        }

        $(document).ready(function () {

           

        });

        function PrimaryWarehouseLoad() {

            var temp = new Array();
            var sel = "";

            $("#cphMain_ddlWarehouse option:selected").each(function () {
                var $this = $(this);
                if ($this.length) {
                    var selText = $this.text();
                    var selVal = $this.val();
                    sel = sel + selVal + "¦" + selText + ",";
                }
            });

            var temp = sel.split(',');

            $("#cphMain_ddlPrimaryWrhs").empty();
            for (a in temp) {

                if (temp[a] != "") {
                    var tempNew = temp[a].split('¦');
                    var OptionVal = tempNew[0];
                    var OptionText = tempNew[1];

                    var o = new Option(OptionText, OptionVal);
                    $(o).html(OptionText);
                    $("#cphMain_ddlPrimaryWrhs").append(o);
                }
            }

        }
    </script>
    <script>


        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("divNewCust").style.display = "none";
            document.getElementById("divNewEmp").style.display = "none";

            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value != "view") {

                if (document.getElementById("<%=cbxAwarded.ClientID%>").checked == true) {

                    $au("div#divProjectManager input.ui-autocomplete-input").prop("disabled", false);
                    document.getElementById("<%=txtClientRefNUm.ClientID%>").disabled = false;
                    document.getElementById("<%=ddlProjectManager.ClientID%>").disabled = false;
                    document.getElementById("<%=txtInternalRefNum.ClientID%>").disabled = false;
                    document.getElementById("<%=txtTenderRFQ.ClientID%>").disabled = true;
                }
                else {
                    $au("div#divProjectManager input.ui-autocomplete-input").prop("disabled", true);
                    document.getElementById("<%=txtClientRefNUm.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlProjectManager.ClientID%>").disabled = true;
                    document.getElementById("<%=txtInternalRefNum.ClientID%>").disabled = true;
                    document.getElementById("<%=txtTenderRFQ.ClientID%>").disabled = false;
                }
            }
            else {
                document.getElementById("<%=btnNewCust.ClientID%>").style.pointerEvents = "none";
            }

            if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {
                document.getElementById("divExistingEmp").style.display = "none";
                document.getElementById("divNewEmp").style.display = "";


            }
            else {
                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";

            }

            if (document.getElementById("<%=hiddenPMSDisplaySts.ClientID%>").value == "1") {
                document.getElementById("divWarehouse").style.display = "block";
            }
            else {
                document.getElementById("divWarehouse").style.display = "none";
            }


        });



        function CustomerFocus() {
            var DropDownCustomer = document.getElementById("<%=ddlExistingCustomer.ClientID%>");
            var DropDownCustomerValue = DropDownCustomer.value;
            document.getElementById("<%=HiddenCustomerFocus.ClientID%>").value = DropDownCustomerValue;
        }
        function CustomerLoad() {
            var $noC = jQuery.noConflict();
            var DropDownCustomer = document.getElementById("<%=ddlExistingCustomer.ClientID%>");
            var DropDownCustomerValue = DropDownCustomer.value;
            var FocusCustomerValue = document.getElementById("<%=HiddenCustomerFocus.ClientID%>").value
            if (DropDownCustomerValue != FocusCustomerValue) {
                document.getElementById("<%=ddlExistingCustomer.ClientID%>").style.borderColor = "";
                $noC("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");
                return false;
            }
        }

    </script>
    <script type="text/javascript">


        function NewCustPageLoad(obj) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to add new customer?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var CustNme = '';

                    if (obj == "ddlExistingCustomer") {

                        CustNme = ''
                    }
                    var nWindow = window.open('/Master/gen_Customer_Master/gen_Customer_Master.aspx?CFAM=' + CustNme + '', 'PoP_Up', 'width=1200,height=630,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                    nWindow.focus();
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }


        function CloseWindow() {
            window.close();
        }

        function PostbackFun(myVal) {
            document.getElementById("<%=hiddenNewCustId.ClientID%>").value = myVal;
            __doPostBack("<%=btnNewCustS.UniqueID %>", "");
            return false;
        }

        function GetValueFromChild(myVal) {

            if (myVal != '') {

                // alert(myVal);
                PostbackFun(myVal);
                //     alert(myVal);
            }
        }

       
            function CbxChangeEmploye() {
                if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

                IncrmntConfrmCounter();
                document.getElementById("divExistingEmp").style.display = "none";
                document.getElementById("divNewEmp").style.display = "";
                document.getElementById("<%=txtContactMail.ClientID%>").value = "";
                    document.getElementById("<%=txtContactPhone.ClientID%>").value = "";

            }
            else {
                IncrmntConfrmCounter();
                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";
                document.getElementById("<%=ddlExistingEmployee.ClientID%>").value = "--SELECT EMPLOYEE--";
           }

           return false;
       }
        function UpdatePanelCustomerLoad(strCustId) {

           document.getElementById("<%=hiddenNewCustId.ClientID%>").value = "";

            CheckSubmitZero();
          

            $au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();

            document.getElementById("<%=ddlExistingCustomer.ClientID%>").style.borderColor = "";
            $au("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("<%=ddlExistingCustomer.ClientID%>").value = strCustId;
            var a = $au("#cphMain_ddlExistingCustomer option:selected").text();

            $au("div#divExistingCust input.ui-autocomplete-input").val(a);

            document.getElementById("<%=ddlExistingCustomer.ClientID%>").focus();
                $au("#cphMain_ddlExistingCustomer").select();
            }

        //document.getElementById("<%=ddlExistingEmployee.ClientID%>").value = "--SELECT EMPLOYEE--";
        function DivAwardedVisibility() {
            IncrmntConfrmCounter();
            if (document.getElementById("<%=cbxAwarded.ClientID%>").checked == true) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to make the project awarded?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $au("div#divProjectManager input.ui-autocomplete-input").prop("disabled", false);

                        document.getElementById("<%=txtClientRefNUm.ClientID%>").disabled = false;
                        document.getElementById("<%=ddlProjectManager.ClientID%>").disabled = false;
                        document.getElementById("<%=txtInternalRefNum.ClientID%>").disabled = false;
                        document.getElementById("<%=txtTenderRFQ.ClientID%>").value = "";
                        document.getElementById("<%=txtTenderRFQ.ClientID%>").disabled = true;

                        return false;
                    }
                    else {
                        document.getElementById("<%=cbxAwarded.ClientID%>").checked = true;
                        return false;
                    }
                });
            }
            else {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to continue?.The data in the section may get cleared",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $au("div#divProjectManager input.ui-autocomplete-input").val("--SELECT EMPLOYEE--");
                        document.getElementById("<%=ddlProjectManager.ClientID%>").value = "--SELECT EMPLOYEE--";
                       document.getElementById("<%=txtClientRefNUm.ClientID%>").value = "";
                        document.getElementById("<%=txtInternalRefNum.ClientID%>").value = "";
                        $au("div#divProjectManager input.ui-autocomplete-input").prop("disabled", true);
                        document.getElementById("<%=txtClientRefNUm.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlProjectManager.ClientID%>").disabled = true;
                        document.getElementById("<%=txtInternalRefNum.ClientID%>").disabled = true;
                        document.getElementById("<%=txtTenderRFQ.ClientID%>").disabled = false;

                        $au("div#divProjectManager input.ui-autocomplete-input").css("borderColor", "");
                        document.getElementById("<%=txtInternalRefNum.ClientID%>").style.borderColor = "";

                        return false;
                    }
                    else {
                        document.getElementById("<%=cbxAwarded.ClientID%>").checked = true;
                        return false;
                    }
                });
            }
            return false;
        }
        function AutoCompleteEmp()
        {
            document.getElementById("divNewEmp").style.display = "none";
            document.getElementById("divExistingEmp").style.display = "";
            $au('#cphMain_ddlExistingEmployee').selectToAutocomplete1Letter();
        }
        function UpdatePanelExistEmployee() {

            if (document.getElementById("<%=cbxExistingEmployee.ClientID%>").checked == false) {

                document.getElementById("divExistingEmp").style.display = "none";
                document.getElementById("divNewEmp").style.display = "";


            }
            else {
                document.getElementById("divNewEmp").style.display = "none";
                document.getElementById("divExistingEmp").style.display = "";

            }
            $au('#cphMain_ddlExistingEmployee').selectToAutocomplete1Letter();
            $au("div#divExistingEmp input.ui-autocomplete-input").focus();
        }   
    </script>
    <script>
        var Cnt = 0;
        $noCon(function () {
            //disable mouse selection
           
        });

       
       

    </script>
    <style>
            .select2-container--default.select2-container--focus .select2-selection--multiple {
    border: solid #ccc 1px;
    outline: 0;
}
    .select2-container {
        width:585px !important;
    }
    </style>
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
                return false;

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenNewCustId" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenEditMode" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustomerFocus" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenWarehouseIds" runat="server" />
    <asp:HiddenField ID="hiddenSelctdPrimaryWrhs" runat="server" />
    <asp:HiddenField ID="hiddenPMSDisplaySts" runat="server" />
    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="gen_ProjectsList.aspx">Project Master</a></li>
        <li id="lblEntryB" runat="server" class="active">Add Project Master</li>
    </ol>
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">

            <div class="content_box1 cont_contr" onmouseover="closesave()">
                <h2 id="lblEntry" runat="server">Add Project Master</h2>

                <div class="form-group fg2 sa_fg1 sa_480">
                    <label for="email" class="fg2_la1">Project Name:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtProjectName" class="form-control fg2_inp1 inp_mst" placeholder="Project Name" runat="server" MaxLength="150" Style="text-transform: uppercase;"></asp:TextBox>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group fg2 sa_fg1 sa_480">
                            <label for="email" class="fg2_la1">Customer:<span class="spn1">*</span></label>
                            <div class="input-group dys flt_l dys_wdt">
                                <div id="divNewCust" style="display: none">
                                    <asp:TextBox ID="txtCustName" class="form-control fg2_inp1 inp_mst" runat="server" MaxLength="100" onblur="RemoveTag(this)" Style="display: none; text-transform: uppercase;"></asp:TextBox>
                                </div>

                                <div id="divExistingCust">
                                    <asp:DropDownList ID="ddlExistingCustomer" class="form-control fg2_inp1 inp_mst" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                                    </asp:DropDownList>
                                    <a id="btnNewCust" runat="server" href="#" title="Add New Customer" class=" ad_cst" onclick="return NewCustPageLoad('ddlExistingCustomer')"><span class="input-group-addon cur6"><i class="fa fa-plus"></i></span></a>
                                   <asp:Button ID="btnNewCustS" runat="server" title="Add Customer" class="save tooltip" Style="margin-left: 0.1%; padding: 2%; border-radius: 0px; padding-bottom: 2.7%;display:none;" Text="+"  OnClick="btnNewCust_Click" />
                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="form-group fg2 sa_fg1 sa_480" id="divDivs">
                    <label for="email" class="fg2_la1">Division:<span class="spn1">*</span></label>
                    <asp:DropDownList ID="ddlDivision" class="form-control fg2_inp1 inp_mst" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                </div>

                <div class="form-group fg2 fg2_mr sa_fg1 sa_480">
                    <label for="email" class="fg2_la1">Ref#:<span class="spn1">*</span></label>
                    <input id="lblRefNumber" runat="server" type="text" class="form-control fg2_inp1 inp_mst" disabled="" />
                </div>
                <div class="clearfix"></div>
                <div class="devider"></div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="form-group fg2 fg2_mr sa_1">
                            <label class="form1 mar_bo">
                                <span class="button-checkbox mar_rgt1">
                                    <label class="switch mr_swt" onclick="empl_ct()">
                                        <input type="checkbox" id="cbxExistingEmployee" runat="server" onchange="CbxChangeEmploye()">
                                        <span class="slider_tog round"></span>
                                    </label>
                                </span>Existing Employee:
                            </label>
                            <div id="divExistingEmp">
                                <asp:DropDownList ID="ddlExistingEmployee" class="form-control fg2_inp1" runat="server" AutoPostBack="true" autofocus="autofocus" OnSelectedIndexChanged="ddlExistingEmployee_SelectedIndexChanged" autocorrect="off" autocomplete="off">
                                </asp:DropDownList>
                            </div>
                            <div id="divNewEmp">
                                <asp:TextBox ID="txtEmployeeName" class="form-control fg2_inp1" placeholder="Contact Name" runat="server" MaxLength="100" onblur="RemoveTag(this)" Style="text-transform: uppercase;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group fg2 fg2_mr sa_fg4 sa_480">
                            <label for="email" class="fg2_la1">Email:<span class="spn1"></span></label>
                            <asp:TextBox ID="txtContactMail" class="form-control fg2_inp1" placeholder="Email" runat="server" MaxLength="100"></asp:TextBox>
                        </div>

                        <div class="form-group fg2 sa_fg4 sa_480">
                            <label for="email" class="fg2_la1">Phone#:<span class="spn1"></span></label>
                            <asp:TextBox ID="txtContactPhone" class="form-control fg2_inp1" placeholder="Phone#" runat="server" MaxLength="100" Style="text-transform: uppercase;" onkeydown="return isNumber(event,'cphMain_txtContactPhone');"></asp:TextBox>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="form-group fg2 sa_fg4 sa_480">
                    <label for="email" class="fg2_la1">Tender / RFQ Ref#:<span class="spn1">*</span></label>
                    <asp:TextBox ID="txtTenderRFQ" class="form-control fg2_inp1 inp_mst" placeholder="Tender / RFQ Ref#" runat="server" MaxLength="100" Style="text-transform: uppercase;"></asp:TextBox>
                </div>

                <div class="clearfix"></div>

                <div id="divWarehouse" style="display: none;">
                    <div class="form-group fg6 sa_fg4 sa_480" style="margin-bottom: 10px;">
                        <label for="" class="fg2_la1">Warehouse:<span class="spn1">*</span></label><br>
                        <asp:DropDownList ID="ddlWarehouse" data-placeholder="Select warehouse" multiple="mutiple" class="form-control fg2_inp1 inp_mst select2" runat="server">
                        </asp:DropDownList>
                    </div>

                    <div class="form-group fg2 sa_fg4 sa_640">
                        <label for="email" class="fg2_la1">Primary Warehouse:<span class="spn1"></span></label>
                        <asp:DropDownList ID="ddlPrimaryWrhs" class="form-control fg2_inp1" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg2 fg2_mr sa_fg4 sa_480">
                    <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1">*</span></label>
                    <div class="check1 tr_l">
                        <div class="">
                            <label class="switch">
                                <input type="checkbox" id="cbxStatus" runat="server" checked="checked" />
                                <span class="slider_tog round"></span>
                            </label>
                        </div>
                    </div>
                </div>

                <div class="clearfix"></div>
                <div class="devider"></div>

                <div class="award_Area sa_awrd" id="divAwardedContainer">

                    <div class="fg2 tr_l pad_lft sa_640">
                        <div class="form-group">
                            <label class="form1 mar_bo">
                                <i class="aw_img">
                                    <img src="/Images/New Images/images/cup.png" width="40" height="40">
                                    <b class="plc1">Awarded</b>
                                </i>
                                <span class="button-checkbox mar_rgt1 mar_tp">
                                    <label class="switch" >
                                        <input type="checkbox" id="cbxAwarded" runat="server" checked="checked" onchange="return DivAwardedVisibility()"/>
                                        <span class="slider_tog round"></span>
                                    </label>
                                </span>
                                <!--  <span class="spn1">*</span> -->
                            </label>
                        </div>
                    </div>
                    <div class="form-group fg2 fg2_mr sa_640" id="divProjectManager">
                        <label for="email" class="fg2_la1">Project Manager:<span class="spn1">*</span></label>
                        <asp:DropDownList ID="ddlProjectManager" class="form-control fg2_inp1 inp_mst" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group fg2 fg2_mr sa_640">
                        <label for="email" class="fg2_la1">Client Ref#:<span class="spn1"></span></label>
                        <asp:TextBox ID="txtClientRefNUm" class="form-control fg2_inp1" placeholder="Client Ref#" runat="server" MaxLength="100" Style="text-transform: uppercase;"></asp:TextBox>
                    </div>
                    <div class="form-group fg2 fg2_mr sa_640">
                        <label for="email" class="fg2_la1">Internal Ref#:<span class="spn1">*</span></label>
                        <asp:TextBox ID="txtInternalRefNum" class="form-control fg2_inp1 inp_mst" placeholder="Internal Ref#" runat="server" MaxLength="100" Style="text-transform: uppercase;"></asp:TextBox>
                    </div>
                </div>

                <div class="clearfix"></div>
                <div class="free_sp" style="margin-top:0px;"></div>
                <div class="devider"></div>

                <div class="sub_cont pull-right">
                    <div class="save_sec">
                        <asp:Button ID="btnUpdate" runat="server" class="btn sub1" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnUpdateNext" runat="server" class="btn sub3" Text="Update & Next" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnAdd" runat="server" class="btn sub1" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                        <asp:Button ID="btnAddNext" runat="server" class="btn sub3" Text="Save & Next" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                        <asp:Button ID="btnAddClose" runat="server" class="btn sub3" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
                        <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
                        <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                        <asp:Button ID="btnClose" runat="server" class="btn sub4" Text="Close" OnClientClick=" CloseWindow();" />
                    </div>
                </div>
            </div>
        </div>
        <!-- <div class="content_sec3"></div> -->
    </div>
    <div class="mySave1" id="mySave" runat="server">
        <div class="save_sec">
            <asp:Button ID="btnUpdateF" runat="server" class="btn sub1 bt_b" Text="Update" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnUpdateNextF" runat="server" class="btn sub3 bt_b" Text="Update & Next" OnClientClick="return NameValidate();" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnAddF" runat="server" class="btn sub1 bt_b" Text="Save" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
            <asp:Button ID="btnAddNextF" runat="server" class="btn sub3 bt_b" Text="Save & Next" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
            <asp:Button ID="btnAddCloseF" runat="server" class="btn sub3 bt_b" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return NameValidate();" />
            <asp:Button ID="btnClearF" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2 bt_b" Text="Clear" />
            <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage();" />
             <asp:Button ID="btnCloseF" runat="server" class="btn sub4" Text="Close" OnClientClick=" CloseWindow();" />
        </div>
    </div>
    <a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
        <i class="fa fa-save"></i>
    </a>

    <!---back_button_fixed_section--->
    <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="divList" runat="server">
        <i class="fa fa-arrow-circle-left"></i>
    </a>
    <!---back_button_fixed_section--->
    <!--save_pop up_open-->
    <script>
        function opensave() {
            document.getElementById("cphMain_mySave").style.width = "140px";
        }

        function closesave() {
            document.getElementById("cphMain_mySave").style.width = "0px";
        }
        $noCon(window).load(function () {
            $noCon("#cphMain_ddlWarehouse").select2({
                //  tags: true
            }).on("select2:unselecting", function (e) {
                // check if originalEvent.currentTarget.className is "select2-results__option" (in other words if it was raised by a item in the dropdown)
                if ($noCon(e.params.args.originalEvent.currentTarget).hasClass("select2-results__option")) {
                    e.preventDefault();
                    // close the dropdown
                    $noCon(".js-example-tags").select2().trigger("close");
                }
            }).on("change", function (e) {
                PrimaryWarehouseLoad();
                Cnt++;
            });


            var Id = document.getElementById("<%=hiddenWarehouseIds.ClientID%>").value;
            if (Id != "") {
                var totalString = Id;
                eachString = totalString.split(',');
                var newVar = new Array();
                for (count = 0; count < eachString.length; count++) {
                    if (eachString[count] != "") {
                        newVar.push(eachString[count]);
                    }
                }
                $noCon('#cphMain_ddlWarehouse').val(newVar);
                $noCon("#cphMain_ddlWarehouse").trigger("change");
            }

            var PrimaryId = document.getElementById("<%=hiddenSelctdPrimaryWrhs.ClientID%>").value;
            if (PrimaryId != "") {
                PrimaryWarehouseLoad();
                $noCon('#cphMain_ddlPrimaryWrhs').val(PrimaryId);
            }
                   
         });
    </script>
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
