<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Job_Master_List.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Job_Master_gen_Job_Master_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />

      <script type="text/javascript">

          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

          });

      </script>
    
    <script type="text/javascript">
        var $Mo = jQuery.noConflict();

        function OpenCancelView(Id) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this job?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    document.getElementById("lblErrMsgCancelReason").style.display = "none";

                    document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
                     document.getElementById("<%=txtCnclReason.ClientID%>").value = "";
                     $('#dialog_simple').modal('show');
                     $('#dialog_simple').on('shown.bs.modal', function () {
                         document.getElementById("<%=txtCnclReason.ClientID%>").focus();
                     });

                     document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = Id;

                 }
             });
             return false;
         }

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
             });
             return false;
         }

        function DuplicationName() {
            $("#danger-alert").html("Recalling Denied!.Job Title Can’t be Duplicated.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

    </script>
    
    <script>
        function SuccessConfirmation() {
            $("#success-alert").html("Job details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            $("#success-alert").html("Job details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCancelation() {
            $("#success-alert").html("Job cancelled successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessRecall() {
            $("#success-alert").html("Job details recalled successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function CancelAlert(href) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this job?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location = href;
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function ReCallAlert(href) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to recall this job?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location = href;
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function CancelNotPossible() {
            $("#danger-alert").html("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function ChangeStatus(strId, Status) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to change the status of the job?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strId != "") {
                        var Details = PageMethods.ChangeStatus(strId, Status, function (response) {

                            var SucessDetails = response;
                            if (SucessDetails == "successchng") {
                                window.location = 'gen_Job_Master_List.aspx?InsUpd=Sts';
                            }
                        });
                    }
                    return false;

                }
                return false;

            });
            return false;
        }


        function SuccessStatusChng() {
            $("#success-alert").html("Job status changed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function PrintClick() {

            var OrgId = '<%= Session["ORGID"] %>';
            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var ddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var CancelStatus = 0;
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                CancelStatus = 1;
            }

            if (CorpId != "" && CorpId != null && OrgId != "" && OrgId != null) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Job_Master_List.aspx/PrintList",
                    data: '{CorpId: "' + CorpId + '",OrgId: "' + OrgId + '",ddlStatus: "' + ddlStatus + '",CancelStatus: "' + CancelStatus + '"}',
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

         //validation when cancel process
         function ValidateCancelReason() {

             // replacing < and > tags
             var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

             var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
             var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
             if (Reason == "") {
                 document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "red";
                 document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                 document.getElementById("lblErrMsgCancelReason").style.display = "";
                 document.getElementById("<%=txtCnclReason.ClientID%>").focus();
                 $("div.war").fadeIn(200).delay(500).fadeOut(400);
                 return false;
             }
             else {
                 Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                 Reason = Reason.replace(/[ ]{2,}/gi, " ");
                 Reason = Reason.replace(/\n /, "\n");
                 if (Reason.length < "10") {
                     document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                     document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "red";
                     document.getElementById("lblErrMsgCancelReason").style.display = "";
                     document.getElementById("<%=txtCnclReason.ClientID%>").focus();
                     $("div.war").fadeIn(200).delay(500).fadeOut(400);
                     return false;
                 }
             }
         }

    </script>
    <script>
        function InsertToSearchField() {

            var DropdownStatus = document.getElementById("<%=ddlStatus.ClientID%>");
            var SelectedValueStatus = DropdownStatus.value;
            var ShwCancel = 0;
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked) {
                ShwCancel = 1;
            }
            else {
                ShwCancel = 0;
            }

            document.getElementById("<%=hiddenSearchField.ClientID%>").value = SelectedValueStatus + '_' + ShwCancel;

            LoadList();
            return true;
        }

    </script>


        <script>

            //--------------------------------------Pagination--------------------------------------

            $(document).ready(function () {
                LoadList();
            });

            function LoadList() {
                Load_dt();
                getdata(1);
                return false;
            }

            //Efficiently Paging Through Large Amounts of Data
            var intOrderByColumn = 0;
            var intOrderByStatus = 0;
            var intToltalSearchColumns = 0;

            //------------Load column filters and table----------

            function Load_dt() {

                var strPagingTable = '';
                strPagingTable += '<div id="divHeader_dt"></div>';
                strPagingTable += '<div><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_800" style="width:100%;">';
                strPagingTable += '<thead class="thead1"><tr id="trPagingTableHeading"></tr><tr id="thPagingTable_SearchColumns"></tr></thead>';
                strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
                strPagingTable += '</table></div>';

                $("#divPagingTableContainer").html(strPagingTable);

                intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

                var strCancelStatus = 0;
                if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                strCancelStatus = 1;
            }

                var url = "/AWMS/AWMS_Master/gen_Job_Master/gen_Job_Master_List.aspx/LoadStaticDatafordt";
            var objData = {};
            objData.CancelStatus = strCancelStatus;

            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(objData),
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
            var strUserId = '<%= Session["USERID"] %>';

            //if (strOrgId == "" || strCorpId == "") {
            //    window.location.href = "/Default.aspx";
            //    return false;
            //}

            var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var strCancelStatus = 0;
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                strCancelStatus = 1;
            }
            var strEnableModify = document.getElementById("<%=hiddenEnableModify.ClientID%>").value;
            var strEnableCancel = document.getElementById("<%=hiddenEnableCancel.ClientID%>").value;
            var strCancelReasonMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
            var strHiddenSearch = document.getElementById("<%=hiddenSearchField.ClientID%>").value;

            var url = "/AWMS/AWMS_Master/gen_Job_Master/gen_Job_Master_List.aspx/GetData";
            var objData = {};
            objData.OrgId = strOrgId;
            objData.CorpId = strCorpId;
            objData.UserId = strUserId;
            objData.ddlStatus = strddlStatus;
            objData.CancelStatus = strCancelStatus;
            objData.EnableModify = strEnableModify;
            objData.EnableCancel = strEnableCancel;
            objData.CancelReasonMust = strCancelReasonMust;
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

                    var intToltalColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

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

        //$("th i").click(function () {
        //    alert();
        //});

        //$('.pull-right hed_fa').click(function () {
        //    alert("1  " + $(this).hasClass('fa fa-sort')); alert("2  " + $(this).hasClass('fa fa-caret-up')); alert("3  " + $(this).hasClass('fa fa-caret-down'));
        //    if ($(this).hasClass('fa fa-sort') == true) {
        //        $(this).addClass('fa fa-caret-up');
        //    }
        //    else if ($(this).hasClass('fa fa-caret-up') == true) {
        //        $(this).addClass('fa fa-caret-down');
        //    }
        //    else {
        //        $(this).addClass('fa fa-sort');
        //    }
        //});

        //--------------------------------------Pagination--------------------------------------

    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

     <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
     <asp:HiddenField ID="hiddenSearchField" runat="server" />
     <asp:HiddenField ID="hiddenEnableModify" runat="server" />
     <asp:HiddenField ID="hiddenEnableCancel" runat="server" />
     <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            
<!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Awms.aspx">AWMS</a></li>
      <li class="active">Job</li>
    </ol>
<!---breadcrumb_section_started----> 

<!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->


    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Job</h1>

         <div class="form-group fg2 frm_50 sa_o_fg4">
          <label for="email" class="fg2_la1">Status:<span class="spn1">*</span></label>
          <asp:DropDownList ID="ddlStatus" runat="server" class="form-control fg2_inp1 fg_chs2 inp_mst">
              <asp:ListItem Text="Active" Value="1"></asp:ListItem>
              <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
              <asp:ListItem Text="All" Value="0"></asp:ListItem>
           </asp:DropDownList>
        </div>

        <div class="fg5 fg2_hc4 frm_50">
          <label class="form1 mar_bo mar_tp">
            <span class="button-checkbox">
              <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
              <input type="checkbox" class="hidden" id="cbxCnclStatus" runat="server" checked="false" onkeypress="return DisableEnter(event)" />
            </span>
            <p class="pz_s">Show Deleted Entries</p>
          </label>
        </div>

        <div class="fg2 fg2_blk">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
          <asp:Button ID="btnSearch" runat="server" class="submit_ser" Text="" OnClientClick="return InsertToSearchField();"  />
        </div>
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->
        
<!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="tab_res"></div>
<!----table---->

        </div>
       </div>


<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
        </div>

<!---print_button--->
<a href="javascript:;" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
<!---print_button_closed--->

<!---add_button--->
      <div id="divAdd" onclick="location.href='gen_Job_Master.aspx'" runat="server">
           <a href="gen_Job_Master.aspx" type="button" id="myBtn" title="Add New">
             <i class="fa fa-plus-circle"></i>
           </a>
      </div>
<!---add_button_closed--->

<!----Cancel modal---->

    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title">Reason for delete</h5>
                    <button type="button" class="close" aria-label="Close" onclick="return CloseCancelView();">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <asp:TextBox ID="txtCnclReason" placeholder="Write reason for delete" rows="6" class="text_ar1" MaxLength="500" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnRsnSave" runat="server" Text="Save" class="btn btn-success" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" />
                    <asp:Button ID="btnRsnCncl" runat="server" Text="Cancel" class="btn btn-danger" OnClientClick="return CloseCancelView();" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

