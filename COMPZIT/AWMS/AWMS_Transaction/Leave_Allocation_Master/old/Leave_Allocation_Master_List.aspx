<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="Leave_Allocation_Master_List.aspx.cs" Inherits="AWMS_AWMS_Transaction_Leave_Allocation_Master_Leave_Allocation_Master_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

             <style>
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
                 #divPagingTableContainer {
                     width:100%;
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
                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
                //  $au('#cphMain_ddlLeavTyp').selectToAutocomplete1Letter();
                $au('form').submit(function () {
                    //   alert($au(this).serialize());
                    //   return false;
                });
            });
        })(jQuery);

          </script>

     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              $noCon("div#divddlEmployee input.ui-autocomplete-input").select();
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
             if (confirm("Do you want to close  without completing cancellation process?")) {
                 document.getElementById('divMessageArea').style.display = "none";
                 document.getElementById('imgMessageArea').src = "";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                 document.getElementById("MymodalCancelView").style.display = "none";
                 document.getElementById("freezelayer").style.display = "none";
                 document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation details inserted successfully.";
        }

        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation details updated successfully.";
         }

         function SuccessCancelation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation cancelled successfully.";
        }
        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation recalled successfully.";
        }

        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation re-opened successfully.";
        }
        function Already_ReOpened() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Reopen denied. The selected leave allocation is already reopened state.";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave allocation confirmed successfully.";
        }
        function Already_Confirmed() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirmation denied. The selected leave allocation is already confirmed state.";
        }
        function NoOfficer() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirmation denied.Selected employee does not have reporting officer.";
        }
        function DuplicationConfm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm denied.The selected days are already confirmed";
            }
        function getdetails(href) {
            window.location = href;
            return false;
        }

        function CancelAlert(href) {

            if (confirm("Do you want to cancel this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        function ReCallAlert(href) {

            if (confirm("Do you want to recall this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function ReOpenAlert() {

            if (confirm("Do you want to Re-Open this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
        function ConfirmAlert() {

            if (confirm("Do you want to confirm this Entry?")) {
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
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function SearchValidation() {
            $('.ddlEmployeeClass').css({ 'border-style': 'solid', 'border-color': '' })

            if (document.getElementById("cphMain_ddlLeaveCategory").value == "1" || document.getElementById("cphMain_ddlLeaveCategory").value == "2") {
                if (document.getElementById("cphMain_ddlEmployee").value == "--SELECT--") {
                    $('.ddlEmployeeClass').css({ 'border-style': 'solid', 'border-color': 'red' })
                    $('.ddlEmployeeClass').focus();

                    return false;
                }
            }

            var searchStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var searchyear = document.getElementById("<%=ddlModalYear.ClientID%>").value;
            var searchemply = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");
            var cbx = 0;

            if (cbxStatus.checked) {
                cbx = 1;
                document.getElementById("<%=HiddenSearchField.ClientID%>").value = searchyear + ',' + searchStatus + ',' + searchemply + ',' + cbx;
            }
            else {
                cbx = 0;
                document.getElementById("<%=HiddenSearchField.ClientID%>").value = searchyear + ',' + searchStatus + ',' + searchemply + ',' + cbx;
            }

            document.getElementById("<%=HiddenSearchField.ClientID%>").value = searchyear + ',' + searchStatus + ',' + searchemply + ',' + cbx;
          

            //  if (SearchWord == "") {
            //      document.getElementById("<%=HiddenSearchField.ClientID%>").value = "" + ',' + searchStatus + ',' + cbx;
            //     return true;
            //   }
            //    else {
            //  if (SearchWord.length >= 3) {

            //      document.getElementById("<%=HiddenSearchField.ClientID%>").value = searchyear + ',' + searchStatus + ',' + cbx;
            //    return true;
            // }
            //  else {

            //   document.getElementById("<%=HiddenSearchField.ClientID%>").value = "" + ',' + searchStatus + ',' + cbx;
            //   return true;
            //  }
            LoadList();
            return false;
        }
        // }

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
        function DisableEnter(evt) {
            //  var b = new Date(); alert(b);

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }


        </script>

      <%--  for giving pagination to the html table--%>
    <script src="../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />
      <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
     <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <style>
        .datesort {
            display:none;
        }
        #TableRprtRow .tdT {
            line-height: 100%;
        }
        .cont_rght {
            width: 98%;
        }
        .pagination > .active > a, .pagination > .active > a:focus, .pagination > .active > a:hover, .pagination > .active > span, .pagination > .active > span:focus, .pagination > .active > span:hover {
    z-index: 3;
    color: 
#fff;
cursor: default;
background-color:
#9ba48b;
border-color:
    #337ab7;
}
    </style>

     <script>
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

        </script>
      <script>

          //--------------------------------------Pagination--------------------------------------
          var $p11 = jQuery.noConflict();
          $p11(document).ready(function () {
              Load_dt();
              getdata(1);

          });

          function LoadList() {
              getdata(1);
              return false;
          }

          //Efficiently Paging Through Large Amounts of Data
          var intOrderByColumn = 0;
          var intOrderByStatus = 1;
          var intToltalSearchColumns = 0;

          //------------Load column filters and table----------

          function Load_dt() {

              var strPagingTable = '';
              strPagingTable += '<div id="divHeader_dt"></div>';
              strPagingTable += '<div><table id="tblPagingTable" class="main_table" style="width:100%;">';
              strPagingTable += '<thead class="main_table_head"><tr id="trPagingTableHeading"></tr></thead>';
              strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
              strPagingTable += '</table></div>';

              $("#divPagingTableContainer").html(strPagingTable);

              intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

              var url = "/AWMS/AWMS_Transaction/Leave_Allocation_Master/Leave_Allocation_Master_List.aspx/LoadStaticDatafordt";
              $.ajax({
                  type: 'POST',
                  dataType: 'json',
                  contentType: "application/json; charset=utf-8",
                  url: url,
                  success: function (result) {
                      $("#divHeader_dt").html(result.d[0]);
                      $("#thPagingTable_SearchColumns").html(result.d[1]);
                      intToltalSearchColumns = result.d[2];
                      //bind on paste event to enable search on paste via mouse
                      $("input").on('paste', function (e) {
                          setTimeout(function () { $(e.target).keyup(); }, 100);
                      });
                  },
                  error: function () {
                      Error();
                  }
              });
          }

          //-----------Load datatable & pagination----------

          function getdata(strPageNumber) {
              document.getElementById("divPagingTable_processing").style.display = "";
              var strPageSize = 10;
              var strCommonSearchString = "";
              var strInputColumnSearch = getColumnSearchData();//individual column search
              if (document.getElementById("txtCommonSearch_dt")) {
                  strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                  strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
              }
              if (document.getElementById("ddl_page_size")) {
                  strPageSize = document.getElementById("ddl_page_size").value;
              }
              var strOrgId = '<%= Session["ORGID"] %>';
              var strCorpId = '<%= Session["CORPOFFICEID"] %>';
              var strddlCtgry = document.getElementById("<%=ddlLeaveCategory.ClientID%>").value;
              var strddlYear = document.getElementById("<%=ddlModalYear.ClientID%>").value;
              var strddlEmployee = document.getElementById("<%=ddlEmployee.ClientID%>").value;
              var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
              var strCancelStatus = 0;
              if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                strCancelStatus = 1;
             }
             var strEnableModify = document.getElementById("<%=hiddenRoleUpdate.ClientID%>").value;
             var strEnableCancel = document.getElementById("<%=hiddenRoleCancel.ClientID%>").value;
             var strEnableConfirm = document.getElementById("<%=HiddenFieldConfirm.ClientID%>").value;
             var strEnableReopen = document.getElementById("<%=hiddenRoleReOpen.ClientID%>").value;
             var strHiddenSearch = document.getElementById("<%=HiddenSearchField.ClientID%>").value; 
             var strEnableRecall= document.getElementById("<%=hiddenRoleRecall.ClientID%>").value;
             var url = "/AWMS/AWMS_Transaction/Leave_Allocation_Master/Leave_Allocation_Master_List.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.ddlCtgry = strddlCtgry;
             objData.ddlYear = strddlYear;
             objData.ddlEmployee = strddlEmployee;
             objData.ddlStatus = strddlStatus;
             objData.CancelStatus = strCancelStatus;
             objData.EnableModify = strEnableModify;
             objData.EnableCancel = strEnableCancel;
             objData.EnableConfirm = strEnableConfirm;
             objData.EnableReopen = strEnableReopen;
             objData.EnableRecall = strEnableRecall;            
             objData.HiddenSearch = strHiddenSearch;
             objData.PageNumber = strPageNumber;
             objData.PageMaxSize = strPageSize;
             objData.strCommonSearchTerm = strCommonSearchString;
             objData.OrderColumn = intOrderByColumn;
             objData.OrderMethod = intOrderByStatus;
             objData.strInputColumnSearch = strInputColumnSearch;
          
             $.ajax({
               
                 type: 'POST',
                 data: JSON.stringify(objData),
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {

                     $('#trPagingTableHeading').html(result.d[0]);
                     $('#tblPagingTable tbody').html(result.d[1]);

                     $("#cphMain_divReport").html(result.d[2]);//datatable

                     var intToltalColumns = document.getElementById('tblPagingTable').rows[1].cells.length;

                     var intAdditionalCoumns = intToltalColumns - (intToltalSearchColumns);

                     if (intAdditionalCoumns < 0) {
                         intAdditionalCoumns = 0;
                     }
                     $("#thPagingTable_thAdjuster").attr('colspan', intAdditionalCoumns);

                     if (document.getElementById("td_No_data_row_dt")) {
                         $("#td_No_data_row_dt").attr('colspan', intToltalColumns);
                     }

                     //enable sort icon 

                     if (intOrderByStatus == 1) {
                         $("#tdColumnHead_" + intOrderByColumn).addClass("asc");
                     }
                     else {
                         $("#tdColumnHead_" + intOrderByColumn).addClass("desc");
                     }

                     document.getElementById("divPagingTable_processing").style.display = "none";

                 },
                 error: function () {
                     Error();
                 }
             });
             return false;
         }


         function getColumnSearchData() {

             //this function collects data from input column search boxes and along with the id
             //— ‡
             var inputSearchTerms = "";
             for (var intSearchColumnCount = 0; intSearchColumnCount < intToltalSearchColumns; intSearchColumnCount++) {
                 if (document.getElementById("txtSearchColumn_" + intSearchColumnCount)) {
                     var searchString = document.getElementById("txtSearchColumn_" + intSearchColumnCount).value.trim();
                     if (searchString != "") {

                         searchString = ValidateSearchInputData(searchString);

                         if (inputSearchTerms == "") {
                             inputSearchTerms = intSearchColumnCount + "‡" + searchString;
                         } else {
                             inputSearchTerms += "—" + intSearchColumnCount + "‡" + searchString;
                         }
                     }
                 }
             }
             return inputSearchTerms;
         }
         function SetOrderByValue(intOrderBy) {
             intOrderByColumn = intOrderBy;
             if (intOrderByStatus == 1) {
                 intOrderByStatus = 0;
             }
             else {
                 intOrderByStatus = 1;
             }
             //redraw
             getdata(1);
         }
         function ValidateSearchInputData(strSearchString) {
             var text = strSearchString;
             var replaceText1 = text.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             var replaceText3 = replaceText2.replace(/'/g, "");
             strSearchString = replaceText3;
             if (strSearchString.length > 100) {
                 strSearchString = strSearchString.substring(0, 100);
             }
             else {
             }
             return strSearchString;
         }

         //Efficiently Paging Through Large Amounts of Data

         //setup before functions
         var typingTimer;                //timer identifier
         var doneTypingInterval = 1000;  //time in ms (5 seconds)

         function SettypingTimer() {
             //on keyup, start the countdown
             clearTimeout(typingTimer);
             typingTimer = setTimeout(doneTyping, doneTypingInterval);
         }
         //user is "finished typing," do something
         function doneTyping() {
             //do something
             getdata(1);
         }
         //--------------------------------------Pagination--------------------------------------

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <br />
    
     <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>

    

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>

            <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">

            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/Leave_Allocation.png" style="vertical-align: middle;"  />   <asp:Label ID="lblEntry" runat="server">Leave Allocation</asp:Label>
            </div>
   <%--0006 start--%>
        <br/>
        <div id="divddlEmployee" style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 100%;padding-bottom: 1.5%;padding-top: 1.5%;">


              <div class="eachform" style="width: 40%; padding-left: 0.5%;float: left;">

                <h2 style="margin-top: 1%;width: 28%;">Leave Category</h2>

                <asp:DropDownList ID="ddlLeaveCategory" class="form1" tabindex="3" onkeydown="return DisableEnter(event)" style="height:25px;width:50%;float: left;" runat="server">
                     <asp:ListItem Text="Leave Allocation" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Leave Request" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Daily Attendace" Value="2"></asp:ListItem>
                   
                </asp:DropDownList>
            </div>

                    <div class="eachform" id="divModalYear" style="width: 28%; padding-left: 0.5%;float: left;">
                     <h2 style="width: 26%;margin-top:1%;" >Year*</h2>
                 <asp:DropDownList ID="ddlModalYear" tabindex="2" class="form1" onkeydown="return DisableEnter(event)" style="height:25px;width:45%;float: left;" runat="server"></asp:DropDownList>

                </div>


            <div class="subform" style="width:18%;float: left;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" tabindex="4" Checked="false" class="form2" onkeypress="return DisableEnter(event)"/>
                    <%--<asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" tabindex="4" Checked="false" class="form2" onkeypress="return DisableEnter(event)"/>--%>
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
             </div>
            <br/> <br/> <br/>

                    <div class="eachform" style="width: 40%; padding-left: 0.5%;float: left;">

                <h2 style="margin-top: 1%;width: 28%;">Employee</h2>
                <asp:DropDownList ID="ddlEmployee" tabindex="1" class="form1 ddlEmployeeClass" onkeydown="return DisableEnter(event)" style="height:25px;width:46%;float: left;" runat="server">                   
                </asp:DropDownList>
            </div>

                <div class="eachform" style="width: 28%; padding-left: 0.5%;float: left;">
                <h2 style="width: 26%;margin-top:1%;">Status*</h2>
                <asp:DropDownList ID="ddlStatus" class="form1" tabindex="3" onkeydown="return DisableEnter(event)" style="height:25px;width:45%;float: left;" runat="server">
                     <asp:ListItem Text="Not Confirmed" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>                      
                     <asp:ListItem Text="All" Value="0"></asp:ListItem>                 
                </asp:DropDownList>

            </div>                       
  
          <div style="width: 18%;" class="eachform">
            <asp:Button ID="btnSearch" tabindex="6" style="margin-top:-0.4%; cursor:pointer; width: 104px;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();" />

        </div>
            </div>
                
        <%--stop 0006--%>

        <br />




        <div onclick="location.href='Leave_Allocation_Master.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:0.5%;z-index:1000;width:80px;">

           <%-- <a href="gen_Product_Category.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
         <asp:HiddenField ID="hiddenNext" runat="server" />
        <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenMemorySize" runat="server" />
         <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
         <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
         <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
        <asp:HiddenField ID="hiddenRoleRecall" runat="server" />
        <asp:HiddenField ID="hiddenCommodityValue" runat="server" />
         <asp:HiddenField ID="hiddenRoleReOpen" runat="server" />
         <asp:HiddenField ID="HiddenSearchField" runat="server" />
          <asp:HiddenField ID="HiddenFieldConfirm" runat="server" />
        <%--  <br />
        <br />--%>

         <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="table-responsive" style="width:100%;margin-top:-2%;"></div>


                  
                <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;"> Leave Allocation </h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();"  runat="server" Text="Close" />
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