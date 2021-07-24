<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Purchase_Master_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Purchase_Master_Purchase_Master_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

     <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
  
    
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              //loadTableDesg();
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
                  else if (ReopenSts == 'successConfirm') {
                      SuccessConfirm();
                  }
                  
              }

              $noCon("#divddlSupplier input.ui-autocomplete-input").focus();
              $noCon("#divddlSupplier input.ui-autocomplete-input").select();

              LoadEmployeeList(0);

          });

          function getdetails(href) {
              window.location = href;
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

          function SuccessConfirm() {
              var ret = false;
              $noCon("#success-alert").html("Purchase details confirmed successfully.");
              $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function SuccessReoen() {
              var ret = false;
              $noCon("#success-alert").html("Purchase details reopened successfully.");
              $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["REOPEN_STS"] = "' + null + '"; %>';
              return false;
          }
          function AlreadyREopened() {
              $noCon("#divWarning").html("Purchase information already reopened.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });

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

          function AcntClosed() {
              $noCon("#divWarning").html("This action is  denied! Account is already closed .");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }

          function Error() {
              $noCon("#divWarning").html("Some error occured!");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              return false;
          }

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
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                        if (fromdate == "") {
                            document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";

                            $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                        if (toDate == "") {
                            document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                            $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            
                            $noCon(window).scrollTop(0);
                            ret = false;
                        }
                      //  alert(fromdate);
                        if (fromdate != "" && toDate != "") {

                            var arrDateFromchk = fromdate.split("-");
                            dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                            var arrDateTochk = toDate.split("-");
                            dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                            if (dateDateFromchk > dateDateTochk) {
                                $noCon("#divWarning").html("From date should not be greater than to date.");
                                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                
                                $noCon(window).scrollTop(0);
                                document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                                document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                                ret = false;
                            }
                        }

                        if (ret == true) {
                            LoadEmployeeList(0);

                        }
                        return ret;
                       
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
          //function PrintClick() {

          //    LoadEmployeeList(1);

          //    setTimeout(DelayPrint, 500);

          //    setTimeout(Load, 500);

          //    return false;
          //}

          //function Load() {
          //    LoadEmployeeList(0);
          //}

          //function DelayPrint() {
          //    DisplayPrint();
          //}

          function PrintClick() {

              var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';
              var Suplier = 0;
              var SupName = "";
              var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
              var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
              var reopenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
              var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
              var AuditPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
              var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
              var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
              var CurrencyId = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;
              var Status = document.getElementById("cphMain_ddlStatus").value;
              var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
              if (document.getElementById("<%=ddlSupplier.ClientID%>").value != "--SELECT SUPPLIER --") {
                  Suplier = document.getElementById("<%=ddlSupplier.ClientID%>").value;
                  SupName = $("#cphMain_ddlSupplier :selected").text();
              }
              var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
              var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;

              var startDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
              var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
              var CnclSts = 0;
              if (document.getElementById("cphMain_cbxCnclStatus").checked == true)
                  CnclSts = 1;
                  if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                      $.ajax({
                          type: "POST",
                          async: false,
                          contentType: "application/json; charset=utf-8",
                          url: "Purchase_Master_List.aspx/PrintList",
                          data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Status: "' + Status + '",PurchaseStatus: "' + PurchaseStatus + '",Suplier: "' + Suplier + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",CurrencyId: "' + CurrencyId + '",startDate: "' + startDate + '",EndDate: "' + EndDate + '",SupName: "' + SupName + '"}',
                          dataType: "json",
                          success: function (data) {
                              if (data.d != "") {
                                  window.open(data.d, '_blank');
                                  //document.getElementById("cphMain_divPrintReport").innerHTML = data.d;
                                  //window.open("../../Print/Common_print.htm");
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
              var Suplier = 0;
              var SupName = "";
              var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
              var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
              var reopenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
              var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
              var AuditPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
              var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
              var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
              var CurrencyId = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;
              var Status = document.getElementById("cphMain_ddlStatus").value;
              var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
              if (document.getElementById("<%=ddlSupplier.ClientID%>").value != "--SELECT SUPPLIER --") {
                  Suplier = document.getElementById("<%=ddlSupplier.ClientID%>").value;
                  SupName = $("#cphMain_ddlSupplier :selected").text();
              }
              var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
              var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
              var startDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
              var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
              var CnclSts = 0;
              if (document.getElementById("cphMain_cbxCnclStatus").checked == true)
                  CnclSts = 1;
              if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                  $.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "Purchase_Master_List.aspx/PrintCSV",
                      data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Status: "' + Status + '",PurchaseStatus: "' + PurchaseStatus + '",Suplier: "' + Suplier + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",CurrencyId: "' + CurrencyId + '",startDate: "' + startDate + '",EndDate: "' + EndDate + '",SupName: "' + SupName + '"}',
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
          function PrintVersnError() {
              $noCon("#divWarning").html("Please select a version for printing from account setting.");
              $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
              });
              $(window).scrollTop(0);
              return false;
          }

          </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCurrncyId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenReopen" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
    <asp:HiddenField ID="HiddenEnableModify" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />
    <asp:HiddenField ID="HiddenFinancialStartDate" runat="server" />
    <asp:HiddenField ID="HiddenFnancialEndDeate" runat="server" />
    <asp:HiddenField ID="HiddenAccountCloseDate" runat="server" />
    <asp:HiddenField ID="HiddenConfirmStatus" runat="server" />
    <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />
    <asp:HiddenField ID="hiddenPrintSts" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Purchase Register  </li>
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
                <h1 class="h1_con">Purchase Register  </h1>

                <div class="form-group fg7">
                    <label for="email" class="fg2_la1">Supplier:<span class="spn1"></span></label>
                    <div id="divddlSupplier">
                        <asp:DropDownList ID="ddlSupplier" class="form-control fg2_inp1" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg7">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtFromdate" runat="server" type="text" readonly="readonly" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var startDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                        var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
                        $noCon('#cphMain_txtFromdate').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            startDate: startDate,
                            endDate: EndDate,
                            timepicker: false
                        });
                    </script>
                </div>

                <div class="form-group fg7">
                    <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span></label>
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" readonly="readonly" onkeypress="return DisableEnter(event)" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var startDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                        var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
                        $noCon('#cphMain_txtTodate').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            startDate: startDate,
                            endDate: EndDate,
                            timepicker: false
                        });
                    </script>
                </div>

                <div class="form-group fg8 mar_lt">
                    <label for="email" class="fg2_la1">Status:<span class="spn1"></span></label>
                    <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1" runat="server">
                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                        <asp:ListItem Text="All" Value="2"></asp:ListItem>
                    </asp:DropDownList>

                </div>

                <div class="form-group fg7 mar_lt">
                    <label for="email" class="fg2_la1">Purchase Status:<span class="spn1"></span></label>
                    <asp:DropDownList ID="ddlPurchaseStatus" class="form-control fg2_inp1" runat="server">
                        <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Reopened" Value="2"></asp:ListItem>
                        <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                    </asp:DropDownList>

                </div>

                <div class="fg7">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" onkeypress="return DisableEnter(event)" class="form2" />
                            <button type="button" class="btn-d" data-color="p"  ng-model="all"></button>
                            <input type="checkbox" class="hidden" />
                        </span>
                        <p class="pz_s">Show Deleted Entries</p>
                    </label>
                </div>
            
                <div class="fg8">

                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <button type="button" id="btnSearch" onclick="return SearchValidation();" class="submit_ser"></button>

                </div>
                <div class="clearfix"></div>
                <div class="devider divid"></div>

                <div id="diEmployeeList">

   <div class="hcm_res">
                    <table id="datatable_fixed_column" class="display table-bordered hcm_re_tbl" style="width:100%;">
                        <thead class="thead1">
                            <tr class="SearchRow">
                                <th class="th_b4 tr_l">REF#
              <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <input type="text" class="tb_inp_1 tb_in tr_l" placeholder="REF #" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b6">DATE 
              <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <input type="text" class="tb_inp_1 tb_in tr_c" placeholder="DATE" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b2 tr_l">Supplier Name
              <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <input type="text" class="tb_inp_1 tb_in tr_l" placeholder="SUPPLIER" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b4 tr_r">TOTAL AMOUNT
              <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                    <input type="text" class="tb_inp_1 tb_in tr_r" placeholder="TOTAL AMOUNT" onkeydown="return DisableEnter(event)" />
                                </th>
                                <th class="th_b6 tr_c">STATUS
              <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                </th>
                                <th class="th_b2">ACTIONS 
                                    <i class="fa fa-sort pull-right hed_fa" aria-hidden="true"></i>
                                </th>

                               

                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="6" class="dataTables_empty">Loading details...</td>
                            </tr>
                        </tbody>
                        <tr id="trTotal" runat="server">

                        </tr>
                    </table>
</div>   

                </div>

                <asp:Button ID="btnEdit" runat="server" Text="Button" Style="display: none" />
                <div id="divAdd" onclick="location.href='Purchase_master.aspx'" class="add" runat="server">
                    <a href="Purchase_master.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                        <i class="fa fa-plus-circle"></i>
                    </a>
                </div>
                <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i> </button>
                <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>

            </div>
        </div>
    </div>


 



         


        <div id="divReport" class="table-responsive" runat="server" style="display:none;">
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


    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static"   role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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

           function LoadEmployeeList(mode) {

               var orgID = '<%= Session["ORGID"] %>';
               var corptID = '<%= Session["CORPOFFICEID"] %>';
               var Suplier = 0;
               var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
               var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
               var reopenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
               var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
               var AuditPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
               var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
               var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
               var CurrencyId = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;
               var Mode = mode;

               //   alert(EnableEdit + "||||" + EnableDelete + "||||" + EnableReopen);
               var Status = document.getElementById("cphMain_ddlStatus").value;
               var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
               if (document.getElementById("<%=ddlSupplier.ClientID%>").value != "--SELECT SUPPLIER --") {
                   Suplier = document.getElementById("<%=ddlSupplier.ClientID%>").value;
               }
               var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
               var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;

               var startDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
               var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;


               var CnclSts = 0;
               var responsiveHelper_datatable_fixed_column = undefined;
               var breakpointDefinition = {
                   tablet: 1024,
                   phone: 480
               };
               if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                   CnclSts = 1;
               }
               else {
                   CnclSts = 0;
               }

               if (CnclSts == 1) {
                   var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                      // 'bProcessing': true,
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
                           aoData.push({ "name": "SUPLIER", "value": Suplier });
                           aoData.push({ "name": "FROMDT", "value": from });
                           aoData.push({ "name": "TODAT", "value": toDt });
                           aoData.push({ "name": "ENABLEDIT", "value": EnableEdit });
                           aoData.push({ "name": "ENABLEDELETE", "value": EnableDelete });
                           aoData.push({ "name": "STARTDATE", "value": startDate });
                           aoData.push({ "name": "ENDDATE", "value": EndDate });
                           aoData.push({ "name": "ENDDATE", "value": EndDate });
                           aoData.push({ "name": "REOPEN", "value": reopenSts });
                           aoData.push({ "name": "ACNTCLSDT", "value": acntClsDate });
                           aoData.push({ "name": "AUDITPRVSN", "value": AuditPrvision });
                           aoData.push({ "name": "ENABLEAUDIT", "value": EnableAudit });
                           aoData.push({ "name": "CONFIRM", "value": EnableConfirm });
                           aoData.push({ "name": "PURCAHSESTATUS", "value": PurchaseStatus });
                           aoData.push({ "name": "CURRENCY", "value": CurrencyId });
                           aoData.push({ "name": "MODE", "value": Mode });

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
                           aoData.push({ "name": "SUPLIER", "value": Suplier });
                           aoData.push({ "name": "FROMDT", "value": from });
                           aoData.push({ "name": "TODAT", "value": toDt });
                           aoData.push({ "name": "ENABLEDIT", "value": EnableEdit });
                           aoData.push({ "name": "ENABLEDELETE", "value": EnableDelete });
                           aoData.push({ "name": "STARTDATE", "value": startDate });
                           aoData.push({ "name": "ENDDATE", "value": EndDate });
                           aoData.push({ "name": "ENDDATE", "value": EndDate });
                           aoData.push({ "name": "REOPEN", "value": reopenSts });
                           aoData.push({ "name": "ACNTCLSDT", "value": acntClsDate });
                           aoData.push({ "name": "AUDITPRVSN", "value": AuditPrvision });
                           aoData.push({ "name": "ENABLEAUDIT", "value": EnableAudit });
                           aoData.push({ "name": "CONFIRM", "value": EnableConfirm });
                           aoData.push({ "name": "PURCAHSESTATUS", "value": PurchaseStatus });
                           aoData.push({ "name": "CURRENCY", "value": CurrencyId });
                           aoData.push({ "name": "MODE", "value": Mode });

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
               var Suplier = 0;
               var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
              var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
               var reopenSts = document.getElementById("<%=HiddenReopen.ClientID%>").value;
               var acntClsDate = document.getElementById("<%= HiddenAccountCloseDate.ClientID%>").value;
               var AuditPrvision = document.getElementById("<%= HiddenProvisionSts.ClientID%>").value;
               var EnableAudit = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;
               var EnableConfirm = document.getElementById("<%=HiddenConfirmStatus.ClientID%>").value;
               var CurrencyId = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;
               var Status = document.getElementById("cphMain_ddlStatus").value;
               var PurchaseStatus = document.getElementById("cphMain_ddlPurchaseStatus").value;
               if (document.getElementById("<%=ddlSupplier.ClientID%>").value != "--SELECT SUPPLIER --") {
                  Suplier = document.getElementById("<%=ddlSupplier.ClientID%>").value;
              }
              var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
               var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;

               var startDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
               var EndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
               var CnclSts = 0;
               if (document.getElementById("cphMain_cbxCnclStatus").checked == true)
                   CnclSts = 1;
               if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "Purchase_Master_List.aspx/PurchaseAmountSum",
                       data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Status: "' + Status + '",PurchaseStatus: "' + PurchaseStatus + '",Suplier: "' + Suplier + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",CurrencyId: "' + CurrencyId + '",startDate: "' + startDate + '",EndDate: "' + EndDate + '"}',
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
               else {
                   window.location = '/Security/Login.aspx';
               }














           }


         

       </script>
       <script>
    
           function ConfirmByID(StrId) {

               ezBSAlert({
                   type: "confirm",
                   messageText: "Do you want to confirm this purchase?",
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
               var FinYrID = '<%=Session["FINCYRID"]%>';

               if (strPayemntId != "" && strUserID != '') {
                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "Purchase_Master_List.aspx/ConfirmPurchaseDetails",
                       data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",FinYrID: "' + FinYrID + '"}',
                       dataType: "json",
                       success: function (data) {
                           var ReopenSts = data.d;
                           if (ReopenSts != '') {
                               $(window).scrollTop(0);
                               LoadEmployeeList(0);
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
                               else if (ReopenSts == 'successConfirm') {
                                   SuccessConfirm();
                               }
                                   //0039
                               else if (ReopenSts == 'successConfirm') {
                                   SuccessConfirm();
                               }
                                   //end


                               else if (ReopenSts == 'alrdyCnfrmd') {
                                   AlreadyConfirmed();
                               }
                           }
                       }
                   });
               }

               return false;
           }
           function ReOpenByID(StrId) {

               ezBSAlert({
                   type: "confirm",
                   messageText: "Do you want to reopen this purchase?",
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

               if (strPayemntId != "" && strUserID != '') {

                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "Purchase_Master_List.aspx/ReopenPurchaseDetails",
                       data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                       dataType: "json",
                       success: function (data) {                           
                           var ReopenSts = data.d;
                           if (ReopenSts != '') {
                               $(window).scrollTop(0);
                               LoadEmployeeList(0);
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
                               else if (ReopenSts == 'successConfirm') {
                                   SuccessConfirm();
                               }
                               else if (ReopenSts == 'alrdyreopened') {
                                   AlreadyREopened();
                               }

                           }
                       }
                   });
            }

            return false;
        }



           function OpenPrint(StrId) {
               var orgID = '<%= Session["ORGID"] %>';
               var corptID = '<%= Session["CORPOFFICEID"] %>';
               var PreparedBy = '<%= Session["USERFULLNAME"] %>';
               var saleId = StrId;
               var CurrencyId = document.getElementById("<%=HiddenCurrncyId.ClientID%>").value;
              
                       if (corptID != "" && corptID != null && orgID != "" && orgID != null && saleId != "") {
                           $.ajax({
                               type: "POST",
                               async: false,
                               contentType: "application/json; charset=utf-8",
                               url: "Purchase_Master_List.aspx/PrintPDF",
                               data: '{saleId: "' + saleId + '",orgID: "' + orgID + '",corptID: "' + corptID + '",PreparedBy: "' + PreparedBy + '",CurrencyId: "' + CurrencyId + '"}',
                               dataType: "json",
                               success: function (data) {
                                 
                                   if (data.d != "false" && data.d != "")
                                   {
                                       window.open(data.d, '_blank');
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

    </script>
  
    <script>
        function ChangeStatus(StrId, stsmode, cnclusrId) {
            if (cnclusrId == "") {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to change the status of this purchase details?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        var usrId = '<%= Session["USERID"] %>';

                        var Details = PageMethods.ChangePurchaseStatus(StrId, stsmode, usrId, function (response) {
                            var SucessDetails = response;
                            if (SucessDetails == "success") {
                                window.location = 'Purchase_Master_List.aspx?InsUpd=StsCh';
                            }
                            else {
                                window.location = 'Purchase_Master_List.aspx?InsUpd=Error';
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
                messageText: "Do you want to delete this purchase",
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
        function DeleteByID(strCatId, cnclRsn, reasonmust) {
           
            var usrId = '<%=Session["USERID"]%>';
            // 0039
            var strOrgIdID = '<%=Session["ORGID"]%>';        
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';        
            //end

            if (strCatId != "" && usrId != '') {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "Purchase_Master_List.aspx/CancelPurchaseMstr",
                    data: '{strCatId: "' + strCatId + '",reasonmust: "' + reasonmust + '",usrId: "' + usrId + '",cnclRsn: "' + cnclRsn + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                    dataType: "json",
                    success: function (data) {
                        var SucessDetails = data.d;
                        $(window).scrollTop(0);
                        LoadEmployeeList(0);
                        if (SucessDetails == "successcncl") {
                            SuccessCancelation();
                        }
                            //0039
                        else if (SucessDetails == "AlreadyCancl") {
                            AlreadyCanceled();
                        }
                            //end
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
            if (ret == true) {
                var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    DeleteByID(strId, strCancelReason, strCancelMust);
                    $('#dialog_simple').modal('hide');
                }

                return false;

        }
        function SuccessConfirmationaddclose() {
            $noCon("#success-alert").html("Purchase inserted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            
            return false;
        }
       
        function AlreadyConfirmed() {
            $noCon("#divWarning").html("Purchase information already confirmed.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SuccessUpdation() {
            $noCon("#success-alert").html("Purchase updated successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            
            return false;
        }
            function SuccessConfirmation() {
                $noCon("#success-alert").html("Purchase Confirmed successfully.");
                $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                
                return false;
            }

        //0039
            function AlreadyCon() {
                $noCon("#divWarning").html("Purchase confirmed already.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                return false;
            }
        //end
            function SuccessUpdation() {
                $noCon("#success-alert").html("Purchase updated successfully.");
                $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                
                return false;
            }

            function SuccessCancelation() {
                $noCon("#success-alert").html("Purchase deleted successfully.");
                $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                
                return false;

            }

        //0039
            function AlreadyCanceled() {
                $noCon("#divWarning").html("Purchase Already deleted.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });

                return false;

            }
        //end
            function SuccessStatusChange() {
                $noCon("#success-alert").html("Purchase status changed successfully.");
                $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                });
                
                return false;
            }
            function CancelNotPossible() {
                ezBSAlert({
                    type: "alert",
                    messageText: "Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!",
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
    </script>
    
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
    
   
  


    <script>
        var $au = jQuery.noConflict();

        $au(function () {
            $au('#cphMain_ddlSupplier').selectToAutocomplete1Letter();
            //$au("#cphMain_ddlCustomer").focus();
        });
      
        </script>
          <div id="div1" class="table-responsive" runat="server" style="display:none;">
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
                                     <div id="divTitle" runat="server" style="display: none">
     PURCHASE REGISTER
      </div>






</asp:Content>

