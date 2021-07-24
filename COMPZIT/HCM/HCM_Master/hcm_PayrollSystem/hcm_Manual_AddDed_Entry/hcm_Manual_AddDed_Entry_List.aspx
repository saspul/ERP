<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="hcm_Manual_AddDed_Entry_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Manual_AddDed_Entry_hcm_Manual_AddDed_Entry_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <script>
        var $noCon1 = jQuery.noConflict();
        function OpenCancelView(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this manual addition/deduction entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
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
        function SuccessUpd() {
            $("#success-alert").html("Manual addition/deduction entry updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessIns() {
            $("#success-alert").html("Manual addition/deduction entry saved successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCancelation() {
            $("#success-alert").html("Manual addition/deduction entry deleted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Manual addition/deduction entry confirmed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReopen() {
            $("#success-alert").html("Manual addition/deduction entry reopened successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function AlreadyCancelMsg() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#divWarning").html("Action is denied.Manual addition/deduction entry is already deleted");
            $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function AlConf() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#divWarning").html("Action is denied.Manual addition/deduction entry is already confirmed");
             $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
             });
        }
        function AlReop() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#divWarning").html("Action is denied.Manual addition/deduction entry is already reopened");
             $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
             });
         }
        
        function ErrorCancelation() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#divWarning").html("Some error occurred.Try again!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ReOpen(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reopen this manual addition/deduction entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    ReOpenConfByID(StrId,3,null,null);
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function ConfirmByID(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to confirm this manual addition/deduction entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    ReOpenConfByID(StrId, 1,null,null);
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
                url: "hcm_Manual_AddDed_Entry_List.aspx/ReOpenConfByID",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",userID: "' + userID + '",MasterDbId: "' + MasterDbId + '",Mode: "' + Mode + '",reasonmust: "' + reasonmust + '",cnclRsn: "' + cnclRsn + '"}',
                dataType: "json",
                success: function (data) {
                    window.location.href = "hcm_Manual_AddDed_Entry_List.aspx?InsUpd="+data.d;

                }
            });
                
        return false;
    }
    </script>
     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
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
             strPagingTable += '<div><table id="tblPagingTable" class="display table-bordered pro_tab1" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr><tr id="trPagingTableHeading"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "/HCM/HCM_Master/hcm_PayrollSystem/hcm_Manual_AddDed_Entry/hcm_Manual_AddDed_Entry_List.aspx/LoadStaticDatafordt";
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
            var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var strYear = document.getElementById("<%=ddlYear.ClientID%>").value;
            var strMonth = document.getElementById("<%=ddlMonth.ClientID%>").value;
            var strCancelStatus = 0;
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                strCancelStatus = 1;
            }

            var strEnableModify = document.getElementById("<%=HiddenFieldUpdRole.ClientID%>").value;
            var strEnableCancel = document.getElementById("<%=HiddenFieldCnclRole.ClientID%>").value;
            var strEnableConfirm = document.getElementById("<%=HiddenFieldConfRole.ClientID%>").value;
            var strEnableReopen = document.getElementById("<%=HiddenFieldReopRole.ClientID%>").value;

            var url = "/HCM/HCM_Master/hcm_PayrollSystem/hcm_Manual_AddDed_Entry/hcm_Manual_AddDed_Entry_List.aspx/GetData";
            var objData = {};
            objData.OrgId = strOrgId;
            objData.CorpId = strCorpId;
            objData.ddlStatus = strddlStatus;
            objData.CancelStatus = strCancelStatus;
            objData.Year = strYear;
            objData.Month = strMonth;
            objData.EnableModify = strEnableModify;
            objData.EnableCancel = strEnableCancel;
            objData.EnableConfirm = strEnableConfirm;
            objData.EnableReopen = strEnableReopen;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
    <asp:HiddenField ID="HiddenSearchField" runat="server" />
    <asp:HiddenField ID="Hiddenenabledit" runat="server" />
    <asp:HiddenField ID="Hiddenenabladd" runat="server" />
    <asp:HiddenField ID="HiddenusrId" runat="server" />
    <asp:HiddenField ID="Hiddencnclsts" runat="server" />
    <asp:HiddenField ID="HiddenSuccessMsgType" runat="server" />


     <asp:HiddenField ID="HiddenFieldUpdRole" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldConfRole" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldReopRole" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldCnclRole" runat="server" Value="0" />

    <!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
      <li class="active">Manual Addition/Deduction Entry List</li>
    </ol>
<!---breadcrumb_section_started---->
      <!---alert_message_section---->
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
<!----alert_message_section_closed---->
     <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Manual Addition/Deduction Entry List</h1>

          <div class="form-group fg2 fg2_hc3">
          <label for="email" class="fg2_la1">Month<span class="spn1"></span>:</label>
          <select class="form-control fg2_inp1 fg_chs2" id="ddlMonth" runat="server">
          </select> 
        </div>
        <div class="form-group fg2 fg2_hc3">
          <label for="email" class="fg2_la1">Year<span class="spn1"></span>:</label>
          <select class="form-control fg2_inp1 fg_chs2" id="ddlYear" runat="server">
          </select> 
        </div>
        <div class="form-group fg5 fg2_hc3">
          <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
          <select class="form-control fg2_inp1 fg_chs2" id="ddlStatus" runat="server">
            <option value="0">All</option>
            <option value="1">Pending</option>
            <option value="2">Confirmed</option>
            <option value="3">Reopened</option>
          </select> 
        </div> 
        <div class="fg5 fg2_hc4">
          <label class="form1 mar_bo mar_tp">
            <span class="button-checkbox">
              <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
              <input type="checkbox" class="hidden" id="cbxCnclStatus" runat="server" />
            </span>
            <p class="pz_s">Show Deleted Entries?</p>
          </label>
        </div>

        <div class="fg8 fg2_hc5">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
           <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return LoadList();" />
        </div>
          
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="hcm_res"></div>
       
<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
        </div>
      </div>
    </div>

    <!----------------------------------------------Content_section_opened------------------------------------------------------------->

     <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static"    role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document" id="divCancelPopUp">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>

                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
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
    <a href="hcm_Manual_AddDed_Entry.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
        <i class="fa fa-plus-circle"></i>
    </a>
    <a href="hcm_Manual_AddDed_Entry_Edit.aspx" type="button" class="quick" title="Quick Edit" >
        <i class="fa fa-edit"><span class="fa fa-bolt spn_qkr"></span></i>
    </a>

        <!---print_button--->
    <asp:Button ID="btnPrintList" runat="server" class="submit_ser" style="display:none" OnClick="btnPrintList_Click" />
<a href="javascript:;" type="button" class="print_o"  onclick="ListPrintBtnClick()" title="Print page">
  <i class="fa fa-print"></i>
</a>
<!---print_button_closed--->

<!---add_new_button_closed-->
<!----==========Procurement_management_script_section_started=======--->
<!-------------print_script_start--------------------->
<script>
    $(document).ready(function () {
        $(".imprt_o").click(function () {
            $(".import_opt").toggle(300);
        });
    });
</script>
<script type="text/javascript">
    $(".wr2").click(function () {
        $(".import_opt").hide(400);
    });
</script>
<!-------------print_script_close--------------------->
      <script>
          //for search option
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();
          function ValidateCancelReason() {
              // replacing < and > tags
              var ret = true;
              document.getElementById("lblErrMsgCancelReason").style.display = "none";
              document.getElementById("txtCancelReason").style.borderColor = "";
              var strCancelReason = document.getElementById("txtCancelReason").value;
              if (strCancelReason == "") {
                  document.getElementById("txtCancelReason").style.borderColor = "red";
                  document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                  document.getElementById("lblErrMsgCancelReason").style.display = "";
                  $("div.war").fadeIn(200).delay(500).fadeOut(400);
                  return ret;
              }
              else {
                  strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                  strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                  strCancelReason = strCancelReason.replace(/\n /, "\n");
                  if (strCancelReason.length < "10") {
                      document.getElementById("lblErrMsgCancelReason").innerHTML = "Delete reason should be minimum 10 characters";
                      document.getElementById("txtCancelReason").style.borderColor = "red";
                      document.getElementById("lblErrMsgCancelReason").style.display = "";
                      $("div.war").fadeIn(200).delay(500).fadeOut(400);
                      return ret;
                  }
                  else {

                  }
              }
              if (ret == true) {
                  var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                  var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                  ReOpenConfByID(strId,0, strCancelReason, strCancelMust);
                  $('#dialog_simple').modal('hide');
              }
              return false;
          }
    </script>
   
           <script>
               function getdetails(href) {
                   window.location = href;
                   return false;
               }
               //EVM-0024
               function CloseCancelView() {
                   ReasonConfirm = document.getElementById("txtCancelReason").value;
                   if (document.getElementById("<%=Hiddencnclsts.ClientID%>").value == "") {
                       ezBSAlert({
                           type: "confirm",
                           messageText: "Do you want to close  without completing deletion process?",
                           alertType: "info"
                       }).done(function (e) {
                           if (e == true) {
                               $('#dialog_simple').modal('hide');
                           }
                           else {
                               $('#dialog_simple').modal('show');
                               return false;
                           }
                       });
                       return false;
                   }
               }
               //END
               function OpenCancelBlock() {
                   $("#divWarning").html("Sorry, Deletion denied. This entry is already selected somewhere or it is a confirmed entry!");
                   $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   return false;
               }
               </script>

    <script>
        function ListPrintBtnClick() {
            document.getElementById("<%=btnPrintList.ClientID%>").click();
        }
    </script>
</asp:Content>

