<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Bank_Reconciliation.aspx.cs" Inherits="FMS_FMS_Master_fms_Bank_Reconciliation_fms_Bank_Reconciliation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
       <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
      <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              $("#divAccount" + "> input").focus();
              var ReopenSts = '<%= Session["SuccessMsg"] %>';
              if (ReopenSts != '') {
                  if (ReopenSts == 'successReCall') {
                      SuccessReoen();
                  }
                  else if (ReopenSts == 'failed') {
                      SuccessErrorReoen();
                  }
              }
              LoadEmployeeList();
          });


          function getdetails(href) {
              window.location = href;
              return false;
          }
          function SuccessReoen() {
              var ret = false;
              $noCon("#success-alert").html("Bank reconcilation recalled successfully.");
              $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

              });
              '<%Session["SuccessMsg"] = "' + null + '"; %>';
              return false;
          }
          function SuccessErrorReoen() {
              $noCon("#divWarning").html("Some error occured!.");
              $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
              });
              '<%Session["SuccessMsg"] = "' + null + '"; %>';
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
              
              if (ret == true) {
                  LoadEmployeeList();
              }
              return ret;
          }
          function CloseModal(x) {
              ezBSAlert({
                  type: "confirm",
                  messageText: "Are you sure you want to close?",
                  alertType: "info"
              }).done(function (e) {
                  if (e == true) {
                      document.getElementById("BttnTemp").click();
                      return false;
                  }
                  else {
                      return false;
                  }
              });
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
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Account Group</li>
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
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h1>bank reconciliation</h1>

                <div class="form-group fg5" id="divAccount">
                    <label for="email" class="fg2_la1">Voucher Type<span class="spn1"></span>:</label>
                    <asp:DropDownList ID="ddlAccount" class="form-control fg2_inp1 ddl" runat="server">
                        <asp:ListItem Text="All" Value="3" />
                        <asp:ListItem Text="Journal" Value="2" />
                        <asp:ListItem Text="Payment" Value="1" />
                        <asp:ListItem Text="Receipt" Value="0" />
                    </asp:DropDownList>
                </div>

                <div class="fg5">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <button type="button" class="btn-d" data-color="p" ></button>
                            <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" onkeypress="return DisableEnter(event)" Checked="false" class="form2" />
                        </span>
                        <p class="pz_s">Reconciled</p>
                    </label>
                </div>

                <div class="fg2">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                     <asp:Button ID="btnSearch"  runat="server" class="submit_ser" OnClientClick="return SearchValidation();"  /> 
                </div>

                <div class="clearfix"></div>
                <div class="devider"></div>

                <div id="diEmployeeList" class="table_box tb_scr">
                    <table id="datatable_fixed_column" class="display table-bordered" width="100%">
                        <thead class="thead1">
                            <tr class="SearchRow">
                              <%--  <th class=" col-md-1 td1">SL NO</th>--%>
                                <th class=" col-md-4 tr_l ">ACCOUNT
                             <input type="text" class="tb_inp_1 tb_in tr_l" placeholder="ACCOUNT" onkeydown="return DisableEnter(event)" /></th>
                                <th class=" col-md-4 tr_r">TOTAL AMOUNT
                             <input type="text" class=" tb_inp_1 tb_in tr_r" placeholder="TOTAL AMOUNT" onkeydown="return DisableEnter(event)" /></th>
                                <th class="col-md-3">Actions
                <p class="nbsp1">&nbsp;</p>
                                </th>
                                <th style="display:none"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td colspan="3" class="dataTables_empty">Loading details...</td>
                            </tr>
                        </tbody>
                    </table>
                </div>



                 <div class="eachform" style="width: 32%;margin-top: 2%;margin-left:4%;display:none">
                <h2 style="margin-top:1%;">Ledger </h2>
                <asp:DropDownList ID="ddlLedger" Height="30px" class="form-control ddl" runat="server" Style="margin-left: 25%;margin-bottom:2%;width: 64%;display:none">
                </asp:DropDownList>
               </div>
                             
                 <div style="width:100%;display:none">
                 <div class="eachform" style="width: 29%;margin-top: 2%;margin-left:1%;display:none">
                <h2 style=""margin-top:1%;">From Date*</h2>
               <input id="txtFromdate" runat="server" type="text"  style="height:30px;width:70%;margin-left: 8%;margin-bottom:2%;float: right;" onkeypress="return DisableEnter(event)"  class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />

                     <script>
                         $noCon('#cphMain_txtFromdate').datepicker({
                             autoclose: true,
                             format: 'dd-mm-yyyy',
                             timepicker: false
                         });
                     </script>
            </div>
                     <div class="eachform" style="width: 28.5%;margin-top: 2%;margin-left:4%;display:none">
                <h2 style="margin-top:1%;">To Date *</h2>
               <input id="txtTodate" runat="server" type="text"  style="height:31px;margin-bottom:2%;float: right;width: 72%;" onkeypress="return DisableEnter(event)"  class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />

            <script>
                $noCon('#cphMain_txtTodate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
       </script>
            </div>
                

               
                     </div>
           
    
            </div>
        </div>
    </div>

      <asp:Button ID="bttnsaveTemp"  style="display:none"   runat="server"  OnClick="bttnsave_Click"  text="PROCESS"    />
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


        
           
                                            <%--------------------------------View for error Reason--------------------------%>
          
       <%-- <div id="dialog_simple" title="Dialog Simple Title" style="display:none;width:">
                    <div class="widget-body no-padding" id="divCancelPopUp">


                  <div class="alert alert-danger fade in" id="lblErrMsgCancelReason" style="display: none; margin-top: 1%">

                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please select atleast one entry</label>
                </div>

                <div style="width: 100%; float: left; clear: both; margin-top: 5%">

                    <section style="width: 95%; margin-left: 5%; width:91%;min-height: 268px;height: 268px;overflow: auto;border: 1px solid burlywood;padding:1%">
                       
                    

                    </section>


                </div>
                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                      
                        
                    </div>
                   
                </div>
            </div>
                </div>  --%>

<%--    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog md_xl" role="document">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title mod1" id="H1"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>--%>
    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog md_xl" role="document">
            <div class="modal-content">
                <div class="modal-header ">
                    <h2 class="modal-title " id="exampleModalLabel"><i class="fa fa-business-time">TRANSACTIONS</i></h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div id="lblErrMsgCancelReason" class="al-box war">Please select atleast one entry</div>
                    <div id="divBank"></div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="bttnsave" runat="server" OnClientClick="return ChangeStatus();" class="btn btn-success" Text="RECONCILE" />
                    <button type="button" id="btnCnclRsn" onclick="return CloseModal()" class="btn btn-danger" >Cancel</button>
                    <button id="BttnTemp" type="button" style="display: none" class="btn btn-primary" data-dismiss="modal"></button>

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
               var LedgerId = 0;
               var AccountId = 0;
               var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
               var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;

               var Costcenterval = document.getElementById("<%=ddlAccount.ClientID%>").value;
               var Ledgval = document.getElementById("<%=ddlLedger.ClientID%>").value;

               // if (document.getElementById("<%=ddlAccount.ClientID%>").value != "--SELECT ACCOUNT--") {
               AccountId = document.getElementById("<%=ddlAccount.ClientID%>").value;
               //  }
               if (document.getElementById("<%=ddlLedger.ClientID%>").value != "--SELECT LEDGER--") {
                   LedgerId = document.getElementById("<%=ddlLedger.ClientID%>").value;
               }
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

                       'bProcessing': true,
                       'bServerSide': true,
                       'sAjaxSource': 'data.ashx',
                       "bDestroy": true,
                       "autoWidth": true,
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
                           aoData.push({ "name": "ACCOUNTID", "value": AccountId });
                           aoData.push({ "name": "LEDGERID", "value": LedgerId });
                           aoData.push({ "name": "FROMDT", "value": from });
                           aoData.push({ "name": "TODAT", "value": toDt });
                           aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                       },
                       "columnDefs": [
                         {
                             "targets": [0],
                             "className": "tr_l",
                             "visible": true
                         },
           {
               "targets": [1],
               "className": "tr_r",
               "visible": true
           },
             {
                 "targets": [3],
                 "visible": false
             },
                   {
                       "targets": 1,
                       "orderData": 2,
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
                       'bProcessing': true,
                       'bServerSide': true,
                       'sAjaxSource': 'data.ashx',
                       "bDestroy": true,
                       "autoWidth": true,
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
                           aoData.push({ "name": "ACCOUNTID", "value": AccountId });
                           aoData.push({ "name": "LEDGERID", "value": LedgerId });
                           aoData.push({ "name": "FROMDT", "value": from });
                           aoData.push({ "name": "TODAT", "value": toDt });
                           aoData.push({ "name": "CNCL_STS", "value": CnclSts });
                       },
                       "columnDefs": [
      {
          "targets": [0],
          "className": "tr_l",
          "visible": true
      },
           {
               "targets": [1],
               "className": "tr_r",
               "visible": true,
               "orderData": 3
           },
              {
                  "targets": [3],
                  "visible": false
              },
              {
                  "targets": 1,
                  "orderData": 2,
              },
                       ],


                   });
                   $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                       otable
                           .column($NoConfi(this).parent().index() + ':visible')
                           .search(this.value)
                           .draw();

                   });
               }
           }
    </script>
  
    <script>
        function ChangeStatus() {
           
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to reconcile this entry?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                     
                      
                        if (Validate() == true) {
                    
                            document.getElementById("<%=bttnsaveTemp.ClientID%>").click();
                              return false;

                          }
                      
                    }
                });
                return false;
            
        }
        function OpenReconView(StrId) {
            //document.getElementById("<%=HiddenVouchrTyp.ClientID%>").value = vouchertyp;
            var corpid = '<%= Session["CORPOFFICEID"] %>';
            var orgid = '<%= Session["ORGID"] %>';
            var userid = '<%= Session["USERID"] %>';
            $noCon.ajax({
                type: "POST",
                url: "fms_Bank_Reconciliation.aspx/AccntDetailsById",
                data: '{intAccntId:"' + StrId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d[0] != "0") {
                        document.getElementById("<%=HiddenRowCount.ClientID%>").value = response.d[0]
                        document.getElementById("divBank").innerHTML = response.d[1];
                        $('#dialog_simple').modal('show');
                    }
                },
                failure: function (response) {
                }
            });
            return false;
        }
        function Recall(StrId) {
            var strOrgIdID = '<%=Session["ORGID"]%>';
        var strCorpID = '<%=Session["CORPOFFICEID"]%>';
        if (StrId != "") {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you sure want to recall?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Details = PageMethods.Reopen_Reconciled(StrId, strOrgIdID, strCorpID, function (response) {
                        var SucessDetails = response;
                        if (SucessDetails == "successReCall") {

                            window.location = 'fms_Bank_Reconciliation.aspx';
                            return false;

                        }
                        else {
                            window.location = 'fms_Bank_Reconciliation.aspx';
                            return false;

                        }
                    });
                }
            });
            return false;
        }
        return false;
    }

        function Validate() {
           // $noCon('#dialog_simple').dialog('close');
            var ret = true;
            var flag = 0;
            document.getElementById("<%=HiddenVouchers.ClientID%>").value = "";
            document.getElementById("lblErrMsgCancelReason").style.display = "none";
            var Varcount = document.getElementById("<%=HiddenRowCount.ClientID%>").value;
            if (Varcount == "0") {
                document.getElementById("lblErrMsgCancelReason").innerHTML = " No data available";
                document.getElementById("lblErrMsgCancelReason").style.display = "";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                ret = false;
            }
            else {
                $('#TableVouchers').find('input[type="checkbox"]:checked').each(function () {
                    var row = $(this);
                    flag++;
                  
                    //this is the current checkbox
                    //  row.val();
                  
                    if (document.getElementById("<%=HiddenVouchers.ClientID%>").value == "") {
                        document.getElementById("<%=HiddenVouchers.ClientID%>").value = row.val();
                    }
                    else {
                        document.getElementById("<%=HiddenVouchers.ClientID%>").value = document.getElementById("<%=HiddenVouchers.ClientID%>").value + "," + row.val();
                    }

                });


            }
          
            if (flag == 0) {
               
                document.getElementById("lblErrMsgCancelReason").innerHTML = "Please select atleast one entry";
                document.getElementById("lblErrMsgCancelReason").style.display = "";
                $("div.war").fadeIn(200).delay(500).fadeOut(400);
                ret = false;
            }
          
         
            return ret;
        }
    
       
        function SuccessMsg() {
            $noCon("#success-alert").html("Reconciled successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           
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

</asp:Content>

