<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/MasterPage/MasterPageCompzit_AWMS.master" CodeFile="gen_Insurance_and_PermitRenewal.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Insurance_and_Permit_gen_Insurance_and_Permit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

     <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
    <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/CssLeadIndividualModal.css" />
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
     <script src="../../../JavaScript/jquery-1.8.2.min.js"></script>

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


.isDisabled {
  cursor: not-allowed;
  opacity: 0.5;
}
          







    </style>
     <style>
.divbutton {
    display:inline-block;
    color:#0C7784;
    border:1px solid #999;
    background:#CBCBCB;
    /*box-shadow: 0 0 5px -1px rgba(0,0,0,0.2);*/
    cursor:pointer;
    vertical-align:middle;
    width: 18.7%;
    padding: 5px;
    text-align: center;
    font-family: calibri;
}
.divbutton:active {
    color:red;
    box-shadow: 0 0 5px -1px rgba(0,0,0,0.6);
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

                $au('#cphMain_ddlVehicleNumber').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);





                    </script>


    <style type="text/css">
        

                 input[disabled], select[disabled], textarea[disabled], input[readonly], select[readonly], textarea[readonly] {
        cursor:default;
        }

                   input[type=text][disabled="disabled"] {
            margin-left: 28.5% !important;
            height: 30px !important;
        }
                       .open > .dropdown-menu {
    display: none;
}

                        #divCaption1 {
            font-size: 19px;
            font-weight: bold;
            color: rgb(83, 101, 51);
            font-family: Calibri;
            width: 128px;
            margin-left: 1%;
            margin-top: 2%;
            border-bottom: 1px solid;
        }
                        #divCaption2 {
                 font-size: 19px;
                 font-weight: bold;
                 color: rgb(83, 101, 51);
                 font-family: Calibri;
                 width: 162px;
                 margin-left: 2%;
                 margin-top: 2%;
                 border-bottom: 1px solid;
        }

                        #divMessageArea1 {
    border-radius: 8px;
    background: #fff;
    padding: 10px;
    font-weight: bold;
    text-align: center;
    font-size: 17px;
    color: #53844E;
    margin-top: 0%;
    font-family: Calibri;
    border: 2px solid #53844E;
}
                        #imgMessageArea1 {
    float: left;
    margin-left: 1%;
    margin-top: -0.2%;
}
    </style>

          <%--  for giving pagination to the html table--%>
    <script src="../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />

    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            document.getElementById('cphMain_txtDate').focus();
            //$p('#ReportTable').DataTable({
            //    "pagingType": "full_numbers",
            //    "bpaginate": false,
            //    "bInfo": false,
            //    "bSort": false
            //});

           

          
        });
        //EVM-0027
        //$p(document).ready(function () {
            //document.getElementById('cphMain_txtDate').focus();
           


        //});


            </script>

     <script type="text/javascript"
        src="../../../JavaScript/jquery_2.1.3_jquery_min.js"></script>

    <script type="text/javascript"
        src="../../../JavaScript/jquery_1.11.3_jquery_min.js"></script>
    <script src="../../../JavaScript/scripts/jquery-1.9.1.min.js"></script>
    


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
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {

                return false;
            }
        }

    </script>
    <script>
        function getdetails(href) {
            window.location = href;
            return false;
        }
        //EVM-0027
       
        function getVehicleDetails(id) {
         
            var nWindow = window.open('/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?ViewId=' + id + '&RFGP=VW', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
            // nWindow.focus();
        }
        //END

        var $noCon = jQuery.noConflict();
     
        $noCon(window).load(function ()
        {
            

            $(window).scrollTop(0);
           
            divButtonAsOnDateExprdVhclDetailsClick('1');
            //document.getElementById('divAsOnDateExprdVhclDetails').style.display = "none";
            //document.getElementById('divExprdVhclDetails').style.display = "none";
            document.getElementById("divVehRnwl").style.display = "";
          //  document.getElementById("<%=ddlVehicleRenewal.ClientID%>").value = "--SELECT RENEWAL TYPE--";
            var a = $noC("#cphMain_ddlVehicleRenewal option:selected").text();
            //alert(a);
            $noC("div#divVehRnwl input.ui-autocomplete-input").val(a);

          //  document.getElementById("divVehNumbr").style.display = "";
           // document.getElementById("<%=ddlVehicleNumber.ClientID%>").value = "--REGISTRATION NUMBER--";
            var b = $noC("#cphMain_ddlVehicleNumber option:selected").text();
            //alert(b);
            $noC("div#divVehNumbr input.ui-autocomplete-input").val(b);

        });
       
</script>


    <script>
        function divButtonExprdVhclDetailsClick(type) {
            //hiding other
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.borderBottom = "1px solid #999";
            document.getElementById('divAsOnDateExprdVhclDetails').style.display = "none";
            //document.getElementById('divExprdVhclDetails').style.display = "none";
            
            //displaying current
            document.getElementById('divButtonExprdVhclDetails').style.backgroundColor = "#f9f9f9";
            //document.getElementById('divButtonExprdVhclDetails').style.borderBottom = "none";
            document.getElementById('divExprdVhclDetails').style.display = "block";
            //if (type == "1") {
            //    document.getElementById('cphMain_txtInsurance').focus();
            //}
        }
        function divButtonAsOnDateExprdVhclDetailsClick(type) {
            //hiding other
            document.getElementById('divButtonExprdVhclDetails').style.backgroundColor = "#CBCBCB";
            document.getElementById('divButtonExprdVhclDetails').style.borderBottom = "1px solid #999";
            document.getElementById('divExprdVhclDetails').style.display = "none";

            
            //displaying current
            document.getElementById('divButtonAsOnDateExprdVhclDetails').style.backgroundColor = "#f9f9f9";
            //document.getElementById('divButtonAsOnDateExprdVhclDetails').style.borderBottom = "none";
            document.getElementById('divAsOnDateExprdVhclDetails').style.display = "block";
            //if (type == "1") {
            //    document.getElementById('cphMain_txtInsurance').focus();
            //}
        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea1').style.display = "";
            document.getElementById("<%=lblMessageArea1.ClientID%>").innerHTML = "Insurance Renewal details Inserted Successfully.";
            document.getElementById('imgMessageArea1').src = "/Images/Icons/imgMsgAreaInfo.png";
        }
        function SuccessPermtConfirmation() {
            var permitname = "";
            if (document.getElementById("<%=hiddenPermitName.ClientID%>").value != "") {
                            permitname = document.getElementById("<%=hiddenPermitName.ClientID%>").value;
            }
            document.getElementById('divMessageArea1').style.display = "";
            document.getElementById("<%=lblMessageArea1.ClientID%>").innerHTML = ""+permitname+" Renewal details Inserted Successfully.";
            document.getElementById('imgMessageArea1').src = "/Images/Icons/imgMsgAreaInfo.png";
        }
        function Validate() {
            document.getElementById('divMessageArea1').style.display = "none";
            document.getElementById('divMessageArea').style.display = "none";
   
            var ret = true;
            //if (CheckIsRepeat() == true) {
            //}
            //else {
            //    ret = false;
            //    return ret;
            //}
            document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVehicleNumber.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlVehicleRenewal.ClientID%>").style.borderColor = "";
            var DatePermit = document.getElementById("<%=txtDate.ClientID%>").value.trim();
            if (DatePermit == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDate.ClientID%>").focus();
                ret = false;
            }
            else {

                var TaskdatepickerDate = document.getElementById("<%=txtDate.ClientID%>").value;
                var arrDatePickerDate = TaskdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
                if (dateDateCntrlr < dateCurrentDate) {
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtDate.ClientID%>").focus();
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, As On Date should be greater than Current Date !";
                ret = false;

            }
            }
            var VehDdl = document.getElementById("<%=ddlVehicleRenewal.ClientID%>");
            var VehText = VehDdl.options[VehDdl.selectedIndex].text;

            if (VehText == "--SELECT RENEWAL TYPE--") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlVehicleRenewal.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlVehicleRenewal.ClientID%>").focus();
                ret = false;
            }

            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }

        function ConfirmMessage() {
    
        
                window.location.href = "gen_Insurance_And_PermitRenewal_List.aspx";

          
        }

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


        function PlusWeek() {

            var d = 30;


            var DropdownListWeek = document.getElementById("<%=ddlWeek.ClientID%>");
            var SelectedValueWeek = DropdownListWeek.value;

            var dateDateCntrlr = new Date();
            if (SelectedValueWeek == '1 Week') {                
                dateDateCntrlr.setDate(dateDateCntrlr.getDate() + 7);
            }
            else if (SelectedValueWeek == '1 Month') {
                dateDateCntrlr.setDate(dateDateCntrlr.getDate() + d);
            }
            else if (SelectedValueWeek == '3 Months') {
                dateDateCntrlr.setDate(dateDateCntrlr.getDate() + 3*d);
            }
           else if (SelectedValueWeek == '6 Months') {
                dateDateCntrlr.setDate(dateDateCntrlr.getDate() + 6*d);
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

            document.getElementById("<%=txtDate.ClientID%>").value = ddmmyyyyDate;

            return false;
        }


        //EVM-0027


        function printredirect() {

            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
         //   $('#cphMain_divPrintReportSorted table tr').find('td :eq(0),td a :eq(2),td a :eq(3),td a:eq(4)').addClass("isDisabled");
          //  $('#cphMain_divPrintReportSorted table tr').find('td :eq(4)').find('a').addClass("isDisabled");
            $('#cphMain_divPrintReportSorted table tr').find('td:eq(3),td:eq(4)').attr("style", "color:Black");
            $('#cphMain_divPrintReportSorted table tr').find('td:eq(3),td:eq(4)').attr("style", "text-align:center");
            $('#cphMain_divPrintReportSorted table tr').find('a').removeAttr("style");


           
           

         //   document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable1')[0].outerHTML;
//

            //var resultCurrcy = [];
            //var result = 0;
            //var incrmnt = 0;

            //$p('#cphMain_divPrintReportSorted table tr').each(function () {

            //    $p('td', this).each(function (index, val) {
            //        if (index == 8) {

            //            result += parseFloat($(val).text().replace(/,/g, ""));
            //        }

            //    });

            //});

            //$p('#cphMain_divPrintReportSorted table').append('<tr ></tr>');


            //var FloatingValue = document.getElementById("<%=hiddenDecimalCountMoney.ClientID%>").value;
            //var n = result;
            //if (FloatingValue != "") {
            //    n = result.toFixed(FloatingValue);
            //}

            //addCommas(n);
            //var cnt = 0;
            //var dec = cnt.toFixed(FloatingValue);
           // if (document.getElementById("<%=HiddenFieldAmount.ClientID%>").value != dec) {

              //  $p('#cphMain_divPrintReportSorted table ').last().append('<td style="text-align: right;" colspan=8 >Total<td style="text-align: right;">' + document.getElementById("<%=HiddenFieldAmount.ClientID%>").value + '<td  style="text-align: center;">' + document.getElementById("<%=HiddenCurrency.ClientID%>").value + '</td></td></td>')
                // });
           // }
        }


        function addCommas(amnt) {

            nStr = amnt;
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
                 document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = x1;
                  //return x1;
              else
                  document.getElementById("<%=HiddenFieldAmount.ClientID%>").value = x1 + "." + x2;
             // return x1 + "." + x2;

          }
        //END
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--EVM-0027--%>
      <asp:HiddenField ID="HiddenFieldAmount" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
      <asp:HiddenField ID="HiddenCurrency" runat="server" />
 
  <%--  END--%>
    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
    <asp:HiddenField ID="hiddenPrmtDate" runat="server" />
    <asp:HiddenField ID="hiddenIsuDate" runat="server" />
    <asp:HiddenField ID="hiddenVehNmbr" runat="server" />
     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenDate" runat="server" />
     <asp:HiddenField ID="hiddenPermitName" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCountMoney" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
      <asp:HiddenField ID="hiddenVhclRnwlAlrtMod" runat="server" />
      <asp:HiddenField ID="hiddenVhclRnwlAlrtVal" runat="server" />
      <div class="cont_rght" style="width:99%;padding-top:0%">
                          <div id="divMessageArea1" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea1" src="" >
                <asp:Label ID="lblMessageArea1" runat="server"></asp:Label>
            </div>

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:.5%; top:25%;height:26.5px;"></div>
          
          <div id="divFill" class="fillform" style="width:99%;">
               <div id="divCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                 <img src="/Images/BigIcons/Insurance-and-Permit-Renewal.png" style="vertical-align: middle;" />   <asp:Label ID="lblEntry" runat="server"> Vehicle Renewal</asp:Label>
             
                    </div> 
               <br />
           <div id="divButtonExprdVhclDetails" onclick="divButtonExprdVhclDetailsClick('1')" class="divbutton" style=" visibility:hidden;">Expired Vehicles</div>
          <div id="divButtonAsOnDateExprdVhclDetails" onclick="divButtonAsOnDateExprdVhclDetailsClick('1')" class="divbutton" style=" visibility:hidden;" ></div>  
             <%-- EVM-0027--%>
               <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 2.5%; font-family: Calibri;" class="print" onclick="printredirect()">
        <a id="A1" target="_blank" data-title="Item Listing" href="/Reports/Print/SortedPrint.htm" style="color: rgb(83, 101, 51)">
            <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%;"><span style="float: right; margin-top: 4%;">Print</span></a>
    </div>
            <%--  END--%>
              <div id="divExprdVhclDetails" style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%; margin-top:1%;">
               
                     <div id="divCaption1" >
            <asp:Label ID="Label1" runat="server">Expired Vehicles</asp:Label>
            </div>

                <div id="divReport" class="table-responsive" runat="server" style="margin-top:2%;width: 98%;margin-left: 1%;">
                <br />
                </div>
             </div>
              </div>

 <div  id="divAsOnDateExprdVhclDetails" class="fillform" style="width:99%;">
                <div id="divMessageArea" style="display: none; margin:0px 0 13px;">
                 <img id="imgMessageArea" src="" >
                <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
            </div>

   <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%; margin-top:0%;">
                  <div id="divCaption2" style="visibility:hidden;" >
            <asp:Label ID="lblHeader1" runat="server" Visible="false">Vehicle Renewal List</asp:Label>
            </div>

             <div id="datetimepickerFrom" class="input-append date" style="font-family: Calibri; width: 30%;float:left; /*! height:37px; */margin-left:2%;margin-top: 2%;">
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;">As On Date*</span>
                                <div style="float: right; width: 79%; margin-top: -8%;">
                                <asp:DropDownList ID="ddlWeek"  style="margin-left: 6%;width: 43%;margin-top: 1.5%;height:23px;border: 1px solid #9ba48b;color: #7b826e;" runat="server" onchange="return PlusWeek();"></asp:DropDownList>  
                                <asp:TextBox ID="txtDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 30%; margin-top:-8.4%;  font-family: calibri; float: left;font-size:15px;margin-left:50%;height:23px;" onkeydown="return isNumberDate(event);"></asp:TextBox>                                                                    
                                    <img class="add-on" src="../../../Images/Icons/CalandarIcon.png" style="height: 15px; float:left; cursor:pointer;margin-top:  -9.3%;margin-left: 87%;" />

                                
                                   <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
                        
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker.js">
                        </script>
                        <script type="text/javascript"
                            src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js">
                        </script>
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#datetimepickerFrom').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),

                            });


                                </script>
                            </div>
                               </div> 



       <%-- <asp:UpdatePanel ID="UpdatePanelForTable" runat="server" UpdateMode="Conditional">
                       <ContentTemplate> --%>

       <div id="divVehRnwl" style="float: left; width: 26%; margin-top: 1.7%;margin-left: 1%;" >  
           <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;float: left;">Based On*</span> 
             
    <asp:DropDownList ID="ddlVehicleRenewal" CssClass="leads_field leads_field_dd dd2" AutoPostBack="false" style="width: 65% !important; margin-left:2%;margin-top: 0.5%;" runat="server"  autofocus="autofocus" autocorrect="off" autocomplete="off">      
                 </asp:DropDownList>
           </div>
                            <%-- </ContentTemplate> 
                 </asp:UpdatePanel>--%>
       <div id="divVehNumbr" style="float: left; width: 31%; margin-top: 1.7%;" >
           <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;float: left;">Registration Number</span>
        <asp:DropDownList ID="ddlVehicleNumber" CssClass="leads_field leads_field_dd dd2" style="width: 52% !important; margin-left:2%;margin-top: 0%;" runat="server" onkeypress="return DisableEnter(event);">      
                 </asp:DropDownList>
           </div>

           
                 <%--<asp:UpdatePanel ID="UpdatePanelForTable" runat="server" UpdateMode="Always">
                       <ContentTemplate> --%>

           
    <asp:Button ID="btnSearch" style="margin-top:-2.4%; margin-right:2%; float:right; cursor:pointer; width: 104px;margin-left: 49%;margin-bottom: 2%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click"  OnClientClick="return Validate();"/>
     
               
               
       
             
        <div id="divReportDate" class="table-responsive" runat="server" style="">

        </div>
      
      </div>
      </div>
          </div>
    <%--EVM-0027--%>
    
        <div id="divTitle" runat="server" style="display: none">Vehicle Renewal Report
           
        </div>
        <div id="divPrintReport" runat="server" style="display: none">
            <br />
        </div>
        <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
        </div>
       <div id="divtile" runat="server" style="display: none"></div>
        <div id="divPrintReportSorted" runat="server" style="display: none">
            <br />
        </div>
   <%-- END--%>

     <style>
        #ReportTable_filter input {
    height: 18px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
}
    </style>
</asp:Content>
