<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Modal.master" AutoEventWireup="true" CodeFile="gen_Modify_Insurance_Master_List.aspx.cs" Inherits="GMS_GMS_Master_gen_Insurance_Master_gen_Modify_Insurance_Master_List" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <link href="/css/bootstrap.min.css" rel="stylesheet" />


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
          input[type="radio"] {
    display: inline-block;
}
      .open > .dropdown-menu {
    display: none;
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

    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

     <script type="text/javascript">
         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {

             document.getElementById("freezelayer").style.display = "none";
             document.getElementById('MymodalCancelView').style.display = "none";
             var ClosePrimaryId = document.getElementById("<%=hiddenRsnidclose.ClientID%>").value;
             if (ClosePrimaryId != "") {
                 OpenCloseView();
             }

             var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
         });


          </script>
   
       <script>

           var $Mo = jQuery.noConflict();

           function OpenCloseView() {
               document.getElementById("MymodalCloseView").style.display = "block";
               document.getElementById("freezelayer").style.display = "";
               document.getElementById("<%=TxtCloseReson.ClientID%>").focus();
               return false;
           }

           function CloseCloseView() {
               if (confirm("Do you want to close  without completing Closing Process?")) {
                   document.getElementById('divMessageArea').style.display = "none";
                   document.getElementById('imgMessageArea').src = "";
                   document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCloseView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnidclose.ClientID%>").value = "";
              }
          }

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

          function PrintAlert(href) {

              if (confirm("Do you want to Take a Print?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }

          function DuplicationRFQ() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Request For Guarantee Can’t be Duplicated.";


        }
        function Duplication() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Guarantee Number Can’t be Duplicated.";


        }
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Details Inserted Successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Details Updated Successfully.";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Cancelled Successfully.";
        }
        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Recalled Successfully.";
        }
        function SuccessStatusChange() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Status Changed Successfully.";
        }
        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Details ReOpened Successfully.";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Details Confirmed Successfully.";
        }
        function SuccessClose() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Insurance Details Closed Successfully.";
         }
         function getdetails(href) {
             window.location = href;
             return false;
         }

         function ConfirmClose() {


             if (confirm("Are You Sure You Want To Close?")) {
                 window.location = href;
                 return true;
             }
             else {

                 // CheckSubmitZero();
                 return false;
             }

         }
         function closeWindow() {
             window.close();
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

         function getdetails(href) {
             window.location = href;
             return false;
         }
         function ConfirmGtee(href, expStatus) {
             if (expStatus == "1") {
                 if (confirm("Insurance has been expired already. Are you sure you want to continue?")) {
                     // ret = true;
                     window.location = href;
                     return false;
                 }
                 else {

                     // CheckSubmitZero();
                     return false;
                 }
             }
             else {
                 if (confirm("Are You Sure You Want To Confirm?")) {
                     window.location = href;
                     return false;
                 }
                 else {
                     return false;
                 }

             }
         }
         function StatusCheck() {

             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm Denied. Entry Is Already Confirmed.";

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
                "bSort": false,
                "pageLength": 25,
                "bPaginate": false
            });
        });
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
                        #cphMain_divReport {
            float: left;
            width: 97.5%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
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

        function ValidateCloseReason() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=TxtCloseReson.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=TxtCloseReson.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorCloseRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=TxtCloseReson.ClientID%>").style.borderColor = "";
                var Reason = document.getElementById("<%=TxtCloseReson.ClientID%>").value.trim();
            if (Reason == "") {
                document.getElementById('divErrorCloseRsnAWMS').style.visibility = "visible";
                document.getElementById("<%=lblErrorCloseRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=TxtCloseReson.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorCloseRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorCloseRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                        var txthighlit = document.getElementById("<%=TxtCloseReson.ClientID%>").style.borderColor = "Red";
                        return false;
                    }
                }
            }

            function SearchValidation() {
                ret = true;

                //var ddlSuplr;
                var CrdExpWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtFromDate.ClientID%>").value = replaceCode2;

            var CrdExpWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=txtToDate.ClientID%>").value = replaceCode2;

            var CrdExpWithoutReplace = document.getElementById("<%=ExpiryDate.ClientID%>").value;
            var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
            var replaceCode2 = replaceCode1.replace(/>/g, "");
            document.getElementById("<%=ExpiryDate.ClientID%>").value = replaceCode2;

            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
            var varGarntSts = document.getElementById("<%=ddlGuaranteeStatus.ClientID%>").value;
            var InsuranceTyp = document.getElementById("<%=ddlInsuranceTyp.ClientID%>").value;
            var InsurancePrvdr = document.getElementById("<%=ddlInsurncPrvdr.ClientID%>").value;

            var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");
            var EspireDate = document.getElementById("<%=ExpiryDate.ClientID%>").value;

            var InsTypMstr = document.getElementById("<%=ddlsearch.ClientID%>").value;

            var cbx = 0;
            // alert(cbxStatus.checked);
            if (cbxStatus.checked) {
                cbx = 1;
            }
            else {
                cbx = 0;
            }


            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = FromDate + ',' + ToDate + ',' + InsuranceTyp + ',' + EspireDate + ',' + cbx + ',' + InsurancePrvdr + ',' + varGarntSts + ',' + InsTypMstr;
            }


            return ret;

        }

        function ExpiryDateChk() {

            var ExpireDate = document.getElementById("<%=ExpiryDate.ClientID%>").value.trim();
             //alert(ExpireDate);
             var arrDateExpireDate = ExpireDate.split("-");
             var datearrDateExpireDate = new Date(arrDateExpireDate[2], arrDateExpireDate[1] - 1, arrDateExpireDate[0]);


             var CurrentDate = document.getElementById("<%=HiddenCurrentDate.ClientID%>").value;

            var arrDateCurrentDate = CurrentDate.split("-");

            var datearrDateCurrentDate = new Date(arrDateCurrentDate[2], arrDateCurrentDate[1] - 1, arrDateCurrentDate[0]);

            if (datearrDateExpireDate < datearrDateCurrentDate) {

                document.getElementById("<%=ExpiryDate.ClientID%>").value = "";
            }

            return false;
        }

        function printredirect() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            $('#cphMain_divPrintReportSorted table tr').find('td:eq(7),th:eq(7),td:eq(8),th:eq(8),td:eq(9),th:eq(9),td:eq(10),th:eq(10),td:eq(11),th:eq(11),td:eq(12),th:eq(12)').remove();
        }

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="HiddenFieldRadioCusSupl" runat="server" />
    <asp:HiddenField ID="HiddenFieldRenew" runat="server" />
     <asp:HiddenField ID="hiddenFieldConfirm" runat="server" />
      <asp:HiddenField ID="hiddenRsnidclose" runat="server" />
    <asp:HiddenField ID="hiddenRoleClose" runat="server" />
    <asp:HiddenField ID="HiddenIntCanlId" runat="server" />
     <asp:HiddenField ID="HiddenGurantNum" runat="server" />
     <asp:HiddenField ID="HiddenFieldSuplier" runat="server" />
       <asp:HiddenField ID="HiddenFieldClient" runat="server" />

    <asp:HiddenField ID="hiddenCommodityValue" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
      <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenNext" runat="server" />
      <asp:HiddenField ID="hiddenPrevious" runat="server" />
      <asp:HiddenField ID="HiddenCurrentDate" runat="server" />
  <asp:HiddenField ID="hiddenRowCount" runat="server" />
      <div style="display:none; cursor: default; float: right; height: 25px; margin-right:7.5%;margin-top:4%;font-family:Calibri;" class="print" onclick="printredirect()">            
                                 <a id="A1" target="_blank" data-title="Item Listing"  href="/Reports/Print/SortedPrint.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                               Sorted Print</a>                                    
                                </div>

     <div style="display:none;cursor: default; float: right; height: 25px; margin-right:2.5%;margin-top:4%;font-family:Calibri;" class="print" onclick="printredirectt()">            
                                 <a id="print_cap" target="_blank" data-title="Item Listing"  href="/Reports/Print/28_Print.htm" style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                 Print</a>                                    
                                </div>

   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

     <div onclick="return false;'" id="divAdd" class="add" runat="server" style="display:none;position: fixed; height:26.5px; right:1%;z-index: 2;">
    </div>

     <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/InsuranceMstr.png" style="vertical-align: middle;" />
            Insurance
            <p id="pHeader" style="font-size: 16px;" runat="server"></p>
        </div >

     <%-- START EVM-0031 --%> 

 <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 97.5%; margin-top: 4%; height: 245px; margin-bottom: 1%;">


        <div style="width: 100%; float: left;">


            <div class="eachform" style="width: 36%; float: left; margin-top: 10px; margin-left: 19px; border: 1px solid; border-color: #9ba48b;">
    
                <h2 style="margin-top: 1%; margin-left: 15%">Insurance Provider</h2>

                <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 1%; float: left;">
                    <asp:DropDownList ID="ddlInsurncPrvdr" class="form1" Style="height: 25px; width: 79%; margin-left: 8%; margin-top: 0%; float: left; margin-bottom: 9px;" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
      
            <div class="eachform" style="width: 30%; height: 77px; float: left; margin-top: 10px; margin-left: 19px; border: 1px solid; border-color: #9ba48b;">
       
                <h2 style="margin-top: 1%; margin-left: 15%">Insurance Type</h2>
                <div>
                    <asp:DropDownList ID="ddlsearch" runat="server" class="form1" Style="margin-left: 38px; width: 243px; height: 26px; margin-bottom: 10px; float: left;"></asp:DropDownList>

                </div>
            </div>



            <div class="eachform" style="width: 27%; float: left; margin-top: 9px; margin-left: 18px; border: 1px solid; border-color: #9ba48b; height: 78px;">
    
                <h2 style="margin-top: 1%; margin-left: 10%">Insurance Expiry</h2>

                <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 0%; float: left;">
                    <div id="DivExpre" class="input-append date" style="font-family: Calibri; float: right; width: 89%; margin-right: 7%; margin-top: 1%;">
                        <asp:TextBox ID="ExpiryDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" onblur="return ExpiryDateChk();" runat="server" Style="width: 68.8%; height: 27px; font-family: calibri; float: left; margin-left: 4%;"></asp:TextBox>
                        <input type="image" id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 27px; float: left; width: 30px; cursor: pointer;" />

                        <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                        <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                        <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                        <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                        <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                        <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#DivExpre').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#DivExpre').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    startDate: new Date(),


                                });
                            }
                        </script>
                        <p style="visibility: hidden">Please enter</p>
                    </div>
                </div>

            </div>
            
            

        </div>

        <div style="width: 100%; float:left;">


            <div class="eachform" style="width: 52%;float: left;margin-top: 0px;border: 1px solid;border-color: #9ba48b;padding: 16px;margin-left: 18px;">

                <h2 style="margin-top: 0.5%; margin-left: 2%;">Insurance Date</h2>
                <div class="subform" style="padding-left:0.5%; padding-top: 7%; float: left; margin-left: -23%;">
           
                    <h2 style="margin-top:0.5%; margin-left: 5%;">From</h2>

                    <div id="Div3" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right: 7%; margin-top: 1%;">
                        <asp:TextBox ID="txtFromDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 82.8%; height: 27px; font-family: calibri; float: left; margin-left: -29%;"></asp:TextBox>
                        <input type="image" id="img2" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 27px; float: left; width: 30px; cursor: pointer;" />

                        <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                        <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                        <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                        <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                        <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                        <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#Div3').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#Div3').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //startDate: new Date(),


                                });
                            }
                        </script>
                        <p style="visibility: hidden">Please enter</p>
                    </div>
                </div>
     
                <div class="subform" style="padding-left:0.5%;padding-top: 7%; float: left;">
       
                    <h2 style="margin-top: 0.5%;margin-left: 5%;">To </h2>

                    <div id="ClosingDate" class="input-append date" style="font-family: Calibri; float: right; width: 50%; margin-right:7%; margin-top: 1%; margin-bottom: -3px;">
                        <asp:TextBox ID="txtToDate" class="textDate form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 82.8%; height: 27px; font-family: calibri; float: left; margin-left: -29%;"></asp:TextBox>
                        <input type="image" id="img1" class="add-on" src="/Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" onblur="return TextDateChange()" style="height: 27px; float: left; width: 30px; cursor: pointer;" />

                        <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
                        <script src="../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
                        <script src="../../../JavaScript/Date/bootstrap-datepicker.js"></script>
                        <script src="../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
                        <link href="../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
                        <link href="../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />
                        <script type="text/javascript">
                            var $noC2 = jQuery.noConflict();
                            $noC2('#ClosingDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                //  startDate: new Date(),


                            });
                            function FocusOnDate() {

                                $noC2('#ClosingDate').datetimepicker({
                                    format: 'dd-MM-yyyy',
                                    language: 'en',
                                    pickTime: false,
                                    //  startDate: new Date(),


                                });
                            }
                        </script>
                        <p style="visibility: hidden">Please enter</p>
                    </div>

                </div>

            </div>

 
            <div class="eachform" style="width: 17%;float: left;margin-top: 0px;margin-left: 6px;border: 1px solid;border-color: #9ba48b;margin-right: 7px;height: 103px;padding-top: 21px;">
             
                <h2 style="margin-top: 1%; margin-left: 15%">Insurance Status</h2>

                <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 1%; float: left;">
                    <asp:DropDownList ID="ddlGuaranteeStatus" class="form1" Style="height:25px; width: 79%; margin-left: 8%; margin-top: 0%; float: left; margin-bottom: 9px;" runat="server">
                        <asp:ListItem Text="New" Selected="True" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Confirmed" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Renewed" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Closed" Value="4"></asp:ListItem>
                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
    
            <div class="eachform" style="width:19%;float:right;margin-top:0px;margin-left:0px;border:1px solid;border-color:#9ba48b;margin-right:90px;height:102px;padding-top:18px;">

                <h2 style="margin-top: 1%; margin-left: 15%">Category</h2>
              
                <div class="eachform" style="width: 100%; padding-left: 0.5%; padding-top: 1%; float: left;">
                    <asp:DropDownList ID="ddlInsuranceTyp" class="form1" Style="height: 25px; width: 79%; margin-left: 9%; margin-top: 1%; margin-bottom: 3%; float: left;" runat="server">
                        <asp:ListItem Text="Open" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Limited" Value="2"></asp:ListItem>
                        <asp:ListItem Text="All" Selected="True" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div style="width: 20%; float: left; margin-top: 0%;">

                <div class="eachform" style="width: 100%; margin-top: 0%;">
                    <div class="subform" style="display: none; width: 215px; float: left; margin-left: 6%; margin-top: 8%;">

                        <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" />
                        <h3 style="margin-top: 1%;">Show Deleted Entries</h3>
                    </div>
                </div>

                <div class="eachform" style="width: 53%; float: right; margin-right: 29%; margin-top: 0%;">
          
                    <asp:Button ID="btnSearch" Style="cursor: pointer;margin-top: -20%;margin-left: 116px;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                </div>
            
                <br style="clear: both" />

            </div>

        </div>

    </div>


     <%-- END EVM-0031 --%> 

            <table style="width:35%;">
            <tr>
                <td style="width:28%;">
                    <asp:Button ID="btnPrevious" style=" float:left; font-size: 13px;" Enabled="false"  Width="98%" runat="server" class="searchlist_btn_rght" Text="Show Previous 500 Records" OnClick="btnPrevious_Click" />
          </td>
                <td style="width:25%;">

        <asp:Button ID="btnNext"  Width="98%" Margin-Left="5px"  style=" float:left; font-size: 13px;" runat="server" class="searchlist_btn_rght" Text="Show Next 500 Records" OnClick="btnNext_Click"  />
               </td>
               </tr>
        </table>

       <div class="modal-dialog" style="position: fixed; z-index: 30;top: 119px;left: 375px;display:none" id="alertdiv" role="document"><div class="modal-content"><div class="modal-header" style="color: #69583a;background: #a5b78f;"><button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return CloseAlert();">×</button><h3 class="modal-title" id="msgboxLabel">Alert!</h3></div><div class="modal-body"><div class="media"><div class="media-left"><i class="fa fa-info-circle fa-4x text-info"></i></div><div class="media-body">Please select a Insurance to modify!.</div></div></div><div class="modal-footer"><button data-dismiss="modal" class="btn btn-default" onclick="return CloseAlert();">Close</button></div></div></div>
        <asp:Button ID="btnmodify" Class="btn btn-primary btn-lg" runat="server" OnClientClick="return getselected()" OnClick="btnmodify_Click" style="float: right;margin-bottom: 1%;margin-right: 3%;width:10%" Text="Modify" />
       

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
        <div id="divtile" runat="server" style="display: none">Insurance</div>

         <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>


       <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Insurance</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   



              <div id="MymodalCloseView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCloseView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Insurance</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorCloseRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorCloseRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Close Reason*</label>
                        <asp:TextBox ID="TxtCloseReson" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_TxtCloseReson)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_TxtCloseReson,450)" onkeyup="textCounter(cphMain_TxtCloseReson,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="BtnCloseSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCloseReason();" OnClick="BtnCloseSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnCloseCancl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCloseView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   


         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height:auto!important;"
                class="freezelayer" id="freezelayer">
                    </div>


       <style>

        textarea {
    overflow: auto;
    vertical-align: top;
}
        #cphMain_TxtCloseReson {
    font-family: Calibri;
}
        #divErrorCloseRsnAWMS {
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

     

        #ReportTable_filter input {
    height: 19px;
    width: 208px;
    color: #336B16;
    font-size: 14px;
}
             .open > .dropdown-menu {
    display: none;
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
    
        <script>
            function confirmalert() {
                document.getElementById("freezelayer").style.display = "";
                document.getElementById("alertdiv").style.display = "";

                return false;
            }
            function selectAllGuarantee() {
                var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
                var strAmntList = "";
                if (document.getElementById('cbxSelectAll').checked == true) {
                    for (i = 0; i < RowCount; i++) {

                        document.getElementById('cblguaranteelist' + i).checked = true;

                    }
                }
                else {
                    for (i = 0; i < RowCount; i++) {

                        document.getElementById('cblguaranteelist' + i).checked = false;

                    }
                }
            }




            $nonvonfl = jQuery.noConflict();
            function getselected() {

                var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
                var strAmntList = "";

                for (i = 0; i < RowCount; i++) {
                    // alert("dddddd");
                    if (document.getElementById('cblguaranteelist' + i) != undefined) {

                        if (document.getElementById('cblguaranteelist' + i).checked) {



                            strAmntList = strAmntList + document.getElementById('cblguaranteelist' + i).value + ',';
                        }
                    }
                }

                if (strAmntList != "") {

                    // return true;
                }
                else {

                    var ret = confirmalert();
                    return ret;
                }
               // alert(strAmntList);

                var assoc = {};
                var decode = function (s) { return decodeURIComponent(s.replace(/\+/g, " ")); };
                var queryString = location.search.substring(1);
                var keyValues = queryString.split('&');

                for (var i in keyValues) {
                    var key = keyValues[i].split('=');
                    if (key.length > 1) {
                        assoc[decode(key[0])] = decode(key[1]);
                    }
                }
                var id = assoc["Mody"];
                if (window.opener != null && !window.opener.closed) {

                    var nWindow1 = window.open('/GMS/GMS_Master/gen_Notification_Template/gen_Notification_Template.aspx?ModyIns=' + id + '&InsID=' + strAmntList, 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                    nWindow1.focus();

                }


                return false;

            }





            function CloseAlert() {
                document.getElementById("alertdiv").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                return false;
            }

    </script>

</asp:Content>



