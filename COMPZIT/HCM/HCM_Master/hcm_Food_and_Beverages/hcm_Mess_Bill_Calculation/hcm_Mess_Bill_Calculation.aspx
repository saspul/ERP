<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Mess_Bill_Calculation.aspx.cs" Inherits="HCM_HCM_Master_hcm_Food_and_Beverages_hcm_Mess_Bill_Calculation_hcm_Mess_Bill_Calculation" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">



     <script src="/JavaScript/multiselect/jQuery/jquery-3.1.1.min.js"></script>
     <script src="/js/libs/jquery-ui/1.8/jquery-ui.min.js"></script>         
     <link href="/js/libs/jquery-ui/1.8/jquery-ui.css" rel="stylesheet" />




        <%-- for datetime picker--%>
    <script src="/JavaScript/datepicker/bootstrap-datepicker.js"></script>
    <link href="/JavaScript/datepicker/datepicker3.css" rel="stylesheet" />
    
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

       <style>




        .ui-widget-content {
            background: #ffffff;
            color: #333333;
        }
        .ui-widget {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 1em;
        }
        .ui-menu {
            list-style: none;
            padding: 0;
            padding-right: 0px;
            margin: 0;
            display: block;
            outline: 0;
        }
            .ui-menu .ui-menu {
                position: absolute;
            }
        .ui-autocomplete {
            position: absolute;
            top: 0;
            left: 0;
            cursor: default;
            max-height: 200px;
            overflow-y: auto;
            /* prevent horizontal scrollbar */
            overflow-x: hidden;
        }
        .ui-front {
            z-index: 100;
        }
        .ui-menu .ui-menu-item {
            margin: 0;
            cursor: pointer;
        }
        .ui-menu .ui-menu-item-wrapper {
            position: relative;
            padding: 3px 1em 3px .4em;
            text-align:left!important;
        }
        .ui-menu .ui-menu-divider {
            margin: 5px 0;
            height: 0;
            font-size: 0;
            line-height: 0;
            border-width: 1px 0 0 0;
        }
        .ui-menu .ui-state-focus,
        .ui-menu .ui-state-active {
            margin: -1px;
        }
        .ui-state-active,
        .ui-widget-content .ui-state-active,
        .ui-widget-header .ui-state-active:hover {
            border: 1px solid #003eff;
            background: #007fff;
            font-weight: normal;
            color: #ffffff;
        }
        .ui-selectmenu-menu .ui-menu {
            overflow: auto;
            overflow-x: hidden;
            padding-bottom: 1px;
        }
            .ui-selectmenu-menu .ui-menu .ui-selectmenu-optgroup {
                font-size: 1em;
                font-weight: bold;
                line-height: 1.5;
                padding: 2px 0.4em;
                margin: 0.5em 0 0 0;
                height: auto;
                border: 0;
            }
        .ui-menu-icons .ui-menu-item-wrapper {
            padding-left: 2em;
        }
        .ui-menu-icons {
            position: relative;
        }
        .ui-menu .ui-icon {
            position: absolute;
            top: 0;
            bottom: 0;
            left: .2em;
            margin: auto 0;
        }
        .ui-menu .ui-menu-icon {
            left: auto;
            right: 0;
        }

    </style>


      <style type="text/css">
        #TableHeaderBilling {
            background-color: #A4B487;
            color: white;
            font-weight: bold;
            font-family: calibri;
            line-height: 30px;
        }


        #TableFooterBilling {
            color: red;
            font-weight: bold;
            font-family: calibri;
            line-height: 25px;
        }

        #myTable {
            background-color: #039ED1;
            color: white;
            font-weight: bold;
            line-height: 30px;
        }
    </style>

    <style>

         .MyModalPopup {
            display: none;
            position: fixed;
            z-index: 100;
            padding-top: 0%;
            left: 5%;
            top: 9%;
            width: 87%;
            height: 87%;
            overflow: auto;
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }

    </style>

      <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            /*width: 52.6%;*/
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

 <style>
    #divPopupMessageArea {
    border-radius: 8px;
    background: #fff;
    padding: 1px;
    font-weight: bold;
    text-align: center;
    font-size: 17px;
    color: #53844E;
    margin-bottom: 0.5%;
    font-family: Calibri;
    border: 2px solid #53844E;
}
 </style>
    <script type="text/javascript">
     
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        } 
        function MessDuplication() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry.Mess bill is already created for the date";
        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill details inserted successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill details updated successfully.";
        }
        function MessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Mess bill details confirmed successfully.";
        }
        function EmployeeSelect() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry.Employees not present in this accomodation";
        }

        function DateSelect() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select the date.";
        }

        function EmployeeDuplication() {
            $(window).scrollTop(0);
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Employee already allocated.";
        }
        function MultipleEmployeeDup() {
            $(window).scrollTop(0);
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Same employees were selected."; 
        }

        // for not allowing enter
        function DisableEnter(evt) {
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

        var $noCon = jQuery.noConflict();
        var $noConfi = jQuery.noConflict();
        $noCon(function () {
            //ddlAccoChange();

        //    AmountCheck('cphMain_txtTotalAmount');
          
        });

        function ddlAccoChange__() {
        }

        function ddlAccoChange() {

            $("#TableaddedRows tbody").empty();
            rowCount = 0;
            RowIndex = 0;
            addMoreRows();
            if (document.getElementById("<%=hiddenCalcRateMode.ClientID%>").value == "1") {

                var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
                var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
                var AccoId = document.getElementById("<%=ddlAccomo.ClientID%>").value;
                var skillsSelect = document.getElementById("<%=ddlAccomo.ClientID%>");
                var AccoName = skillsSelect.options[skillsSelect.selectedIndex].text;
                var From_date = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var To_date = document.getElementById("<%=txtToDate.ClientID%>").value;
                var TotalAmount = document.getElementById("<%=txtTotalAmount.ClientID%>").value;
                var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;


                var EmpIdsAsJson = "";
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "hcm_Mess_Bill_Calculation.aspx/ConvertDataTableToHTML",
                    data: '{intCorpId: "' + CorpId + '",intOrgId:"' + OrgId + '",intAccoId:"' + AccoId + '",strAccoName:"' + AccoName + '",datFrom:"' + From_date + '",datTo:"' + To_date + '",strTotalAmount:"' + TotalAmount + '",strDecimalCnt:"' + DecimalCnt + '",EmpIdsAsJson:"' + EmpIdsAsJson + '"}',
                    dataType: "json",
                    success: function (data) {
                        document.getElementById("<%=divReport.ClientID%>").innerHTML = data.d[0];

                        document.getElementById("<%=divPrintReport.ClientID%>").innerHTML = data.d[2];
                        document.getElementById("<%=divPrintCaption.ClientID%>").innerHTML = data.d[3];
                        document.getElementById("<%=divPrintCaption.ClientID%>").innerHTML = "";


                        //evm-0023
                        if (AccoId != "--SELECT ACCOMMODATION--") {

                            if (data.d[4] == "FALSE") {
                             //   EmployeeSelect();
                                document.getElementById("<%=hiddenReturn.ClientID%>").value = "FALSE";
                            }
                            else if (data.d[4] == "NULLDATE") {
                                DateSelect();
                            }
                            else if (data.d[4] == "TRUE") {
                                document.getElementById('divMessageArea').style.display = "none";
                                document.getElementById('imgMessageArea').src = "";
                                document.getElementById("<%=hiddenReturn.ClientID%>").value = "TRUE";
                            }
                        }
                    }

                });
            }
        }

        function AmountCheck(textboxid) {
            var txtPerVal = (document.getElementById(textboxid).value).split(',').join('');
            if (txtPerVal == "") {
                return false;
            }
            else {
                if (!isNaN(txtPerVal) == false) {
                    document.getElementById('' + textboxid + '').value = "";
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
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
                    if (FloatingValue != "") {
                        var n = num.toFixed(FloatingValue);
                    }
                    document.getElementById('' + textboxid + '').value = addCommas(n);

                }
            }
        }

        function ChangeAmnt(RowNum) {
            var ret = true;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var TotalAmount = document.getElementById("<%=txtTotalAmount.ClientID%>").value.trim().split(',').join('');
            var CurrAmnt = 0;
            if (document.getElementById("txtAmnt_" + RowNum).value.trim() != "") {
                CurrAmnt = document.getElementById("txtAmnt_" + RowNum).value.trim().split(',').join('');
            }
            else {
                document.getElementById("txtAmnt_" + RowNum).value = "0";
            }
            var CurrChangeSts = document.getElementById("tdAmntChangeSts_" + RowNum).innerHTML;
            var CurrNumDays = document.getElementById("tdRemain_" + RowNum+" ").innerHTML;
            var CurrOldValue = document.getElementById("tdAmntOld_" + RowNum).innerHTML.split(',').join('');
            var ChagedTotSum = 0;
            var UnchangedTotDays = 0;
           
            var MainTable = $('#ReportTable > tbody > tr');
            $(MainTable).each(function () {
                var RowId = $(this).attr('id');

                var SplitId = RowId.split('_');
                if (SplitId[0] == "trId") {
                    var CntMain = SplitId[1];
                    if (CntMain != RowNum) {
                        var NUMDAYS = document.getElementById("tdRemain_" + CntMain).innerHTML;
                        var AMOUNT = document.getElementById("txtAmnt_" + CntMain.trim()).value.split(',').join('');
                        var CHANGESTS = document.getElementById("tdAmntChangeSts_" + CntMain.trim()).innerHTML;
                        if (CHANGESTS == 0) {
                            UnchangedTotDays = UnchangedTotDays + parseInt(NUMDAYS);
                        }
                        else {
                            ChagedTotSum = ChagedTotSum + parseFloat(AMOUNT);
                        }
                    }
                }
            });
            ChagedTotSum = ChagedTotSum + parseFloat(CurrAmnt);
            if (parseFloat(ChagedTotSum) > parseFloat(TotalAmount)) {
                var n = parseFloat(CurrOldValue).toFixed(FloatingValue);
                document.getElementById("txtAmnt_" + RowNum).value = addCommas(n);
                CurrAmnt = CurrOldValue;
                ret = false;
            }
            if (ret == true) {
              
                if (FloatingValue != "") {
                    var n = parseFloat(CurrAmnt).toFixed(FloatingValue);
                    document.getElementById('txtAmnt_' + RowNum).value = addCommas(n);
                }
               
                document.getElementById("tdAmount_" + RowNum + " ").style.backgroundColor = "#f3d6d6";
                document.getElementById("tdAmntChangeSts_" + RowNum).innerHTML = "1";
                document.getElementById("tdAmntOld_" + RowNum).innerHTML = CurrAmnt;

                var RemaingTotAmnt = parseFloat(TotalAmount) - parseFloat(ChagedTotSum);
                var RemaingPerDayAmnt = RemaingTotAmnt / UnchangedTotDays;
            

                var LastUnChRowNum = -1;

              

                $(MainTable).each(function () {
                    var RowId = $(this).attr('id');
                    var SplitId = RowId.split('_');
                    if (SplitId[0] == "trId") {
                        var CntMain = SplitId[1];
                        if (CntMain != RowNum) { 
                            var NUMDAYS = document.getElementById("tdRemain_" + CntMain).innerHTML;

                            var CHANGESTS = document.getElementById("tdAmntChangeSts_" + CntMain.trim()).innerHTML;
                            if (CHANGESTS == 0) {
                                LastUnChRowNum = CntMain.trim();
                                var n = parseInt(NUMDAYS) * parseFloat(RemaingPerDayAmnt);
                                document.getElementById("txtAmnt_" + CntMain.trim()).value = addCommas(n.toFixed(FloatingValue));
                                document.getElementById("tdAmntOld_" + CntMain.trim()).innerHTML = parseInt(NUMDAYS) * parseFloat(RemaingPerDayAmnt);
                            }
                        }
                    }
                });
                if (LastUnChRowNum > 0) {
                    var ChagedTotSum = 0;
                    var MainTable = $('#ReportTable > tbody > tr');
                    $(MainTable).each(function () {
                        var RowId = $(this).attr('id');
                        var SplitId = RowId.split('_');
                        if (SplitId[0] == "trId") {
                            var CntMain = SplitId[1];
                            var AMOUNT = document.getElementById("txtAmnt_" + CntMain.trim()).value.split(',').join('');
                            ChagedTotSum = ChagedTotSum + parseFloat(AMOUNT);
                        }
                    });
                    if (parseFloat(TotalAmount) != parseFloat(ChagedTotSum)) {
                        var diff = parseFloat(TotalAmount) - parseFloat(ChagedTotSum);
                        var n = parseFloat(document.getElementById("txtAmnt_" + LastUnChRowNum).value.split(',').join('')) + parseFloat(diff);
                        document.getElementById("txtAmnt_" + LastUnChRowNum).value = addCommas(n.toFixed(FloatingValue));
                        document.getElementById("tdAmntOld_" + LastUnChRowNum).innerHTML = n;
                    }
                }
            }
        }


        function ChangeAmntMessEdit(RowNum) {
            var ret = true;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var TotalAmount = document.getElementById("<%=txtTotalAmount.ClientID%>").value.trim().split(',').join('');
            
            if (TotalAmount != "") {

                var ChagedTotSum = 0;
                var UnchangedTotDays = 0;
                var MainTable;

                //if ((document.getElementById("cphMain_hiddenEditMode").value == "1" && document.getElementById("cphMain_hiddenContinueBackReturn").value == "1") || document.getElementById("cphMain_hiddenEditMode").value == "") {
                    MainTable = $('#MessDetailTable > tbody > tr');
               // }
                //else {
                   // MainTable = $('#MessDetailTableEdit > tbody > tr');
                //}

                $(MainTable).each(function () {
                    var RowId = $(this).attr('id');
                    var SplitId = RowId.split('_');

                    if (SplitId[0] == "trIdMess") {
                        var CntMain = SplitId[1];

                        var NUMDAYS = document.getElementById("tdDaysMess" + CntMain).innerHTML;
                        var AMOUNT = document.getElementById("txtAmntMess" + CntMain.trim()).value.split(',').join('');
                        var CHANGESTS = document.getElementById("tdAmntChangeStsMess" + CntMain.trim()).innerHTML;
                        if (CHANGESTS == 0) {
                            UnchangedTotDays = UnchangedTotDays + parseInt(NUMDAYS);
                        }
                        else {
                            ChagedTotSum = ChagedTotSum + parseFloat(AMOUNT);
                        }
                    }
                });

                if (ret == true) {
                    var RemaingTotAmnt = parseFloat(TotalAmount) - parseFloat(ChagedTotSum);
                    var RemaingPerDayAmnt = RemaingTotAmnt / UnchangedTotDays;

                    var LastUnChRowNum = -1;

                    $(MainTable).each(function () {
                        var RowId = $(this).attr('id');
                        var SplitId = RowId.split('_');
                        if (SplitId[0] == "trIdMess") {
                            var CntMain = SplitId[1];
                            var NUMDAYS = document.getElementById("tdDaysMess" + CntMain).innerHTML;
                            var CHANGESTS = document.getElementById("tdAmntChangeStsMess" + CntMain.trim()).innerHTML;
                            if (CHANGESTS == 0) {
                                LastUnChRowNum = CntMain.trim();
                                var n = parseInt(NUMDAYS) * parseFloat(RemaingPerDayAmnt);
                                document.getElementById("txtAmntMess" + CntMain.trim()).value = addCommas(n.toFixed(FloatingValue));
                                document.getElementById("tdAmntOldMess" + CntMain.trim()).innerHTML = parseInt(NUMDAYS) * parseFloat(RemaingPerDayAmnt);
                            }
                        }
                    });

                    if (LastUnChRowNum > 0) {
                        var ChagedTotSum = 0;
                        $(MainTable).each(function () {
                            var RowId = $(this).attr('id');
                            var SplitId = RowId.split('_');
                            if (SplitId[0] == "trIdMess") {
                                var CntMain = SplitId[1];
                                var AMOUNT = document.getElementById("txtAmntMess" + CntMain.trim()).value.split(',').join('');
                                ChagedTotSum = ChagedTotSum + parseFloat(AMOUNT);
                            }
                        });

                        if (parseFloat(TotalAmount) != parseFloat(ChagedTotSum)) {
                            var diff = parseFloat(TotalAmount) - parseFloat(ChagedTotSum);
                            var n = parseFloat(document.getElementById("txtAmntMess" + LastUnChRowNum).value.split(',').join('')) + parseFloat(diff);
                            document.getElementById("txtAmntMess" + LastUnChRowNum).value = addCommas(n.toFixed(FloatingValue));
                            document.getElementById("tdAmntOldMess" + LastUnChRowNum).innerHTML = n;
                        }
                    }
                }
            }
         }





        function ChangeAmntMess(RowNum) {

            

            var ret = true;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var TotalAmount = document.getElementById("<%=txtTotalAmount.ClientID%>").value.trim().split(',').join('');

            if (document.getElementById("<%=hiddenCurrentAmt.ClientID%>").value.trim() != TotalAmount) {
               // alert("Calculate first");
               // document.getElementById("txtAmntMess" + RowNum).value = "";
                //return false;
            }
           
              var CurrAmnt = 0;
              if (document.getElementById("txtAmntMess" + RowNum).value.trim() != "") {
                  CurrAmnt = document.getElementById("txtAmntMess" + RowNum).value.trim().split(',').join('');
              }
              else {
                  document.getElementById("txtAmntMess" + RowNum).value = "0";
              }
              
             
              var CurrChangeSts = document.getElementById("tdAmntChangeStsMess" + RowNum).innerHTML;
              var CurrNumDays = document.getElementById("tdDaysMess" + RowNum).innerHTML;
              var CurrOldValue = document.getElementById("tdAmntOldMess" + RowNum).innerHTML.split(',').join('');

              var ChagedTotSum = 0;
              var UnchangedTotDays = 0;
              var MainTable;

              //if ((document.getElementById("cphMain_hiddenEditMode").value == "1" && document.getElementById("cphMain_hiddenContinueBackReturn").value == "1") || document.getElementById("cphMain_hiddenEditMode").value == "") {
                  MainTable = $('#MessDetailTable > tbody > tr');
              //}
              //else {

                  //MainTable = $('#MessDetailTableEdit > tbody > tr');
              //}

              $(MainTable).each(function () {
                  var RowId = $(this).attr('id');
                  var SplitId = RowId.split('_');

                  if (SplitId[0] == "trIdMess") {
                      var CntMain = SplitId[1];
                      if (CntMain != RowNum) {                         
                          var NUMDAYS = document.getElementById("tdDaysMess" + CntMain).innerHTML;
                          var AMOUNT = document.getElementById("txtAmntMess" + CntMain.trim()).value.split(',').join('');
                          var CHANGESTS = document.getElementById("tdAmntChangeStsMess" + CntMain.trim()).innerHTML;                          
                          if (CHANGESTS == 0) {
                              UnchangedTotDays = UnchangedTotDays + parseInt(NUMDAYS);                              
                          }
                          else {
                              ChagedTotSum = ChagedTotSum + parseFloat(AMOUNT);
                          }
                      }
                  }
              });
              ChagedTotSum = ChagedTotSum + parseFloat(CurrAmnt);
           
            if (parseFloat(ChagedTotSum) > parseFloat(TotalAmount)) {
               

                  var n = parseFloat(CurrOldValue).toFixed(FloatingValue);
                  document.getElementById("txtAmntMess" + RowNum).value = addCommas(n);
                  CurrAmnt = CurrOldValue;
                  ret = false;
            }

          


            if (ret == true) {

                  if (FloatingValue != "") {                   
                      var n = parseFloat(CurrAmnt).toFixed(FloatingValue);
                      document.getElementById('txtAmntMess' + RowNum).value = addCommas(n);
                  }
                  document.getElementById("txtAmntMess" + RowNum).style.backgroundColor = "#f3d6d6";
                  document.getElementById("tdAmntChangeStsMess" + RowNum).innerHTML = "1";
                  document.getElementById("tdAmntOldMess" + RowNum).innerHTML = CurrAmnt;

                  var RemaingTotAmnt = parseFloat(TotalAmount) - parseFloat(ChagedTotSum);
                  var RemaingPerDayAmnt = RemaingTotAmnt / UnchangedTotDays;



                  var LastUnChRowNum = -1;

                  $(MainTable).each(function () {
                      var RowId = $(this).attr('id');
                      var SplitId = RowId.split('_');
                      if (SplitId[0] == "trIdMess") {
                          var CntMain = SplitId[1];
                          if (CntMain != RowNum) {
                              var NUMDAYS = document.getElementById("tdDaysMess" + CntMain).innerHTML;
                              var CHANGESTS = document.getElementById("tdAmntChangeStsMess" + CntMain.trim()).innerHTML;
                              if (CHANGESTS == 0) {

                                  LastUnChRowNum = CntMain.trim();
                                  var n = parseInt(NUMDAYS) * parseFloat(RemaingPerDayAmnt);
                                  document.getElementById("txtAmntMess" + CntMain.trim()).value = addCommas(n.toFixed(FloatingValue));
                                  document.getElementById("tdAmntOldMess" + CntMain.trim()).innerHTML = parseInt(NUMDAYS) * parseFloat(RemaingPerDayAmnt);
                              }
                          }
                      }
                  });

                  if (LastUnChRowNum > 0) {
                      var ChagedTotSum = 0;
                      $(MainTable).each(function () {
                          var RowId = $(this).attr('id');
                          var SplitId = RowId.split('_');
                          if (SplitId[0] == "trIdMess") {
                              var CntMain = SplitId[1];
                              var AMOUNT = document.getElementById("txtAmntMess" + CntMain.trim()).value.split(',').join('');
                              ChagedTotSum = ChagedTotSum + parseFloat(AMOUNT);
                          }
                      });

                      if (parseFloat(TotalAmount) != parseFloat(ChagedTotSum)) {                        
                          var diff = parseFloat(TotalAmount) - parseFloat(ChagedTotSum);
                          var n = parseFloat(document.getElementById("txtAmntMess" + LastUnChRowNum).value.split(',').join('')) + parseFloat(diff);
                          document.getElementById("txtAmntMess" + LastUnChRowNum).value = addCommas(n.toFixed(FloatingValue));
                          document.getElementById("tdAmntOldMess" + LastUnChRowNum).innerHTML = n;
                      }
                  }
              }
          }


            function ClosePopUp() {
            //    ClearTextBx();

            }

            function ValidateMessBill(x) {
                var ret = true;
                if (CheckIsRepeat() == true) {
                }
                else {
                    return false;
                }
              
                document.getElementById('divMessageArea').style.display = "none";

                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
                document.getElementById("<%=ddlAccomo.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtTotalAmount.ClientID%>").style.borderColor = "";

                var frmdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                var todate = document.getElementById("<%=txtToDate.ClientID%>").value.trim();
                var AccoId = document.getElementById("<%=ddlAccomo.ClientID%>").value;
                var TotalAmount = document.getElementById("<%=txtTotalAmount.ClientID%>").value.trim();

                if (AccoId != "--SELECT ACCOMMODATION--" ) {

                    if (frmdate != "" && todate != "") {
                        var arrDatePickerDate1 = frmdate.split("-");
                        frmdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                        var arrDatePickerDate1 = todate.split("-");
                        todate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
                        if (frmdate > todate) {
                            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";

                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, from date cannot be greater than to date !.";
                            document.getElementById("<%=txtFromDate.ClientID%>").focus();
                            ret = false;
                        }
                    }
                    else {

                        var dateselected = "";
                        if (todate == "") {
                            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                            dateselected = "1";
                            ret = false;
                        }
                        if (frmdate == "") {
                            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                            dateselected = "2";
                            ret = false;
                        }

                        if (dateselected == "1") {
                            document.getElementById("<%=txtToDate.ClientID%>").focus();
                            ret = false;
                        }

                        if (TotalAmount == "") {
                            document.getElementById("<%=txtTotalAmount.ClientID%>").style.borderColor = "Red";
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                            document.getElementById("<%=txtTotalAmount.ClientID%>").focus();
                            ret = false;
                        }

                        if (dateselected == "2") {
                            document.getElementById("<%=txtFromDate.ClientID%>").focus();
                            ret = false;
                        }
                    }
                   
                    if (TotalAmount == "") {
                        document.getElementById("<%=txtTotalAmount.ClientID%>").style.borderColor = "Red";
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                        document.getElementById("<%=txtTotalAmount.ClientID%>").focus();
                        ret = false;
                    }
                    else if (x == 1) {
                        var ChagedTotSum2 = 0;
                        var amountlist = "";
                        var MainTable;                      
                        //if ((document.getElementById("cphMain_hiddenEditMode").value == "1" && document.getElementById("cphMain_hiddenContinueBackReturn").value == "1") || document.getElementById("cphMain_hiddenEditMode").value == "") {
                            MessTable = $('#MessDetailTable > tbody > tr');
                        //}
                        //else {
                            //MessTable = $('#MessDetailTableEdit > tbody > tr');
                        //}                       
                        $(MessTable).each(function () {
                            var RowId = $(this).attr('id');
                            var SplitId = RowId.split('_');
                            if (SplitId[0] == "trIdMess") {
                                var CntMain = SplitId[1];
                                var AMOUNT = document.getElementById("txtAmntMess" + CntMain.trim()).value.split(',').join('').trim();
                                ChagedTotSum2 = parseFloat(ChagedTotSum2) + parseFloat(AMOUNT);
                            }
                        });
                        TotalAmount = TotalAmount.split(',').join('');

                        //alert("Tot "+TotalAmount)
                        //alert("Chng " +Math.round(ChagedTotSum2.toFixed(document.getElementById("<%=hiddenDecimalCount.ClientID%>").value)))

                        //alert(parseFloat(TotalAmount));
                        //alert(ChagedTotSum2.toFixed(document.getElementById("<%=hiddenDecimalCount.ClientID%>").value));
                        if (parseFloat(TotalAmount) !=ChagedTotSum2.toFixed(document.getElementById("<%=hiddenDecimalCount.ClientID%>").value)) {
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sum of amounts must be equal to the mess bill amount.";
                            ret = false;
                        }
                    }
                    
                }
                else {
                    if (AccoId == "--SELECT ACCOMMODATION--") {
                        document.getElementById("<%=ddlAccomo.ClientID%>").style.borderColor = "Red";
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                        document.getElementById("<%=ddlAccomo.ClientID%>").focus();
                        ret = false;
                    }
                 
                }

                if (ret == false) {                  
                    CheckSubmitZero();
                }
                else {
                    if (x == 0) {
                        ddlAccoChange();

                        calculateAmount();
                    }

                    var tbClientValues = '';
                    tbClientValues = [];
                    //if ((document.getElementById("cphMain_hiddenEditMode").value == "1" && document.getElementById("cphMain_hiddenContinueBackReturn").value == "1") || document.getElementById("cphMain_hiddenEditMode").value == "") {
                        MessTable = $('#MessDetailTable > tbody > tr');
                    //}
                    //else {
                        //MessTable = $('#MessDetailTableEdit > tbody > tr');
                    //}

                    $(MessTable).each(function () {

                        var RowId = $(this).attr('id');

                        var SplitId = RowId.split('_');

                        if (SplitId[0] == "trIdMess") {
                            var CntMain = SplitId[1];
                            var EMPID = document.getElementById('tdEmpidMess' + CntMain).innerHTML;
                            var NUMDAYS = document.getElementById('tdDaysMess' + CntMain).innerHTML;
                            var AMOUNT = document.getElementById('txtAmntMess' + CntMain.trim()).value.trim();
                            var CHANGESTS = document.getElementById('tdAmntChangeStsMess' + CntMain.trim()).innerHTML;
                            var client = JSON.stringify({
                                EmpId: "" + EMPID + "",
                                NoOfDays: "" + NUMDAYS + "",
                                Ammount: "" + AMOUNT + "",
                                ChangeSts: "" + CHANGESTS + ""
                            });
                            tbClientValues.push(client);
                        }

                    });
                    document.getElementById("<%=hiddenEmployeeMessData.ClientID%>").value = JSON.stringify(tbClientValues);

                    document.getElementById("<%=hiddenEmpMessDetails.ClientID%>").value = JSON.stringify(tbClientValues);

                    CheckSubmitZero();
                }

               

                return ret;
            }

        function calculateAmount() {

            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            var table;
            var NumOfEmp;
            
            var LastUnChRowNum = -1;

            //if ((document.getElementById("cphMain_hiddenEditMode").value == "1" && document.getElementById("cphMain_hiddenContinueBackReturn").value == "1") || document.getElementById("cphMain_hiddenEditMode").value == "") {
                table = document.getElementById("MessDetailTable");
                NumOfEmp = $('#MessDetailTable >tbody >tr').length;
                var TotalAmt = document.getElementById("cphMain_txtTotalAmount").value;
                TotalAmt = TotalAmt.split(',').join('');
                var AmountForEachEmp = TotalAmt / NumOfEmp;
                AmountForEachEmp = parseFloat(AmountForEachEmp);
                for (var i = 1; i <= NumOfEmp; i++) {
                    var validRowID = (table.rows[i].cells[0].innerText);
                    //$("#txtAmntMess" + validRowID).val(AmountForEachEmp);
                    document.getElementById("txtAmntMess" + validRowID.trim()).value = addCommas(AmountForEachEmp.toFixed(FloatingValue));

                    document.getElementById("txtAmntMess" + validRowID.trim()).style.backgroundColor = "";
                    document.getElementById("tdAmntChangeStsMess" + validRowID.trim()).innerHTML = "0";
                    document.getElementById("tdAmntOldMess" + validRowID.trim()).innerHTML = addCommas(AmountForEachEmp.toFixed(FloatingValue));
                    LastUnChRowNum = validRowID.trim();
                }

                var MainTable = $('#MessDetailTable >tbody >tr');
                if (LastUnChRowNum > 0) {
                    var ChagedTotSum = 0;
                    $(MainTable).each(function () {
                        var RowId = $(this).attr('id');
                        var SplitId = RowId.split('_');
                        if (SplitId[0] == "trIdMess") {
                            var CntMain = SplitId[1];
                            var AMOUNT = document.getElementById("txtAmntMess" + CntMain.trim()).value.split(',').join('');
                            ChagedTotSum = ChagedTotSum + parseFloat(AMOUNT);
                        }
                    });
                    if (parseFloat(TotalAmt) != parseFloat(ChagedTotSum)) {
                        var diff = parseFloat(TotalAmt) - parseFloat(ChagedTotSum);
                        var n = parseFloat(document.getElementById("txtAmntMess" + LastUnChRowNum).value.split(',').join('')) + parseFloat(diff);
                        document.getElementById("txtAmntMess" + LastUnChRowNum).value = addCommas(n.toFixed(FloatingValue));
                        document.getElementById("tdAmntOldMess" + LastUnChRowNum).innerHTML = addCommas(n.toFixed(FloatingValue));
                    }
                }

            //}
            //else {
            //    table = document.getElementById("MessDetailTableEdit");
            //    NumOfEmp = $('#MessDetailTableEdit >tbody >tr').length;

            //    var TotalAmt = document.getElementById("cphMain_txtTotalAmount").value;
            //    TotalAmt = TotalAmt.split(',').join('');
            //    var AmountForEachEmp = TotalAmt / NumOfEmp;
            //    for (var i = 1; i <= NumOfEmp; i++) {
            //        var validRowID = (table.rows[i].cells[0].innerText);
            //        $("#txtAmntMess" + validRowID).val(AmountForEachEmp);                 
            //    }
            //}                           
        }

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

        function ConfirmMessage() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to leave this page?")) {
                    window.location.href = "hcm_Mess_Bill_Calculation_List.aspx";
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Mess_Bill_Calculation_List.aspx";

            }
        }


        function BlurNotNumber(obj) {

            var txt = document.getElementById(obj).value;

            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;
                }
                else {
                    if (txt.indexOf(".") > 0) {
                        document.getElementById(obj).value = "";
                        document.getElementById(obj).focus();
                        return false;
                    }
                }
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

        function isNumber(evt) {
           
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
          
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
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
                    document.getElementById('' + textboxid + '').value = "";
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
                    var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

                        if (FloatingValue != "") {
                            var n = num.toFixed(FloatingValue);
                        }
                        var a = document.getElementById('' + textboxid + '').value;

                        document.getElementById('' + textboxid + '').value = addCommas(n);
                    }
                }
                document.getElementById('' + textboxid + '').style.borderColor = "";          

        }

        function addCommas(nStr) {
            
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];


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

            if (isNaN(x2))

                return x1;
            else
                return x1 + "." + x2;
        }



        function disabled() {
            document.getElementById("<%=ddlAccomo.ClientID%>").style.backgroundColor = "rgb(227, 227, 227)";       
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="HiddenFieldAddMode" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenMessBillId" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="hiddenDecimalCountCommon" runat="server" />
     <asp:HiddenField ID="hiddenReturn" runat="server" />
    
    <asp:HiddenField ID="HiddenCurencyMode" runat="server" />
    <asp:HiddenField ID="hiddenEmployeeId" runat="server" />
     <asp:HiddenField ID="hiddenEmployeeMessData" runat="server" />

     <asp:HiddenField ID="hiddenCalcRateMode" runat="server" />
    <asp:HiddenField ID="hiddenEmpMessDetails" runat="server" />
    <asp:HiddenField ID="hiddenEditMode" runat="server" />
    <asp:HiddenField ID="hiddenViewMode" runat="server" />

    <asp:HiddenField ID="hiddenEmpName" runat="server" />
         <asp:HiddenField ID="hiddenContinueBackReturn" runat="server" />
         <asp:HiddenField ID="hiddenCurrentAmt" runat="server" />
    <asp:HiddenField ID="hiddenEmployeeCode" runat="server" />

   

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
   
    <asp:Label ID="lblIndex" runat="server" Text="Label" Style="display: none"></asp:Label>

    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
     <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 2%; font-family: Calibri;" class="print" id="divPrint" runat="server">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="Print/45_Print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print</span></a>                                  
</div>

    <div id="div1" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">
    </div>
    <div class="cont_rght">


        <%--popups--%>

              <div id="MyModalPopup" class="MyModalPopup">
          <div id="DivEmpHeader" style="height: 30px; background-color: #6f7b5a;">
             <label id="lblProcess" style="margin-left: 42%; font-size: 18px; color: #fff; font-family: calibri;">Add employee in bulk</label>
             <img id="closeCancelView"  class="closeCancelView" style="margin-top: .5%; margin-right: 1%; float: right; cursor: pointer;" onclick="ClosePopup(0);" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
           </div>


           <div style="float: left; margin: 13px; background-color: #fff; margin-bottom: 6px; width: 97%;">  
                           <div id="divPopupMessageArea" style="display: none">
                    <asp:Label ID="lblPopupMessageArea" runat="server"></asp:Label>
                 </div>
        <div id="divFilter" style="border:.5px solid #9ba48b; background-color: #f3f3f3;height:305px;width:100%;padding:2%;">
           
          <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Business Unit* </h2>
             <div id="div2">
                 <asp:DropDownList ID="ddlBusnsUnit" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server" onchange="return changeBu();">
                </asp:DropDownList>
                 </div>
         </div>  


         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Designation </h2>
             <div id="divDesignation">
                <asp:DropDownList ID="ddlDesgntn" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
                 </div>
         </div>  
            
        <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Department </h2>
            <div id="divDepartment">
                <asp:DropDownList ID="ddlDeptmnt" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
                </div>
         </div> 
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 
         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Division </h2>
             <div id="divDivision">
                <asp:DropDownList ID="ddlDivsn" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" runat="server" onkeydown="return DisableEnter(event)" AutoPostBack="true"  OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                </asp:DropDownList>
                 </div>
         </div>  

        <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
            <h2 style="margin-left: 0%">Project </h2>
                <asp:DropDownList ID="ddlPrjct" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList> 
            
          
         </div> 

             </ContentTemplate>

            </asp:UpdatePanel>            
      
         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
               <h2 style="margin-left: 0%">Pay Grade </h2>
                <asp:DropDownList ID="ddlGrade" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div>  
            
        <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Status* </h2>
                <asp:DropDownList ID="ddlStatus" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                <asp:ListItem Text="WORKING" Value="0"></asp:ListItem>
                <asp:ListItem Text="ON LEAVE" Value="1"></asp:ListItem>
                <asp:ListItem Text="RESIGNED" Value="2"></asp:ListItem>
                <asp:ListItem Text="IN ACTIVE" Value="3"></asp:ListItem>
                </asp:DropDownList>
         </div> 
         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;">
             <h2 style="margin-left: 0%">Nationality </h2>
                <asp:DropDownList ID="ddlNation" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div>  

        <div class="eachform" style="width: 47%; float: left;margin-left: 0%;">
             <h2 style="margin-left: 0%">Religion </h2>
                <asp:DropDownList ID="ddlRelgn" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div> 
     

         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Gender </h2>
                <asp:DropDownList ID="ddlGender" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                 <asp:ListItem Text="--SELECT--" Value="3"></asp:ListItem>
                 <asp:ListItem Text="MALE" Value="0"></asp:ListItem>
                 <asp:ListItem Text="FEMALE" Value="1"></asp:ListItem>
                 <asp:ListItem Text="OTHER" Value="2"></asp:ListItem>
                </asp:DropDownList>
         </div>  

        <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Age </h2>
          
                <div id="AgeFrom" style="width: 26%;margin-left: 35%;">
                    <label style="color:#909c7b;font-family: calibri;">From</label>
              
                <asp:TextBox ID="txtAgeFrom"  class="form1" runat="server"  MaxLength="2" Style="width: 23%; text-transform: uppercase; height: 30px;float:none;margin-left:4%;font-family:Calibri;" onkeypress="return isNumber(event);" onkeydown="return isNumber(event);"></asp:TextBox>
               </div>
           <div id="AgeTo" style="width: 25%;margin-right: 19%;float:right;margin-top:-6%;">
                     <label style="color:#909c7b;font-family: calibri;">To</label>
                <asp:TextBox ID="txtAgeTo"  class="form1" runat="server"  MaxLength="2" Style="width: 23%; text-transform: uppercase;  height: 30px;float:none;margin-left:4%;font-family:Calibri;" onkeypress="return isNumber(event);" onkeydown="return isNumber(event);"></asp:TextBox>
           </div>
         </div> 


         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%;width:25%;">Number of Years at Al-Balagh</h2>
                <asp:DropDownList ID="ddlNumYear" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                     <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="1+YEARS" Value="1"></asp:ListItem>
                     <asp:ListItem Text="3+YEARS" Value="2"></asp:ListItem>
                     <asp:ListItem Text="5+YEARS" Value="3"></asp:ListItem>
                     <asp:ListItem Text="8+YEARS" Value="4"></asp:ListItem>
                     </asp:DropDownList>
         </div>  

         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <input type="button" id="btnclearPopup" onclick="ClearPopup();" style="display:none;cursor:pointer;margin-top: 0%;float:right;text-transform: capitalize;margin-right: 1%;width: 97px;height: 27px;"  class="cancel"  value="Clear" />
             <a  href="javascript:void(0);" style="cursor:pointer;float:right;margin-right: 3%;margin-top: 1px;" onclick="SearchClick();" class="searchlist_btn_lft"> Search</a>

         </div>         
     </div>



<input type="button" style="text-align:right;display:none;margin-left:43%;" id="btnAddBulk" class="cancel"  onclick="ShowProcess_Multy();"  value="Add Bulk"  />

<br/> <br/>

 <div id="divReportEmployeeDtl" class="widget-body no-padding dataTables_wrapper" style="margin-top: 0.5%;width: 100%;margin-left:0%;">

</div>    


          </div>

       </div>

         <%--popups--%>

        <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
            <asp:Label ID="lblEntry" runat="server">Mess Bill</asp:Label>
        </div>

        <div style="border: .5px solid #9ba48b; background-color: #f3f3f3; width: 97.5%; margin-top: 0.5%; float: left;">
            <div class="eachform" style="width: 49%; margin-top: 1%; margin-left: 2%; float: left;">
                <h2 style="margin-top: 1%; margin-left: 13%;">Accommodation*</h2>
                <asp:DropDownList ID="ddlAccomo" class="form1" OnChange="ddlAccoChange()" runat="server" Style="width: 43%; float: right; margin-right: 15%;">
                </asp:DropDownList>

            </div>


            <div class="eachform" style="width: 49%; margin-top: -3.5%; margin-left: 49%; float: left;">
                <h2 style="margin-top: 1%; margin-left: 13%;">From Date*</h2>
                <asp:TextBox ID="txtFromDate" class="form1" runat="server" onkeydown="return DisableEnter(event)" Style="width: 40%; float: right; margin-right: 15%;">
                </asp:TextBox>

            </div>

            <div id="divTxtTotalAmt" style="display:none">
            <div class="eachform" style="width: 49%; margin-top: 1.5%; float: left;margin-left: 7%;">
                <h2 style="margin-top: 1%; margin-left: 3%;">Amount*</h2>
                <asp:TextBox ID="txtTotalAmount" class="form1" MaxLength="8" onkeypress="return isNumber(event,this);" onblur="AmountCheck('cphMain_txtTotalAmount');"   runat="server" Style="width: 43%; float: right; margin-right: 25%;">
                </asp:TextBox>

            </div>
                </div>
            <br/> <br/><br/>  <br/><br/> 
            <div class="eachform" style="width: 49%; margin-top: -3.5%; float: left;margin-left: 54%;">
                <h2 style="margin-top: 1%; margin-left: 3%;">To Date*</h2>
                <asp:TextBox ID="txtToDate" class="form1" runat="server" onkeydown="return DisableEnter(event)" Style="width: 40%; float: right; margin-right: 25%;">
                </asp:TextBox>

            </div>

            <div id="divBtnCalculate" style="display:none">
            <div class="eachform" style="width: 100%; margin-top: 0.5%; float: left;">
                <input type="button" id="btnCalculate" runat="server" value="Calculate" style="cursor:pointer; width: 110px; float: left; margin-left: 45%; background-color: #0870b3; border: 2px solid #b7afaf; height: 26px; color: white;" onclick="return ValidateMessBill(0)"  />

            </div>
           </div>

        </div>
        <div style="border: .5px solid #9ba48b; background-color: #f3f3f3; width: 97.5%; margin-top: 1%; float: left;padding-bottom: 3%;">
            <%--<h4><a id="btnBulk" style="float:right;" href="javascript:void(0);" onclick="return BulkPopup();">Add bulk</a></h4>--%>
            <br/>
            <div id="divMessDetail" class="table-responsive" style="display:none; float: left; width: 75%;  margin-top: 1%; margin-left: 1%;" runat="server">
                <table id="MessDetailTable" class="main_table" cellspacing="0" cellpadding="2px">
                    <thead><tr class="main_table_head">
                        <th class="thT" style="width:5%;text-align: left; word-wrap:break-word;">Sl#</th>  <%--EMPLOYEE CODE--%>
                        <th class="thT" style="width:20%;text-align: left; word-wrap:break-word;">EMPLOYEE CODE</th>
                        <th class="thT" style="width:40%;text-align: left; word-wrap:break-word;">EMPLOYEE</th>
                        <th class="thT" style="width:20%;text-align: center; word-wrap:break-word;">NUMBER OF DAYS</th>
                        <th class="thT" style="width:15%;text-align: right; word-wrap:break-word;">AMOUNT</th>
                        </tr></thead>
                    <tbody>

                        

                    </tbody>

                </table>
            </div>

             <div id="divReportMess" class="table-responsive" runat="server" style="overflow: auto;max-height:340px;float:left; width: 75%; margin-top: 1%; margin-left: 1%;display:none;">
            </div>


            <div id="divReport" class="table-responsive" runat="server" style="display:none; float:left; width: 75%; margin-top: 1%; margin-left: 1%;">
            </div>

             <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


    <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


                <div id="divErrorNotification" style="visibility: hidden">
                    <asp:Label ID="lblErrorNotification" runat="server"></asp:Label>
                </div>
                <div id="divTables" style="width: 50%;float:left; margin-left: 10%; padding-top: 0.6%;">
                   <h2 style="margin-top:1%;"> Employees</h2>
                    <table id="TableHeaderBilling" rules="all" style="width: 100%;">

                        <tr>
                            <td style="font-size: 14px; width: 7%; padding-left: 0.5%;">Sl#</td>
                            <td style="font-size: 14px; width: 72%; padding-left: 0.5%;">Name</td>

                            <td id="spanAddRow" style="width: 11%;background: rgb(244, 246, 240) none repeat scroll 0% 0%;">
                                <%--  this not used  now if needed remove display none--%>
                                <img src="/Images/imgAddRows.png" style="cursor: pointer; width: 100%; height: 30px; display: none" onclick="CheckaddMoreRows();" />

                            </td>
                        </tr>
                    </table>
                    
                    <div style="width: 100%; min-height: 75px; overflow-y: auto;">
                        <table id="TableaddedRows" style="width: 100%;">
                        </table>

                    </div>                  
                    <div id="divBlink" style="background-color: rgb(249, 246, 3); font-size: 10.5px; color: black; opacity: 0.6;"></div>
                </div>




            <div style="float: left; width: 14%; margin-left: 7%; padding: 1%;">

              <input id="btnBack" type="button" class="save" value="Edit" onclick="clickBtnBack()" style="display:none"; />

              <div id="divButtons">
                <asp:Button ID="btnUpdate" runat="server" TabIndex="10" class="save" Text="Update" OnClientClick="return ValidateMessBill(1);" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnUpdateClose" TabIndex="11" runat="server" class="save" Text="Update & Close" OnClientClick="return ValidateMessBill(1);" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnConfirm" runat="server" TabIndex="10" class="save" Text="Confirm" OnClientClick="return ValidateMessBill(1);" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnConfirmClose" runat="server" TabIndex="10" class="save" Text="Confirm & Close" OnClientClick="return ValidateMessBill(1);" OnClick="btnUpdate_Click" />

                <asp:Button ID="btnAdd" runat="server" TabIndex="12" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return ValidateMessBill(1);" />
                <asp:Button ID="btnAddClose" runat="server" TabIndex="13" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return ValidateMessBill(1);" />
              </div>
                 <%--<h4><a id="btnBulk" style="float:right;" href="javascript:void(0);" onclick="return BulkPopup();">Add bulk</a></h4>--%>
                <input id="btnBulk" type="button" class="save" value="Add bulk employees" onclick="return BulkPopup();" />
                <input id="btnContinue" type="button" class="save" value="Continue" onclick="clickBtnContinue()" />

                <%--<asp:Button ID="btnCancel" runat="server" TabIndex="14" class="save" Text="Cancel" PostBackUrl="hcm_Mess_Bill_Calculation_List.aspx" />--%>
                <input id="btnCancel" type="button" class="save" value="Cancel" onclick="clickBtnCancel()" />
                <input id="btnClear" type="button" onclick="clickBtnClear()" class="save" value="Clear" />

            </div>
        </div>

    </div>


    <style>
        .MyModalPopUp {
            display: none;
            position: fixed;
            z-index: 100;
            padding-top: 0%;
            left: 18%;
            top: 15%;
            width: 66%;
            height: 360px;
            overflow: auto;
            background-color: white;
            border: 3px solid;
            border-color: #6f7b5a;
        }

        .cont_rght {
            width: 97%;
        }

        .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 0px;
            height: 0px;
            border-radius: 4px;
            border: none;
        }

        .table > thead > tr > th {
            vertical-align: bottom;
            background: #7b7b7b;
            color: #fff;
        }

        .datepicker table tr td.disabled, .datepicker table tr td.disabled:hover {
            background: none;
            color: #c5c5c5;
            cursor: default;
        }

        .lblTop {
            width: 232px;
            padding: 0px 8px;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }

        .save {
            font-family: Calibri;
            font-size: 14px;
            color: #fff;
            padding: 4px 5px 5px;
            margin: 0 10px 6px 2px;
            line-height: 1;
            font-weight: normal;
            float: left;
            background: #9ba48b;
            border: none;
            border-radius: 2px;
            cursor: pointer;
            text-transform: uppercase;
            width: 100%;
        }
    </style>


    <script>

        var $noConfi = jQuery.noConflict();
        $noConfi(function () {
            $noConfi('#cphMain_txtFromDate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                // startDate: new Date()
            });
            $noConfi('#cphMain_txtToDate').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                language: 'en',
                //startDate: new Date()
            });
        });
</script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).on('load', function () {
            
            if (document.getElementById("<%=HiddenFieldAddMode.ClientID%>").value == "1") {
                document.getElementById('cphMain_divMessDetail').style.display = "none";
            }
            else {
                document.getElementById('cphMain_divMessDetail').style.display = "block";
            }

            if (document.getElementById("<%=hiddenEditMode.ClientID%>").value == "1") {           
                document.getElementById('divTables').style.display = "none";
                document.getElementById("divTxtTotalAmt").style.display = "block";
                document.getElementById("divBtnCalculate").style.display = "block";
                document.getElementById("btnBack").style.display = "block";
                document.getElementById("btnContinue").style.display = "none";
                document.getElementById("cphMain_btnUpdate").style.display = "block";
                document.getElementById("cphMain_btnUpdateClose").style.display = "block";

                document.getElementById("btnBulk").style.display = "none";               
            }
            else {
                document.getElementById('divButtons').style.display = "none";
            }

            if (document.getElementById("<%=hiddenViewMode.ClientID%>").value == "1") {

                document.getElementById('divTables').style.display = "none";
                document.getElementById('btnBulk').style.display = "none";
                document.getElementById('btnContinue').style.display = "none";
                document.getElementById('cphMain_btnCancel').style.display = "none";
                document.getElementById('btnClear').style.display = "none";
                document.getElementById('divTxtTotalAmt').style.display = "block";
                document.getElementById('cphMain_btnCancel').style.display = "block";             
            }
            addMoreRows();            
        });

        //ValidateMessBill(x) tdEmp  btnBulk MessDetailTable
        function clickBtnContinue() {
            var ret = true;
            document.getElementById("<%=hiddenContinueBackReturn.ClientID%>").value = "";
            document.getElementById('divMessageArea').style.display = "none";

            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlAccomo.ClientID%>").style.borderColor = "";

            var frmdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var todate = document.getElementById("<%=txtToDate.ClientID%>").value;
            var AccoId = document.getElementById("<%=ddlAccomo.ClientID%>").value;

            var date1 = new Date(frmdate.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"))
            var date2 = new Date(todate.replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"))

            var diffTime = Math.abs(date2.getTime() - date1.getTime());
            var NofDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)) + 1;
                       
            if (AccoId != "--SELECT ACCOMMODATION--") {

                // EVM-0043

                if (frmdate != "" && todate != "") {
                    var frmdate1 = document.getElementById("<%=txtFromDate.ClientID%>").value;
                    var arrDatePickerDate1 = frmdate1.split("-");
                    frmdate1 = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);

                    var todate1 = document.getElementById("<%=txtToDate.ClientID%>").value;
                    var arrDatePickerDate2 = todate1.split("-");
                    todate1 = new Date(arrDatePickerDate2[2], arrDatePickerDate2[1] - 1, arrDatePickerDate2[0]);


                    if (frmdate1 > todate1) {
                        document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";

                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                        document.getElementById("<%=txtFromDate.ClientID%>").focus();
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,from date cannot be greater than to date !.";

                        ret = false;
                    }
                }

                else {

                    var dateselected = "";
                    if (todate == "") {
                        document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                        dateselected = "1";
                        ret = false;
                    }
                    if (frmdate == "") {
                        document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                        dateselected = "2";
                        ret = false;
                    }

                    if (dateselected == "1") {
                        document.getElementById("<%=txtToDate.ClientID%>").focus();
                        ret = false;
                    }

                    if (dateselected == "2") {
                        document.getElementById("<%=txtFromDate.ClientID%>").focus();
                        ret = false;
                    }
                }
            }
            else {
                if (AccoId == "--SELECT ACCOMMODATION--") {
                    document.getElementById("<%=ddlAccomo.ClientID%>").style.borderColor = "Red";
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing.";
                    document.getElementById("<%=ddlAccomo.ClientID%>").focus();
                    ret = false;
                }

            }

            var arr = [];
            $(".clsMultiEmpId").each(function () {
                var value = $(this).val();
                if (arr.indexOf(value) == -1) {
                    arr.push(value);
                }
                else {                    
                    $(this).addClass("duplicate");
                    $(".duplicate").siblings().css({ "border": "2px solid red" });
                    $(".duplicate").siblings().focus();
                    ret = false;

                    MultipleEmployeeDup();

                }

            });

            if (ret == true) {
                var currentValues = [];
                $('.clsMultiEmpId').each(function () {
                    currentValues.push($(this).val());
                });


                tbClientTotalValuesCat = [];
                var table = document.getElementById("TableaddedRows");
                for (var i = 0; i < table.rows.length; i++) {
                    var validRowID = (table.rows[i].cells[0].innerHTML);
                    var EmpId = document.getElementById("hidden_MultipleEmp_Id" + validRowID).value.trim();
                    var EmpName = document.getElementById("ddlEmp" + validRowID).value.trim();
                    var MessBillId = document.getElementById("cphMain_hiddenMessBillId").value;
                   

                    var objSearchMstr = {};
                    objSearchMstr.EmpId = EmpId;
                    objSearchMstr.frmdate = frmdate;
                    objSearchMstr.todate = todate;
                    objSearchMstr.validRowID = validRowID;
                    objSearchMstr.MessBillId = MessBillId;
                   
                    if (EmpNameValidation('ddlEmp', validRowID) == true) {                      
                        $.ajax({
                            url: "hcm_Mess_Bill_Calculation.aspx/CheckEmployeeMessDate",
                            data: JSON.stringify(objSearchMstr),
                            dataType: "json",
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d == "True") {
                                    document.getElementById('ddlEmp' + validRowID).style.borderColor = "Red";

                                    document.getElementById('ddlEmp' + validRowID).focus();
                                    EmployeeDuplication();
                                    ret = false;
                                }
                                else {
                                }
                            },
                            error: function (response) {
                                alert("err")

                            },
                            failure: function (response) {
                                alert("fail")

                            }
                        });                       
                    }
                    else {
                        ret = false;
                    }
                }
            }

            if (ret == true) {              

                //if ((document.getElementById("cphMain_hiddenEditMode").value == "1" && document.getElementById("cphMain_hiddenContinueBackReturn").value == "1") || document.getElementById("cphMain_hiddenEditMode").value == "") {
                    var MessTable = $('#MessDetailTable > tbody > tr');
                //}
                //else {
                    //var MessTable = $('#MessDetailTableEdit > tbody > tr');
                //}

                if (MessTable.length == 0) {

                    $("#MessDetailTable td").parent().remove();

                    tbClientTotalValuesCat = [];
                    var table = document.getElementById("TableaddedRows");
                    for (var i = 0; i < table.rows.length; i++) {
                        var validRowID = (table.rows[i].cells[0].innerHTML);
                        var EmpId = document.getElementById("hidden_MultipleEmp_Id" + validRowID).value.trim();
                        var EmpName = document.getElementById("ddlEmp" + validRowID).value.trim();
                        var EmpArr = EmpName.split('-');
                        if (EmpArr.length == 2) {
                            EmpName = EmpArr[1];
                        }
                        var EmpCode = document.getElementById("hidden_MultipleEmp_Code" + validRowID).value.trim();
                        var objSearchMstr = {};
                        objSearchMstr.EmpId = EmpId;
                        objSearchMstr.frmdate = frmdate;
                        objSearchMstr.todate = todate;
                        objSearchMstr.validRowID = validRowID;
                        objSearchMstr.EmpCode = EmpCode;
                        addEmployeeDtlsTable(i, EmpId, EmpName, NofDays, EmpCode)
                    }
                }
                else {

                   
                    var lim = MessTable.length;
                  

                    var table = document.getElementById("TableaddedRows");
                    var StrEmpIds = "";
                    for (var i = 0; i < table.rows.length; i++) {
                        var validRowID = (table.rows[i].cells[0].innerHTML);
                        var EmpId = document.getElementById("hidden_MultipleEmp_Id" + validRowID).value.trim();
                        var EmpName = document.getElementById("ddlEmp" + validRowID).value.trim();
                        var EmpArr = EmpName.split('-');
                        if (EmpArr.length == 2) {
                            EmpName = EmpArr[1];
                        }
                        var EmpCode = document.getElementById("hidden_MultipleEmp_Code" + validRowID).value.trim();
                        StrEmpIds = StrEmpIds + "" + EmpId + ",";
                        var flag = 0;
                      
                        $(MessTable).each(function () {
                            var RowId = $(this).attr('id');
                            var SplitId = RowId.split('_');
                            if (SplitId[0] == "trIdMess") {
                                var CntMain = SplitId[1];
                                var EmpIdTab = document.getElementById('tdEmpidMess' + CntMain).innerHTML.trim();
                                if (EmpId == EmpIdTab) {
                                    flag = 1;
                                }                               
                            }
                        });
                        if (flag == 0)
                        {
                            addEmployeeDtlsTable(lim, EmpId, EmpName, NofDays, EmpCode);
                            lim = parseInt(lim) + 1;
                        }
                    }
                    var rowNuCurr = parseInt(lim) - 1;;
                    $(MessTable).each(function () {
                        var RowId = $(this).attr('id');
                        var SplitId = RowId.split('_');
                        if (SplitId[0] == "trIdMess") {
                            var CntMain = SplitId[1];
                            var EmpIdTab = document.getElementById('tdEmpidMess' + CntMain).innerHTML.trim();
                            var n = StrEmpIds.indexOf(EmpIdTab);
                            if (parseInt(n) < 0) {
                                $(this).remove();
                            }
                        }
                    });
                    ChangeAmntMessEdit(rowNuCurr);
                }
               

                document.getElementById("btnBulk").style.display = "none";
                document.getElementById("btnClear").style.display = "none";


                document.getElementById("btnContinue").style.display = "none";
                document.getElementById("divTables").style.display = "none";

                document.getElementById("btnBack").style.display = "block";
                document.getElementById("<%=hiddenCalcRateMode.ClientID%>").value = "1";
                document.getElementById("divButtons").style.display = "block";
                document.getElementById("divTxtTotalAmt").style.display = "block";
                document.getElementById("divBtnCalculate").style.display = "block";

                document.getElementById("cphMain_divMessDetail").style.display = "block";
                //document.getElementById("cphMain_txtTotalAmount").value = "";      
                document.getElementById("cphMain_divReportMess").style.display = "none";


                ddlAccoChange();
            }

            if (ret == true) {

            }

            return ret;
        }
        

        function clickBtnBack() {
            $('.ddlEmp').css('border-color', '');
            document.getElementById("btnBulk").style.display = "block";
            document.getElementById("btnClear").style.display = "block";

            document.getElementById("divTables").style.display = "block";
            document.getElementById("cphMain_divMessDetail").style.display = "none";
            document.getElementById("btnContinue").style.display = "block";
            document.getElementById("btnBack").style.display = "none";

            document.getElementById("<%=hiddenCalcRateMode.ClientID%>").value = "0";
            document.getElementById("divButtons").style.display = "none";
            document.getElementById("divTxtTotalAmt").style.display = "none";
            document.getElementById("divBtnCalculate").style.display = "none";
            document.getElementById("cphMain_divReport").style.display = "none";

            var RowCount = 0;
            //if ((document.getElementById("cphMain_hiddenEditMode").value == "1" && document.getElementById("cphMain_hiddenContinueBackReturn").value == "1") || document.getElementById("cphMain_hiddenEditMode").value == "") {
                 RowCount =$('#MessDetailTable > tbody > tr').length;
            //}
            //else {
                //RowCount =$('#MessDetailTableEdit > tbody > tr').length;
            //}

          

                var LastRowNumOpacity = "";
                for (i = 0; i < RowCount; i++) {

                    var LasttdInputText = $("#TableaddedRows tr:last input:first").val();
                    var LasttdInputId = $('#TableaddedRows  tr:last input:first').attr('id');
                    var LastRowNum = LasttdInputId.replace("ddlEmp", "");
                    LastRowNumOpacity = LastRowNum;

                    document.getElementById("cphMain_hiddenEmployeeId").value = document.getElementById('tdEmpidMess' + i).innerHTML;
                    document.getElementById("cphMain_hiddenEmpName").value = document.getElementById('tdEmpName' + i).innerHTML;
                    document.getElementById("cphMain_hiddenEmployeeCode").value = document.getElementById('tdEmpCode' + i).innerHTML;
                    
                    if (LasttdInputText == "") {
                         document.getElementById("ddlEmp" + LastRowNum).value = document.getElementById("cphMain_hiddenEmployeeCode").value.trim() +"-"+ document.getElementById("cphMain_hiddenEmpName").value;
                      //  document.getElementById("ddlEmp" + LastRowNum).value = document.getElementById("cphMain_hiddenEmpName").value;
                        document.getElementById("hidden_MultipleEmp_Id" + LastRowNum).value = document.getElementById("cphMain_hiddenEmployeeId").value;
                        document.getElementById("hidden_MultipleEmp_Code" + LastRowNum).value = document.getElementById("cphMain_hiddenEmployeeCode").value;
                    }
                    else {
                        document.getElementById("tdInx" + LastRowNum).innerHTML = LastRowNum;
                        addMoreRows();

                    }
                }
           
                LastRowNumOpacity++;
                document.getElementById("cphMain_hiddenEmployeeId").value = "";
                document.getElementById("cphMain_hiddenEmpName").value = "";
                $(".tdIndvlAddMoreRow:not(#tdIndvlAddMoreRow" + LastRowNumOpacity + ")").css('opacity', '0.3');

                //$("#MessDetailTable td").parent().remove();               
                document.getElementById("cphMain_divReportMess").style.display = "none";         

        }

        function clickBtnClear() {                       
            if (confirm("Are you sure you want to clear the employees?")) {
                $("#TableaddedRows tbody").remove();
                addMoreRows();
            }
            else {
                return false;
            }
        }
        function clickBtnCancel() {
            if (confirm("Are you sure you want to leave this page?")) {
                window.location.href = "hcm_Mess_Bill_Calculation_List.aspx";
            }
            else {
                return false;
            }
        }
        function changeSingle() {
            
            var flag = 0;

            $('.clsCblcandidatelist:checkbox:checked').map(function () {
                flag++;
            });
            //selectAllCandidate
            if (flag == 0) {
                document.getElementById("btnAddBulk").style.display = "none";
            }
            else {
                document.getElementById("btnAddBulk").style.display = "block";
            }
        }



        function CheckaddMoreRowsIndividual(x, retBool) {          
            var check = document.getElementById("tdInx" + x).innerHTML;
            if (check == " ") {
                if (retBool == true) {
                    if (CheckAllRowFieldAndHighlight(x, false) == true) {
                        
                        //New change              
                        var ret = true;
                        var arr = [];
                        $(".clsMultiEmpId").each(function () {
                            var value = $(this).val();
                           // alert("# " + value);
                            if (arr.indexOf(value) == -1) {
                                arr.push(value);
                            }
                            else {                                    
                                $(".clsMultiEmpId").removeClass("duplicate");
                                $(this).addClass("duplicate");
                                $(".duplicate").siblings().css({ "border": "2px solid red" });
                                $(".duplicate").siblings().focus();
                                ret = false;
                                MultipleEmployeeDup();
                            }
                        });
                        //New change
                       
                        
                        if (ret == true) {
                            document.getElementById("tdInx" + x).innerHTML = x;
                            document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                            addMoreRows();
                            arr = "";
                        }
                        document.getElementById('ddlEmp' + rowCount).focus();
                        return false;
                    }
                    else {
                        document.getElementById('ddlEmp' + rowCount).style.borderColor = "Red";
                            document.getElementById('ddlEmp' + rowCount).focus();

                    }
                }
                else if (retBool == false) {
                    var row_index = jQuery('#rowId_' + x).index();
                    if (CheckAllRowField(x, row_index) == true) {
                        document.getElementById("tdInx" + x).innerHTML = x;
                        document.getElementById("tdIndvlAddMoreRow" + x).style.opacity = "0.3";
                        addMoreRows();
                        document.getElementById('ddlEmp' + rowCount).focus();

                        return false;
                    }
                }          
            }

         


            return false;
        }

        function CheckAllRowFieldAndHighlight(x, blFromBlurValue) {
            var EmpName = document.getElementById("ddlEmp" + x).value;
            document.getElementById("ddlEmp" + x).style.borderColor = "";
            if (EmpName == "") {
                return false;
            }
            else {
                return true;
            }


            var arr = [];
            $(".clsMultiEmpId").each(function () {
                var value = $(this).val();
                if (arr.indexOf(value) == -1) {
                    arr.push(value);
                }
                else {
                    $(this).addClass("duplicate");
                    $(".duplicate").siblings().css({ "border": "2px solid red" });
                    $(".duplicate").siblings().focus();
                    ret = false;

                    MultipleEmployeeDup();
                }
            });





        }

        function removeRow(removeNum, CofirmMsg) {
            if (confirm(CofirmMsg)) {
                //$("#MessDetailTable td").parent().remove();
                var row_index = jQuery('#rowId_' + removeNum).index();
                jQuery('#rowId_' + removeNum).remove();

                addRowtable = document.getElementById("TableaddedRows");
                var TableRowCount = document.getElementById("TableaddedRows").rows.length;
                if (TableRowCount != 1) {
                    for (var i = 1; i < addRowtable.rows.length; i++) {
                        var xLoop = (addRowtable.rows[i].cells[0].innerHTML);
                        if (TableRowCount != 0) {
                            if ((TableRowCount - 1) == i) {
                                document.getElementById("tdInx" + xLoop).innerHTML = " ";
                                document.getElementById("tdIndvlAddMoreRow" + xLoop).style.opacity = "1";

                            }

                        }
                    }
                }
                else {

                    document.getElementById("tdInx" + 1).innerHTML = " ";
                    document.getElementById("tdIndvlAddMoreRow" + 1).style.opacity = "1";
                }

                if (TableRowCount == 0) {
                    addMoreRows();
                }
              

                return false;
            }
            else {
                return false;

            }
        }

        function ChangeValue(obj, x) {
            RemoveTag('ddlEmp' + x);
            if (obj == 'ddlEmp') {
                document.getElementById("ddlEmp" + x).style.borderColor = "";
            }
            var row_index = jQuery('#rowId_' + x).index();

            var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            if (SavedorNot == "saved") {
                document.getElementById(obj + x).style.borderColor = "";
            }
            else {

                if (CheckAllRowFieldAndHighlight(x, true) == true) {

                }
            }
        }

        function BlurEmp(obj, x) {
            var ret = true;

            if (document.getElementById("hidden_MultipleEmp_Id" + x).value == "") {
                document.getElementById('ddlEmp' + x).value = "";
               // document.getElementById('ddlEmp' + x).focus();
                ret = false;
            }

            return ret;
        }

        function EmpNameValidation(obj, x) {
            var ret = true;

            if (document.getElementById("hidden_MultipleEmp_Id" + x).value == "") {
                $("#MessDetailTable td").parent().remove();
                document.getElementById('ddlEmp' + x).value = "";
                document.getElementById('ddlEmp' + x).style.borderColor = "red";
                document.getElementById('ddlEmp' + x).focus();
                ret = false;
            }
            return ret;
        }


        function RemoveTag(obj) {
            var txt = document.getElementById(obj).value.trim();
            var replaceText1 = txt.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById(obj).value = replaceText2;

        }
        function isTag(evt) {
            IncrmntConfrmCounter();
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
    </script>



    <script>
        var $noC = jQuery.noConflict();
        var rowCount = 0;
        var RowIndex = 0;

        var tbClientTotalValuesCat = '';
        tbClientTotalValuesCat = [];        
        function addMoreRows() {
            rowCount++;

            RowIndex++;
            document.getElementById("<%=lblIndex.ClientID%>").innerHTML = RowIndex.toString();

            var bulk = true;
            if (document.getElementById("cphMain_hiddenEmployeeId").value == "" && document.getElementById("cphMain_hiddenEmpName").value == "") {
                bulk = false;
            }
            else {
            }
            var recRow = '<tr id="rowId_' + rowCount + '" >';
            recRow += '<td id="tdId' + rowCount + '" style="display: none;">' + rowCount.toString() + '</td>';

            recRow += '<td style="width: 5.7%;text-align: center;padding: 2px;padding-right: 5px;"><div id="divSlNum' + rowCount + '" style="background-color: rgb(164, 180, 135); padding-bottom: 10%; padding-top: 8%; color: white;font-weight: bold;margin-top: -10%;" >' + RowIndex.toString() + ' </div></td>';

            if (bulk == false) {
             recRow += ' <td id="tdEmp' + rowCount + '"  style="width: 63%;padding: 4px;">';
             recRow += ' <input id="ddlEmp' + rowCount + '"  class="ddlEmp BillngEntryField"  type="text"  onkeypress="return isTag(event)" onblur="return BlurEmp(\'ddlEmp\',' + rowCount + ')"    onchange="return ChangeValue(\'ddlEmp\',' + rowCount + ')"   maxlength=95 style="text-transform: uppercase;text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
             recRow += '<input class="clsMultiEmpId" type="hidden" id="hidden_MultipleEmp_Id' + rowCount + '"/>';
             recRow += '<input class="clsMultiEmpId" type="hidden" id="hidden_MultipleEmp_Code' + rowCount + '"/>';

             recRow += '   </td> ';

             recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" class="tdIndvlAddMoreRow" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '" type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';
             recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';

             recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
             recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';

             recRow += '</tr>';
            }
            else {
                if (document.getElementById("cphMain_hiddenEmployeeId").value != "" && document.getElementById("cphMain_hiddenEmpName").value != "") {
                   // alert("#Enter");
                   // alert(document.getElementById("cphMain_hiddenEditMode").value)
                    
                    recRow += ' <td id="tdEmp' + rowCount + '"  style="width: 63%;padding: 4px;">';
                    if (document.getElementById("cphMain_hiddenEditMode").value == "1") {
                        recRow += ' <input id="ddlEmp' + rowCount + '"  class="ddlEmp BillngEntryField"  type="text" value="' + document.getElementById("cphMain_hiddenEmployeeCode").value.trim() + "-" + document.getElementById("cphMain_hiddenEmpName").value + '"  onkeypress="return isTag(event)" onblur="return BlurEmp(\'ddlEmp\',' + rowCount + ')"    onchange="return ChangeValue(\'ddlEmp\',' + rowCount + ')"   maxlength=95 style="text-transform: uppercase;text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                    }
                    else {
                         recRow += ' <input id="ddlEmp' + rowCount + '"  class="ddlEmp BillngEntryField"  type="text" value="' + document.getElementById("cphMain_hiddenEmpName").value + '"  onkeypress="return isTag(event)" onblur="return BlurEmp(\'ddlEmp\',' + rowCount + ')"    onchange="return ChangeValue(\'ddlEmp\',' + rowCount + ')"   maxlength=95 style="text-transform: uppercase;text-align: left; line-height: 20px; margin-top:0px; margin-bottom: 3px; width: 100%;margin-left: -0.5%;"/>';
                    }
                    recRow += '<input class="clsMultiEmpId" type="hidden" value="' + document.getElementById("cphMain_hiddenEmployeeId").value + '" id="hidden_MultipleEmp_Id' + rowCount + '"/>';
                    recRow += '<input class="clsMultiEmpId" type="hidden" value="' + document.getElementById("cphMain_hiddenEmployeeCode").value + '" id="hidden_MultipleEmp_Code' + rowCount + '"/>';
                    recRow += '   </td> ';

                    recRow += '<td id="tdIndvlAddMoreRow' + rowCount + '" class="tdIndvlAddMoreRow" style="width: 1.5%; padding-left: 4px;"> <input id="tdIndvlAddMoreRowPic' + rowCount + '" type="image" class="BillngEntryField" src="/Images/Icons/addEntry.png" alt="Add" onclick="return CheckaddMoreRowsIndividual(' + rowCount + ',true);" title="ADD" style="  cursor: pointer;"></td>';
                    recRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" class="BillngEntryField" src="/Images/Icons/deleteEntry.png" alt="Delete"  onclick = "return removeRow(' + rowCount + ',\'Are you sure you want to delete this entry?\');"  title="DELETE"  style=" cursor: pointer;" ></td>';

                    recRow += ' <td id="tdInx' + rowCount + '" style="display: none;" > </td>';
                    recRow += '<td id="tdSave' + rowCount + '" style="display: none;"> </td>';

                    recRow += '</tr>';
                }
            }
           
            jQuery('#TableaddedRows').append(recRow);

            getEmpAutocomplt(rowCount);

        }

        $noC(function () {
            getEmpAutocomplt(1); //set Default 
        });

        function getEmpAutocomplt(RowCount) {
            var id = "#ddlEmp" + RowCount;
                $noC(id).autocomplete({
                    source: function (request, response) {
                        var objSearchMstr = {};
                        var orgID = '<%= Session["ORGID"] %>';
                        var corpID = '<%= Session["CORPOFFICEID"] %>';

                        objSearchMstr.orgID = orgID;
                        objSearchMstr.corpID = corpID;
                        objSearchMstr.prefix = request.term;
                        objSearchMstr.AccomdtnId = document.getElementById("cphMain_ddlAccomo").value;

                        $.ajax({
                            url: "hcm_Mess_Bill_Calculation.aspx/getEmployees",
                            data: JSON.stringify(objSearchMstr),
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('%')[0].trim(),
                                        val: item.split('%')[1].trim()
                                        
                                    }
                                }))
                            },
                            error: function (response) {

                            },
                            failure: function (response) {

                            }
                        });
                    },
                    select: function (e, i) {
                        var srtSearchItemMstr = i.item.label;
                        var srtSearchItemId = i.item.val;
                       
                     
                        var ItemId = srtSearchItemId.split('~')[0].trim();
                        var UserCode = srtSearchItemId.split('~')[1].trim();

                        
                        document.getElementById("hidden_MultipleEmp_Id" + RowCount).value = ItemId;
                        document.getElementById("hidden_MultipleEmp_Code" + RowCount).value = UserCode;

                    },
                    minLength: 1
                });
            }


        function addEmployeeDtlsTable(rowCount, EmpId, EmpName, NofDays, EmpCode) {

            slNum = rowCount + 1;                       
            var recRow = '<tr id="trIdMess_' + rowCount + '" >';
            recRow += '<td id="RowId' + rowCount + '" class="tdT" style=" display:none">' + rowCount + ' </td>';
            recRow += '<td class="tdT" style=" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;">' + slNum + ' </td>';
            recRow += '<td id="tdEmpCode' + rowCount + '" class="tdT" style=" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;">' + EmpCode + ' </td>';
            recRow += '<td id="tdEmpName' + rowCount + '" class="tdT" style=" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;">' + EmpName + '</td>';
            recRow += '<td id="tdDaysMess' + rowCount + '" class="tdT" style=" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;">' + NofDays + '</td>';
            recRow += '<td id="tdAmountMess' + rowCount + '" class="tdT" style="padding-right: 1%; width:15%;word-break: break-all; word-wrap:break-word;text-align: right;">';
            recRow += '<input id="txtAmntMess' + rowCount + '" class="clsTxtAmntMess" onkeydown="return isNumber(event,\'tdAmountMess' + rowCount + '\');" onchange="return ChangeAmntMess(' + rowCount + ');" type="text" style="text-align: right;" value="0.00"/>';
            recRow += ' </td> ';
            recRow += '<td id="tdEmpidMess' + rowCount + '" class="tdT" style=" display:none">' + EmpId + ' </td>';
            recRow += '<td id="tdAmntChangeStsMess' + rowCount + '" class="tdT" style=" display:none">0</td>';
            recRow += ' <td id="tdAmntOldMess' + rowCount + '" class="tdT" style=" display:none">0.00</td>';
            recRow += ' <td id="tdEmpDetlidMess' + rowCount + '" class="tdT" style=" display:none"></td>';
            recRow += '</tr>';

            jQuery('#MessDetailTable').append(recRow);
          

        }

    </script>


      <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <script>


        var $au = jQuery.noConflict();
        function BulkPopup() {

            var objSearchMstr = {};
            objSearchMstr.OrgId = '<%= Session["ORGID"] %>';
            objSearchMstr.CorpId = '<%= Session["CORPOFFICEID"] %>';
            objSearchMstr.AcmdtnId = document.getElementById("cphMain_ddlAccomo").value;
            if (objSearchMstr.AcmdtnId != "--SELECT ACCOMMODATION--") {               
                document.getElementById("MyModalPopup").style.display = "block";
                $.ajax({
                    url: "hcm_Mess_Bill_Calculation.aspx/LoadBusinessUnits",
                    data: JSON.stringify(objSearchMstr),
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d != "") {
                            document.getElementById("cphMain_ddlBusnsUnit").innerHTML = data.d;
                            ret = false;
                        }
                        else {
                        }
                    },
                    error: function (response) {
                        alert("err")

                    },
                    failure: function (response) {
                        alert("fail")

                    }
                });




                $au(function () {
                    //$au('#cphMain_ddlDesgntn').selectToAutocomplete1Letter();
                    //$au('#cphMain_ddlDeptmnt').selectToAutocomplete1Letter();
                    //$au('#cphMain_ddlGrade').selectToAutocomplete1Letter();
                    //$au('#cphMain_ddlNation').selectToAutocomplete1Letter();
                    //$au('#cphMain_ddlDivsn').selectToAutocomplete1Letter();
                    //$au('#cphMain_ddlPrjct').selectToAutocomplete1Letter();
                });

                document.getElementById("cphMain_hiddenEmployeeId").value = "";
                document.getElementById("cphMain_hiddenEmpName").value = "";
                $(".clsCblcandidatelist").prop("checked", false);
                $("#cbxSelectAll").prop("checked", false);



                changeBu();

                document.getElementById("btnAddBulk").style.display = "none";
                document.getElementById("divReportEmployeeDtl").innerHTML = "";
            }
        }
        function changeBu() {

            var objSearchMstr = {};
            objSearchMstr.OrgId = '<%= Session["ORGID"] %>';
            objSearchMstr.CorpId = document.getElementById("cphMain_ddlBusnsUnit").value;
            if (objSearchMstr.CorpId != "") {
                $.ajax({
                    url: "hcm_Mess_Bill_Calculation.aspx/LoadBusinessUnitsSubDdl",
                    data: JSON.stringify(objSearchMstr),
                    dataType: "json",
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        document.getElementById("cphMain_ddlDivsn").innerHTML = data.d[0];
                        document.getElementById("cphMain_ddlPrjct").innerHTML = data.d[1];
                        document.getElementById("cphMain_ddlDeptmnt").innerHTML = data.d[2];
                        document.getElementById("cphMain_ddlGrade").innerHTML = data.d[3];
                        $au(function () {
                          
                           
                            //$au('#cphMain_ddlDesgntn').selectToAutocomplete1Letter();
                            //$au('#cphMain_ddlDeptmnt').selectToAutocomplete1Letter();
                            //$au('#cphMain_ddlGrade').selectToAutocomplete1Letter();
                            //$au('#cphMain_ddlNation').selectToAutocomplete1Letter();
                            //$au('#cphMain_ddlDivsn').selectToAutocomplete1Letter();
                            //$au('#cphMain_ddlPrjct').selectToAutocomplete1Letter();
                        });
                    },
                    error: function (response) {
                        alert("err")

                    },
                    failure: function (response) {
                        alert("fail")

                    }
                });
            }          
        }
        function ClosePopup(x) {
            document.getElementById("MyModalPopup").style.display = "none";
            $('body').css('overflow', 'auto');
        }

        function Autocomplt() {
            $au('#cphMain_ddlDivsn').selectToAutocomplete1Letter();
            $au('#cphMain_ddlPrjct').selectToAutocomplete1Letter();

            $au('#cphMain_ddlDesgntn').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDeptmnt').selectToAutocomplete1Letter();
            $au('#cphMain_ddlGrade').selectToAutocomplete1Letter();
           

        }

        function SearchClick() {
            

            var OrgId = "";
            var CorpId = "";

            var DesignationId = "";
            var DepartmentId = "";
            var DivisionId = "";
            var ProjectId = "";
            var ReligionId = "";

            var GenderId = "";
            var NumOfYears = "";
            var PayGradeId = "";
            var AgeFrom = "";
            var AgeTo = "";
            var StatusId = "";
            var NationalityId = "";


            OrgId = '<%= Session["ORGID"] %>';
            CorpId = document.getElementById("cphMain_ddlBusnsUnit").value;

            if (OrgId == "" || CorpId == "") {
                window.location = '/Security/Login.aspx';
            }

            if (document.getElementById("cphMain_ddlDesgntn").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlDesgntn");
                DesignationId = e.options[e.selectedIndex].value;
            }

               

            if (document.getElementById("cphMain_ddlDeptmnt").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlDeptmnt");
                DepartmentId = e.options[e.selectedIndex].value;
            }


            if (document.getElementById("cphMain_ddlDivsn").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlDivsn");
                DivisionId = e.options[e.selectedIndex].value;
            }


            if (document.getElementById("cphMain_ddlPrjct").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlPrjct");
                ProjectId = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlRelgn").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlRelgn");
                ReligionId = e.options[e.selectedIndex].value;
            }


            if (document.getElementById("cphMain_ddlGender").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlGender");
                GenderId = e.options[e.selectedIndex].value;
            }


            if (document.getElementById("cphMain_ddlNumYear").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlNumYear");
                NumOfYears = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlGrade").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlGrade");
                PayGradeId = e.options[e.selectedIndex].value;
            }

            AgeFrom = document.getElementById("cphMain_txtAgeFrom").value;
            AgeTo = document.getElementById("cphMain_txtAgeTo").value;



            if (document.getElementById("cphMain_ddlStatus").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlStatus");
                StatusId = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlNation").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlNation");
                NationalityId = e.options[e.selectedIndex].value;
            }

            var ret = true;
            $('#divDepartment >input').css('border-color', '');
            document.getElementById('divPopupMessageArea').style.display = "none";
            if (document.getElementById("cphMain_ddlDeptmnt").value == "--SELECT--") {
                if (document.getElementById("cphMain_ddlDeptmnt").value == "--SELECT--") {
                    $('#divDepartment >input').css('border-color', 'red');
                }

                document.getElementById('divPopupMessageArea').style.display = "block";
                document.getElementById("<%=lblPopupMessageArea.ClientID%>").innerHTML = "Please select the highlighted fields below.";

                ret = false;
            }


            if (ret == true) {
                LoadEmployeeDetailsList(OrgId, CorpId, DesignationId, DepartmentId, DivisionId, ProjectId, ReligionId, GenderId, NumOfYears, PayGradeId, AgeFrom, AgeTo, StatusId, NationalityId);
            }

        }

        function LoadEmployeeDetailsList(OrgId, CorpId, DesignationId, DepartmentId, DivisionId, ProjectId, ReligionId, GenderId, NumOfYears, PayGradeId, AgeFrom, AgeTo, StatusId, NationalityId) {

            var objSearchMstr = {};
            objSearchMstr.OrgId=OrgId; 
            objSearchMstr.CorpId=CorpId;
            objSearchMstr.DesignationId=DesignationId; 
            objSearchMstr.DepartmentId=DepartmentId; 
            objSearchMstr.DivisionId=DivisionId;
            objSearchMstr.ProjectId=ProjectId;
            objSearchMstr.ReligionId=ReligionId; 
            objSearchMstr.GenderId=GenderId; 
            objSearchMstr.NumOfYears=NumOfYears; 
            objSearchMstr.PayGradeId=PayGradeId;
            objSearchMstr.AgeFrom=AgeFrom; 
            objSearchMstr.AgeTo=AgeTo;
            objSearchMstr.StatusId = StatusId;
            objSearchMstr.NationalityId = NationalityId;

            $.ajax({
                url: "hcm_Mess_Bill_Calculation.aspx/LoadEmployeeDetailsList",
                data: JSON.stringify(objSearchMstr),
                dataType: "json",
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d != "") {
                        document.getElementById("divReportEmployeeDtl").innerHTML = data.d;
                     //   document.getElementById("btnAddBulk").style.display = "block";

                        ret = false;
                    }
                    else {
                    }
                },
                error: function (response) {
                    alert("err")

                },
                failure: function (response) {
                    alert("fail")

                }
            });
        }
    </script>

     <script>
         function selectAllCandidate() {
             var RowCount =$('#ReportTableBulk >tbody >tr').length;
                    var strAmntList = "";
                    if (document.getElementById('cbxSelectAll').checked == true) {
                        document.getElementById("btnAddBulk").style.display = "block";
                        for (i = 0; i < RowCount; i++) {
                            document.getElementById('cblcandidatelist' + i).checked = true;
                        }
                    }
                    else {
                        document.getElementById("btnAddBulk").style.display = "none";
                        for (i = 0; i < RowCount; i++) {
                            document.getElementById('cblcandidatelist' + i).checked = false;
                        }
                    }
         }
       

         function ShowProcess_Multy() {
             var RowCount = $('#ReportTableBulk >tbody >tr').length;

                  var LastRowNumOpacity = "";

                  for (i = 0; i < RowCount; i++) {

                      if (document.getElementById('cblcandidatelist' + i).checked) {

                          var LasttdInputText = $("#TableaddedRows tr:last input:first").val();
                          var LasttdInputId = $('#TableaddedRows  tr:last input:first').attr('id');
                          var LastRowNum = LasttdInputId.replace("ddlEmp", "");
                          LastRowNumOpacity = LastRowNum;


                          document.getElementById("cphMain_hiddenEmployeeId").value = document.getElementById('tdEmpId' + i).innerHTML;
                          if (document.getElementById('tdEmpCode' + i).innerHTML != "") {
                              document.getElementById("cphMain_hiddenEmpName").value = document.getElementById('tdEmpCode' + i).innerHTML + "-" + document.getElementById('tdEmpName' + i).innerHTML;
                          }
                          else {
                              document.getElementById("cphMain_hiddenEmpName").value = document.getElementById('tdEmpName' + i).innerHTML;
                          }
                          document.getElementById("cphMain_hiddenEmployeeCode").value = document.getElementById('tdEmpCode' + i).innerHTML;


                          if (LasttdInputText == "") {
                              document.getElementById("ddlEmp" + LastRowNum).value = document.getElementById("cphMain_hiddenEmpName").value;
                              document.getElementById("hidden_MultipleEmp_Id" + LastRowNum).value = document.getElementById("cphMain_hiddenEmployeeId").value;
                              document.getElementById("hidden_MultipleEmp_Code" + LastRowNum).value = document.getElementById("cphMain_hiddenEmployeeCode").value;
                          }
                          else {
                              document.getElementById("tdInx" + LastRowNum).innerHTML = LastRowNum;
                              addMoreRows();
                             
                          }
                         
                      }
                  }
                  LastRowNumOpacity++;
                  document.getElementById("cphMain_hiddenEmployeeId").value = "";
                  document.getElementById("cphMain_hiddenEmpName").value = "";                  
                  $(".tdIndvlAddMoreRow:not(#tdIndvlAddMoreRow" + LastRowNumOpacity + ")").css('opacity', '0.3');

                  document.getElementById('closeCancelView').click();
         }

         $au(document).ready(function () {
             $("#TableaddedRows tbody").empty();
         });


         $noCon(document).keyup(function (e) {            
             if (e.keyCode == 27) {
                 //  alert('Esc key is press');
                 if (document.getElementById('MyModalPopup').style.display == "block") {
                     ClosePopup(0);
                  //   document.getElementById('closeCancelView').click();
                     
                 }
             }
         });

         $noCon('#btnBulk').click(function (e) {
             e.preventDefault();
             $('body').css('overflow', 'hidden');
         });
     </script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />



    <style>
    .duplicate {
    border: 1px solid red;
    color: red;
    }
   </style>



</asp:Content>


