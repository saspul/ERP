﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Profit_and_Loss_account.aspx.cs" Inherits="FMS_FMS_Master_fms_Profit_and_Loss_account_fms_Profit_and_Loss_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
              LoadEmpList(x);
              //loadTableDesg();
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
                    "bSort": false,
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
                $NoConfi("#datatable_fixed_column"+ x+" thead th input[type=text]").on('keyup change', function () {

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
           
              if (toDate == "") {
                  document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                
                  $noCon(window).scrollTop(0);
                  ret = false;
              }
              return ret;
          }
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
    <asp:HiddenField ID="HiddenEnableModify" runat="server" />
    <asp:HiddenField ID="HiddenVouchrTyp" runat="server" />
    <asp:HiddenField ID="HiddenRowCount" runat="server" />
    <asp:HiddenField ID="HiddenVouchers" runat="server" />
    <asp:HiddenField ID="HiddenType" runat="server" />
    <asp:HiddenField ID="HiddenCount" runat="server" />
    <asp:HiddenField ID="HiddenDecimalCnt" runat="server" />
    <asp:HiddenField ID="HiddenAcntGrpId" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="hiddenpdfpath" runat="server" />
    <asp:HiddenField ID="HiddenFieldSearchDate" runat="server" />
    <asp:HiddenField ID="HiddenSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldShowZero" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenStrID" runat="server" />
    <asp:HiddenField ID="HiddenLedgerSts" runat="server" />
    <asp:HiddenField ID="HiddenPrevId" runat="server" />
    <asp:HiddenField ID="HiddenEndDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldNewToDate" runat="server" />
     <asp:HiddenField ID="HiddenStrName" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Profit & Loss Account</li>
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
                    <asp:Label ID="lblEntry" runat="server">PROFIT & LOSS ACCOUNT</asp:Label>
                </h2>

                <div class="form-group fg2">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1">*</span> </label>
                    <div id="datepicker2" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtFromDate" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var StartDateVal = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
                        var EndDateVal = document.getElementById("<%=HiddenEndDate.ClientID%>").value;

                        $noCon('#datepicker2').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            //startDate: StartDateVal,
                            //endDate: EndDateVal
                        });
                    </script>

                </div>

                <div class="form-group fg2">
                    <label for="pwd" class="fg2_la1">To Date:<span class="spn1">*</span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" placeholder="dd-mm-yyyy" maxlength="50" />
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
                            //endDate: EndDateVal
                        });
                    </script>

                </div>
                <div class="form-group fg5">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
                            <button type="button" class="btn-d" data-color="p"></button>
                        </span>
                        <p class="pz_s">Show zero balance</p>
                    </label>
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
        PROFIT AND LOSS ACCOUNT
    </div>

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
                        <h3><a id="divBackLink" runat="server" href="#">11020-BUSINESS UNITS</a></h3>
                    </div>
                    <div id="divBank"></div>

                </div>
                <div class="modal-footer">
                    <button id="ButtnDrlldownClick" onclick="return PrintClickDrillDwn('pdf');" class="pnt_mod"><i class="fa fa-print"></i></button>
                <button id="Button1" onclick="return PrintClickDrillDwn('csv');" title="CSV" class="pnt_mod" style ="background-color: #2a57ab;"><i class="fa fa-file-excel-o"></i></button>

                </div>
            </div>
        </div>
    </div>


    <script>
        function ChangeStatus() {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reconcile this entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {


                    if (Validate() == true) {
                        alert();

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
            var strName = document.getElementById("<%=HiddenStrName.ClientID%>").value;
            var ShowZero = document.getElementById("<%=HiddenFieldShowZero.ClientID%>").value;
            //var datefrom = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
            var datefrom = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var dateto = document.getElementById("<%=HiddenFieldSearchDate.ClientID%>").value;

            $noCon.ajax({
                type: "POST",
                async: false,
                url: "fms_Profit_and_Loss_account.aspx/TrailBalance_List_Print",
                data: '{ShowZero:"' + ShowZero + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",datefrom:"' + datefrom + '",dateto:"' + dateto + '",strName:"' + strName + '",strPrintMode:"' + strPrintMode + '"  }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d != "") {
                        window.open(response.d, '_blank');
                    }
                }
            });
            return false;
        }
        function PrintClickDrillDwn(PrintMode) {
            var strPrintMode = PrintMode;
            var StrId = document.getElementById("<%=HiddenStrID.ClientID%>").value;
            var sts = document.getElementById("<%=HiddenSts.ClientID%>").value;
            var ledgrSts = document.getElementById("<%=HiddenLedgerSts.ClientID%>").value;
            var ShowZero = document.getElementById("<%=HiddenFieldShowZero.ClientID%>").value;
            var PrevId = document.getElementById("<%=HiddenPrevId.ClientID%>").value;
            var datefrom = document.getElementById("<%=txtFromDate.ClientID%>").value;
        //    var datefrom = document.getElementById("<%=HiddenStartDate.ClientID%>").value;
            var dateto = document.getElementById("<%=HiddenFieldSearchDate.ClientID%>").value;
            var strName = document.getElementById("<%=HiddenStrName.ClientID%>").value;
            var tableid = "";
            if (datefrom != "" && dateto != "" ) {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                var TypSts = 0;
                var aantId = "";
                var strprvId = "";
              
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Profit_and_Loss_account.aspx/TrailBalance_Lists_ById_Print",
                    data: '{intAccntId:"' + StrId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",intdateto:"' + dateto + '" ,TypSts:"' + TypSts + '",ledgrSts:"' + ledgrSts + '",ShowZero:"' + ShowZero + '" ,strName:"' + strName + '",strPrintMode:"' + strPrintMode + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d != "") {
                            window.open(response.d, '_blank');
                        }
                    },
                    failure: function (response) {

                    }
                });
            }
        }
        function OpenReconView(StrId, sts, linksts, acnttid, PrevId, strName, lblsts, ledgrSts) {

            document.getElementById("<%=HiddenType.ClientID%>").value = "0";

            document.getElementById("<%=HiddenStrID.ClientID%>").value = StrId;
            document.getElementById("<%=HiddenLedgerSts.ClientID%>").value = ledgrSts;
            document.getElementById("<%=HiddenSts.ClientID%>").value = sts;
            document.getElementById("<%=HiddenPrevId.ClientID%>").value = PrevId;
            document.getElementById("<%=HiddenStrName.ClientID%>").value = strName;

            
            var ShowZero = document.getElementById("<%=HiddenFieldShowZero.ClientID%>").value;
            var datefrom = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var dateto = document.getElementById("<%=HiddenFieldSearchDate.ClientID%>").value;
            var tableid = "";
            if (datefrom != "" && dateto != "" ) {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                var orgid = '<%= Session["ORGID"] %>';
                var userid = '<%= Session["USERID"] %>';
                var TypSts = 0;
                var aantId = "";
                var strprvId = "";
                if (document.getElementById("<%=HiddenAcntGrpId.ClientID%>").value != "") {
                    if (sts == 1)
                        document.getElementById("<%=HiddenAcntGrpId.ClientID%>").value = document.getElementById("txtprvId" + acnttid).value;
                }
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Profit_and_Loss_account.aspx/DecriptId_ById",
                    data: '{intAccntId:"' + StrId + '",intstrprvId:"' + PrevId + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d[0] != "0") {
                            aantId = response.d[0];
                        }

                        if (response.d[1] != "0") {
                            strprvId = response.d[1];
                        }
                    },
                    failure: function (response) {
                    }
                });
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Profit_and_Loss_account.aspx/TrailBalance_Lists_ById",
                    data: '{intAccntId:"' + StrId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",intdateto:"' + dateto + '" ,TypSts:"' + TypSts + '",ledgrSts:"' + ledgrSts + '",ShowZero:"' + ShowZero + '" ,strName:"' + strName + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d[4] != "") {

                            document.getElementById("<%=hiddenpdfpath.ClientID%>").value = response.d[4];
                        }
                        if (response.d[0] != "0") {
                            tableid = response.d[2];
                            document.getElementById("<%=HiddenRowCount.ClientID%>").value = response.d[0]
                            document.getElementById("divBank").innerHTML = response.d[1];
                            document.getElementById("<%=divPrintCaptionDrilDown.ClientID%>").innerHTML = response.d[3];
                            // document.getElementById("<%=divPrintReportDrilDown.ClientID%>").innerHTML = response.d[4];
                            $('#dialog_simple').modal('show');
                            sts = 1;

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

                            if (linksts == 0) {
                                if (lblsts == 0) {
                                    document.getElementById("<%=divBackLink.ClientID%>").innerHTML += '<label id=\"lbl_' + strprvId + '\">>></label> <a  id=\"link_' + strprvId + '\"  target=\"_blank\" onclick=\"return  OpenReconView(\'' + PrevId + '\',0,1,' + aantId + ',\'' + PrevId + '\',\'QQQQ\',0,0); \" style=\"cursor: pointer;\" title=\"Back\" > ' + strName + ' </a>';
                                }
                                else {
                                    document.getElementById("<%=divBackLink.ClientID%>").innerHTML = "";
                                    document.getElementById("<%=divBackLink.ClientID%>").innerHTML += '<label id=\"lbl_' + strprvId + '00000\"></label> <a  id=\"link_' + strprvId + '0000\"  target=\"_blank\" onclick=\"return  OpenReconView(\'' + PrevId + '\',0,1,' + aantId + ',\'' + PrevId + '\',\'QQQQ\',1,0); \" style=\"cursor: pointer;\" title=\"Back\" > ' + strName + ' </a>';
                                }
                                document.getElementById("<%=HiddenAcntGrpId.ClientID%>").value = StrId;
                            }
                            else {
                                if (lblsts == 1) {
                                    $('#dialog_simple').modal('hide');
                                    document.getElementById("<%=divBackLink.ClientID%>").innerHTML = "";
                                }
                                else {
                                    $('#lbl_' + strprvId).remove();
                                    $('#link_' + strprvId).remove();
                                }
                            }
                        }
                    },
                    failure: function (response) {

                    }
                });
                LoadEmpList(tableid);
            }
            return false;

        }

        function OpenReconViewNet(StrId, strName, ledgrSts) {

            document.getElementById("<%=HiddenStrID.ClientID%>").value = StrId;
            document.getElementById("<%=HiddenLedgerSts.ClientID%>").value = ledgrSts;
            var ShowZero = document.getElementById("<%=HiddenFieldShowZero.ClientID%>").value;
            document.getElementById("<%=HiddenType.ClientID%>").value = "1";
            var datefrom = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var dateto = document.getElementById("<%=HiddenFieldSearchDate.ClientID%>").value;
            document.getElementById("<%=HiddenStrName.ClientID%>").value = strName;
            var tableid = "";
            if (datefrom != "" && dateto != "") {
                var corpid = '<%= Session["CORPOFFICEID"] %>';
                           var orgid = '<%= Session["ORGID"] %>';
                           var userid = '<%= Session["USERID"] %>';
                           var TypSts = 1;
                           $noCon.ajax({
                               type: "POST",
                               async: false,
                               url: "fms_Profit_and_Loss_account.aspx/TrailBalance_Lists_ById",
                               data: '{intAccntId:"' + StrId + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",intdatefrom:"' + datefrom + '",intdateto:"' + dateto + '",TypSts:"' + TypSts + '" ,ledgrSts:"' + ledgrSts + '",ShowZero:"' + ShowZero + '" ,strName:"' + strName + '" }',
                               contentType: "application/json; charset=utf-8",
                               dataType: "json",
                               success: function (response) {
                                   if (response.d[4] != "") {

                                       document.getElementById("<%=hiddenpdfpath.ClientID%>").value = response.d[4];
                            }
                            if (response.d[0] != "0") {

                                tableid = response.d[2];
                                document.getElementById("<%=HiddenRowCount.ClientID%>").value = response.d[0]
                                document.getElementById("divBank").innerHTML = response.d[1];

                                document.getElementById("<%=divPrintCaptionDrilDown.ClientID%>").innerHTML = response.d[3];
                                document.getElementById("<%=divPrintReportDrilDown.ClientID%>").innerHTML = response.d[4];




                                $('#dialog_simple').modal('show');
                                document.getElementById("<%=divBackLink.ClientID%>").innerHTML = '<a  target=\"_blank\" onclick=\"ReturnBack(); \" style=\"cursor: pointer;\" title=\"Back\" >' + strName + ' </a>';

                                document.getElementById("<%=HiddenAcntGrpId.ClientID%>").value = StrId;
                                //document.getElementById("<%=HiddenCount.ClientID%>").value = "0";

                            }




                        },
                        failure: function (response) {

                        }


                    });

                    LoadEmpList(tableid);
                           //  loadTableDesg();
                }




                return false;

            }
            function ReturnBack() {
                $('#dialog_simple').modal('hide');
                //   document.getElementById("<%=HiddenCount.ClientID%>").value = "0";


        }


        function Validate() {
            // $('#dialog_simple').modal('hide');
            var ret = true;
            var flag = 0;
            document.getElementById("<%=HiddenVouchers.ClientID%>").value = "";
                            document.getElementById("divErrMsgCnclRsn").style.display = "none";
                            var Varcount = document.getElementById("<%=HiddenRowCount.ClientID%>").value;
            if (Varcount == "0") {
                document.getElementById("lblErrMsgCancelReason").innerHTML = " No data available";
                document.getElementById("divErrMsgCnclRsn").style.display = "";
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
                document.getElementById("divErrMsgCnclRsn").style.display = "";
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

</asp:Content>


