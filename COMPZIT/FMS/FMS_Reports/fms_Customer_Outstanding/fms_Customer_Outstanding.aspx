<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Customer_Outstanding.aspx.cs" Inherits="FMS_FMS_Reports_fms_Customer_Outstanding_fms_Customer_Outstanding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
        $noCon(window).load(function () {
            var x = "";
            LoadEmpList();
            loadTableDesg(0);
        });
        function loadTableDesg(mode) {

            var TitleName = "";
            if (mode == 0) {
                TitleName = "STATEMENT OF ACCOUNT";
                document.getElementById("hStatementType").innerHTML = "STATEMENT OF ACCOUNT";
            }
            else {
                TitleName = "OUTSTANDING STATEMENT OF ACCOUNT";
                document.getElementById("hStatementType").innerHTML = "OUTSTANDING STATEMENT OF ACCOUNT";
            }

        }
        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                var prm = Sys.WebForms.PageRequestManager.getInstance();
                //  prm.add_initializeRequest(InitializeRequest);
                prm.add_endRequest(EndRequest);
            });
        })(jQuery);

        function EndRequest(sender, args) {
            // after update occur on UpdatePanel re-init the Autocomplete
            LoadEmpList();

        }

        function PostdatedChqDisplay(LdgrId) {
            //alert(LdgrId);
            var CorpId = '<%= Session["CORPOFFICEID"] %>';
             var OrgId = '<%= Session["ORGID"] %>';

             if (LdgrId != "") {
                 $noCon.ajax({
                     type: "POST",
                     async: false,
                     url: "fms_Customer_Outstanding.aspx/LoadPostdatedChqDtls",
                     data: '{OrgId:"' + OrgId + '" ,CorpId:"' + CorpId + '",LdgrId:"' + LdgrId + '"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {
                         document.getElementById("tblPostdateChq").innerHTML = "";

                         if (response.d != "") {
                             document.getElementById("tblPostdateChq").innerHTML = response.d;
                             return false;
                         }
                     },
                     failure: function (response) {

                     }
                 });
             }
             return false;
         }
        function LoadEmpList() {
            var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';
              var responsiveHelper_datatable_fixed_column = undefined;
              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };
              var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                  "bDestroy": true,
                  //  "order": [[2, 'asc']],

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
                  "columnDefs": [

                  ],
              });

              // custom toolbar
              // Apply the filter
              $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {
                  otable
                      .column($NoConfi(this).parent().index() + ':visible')
                      .search(this.value)
                      .draw();

              });
              /* END COLUMN FILTER */

          }

          function getdetails(href) {
              window.location = href;
              return false;
          }

          function SearchValidation() {
              var ret = true;
              document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
              var fromdate = document.getElementById("cphMain_txtFromdate").value;
              var toDate = document.getElementById("cphMain_txtTodate").value;
              if (fromdate == "" || toDate == "") {
                  if (fromdate == "") {
                      document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                  }
                  if (toDate == "") {
                      document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                  }
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });

                  $noCon(window).scrollTop(0);
                  ret = false;
              }
              if (fromdate != "" && toDate != "") {

                  var arrDateFromchk = fromdate.split("-");
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
              return ret;
          }
          function OpenCustomerDetails(StrId, RowId, mode) {
              var datefrom = document.getElementById("<%=HiddenFieldSearchToDate.ClientID%>").value;
              var decimalcount = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
              document.getElementById("<%=hiddenLedgerId.ClientID%>").value = StrId;
              document.getElementById("<%=hiddenMode.ClientID%>").value = mode;
              var LedgerName = document.getElementById("tdAmnt" + RowId).innerHTML;
              var Financialfrom = document.getElementById("<%=HiddenFieldSearchFromDate.ClientID%>").value;
              var FinancialEnd = document.getElementById("<%=HiddenEndDate.ClientID%>").value;
              document.getElementById("<%=CustomerHead.ClientID%>").innerHTML = LedgerName;
              var tableid = "";
              if (datefrom != "") {
                  var corpid = '<%= Session["CORPOFFICEID"] %>';
                  if (document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value != "") {
                      corpid = document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value;
                  }
                  var orgid = '<%= Session["ORGID"] %>';
                  var userid = '<%= Session["USERID"] %>';
                  $noCon.ajax({
                      type: "POST",
                      async: false,
                      url: "fms_Customer_Outstanding.aspx/CustomerDetails_ById",
                      data: '{StrId:"' + StrId + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",decimalcount:"' + decimalcount + '",Financialfrom:"' + Financialfrom + '",FinancialEnd:"' + FinancialEnd + '",mode:"' + mode + '"}',
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {
                        //  document.getElementById("<%=hiddenpdfpath.ClientID%>").value = response.d[5];

                          if (response.d[0] != "0") {
                              document.getElementById("divBank").innerHTML = response.d[1];
                              document.getElementById("<%=divPrintCaption.ClientID%>").innerHTML = response.d[3];
                            //  document.getElementById("<%=divPrintReport.ClientID%>").innerHTML = response.d[4];
                              $('#dialog_simple').modal('show');
                          }
                      },
                      failure: function (response) {

                      }
                  });

                  LoadEmpList();
                  loadTableDesg(mode);
              }
              return false;
          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:HiddenField ID="HiddenEndDate" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldCorpId" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenLedgerId" runat="server" />
    <asp:HiddenField ID="hiddenMode" runat="server" />
    <asp:HiddenField ID="HiddenFieldSearchFromDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldSearchToDate" runat="server" />
    <asp:HiddenField ID="hiddenpdfpath" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>


    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Customer Outstanding Report</li>
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
                <h2>
                    <asp:Label ID="lblEntry" runat="server">Customer Outstanding Report</asp:Label>
                </h2>

                <div class="form-group fg2">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1">*</span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtFromdate" runat="server" type="text" readonly="readonly" autocomplete="off" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>

                    <script>
                        var StartDateVal = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                        var EndDateVal = document.getElementById("<%=HiddenEndDate.ClientID%>").value;

                        $noCon('#datepicker').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            //startDate: StartDateVal,
                            endDate: EndDateVal,
                        });
                    </script>
                </div>

                <div class="form-group fg2">
                    <label for="pwd" class="fg2_la1">To Date:<span class="spn1">*</span> </label>
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" readonly="readonly" autocomplete="off" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var StartDateVal = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                        var EndDateVal = document.getElementById("<%=HiddenEndDate.ClientID%>").value;
                        $noCon('#datepicker1').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            //startDate: StartDateVal,
                            endDate: EndDateVal,
                        });
                    </script>
                </div>

                <div class="fg2">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();" />
                </div>
                <div class="clearfix"></div>
                <div class="devider"></div>

                <div id="divList" runat="server" class="table_box tb_scr">
                </div>
                <button id="print" onclick="return PrintClick('pdf');" class="print_o"><i class="fa fa-print"></i></button>
                <button id="csv" onclick="return PrintClick('csv');" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>
            </div>
        </div>
    </div>
    <div id="divReport" class="table-responsive" runat="server" style="display: none;">
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
        CUSTOMER OUTSTANDING
    </div>


    <%--------------------------------View for error Reason--------------------------%>
    <div class="modal fade" id="dialog_simple" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod2" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title tr_c" id="hStatementType">STATEMENT OF ACCOUNT</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="customer">
                        <h3>
                            <label id="CustomerHead" runat="server"></label>
                            <span class="pull-right"></span></h3>
                    </div>
                    <div id="divBackLink" runat="server" class="eachform">
                    </div>
                    <div id="divBank"></div>

                </div>
                <div class="modal-footer">
                    <button id="ButtnDrlldownClick" onclick="return PrintClickDrillDwn('pdf');" class="pnt_mod"><i class="fa fa-print"></i></button>
                    <button id="ButtnDrlldownClickCSV" onclick="return PrintClickDrillDwn('csv');" title="CSV" class="pnt_mod" style="background-color: #2a57ab;" ><i class="fa fa-file-excel-o"></i></button>
                </div>
            </div>
        </div>
    </div>

    
    <!----post_dated detailed_section_popup_opened--->

<div class="modal fade" id="divPostdatedChq" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod2" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title tr_c" id="H1">Postdated Cheque</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="customer">
        </div>

    <table id="tblPostdateChq" class="display table-bordered" cellspacing="0" width="100%">
    </table>

      </div>
      <div class="modal-footer">
      </div>
    </div>
  </div>
</div>
<!----post_dated detailed_section_popup_closed--->

    <script>
        function PrintClick(PrintMode) {
            var strPrintMode = PrintMode;
            var datefrom = document.getElementById("<%=HiddenFieldSearchToDate.ClientID%>").value;
            var decimalCount = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var tableid = "";
            var Financialfrom = document.getElementById("<%=HiddenFieldSearchFromDate.ClientID%>").value;
            var FinancialEnd = document.getElementById("<%=HiddenEndDate.ClientID%>").value;
            if (datefrom != "") {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                  if (document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value != "") {
                      corpid = document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value;
                  }
                  var orgid = '<%= Session["ORGID"] %>';
                  var userid = '<%= Session["USERID"] %>';
                  $noCon.ajax({
                      type: "POST",
                      async: false,
                      url: "fms_Customer_Outstanding.aspx/CustomerDetails",
                      data: '{intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",decimalCount:"' + decimalCount + '",Financialfrom:"' + Financialfrom + '",FinancialEnd:"' + FinancialEnd + '",strPrintMode:"' + strPrintMode + '"}',
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {
                          window.open(response.d[2], '_blank');
                          if (response.d[0] != "1") {
                              // document.getElementById("divBank").innerHTML = response.d[1];
                              document.getElementById("<%=divPrintCaption.ClientID%>").innerHTML = response.d[3];
                              document.getElementById("<%=divPrintReport.ClientID%>").innerHTML = response.d[1];
                              
                              
                            //  $('#dialog_simple').modal('show');
                        }
                    },
                    failure: function (response) {

                    }
                  });
               
              //  window.open(response.d[2], '_blank');
              // window.open("../../Print/Common_print.htm");
            }
            return false;

        }

        function PrintClickDrillDwn(PrintMode) {
            var strPrintMode = PrintMode;
            var datefrom = document.getElementById("<%=HiddenFieldSearchToDate.ClientID%>").value;
            var decimalcount = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;
            var StrId = document.getElementById("<%=hiddenLedgerId.ClientID%>").value;
            var mode = document.getElementById("<%=hiddenMode.ClientID%>").value;
            var Financialfrom = document.getElementById("<%=HiddenFieldSearchFromDate.ClientID%>").value;
            var FinancialEnd = document.getElementById("<%=HiddenEndDate.ClientID%>").value;
            var tableid = "";
            if (datefrom != "") {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                if (document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value != "") {
                    corpid = document.getElementById("<%=HiddenFieldCorpId.ClientID%>").value;
                }
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Customer_Outstanding.aspx/CustomerDetails_ById_Print",
                    data: '{StrId:"' + StrId + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",decimalcount:"' + decimalcount + '",Financialfrom:"' + Financialfrom + '",FinancialEnd:"' + FinancialEnd + '",mode:"' + mode + '",strPrintMode:"' + strPrintMode + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        window.open(response.d[0], '_blank');
                    },
                    failure: function (response) {

                    }
                });
            }
            return false;
        }
    </script>




</asp:Content>

