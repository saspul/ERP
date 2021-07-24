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
   




<%--    <link href="../../../css/New%20css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../css/bootstrap.css" rel="stylesheet" />--%>


<%--        <script src="../../../js/New%20js/js/ajax.js"></script>

<script src="../../../js/New%20js/js/boot.min.js"></script>--%>

<link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i" rel="stylesheet"/>
<!---Font_Awesome_section_opened----------->
  <link href="../../../css/New%20css/font_awe/css/font-awesome.css" rel="stylesheet" />
  <link href="../../../css/New%20css/font_awe/css/font-awesome.min.css" rel="stylesheet" />
<!---Font_Awesome_section_closed----------->

<!--------css_Included------->




    <style>
        /*.ui-autocomplete {
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
                 .ui-autocomplete {
               position: absolute;
               cursor: default;
               z-index: 4000 !important;
           }*/
             
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

           .ui-autocomplete {
               position: absolute;
               cursor: default;
               z-index: 4000 !important;
           }
   
           .butn2 {
    background-color: #8BC34A;}
.butn3 {
    background-color: #e29151;} 
.butn4 {
    background-color: #ff6464;}

.spl_krn {
    width: 60%;height: 90px;margin: auto;background-color: rgba(216, 237, 252, .4);
    padding: 20px;margin-bottom: 30px;float: left;border-radius: 4px;margin-right: 30px;} 
.sls_77 {
    width: 33.33%;height:70px;margin: auto;float: left;margin-top: 20px;}
.sls_077 {
    width: 33.33%;height:70px;margin: auto;float: left;margin-top: 20px;}
.head_lab7{margin-bottom: 15px;}
.box_too7.arrow-top7:before {content: " ";position: relative;top: 12px;right: 210px;border-bottom: none;
                              border-right: 0px solid transparent;border-left: 200px solid transparent;
                                border-top: 15px solid rgb(20, 204, 34);z-index: 99999999999;margin: auto;}

.box_tooo.arrow-topo:before {content: " ";position: relative;top: -35px;left: 335px;border-top: none;
                              border-right: 20px solid transparent;border-left: 20px solid transparent;
                                border-bottom: 15px solid rgb(20, 204, 34);z-index: 99999999999;margin: auto; margin-top: -24px;}


.fg2_inp3{width: 100%!important;margin-right: 20px;}
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

              //LoadExpenseDetails();//EVM 0044

              //END
              //loadTableDesg();

              document.getElementById("<%=hiddenPrdctCnclDtls.ClientID%>").value = "";
              document.getElementById("<%=hiddenCnclDtls.ClientID%>").value = "";

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
          function SuccessConfirm() {
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

              if (fromdate != "" && toDate != "") {

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
            if (orgID == "") {
                window.location.href = "/Default.aspx";
                return false;
            }
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
        //----------------0044
        function ConfirmMessageList() {
            if (confirmbox > 0) {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to leave this page?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        window.location.href = "fms_Sales_Master_List.aspx";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
            }
            else {
                window.location.href = "fms_Sales_Master_List.aspx";
                return false;
            }
            return false;
        }

        function ConfirmMessage() {

            /// jQuery('#ExpTable').empty();
            document.getElementById("<%=Hiddenpopup.ClientID%>").value = 0;

            if (confirmbox > 0 || document.getElementById("<%=HiddenFieldCancelsts.ClientID%>").value == "1") {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to leave this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    // window.location.href = "fms_Sales_Master_List.aspx";
                    $('.modal').modal('hide');
                    return false;
                }
                else {
                    return false;
                }
            });
        }
            else {
                //rebug
                $('.modal').modal('hide');
                
           // window.location.href = "fms_Sales_Master_List.aspx";
            return false;
        }
        return false;
    }
    function AlertClearAll() {
        if (confirmbox > 0) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want clear all data in this page?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    window.location.href = "fms_Sales_Master_List.aspx";
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        else {
            window.location.href = "fms_Sales_Master_List.aspx";
            return false;
        }
        return false;
    }
    function ExpSuccessInsertion() {
        $("#success-alert").html("Expense inserted successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function ExpSuccessUpdation() {
        $("#success-alert").html("Expense updated successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function ExpSuccessConfirmation() {
        $("#success-alert").html("Expense confirmed successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }

    function ExpSuccessReopen() {
        $("#success-alert").html("Expense reopened successfully.");
        $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
        });
        return false;
    }


    function ExpConfirmAlert() {
        //ezBSAlert({
        //    type: "confirm",
        //    messageText: "Are you sure you want to confirm this expense?",
        //    alertType: "info"
        //}).done(function (e) {
        //    if (e == true) {
                document.getElementById("<%=btnConfirmClick.ClientID%>").click();
        //}
        //});
    function ExpConfirmError() {
        $noCon("#divWarning").html("Expense details already confirmed.");
        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        });

        // ddlAccountName.Focus();
        return false;
    }
    function ExpReopenError() {
        $noCon("#divWarning").html("Expense details already reopened.");
        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
        });

        // ddlAccountName.Focus();
        return false;
    }

    return false;
}

function ExpReopenAlert() {
    //ezBSAlert({
    //    type: "confirm",
    //    messageText: "Are you sure you want to reopen this expense?",
    //    alertType: "info"
    //}).done(function (e) {
    //    if (e == true) {
            document.getElementById("<%=btnReopenClick.ClientID%>").click();
    //}
    //});
   /// return false;
}
function LoadExpenseDetails(View) {
    //alert("view"+View);

    document.getElementById("<%=Hiddencnt.ClientID%>").value = 0;

    if (document.getElementById("<%=hiddenExpenseDtls.ClientID%>").value != "[]" && document.getElementById("<%=hiddenExpenseDtls.ClientID%>").value != "") {

                $("#cphMain_btnSave").hide();
                $("#cphMain_btnSaveAndClose").hide();
                $("#cphMain_btnClear").hide();
                if (View != "1") {
                    $("#cphMain_btnUpdate").show();
                    $("#cphMain_btnUpdateAndClose").show();
                  //  $("#cphMain_btnConfirm").show();
                  //  $("#cphMain_btnReopen").hide();
                }
                else {



                    $("#cphMain_btnUpdate").hide();
                    $("#cphMain_btnUpdateAndClose").hide();
                 //   $("#cphMain_btnConfirm").hide();
                  //  $("#cphMain_btnReopen").show();
                }

                //0041


                var Count = 1;
                var EditVal = document.getElementById("<%=hiddenExpenseDtls.ClientID%>").value;



                var findAtt2 = '\\"\\[';
                var reAtt2 = new RegExp(findAtt2, 'g');
                var resAtt2 = EditVal.replace(reAtt2, '\[');

                var findAtt3 = '\\]\\"';
                var reAtt3 = new RegExp(findAtt3, 'g');
                var resAtt3 = resAtt2.replace(reAtt3, '\]');

                var jsonAtt = $.parseJSON(resAtt3);
                //var jsonAtt = JSON.parse(resAtt3);
                var numr = 0;

                for (var key in jsonAtt) {

                    if (jsonAtt.hasOwnProperty(key)) {



                        if (jsonAtt[key].EXPENSEID != "") {



                            EditExpense(jsonAtt[key].EXPENSEID, jsonAtt[key].PARTYHDID, jsonAtt[key].PARTYHDNAME, jsonAtt[key].EXPDESC, jsonAtt[key].EXPAMNT, jsonAtt[key].DTLID, jsonAtt[key].PRDCTDTLS, Count, jsonAtt[key].PAID_AMNT, jsonAtt[key].BALNC_AMNT);

                            if (parseInt(Count + 1) < parseInt(jsonAtt.length)) {

                                document.getElementById("btnAdd" + Count).disabled = true;
                               
                            }

                            Count++;
                            //alert("done");
                          
                        }
                        

                    }
                   
                }

                
            }
    else {

        $("#cphMain_btnSave").show();
        $("#cphMain_btnSaveAndClose").show();
                $("#cphMain_btnClear").hide();
                $("#cphMain_btnUpdate").hide();
                $("#cphMain_btnUpdateAndClose").hide();
              //  $("#cphMain_btnConfirm").hide();
               // $("#cphMain_btnReopen").hide();
                //alert("count"+Count);
                AddExpenseData();
            }
        }

        function isNumberAmount(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (keyCodes == 13) {

                return false;

            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 38 || keyCodes == 40) {
                return true;
            }
            else if (keyCodes == 36 || keyCodes == 35 || keyCodes == 41) {
                return false;
            }
            if (keyCodes == 46)
                return true;

            if (keyCodes > 31 && (keyCodes < 48 || keyCodes > 57)) {
                return false;
            }




            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    ret = false;
                }
                return ret;
            }
        }

        var CountRows = 1;
        function loadExpense(mode) {

            //0041
            
            if (document.getElementById("<%=Hiddencnt.ClientID%>").value == 0) {

                CountRows = 1;
                document.getElementById("<%=Hiddencnt.ClientID%>").value = 1;
               // alert("o");
                
            }

            if (mode == "0") {

                jQuery('#ExpTable').empty();
               // alert("fail");

            }
            else {
                CountRows++;
            }


            //for (i = 0; i < 5; i++) {
           


            document.getElementById("<%=HiddenFieldCancelsts.ClientID%>").value = "0";

            var recRow;
            document.getElementById("<%=Hiddencnt.ClientID%>").value = CountRows;
            
            var CrncyAbrv = document.getElementById("<%=HiddenCurrencyAbrevation.ClientID%>").value;
            if (CountRows % 2 == 1) {
                recRow = '<tr id="trRowId_' + CountRows + '" >';
            }
            else {
                recRow = '<tr id="trRowId_' + CountRows + '" class="tr1" >';
                
            }
            recRow += '<td id="tdId' + CountRows + '" style="display: none;">' + CountRows + '</td>';
            recRow += '<td class="tr_c">';
            //0041
           // alert(CountRows);
            recRow += '<div id="Setlsts' + CountRows + '" >';
            
            recRow += '</div>';
        
            recRow += '</td>';
            recRow += '<td>';
            recRow += '<div id="divParty_' + CountRows + '"><input id="ddlParty' + CountRows + '" type="text" name="ddlParty' + CountRows + '" class="fg2_inp2 fg2_inp3 fg_chs1" autocomplete="off" placeholder="-Select-" maxlength="150"  onkeypress="return LoadParty(' + CountRows + ');" onkeydown="return LoadParty(' + CountRows + ');" onkeyup="IncrmntConfrmCounter();" /></div>';

            recRow += '</td>';
            recRow += '<td class=" tr_r">';
            recRow += '<div class="input-group mr_at flt_l">';
            recRow += '<span id="spAmtCrncy' + CountRows + '" name="spAmtCrncy' + CountRows + '" class="input-group-addon cur1">' + CrncyAbrv + '</span>';
            recRow += '<input id="txtAmount' + CountRows + '" name="txtAmount' + CountRows + '" type="text"  class="form-control fg2_inp2 tr_r" name="email" placeholder="0.00" onkeyup="calmnt('+CountRows+')" >';
            recRow += '</div>';
            recRow += '</td>';
            recRow += '<td class=" tr_r" id="SetleAmt' + CountRows + '" name="SetleAmt' + CountRows + '"></td>';
            recRow += '<td class=" tr_r" id="BalncAmt' + CountRows + '" name="BalncAmt' + CountRows + '"></td>';
            recRow += '<td>';
            recRow += '<textarea id="txtNarration' + CountRows + '" name= "txtNarration' + CountRows + '" rows="2" cols="50" class="form-control" placeholder="Write something here..."  maxlength="50" style="margin: 0px 23px 0px 0px; height: 42px; width: 172px;"></textarea>';
            recRow += '</td>';
            recRow += '<td class="td1">';
            recRow += '<div class="btn_stl1">';
            recRow += '<button class="btn act_btn bn7 shw_dwn" id="btnDisp' + CountRows + '" title="Add Items"  onclick ="return AddExpense(' + CountRows + ',' + 0 + ');"><i class="fa fa-newspaper-o "></i></button>';
            recRow += '<button class="btn act_btn bn2" title="Add" id="btnAdd' + CountRows + '" onclick="return CheckaddMoreRows(' + CountRows + ');">';
            recRow += '<i class="fa fa-plus-circle"></i>';
            recRow += '</button>';
            //0041


            if (document.getElementById("<%=Confirmsts.ClientID%>").value == "1") {
                recRow += '<button class="btn act_btn bn3" disabled="true" title="Delete"id="btnDelete' + CountRows + '" onclick="return RemoveRows(' + CountRows + ');">';
                recRow += '<i class="fa fa-trash"></i>';
                recRow += '</button>';
            }
            else {

                recRow += '<button class="btn act_btn bn3" title="Delete"  id="btnDelete' + CountRows + '" onclick="return RemoveRows(' + CountRows + ');">';
                recRow += '<i class="fa fa-trash"></i>';
                recRow += '</button>';
            }
            recRow += '</div>';
            recRow += '<span id="disptd' + CountRows + '" class="add_dedu" style="display: none!important;background-color: #fff;width:640px;height:auto;position:absolute;min-height: 200px;z-index: 99;right:0px;box-shadow: 4px 4px 10px #ccc;border-top: 2px solid #14cc22;float: right;padding:20px;z-index: 9999999;">';
            recRow += '</span>';
            recRow += '</td>';


            recRow += '<td style="display: none;"><input id="tdPartyId' + CountRows + '" value="-Select-"></td>';
            recRow += '<td style="display: none;"><input id="tdPartyName' + CountRows + '" ></td>';
            recRow += '<td style="display: none;"><input id="tdExpenseId' + CountRows + '" name="tdExpenseId' + CountRows + '"></td>';
            recRow += '<td id="tdEvt' + CountRows + '" style="width:0%;display: none;">INS</td>';
            recRow += '<td id="tdDtlId' + CountRows + '" style="width:0%;display: none;">0</td>';
            recRow += '<td style="display:none;"><input id="tdPrdtdetails' + CountRows + '" name="tdPrdtdetails' + CountRows + '" type="text" /></td>';
            recRow += '</tr>';
            jQuery('#ExpTable').append(recRow);

            document.getElementById("<%=ExpTotal.ClientID%>").value = "0.00 " + CrncyAbrv;
            document.getElementById("<%=SetlTotal.ClientID%>").value = "0.00 " + CrncyAbrv;
            document.getElementById("<%=BalTotal.ClientID%>").value = "0.00 " + CrncyAbrv;
            document.getElementById("<%=Hiddeneamt.ClientID%>").value = "0.00 ";
            
            return false;

            //}

        }

        var CountProducts = 1;
        function AddExpense(row, mode) {
            CountProducts = 1;

            //007
            if (document.getElementById("<%=Hiddenpopup.ClientID%>").value != 1) {

               // alert("bb"+document.getElementById("tdPrdtdetails" + row).value);

                var Prdct = document.getElementById("tdPrdtdetails" + row).value;

                if (Prdct != "") {
                    var prdctsplival = Prdct.split('%');
                    if (prdctsplival[0] == "") {
                        Prdct = "";
                    }
                   // alert("aa" + prdctsplival[0]);
                }
                // alert(document.getElementById("tdExpenseId" + row).value);

                if (Prdct=="") {

                    

                    var CorpId = '<%= Session["CORPOFFICEID"] %>';
                    var OrgId = '<%=Session["ORGID"]%>';

                    saleid = document.getElementById("<%=hiddenSalesId.ClientID%>").value;
                    var prdt;
                    var product;
                    var prdid;
                    var productsplit = "";
                    var prdidsplit = "";

                    $.ajax({
                        async: false,
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "fms_Sales_Master_List.aspx/LoadProdts",
                        data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",SalesId:"' + saleid + '"}',
                        success: function (data) {


                            product = data.d[0];
                            prdid = data.d[1];
                            //  alert(product);
                            // alert(prdid);
                            productsplit = product.split(',');
                            prdidsplit = prdid.split(',');
                            //alert(productsplit[0]);




                        }
                    });
                    document.getElementById("tdPrdtdetails" + row).value = "";

                    var p;
                    for (p = 0; p < productsplit.length; p++) {

                        if (document.getElementById("tdPrdtdetails" + row).value == "") {
                            document.getElementById("tdPrdtdetails" + row).value = prdidsplit[p] + "%" + productsplit[p] + "%" + "" + "%" + "0";
                        }
                        else {

                            document.getElementById("tdPrdtdetails" + row).value = document.getElementById("tdPrdtdetails" + row).value + "$" + prdidsplit[p] + "%" + productsplit[p] + "%" + "" + "%" + "0";
                        }
                    }
                }
            loadProductDetails(row, mode);
            CalculateprdtTotal(row);//0044 16/6
        }
            return false;
        }

        function calmnt(CountRows) {


            LoadExpTotal();
            //kik

            document.getElementById("BalncAmt" + CountRows).innerHTML = "0";

            if (Number(document.getElementById("<%=Hiddeneamt.ClientID%>").value) > Number(document.getElementById("<%=Hiddensamt.ClientID%>").value)) {

                $noCon("#divWarning").html("The expense amount exceeded than the sales amount!");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                return false;

            }

        }
        function AddExpenseData(row, mode) {

            //alert(row);
            //if (CheckAndHighlight(row, 0, "") == true) {
            //alert(row);

            if (mode == 0) {


                jQuery('#disptd' + row).empty();
                //jQuery('#PrdtTable' + row).empty();
                //alert("rowId"+row);
            }
            else {
                //alert("count"+CountProducts);
                CountProducts++;
            }


            var recRow;
            var prdtRow;
            var CrncyAbrv = document.getElementById("<%=HiddenCurrencyAbrevation.ClientID%>").value;

            recRow = '<table id="PrdtTable' + row + '"  class="add_dedu"  >';
            recRow += '<tr style="background-color: #4298d4;color:#fff;border-top:none;">';
            recRow += '<td style="display: none;">0</td>';
            recRow += '<td id="tdPrdtId' + row + '" style="display: none;">' + row + '</td>';
            recRow += '<td class="tr_l" style="width:400px;margin:auto;font-weight: 600;border-top:none;">Product</td>';
            recRow += '<td class="tr_r" style="width:200px;margin:auto;font-weight: 600;border-top:none;">Amount</td>';
           // recRow += '<td class="tr_c" style="width:150px;margin:auto;float: left;font-weight: 600;border-top:none;">Actions</td>';
            recRow += '</tr>';
            //bug

            recRow += '<tbody id="Prdttbody' + row + '">';
            recRow += '<tr id="trPrdt_' + row + CountProducts + '" style="color:#333;">';
            recRow += '<td id="tdPrdtId' + row + CountProducts + '" style="display: none;">' + row + CountProducts + '</td>';
            recRow += '<td class="tr_l" class="tr_l" style="width:400px;margin:auto;>';
            recRow += '<div id="divProduct_' + row + CountProducts + '"><input id="ddlProducts' + row + CountProducts + '" type="text" name="ddlProducts' + row + CountProducts + '" class="fg2_inp2 fg2_inp3 fg_chs1" autocomplete="off" placeholder="-Select-" maxlength="150"  onkeypress="return LoadProducts(' + row + CountProducts + ',\'ddlProducts\');" onkeydown="return LoadProducts(' + row + CountProducts + ',\'ddlProducts\');" onkeyup="IncrmntConfrmCounter()" /></div>';
            recRow += '</td>';
            recRow += '<td class="tr_r" style="width:200px;margin:auto;">';
            recRow += '<input id="txtPrice' + row + CountProducts + '" name="txtPrice' + row + CountProducts + '" autocomplete="off"  class="\tr_r form-control fg2_inp2 brd_r hei_25\" type="text" onChange="return CalculateprdtTotal(' + row + ');" placeholder="0.00" style="text-align: right"  maxlength="10" onkeypress=\"return isNumberAmount(event,\'txtPrice' + row + CountProducts + '\')\" onkeydown=\"return isNumberAmount(event,\'txtPrice' + row + CountProducts + '\')\">';
            recRow += '</td>';
           // recRow += '<td class="tr_c" style="width:150px;margin:auto;float: left;">';
            if (document.getElementById("<%=Confirmsts.ClientID%>").value == "1") {
               // recRow += '<button class="btn act_btn bn2" title="Add" style="display: none;"  disabled="true" id="btnPdtAdd' + row + CountProducts + '"onclick="return CheckaddMorePrdtRows(' + row + ',' + CountProducts + ');"><i class="fa fa-plus-circle"></i></button>';
            }
            else {
              //  recRow += '<button class="btn act_btn bn2" style="display: none;" title="Add" disabled="true" id="btnPdtAdd' + row + CountProducts + '"onclick="return CheckaddMorePrdtRows(' + row + ',' + CountProducts + ');"><i class="fa fa-plus-circle"></i></button>';
            }
            //042
            if (document.getElementById("<%=Confirmsts.ClientID%>").value == "1") {

               // recRow += '<button class="btn act_btn bn3" title="Delete" disabled="true" id="btnPdtDelete' + row + CountProducts + '"onclick="return RemoveData(' + row + ',' + CountProducts + ');">';
               // recRow += '<i class="fa fa-trash"></i>';
               // recRow += '</button>';
            }

            else {

               // recRow += '<button class="btn act_btn bn3" disabled="true" title="Delete" id="btnPdtDelete' + row + CountProducts + '"onclick="return RemoveData(' + row + ',' + CountProducts + ');">';
               // recRow += '<i class="fa fa-trash"></i>';
               // recRow += '</button>';

            }
           // recRow += '</td>';
            recRow += ' </tr>';
            recRow += '</tbody>';

            //<!---total row---->

            // recRow += '<tfoot class=""style="background-color: #fff;width:640px;height:auto;position:min-height: 20px;z-index: 99;right:0px;box-shadow: 4px 4px 10px #ccc;float: right;padding:0px;padding-top:0px;bottom:0;padding-bottom:4px;border-bottom: 2px solid #14cc22;">';
            recRow += '<tr class="bg1 txt_rd">';
            recRow += '<td style="display: none;">0</td>';
            recRow += '<td class="tr_r"   style="width:400px;margin:auto;border:none!important;text-align: right;">Total</td>';
            recRow += '<td id="prdtTotal' + row + '" class="tr_r"  style="width:200px;margin:auto;border:none!important;">0.00 ' + CrncyAbrv + '</td>';
            recRow += '<td class="tr_c" style="width:0px;margin:auto;border:none!important;"></td>';
            recRow += '</tr>';
            recRow += '</table>';
            //  // <!---total row---->

            recRow += '<table style="margin-top:-20px; float: right;">';
            //0041

            recRow += '<tbody>';
            recRow += '  <tr class="" style="width:100%;color:#0175c5;border:none;float: right!important;">';
            
            recRow +='   <td class="tr_r" style="margin:auto;float: right;font-weight: 400;border:none!important;margin-right: 40px;margin-bottom:5px;margin-top: 10px;">SETTLEMENT</td>';
            recRow += '</tr>';
            recRow +='<br>';
            recRow +=' <tr class="" style="color:#48acf2;border:none;float: right!important;">';
            recRow += '<td class="tr_r" style="width:200px;margin:auto;float: left;font-weight: 400;border:none!important;">Expense Amount:</td>';
            if (document.getElementById("txtAmount" + row).value == "") {

                recRow += ' <td class="tr_r" id="setlamt1" style="width:100px;margin:auto;float: left;font-weight: 400;border:none!important;margin-right: 40px;">0.00' + CrncyAbrv + '</td>';
            }
            else {
                recRow += ' <td class="tr_r" id="setlamt1" style="width:100px;margin:auto;float: left;font-weight: 400;border:none!important;margin-right: 40px;">' + document.getElementById("txtAmount" + row).value + CrncyAbrv + '</td>';
            }
            
            recRow += '</tr>';
            recRow +='  <tr class="" style="color:#48acf2;border:none;float: right!important;">';
            recRow +=  '  <td class="tr_r" style="width:200px;margin:auto;float: left;font-weight: 400;border:none!important;">Product Total:</td>';
            recRow += '   <td class="tr_r" id="setlamt2" style="width:100px;margin:auto;float: left;font-weight: 400;border:none!important;margin-right: 40px;">0.00'+ CrncyAbrv +'</td>';
            recRow +=' </tr>';
            recRow +=' <tr class="" style="color:#48acf2;border:none;float: right!important;">';
            recRow +='  <td class="tr_r" style="width:200px;margin:auto;float: left;font-weight: 400;border:none!important;">Balance:</td>';
            recRow += ' <td class="tr_r" id="setlamt3" style="width:100px;margin:auto;float: left;font-weight: 400;border:none!important;margin-right: 40px;">0.00'+ CrncyAbrv +'</td>';
            recRow += '</tr>';
            recRow += ' <tr class="">';
            recRow +='   <td class="tr_c" style="width: 400px;border: none!important;border-top:1px solid #ccc!important;margin: auto;margin-bottom: 20px;"></td>';
            recRow +=  '</tr>';
            recRow += ' <br>';



            recRow += '</tbody>';


            ////  <!----buttons row--->

            recRow += '<tr  class="">';
            recRow += '<td style="display: none;">0</td>';
            recRow += '<td class="tr_r" style="width:283px;margin:auto;float: left;border:none!important;border-right:1px solid #ddd!important;">';
            recRow += '</td>';
            recRow += '<td class="tr_r" style="width:283px;margin:auto;float:right;border:none!important;padding-top:10px;">';
            recRow += '<button type="submit" id="btnupd" class="btn sub1" style="margin-right:4px;" onClick="return FillProductDetails(' + row + ',' + CountProducts + ');">Update</button>';
            recRow += '<button type="submit" class="btn sub4 shw_dwn" onClick="return removeExpenseData(' + row + ');">Cancel</button>';
            recRow += '</td>';
            recRow += '<td style="display: none;"><input id="tdProductId' + row + CountProducts + '" value="-Select-"></td>';
            recRow += '<td style="display: none;"><input id="tdProductName' + row + CountProducts + '" ></td>';
            recRow += '<td id="tdPrdtEvt' + row + CountProducts + '" style="width:0%;display: none;">INS</td>';
            recRow += '<td id="tdPrdtDtlId' + row + CountProducts + '" style="width:0%;display: none;">0</td>';
            recRow += '<td id="tdMainRow' + row + CountProducts + '" style="width:0%;display: none;">' + row + '</td>';

            recRow += '</tr>';
            // recRow += '</tfoot>';
            recRow += '</table>';

            //  <!----buttons row_closed--->

            if (mode == "0") {
                jQuery('#disptd' + row).append(recRow);

            }
            else {
                prdtRow += '<tr id="trPrdt_' + row + CountProducts + '" style="color:#333;">';
                prdtRow += '<td id="tdPrdtId' + row + CountProducts + '" style="display: none;">' + row + CountProducts + '</td>';
                prdtRow += '<td class="tr_l" style="width:400px;margin:auto;">';
                prdtRow += '<div id="divProduct_' + row + CountProducts + '"><input id="ddlProducts' + row + CountProducts + '" type="text" name="ddlProducts' + row + CountProducts + '" class="fg2_inp2 fg2_inp3 fg_chs1" autocomplete="off" placeholder="-Select-"   onkeypress="return LoadProducts(' + row + CountProducts + ',\'ddlProducts\');" onkeydown="return LoadProducts(' + row + CountProducts + ',\'ddlProducts\');" onkeyup="IncrmntConfrmCounter()" /></div>';
                prdtRow += '</td>';
                prdtRow += '<td class="tr_r" style="width:200px;margin:auto;">';
                prdtRow += '<input id="txtPrice' + row + CountProducts + '"   autocomplete="off"  class="\tr_r form-control fg2_inp2 brd_r hei_25\" type="text" onChange="return CalculateprdtTotal(' + row + ');" placeholder="0.00"  style="text-align: right"  onkeypress=\"return isNumberAmount(event,\'txtPrice' + row + CountProducts + '\')\" onkeydown=\"return isNumberAmount(event,\'txtPrice' + row + CountProducts + '\')\">';
                prdtRow += '</td>';

              //  prdtRow += '<td class="tr_c" style="width:150px;margin:auto;float: left;">';
                if (document.getElementById("<%=Confirmsts.ClientID%>").value == "1") {
                  //  prdtRow += '<button class="btn act_btn bn2" title="Add" disabled="true"  id="btnPdtAdd' + row + CountProducts + '"onclick="return CheckaddMorePrdtRows(' + row + ',' + CountProducts + ');"><i class="fa fa-plus-circle"></i></button>';
                }
                else {
                   // prdtRow += '<button class="btn act_btn bn2" title="Add" disabled="true" id="btnPdtAdd' + row + CountProducts + '"onclick="return CheckaddMorePrdtRows(' + row + ',' + CountProducts + ');"><i class="fa fa-plus-circle"></i></button>';
                }
                //recRow+=     '<button class="btn act_btn bn1" title="Edit">';
                //recRow+=    ' <i class="fa fa-edit"></i>';
                //recRow+=  '</button>';
                if (document.getElementById("<%=Confirmsts.ClientID%>").value == "1") {

                   // prdtRow += '<button class="btn act_btn bn3" disabled="true" title="Delete" id="btnPdtDelete' + row + CountProducts + '"onclick="return RemoveData(' + row + ',' + CountProducts + ');">';
                }
                else {

                  //  prdtRow += '<button class="btn act_btn bn3"  disabled="true" title="Delete" id="btnPdtDelete' + row + CountProducts + '"onclick="return RemoveData(' + row + ',' + CountProducts + ');">';
                }
              //  prdtRow += '<i class="fa fa-trash"></i>';
               // prdtRow += '</button>';
               // prdtRow += '</td>';
                prdtRow += '<td style="display: none;"><input id="tdProductId' + row + CountProducts + '" value="-Select-"></td>';
                prdtRow += '<td style="display: none;"><input id="tdProductName' + row + CountProducts + '" ></td>';
                prdtRow += '<td id="tdPrdtEvt' + row + CountProducts + '" style="width:0%;display: none;">INS</td>';
                prdtRow += '<td id="tdPrdtDtlId' + row + CountProducts + '" style="width:0%;display: none;">0</td>';
                recRow += '<td id="tdMainRow' + row + CountProducts + '" style="width:0%;display: none;">' + row + '</td>';
                prdtRow += ' </tr>';
                jQuery('#Prdttbody' + row).append(prdtRow);
            }

            //alert(row);
            document.getElementById("disptd" + row).style.display = "block";

            return false;
        }
        function removeExpenseData(row) {
            document.getElementById("disptd" + row).style.display = "none";
            document.getElementById("<%=Hiddenpopup.ClientID%>").value = "0";
            return false;
        }
        function EditExpense(EXPENSEID, PARTYHDID, PARTYHDNAME, EXPDESC, EXPAMNT, DTLID, PRDCTDTLS, Count, PAID_AMNT, BALNC_AMNT) {
            //alert("count"+Count);

            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CrncyAbrv = document.getElementById("<%=HiddenCurrencyAbrevation.ClientID%>").value;
            var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;


            if (Count == "1") {
                // alert("A");

                //0041
               
                //your code to be executed after 1 second
                loadExpense(0);
                
                loadProductDetails(Count, 0);




                //alert(EXPAMNT);
            }
            else {
                loadExpense(Count);
                loadProductDetails(Count, Count);
            }
          //  CountRows = Count;
            var dispsetlsts = '';

            //alert("chec" + Count);

            document.getElementById("<%=hiddenExpenseId.ClientID%>").value = EXPENSEID;
            document.getElementById("tdExpenseId" + Count).value = EXPENSEID;
            document.getElementById("ddlParty" + Count).value = PARTYHDNAME;
            document.getElementById("tdPartyId" + Count).value = PARTYHDID;
            document.getElementById("tdPartyName" + Count).value = PARTYHDNAME;
            document.getElementById("txtNarration" + Count).value = EXPDESC;
            document.getElementById("txtAmount" + Count).value = BlurAmountReturn(EXPAMNT, FloatingValue);//addCommasReturn(, CrncyModeId);
            document.getElementById("tdDtlId" + Count).innerHTML = DTLID;
            document.getElementById("tdEvt" + Count).innerHTML = "UPD";
            document.getElementById("tdPrdtdetails" + Count).value = PRDCTDTLS;
            //0041
            
            if (PAID_AMNT == EXPAMNT) {

                dispsetlsts += '<div class="bo_not1" title="Fully Settled">';
                dispsetlsts += '<i class="fa fa-square"></i>';
                dispsetlsts += '</div>';
                
                
             //   $("#cphMain_btnReopen").hide();
                
                document.getElementById("<%=Hidden.ClientID%>").value = "1";
                
            }
            else if (PAID_AMNT == 0) {

                
                dispsetlsts += ' <div class="bo_not3">';
                dispsetlsts += '<i class="fa fa-square"></i>';
                dispsetlsts += '</div>';
               
            }
            else if (PAID_AMNT > 0) {

                dispsetlsts += '<div class="bo_not2" title="Partially Settled">';
                dispsetlsts += '<i class="fa fa-square"></i>';
                dispsetlsts += '</div>';
                
                document.getElementById("<%=Hidden.ClientID%>").value = "1";
            }
            document.getElementById("Setlsts"+Count).innerHTML = dispsetlsts;

          
            
            document.getElementById("SetleAmt" + Count).innerHTML = BlurAmountReturn(PAID_AMNT, FloatingValue); 
            document.getElementById("BalncAmt" + Count).innerHTML = BlurAmountReturn(BALNC_AMNT, FloatingValue);
                //if (document.getElementById("SetleAmt" + Count).innerHTML == "" && document.getElementById("BalncAmt" + Count).innerHTML=="") {

                //    document.getElementById("SetleAmt" + Count).innerHTML = 0;
                //    document.getElementById("BalncAmt" + Count).innerHTML = EXPAMNT;
                //}
                
            
            document.getElementById("disptd" + Count).style.display = "none";

            //41n
            LoadExpTotal();//0044 16/6
            //0041
            //CalculateExpTotal(row);
        }

        function AutoCompleteTextBox(TextId, Rowx, sts) {
            $noCon(TextId + Rowx).autocomplete({
                source: function (request, response) {

                    var strOrgId = '<%=Session["ORGID"]%>';
                var strCorpId = '<%=Session["CORPOFFICEID"]%>';
                var objSearchMstr = {};
                objSearchMstr.prefix = request.term;
                objSearchMstr.strOrgid = strOrgId;
                objSearchMstr.strCorpid = strCorpId;
                $noCon.ajax({
                    url: '<%=ResolveUrl("fms_Sales_Master.aspx/DropdownProductBind") %>',
                            data: JSON.stringify(objSearchMstr),
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($noCon.map(data.d, function (item) {
                                    return {
                                        label: item.split('—')[0],
                                        val: item.split('—')[1]
                                    }
                                }))
                            },
                            error: function (response) {

                            },
                            failure: function (response) {
                            }
                        });
            },
            autoFocus: true,
            select: function (e, i) {
                var srtSearchItemMstr = i.item.label;
                document.getElementById("txtproductName" + Rowx).value = i.item.label;
                document.getElementById("txtproductId" + Rowx).value = i.item.val;
                $noCon("#ddlProduct_" + Rowx).attr("title", i.item.label);


                document.getElementById('txtQntity' + Rowx).value = 1;
                document.getElementById('txtQntity' + Rowx).readOnly = false;
                document.getElementById('txtQntity' + Rowx).style.pointerEvents = "painted";
                document.getElementById('txtRate' + Rowx).style.pointerEvents = "painted";
                document.getElementById('txtRate' + Rowx).readOnly = false;

                $(".ddlProduct_" + Rowx).focus();
                BlurValue(Rowx, 'txtDisPercent');

            },
            minLength: 3
        });
            }



            var confirmbox = 0;

            function IncrmntConfrmCounter() {
                confirmbox++;
            }




            function GetExpenseData(x, SalesId) {
                
                //alert("getData" + x + "saleId" + SalesId);
                document.getElementById("<%=hiddenSalesId.ClientID%>").value = SalesId;

            var salesref = document.getElementById("tblPagingTable").rows[x].cells[0].innerHTML;
            var salesdate = document.getElementById("tblPagingTable").rows[x].cells[1].innerHTML;
            var customerName = document.getElementById("tblPagingTable").rows[x].cells[2].innerHTML;
            var salesAmount = document.getElementById("tblPagingTable").rows[x].cells[3].innerHTML;
               
            document.getElementById("<%=Hiddensamt.ClientID%>").value = salesAmount.replace(/\,/g, '');
            document.getElementById("salesRef").innerText = salesref;
            document.getElementById("salesDate").innerText = salesdate;
            document.getElementById("custName").innerText = customerName;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CrncyAbrv = document.getElementById("<%=HiddenCurrencyAbrevation.ClientID%>").value;
                var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;
            var salesAmtxt = BlurAmountReturn(salesAmount, FloatingValue);
            document.getElementById("salesAmt").innerText = addCommasReturn(salesAmount, CrncyModeId) + " " + CrncyAbrv;;
            

            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%= Session["ORGID"] %>';

            $.ajax({
                async: false,
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: "fms_Sales_Master_List.aspx/LoadData",
                data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",SalesId:"' + SalesId + '"}',
                success: function (data) {


                    document.getElementById("<%=txtExpDate.ClientID%>").value = data.d[0];
                    document.getElementById("<%=txtexpRef.ClientID%>").value = data.d[1];
                    document.getElementById("<%=ExpTotal.ClientID%>").value = data.d[4];
                    document.getElementById("<%=Hiddeneamt.ClientID%>").value = data.d[4];
                    document.getElementById("<%=SetlTotal.ClientID%>").value = data.d[7];
                    document.getElementById("<%=BalTotal.ClientID%>").value = data.d[6];
                    document.getElementById("<%=txtDescription.ClientID%>").value = data.d[2];

                    document.getElementById("<%=hiddenExpenseDtls.ClientID%>").value = data.d[3];
                    //alert(document.getElementById("<%=hiddenExpenseDtls.ClientID%>").value);
                    LoadExpenseDetails(data.d[5]);
                    document.getElementById("<%=Confirmsts.ClientID%>").value = data.d[5];
                    
                    if (data.d[5] == "1") {
                        // alert("a");
                        $("#ExpTable").find("input,textarea,button:not(.shw_dwn)").attr("disabled", "disabled");
                        $("#cphMain_txtDescription").attr("disabled", "disabled");
                        $("#cphMain_txtExpDate").attr("disabled", "disabled");
                    }
                }
            });

            //0041


            if (document.getElementById("<%=hiddenExpenseDtls.ClientID%>").value == "") {


                loadExpense(0);
            }
        }


        function CheckaddMoreRows(x) {


            document.getElementById("<%=HiddenFieldCancelsts.ClientID%>").value = "1";
        if (CheckAndHighlight(x, 1) == true) {

            loadExpense(-1);
            var idlast = $('#ExpTable tr:last').attr('id');
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            
            document.getElementById("ddlParty" + LastId).focus();
            document.getElementById("btnAdd" + x).disabled = true;
            
            LoadExpTotal();

            return false;
        }
        else {
            return false;
        }

        return false;
    }

    function CheckAndHighlight(x, Mode) {

        var ret = true;

        var Table = document.getElementById("ExpTable");

        if (Mode == 0) {
            if (document.getElementById("ddlParty" + x).value.trim() == "") {
                document.getElementById("ddlParty" + x).style.borderColor = "Red";
                document.getElementById("ddlParty" + x).focus();
                ret = false;
            }

        }
        else {

            if (document.getElementById("ddlParty" + x).value.trim() == "") {
                document.getElementById("ddlParty" + x).style.borderColor = "Red";
                document.getElementById("ddlParty" + x).focus();
                ret = false;
            }
            if (document.getElementById("txtAmount" + x).value.trim() == "") {
                document.getElementById("txtAmount" + x).style.borderColor = "Red";
                document.getElementById("txtAmount" + x).focus();

                ret = false;
            }
        }
        var Flag = 0;
        if (ret == true) {
            if (CheckPartyDuplication(x) == false) {
                Flag++;
                ret = false;
            }
        }

        if (ret == false && Flag == 0) {
            $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            ret = false;
        }

        return ret;
    }

    function CheckPartyDuplication(x) {

        var ret = true;
        var Table = document.getElementById("ExpTable");

        for (var i = 0; i < Table.rows.length; i++) {
            var xLoop = (Table.rows[i].cells[0].innerHTML);
            var xLoopId = "";
            var Id = "";
            xLoopId = $("#ddlParty" + xLoop).val();
            Id = $("#ddlParty" + x).val();
            if (xLoop != x) {
                if (xLoopId == Id) {
                    $noCon("#divWarning").html("Party should not be duplicated.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#ddlParty" + x).css("borderColor", "red");
                    $noCon("#ddlParty" + x).select();
                    $noCon(window).scrollTop(0);
                    return false;
                }
            }
        }
        return ret;
    }

    function RemoveRows(x) {

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected expense details?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {


                document.getElementById("<%=HiddenFieldCancelsts.ClientID%>").value = "1";
                var evt = document.getElementById("tdEvt" + x).innerHTML;

                if (evt == "UPD") {
                    var detailId = document.getElementById("tdDtlId" + x).innerHTML;

                    var CanclIds = document.getElementById("<%=hiddenCnclDtls.ClientID%>").value;
                    if (CanclIds == '') {
                        document.getElementById("<%=hiddenCnclDtls.ClientID%>").value = detailId;
                    }
                    else {
                        document.getElementById("<%=hiddenCnclDtls.ClientID%>").value = document.getElementById("<%=hiddenCnclDtls.ClientID%>").value + ',' + detailId;
                    }
                }

                jQuery('#trRowId_' + x).remove();

                var idlast = $('#ExpTable tr:last').attr('id');
                
                if (idlast != undefined) {
                    var LastId = "";
                    if (idlast != "") {
                        var res = idlast.split("_");
                        LastId = res[1];
                    }
                    document.getElementById("btnAdd" + LastId).disabled = false;
                    
                }

                var Table = document.getElementById("ExpTable");
                if (Table.rows.length < 1) {
                    loadExpense(0);
                }
                else {

                    // alert("a");
                    LoadExpTotal();
                    //0041
                }
            }
            else {
                //loadExpense(1);

                return false;
            }
        });
        return false;
    }

    function CheckExpPrdtDtls(mainrow) {

        var ret = true;
        var flag = 0;

        var Table = document.getElementById("Prdttbody" + mainrow);

        for (var x = 0; x < Table.rows.length; x++) {

            if (Table.rows[x].cells[0].innerHTML != "") {

                var validRowID = (Table.rows[x].cells[0].innerHTML);
                //alert(validRowID);
                var PrdtHd = document.getElementById("ddlProducts" + validRowID).value.trim();
                var PrdtAmnt = document.getElementById("txtPrice" + validRowID).value.trim();

                if ((Table.rows.length > 1) || (Table.rows.length == 1 && (PrdtHd != "" || PrdtAmnt != ""))) {
                    if (CheckAndHighlightPrdtData(mainrow, validRowID) == false) {
                        ret = false;
                    }
                    flag = 1;
                }

            }
        }


        return ret;
    }


    function CheckAmt(mainrow) {

       // alert("a");
        var rEt = true;
        var prdtamnt = 0;
        var Table = document.getElementById("Prdttbody" + mainrow);

        for (var x = 0; x < Table.rows.length; x++) {
            var xLoop = Table.rows[x].cells[0].innerHTML;
            
            if (xLoop != "0") {
                var amt = document.getElementById("txtPrice" + xLoop).value;
                prdtamnt = Number(prdtamnt) + Number(amt);
               

            }
        }
        if (Number(document.getElementById("txtAmount" + mainrow).value) != prdtamnt) {

            
           
            $("#divWarning").html("The total cost of all products should be equal to the expense amount.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            rEt = false;
        }

        return rEt;
    }
    function ValidateExpDtls() {
        var ret = true;

        if (ValidateExpPrdtDtls() == false) {
            ret = false;
        }
        if (ret == true) {

            document.getElementById("<%=hiddenExpenseDtls.ClientID%>").value = "";

            var tbClientTotalValues = '';
            tbClientTotalValues = [];
            var Table = document.getElementById("ExpTable");
            for (var x = 0; x < Table.rows.length; x++) {

                if (Table.rows[x].cells[0].innerHTML != "") {

                    var validRowID = (Table.rows[x].cells[0].innerHTML);

                    var PartyHeadId = document.getElementById("tdPartyId" + validRowID).value.trim();
                    var PartyAmnt = document.getElementById("txtAmount" + validRowID).value.trim();
                    var Evt = document.getElementById("tdEvt" + validRowID).innerHTML;
                    var DetailId = document.getElementById("tdDtlId" + validRowID).innerHTML;
                    var desc = document.getElementById("txtNarration" + validRowID).value.trim();
                    if (PartyHeadId != "") {
                        var client = JSON.stringify({
                            ROWID: "" + validRowID + "",
                            PARTYHDID: "" + PartyHeadId + "",
                            EXPAMNT: "" + PartyAmnt + "",
                            EVTACTION: "" + Evt + "",
                            EXPDESC: "" + desc + "",
                            DTLID: "" + DetailId + "",
                        });
                        tbClientTotalValues.push(client);
                    }

                }
            }

            document.getElementById("<%=hiddenExpenseDtls .ClientID%>").value = JSON.stringify(tbClientTotalValues);

        }
        //alert(document.getElementById("<%=hiddenExpenseDtls .ClientID%>").value);
        return ret;
    }


        function ValidateExpPrdtDtls() {
        
            //0041
            var ret = true;
            var flag = 0;
            var ExpTable = document.getElementById("ExpTable");
            for (var i = 0; i < ExpTable.rows.length; i++) {
                var mainrow = ExpTable.rows[i].cells[0].innerText;
                if (ExpTable.rows[i].cells[0].innerHTML != "") {
                    if (CheckAndHighlight(mainrow, 1) == false) {
                        ret = false;
                        return ret;
                    }
                    // if (document.getElementById("tdPrdtdetails" + mainrow).value == "") {
                    //   ret = false;
                    // return ret;
                    //}
              
                }
            }
            //kik
           // alert(document.getElementById("<%=Hiddensamt.ClientID%>").value);
           // alert(document.getElementById("<%=Hiddeneamt.ClientID%>").value);
          //  if (Number(document.getElementById("<%=Hiddeneamt.ClientID%>").value) > Number(document.getElementById("<%=Hiddensamt.ClientID%>").value)) {

        //    ezBSAlert({
        //        type: "confirm",
        //        messageText: "Are you sure you want to delete selected product details?",
        //        alertType: "info"
        //    }).done(function (o) {
        //        if (o == true) {

        //            ret = true;

        //    }

        //    else {

        //            ret = false;
        //    }
        //    });
        //}
        return ret;
    }
    //-------------------------------------------

    //---Product table functions
    function CheckaddMorePrdtRows(mainrow, prdtrow) {
        if (CheckAndHighlightPrdt(mainrow, prdtrow, 1) == true) {

            AddExpenseData(mainrow, -1);
            var idlast = $('#PrdtTable' + mainrow + ' tbody tr:last').attr('id');
            var LastId = "";
            if (idlast != "") {
                var res = idlast.split("_");
                LastId = res[1];
            }
            //alert(LastId);
            document.getElementById("ddlProducts" + LastId).focus();
           // document.getElementById("btnPdtAdd" + mainrow + prdtrow).disabled = true;
            return false;
        }
        else {
            return false;
        }

        return false;
    }
    function CheckAndHighlightPrdtData(mainrow, row) {

        var ret = true;
        document.getElementById("ddlProducts" + row).style.borderColor = "";
        document.getElementById("txtPrice" + row).style.borderColor = "";

        if (document.getElementById("ddlProducts" + row).value.trim() == "") {
            document.getElementById("ddlProducts" + row).style.borderColor = "Red";
            document.getElementById("ddlProducts" + row).focus();
            ret = false;
        }
        if (document.getElementById("txtPrice" + row).value.trim() == "") {
            document.getElementById("txtPrice" + row).style.borderColor = "Red";
            document.getElementById("txtPrice" + row).focus();
            ret = false;
        }
        var Flag = 0;
        if (ret == true) {
            if (CheckPrdtDataDuplication(mainrow, row) == false) {
                Flag++;
                ret = false;
            }
        }

        if (ret == false && Flag == 0) {
            $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            ret = false;
        }

        return ret;
    }
    function CheckPrdtDataDuplication(mainrow, row) {

        var ret = true;
        var Table = document.getElementById("Prdttbody" + mainrow);

        for (var i = 0; i < Table.rows.length; i++) {
            var xLoop = Table.rows[i].cells[0].innerHTML;
            var xLoopId = "";
            var Id = "";
            xLoopId = $("#ddlProducts" + xLoop).val();
            Id = $("#ddlProducts" + row).val();
            if (xLoop != ("" + row)) {
                if (xLoopId == Id) {
                    $noCon("#divWarning").html("Product should not be duplicated.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#ddlProducts" + mainrow).css("borderColor", "red");
                    $noCon("#ddlProducts" + mainrow).select();
                    $noCon(window).scrollTop(0);
                    return false;
                }
            }
        }
        return ret;
    }

    function CheckAndHighlightPrdt(mainrow, prdtrow, Mode) {

        var ret = true;
        document.getElementById("ddlProducts" + mainrow + prdtrow).style.borderColor = "";
        document.getElementById("txtPrice" + mainrow + prdtrow).style.borderColor = "";
        if (document.getElementById("ddlProducts" + mainrow + prdtrow).value.trim() == "") {
            document.getElementById("ddlProducts" + mainrow + prdtrow).style.borderColor = "Red";
            document.getElementById("ddlProducts" + mainrow + prdtrow).focus();
            ret = false;
        }
        if (document.getElementById("txtPrice" + mainrow + prdtrow).value.trim() == "") {
            document.getElementById("txtPrice" + mainrow + prdtrow).style.borderColor = "Red";
            document.getElementById("txtPrice" + mainrow + prdtrow).focus();
            ret = false;
        }
        var Flag = 0;
        if (ret == true) {
            if (CheckPrdtDuplication(mainrow, prdtrow) == false) {
                Flag++;
                ret = false;
            }
        }

        if (ret == false && Flag == 0) {
            $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            ret = false;
        }

        return ret;
    }

    function CheckPrdtDuplication(mainrow, prdtrow) {

        var ret = true;
        var Table = document.getElementById("Prdttbody" + mainrow);

        for (var i = 0; i < Table.rows.length; i++) {
            var xLoop = Table.rows[i].cells[0].innerHTML;
            var xLoopId = "";
            var Id = "";
            xLoopId = $("#ddlProducts" + xLoop).val();
            Id = $("#ddlProducts" + mainrow + prdtrow).val();
            if (xLoop != ("" + mainrow + prdtrow)) {
                if (xLoopId == Id) {
                    $noCon("#divWarning").html("Product should not be duplicated.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                    $noCon("#ddlProducts" + mainrow + prdtrow).css("borderColor", "red");
                    $noCon("#ddlProducts" + mainrow + prdtrow).select();
                    $noCon(window).scrollTop(0);
                    return false;
                }
            }
        }
        return ret;
    }
    function RemoveData(mainrow, prdtRow) {


        RemovePrdtRows(mainrow, prdtRow);


        CalculateprdtTotal(mainrow);

        
        

        return false;
    }

    function RemovePrdtRows(mainrow, prdtRow) {

        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected product details?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {

        var evt = document.getElementById("tdPrdtEvt" + mainrow + prdtRow).innerHTML;

        if (evt == "UPD") {
            var detailId = document.getElementById("tdPrdtDtlId" + mainrow + prdtRow).innerHTML;

            var CanclIds = document.getElementById("<%=hiddenPrdctCnclDtls.ClientID%>").value;
                //alert(CanclIds);

                if (CanclIds == '') {
                    document.getElementById("<%=hiddenPrdctCnclDtls.ClientID%>").value = detailId;
                }
                else {
                    document.getElementById("<%=hiddenPrdctCnclDtls.ClientID%>").value = document.getElementById("<%=hiddenPrdctCnclDtls.ClientID%>").value + ',' + detailId;
                }
            }

       
        

        jQuery('#trPrdt_' + mainrow + prdtRow).remove();

        if (prdtRow == 1) {

            AddExpenseData(1,0);
        }
        
        
            var idlast = $('#PrdtTable' + mainrow + ' tbody tr:last').attr('id');

            if (idlast != undefined) {
                var LastId = "";
                if (idlast != "") {
                    var res = idlast.split("_");
                    LastId = res[1];
                }
                if (document.getElementById("<%=Confirmsts.ClientID%>").value != "1") {
                   // document.getElementById("btnPdtAdd" + LastId).disabled = false;
                }
            }

                // LoadExpTotal();
                CalculateprdtTotal(mainrow);

            var Table = document.getElementById("Prdttbody" + mainrow);
            if (Table.rows.length < 1) {
                AddExpenseData(0);
            }
            }
                else {
                    return false;
                }
            });

            return false;
        }
        //--------------------------
        function CalculateprdtTotal(mainrow) {
            var prdtamount = 0;
            var expamount = 0;
            document.getElementById("<%=Hiddenpopup.ClientID%>").value = "1";
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CrncyAbrv = document.getElementById("<%=HiddenCurrencyAbrevation.ClientID%>").value;
            var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;

            //---Calculate expense amount of each entry for products selected
            //alert(mainrow);
            //alert("Prdttbody" + mainrow);
            var Table = document.getElementById("Prdttbody" + mainrow);
           // alert(Table.rows.length);
            //if (Table.rows.length == 0) {

            //    var prdtmntt = BlurAmountReturn(0, FloatingValue);
            //    document.getElementById("prdtTotal" + mainrow).innerText = addCommasReturn(prdtmntt, CrncyModeId) + " " + CrncyAbrv;
            //}
            //alert(Table.rows.length);
            for (var x = 0; x < Table.rows.length; x++) {
                var xLoop = (Table.rows[x].cells[0].innerHTML);

                if (xLoop != "0") {
                    var amt = document.getElementById("txtPrice" + xLoop).value;
                    prdtamount = Number(prdtamount) + Number(amt);
                    //alert("txtPrice" +xLoop+"-"+prdtamount);
                    //alert(prdtamount);
                    if (FloatingValue != "") {

                        document.getElementById("txtPrice" + xLoop).value = BlurAmountReturn(amt, FloatingValue); //addCommasReturn(, CrncyModeId);
                    }
                }

            }

            var prdctmntt = BlurAmountReturn(prdtamount, FloatingValue); //addCommasReturn(, CrncyModeId) + " " + CrncyAbrv;

            document.getElementById("prdtTotal" + mainrow).innerText = addCommasReturn(prdctmntt, CrncyModeId) + " " + CrncyAbrv;
            document.getElementById("setlamt2").innerText = addCommasReturn(prdctmntt, CrncyModeId) + " " + CrncyAbrv;
            var valamt = (Number(document.getElementById("txtAmount" + mainrow).value) - Number(prdctmntt));
            document.getElementById("setlamt3").innerText = BlurAmountReturn(valamt, FloatingValue) + " " + CrncyAbrv;
            //document.getElementById("txtAmount" + mainrow).value = addCommasReturn(BlurAmountReturn(prdtamount, FloatingValue), CrncyModeId) ;
            //addCommasReturn(, CrncyModeId) + " " + CrncyAbrv;

        }
        function FillProductDetails(mainrow, prdtrow) {
            if (CheckExpPrdtDtls(mainrow) == true && CheckAmt(mainrow)==true) {
                var Table = document.getElementById("Prdttbody" + mainrow);
                for (var x = 0; x < Table.rows.length; x++) {
                    var xLoop = Table.rows[x].cells[0].innerHTML;
                  //  alert(xLoop);
                  //  alert(document.getElementById("tdProductId" + xLoop).value);
                   // alert(document.getElementById("tdPrdtDtlId" + xLoop).innerHTML);
                    if (x == 0) {
                        document.getElementById("tdPrdtdetails" + mainrow).value = "";
                    }


                    if (document.getElementById("tdPrdtdetails" + mainrow).value == "") {
                        document.getElementById("tdPrdtdetails" + mainrow).value = document.getElementById("tdProductId" + xLoop).value + "%" + document.getElementById("ddlProducts" + xLoop).value + "%" + document.getElementById("txtPrice" + xLoop).value + "%" + document.getElementById("tdPrdtDtlId" + xLoop).innerHTML;
                    }
                    else {

                        document.getElementById("tdPrdtdetails" + mainrow).value = document.getElementById("tdPrdtdetails" + mainrow).value + "$" + document.getElementById("tdProductId" + xLoop).value + "%" + document.getElementById("ddlProducts" + xLoop).value + "%" + document.getElementById("txtPrice" + xLoop).value + "%" + document.getElementById("tdPrdtDtlId" + xLoop).innerHTML;
                    }

                }
                //alert(document.getElementById("tdPrdtdetails" + mainrow).value);
                CalculateExpTotal(mainrow);
                document.getElementById("<%=Hiddenpopup.ClientID%>").value = "0";
                removeExpenseData(mainrow);
                document.getElementById("btnDisp" + mainrow).style.borderColor = "";
            }

         

                return false;
            
            

        }
        function loadProductDetails(row, mode) {


            //alert("row" + row);
            //alert(document.getElementById("tdPrdtdetails" + row).value);
            var addRowExpense = document.getElementById("ExpTable");
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var rowId = 0;

          //  alert(document.getElementById("tdPrdtdetails" + row).value);

            if (document.getElementById("tdPrdtdetails" + row).value != "") {


                document.getElementById("<%=hiddenedit.ClientID%>").value = "1";

                var CstCntrDtl = document.getElementById("tdPrdtdetails" + row).value;
                var splitrow = CstCntrDtl.split("$");
                for (var Cst = 0; Cst < splitrow.length; Cst++) {



                    if (Cst == 0) {
                        //alert("call0" + row);


                        AddExpenseData(row, 0);


                    }
                    else {
                        // alert("call1" + row);

                        AddExpenseData(row, 1);

                    }


                    var splitEach = splitrow[Cst].split("%");
                    var RowCnt = parseInt(Cst) + 1;

                    if (parseInt(Cst) < parseInt(splitrow.length) - 1) {
                      //  document.getElementById("btnPdtAdd" + row + RowCnt).disabled = true;
                    }

                    document.getElementById("tdProductId" + row + RowCnt).value = splitEach[0];
                    document.getElementById("ddlProducts" + row + RowCnt).value = splitEach[1];
                    document.getElementById("txtPrice" + row + RowCnt).value = splitEach[2];
                    document.getElementById("tdPrdtDtlId" + row + RowCnt).innerHTML = splitEach[3];
                    document.getElementById("tdPrdtEvt" + row + RowCnt).innerHTML = "UPD";
                }

            }
            else {
                //alert("call" + mode + "-" + row);
                

                    AddExpenseData(row, mode);
               // }

            }

            return false;
        }
        function CalculateExpTotal(mainrow) {

            var expamount = 0;
            var prdtamount = 0;
            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CrncyAbrv = document.getElementById("<%=HiddenCurrencyAbrevation.ClientID%>").value;
            var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;

            //---Calculate expense amount of each entry for products selected

            var Table = document.getElementById("Prdttbody" + mainrow);
            for (var x = 0; x < Table.rows.length; x++) {
                var xLoop = Table.rows[x].cells[0].innerHTML;
                //alert(xLoop);
                if (xLoop != "0") {
                    var amt = document.getElementById("txtPrice" + xLoop).value;
                    prdtamount = Number(prdtamount) + Number(amt);
                    //alert(prdtamount);

                }
            }
            //change0041
            if (Number(document.getElementById("txtAmount" + mainrow).value) < prdtamount) {
           // document.getElementById("txtAmount" + mainrow).value = BlurAmountReturn(prdtamount, FloatingValue); //addCommasReturn(, CrncyModeId);
        }
            var Table = document.getElementById("ExpTable");
            for (var x = 0; x < Table.rows.length; x++) {
                var xLoop = (Table.rows[x].cells[0].innerHTML);
                //alert(xLoop);
                if (xLoop != "0") {
                    //alert(document.getElementById("txtAmount" + x).value);
                    expamount = Number(expamount) + Number(document.getElementById("txtAmount" + xLoop).value);
                    //alert(expamount);
                }


            }
            
            document.getElementById("<%=ExpTotal.ClientID%>").value = BlurAmountReturn(expamount, FloatingValue); //addCommasReturn(, CrncyModeId) + " " + CrncyAbrv;
            document.getElementById("<%=Hiddeneamt.ClientID%>").value = expamount;

            return false;
        }
        //---Calculate total expense amount of every entry....
        function LoadExpTotal() {

            var expamount = 0;
            var prdtamount = 0;
            var seltamnt = 0;
            var balamtn = 0;

            var FloatingValue = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var CrncyAbrv = document.getElementById("<%=HiddenCurrencyAbrevation.ClientID%>").value;
            var CrncyModeId = document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value;



            var Table = document.getElementById("ExpTable");
            for (var x = 0; x < Table.rows.length; x++) {
                var xLoop = (Table.rows[x].cells[0].innerHTML);
                
                
                //alert(xLoop);
                if (xLoop != "0") {
                    //alert(document.getElementById("txtAmount" + x).value);
                    expamount = Number(expamount) + Number(document.getElementById("txtAmount" + xLoop).value);
                    if (document.getElementById("SetleAmt" + xLoop).innerHTML == "" && document.getElementById("BalncAmt" + xLoop).innerHTML == "") {

                        document.getElementById("SetleAmt" + xLoop).innerHTML = BlurAmountReturn(0, FloatingValue); 
                        document.getElementById("BalncAmt" + xLoop).innerHTML = BlurAmountReturn(document.getElementById("txtAmount" + xLoop).value, FloatingValue);
                    }
                    else { }
                    seltamnt = Number(seltamnt) + Number(document.getElementById("SetleAmt" + xLoop).innerHTML);
                    balamtn = Number(balamtn) + Number(document.getElementById("BalncAmt" + xLoop).innerHTML);

                    
                    
                }


            }
            document.getElementById("<%=Hiddeneamt.ClientID%>").value = expamount;

            var expmntt = BlurAmountReturn(expamount, FloatingValue); //addCommasReturn(, CrncyModeId) + " " + CrncyAbrv;

            document.getElementById("<%=ExpTotal.ClientID%>").value = addCommasReturn(expmntt, CrncyModeId) + " " + CrncyAbrv;

            var setlmntt = BlurAmountReturn(seltamnt, FloatingValue); //addCommasReturn(, CrncyModeId) + " " + CrncyAbrv;

            document.getElementById("<%=SetlTotal.ClientID%>").value = addCommasReturn(setlmntt, CrncyModeId) + " " + CrncyAbrv;

            var balmntt = BlurAmountReturn(balamtn, FloatingValue); //addCommasReturn(, CrncyModeId) + " " + CrncyAbrv;

            document.getElementById("<%=BalTotal.ClientID%>").value = addCommasReturn(balmntt, CrncyModeId) + " " + CrncyAbrv;
            //0041n

            
             return false;
         }

         function addCommasReturn(nStr, CrncyMode) {

             nStr += '';
             var x = nStr.split('.');
             var x1 = x[0];
             var x2 = x[1];

             if (CrncyMode == "1") {
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

             if (CrncyMode == "2") {
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
             if (CrncyMode == "3") {
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

             var strReturn = "";

             if (isNaN(x2)) {
                 strReturn = x1;
             }
             else {
                 strReturn = x1 + "." + x2;
             }

             return strReturn;
         }


         function LoadProducts(x, obj) {

             var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';

             saleid = document.getElementById("<%=hiddenSalesId.ClientID%>").value;

        $noCon('#' + obj + x).autocomplete({
            source: function (request, response) {

                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/LoadProducts",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '",SalesId:"' + saleid + '"}',
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            // alert(item);
                            return {
                                val: item.split('<>')[0],
                                label: item.split('<>')[1],
                            }
                        }))
                    }
                });
            },
            autoFocus: false,

            select: function (e, i) {
                document.getElementById("tdProductId" + x).value = i.item.val;
                //alert(document.getElementById("tdProductId" + x).value);
                document.getElementById(obj + x).value = i.item.label;
                //alert("b");
            },
            change: function (event, ui) {
                if (ui.item) {
                    document.getElementById("tdProductName" + x).value = document.getElementById(obj + x).value;

                }
                else {
                    document.getElementById(obj + x).value = document.getElementById("tdProductName" + x).value;
                }
            }
        });
    }

    function LoadParty(x) {

        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var OrgId = '<%=Session["ORGID"]%>';
        var UserId = '<%= Session["USERID"] %>';

        //alert(x);
        $noCon('#ddlParty' + x).autocomplete({
            source: function (request, response) {

                $.ajax({
                    async: false,
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Sales_Master_List.aspx/LoadParty",
                    data: '{ CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",strText:"' + request.term.replace(/'/g, "").replace(/\\/g, "").trim() + '"}',
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            //alert(item);
                            return {
                                val: item.split('<>')[0],
                                label: item.split('<>')[1],

                            }
                        }))
                    }
                });
            },
            autoFocus: false,

            select: function (e, i) {
                document.getElementById("tdPartyId" + x).value = i.item.val;
                document.getElementById("ddlParty" + x).value = i.item.label;
            },
            change: function (event, ui) {
                if (ui.item) {
                    document.getElementById("tdPartyName" + x).value = document.getElementById("ddlParty" + x).value;
                }
                else {
                    document.getElementById("ddlParty" + x).value = document.getElementById("tdPartyName" + x).value;

                }
            }
        });

    }




    </script>







</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">


 <%--  <%%>
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>--%>
    <%%>


    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenFieldpopupvalue" runat="server" />
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
    <asp:HiddenField ID="Confirmsts" runat="server" />
    <asp:HiddenField ID="hiddenExpenseDtls" runat="server" /> <%--EVM 0044--%>
     <asp:HiddenField ID="HiddenViewSts" runat="server" /> <%--EVM 0044--%>
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
     <asp:HiddenField ID="HiddenFieldCancelsts" runat="server" />
      <asp:HiddenField ID="Hiddenpopup" runat="server" />
    <asp:HiddenField ID="hiddenedit" runat="server" />
    <asp:HiddenField ID="Hiddnsetlsts" runat="server" />
    <asp:HiddenField ID="Hiddensamt" runat="server" />
    <asp:HiddenField ID="Hiddeneamt" runat="server" />
    <asp:HiddenField ID="Hidden" runat="server" />
     <%--EVM 0044--%>

   <asp:HiddenField ID="hiddenDecimalCount" runat="server" /><%--EVM 0044--%>
     <asp:HiddenField ID="HiddenExpenseAmountTotal" runat="server" /><%--EVM 0044--%>
        <asp:HiddenField ID="HiddenCurrencyAbrevation" runat="server" /><%--EVM 0044--%>
   <asp:HiddenField ID="hiddenSalesId" runat="server" />
     <asp:HiddenField ID="Hiddensale1" runat="server" />
   <asp:HiddenField ID="hiddenCnclDtls" runat="server" />
   <asp:HiddenField ID="hiddenPrdctCnclDtls" runat="server" />
   <asp:HiddenField ID="hiddenExpenseId" runat="server" />
    <asp:HiddenField ID="Hiddencnt" runat="server" />

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
                                document.getElementById("<%=HiddenFieldCancelsts.ClientID%>").value = "0";
                                document.getElementById("<%=HiddenFieldpopupvalue.ClientID%>").value = "0";
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
        <!-- Modal_cc -->
<div class="modal fade" id="exampleModal_cc" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" data-backdrop="static" aria-hidden="true">
 <div class="modal-dialog mod2 ex_mod_l" role="document">
     <div class="modal-content">
      <div class="modal-header" style="height: 184px">
         <h2 class="tr_l">EXPENSE BOOKING
           <%-- 0041--%>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"   >
            <span aria-hidden="true">&times;</span>
          </button>
        </h2>
        <div class="clearfix"></div>

        <div class="sls_77">
          <div class="fg12 head_lab">
            <label class="fg4">Expense Date:</label><span class="fg9"></span>
            <span class="fg6 mar_bo_d">
             
              <div id="datepicker9" class="input-group date" data-date-format="mm-dd-yyyy" >
                    <input id="txtExpDate" runat="server" type="text" autocomplete="off" onkeypress="return DisableEnter(event)" class="form-control inp_bdr hei_20" placeholder="dd-mm-yyyy" maxlength="50" />
                   <span class="input-group-addon date1 hei_20_f"><i class="fa fa-calendar"></i></span>
                    <script>

                        var StartDateVal = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                        var EndDateVal = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;

                        $noCon('#cphMain_txtExpDate').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            startDate: StartDateVal,
                            endDate: EndDateVal,
                        });
                            </script>
          </div> 
           </span>
          </div>
          <div class="fg12 head_lab">
            <label class="fg4">Expense Ref#:</label><span class="fg9"></span><span class="fg6">
            <asp:TextBox ID="txtexpRef" runat="server" readonly="true" autocomplete="off" class=" fg2_inp3 fg_chs1" style="Width:100%;"></asp:TextBox>
             <%--   <input id="expRef" class=" fg2_inp3 fg_chs1" runat="server" disabled="" />--%>
                 </span>
          </div>
        </div>
        
          <div class="spl_krn">
        <div class="fg6">
          <div class="fg12 head_lab head_lab7">
            <label class="fg4">Sales Ref#:</label><span class="fg9"></span><span id="salesRef"class=""></span>
          </div>
          <div class="fg12 head_lab">
            <label class="fg4">Customer Name:</label><span class="fg9"></span><span id="custName" class=""></span>
          </div>
        </div>

        <div class="fg6">
          <div class="fg12 head_lab head_lab7 flt_r">
            <label class="fg4">Sales Date:</label><span class="fg9"></span><span id="salesDate" class=""></span>
          </div>
          <div class="fg12 head_lab flt_r">
            <label class="fg4">Sales Amount:</label><span class="fg9"></span><span id="salesAmt"class=""></span>
          </div>
        </div>

      </div>
          </div>
      <div class="modal-body md_bd md_bd_sa" style=" float: left; margin: auto;">
        <table class="table table-bordered" id="ExpenseTable" >
          <thead class="thead1">
            <tr>
             <th class="th_b5_1 tr_l">&nbsp;</th>
              <th class="th_b2 tr_l">Party / Head</th>
              <th class="th_b8 tr_r">Expense</th>
              <th class="th_b8 tr_r">Settled Amount</th>
              <th class="th_b8  tr_r">Balance Amount</th>
              <th class="th_b2 tr_l">Narration</th>
              <th class="th_b3">Actions</th>
            </tr>
          </thead>
          <tbody id="ExpTable">
        <%--    <tr id="">
              <td class="tr_c">
                <div class="bo_not2" title="Partially Settled">
                  <i class="fa fa-square"></i>
                </div>
              </td>
              <td>
                <select class="fg2_inp2 fg2_inp3 fg_chs1" onclick="sel1()">
                  <option>Party 1</option>
                  <option>Party 2</option>
                  <option>Party 3</option>
                </select>
              </td>
              <td class=" tr_r">
                <div class="input-group mr_at flt_l">
                  <span class="input-group-addon cur1">QAR</span>
                  <input id="email" type="text" class="form-control fg2_inp2 tr_r" name="email" placeholder="0.00" disabled="">
                </div>
              </td>
              <td class=" tr_r">1000.00</td>
              <td class=" tr_r">1000.00</td>
              <td>
                <textarea rows="2" cols="50" class="form-control" placeholder="Write something here..."></textarea>
              </td>
              <td class="td1">
                <div class="btn_stl1">
                  <button class="btn act_btn bn7 shw_dwn" title="Add Items" onclick ="return AddExpenseData();"><i class="fa fa-newspaper-o "></i></button>
                  <button class="btn act_btn bn1" title="Edit"><i class="fa fa-edit"></i></button>
                  <button class="btn act_btn sub5" title="Confirm">
                    <i class="fa fa-check"></i>
                  </button>
                  <button class="btn act_btn sub6" title="Reopen">
                    <i class="fa fa-unlock"></i>
                  </button>
                  <button class="btn act_btn bn6" title="Follow Up">
                    <i class="fa fa-rss"></i>
                  </button>
                  <button class="btn act_btn bn3" title="Delete">
                    <i class="fa fa-trash"></i>
                  </button>
                </div>
              </td>
             <tbody id="disptd"class="add_dedu"style="display: none!important;background-color: #fff;width:640px;height:auto;position:absolute;min-height: 200px;z-index: 99;right:0px;box-shadow: 4px 4px 10px #ccc;border-top: 2px solid #14cc22;float: right;padding:20px;">--%>
              <%--  <tr style="background-color: #4298d4;color:#fff;border-top:none;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;font-weight: 600;border-top:none;">Product</td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;font-weight: 600;border-top:none;">Amount</td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;font-weight: 600;border-top:none;">Action</td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn1" title="Edit">
                      <i class="fa fa-edit"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn1" title="Edit">
                      <i class="fa fa-edit"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn2" title="Add">
                      <i class="fa fa-plus-circle"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <!---total row---->
                <tr class="bg1 txt_rd">
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;text-align: right;">Total</td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;border:none!important;">
                    45000.00
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;border:none!important;"></td>
                </tr>
                <!---total row---->
                <!----buttons row--->
                <tr class="">
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;border-right:1px solid #ddd!important;">
                  </td>
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;">
                    <button type="submit" class="btn sub1">Update</button>
                    <button type="submit" class="btn sub4 shw_dwn">Cancel</button>
                  </td>
                </tr>--%>
                <!----buttons row_closed--->
             </tbody>
            <%--</tr>--%>
         <%--   <tr>
              <td class="tr_c">
                <div class="bo_not1" title="Fully Settled">
                  <i class="fa fa-square"></i>
                </div>
              </td>
              <td>
                <select class="fg2_inp2 fg2_inp3 fg_chs1" onclick="sel1()">
                  <option>Party 1</option>
                  <option>Party 2</option>
                  <option>Party 3</option>
                </select>
              </td>
              <td class=" tr_r">
                <div class="input-group mr_at flt_l">
                  <span class="input-group-addon cur1">QAR</span>
                  <input id="Text1" type="text" class="form-control fg2_inp2 tr_r" name="email" placeholder="0.00" disabled="">
                </div>
              </td>
              <td class=" tr_r">1000.00</td>
              <td class=" tr_r">1000.00</td>
              <td>
                <textarea rows="2" cols="50" class="form-control" placeholder="Write something here..."></textarea>
              </td>
              <td class="td1">
                <div class="btn_stl1">
                  <button class="btn act_btn bn7 shw_dwn1" onclick ="return AddExpenseData();" title="Add Items"><i class="fa fa-newspaper-o "></i></button>
                  <button class="btn act_btn bn1" title="Edit"><i class="fa fa-edit"></i></button>
                  <button class="btn act_btn sub5" title="Confirm">
                    <i class="fa fa-check"></i>
                  </button>
                  <button class="btn act_btn sub6" title="Reopen">
                    <i class="fa fa-unlock"></i>
                  </button>
                  <button class="btn act_btn bn6" title="Follow Up">
                    <i class="fa fa-rss"></i>
                  </button>
                  <button class="btn act_btn bn3" title="Delete">
                    <i class="fa fa-trash"></i>
                  </button>
                </div>
              </td>
              <tbody  class="add_dedu1" style="display: none!important;background-color: #fff;width:640px;height:auto;position:absolute;min-height: 200px;z-index: 99;right:0px;box-shadow: 4px 4px 10px #ccc;border-top: 2px solid #14cc22;float: right;padding:20px;">
                <tr style="background-color: #4298d4;color:#fff;border-top:none;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;font-weight: 600;border-top:none;">Product</td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;font-weight: 600;border-top:none;">Amount</td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;font-weight: 600;border-top:none;">Action</td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn1" title="Edit">
                      <i class="fa fa-edit"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn1" title="Edit">
                      <i class="fa fa-edit"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn2" title="Add">
                      <i class="fa fa-plus-circle"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <!---total row---->
                <tr class="bg1 txt_rd">
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;text-align: right;">Total</td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;border:none!important;">
                    45000.00
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;border:none!important;"></td>
                </tr>
                <!---total row---->
                <!----buttons row--->
                <tr class="">
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;border-right:1px solid #ddd!important;">
                  </td>
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;">
                    <button type="submit" class="btn sub1">Update</button>
                    <button type="submit" class="btn sub4 shw_dwn">Cancel</button>
                  </td>
                </tr>
                <!----buttons row_closed--->
              </tbody>
            </tr>
           <tr>
              <td class="tr_c">
                <div class="bo_not1" title="Fully Settled">
                  <i class="fa fa-square"></i>
                </div>
              </td>
              <td>
                <select class="fg2_inp2 fg2_inp3 fg_chs1" onclick="sel1()">
                  <option>Party 1</option>
                  <option>Party 2</option>
                  <option>Party 3</option>
                </select>
              </td>
              <td class=" tr_r">
                <div class="input-group mr_at flt_l">
                  <span class="input-group-addon cur1">QAR</span>
                  <input id="Text2" type="text" class="form-control fg2_inp2 tr_r" name="email" placeholder="0.00" disabled="">
                </div>
              </td>
              <td class=" tr_r">1000.00</td>
              <td class=" tr_r">1000.00</td>
              <td>
                <textarea rows="2" cols="50" class="form-control" placeholder="Write something here..."></textarea>
              </td>
              <td class="td1">
                <div class="btn_stl1">
                  <button class="btn act_btn bn7 shw_dwn3" title="Add Items" onclick ="return AddExpenseData();"><i class="fa fa-newspaper-o "></i></button>
                  <button class="btn act_btn bn1" title="Edit"><i class="fa fa-edit"></i></button>
                  <button class="btn act_btn sub5" title="Confirm">
                    <i class="fa fa-check"></i>
                  </button>
                  <button class="btn act_btn sub6" title="Reopen">
                    <i class="fa fa-unlock"></i>
                  </button>
                  <button class="btn act_btn bn6" title="Follow Up">
                    <i class="fa fa-rss"></i>
                  </button>
                  <button class="btn act_btn bn3" title="Delete">
                    <i class="fa fa-trash"></i>
                  </button>
                </div>
              </td>
              <tbody class="add_dedu3" style="display: none!important;background-color: #fff;width:640px;height:auto;position:absolute;min-height: 200px;z-index: 99;right:0px;box-shadow: 4px 4px 10px #ccc;border-top: 2px solid #14cc22;float: right;padding:20px;">
               <tr style="background-color: #4298d4;color:#fff;border-top:none;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;font-weight: 600;border-top:none;">Product</td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;font-weight: 600;border-top:none;">Amount</td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;font-weight: 600;border-top:none;">Action</td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn1" title="Edit">
                      <i class="fa fa-edit"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn1" title="Edit">
                      <i class="fa fa-edit"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <tr style="color:#333;">
                  <td class="tr_l" style="width:300px;margin:auto;float: left;">
                    <select class="fg2_inp2 fg2_inp3 fg_chs1" type="text">
                      <option>Product 1</option>
                      <option>Product 2</option>
                      <option>Product 3</option>
                    </select>
                  </td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;">
                    <input class="tr_r form-control fg2_inp2 brd_r hei_25" type="text" placeholder="0.00">
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;">
                    <button class="btn act_btn bn2" title="Add">
                      <i class="fa fa-plus-circle"></i>
                    </button>
                    <button class="btn act_btn bn3" title="Delete">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
                <!---total row---->
                <tr class="bg1 txt_rd">
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;text-align: right;">Total</td>
                  <td class="tr_r" style="width:150px;margin:auto;float: left;border:none!important;">
                    45000.00
                  </td>
                  <td class="tr_c" style="width:150px;margin:auto;float: left;border:none!important;"></td>
                </tr>
                <!---total row---->
                <!----buttons row--->
                <tr class="">
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;border-right:1px solid #ddd!important;">
                  </td>
                  <td class="tr_r" style="width:300px;margin:auto;float: left;border:none!important;">
                    <button type="submit" class="btn sub1">Update</button>
                    <button type="submit" class="btn sub4 shw_dwn">Cancel</button>
                  </td>
                </tr>
                <!----buttons row_closed--->
              </tbody>
            </tr>--%>
          </tbody>
          <tfoot>
            <tr class="bg1 txt_rd">
              <th colspan="2"></th>
              <th class="bg1 tr_r" ><input id="ExpTotal" runat="server" style="background-color: #ececec;border: none;text-align: right;"/></th>
              <th class="bg1 tr_r"><input id="SetlTotal" runat="server" style="background-color: #ececec;border: none;text-align: right;"/></th>
              <th class="bg1 tr_r"><input id="BalTotal" runat="server" style="background-color: #ececec;border: none;text-align: right;"/></th>
              <th colspan="2"></th>
            </tr>
          </tfoot>
        </table>
        <div class="fg2">
          <label for="email" class="fg2_la1">Description: <span class="spn1">&nbsp;</span></label>
          <textarea id="txtDescription" runat="server" rows="2" cols="50" class="form-control" placeholder="Write something here..." maxlength="100"></textarea>
        </div>
      </div>
      <div class="modal-footer">
        <div class="note_bx mr_at flt_l">
            <div class="bo_not3">
            <i class="fa fa-square"></i>Pending Settlement
          </div>
            <br />
          <div class="bo_not2">
            <i class="fa fa-square"></i>Partially Settled
          </div><br/>
          <div class="bo_not1">
            <i class="fa fa-square"></i>Fully Settled
          </div>
        </div>
              <asp:Button ID="btnSave"  runat="server" class="btn sub1"  OnClientClick="return ValidateExpDtls();" Text="Save" OnClick="btnSave_Click"  />
              <asp:Button ID="btnSaveAndClose"  runat="server"  class="btn sub3" OnClientClick="return ValidateExpDtls();" Text="Save & Close" OnClick="btnSave_Click"  />
              <asp:Button ID="btnUpdate" runat="server"  class="btn sub1" OnClientClick="return ValidateExpDtls();" Text="Update" OnClick="btnUpdate_Click"  />
              <asp:Button ID="btnUpdateAndClose"  runat="server" class="btn sub3" OnClientClick="return ValidateExpDtls();" Text="Update & Close" OnClick="btnUpdate_Click" />
             <%-- <asp:Button ID="btnConfirm" runat="server" OnClientClick="return ExpConfirmAlert();" class="btn sub2" Text="Confirm" />--%>
              <%--<asp:Button ID="btnReopen"  runat="server" OnClientClick="return ExpReopenAlert();" class="btn sub2" Text="Reopen" />--%>
              <asp:Button ID="btnClear" runat="server" OnClientClick="return AlertClearAll();" class="btn sub2" Text="Clear" />
              <asp:Button ID="btnCancel" runat="server" OnClientClick="return ConfirmMessage();"  class="btn sub4" Text="Cancel" /> 
              <asp:Button ID="btnConfirmClick" Style="display:none;" runat="server"  OnClientClick="return ValidateExpDtls();" class="btn sub2" Text="Confirm" OnClick="btnUpdate_Click" />
              <asp:Button ID="btnReopenClick" Style="display:none;" runat="server" OnClientClick="return ValidateExpDtls();" class="btn sub2" Text="Reopen" OnClick="btnReopen_Click" />
      </div>
    </div>
  </div>
</div>

<!--modal_cc_closed-->
           
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

            //alert(PageMaxSize);
            //alert(PageNumber);
            //alert(strCommonSearchTerm);
            //alert(OrderColumn);
            //alert(OrderMethod);
            //alert(strInputColumnSearch);
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

        function printsorted() {


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
        function PrintCSV() {

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

                   
                   // document.getElementById("<%=btnConfirmClick.ClientID%>").click();
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

               // ExpConfirmAlert();

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

                   // document.getElementById("<%=btnReopenClick.ClientID%>").click();
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

               // ExpReopenAlert();

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
    <%--EVM 0044--%>
  <%--  bug--%>
    <script>
        $(document).ready(function () {
            $(".btn act_btn bn7 shw_dwn").click(function () {
                $(".add_dedu").toggle(200);
                $(".add_dedu1").hide(200)
            });
        });
        $(document).ready(function () {
            $(".btn act_btn bn7 shw_dwn1").click(function () {
                $(".add_dedu1").toggle(200);
                $(".add_dedu").hide(200);
            });
        });
        $(document).on('keydown', function (e) {
            if (e.keyCode === 27) { // ESC
                // $(".add_dedu, .add_dedu1").hide();
                document.getElementById("<%=Hiddenpopup.ClientID%>").value = "0";

               // jQuery('#ExpTable').empty();

            }
        });
</script>

<!---date_pickers--->
<%--<script type="text/javascript">
    $(function () {
        $("#datepicker9").datepicker({
            autoclose: true,
            todayHighlight: true
        }).datepicker('update', new Date());
    });
</script>
<!--date_picker--->

<link href="../date_pick/datepicker.css" rel="stylesheet" type="text/css" /><!-- 
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script> -->
<script src="../date_pick/datepicker.js"></script>--%>

    <%--------------%>
</asp:Content>

