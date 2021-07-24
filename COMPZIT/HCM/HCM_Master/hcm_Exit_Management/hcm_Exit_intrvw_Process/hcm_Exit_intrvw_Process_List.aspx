<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Exit_intrvw_Process_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_intrvw_Process_hcm_Exit_intrvw_Process_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
       <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <%-- <script src="/JavaScript/jquery-1.8.3.min.js"></script>
  --%>   <script>
             var $au = jQuery.noConflict();

             (function ($au) {
                 $au(function () {

                     $au('#cphMain_ddlDesg').selectToAutocomplete1Letter();
                     $au('#cphMain_ddlEmp').selectToAutocomplete1Letter();
                     $au('form').submit(function () {


                     });
                 });
             })(jQuery);
             </script>
     <script src="/JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">

          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              // alert();
              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });

       

          </script>
       <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": false,
                "pageLength": 25
            });
        });
    
          </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
<asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
            <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
      <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght" style="width:100%" >


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Request-for-guarantee.png" style="vertical-align: middle;" />
           Exit Interview Process
            <br>
        </div >
         <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 99.5%;margin-top:1%;">

         <div id="DivProject" class="eachform" style="width: 40%;margin-top:1%;">
                 <h2 style="margin-top: 1%; float: left; padding-right: 7%;margin-left: 7%;">Designation</h2>
                    <asp:DropDownList ID="ddlDesg" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
            </div>
        <div id="DivEmp" class="eachform" style="width: 40%;margin-top:1%;">
                 <h2 style="margin-top: 1%; float: left; padding-right: 7%;margin-left: 7%;">Employee</h2>
                    <asp:DropDownList ID="ddlEmp" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
            </div>
              <div class="eachform" style="width:15%;float: right;margin-right: 2%;margin-top: 1%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;float:left;" TabIndex="5" runat="server" class="searchlist_btn_lft" Text="Search"  OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                     </div>
          
               <br style="clear: both" />
         
            </div>
        <br>
        

     
        <%--  <br />
        <br />--%>

    <div id="divReport" class="table-responsive" runat="server"  style="width:100%">
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
    <script>
        function Successstatschanged() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Interview Process changed successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
      


    </script>
        <script>
            function CancelAlert(href) {

                if (confirm("Do you want to cancel this entry?")) {
                    window.location = href;
                    return false;
                }
                else {
                    return false;
                }
            }
            function CancelNotPossible() {
                alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
                return false;

            }
            function getdetails(href) {
                window.location = href;
                return false;
            }
            
            function CloseCancelView() {
                if (confirm("Do you want to close  without completing cancellation process?")) {
                    document.getElementById('divMessageArea').style.display = "none";
                    document.getElementById('imgMessageArea').src = "";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                    document.getElementById("MymodalCancelView").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";
                    document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
            }
            return false;
        }
    
        // for not allowing <> tags
        function isTag(evt) {
            // IncrmntConfrmCounter();
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
        function isTagWithEnter(evt) {
            //IncrmntConfrmCounter();
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
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
            else {
                return true;
            }
        }
        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Interview Process inserted successfully.";
             $(window).scrollTop(0);
         }
         //old
         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Interview Process updated successfully.";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Interview Process cancelled successfully.";
        }
        function ChangeStatus(catId) {
            if (confirm("Do you want to change the status of this entry?")) {

                //window.location = 'gen_Interview_CategoryList.aspx?StsCh=' + catId;
                return true;
            }
            else {
                return false;
            }
        }
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function IntervPrssId(id, UsrId) {

            var nWindow = window.open('/HCM/HCM_Master/hcm_Exit_Management/hcm_Exit_intrvw_Process/hcm_Exit_intrvw_Process.aspx?Id=' + id + '&RFGP=VW&UserId=' + UsrId + '&MstrId=', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
            // nWindow.focus();
        }
        function IntervPrssWithMstrId(id, UsrId,MstrId) {

            var nWindow = window.open('/HCM/HCM_Master/hcm_Exit_Management/hcm_Exit_intrvw_Process/hcm_Exit_intrvw_Process.aspx?Id=' + id + '&RFGP=VW&UserId=' + UsrId + '&MstrId=' + MstrId, 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
            // nWindow.focus();
        }
    </script>
    
   </asp:Content>


