<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Corp_DeptList.aspx.cs" Inherits="MasterPage_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
     <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script> 
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
   

    <script type="text/javascript">
        function SuccessConfirmation() {
            $("#success-alert").html("Department details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Department details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function SuccessCancelation() {
            $("#success-alert").html("Department cancelled successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }

        function getdetails(href) {
            window.location = href;
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
        function CancelNotPossible() {
            $("#divWarning").html("Sorry, Cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function OpenCancelView(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this department?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenFieldCancelReasMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        document.getElementById("cphMain_txtCancelReason").style.borderColor = "";
                        document.getElementById("cphMain_txtCancelReason").value = "";
                        $('#dialog_simple').modal('show');
                    }
                    else {
                        ReOpenConfByID(StrId, 0, strCancelReason, strCancelMust);
                        $('#dialog_simple').modal('hide');
                    }
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function ReOpenConfByID(StrId, Mode, reasonmust, cnclRsn) {
            //mode(0-Delete,1-confirm,3-reopen)
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userID = '<%= Session["USERID"] %>';
            var MasterDbId = StrId;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Corp_DeptList.aspx/ReOpenConfByID",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",userID: "' + userID + '",MasterDbId: "' + MasterDbId + '",Mode: "' + Mode + '",reasonmust: "' + reasonmust + '",cnclRsn: "' + cnclRsn + '"}',
                dataType: "json",
                success: function (data) {
                    window.location.href = "gen_Corp_DeptList.aspx?InsUpd=" + data.d;
                }
            });
            return false;
        }
        function SuccessSts() {
            $("#success-alert").html("Department status changed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ErrorCancelation() {
            $("#divWarning").html("Some error occurred.Try again!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server"> 
 <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />
    <asp:HiddenField ID="hiddenRsnid" runat="server" />
   <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenFieldCancelReasMust" runat="server" Value="0"/>
    <asp:HiddenField ID="HiddenFieldUpdRole" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCnclRole" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldCnclSts" runat="server" />
    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
        <li class="active">Corporate Department</li>
        
      </ol>
      <!---alert_message_section---->
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1 class="h1_con">Corporate Department</h1>

            <div class="form-group fg2 sa_fg4">
               <label for="email" class="fg2_la1">Status:<span class="spn1">*</span></label>
                 <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 inp_mst" runat="server">
                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                </asp:DropDownList>           
            </div>

             <div class="fg7_5 sa_fg4">
            <label class="form1 mar_bo mar_tp lb_wa">
              <span class="button-checkbox">
                <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
                <input type="checkbox" class="hidden" id="cbxCnclStatus" runat="server"/>
              </span>
              <p class="pz_s">Show Deleted Entries</p>
            </label>
          </div>

            <div class="fg2 sa_fg4">
            <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
            <asp:Button ID="btnSearch" class="submit_ser" runat="server"  OnClientClick="return LoadList();" />
            <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->
          </div>

              <div class="clearfix"></div>
              <div class="devider"></div>

      <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_800"></div>
      

        
        </div>
       
        </div>

      </div>
      
      <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static"    role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document" id="divCancelPopUp">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for cancel</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>

                    <textarea id="txtCancelReason" runat="server" placeholder="Write reason for cancel" rows="6" class="text_ar1" onblur="RemoveTag('cphMain_txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCancelReason,450)" onkeyup="textCounter(cphMain_txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">

                   <asp:Button ID="btnRsnSave" Text="Save" class="btn btn-success" runat="server"  OnClientClick="return ValidateCancelReason();"/>                   
                   <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>

                   
                </div>
            </div>
        </div>
    </div>
 <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
    <a href="gen_Corp_Dept.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
  <i class="fa fa-plus-circle"></i>
</a>
<style>
        #cphMain_myBtn{
            position: fixed;
            top: 252px;
            right: 2px;
            z-index: 99;
            font-size: 28px;
            border: none;
            outline: none;
            background-color: #48acf2;
            color: #fff;
            cursor: pointer;
            padding: 0px;
            padding-top: 0px;
            border-radius: 4px;
            border-radius: 37px;
            width: 55px;
            height: 40px;
            text-align: center;
            transition-delay: 0.1s;
            padding-top: 0px;
        }
    </style>
 <script>
     //for search option
     var $NoConfi = jQuery.noConflict();
     var $NoConfi3 = jQuery.noConflict();
     function ValidateCancelReason() {
         // replacing < and > tags
         var ret = true;
         document.getElementById("lblErrMsgCancelReason").style.display = "none";
         document.getElementById("cphMain_txtCancelReason").style.borderColor = "";
         var strCancelReason = document.getElementById("cphMain_txtCancelReason").value;
         if (strCancelReason == "") {
             document.getElementById("cphMain_txtCancelReason").style.borderColor = "red";
             document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
             document.getElementById("lblErrMsgCancelReason").style.display = "";
             $("div.war").fadeIn(200).delay(500).fadeOut(400);
             return false;
         }
         else {
             strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
             strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
             strCancelReason = strCancelReason.replace(/\n /, "\n");
             if (strCancelReason.length < "10") {
                 document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                 document.getElementById("cphMain_txtCancelReason").style.borderColor = "red";
                 document.getElementById("lblErrMsgCancelReason").style.display = "";
                 $("div.war").fadeIn(200).delay(500).fadeOut(400);
                 return false;
             }
         }
         var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
         var strCancelMust = document.getElementById("<%=HiddenFieldCancelReasMust.ClientID%>").value;
         ReOpenConfByID(strId, 0, strCancelReason, strCancelMust);
         $('#dialog_simple').modal('hide');
         return false;
     }
     //EVM-0024
     function CloseCancelView() {
         ezBSAlert({
             type: "confirm",
             messageText: "Do you want to close  without completing cancellation process?",
             alertType: "info"
         }).done(function (e) {
             if (e == true) {
                 $('#dialog_simple').modal('hide');
                 document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
             }
             else {
                 $('#dialog_simple').modal('show');
                 return false;
             }
         });
         return false;
     }
     //END

     function ChangeStatus(StrId, stsmode, cnclusrId) {
         if (cnclusrId == "0") {
             ezBSAlert({
                 type: "confirm",
                 messageText: "Do you want to change the status of this department?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var usrId = '<%= Session["USERID"] %>';

                     var Details = PageMethods.ChangeStatus(StrId, stsmode, usrId, function (response) {
                         var SucessDetails = response;
                         if (SucessDetails == "success") {
                             window.location = 'gen_Corp_DeptList.aspx?InsUpd=StsCh';
                         }
                         else {
                             window.location = 'gen_Corp_DeptList.aspx?InsUpd=Error';
                         }
                     });
                 }
             });
             return false;
         }
         return false;
     }


     function PrintClick() {
         var orgID = '<%= Session["ORGID"] %>';
        var corptID = '<%= Session["CORPOFFICEID"] %>';
        var Status = document.getElementById("<%=HiddenFieldSts.ClientID%>").value;
        var CnclSts = document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value;
        if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_Corp_DeptList.aspx/PrintList",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Status: "' + Status + '",CnclSts: "' + CnclSts + '"}',
                dataType: "json",
                success: function (data) {
                    if (data.d != "") {
                        window.open(data.d, '_blank');
                    }
                }
            });
        }
        else {
            window.location = '/Security/Login.aspx';
        }
        return false;

    }
 </script>
     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
             var strCancelStatus = 0;
             if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                 strCancelStatus = 1;
             }
             document.getElementById("<%=HiddenFieldSts.ClientID%>").value = strddlStatus;
             document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value = strCancelStatus;
             Load_dt();
             getdata(1);
         });

         function LoadList() {
             var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
             var strCancelStatus = 0;
             if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                 strCancelStatus = 1;
             }
             document.getElementById("<%=HiddenFieldSts.ClientID%>").value = strddlStatus;
             document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value = strCancelStatus;
             getdata(1);
             return false;
         }

         //Efficiently Paging Through Large Amounts of Data
         var intOrderByColumn = 1;
         var intOrderByStatus = 0;
         var intToltalSearchColumns = 0;

         //------------Load column filters and table----------

         function Load_dt() {

             var strPagingTable = '';
             strPagingTable += '<div id="divHeader_dt"></div>';
             strPagingTable += '<div class="r_800"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_800" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "gen_Corp_DeptList.aspx/LoadStaticDatafordt";
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
             var strddlStatus = document.getElementById("<%=HiddenFieldSts.ClientID%>").value;
             var strCancelStatus = document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value;
             var strEnableModify = document.getElementById("<%=HiddenFieldUpdRole.ClientID%>").value;
             var strEnableCancel = document.getElementById("<%=HiddenFieldCnclRole.ClientID%>").value;
             var url = "gen_Corp_DeptList.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.ddlStatus = strddlStatus;
             objData.CancelStatus = strCancelStatus;
             objData.EnableModify = strEnableModify;
             objData.EnableCancel = strEnableCancel;
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
                     document.getElementById("divPagingTable_processing").style.display = "none";
                     $('#tblPagingTable tbody').html(result.d[0]);
                     $("#cphMain_divReport").html(result.d[1]);//datatable

                     var intToltalColumns = document.getElementById('tblPagingTable').rows[1].cells.length;
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

         function SettypingTimer(evt) {
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13 || keyCodes == 9) {
                 return false;
             }
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




