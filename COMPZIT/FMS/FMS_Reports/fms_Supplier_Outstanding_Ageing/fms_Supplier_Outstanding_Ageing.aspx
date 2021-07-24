<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Supplier_Outstanding_Ageing.aspx.cs" Inherits="FMS_FMS_Reports_fms_Supplier_Outstanding_Ageing_fms_Supplier_Outstanding_Ageing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>

    <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();
          $noCon(window).load(function () {
              ChangeMode(1);
              //if (document.getElementById("<%=radioCredit.ClientID%>").checked == true) {
                  //ChangeBaseMode(1);
              //}
              //else {
                  //ChangeBaseMode(0);
              //}
              var x = "";
              LoadEmpList(x);
            //  loadTableDesg();
          });
       
          function LoadEmpList(x) {


              var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';



              var responsiveHelper_datatable_fixed_column = undefined;


              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };

              /* COLUMN FILTER  */
              var otable = $NoConfi3('#datatable_fixed_column' + x).DataTable({
                  //"bfilter": false,
                  //"binfo": false,
                  //"blengthchange": false
                  //"bautowidth": false,
                  // "bpaginate": false,
                  //"bstatesave": true // saves sort state using localstorage
                  "bDestroy": true,
                  "ordering": false,

                  "preDrawCallback": function () {
                      // Initialize the responsive datatables helper once.
                      if (!responsiveHelper_datatable_fixed_column) {
                          responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#datatable_fixed_column' + x), breakpointDefinition);
                      }
                  },
                  "rowCallback": function (nRow) {
                      responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                  },
                  "drawCallback": function (oSettings) {
                      responsiveHelper_datatable_fixed_column.respond();
                  }

              });

              // custom toolbar
              //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

              // Apply the filter
              $NoConfi("#datatable_fixed_column" + x + " thead th input[type=text]").on('keyup change', function () {

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
              document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
              var toDate = document.getElementById("cphMain_txtTodate").value;

              document.getElementById("cphMain_txtSplit1").style.borderColor = "";
              document.getElementById("cphMain_txtSplit2").style.borderColor = "";
              document.getElementById("cphMain_txtSplit3").style.borderColor = "";
              if (document.getElementById("cphMain_ddlMode").value == "0") {
                
              
              }
              if (document.getElementById("cphMain_ddlMode").value == "1") {
                  if (document.getElementById("<%=radioCredit.ClientID%>").checked == false) {

                      if (document.getElementById("cphMain_txtSplit3").value == "") {
                          document.getElementById("cphMain_txtSplit3").style.borderColor = "Red";
                          document.getElementById("cphMain_txtSplit3").focus();
                          ret = false;
                      }
                      if (document.getElementById("cphMain_txtSplit2").value == "") {
                          document.getElementById("cphMain_txtSplit2").style.borderColor = "Red";
                          document.getElementById("cphMain_txtSplit2").focus();
                          ret = false;
                      }
                      if (document.getElementById("cphMain_txtSplit1").value == "") {
                          document.getElementById("cphMain_txtSplit1").style.borderColor = "Red";
                          document.getElementById("cphMain_txtSplit1").focus();
                          ret = false;
                      }
                  }
              }
              if (toDate == "") {
                  document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                  ret = false;
              }
              if (ret == false) {
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                 
                  $noCon(window).scrollTop(0);
              }
              return ret;
          }

          function ChangeMode(x) {

              if (x == 0) {
                  document.getElementById("cphMain_txtSplit1").value = "";
                  document.getElementById("cphMain_txtSplit2").value = "";
                  document.getElementById("cphMain_txtSplit3").value = "";
                  document.getElementById("cphMain_txtFromAgeing").value = "";
                  document.getElementById("cphMain_txtToAgeing").value = "";
              }
              if (document.getElementById("<%=radioCredit.ClientID%>").checked == false) {

                  document.getElementById("cphMain_txtSplit1").style.borderColor = "";
                  document.getElementById("cphMain_txtSplit2").style.borderColor = "";
                  document.getElementById("cphMain_txtSplit3").style.borderColor = "";
                  document.getElementById("cphMain_txtFromAgeing").style.borderColor = "";
                  document.getElementById("cphMain_txtToAgeing").style.borderColor = "";

                  if (document.getElementById("cphMain_ddlMode").value == "0") {
                      document.getElementById("divMethod1").style.display = "block";
                      document.getElementById("divMethod2").style.display = "none";
                  }
                  else {
                      document.getElementById("divMethod2").style.display = "block";
                      document.getElementById("divMethod1").style.display = "none";
                  }
              }
              else {
                  document.getElementById("divMode").style.display = "none";
              }
          }
          //----EVM 0044 14/02
          function ChangeBaseMode(x) {

              if (x == 0) {
                  document.getElementById("divMethod1").style.display = "none";
                  document.getElementById("divMethod2").style.display = "none";

                  document.getElementById("cphMain_txtSplit1").value = "";
                  document.getElementById("cphMain_txtSplit2").value = "";
                  document.getElementById("cphMain_txtSplit3").value = "";
                 
                  document.getElementById("cphMain_txtFromAgeing").value = "";
                  document.getElementById("cphMain_txtToAgeing").value = "";


                  document.getElementById("cphMain_txtSplit1").style.borderColor = "";
                  document.getElementById("cphMain_txtSplit2").style.borderColor = "";
                  document.getElementById("cphMain_txtSplit3").style.borderColor = "";
                  document.getElementById("cphMain_txtFromAgeing").style.borderColor = "";
                  document.getElementById("cphMain_txtToAgeing").style.borderColor = "";

                  if (document.getElementById("cphMain_ddlMode").value == "0") {
                      document.getElementById("divMethod1").style.display = "block";
                      document.getElementById("divMode").style.display = "block";
                      document.getElementById("divMethod2").style.display = "none";
                  }
                  else {
                      document.getElementById("divMode").style.display = "block";
                      document.getElementById("divMethod2").style.display = "block";
                      document.getElementById("divMethod1").style.display = "none";
                  }

              }
              else if (x == 1) {
                  document.getElementById("divMethod2").style.display = "none";
                  document.getElementById("divMethod1").style.display = "none";
                  document.getElementById("divMode").style.display = "none";
                  document.getElementById("cphMain_ddlMode").value = "0";
              }


          }
          //-----------
          function ChangeSplit(Obj) {
              var ret = true;
              Obj.style.borderColor = "";
              var Split1 = document.getElementById("cphMain_txtSplit1").value;
              var Split2 = document.getElementById("cphMain_txtSplit2").value;
              var Split3 = document.getElementById("cphMain_txtSplit3").value;

              if ((Split1 != "" && parseInt(Split1) < 2) || (Split2 != "" && parseInt(Split2) < 4) || (Split3 != "" && parseInt(Split3) < 6)) {
                  ret = false;
              }
              else if (Split1 != "" && (Split2 != "" && parseInt(Split2) - parseInt(Split1) < 2) || (Split3 != "" && parseInt(Split3) - parseInt(Split1) < 2)) {
                  ret = false;
              }
              else if (Split2 != "" && (Split1 != "" && parseInt(Split2) - parseInt(Split1) < 2) || (Split3 != "" && parseInt(Split3) - parseInt(Split2) < 2)) {
                  ret = false;
              }
              else if (Split3 != "" && (Split2 != "" && parseInt(Split3) - parseInt(Split2) < 2) || (Split1 != "" && parseInt(Split3) - parseInt(Split1) < 2)) {
                  ret = false;
              }
              if (ret == false) {
                  Obj.style.borderColor = "red";
                  Obj.value = "";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                 
                  $noCon(window).scrollTop(0);
              }
          }
          function ChangeFromToAge(Obj) {
              var ret = true;
              var FromAge = document.getElementById("cphMain_txtFromAgeing").value;
              var ToAge = document.getElementById("cphMain_txtToAgeing").value;
              if ((FromAge != "" && parseInt(FromAge) < 0) || (ToAge != "" && parseInt(ToAge) < 1)) {
                  ret = false;
              }
              else if (FromAge != "" && ToAge != "" && (parseInt(ToAge) - parseInt(FromAge) < 0)) {
                  ret = false;
              }
              if (ret == false) {
               
                      
                          Obj.style.borderColor = "Red";
                          Obj.focus();
                          $noCon("#divWarning").html("From Date should not be greater than to date.");
                          $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                          });

                          $noCon(window).scrollTop(0);
                      
                 
                  Obj.value = "";
              }
          }

          function PendingReceiptsDisplay(LdgrId) {

              var CorpId = '<%= Session["CORPOFFICEID"] %>';
              var OrgId = '<%= Session["ORGID"] %>';

              if (LdgrId != "") {
                  $noCon.ajax({
                      type: "POST",
                      async: false,
                      url: "fms_Supplier_Outstanding_Ageing.aspx/LoadPendingReceipts",
                      data: '{OrgId:"' + OrgId + '" ,CorpId:"' + CorpId + '",LdgrId:"' + LdgrId + '"}',
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {
                          document.getElementById("tblPendingRcpts").innerHTML = "";

                          if (response.d != "") {
                              document.getElementById("tblPendingRcpts").innerHTML = response.d;
                              return false;
                          }
                      },
                      failure: function (response) {

                      }
                  });
              }
              return false;
          }


        function PostdatedChqDisplay(LdgrId) {
            //alert(LdgrId);
            var CorpId = '<%= Session["CORPOFFICEID"] %>';
            var OrgId = '<%= Session["ORGID"] %>';

            if (LdgrId != "") {
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Supplier_Outstanding_Ageing.aspx/LoadPostdatedChqDtls",
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

      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
    <asp:HiddenField ID="HiddenEnableModify" runat="server" />
    <asp:HiddenField ID="HiddenVouchrTyp" runat="server" />
    <asp:HiddenField ID="HiddenRowCount" runat="server" />
    <asp:HiddenField ID="HiddenVouchers" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearTo" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearFrom" runat="server" />
    <asp:HiddenField ID="HiddenFieldNewToDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldSearchDate" runat="server" />
    <asp:HiddenField ID="HiddenStrId" runat="server" />
    <asp:HiddenField ID="HiddenStrName" runat="server" />
    <asp:HiddenField ID="HiddenAgeingFrom" runat="server" />
    <asp:HiddenField ID="HiddenAgeingTo" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

   <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Supplier Outstanding Ageing Report  </li>
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

    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h2>
                    <asp:Label ID="lblEntry" runat="server"> SUPPLIER OUTSTANDING AGEING REPORT  </asp:Label>
                </h2>
                 <div class="form-group fg7 fg2_mr">
            <div class="">
              <div class="fg12">
                <label for="pwd" class="fg2_la1">Based on:<span class="spn1">*</span></label>
                <div class="form-check chk_bas">
                  <input class="form-check-input" type="radio" name="basedon" id="radioDate" value="option1" checked="true"  runat ="server"  onchange="ChangeBaseMode(0);"/>
                  <label class="form-check-label" for="radioDate">Invoice Date</label>
                </div>
                <div class="form-check chk_bas1">
                  <input class="form-check-input" type="radio" name="basedon" id="radioCredit" value="option2" runat="server"  onchange="ChangeBaseMode(1);" />
                  <label class="form-check-label" for="radioCredit">Credit Period</label>
                </div>
              </div>
            </div>
          </div>

                <div class="form-group fg5 sa_o_fg4 sa_1">
                    <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span></label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" placeholder="dd-mm-yyyy" maxlength="10" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var StartDateVal = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
                        var EndDateVal = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;
                        $noCon('#cphMain_txtTodate').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            //startDate: StartDateVal,
                            endDate: EndDateVal,
                        });
                    </script>
                </div>
                <!----based select area _opened--->
        <div class="dis_ar_bsd" style="display:block;">
                <div class="form-group fg7 mar_lt sa_o_fg4 sa_1" id="divMode">
                    <label for="email" class="fg2_la1">Mode:<span class="spn1">*</span></label>
                    <div id="divAccount">
                        <asp:DropDownList ID="ddlMode" onchange="return ChangeMode(0);" class="form-control fg2_inp1 inp_mst ddl" runat="server">
                            <asp:ListItem Text="Method 1" Value="0" />
                            <asp:ListItem Text="Method 2" Value="1" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="motd_1 sa_o_fg4 sa_1" id="divMethod1">
                    <div class="form-group fg7 ">
                        <label for="email" class="fg2_la1">Ageing From:<span class="spn1">*</span></label>
                        <input id="txtFromAgeing" runat="server" autocomplete="off" type="text" onchange="return ChangeFromToAge(cphMain_txtFromAgeing);" onkeypress="return isNumber(event)" onkeydown="return isNumber(event)" class="form-control fg2_inp1 inp_mst" maxlength="10" />
                    </div>
                    <div class="form-group fg7">
                        <label for="email" class="fg2_la1">Ageing To:<span class="spn1">*</span></label>
                        <input id="txtToAgeing" runat="server" autocomplete="off" type="text" onchange="return ChangeFromToAge(cphMain_txtToAgeing);" onkeypress="return isNumber(event)" onkeydown="return isNumber(event)" class="form-control fg2_inp1 inp_mst" maxlength="10" />
                    </div>
                </div>

                <div class="motd_2 sa_o_fg4 sa_1" id="divMethod2">
                    <div class="form-group fg2 sa_1">
                        <label for="email" class="fg2_la1">Ageing Split:<span class="spn1">*</span></label>
                        <div class="col-md-4 pa_l">
                            <input id="txtSplit1" runat="server" autocomplete="off" type="text" onchange="return ChangeSplit(cphMain_txtSplit1);" onkeypress="return isNumber(event)" onkeydown="return isNumber(event)" class="form-control fg2_inp1 inp_mst tr_r" maxlength="10" />

                        </div>
                        <div class="col-md-4 pa_l">
                            <input id="txtSplit2" runat="server"  autocomplete="off" type="text" onchange="return ChangeSplit(cphMain_txtSplit2);" onkeypress="return isNumber(event)" onkeydown="return isNumber(event)" class="form-control fg2_inp1 inp_mst tr_r" maxlength="10" />
                        </div>
                        <div class="col-md-4 pa_l">
                            <input id="txtSplit3" runat="server" autocomplete="off" type="text" onchange="return ChangeSplit(cphMain_txtSplit3);" onkeypress="return isNumber(event)" onkeydown="return isNumber(event)" class="form-control fg2_inp1 inp_mst tr_r" maxlength="10" />
                        </div>
                    </div>
                    <div class="form-group fg7 fg2_mr sa_o_fg4 sa_1">
                        <div class="row">
                            <div class="">
                                <div class="form-check">
                                    <input class="form-check-input" name="optradio" type="radio" checked="true" onkeypress="return DisableEnter(event)" runat="server" id="radioConsoldtd" />
                                    <label class="form-check-label" for="gridRadios1">Consolidated</label>
                                </div>
                                <div class="form-check">
                                    <input lass="form-check-input" name="optradio" type="radio" id="radioIndividual" onkeypress="return DisableEnter(event)" runat="server" />
                                    <label class="form-check-label" for="gridRadios2">Individual</label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="fg8">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();" />
                </div>


                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider"></div>

                <button id="print" onclick="return PrintClick('pdf');" class="print_o"><i class="fa fa-print"></i></button>
                <button id="csv" onclick="return PrintClick('csv');" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>

                <div id="divList" runat="server" class="table_box tb_scr">
                </div>
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
        SUPPLIER OUTSTANDING AGEING REPORT
    </div>

    <div class="modal fade" id="dialog_simple" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod2" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title tr_c" id="hStatementType">SUPPLIER OUTSTANDING AGEING REPORT</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="customer">
                        <div id="divBackLink" runat="server" href="#">
                            <h5 id="CustName"></h5>
                            <span class="pull-right">
                                <h5 id="ageLbl"></h5>
                            </span>
                            <br />
                        </div>
                    </div>
                    <div id="divBank"></div>

                </div>
                <div class="modal-footer">
                    <button id="ButtnDrlldownClick" onclick="return PrintClickDrillDwn('pdf');" class="pnt_mod"><i class="fa fa-print"></i></button>
                    <button id="csv_sub" style="background-color: #2a57ab;" onclick="return PrintClickDrillDwn('csv');" title="CSV" class="pnt_mod"><i class="fa fa-file-excel-o"></i></button>

                </div>
            </div>
        </div>
    </div>


      <!-- Modal_method4 -->
<div class="modal fade" id="ModalPendingReceipt" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod2" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title tr_c" id="exampleModalLabel">Pending Reciept Details</h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="customer">
        </div>

         <table id="tblPendingRcpts" class="display table-bordered" cellspacing="0" width="100%">
        </table>

      </div>
      <div class="modal-footer">
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
        function ChangeStatus() {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reconcile this entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {


                    if (Validate() == true) {
                     
                        return false;

                    }

                }
            });
            return false;

        }
            

      
        function PrintClick(PrintMode) {
            var strPrintMode = PrintMode;
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                   var orgid = '<%= Session["ORGID"] %>';
                   var userid = '<%= Session["USERID"] %>';
                   var datefrom = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
                var dateto = document.getElementById("<%=txtTodate.ClientID%>").value;
                var mode = document.getElementById("<%=ddlMode.ClientID%>").value;
                var FinYearFromDate = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
                var FinYearToDate = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;
                var individual;
                if (document.getElementById("<%=radioIndividual.ClientID%>").checked == true) {
                    individual = 0;
                }
                if (document.getElementById("<%=radioConsoldtd.ClientID%>").checked == true) {
                    individual = 1;
                }
            if (document.getElementById("<%=radioCredit.ClientID%>").checked == true) {
                individual = 2;
            }
                
                var AgeingFrom = 0;
                var AgeingTo = 0;
                var Split1 = 0;
                var Split2 = 0;
                var Split3 = 0;
                if (mode == "0") {
                    AgeingFrom = document.getElementById("cphMain_txtFromAgeing").value;
                    AgeingTo = document.getElementById("cphMain_txtToAgeing").value;
                }
                if (mode == "1") {
                    Split1 = document.getElementById("cphMain_txtSplit1").value;
                    Split2 = document.getElementById("cphMain_txtSplit2").value;
                    Split3 = document.getElementById("cphMain_txtSplit3").value;

                }
                   $noCon.ajax({
                       type: "POST",
                       async: false,
                       url: "fms_Supplier_Outstanding_Ageing.aspx/LoadConvertToTable_Print",
                       data: '{intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",intdateto:"' + dateto + '",mode:"' + mode + '",AgeingFrom:"' + AgeingFrom + '",AgeingTo:"' + AgeingTo + '",Split1:"' + Split1 + '",Split2:"' + Split2 + '",Split3:"' + Split3 + '",FinYearFromDate:"' + FinYearFromDate + '",FinYearToDate:"' + FinYearToDate + '",individual:"' + individual + '",strPrintMode:"' + strPrintMode + '"}',
                       contentType: "application/json; charset=utf-8",
                       dataType: "json",
                       success: function (response) {
                           if (response.d != "") {
                               window.open(response.d[0], '_blank');
                           }
                       }
                   });
                   return false;
               }
            //window.open("../../Print/Common_print.htm");
            //return false;
       
        function PrintClickDrillDwn(PrintMode) {
            var strPrintMode = PrintMode;
            var datefrom = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
            var dateto = document.getElementById("<%=HiddenFieldSearchDate.ClientID%>").value;
            var FinYearFromDate = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
            var FinYearToDate = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;
          
            var StrId = document.getElementById("<%=HiddenStrId.ClientID%>").value;
            var strName = document.getElementById("<%=HiddenStrName.ClientID%>").value;
           
            var individual;
            if (document.getElementById("<%=radioIndividual.ClientID%>").checked == true) {
                individual = 0;
            }
            if (document.getElementById("<%=radioConsoldtd.ClientID%>").checked == true) {
                individual = 1;
            }
           
            var mode = document.getElementById("<%=ddlMode.ClientID%>").value;

            var AgeingFrom = document.getElementById("<%=HiddenAgeingFrom.ClientID%>").value;
            var AgeingTo = document.getElementById("<%=HiddenAgeingTo.ClientID%>").value;
            var Split1 = 0;
            var Split2 = 0;
            var Split3 = 0;
            if (mode == "0") {
                AgeingFrom = document.getElementById("cphMain_txtFromAgeing").value;
                AgeingTo = document.getElementById("cphMain_txtToAgeing").value;
            }
            if (mode == "1") {
                Split1 = document.getElementById("cphMain_txtSplit1").value;
                Split2 = document.getElementById("cphMain_txtSplit2").value;
                Split3 = document.getElementById("cphMain_txtSplit3").value;

            }
            if (document.getElementById("<%=radioCredit .ClientID%>").checked == true) {
                individual = 2;
                AgeingTo = document.getElementById("<%=HiddenAgeingTo.ClientID%>").value;
               
            }
          
            if (datefrom != "" && dateto != "") {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';

                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Supplier_Outstanding_Ageing.aspx/TrailBalance_Lists_ById_Print",
                    data: '{intAccntId:"' + StrId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",intdateto:"' + dateto + '",mode:"' + mode + '",AgeingFrom:"' + AgeingFrom + '",AgeingTo:"' + AgeingTo + '",Split1:"' + Split1 + '",Split2:"' + Split2 + '",Split3:"' + Split3 + '",strName:"' + strName + '",FinYearFromDate:"' + FinYearFromDate + '",FinYearToDate:"' + FinYearToDate + '",individual:"' + individual + '",strPrintMode:"' + strPrintMode + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d != "") {
                            window.open(response.d[0], '_blank');
                        }
                     
                    },
                    failure: function (response) {

                    }
                });

            }
            return false;
            //window.open("Supplier_Outstanding_Ageing_print.htm");
            //return false;
        }
        function OpenReconView(StrId, strName, mode, AgeingFrom, AgeingTo, Split1, Split2, Split3) {
            
            document.getElementById("<%=HiddenStrId.ClientID%>").value = StrId;
            document.getElementById("<%=HiddenStrName.ClientID%>").value = strName;
           
            var datefrom = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
            var dateto = document.getElementById("<%=HiddenFieldSearchDate.ClientID%>").value;
            var FinYearFromDate = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
            var FinYearToDate = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;
            document.getElementById("<%=HiddenAgeingFrom.ClientID%>").value = AgeingFrom;
            document.getElementById("<%=HiddenAgeingTo.ClientID%>").value = AgeingTo;
            if (datefrom != "" && dateto != "") {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';

                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Supplier_Outstanding_Ageing.aspx/TrailBalance_Lists_ById",
                    data: '{intAccntId:"' + StrId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",intdateto:"' + dateto + '",mode:"' + mode + '",AgeingFrom:"' + AgeingFrom + '",AgeingTo:"' + AgeingTo + '",Split1:"' + Split1 + '",Split2:"' + Split2 + '",Split3:"' + Split3 + '",strName:"' + strName + '",FinYearFromDate:"' + FinYearFromDate + '",FinYearToDate:"' + FinYearToDate + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        document.getElementById("<%=HiddenRowCount.ClientID%>").value = response.d[0]
                        document.getElementById("divBank").innerHTML = response.d[1];

                        document.getElementById("<%=divPrintCaptionDrilDown.ClientID%>").innerHTML = response.d[3];
                        document.getElementById("<%=divPrintReportDrilDown.ClientID%>").innerHTML = response.d[4];
                        $('#dialog_simple').modal('show');
                        LoadEmpList(response.d[2]);
                        //    loadTableDesg();
                        document.getElementById("ageLbl").innerHTML = "";

                        if ((strName.indexOf('‡') > -1) && (strName.indexOf('¦') > -1)) {
                            strName = strName.replace(/‡/g, '"');
                            strName = strName.replace(/¦/g, "'");
                        }
                        else {
                            if (strName.indexOf('‡') > -1) {
                                strName = strName.replace(/‡/g, '"');
                            }
                            if (strName.indexOf('¦') > -1) {
                                strName = strName.replace(/¦/g, "'");
                            }
                        }

                        document.getElementById("CustName").innerHTML = "Supplier Name: " + strName;
                        if (mode == 0) {
                            var FromAge = document.getElementById("cphMain_txtFromAgeing").value;
                            var ToAge = document.getElementById("cphMain_txtToAgeing").value;
                            if (FromAge != "" && ToAge != "") {
                                document.getElementById("ageLbl").innerHTML = "Outstanding Ageing " + FromAge + "-" + ToAge;
                            }
                            else if (FromAge != "") {
                                document.getElementById("ageLbl").innerHTML = "Outstanding Ageing >= " + FromAge;
                            }
                            else if (ToAge != "") {
                                document.getElementById("ageLbl").innerHTML = "Outstanding Ageing <= " + ToAge;
                            }
                        }
                        else if (mode == 2) {
                            if (AgeingTo != "-1" && AgeingTo != "0") {
                                document.getElementById("ageLbl").innerHTML = "Outstanding Ageing " + AgeingFrom + "-" + AgeingTo;
                            }
                            else if (AgeingTo == "0") {
                                document.getElementById("ageLbl").innerHTML = "Outstanding Ageing >" + (parseInt(AgeingFrom) - 1);
                            }
                            else {
                                document.getElementById("ageLbl").innerHTML = "No Due";
                            }
                        }
                        else if (mode == 1) {
                            document.getElementById("ageLbl").innerHTML = "Date: " + document.getElementById("cphMain_txtTodate").value;
                        }
                    },
                    failure: function (response) {

                    }
                });

            }
            return false;
        }
    </script>



       
    
</asp:Content>

