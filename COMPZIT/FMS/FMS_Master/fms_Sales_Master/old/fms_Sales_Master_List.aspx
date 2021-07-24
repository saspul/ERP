<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Sales_Master_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Sales_Master_fms_Sales_Master_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
       <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
     <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <style>
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

      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
            
              //LoadEmployeeList();


              var ReopenSts = '<%= Session["REOPEN_STS"] %>';
              if (ReopenSts != '') {
                  if (ReopenSts == 'successReopen') {
                      SuccessReoen();
                  }
                  else if (ReopenSts == 'failed') {
                      SuccessErrorReoen();
                  }
                  else if (ReopenSts == 'alrdydeleted') {
                      SuccessDeletedList();
                  }
                  else if (ReopenSts == 'acntclosed') {
                      AcntClosedList();
                  }
                  else if (ReopenSts == 'Auditclosed') {
                      AuditClosed();
                  }

              }

              var CONFIRMSts = '<%= Session["CONFIRM_STS"] %>';
              if (CONFIRMSts != '') {
                  if (CONFIRMSts == 'successConfirm') {
                      SuccessConfirm();
                  }
                  else if (CONFIRMSts == 'failed') {
                      SuccessErrorReoen();
                  }
                  else if (CONFIRMSts == 'alrdydeleted') {
                      SuccessDeletedList();
                  }
                  else if (CONFIRMSts == 'acntclosed') {
                      AcntClosedList();
                  }
                  else if (CONFIRMSts == 'Auditclosed') {
                      AuditClosed();
                  }

              }
              //$noCon("div#divddlCustomer input.ui-autocomplete-input").focus();
              //$noCon("div#divddlCustomer input.ui-autocomplete-input").select();
             // document.getElementById("<%=ddlCustomer.ClientID%>").focus();
              $noCon("#divddlCustomer input.ui-autocomplete-input").focus();
              $noCon("#divddlCustomer input.ui-autocomplete-input").select();
              //0039
              //LoadEmployeeList();
              getdata(1);
              //END
              //loadTableDesg();
          });


          function SuccessReoen() {
              var ret = false;
              $noCon("#success-alert").html("Sales details reopened successfully.");
              $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }

          function AlreadyReopened() {
              var ret = false;
              $noCon("#divWarning").html("Sales details already reopened.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function SuccessConfirm()

          {
              var ret = false;
              $noCon("#success-alert").html("Sales details confirmed successfully.");
              $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["CONFIRM_STS"] = "' + null + '"; %>';
              return false;
          }
          function AlreadyConfirmed() {
              var ret = false;
              $noCon("#divWarning").html("Sales details already confirmed .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["CONFIRM_STS"] = "' + null + '"; %>';
              return false;
          }

          function SuccessErrorReoen() {
              $noCon("#divWarning").html("Some error occured!.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function SuccessErrorReoenCheck() {
              $noCon("#divWarning").html("Some error occured!.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              '<%Session["CHK_ISSUE"] = "' + null + '"; %>';
              return false;
          }

          function Error() {
              $noCon("#divWarning").html("Some error occured!");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }

          function AcntClosed() {
              $noCon("#divWarning").html("This action is  denied! Account is already closed .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }
          function AuditClosed() {
              $noCon("#divWarning").html("This action is  denied! Audit is already closed .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }

          function getdetails(href) {
              window.location = href;
              return false;
          }
          function SuccessConfirmationcnfrm() {
              $noCon("#success-alert").html("Sales details confirmed successfully.");
              $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
              });
             
              return false;
          }
          function AcntClosed() {
              $noCon("#divWarning").html("This action is  denied! Account is already closed .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }
          function AuditClosed() {
              $noCon("#divWarning").html("This action is  denied! Audit is already closed .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }
          function ConfirmError() {
              $noCon("#divWarning").html("Sales details already confirmed.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });

              // ddlAccountName.Focus();
              return false;
          }
          function ReopenError() {
              $noCon("#divWarning").html("Sales details already reopened.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });

              // ddlAccountName.Focus();
              return false;
          }

          //0039
          function loadTableDesg() {
              

              $noCon(function () {
                  //$noCon('#dialog_simple').dialog({
                  //    autoOpen: false,
                  //    width: 600,
                  //    resizable: false,
                  //    modal: true,
                  //    title: "Payment",
                  //});
              });
          }
          //end
          

          function SearchValidation() {

              var ret = true;
              document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
              var fromdate = document.getElementById("cphMain_txtFromdate").value;
              var toDate = document.getElementById("cphMain_txtTodate").value;

              if (fromdate == "" && toDate == "") {
                  document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                  document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                  
                  $noCon(window).scrollTop(0);
                  ret = false;
              }

              if (fromdate == "") {
                  document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                 
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                  
                  $noCon(window).scrollTop(0);
                  ret = false;
              }
              if (toDate == "") {
                  document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                  
                  $noCon(window).scrollTop(0);
                  ret = false;
              }

              if (fromdate != "" && toDate != "")
              {

                  var arrDateFromchk = fromdate.split("-");
                 // alert(arrDateFromchk + "arrDateFromchk");
                  dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                  var arrDateTochk = toDate.split("-");
                  dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                  if (dateDateFromchk > dateDateTochk) {
                      $noCon("#divWarning").html("From date should not be greater than to date.");
                      $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                      });
                      
                      $noCon(window).scrollTop(0);
                      document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                      document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                      ret = false;
                  }
              }
            
              if (ret == true) {
                  //0039
                  //LoadEmployeeList();
                  getdata(1);
                  //END
              }
            
              return ret;
          }

          function CancelNotPossible() {
              ezBSAlert({
                  type: "alert",
                  messageText: "Sorry, Cancellation Denied. This sale details is already confirmed!",
                  alertType: "info"

              });
              return false;
          }
          function ReopenNotPossible() {
              $noCon("#divWarning").html("Sorry, reopen denied. This entry is already selected somewhere or it is a confirmed entry!");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              $(window).scrollTop(0);
              return false;
          }
          function PrintNotPossible() {
              ezBSAlert({
                  type: "alert",
                  messageText: "Sorry, Printing Denied. This sale details is not confirmed!",
                  alertType: "info"

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
            if (SearchValidation() == true) {
                getdata(1);
                
            }
            return false;
        }

        //Efficiently Paging Through Large Amounts of Data
        var intOrderByColumn = 0;
        var intOrderByStatus = 0;
        var intToltalSearchColumns = 0;

         //0039
        var intOrderByfromDate = 0;
        var intOrderByToDate = 0;
        var intOrderBySalesStatus = 0;
         //end


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

            var url = "/FMS/FMS_Master/fms_Sales_Master/fms_Sales_Master_List.aspx/LoadStaticDatafordt";//path specified
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
                    alert("error");
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


            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var UserId = '<%= Session["USERID"] %>';

            //if (orgID == "" || corptID == "" || UserId == "") {
            //    window.location.href = "/Default.aspx";
            //    return false;
            //}

            var customer = 0;
            var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
            var AcntPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
            var FinancialStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var FinancialEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var reOpenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
            var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
            var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
            var CurrencyID = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;

            var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
            var Status = document.getElementById("cphMain_ddlStatus").value;
            var SalesStatus = document.getElementById("cphMain_ddlsaleSts").value;

            if (document.getElementById("cphMain_ddlCustomer").value != "--SELECT CUSTOMER--") {
                customer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
            }
            var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
            var CnclSts = 0;
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                CnclSts = 1;
            }

            var url = "/FMS/FMS_Master/fms_Sales_Master/fms_Sales_Master_List.aspx/GetData";
            var objData = {};
            objData.CorpId = corptID;
            objData.OrgId = orgID;
            objData.ddlStatus = Status;
            objData.CancelStatus = CnclSts;
            objData.Customer = customer;
            objData.From = from;
            objData.ToDt = toDt;
            objData.FinncialStartDate = FinancialStartDate;
            objData.FinncialEndDate = FinancialEndDate;
            objData.EnableModify = EnableEdit;
            objData.EnableCancel = EnableDelete;
            objData.ROpenSts = reOpenSts;
            objData.AccntPrvision = AcntPrvision;
            objData.EnbleAudit = EnableAudit;
            objData.SalsStatus = SalesStatus;
            objData.EnbleConfirm = EnableConfirm;
            objData.CurencyID = CurrencyID;
            objData.UserId = UserId;
            //--pagination
            objData.PageNumber = strPageNumber;
            objData.PageMaxSize = strPageSize;
            objData.strCommonSearchTerm = strCommonSearchString;
            objData.OrderColumn = intOrderByColumn;//
            objData.OrderMethod = intOrderByStatus;//
            objData.strInputColumnSearch = strInputColumnSearch;

            
           

            $.ajax({

                type: 'POST',
                data: JSON.stringify(objData),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                url: "/FMS/FMS_Master/fms_Sales_Master/fms_Sales_Master_List.aspx/GetData",
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
                    alert("error");
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
    var typingTimer;              //timer identifier
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


 <%--  <%%>
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>--%>
    <%%>


    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCurrncyId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
    <asp:HiddenField ID="HiddenEnableModify" runat="server" />
    <asp:HiddenField ID="Hiddencnclsts" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />
    <asp:HiddenField ID="HiddenFinancialStartDate" runat="server" />
    <asp:HiddenField ID="HiddenFnancialEndDeate" runat="server" />
    <asp:HiddenField ID="HiddenReopen" runat="server" />
    <asp:HiddenField ID="HiddenAccountCloseDate" runat="server" />
    <asp:HiddenField ID="HiddenAuditProvisionStatus" runat="server" />
    <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenConfirmStatus" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <div class="cont_rght" >

      <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Sales </li>
    </ol>
        <!---alert_message_section---->
        <div class="myAlert-top alert alert-success" id="success-alert">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Success!</strong> Changes completed succesfully
        </div>

        <div class="myAlert-bottom alert alert-danger" id="divWarning">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Danger!</strong> Request not conmpleted
        </div>
        <!----alert_message_section_closed---->
        <div class="content_sec2 cont_contr">
            <div class="content_area_container cont_contr">
                <div class="content_box1 cont_contr">
                    <h1 class="h1_con">Sales </h1>

                    <div class="form-group fg5">
                        <label for="email" class="fg2_la1">Customer Name:<span class="spn1"></span></label>
                        <div id="divddlCustomer" class="eachform">
                            <asp:DropDownList ID="ddlCustomer" class="form-control fg2_inp1 fg_chs2" runat="server" onkeypress="return DisableEnter (event);" onkeydown="return  DisableEnter (event);">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group fg7">
                        <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                        <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                            <input id="txtFromdate" runat="server" type="text" readonly="readonly" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                            <script>

                                var StartDateVal = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                                var EndDateVal = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;

                                $noCon('#cphMain_txtFromdate').datepicker({
                                    autoclose: true,
                                    format: 'dd-mm-yyyy',
                                    timepicker: false,
                                    startDate: StartDateVal,
                                    endDate: EndDateVal,
                                });
                            </script>
                        </div>
                    </div>

        <div class="form-group fg7">
          <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span></label>
          <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
               <input id="txtTodate" runat="server" type="text" readonly="readonly" onkeypress="return DisableEnter(event)"  class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
            <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
          </div>
            <script>
                var StartDateVal = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                var EndDateVal = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;

                $noCon('#cphMain_txtTodate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false,
                    startDate: StartDateVal,
                    endDate: EndDateVal,
                });
       </script>
        </div>

                    <div class="form-group fg8 ">
                        <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
                        <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1" runat="server">
                            <asp:ListItem Text="Active" Value="1" Selected="True"> </asp:ListItem>
                            <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                            <asp:ListItem Text="All" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group fg7 ">
                        <label for="email" class="fg2_la1">Sales Status<span class="spn1"></span>:</label>
                        <asp:DropDownList ID="ddlsaleSts" class="form-control fg2_inp1" runat="server">
                            <asp:ListItem Text="Pending" Value="0"> </asp:ListItem>
                            <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Reopened" Value="2"></asp:ListItem>
                            <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>


                    <div class="fg7">
                        <label class="form1 mar_bo mar_tp">
                            <span class="button-checkbox">
                                <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" onkeypress="return DisableEnter(event)" class="form2" />
                                <button type="button" class="btn-d" data-color="p" ng-model="all"></button>
                                <input type="checkbox" class="hidden" />
                            </span>
                            <p class="pz_s">Show Deleted Entries</p>
                        </label>
                    </div>
                   
<div class="fg8">
                        <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                        <button type="button" id="btnSearch" runat="server" class="submit_ser" onclick="return LoadList()"></button>
                    </div>
                    
                    


        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>


                    <div id="divAdd" onclick="location.href='fms_Sales_Master.aspx'" class="add" runat="server">
                        <a href="fms_Sales_Master.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                            <i class="fa fa-plus-circle"></i>
                        </a>
                    </div>
                <button id="print" onclick="return printsorted();" class="print_o" title="Print page"><i class="fa fa-print"></i> </button>
                <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>



   <div class="hcm_res">

          <!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="tab_res"></div>
       <!----table---->
         
</div>        

                </div>
            </div>
        </div>
       

               <tr id="trTotal" runat="server">
        </tr>  



        
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
                            <div id="divPrintCaptionDrilDown" runat="server" style="display: none">
                </div>
                  <div id="divPrintReportDrilDown" runat="server" style="display: none">
                </div>
    
    
                                 <div id="divTitle" runat="server" style="display: none">
    SALES
      </div>
        
           
                                            <%--------------------------------View for error Reason--------------------------%>
          
        <%--<div id="dialog_simple" title="Dialog Simple Title" style="display: none">
            <div class="widget-body no-padding" id="divCancelPopUp">
                <div class="alert alert-danger fade in" id="lblErrMsgCancelReason" style="display: none; margin-top: 1%">
                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
                </div>
                <div style="width: 100%; float: left; clear: both; margin-top: 5%">
                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Cancel Reason*</label>
                        <label class="input" style="float: left; width: 60%;">
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" onblur="RemoveTag(txtCancelReason)" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="text-transform: uppercase; resize: none;"></textarea>
                        </label>
                    </section>
                </div>
                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-default"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>
                </div>
            </div>
        </div>--%>  

    </div>
                   
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
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();

        function LoadEmployeeList() {
            

            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var UserId = '<%= Session["USERID"] %>';
            var customer = 0;
            var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
            var AcntPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
            var FinancialStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var FinancialEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var reOpenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
            var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
            var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
            var CurrencyID = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;

            var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
            var Status = document.getElementById("cphMain_ddlStatus").value;
            var SalesStatus = document.getElementById("cphMain_ddlsaleSts").value;

            if (document.getElementById("cphMain_ddlCustomer").value != "--SELECT CUSTOMER--") {
                customer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
            }


            //0039
            var strPageSize = 10;
            var strPageNumber = 1;

            var strCommonSearchString = "";
            if (document.getElementById("txtCommonSearch_dt")) {
                strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
            }


            //Efficiently Paging Through Large Amounts of Data
            var intOrderByColumn = 0;
            var intOrderByStatus = 0;
            var intToltalSearchColumns = 0;

            
            var intOrderByfromDate = 0;
            var intOrderByToDate = 0;
            var intOrderBySalesStatus = 0;
            

            var strInputColumnSearch = getColumnSearchData();//individual column search
            //end
            //0039

            if (document.getElementById("ddl_page_size")) {
                strPageSize = document.getElementById("ddl_page_size").value;
            }
            var PageMaxSize = strPageSize;
            var PageNumber = strPageNumber;


            var strCommonSearchTerm = strCommonSearchString;
            var OrderColumn = intOrderByColumn;//
            var OrderMethod = intOrderByStatus;//
            var strInputColumnSearch = strInputColumnSearch;

            alert(PageMaxSize);
            alert(PageNumber);
            alert(strCommonSearchTerm);
            alert(OrderColumn);
            alert(OrderMethod);
            alert(strInputColumnSearch);
            //end
            var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
            var CnclSts = 0;
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            /* COLUMN FILTER  */
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                CnclSts = 1;
                var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                   // 'bProcessing': true,
                    'bServerSide': true,
                    'sAjaxSource': 'data.ashx',
                    "bDestroy": true,
                    "autoWidth": true,
                    "order": [[0, 'desc']],
           
                    "preDrawCallback": function () {
                        if (!responsiveHelper_datatable_fixed_column) {
                            responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_column'), breakpointDefinition);
                        }
                    },
                    "rowCallback": function (nRow) {
                        responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                    },
                    "drawCallback": function (oSettings) {
                        responsiveHelper_datatable_fixed_column.respond();
                    },
                    "fnServerParams": function (aoData) {
                        aoData.push({ "name": "ORG_ID", "value": orgID });
                        aoData.push({ "name": "CORPT_ID", "value": corptID });
                        aoData.push({ "name": "STATUS", "value": Status });
                        aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                        aoData.push({ "name": "CUSTOMER", "value": customer });
                        aoData.push({ "name": "FROMDT", "value": from });
                        aoData.push({ "name": "TODAT", "value": toDt });
                        aoData.push({ "name": "ENABLEDIT", "value": EnableEdit });
                        aoData.push({ "name": "ENABLEDELETE", "value": EnableDelete });
                        aoData.push({ "name": "STARTDATE", "value": FinancialStartDate });
                        aoData.push({ "name": "ENDDATE", "value": FinancialEndDate });
                        aoData.push({ "name": "REOPEN", "value": reOpenSts });
                        aoData.push({ "name": "ACNTCLSDT", "value": acntClsDate });
                        aoData.push({ "name": "AUDITPRVSN", "value": AcntPrvision });
                        aoData.push({ "name": "ENABLEAUDIT", "value": EnableAudit });
                        aoData.push({ "name": "SALES_STS", "value": SalesStatus });
                        aoData.push({ "name": "CONFIRM", "value": EnableConfirm });
                        aoData.push({ "name": "CURRENCY", "value": CurrencyID });
                        aoData.push({ "name": "USERID", "value": UserId });

                    },
                    "columnDefs": [
            {
                "targets": 0,
                "orderData": 4,
            },
            {
                "targets": [0],
                "className": "tr_l",
                "visible": true
            },
              {
                  "targets": [3],
                  "className": "tr_r",
                  "visible": true
              },
           {
               "targets": [1],
               "className": "tr_c",
               "visible": true
           },
           {
               "targets": [2],
               "className": "tr_l",
               "visible": true
           },
                    ],


                });

                $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                    otable
                        .column($NoConfi(this).parent().index() + ':visible')
                        .search(this.value)
                        .draw();

                });
                /* END COLUMN FILTER */

            }
            else {
                var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                  //  'bProcessing': true,
                    'bServerSide': true,
                    'sAjaxSource': 'data.ashx',
                    "bDestroy": true,
                    "autoWidth": true,
                    "order": [[0, 'desc']],
               
                    "preDrawCallback": function () {
                        // Initialize the responsive datatables helper once.
                        if (!responsiveHelper_datatable_fixed_column) {
                            responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_column'), breakpointDefinition);
                        }
                    },

                    "rowCallback": function (nRow) {
                        responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                    },
                    "drawCallback": function (oSettings) {
                        responsiveHelper_datatable_fixed_column.respond();
                    },
                    "fnServerParams": function (aoData) {
                        aoData.push({ "name": "ORG_ID", "value": orgID });
                        aoData.push({ "name": "CORPT_ID", "value": corptID });
                        aoData.push({ "name": "STATUS", "value": Status });
                        aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                        aoData.push({ "name": "CUSTOMER", "value": customer });
                        aoData.push({ "name": "FROMDT", "value": from });
                        aoData.push({ "name": "TODAT", "value": toDt });
                        aoData.push({ "name": "ENABLEDIT", "value": EnableEdit });
                        aoData.push({ "name": "ENABLEDELETE", "value": EnableDelete });
                        aoData.push({ "name": "STARTDATE", "value": FinancialStartDate });
                        aoData.push({ "name": "ENDDATE", "value": FinancialEndDate });
                        aoData.push({ "name": "REOPEN", "value": reOpenSts });
                        aoData.push({ "name": "ACNTCLSDT", "value": acntClsDate });
                        aoData.push({ "name": "AUDITPRVSN", "value": AcntPrvision });
                        aoData.push({ "name": "ENABLEAUDIT", "value": EnableAudit });
                        aoData.push({ "name": "SALES_STS", "value": SalesStatus });
                        aoData.push({ "name": "CONFIRM", "value": EnableConfirm });
                        aoData.push({ "name": "CURRENCY", "value": CurrencyID });
                        aoData.push({ "name": "USERID", "value": UserId });

                    },
                    "columnDefs": [
    {
        "targets": 0,
        "orderData": 4,
    },
            {
                "targets": [0],
                "className": "tr_l",
                "visible": true
            },
              {
                  "targets": [3],
                  "className": "tr_r",
                  "visible": true
              },
           {
               "targets": [1],
               "className": "tr_c",
               "visible": true
           },
           {
               "targets": [2],
               "className": "tr_l",
               "visible": true
           },


                    ],
                });
                $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                    otable
                        .column($NoConfi(this).parent().index() + ':visible')
                        .search(this.value)
                        .draw();

                });
                /* END COLUMN FILTER */
            }



            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var customer = 0;
            var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
            var AuditPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
            var FinancialStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var FinancialEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var reOpenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
            var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
            var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
            var CurrencyID = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;

            var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;

            //var Status = document.getElementById("cphMain_ddlStatus").value;

            var Status = document.getElementById("cphMain_ddlStatus").value;
            var SalesStatus = document.getElementById("cphMain_ddlsaleSts").value;
            // alert(Status);
            if (document.getElementById("cphMain_ddlCustomer").value != "--SELECT CUSTOMER--") {
                customer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
                // alert(customer);
            }
            var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
            var CnclSts = 0;
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                CnclSts = 1;
            }
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/SaleAmountSum",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",EnableEdit: "' + EnableEdit + '",EnableDelete: "' + EnableDelete + '",AuditPrvision: "' + AuditPrvision + '",FinancialStartDate: "' + FinancialStartDate + '",FinancialEndDate: "' + FinancialEndDate + '",reOpenSts: "' + reOpenSts + '",acntClsDate: "' + acntClsDate + '",EnableAudit: "' + EnableAudit + '",CurrencyID: "' + CurrencyID + '",EnableConfirm: "' + EnableConfirm + '",Status: "' + Status + '",SalesStatus: "' + SalesStatus + '",customer: "' + customer + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            document.getElementById("cphMain_trTotal").innerHTML = data.d;
                                return false;
                        }
                        else {
                            document.getElementById("cphMain_trTotal").innerHTML = "";
                        }
                    }
                });
            }




        }
    </script>
    <script>

        function printsorted()
        {


            //0039
            var strPageSize = 10;
            var strPageNumber = 1;

            var strCommonSearchString = "";
            if (document.getElementById("txtCommonSearch_dt")) {
                strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
            }


            //Efficiently Paging Through Large Amounts of Data
            var intOrderByColumn = 0;
            var intOrderByStatus = 0;
            var intToltalSearchColumns = 0;          
            var strInputColumnSearch = getColumnSearchData();//individual column search
            //end
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var customer = 0;
            var customerName = "";
            var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
            var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
            var AuditPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
            var FinancialStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
            var FinancialEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
            var reOpenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
            var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
            var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
            var CurrencyID = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;

            var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;

            //0039

            if (document.getElementById("ddl_page_size")) {
                strPageSize = document.getElementById("ddl_page_size").value;
            }
            var PageMaxSize = strPageSize;
            var PageNumber = strPageNumber;
            
           
            var strCommonSearchTerm = strCommonSearchString;
            var OrderColumn = intOrderByColumn;//
            var OrderMethod = intOrderByStatus;//
            var strInputColumnSearch = strInputColumnSearch;

            //end


            //var Status = document.getElementById("cphMain_ddlStatus").value;

            var Status = document.getElementById("cphMain_ddlStatus").value;
            var SalesStatus = document.getElementById("cphMain_ddlsaleSts").value;
            // alert(Status);

            if (document.getElementById("cphMain_ddlCustomer").value != "--SELECT CUSTOMER--") {
                customer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
                customerName = $("#cphMain_ddlCustomer :selected").text();

            }
            
            var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
            var CnclSts = 0;
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                CnclSts = 1;
            }
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/PrintList",
                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",EnableEdit: "' + EnableEdit + '",EnableDelete: "' + EnableDelete + '",AuditPrvision: "' + AuditPrvision + '",FinancialStartDate: "' + FinancialStartDate + '",FinancialEndDate: "' + FinancialEndDate + '",reOpenSts: "' + reOpenSts + '",acntClsDate: "' + acntClsDate + '",EnableAudit: "' + EnableAudit + '",CurrencyID: "' + CurrencyID + '",EnableConfirm: "' + EnableConfirm + '",Status: "' + Status + '",SalesStatus: "' + SalesStatus + '",customer: "' + customer + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",customerName: "' + customerName + '",PageMaxSize: "' + PageMaxSize + '",PageNumber: "' + PageNumber + '",strCommonSearchTerm: "' + strCommonSearchTerm + '",OrderColumn: "' + OrderColumn + '",OrderMethod: "' + OrderMethod + '",strInputColumnSearch: "' + strInputColumnSearch + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            window.open(data.d, '_blank');
                            return false;
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
        function PrintCSV()
        {

              //0039
              var strPageSize = 10;
              var strPageNumber = 1;

              var strCommonSearchString = "";
              if (document.getElementById("txtCommonSearch_dt")) {
                  strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                  strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
              }


              //Efficiently Paging Through Large Amounts of Data
              var intOrderByColumn = 0;
              var intOrderByStatus = 0;
              var intToltalSearchColumns = 0;
              var strInputColumnSearch = getColumnSearchData();//individual column search
              //end
              var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';
              var customer = 0;
              var customerName = "";
              var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
              var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
              var AuditPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
              var FinancialStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
              var FinancialEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
              var reOpenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
              var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
              var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
              var CurrencyID = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;
              var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
              var Status = document.getElementById("cphMain_ddlStatus").value;
              var SalesStatus = document.getElementById("cphMain_ddlsaleSts").value;
              if (document.getElementById("cphMain_ddlCustomer").value != "--SELECT CUSTOMER--") {
                  customer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
                  customerName = $("#cphMain_ddlCustomer :selected").text();
              }
              //0039

              if (document.getElementById("ddl_page_size")) {
                strPageSize = document.getElementById("ddl_page_size").value;
              }
              var PageMaxSize = strPageSize;
              var PageNumber = strPageNumber;


              var strCommonSearchTerm = strCommonSearchString;
              var OrderColumn = intOrderByColumn;//
              var OrderMethod = intOrderByStatus;//
              var strInputColumnSearch = strInputColumnSearch;

              //end 
              var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
              var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
              var CnclSts = 0;
              if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                  CnclSts = 1;
              }
              if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                  $.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "fms_Sales_Master_List.aspx/PrintCSV",
                      data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",EnableEdit: "' + EnableEdit + '",EnableDelete: "' + EnableDelete + '",AuditPrvision: "' + AuditPrvision + '",FinancialStartDate: "' + FinancialStartDate + '",FinancialEndDate: "' + FinancialEndDate + '",reOpenSts: "' + reOpenSts + '",acntClsDate: "' + acntClsDate + '",EnableAudit: "' + EnableAudit + '",CurrencyID: "' + CurrencyID + '",EnableConfirm: "' + EnableConfirm + '",Status: "' + Status + '",SalesStatus: "' + SalesStatus + '",customer: "' + customer + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",customerName: "' + customerName + '",PageMaxSize: "' + PageMaxSize + '",PageNumber: "' + PageNumber + '",strCommonSearchTerm: "' + strCommonSearchTerm + '",OrderColumn: "' + OrderColumn + '",OrderMethod: "' + OrderMethod + '",strInputColumnSearch: "' + strInputColumnSearch + '"}',
                      dataType: "json",
                      success: function (data) {
                          if (data.d != "") {
                              window.open(data.d, '_blank');
                              return false;
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
        function ConfirmByID(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to confirm this sales?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    Confirm(StrId);
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;

        }
        function Confirm(strPayemntId) {
          

            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var strFinID = '<%=Session["FINCYRID"]%>';

            if (strPayemntId != "" && strUserID != '') {

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/ConfirmSalesDetails",
                    data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",strFinID: "' + strFinID + '"}',
                    dataType: "json",
                    success: function (data) {
                       

                        var CONFIRMSts = data.d;
                        if (CONFIRMSts != '') {
                            $(window).scrollTop(0);
                            //LoadEmployeeList();
                            //0039
                            getdata(1);
                            //end
                            if (CONFIRMSts == 'successConfirm') {
                                SuccessConfirm();
                            }
                            else if (CONFIRMSts == 'failed') {
                                SuccessErrorReoen();
                            }
                            else if (CONFIRMSts == 'alrdydeleted') {
                                SuccessDeletedList();
                            }
                            else if (CONFIRMSts == 'acntclosed') {
                                AcntClosedList();
                            }
                            else if (CONFIRMSts == 'Auditclosed') {
                                AuditClosed();
                            }
                            else if (CONFIRMSts == 'alrdyconfrm') {
                                AlreadyConfirmed();
                            }
                        }
                    }
                });
            }

            return false;
        }
        function ChangeStatus(StrId, stsmode, cnclusrId) {
            if (cnclusrId == "") {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to change the status of this sale details?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var usrId = '<%= Session["USERID"] %>';

                        var Details = PageMethods.ChangeSaleStatus(StrId, stsmode, usrId, function (response) {
                            // alert(response.d);
                            var SucessDetails = response;
                            if (SucessDetails == "success") {
                                window.location = 'fms_Sales_Master_List.aspx?InsUpd=StsCh';
                            }
                            else {
                                window.location = 'fms_Sales_Master_List.aspx?InsUpd=Error';
                            }
                        });
                    }
                });
                return false;
            }
        }
        function OpenCancelView(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this sales details",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must
                        document.getElementById("lblErrMsgCancelReason").style.display = "none";
                        document.getElementById('txtCancelReason').style.borderColor = "";
                        document.getElementById('txtCancelReason').value = "";
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
        function OpenPrint(StrId) {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var UsrName = '<%= Session["USERFULLNAME"] %>';
            var saleId = StrId;
            if (corptID != "" && corptID != null && orgID != "" && orgID != null && saleId != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/PrintPDF",
                    data: '{saleId: "' + saleId + '",orgID: "' + orgID + '",corptID: "' + corptID + '",UsrName: "' + UsrName + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            if (data.d != "false") {
                                window.open(data.d, '_blank');
                            }
                        }
                        else {
                            PrintVersnError();
                        }
                    }
                });
            }
            else {
                window.location = '/Security/Login.aspx';
            }
            return false;
        }

        function PrintVersnError() {
            $noCon("#divWarning").html("Please select a version for printing from account setting.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            $(window).scrollTop(0);
            return false;
        }
        

        function CloseCancelView() {
            ReasonConfirm = document.getElementById("txtCancelReason").value;

            if (document.getElementById("<%=Hiddencnclsts.ClientID%>").value == "") {
                       ezBSAlert({
                           type: "confirm",
                           messageText: "Do you want to close  without completing cancellation process?",
                           alertType: "info"
                       }).done(function (e) {
                           if (e == true) {
                              $('#dialog_simple').modal('hide');
                           }
                           else {
                               $('#dialog_simple').modal('show');
                               $('#dialog_simple').on('shown.bs.modal', function () {
                                   document.getElementById("txtCancelReason").focus();
                               });
                               return false;
                           }
                       });
                       return false;
                   }
               }
        function DeleteByID(strmemotId, cnclRsn, reasonmust) {
            var usrId = '<%=Session["USERID"]%>';
            if (strmemotId != "" && usrId != '') {
                // alert(strId); alert(strCancelReason); alert(strCancelMust); alert(strUserID);


                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/CancelSalesMstr",
                    data: '{strmemotId: "' + strmemotId + '",reasonmust: "' + reasonmust + '",usrId: "' + usrId + '",cnclRsn: "' + cnclRsn + '"}',
                    dataType: "json",
                    success: function (data) {
                        $(window).scrollTop(0);
                        //0039
                        //LoadEmployeeList();
                        getdata(1);
                        //END
                        var SucessDetails = data.d;
                        if (SucessDetails == "successcncl") {
                            SuccessClose();
                        }
                        else {
                            SuccessErrorReoen();
                        }
                    }
                });
            }

            return false;
        }
        //validation when cancel process
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
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                    document.getElementById("txtCancelReason").style.borderColor = "red";
                    document.getElementById("lblErrMsgCancelReason").style.display = "";
                    $("div.war").fadeIn(200).delay(500).fadeOut(400);
                    return ret;
                }
                else {

                }
            }
          //  alert(ret);
            if (ret == true) {
                var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                DeleteByID(strId, strCancelReason, strCancelMust);
               $('#dialog_simple').modal('hide');
            }

            return false;

        }



        function ReOpenByID(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reopen this entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {


                    ReOpen(StrId);


                    return false;

                }
                else {
                    return false;
                }
            });
            return false;

        }



        function ReOpen(strPayemntId) {

            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';

            var strAuditPrvsn = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
            var strAcntPrvsn = document.getElementById("<%=HiddenProvisionSts.ClientID%>").value;

            if (strPayemntId != "" && strUserID != '') {


                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/ReopenReceiptDetails",
                    data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",strAuditPrvsn: "' + strAuditPrvsn + '",strAcntPrvsn: "' + strAcntPrvsn + '"}',
                    dataType: "json",
                    success: function (data) {

                        var ReopenSts = data.d;
                        if (ReopenSts != '') {
                            $(window).scrollTop(0);
                            //0039
                            //LoadEmployeeList();
                            getdata(1);
                            //END
                            if (ReopenSts == 'successReopen') {
                                SuccessReoen();
                            }
                            else if (ReopenSts == 'failed') {
                                SuccessErrorReoen();
                            }
                            else if (ReopenSts == 'alrdydeleted') {
                                SuccessDeletedList();
                            }
                            else if (ReopenSts == 'acntclosed') {
                                AcntClosedList();
                            }
                            else if (ReopenSts == 'Auditclosed') {
                                AuditClosed();
                            }
                            else if (ReopenSts == 'alrdyreopend') {
                                AlreadyReopened();
                            }



                        }
                    }
                });
            }

            return false;
        }


        function SuccessConfirmation() {
            $noCon("#success-alert").html("Sales details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            return false;
        }

        function SuccessUpdation() {
            $noCon("#success-alert").html("Sales details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            return false;
        }
        function SuccessClose() {
            $noCon("#success-alert").html("Sales details cancelled successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            $noCon("#divddlCustomer input.ui-autocomplete-input").focus();
            $noCon("#divddlCustomer input.ui-autocomplete-input").select();
            return false;

        }
        function SuccessStatusChange() {
            $noCon("#success-alert").html("Sales status changed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
            return false;
        }
    </script>
    <script>
        var $au = jQuery.noConflict();

        $au(function () {
            $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();
            //$au("#cphMain_ddlCustomer").focus();
        });

    </script>
</asp:Content>

