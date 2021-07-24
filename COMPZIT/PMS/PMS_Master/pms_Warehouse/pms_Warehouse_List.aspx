<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="pms_Warehouse_List.aspx.cs" Inherits="PMS_PMS_Master_pms_Warehouse_pms_Warehouse_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/Common/Common.js"></script>

    <script>


        var $noCon = jQuery.noConflict();

        $noCon(window).load(function () {

        });

        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this purchase order?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        document.getElementById("lblErrMsgCancelReason").style.display = "none";

                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
                        $('#dialog_simple').modal('show');
                        $('#dialog_simple').on('shown.bs.modal', function () {
                            document.getElementById("txtCancelReason").focus();
                        });

                    }
                    else {
                        DeleteByID(StrId, strCancelReason, strCancelMust);
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

        function ValidateCancelReason() {
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
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
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
                DeleteByID(strId, strCancelReason, strCancelMust);
                $('#dialog_simple').modal('hide');
            }

            return false;

        }
        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            if (strId != "" && strUserID != '') {
                var Details = PageMethods.CancelReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {

                    var SucessDetails = response;
                    if (SucessDetails == "successcncl") {

                        window.location = 'pms_Warehouse_List.aspx?InsUpd=Cncl';


                    }
                    else {
                        window.location = 'pms_Warehouse_List.aspx?InsUpd=Error';
                    }
                });
            }

            return false;
        }

        function ChangeStatus(strId, Status) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to change the status of the warehouse?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strId != "") {
                        var Details = PageMethods.ChangeStatus(strId, Status, function (response) {

                            var SucessDetails = response;
                            if (SucessDetails == "successchng") {
                                window.location = 'pms_Warehouse_List.aspx?InsUpd=Sts';
                            }
                            else {
                                Error();
                            }
                        });
                    }
                    return false;

                }
                return false;

            });
            return false;
        }

  
        function SuccessInsertion() {
            $("#success-alert").html("Warehouse inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessUpdation() {
            $("#success-alert").html("Warehouse updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessCancelation() {
            $("#success-alert").html("Warehouse cancelled successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessStatusChng() {
            $("#success-alert").html("Warehouse status changed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function Error() {
            $("#danger-alert").html("Some error occured!");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
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
        var intOrderByStatus = 0;
        var intToltalSearchColumns = 0;

        //------------Load column filters and table----------

        function Load_dt() {

            var strPagingTable = '';
            strPagingTable += '<div id="divHeader_dt"></div>';
            strPagingTable += '<div><table id="tblPagingTable" class="display table-bordered pro_tab1" style="width:100%;">';
            strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
            strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
            strPagingTable += '</table></div>';

            $("#divPagingTableContainer").html(strPagingTable);

            intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

            var url = "/PMS/PMS_Master/pms_Warehouse/pms_Warehouse_List.aspx/LoadStaticDatafordt";
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

            if (strOrgId == "" || strCorpId == "") {
                window.location.href = "/Default.aspx";
                return false;
            }

            var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var strCancelStatus = 0;
            if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                strCancelStatus = 1;
            }

            strEnableModify = document.getElementById("<%=hiddenEnableModify.ClientID%>").value;
            strEnableCancel = document.getElementById("<%=hiddenEnableCancel.ClientID%>").value;

            var url = "/PMS/PMS_Master/pms_Warehouse/pms_Warehouse_List.aspx/GetData";
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

                    $('#tblPagingTable tbody').html(result.d[0]);
                    var TotalRows = result.d[1];
                    $("#cphMain_divReport").html(result.d[2]);//datatable

                    var intToltalColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

                    var intAdditionalCoumns = intToltalColumns - (intToltalSearchColumns);

                    if (intAdditionalCoumns < 0) {
                        intAdditionalCoumns = 0;
                    }

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

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancel" runat="server" />

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">Procurement Management</a></li>
        <li class="active">Warehouse</li>
    </ol>

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



      <div id="divAdd" onclick="location.href='pms_Warehouse.aspx'" runat="server">
           <a href="pms_Warehouse.aspx" type="button" id="myBtn" title="Add New">
             <i class="fa fa-plus-circle"></i>
           </a>
      </div>
                <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
          <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>


    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">

         <h1 class="h1_con">Warehouse Master LIST</h1>
          <div class="form-group fg2">
            <label for="cphMain_ddlStatus" class="fg2_la1">Status<span class="spn1"></span>:</label>
               <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1" runat="server">
                   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                   <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                   <asp:ListItem Text="All" Value="2"></asp:ListItem>
               </asp:DropDownList>         
          </div>

          <div class="fg2">
            <label class="form1 mar_bo mar_tp">
              <span class="button-checkbox">
                <button type="button" class="btn-d" data-color="p"></button>
                <asp:CheckBox ID="cbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
              </span>
              <p class="pz_s">Show Deleted Entries</p>
            </label>
          </div>

          <div class="fg2">
            <label for="cphMain_btnSearch" class="fg2_la1 nbsp1">&nbsp;</label>
             <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return LoadList();" />
          </div>

      <div class="clearfix"></div>
      <div class="devider"></div>

<!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="tab_res"></div>
<!----table---->


        </div>
      </div>
    </div>

<!----Cancel modal---->

    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
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
                    <button type="button" id="btnCnclRsn" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        function PrintClick() {

            var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';

                var statusid = 0;

                var Suplier = 0;
                var CnclSts = 0;
                statusid = document.getElementById("cphMain_ddlStatus").value;
                if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                    CnclSts = 1;
                }
                if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                    // alert("d");
                    $.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "pms_Warehouse_List.aspx/PrintList",
                        data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '" }',
                        dataType: "json",
                        success: function (data) {
                            if (data.d != "") {

                                window.open(data.d, '_blank');
                            }
                            else {
                                Error();

                            }
                        }
                    });
                }
                else {
                    window.location = '/Security/Login.aspx';
                }
                return false;
        }


        function PrintCSV() {

            var orgID = '<%= Session["ORGID"] %>';
             var corptID = '<%= Session["CORPOFFICEID"] %>';

             var statusid = 0;

             var Suplier = 0;
             var CnclSts = 0;
             statusid = document.getElementById("cphMain_ddlStatus").value;
             if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                 CnclSts =1;
             }
             if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                 
                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "pms_Warehouse_List.aspx/PrintCSV",

                     data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '" }',
                     dataType: "json",
                     success: function (data) {
                       
                         if (data.d != "") {
                             // 
                             window.open(data.d, '_blank');
                         }
                         else {
                             Error();

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


</asp:Content>

