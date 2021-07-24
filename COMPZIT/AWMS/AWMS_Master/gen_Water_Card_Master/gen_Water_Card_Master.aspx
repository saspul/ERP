<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Water_Card_Master.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Water_Card_Master_gen_Water_Card_Master" %>

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
                   if (confirm("Are You Sure You Want To Leave This Page?")) {
                       window.location.href = "gen_Water_Card_Master_List.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Water_Card_Master_List.aspx";

               }
           }

           function AlertClearAll() {
               if (confirmbox > 0) {
                   if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                       window.location.href = "gen_Water_Card_Master.aspx";
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Water_Card_Master.aspx";

               }
           }


    </script>

     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
          

            if (document.getElementById("<%=hiddenConfirmValue.ClientID%>").value != "") {

                IncrmntConfrmCounter();
            }

            AmountCheck('cphMain_txtOpeningAmount'); 
            AmountCheck('cphMain_txtAlertAmount'); 
            AmountCheck('cphMain_txtBalanceAmount');
        });
        
    </script>

        <script type="text/javascript">

            function DuplicationName() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=txtCardNumber.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCardNumber.ClientID%>").focus();
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Water Card Number Can’t be Duplicated.";
            }
            function DuplicationCardName() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=txtCardName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtCardName.ClientID%>").focus();
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Water Card Name Can’t be Duplicated.";
             }
            

            function SuccessConfirmation() {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Card Details Inserted Successfully.";
        }

        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Water Card Details Updated Successfully.";
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
            var CrdNumWithoutReplace = document.getElementById("<%=txtCardNumber.ClientID%>").value;
            var replaceText1 = CrdNumWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCardNumber.ClientID%>").value = replaceText2;

            var CrdExpWithoutReplace = document.getElementById("<%=txtCardEspiryDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtCardEspiryDate.ClientID%>").value = replaceCode2;

            var openAmntWithoutReplace = document.getElementById("<%=txtOpeningAmount.ClientID%>").value;
            var replaceCode1 = openAmntWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtOpeningAmount.ClientID%>").value = replaceCode2;

            var CrdIsueWithoutReplace = document.getElementById("<%=txtCardIsueDate.ClientID%>").value;
            var replaceCode1 = CrdIsueWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtCardIsueDate.ClientID%>").value = replaceCode2;

            var AlrtAmntWithoutReplace = document.getElementById("<%=txtAlertAmount.ClientID%>").value;
            var replaceCode1 = AlrtAmntWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtAlertAmount.ClientID%>").value = replaceCode2;

            var CrdNametWithoutReplace = document.getElementById("<%=txtCardName.ClientID%>").value;
            var replaceCode1 = CrdNametWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtCardName.ClientID%>").value = replaceCode2;

                document.getElementById("<%=txtCardIsueDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCardNumber.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCardEspiryDate.ClientID%>").style.borderColor = "";
                $noCon("div#divBank input.ui-autocomplete-input").css("borderColor", "");
                document.getElementById("<%=txtOpeningAmount.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtAlertAmount.ClientID%>").style.borderColor = "";

                var CardNum = document.getElementById("<%=txtCardNumber.ClientID%>").value.trim();
                var CardExp = document.getElementById("<%=txtCardEspiryDate.ClientID%>").value.trim();
                var CardIssueDate = document.getElementById("<%=txtCardIsueDate.ClientID%>").value.trim();
                var AlertAmount = document.getElementById("<%=txtAlertAmount.ClientID%>").value.trim();

                var BankDdl = document.getElementById("<%=ddlBank.ClientID%>");
                var BankText = BankDdl.options[BankDdl.selectedIndex].text;
                var openAmnt = document.getElementById("<%=txtOpeningAmount.ClientID%>").value;
           
                if (CardIssueDate != "") {
                    var TaskdatepickerDate = document.getElementById("<%=txtCardIsueDate.ClientID%>").value;
                    var arrDatePickerDate = TaskdatepickerDate.split("-");
                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                    var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                    var arrCurrentDate = CurrentDateDate.split("-");
                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                    if (dateDateCntrlr > dateCurrentDate) {
                        document.getElementById("<%=txtCardIsueDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtCardIsueDate.ClientID%>").focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Issue Date should be less than Current Date !";
                        ret = false;

                    }

                }
                if (openAmnt < 0) {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Opening Amount Should Not Be Negative. Please check the highlighted fields below.";
                    document.getElementById("<%=txtOpeningAmount.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtOpeningAmount.ClientID%>").focus();
                     ret = false;
                 }

                 if (AlertAmount < 0) {
                     document.getElementById('divMessageArea').style.display = "";
                     document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                     document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Opening Amount Should Not Be Negative. Please check the highlighted fields below.";
                    document.getElementById("<%=txtAlertAmount.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtAlertAmount.ClientID%>").focus();
                    ret = false;
                }


                if (BankText == "--SELECT--") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlBank.ClientID%>").style.borderColor = "Red";
                    $noCon("div#divBank input.ui-autocomplete-input").css("borderColor", "Red");
                    $noCon("div#divBank input.ui-autocomplete-input").focus();
                    $noCon("div#divBank input.ui-autocomplete-input").select();
                    document.getElementById("<%=ddlBank.ClientID%>").focus();

                    ret = false;
                }

                if (CardExp == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=txtCardEspiryDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCardEspiryDate.ClientID%>").focus();
                    ret = false;
                }

                else {
                    var TaskdatepickerDate = document.getElementById("<%=txtCardEspiryDate.ClientID%>").value;
                    var arrDatePickerDate = TaskdatepickerDate.split("-");
                    var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                    var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                    var arrCurrentDate = CurrentDateDate.split("-");
                    var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                    if (dateDateCntrlr < dateCurrentDate) {

                        document.getElementById("<%=txtCardEspiryDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtCardEspiryDate.ClientID%>").focus();
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, Expiry Date should be greater than Current Date !.";

                        ret = false;
                    }
                }
                if (CardNum == "") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtCardNumber.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtCardNumber.ClientID%>").focus();
                      ret = false;
                  }


                
               


          
             




                if (ret == false) {
                    CheckSubmitZero();

                }
                return ret;
            }


    </script>
    <script>
        function addCommas(nStr) {

            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];
            //var a = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
             //alert('hi'+a);
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
                 return x1;
             else
                 return x1 + "." + x2;
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
            function AmountCheck(textboxid) {
                var txtPerVal = (document.getElementById(textboxid).value).split(',').join('');
                if (txtPerVal == "") {
                    return false;
                }
                else {
                    if (!isNaN(txtPerVal) == false) {
                        document.getElementById(''+textboxid+'').value = "";
                    return false;
                }
                    else {
                        if (txtPerVal < 0) {
                            document.getElementById('' + textboxid + '').value = "";
                            return false;
                        }
                    var amt = parseFloat(txtPerVal);
                    var num = amt;
                    var n = 0;
                    // for floatting number adjustment from corp global
                    var FloatingValue =document.getElementById("<%=hiddenDecimalCount.ClientID%>").value ;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById('' + textboxid + '').value = addCommas(n);

                }
            }
        }
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
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
                $au('#cphMain_ddlVehicleNumber').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);


      

                    </script>
   
    <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />

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
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenConfirmValue" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
        <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="hiddenBalanceChangeNtps" runat="server" />
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <div class="cont_rght">


                   <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

     <br />

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:42%;height:26.5px;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width:100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <div class="eachform" style="width:49%">

                <h2>Card Number*</h2>
                <asp:TextBox ID="txtCardNumber" Height="30px" Width="50%" class="form1" runat="server" MaxLength="50" Style="text-transform: uppercase; margin-right: 4%;"></asp:TextBox>

            </div>
            <div class="eachform"  style="width:49%;float: right;">

                <h2>Card Name</h2>
                <asp:TextBox ID="txtCardName" Height="30px" Width="50%" class="form1" runat="server" MaxLength="50" Style="text-transform: uppercase; margin-right: 4%;"></asp:TextBox>

            </div>
            <div class="eachform"  style="width:49%;float: left;">

                <h2>Vehicle Number</h2>
               
                  <asp:DropDownList ID="ddlVehicleNumber" Height="30px" Width="50%" class="form1" onkeydown="return DisableEnter(event)" runat="server" Style="margin-right: 4%;"></asp:DropDownList>
            </div>
             <div id="divBank" class="eachform"  style="width:49%;float: right;">

                <h2>Bank*</h2>
                <asp:DropDownList ID="ddlBank" Height="30px" Width="50%" class="form1" onkeydown="return DisableEnter(event)" runat="server" Style="margin-right: 4%;"></asp:DropDownList>

            </div>
             <div class="eachform"  style="width:49%;float: left;">

                <h2>Opening Amount</h2>
                <asp:TextBox ID="txtOpeningAmount" class="form1" runat="server" MaxLength="12" Style="height:30px;width:50%;text-transform: uppercase;text-align: right; margin-left: 0%;margin-right: 4%;" onkeydown="return isNumber(event,'cphMain_txtOpeningAmount');" onblur="AmountCheck('cphMain_txtOpeningAmount');"></asp:TextBox>

            </div>
             <div class="eachform"  style="width:49%;float: right;">

                <h2>Balance Amount</h2>
                <asp:TextBox ID="txtBalanceAmount" class="form1" Enabled="false" runat="server" MaxLength="12" Style="height:30px;width:50%;text-transform: uppercase;text-align: right; margin-left: 0%;margin-right: 4%;" onkeydown="return isNumber(event,'cphMain_txtOpeningAmount');" onblur="AmountCheck('cphMain_txtOpeningAmount');"></asp:TextBox>
               
            </div>
             <div class="eachform"  style="width:49%;float: left;">

                <h2>Alert Amount</h2>
                <asp:TextBox ID="txtAlertAmount" Height="30px" Width="50%" class="form1" runat="server" MaxLength="12" Style="text-transform: uppercase;text-align: right; margin-right: 4%;" onkeydown="return isNumber(event,'cphMain_txtAlertAmount');" onblur="AmountCheck('cphMain_txtAlertAmount');"></asp:TextBox>

            </div>
             <div class="eachform"  style="width:49%;float:right">
                 <h2>Card Issued Date</h2>
               <div id="cardIsueDate" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="txtCardIsueDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" onchange="IncrmntConfrmCounter()" runat="server" Style="width:81.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img1" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#cardIsueDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                endDate: new Date(),
                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
                 <div class="eachform"" style="width:49%;float: left;">
                 <h2>Card Expiry Date*</h2>
               <div id="WaterCardExpiry" class="input-append date" style="font-family:Calibri;float:right;width:57.5%">
                 <asp:TextBox ID="txtCardEspiryDate" class="textDate" onchange="IncrmntConfrmCounter()" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width:83%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "imgDate" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            $noCo('#WaterCardExpiry').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),

                            });
                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>
           
            
           
             
            
             
            
                        <div class="eachform"  style="width:49%;float: right;">
                <h2>Status*</h2>
                <div class="subform" style="margin-right: 7%; ">


                    <asp:CheckBox ID="cbxStatus" Text="" runat="server" onkeydown="return DisableEnter(event)" Checked="true" class="form2" />
                    <h3>Active</h3>

                </div>
            </div>
            <br />
            <div class="eachform">
                <div class="subform" style="width: 62%; margin-top:5%">


                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return WaterCardValidate();"/>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return WaterCardValidate();"/>
                     <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="~/AWMS/AWMS_Master/gen_Water_Card_Master/gen_Water_Card_Master_List.aspx"/>
                 <asp:Button ID="btnClear" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear"/>
                </div>
            </div>

        </div>
    </div>

</asp:Content>


