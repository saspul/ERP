<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" CodeFile="Rep_Expired_Gurantees.aspx.cs" Inherits="GMS_Reports_Rep_Expired_Gurantees_Rep_Expired_Gurantees" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
  <style>
              #divMessageArea {
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

        #imgMessageArea {
            float: left;
            margin-left: 1%;
            margin-top: -0.2%;
        }
               /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         #divErrorRsnAWMS {
    border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
}

     </style>
    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
              
          });


          </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

          function OpenCancelView() {



              document.getElementById("MymodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=txtCnclReason.ClientID%>").focus();

              return false;

          }
          function CloseCancelView() {
              if (confirm("Do you want to close  without completing Cancellation Process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
          }

          function ReCallAlert(href) {

              if (confirm("Do you want to Recall this Entry?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }

    </script>
          <style>

        #cphMain_btnNext.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        #cphMain_btnPrevious.aspNetDisabled {
            width: 202px;
            height: 33px;
            margin-top: -5px;
            font-size: 13px;
            cursor: default;
        }
        .searchlist_btn_rght {
            cursor: pointer;
        }
           input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
        }
        #a_Caption:hover {
        color: rgb(83, 101, 51);
        
        }
        #a_Caption {
        color: rgb(88, 134, 7);
        
        }
        #a_Caption:focus {
        color: rgb(83, 101, 51);
        
        }
         .searchlist_btn_lft:hover {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        .searchlist_btn_lft:focus {
        background:url(/Images/Design_Images/images/search-hover.png) no-repeat 0 0;
        
        }
        input[type="submit"][disabled="disabled"] {
            background-color: #9c9c9c;
            cursor:default;
        }
         .searchlist_btn_rght:hover {
                background: #7B866A;
            }
             .searchlist_btn_rght:focus {
                background: #7B866A;
            }
    </style>
    <script type="text/javascript">
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Details Updated Successfully.";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Cancelled Successfully.";
        }
        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Recalled Successfully.";
        }
        function SuccessStatusChange() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Status Changed Successfully.";
        }
        function SuccessStatusDefaultChange() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Default Status Changed Successfully.";
        }
        function DuplicationName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Recall Denied.Template Name Can't Be Duplicated.";
        }
        function FailedConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notification Template Details Insertion Failed.Please Try Again";
        }
        function getdetails(href) {
            window.location = href;
            return false;
        }
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
            return false;

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
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

            }
        </script>

   <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bLengthChange": false,
                "bSort": true,
                "pageLength": 25
            });
        });


    </script>



    <style>
        #cphMain_divReport {
            float: left;
            width:100%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 100%;
        }
    </style>

    <script>

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }

        //validation when cancel process
        function ValidateCancelReason() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
            if (Reason == "") {
                document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }


        function SearchValidation() {
            ret = true;
            var ddlDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;
           
             var ddlGCat = document.getElementById("<%=ddlGCatagry.ClientID%>").value;
           
            var ddlBank = document.getElementById("<%=ddlBank.ClientID%>").value;
           

        
            

             if (ret == true) {

                 document.getElementById("<%=HiddenSearchField.ClientID%>").value = ddlDivision + ',' + ddlGCat +',' + ddlBank;
             }


             return ret;

         }


         function ChangeStatus(CatId, CatStatus) {
             if (confirm("Do You Want To Change The Status Of This Entry?")) {
                 var SearchString = document.getElementById("<%=HiddenSearchField.ClientID%>").value;
                var Details = PageMethods.ChangeTemplateStatus(CatId, CatStatus, function (response) {
                    var SucessDetails = response;

                    if (SucessDetails == "success") {
                        if (SearchString == "") {
                            window.location = 'gen_Notification_Template_List.aspx?InsUpd=StsCh';
                        }
                        else {
                            window.location = 'gen_Notification_Template_List.aspx?InsUpd=StsCh&Srch=' + SearchString + '';
                        }


                    }
                    else {
                        window.location = 'gen_Notification_Template_List.aspx?InsUpd=Error';
                    }
                });
            }
            else {
                return false;
            }
        }

        function ChangeDefaultStatus(CatId, CatStatus) {
            if (confirm("Do You Want To Change The Default Status Of This Entry?")) {
                var SearchString = document.getElementById("<%=HiddenSearchField.ClientID%>").value;
                var Details = PageMethods.ChangeTemplateDefault(CatId, CatStatus, function (response) {
                    var SucessDetails = response;

                    if (SucessDetails == "success") {
                        if (SearchString == "") {
                            window.location = 'gen_Notification_Template_List.aspx?InsUpd=StsDfltCh';
                        }
                        else {
                            window.location = 'gen_Notification_Template_List.aspx?InsUpd=StsDfltCh&Srch=' + SearchString + '';
                        }


                    }
                    else {
                        window.location = 'gen_Notification_Template_List.aspx?InsUpd=Error';
                    }
                });
            }
            else {
                return false;
            }
        }

        function printredirect() {


            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#PrintTable')[0].outerHTML;

            // $("#cphMain_divPrintReportSorted table").dataTable();
            var resultCurrcy = [];
            var result = 0;
            var incrmnt = 0;
            var MainTable = $p('#cphMain_divPrintReportSorted table tr');
            $p('#cphMain_divPrintReportSorted table tr').each(function () {


                var lgth = MainTable.length;

                //$p('td', this).each(function (index, val) {

                //    if (index == 10) {
                //        if (!resultCurrcy[10]) resultCurrcy[10] = "";

                //        resultCurrcy[incrmnt] += $(val).text();
                //        incrmnt++;
                //    }

                //});
                // alert($p('#cphMain_divPrintReportSorted table tr'));

                //$p(resultCurrcy).each(function () {

                //});
                //  alert($(val).text());

                $p('td', this).each(function (index, val) {
                
                    if (index == 9) {


                        //  if (!result[index]) result[index] = 0;
                       // var res=parseFloat($(val).text());
                        //   alert(res);
                     
                        result += parseFloat($(val).text().replace(/,/g, ""));
                       // result += parseFloat($(val).text().replace(",", ""));
                        //alert(result);
                    }

                });




            });

            $p('#cphMain_divPrintReportSorted table').append('<tr ></tr>');

            //$p(result).each(function (index, val) {
            // alert(index);
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var n = result;
            if (FloatingValue != "") {
                n = result.toFixed(FloatingValue);
            }

            addCommas(n);
           // alert()

           //  $("#DropDownlist:selected").val();

           //  var Text = ddlReport.options[ddlReport.selectedIndex].text; $p('#cphMain_divPrintReportSorted table tr')
            var cnt = 0;
            var dec = cnt.toFixed(FloatingValue);
            if (document.getElementById("<%=HiddenFieldAmount.ClientID%>").value != dec) {
              //  $p('#cphMain_divPrintReportSorted table ').last().append('<td style="text-align: right;" colspan=9 >Total<td style="text-align: right;">' + document.getElementById("<%=HiddenFieldAmount.ClientID%>").value  + '<td  style="text-align: left;">'+document.getElementById("<%=HiddenCurrency.ClientID%>").value+'</td></td></td>')
            }
           // });

        }

        </script>
    
<script>
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

    </script>
     <style>


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
      <asp:HiddenField ID="HiddenField1" runat="server" />
      <asp:HiddenField ID="HiddenFieldAmount" runat="server" />
      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
      <asp:HiddenField ID="hiddenDecimalCount" runat="server" />

         <asp:HiddenField ID="HiddenCurrency" runat="server" />

    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
    
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    
     
     <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
      <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenMemorySize" runat="server" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    
    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
    <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4.5%;color:rgb(83, 101, 51);font-family:Calibri;margin-right: 6.5%;width: 6%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 36%"; >CSV </a> 
     <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:4.5%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="/Reports/Print/SortedPrint.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 50%">
                                Print</a>                                    
                                </div>
      <div style="cursor: default; float: right; height: 25px; margin-right:1.5%;margin-top:4.5%;font-family:Calibri; display:none;" class="print" onclick="printredirectt()">            
                                 <a id="print_cap" target="_blank" data-title="Supplier Wise Guarantee Report"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Expired-Guarantees-report.png" style="vertical-align: middle;" />
           Expired Bank Guarantee Report
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%;margin-top:1%;">

         <div style="float:left;width:98%">
                        <%--  <div class="eachform" style="width: 38%; padding-left: 0.5%;padding-top:1% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 5%;">Template Type* </h2>

            <asp:DropDownList ID="ddlTempType" class="form1" TabIndex="1"  style="height:25px;width:57%;margin-right: 9%;" runat="server"></asp:DropDownList>


        </div>--%>
           


           <%-- <div class="eachform" style="width: 100%; padding-left: 0.5%;padding-top:1% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 5%;">Contractor Category </h2>

            <asp:DropDownList ID="ddlContrctrType" class="form1" TabIndex="2"  style="height:25px;width:52%;margin-right: 4%;" runat="server">

                </asp:DropDownList>
        </div>--%>
               
           
       

                    
                 <div id="divDivision " class="eachform" style="width: 40%; float: Left;margin-top: .5%;">
                    <h2 style="margin-left: 8%;margin-top: 2%;width: 16%;">Division </h2>
                   
                    <asp:DropDownList ID="ddlDivision"   class="form1" Style="float: right; width: 55.2% !important; margin-right: 14%;margin-top: 1%;" runat="server" >
                    </asp:DropDownList>
                </div>

              <div id="DivCGuarantee" class="eachform" style="width: 40%;margin-top:1%;">

                <h2 style="margin-top:1%;width: 35%;">Guarantee Method </h2>

                <asp:DropDownList ID="ddlGCatagry" Height="30px"  Width="160px" class="form1" runat="server" Style="height:30px;width:58.2%;float:left; margin-left: 5%;">
                   
                </asp:DropDownList>


            </div>
              
            <div class="eachform" style="width: 40%;padding-top:1% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 9%;">Bank</h2>

            <asp:DropDownList ID="ddlBank" class="form1"   style="height:28px;width:55%;margin-left: 14.7%; float:left" runat="server">

                </asp:DropDownList>
        </div>

                  <div id="Div1" class="eachform" style="width: 40%;margin-top:1%;">

                <h2 style="margin-top:1%;width: 35%;">Currency </h2>

                <asp:DropDownList ID="ddlCurrency" Height="30px"  Width="160px" class="form1" runat="server" Style="height:30px;width:58.2%;float:left; margin-left: 5.1%;">
                   
                </asp:DropDownList>


            </div>
                <div class="eachform" style="width:12%;float: right;margin-right: 2%;margin-top: 1%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 0%;float:left;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  />
                     </div>
             
                 </div>
            <br style="clear: both" />
            </div>
        <br />


        <table style="width:72%;">
            <tr>
                <td style="width:28%;">
                    <asp:Button ID="btnPrevious" style=" float:left; font-size: 13px;" Enabled="false"  Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click"  />
          </td>
                <td style="width:25%;">

        <asp:Button ID="btnNext"  Width="98%" Margin-Left="5px"  style=" float:left; font-size: 13px;" runat="server" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click"  />
               </td>
                <td style="width: 19%;color: #6e7464;"> <asp:Label ID="Label1" runat="server" >Total number of records:</asp:Label></td>
                 <td > <asp:Label style="color: #6e7464;" ID="lblToalRowCount" runat="server" ></asp:Label></td>
               </tr>
        </table>

      <%--  <div onclick="location.href='gen_Notification_Template.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">--%>

          <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
       <%-- </div>--%>
        <%--  <br />
        <br />--%>
       
        <div id="divReport" class="table-responsive" runat="server">
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
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
         <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
        <div id="divTitle" runat="server" style="display: none"></div>
         <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Notification Template</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                        <%-- <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />--%>
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    </div>
   
</asp:Content>



