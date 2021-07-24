<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Ledger_Statement.aspx.cs" Inherits="FMS_FMS_Reports_fms_Ledger_Statement_fms_Ledger_Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>

    <link href="/JavaScript/multiselect/select2/select2.min.css" rel="stylesheet" />
    <script src="/JavaScript/multiselect/select2/select2.full.min.js"></script>

    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>

    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>

        var $noCon = jQuery.noConflict();

        $noCon(function () {

            $noCon("#cphMain_ddlLedger").select2({
            }).on("select2:unselecting", function (e) {
                if ($noCon(e.params.args.originalEvent.currentTarget).hasClass("select2-results__option")) {
                    e.preventDefault();
                    $noCon(".js-example-tags").select2().trigger("close");
                }
            });
            //$noCon(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
            //    $noCon(this).val($noCon(this).val().replace(/[^\d].+/, ""));
            //    if ((event.which < 48 || event.which > 57)) {
            //        event.preventDefault();
            //    }
            //});
        });

        $noCon(window).load(function () {
            LoadEmpList();
            SearchOPtion();

        });

        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();

        function LoadEmpList() {

            var orgID = '<%= Session["ORGID"] %>';
            var corptID = document.getElementById("<%=hiddenCorpId.ClientID%>").value;

            var responsiveHelper_datatable_fixed_column = undefined;

            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                "bSort": false,
                "bDestroy": true,

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
                }

            });
            // Apply the filter
            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });
            /* END COLUMN FILTER */
        }

        function SearchValidation() {
            var ret = true;

            var FrmDate = document.getElementById("<%=txtFromdate.ClientID%>").value.trim();
            var ToDate = document.getElementById("<%=txtTodate.ClientID%>").value.trim();
            var TodayDate = document.getElementById("<%=hiddenDate.ClientID%>").value.trim();

            var datepickerDate = document.getElementById("<%=hiddenDate.ClientID%>").value.trim();
            var arrDatePickerDate = datepickerDate.split("-");
            var Today = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateFrmDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

            var datepickerDate = document.getElementById("<%=txtTodate.ClientID%>").value;
            var arrDatePickerDate = datepickerDate.split("-");
            var dateToDt = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);
           

            document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";

            //NEW
            if (document.getElementById("cphMain_cbxExtngSplr").checked == false) {
                var LedgerRangeFrom = document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").value.trim();
                var LedgerRangeTo = document.getElementById("<%=txtLedgerRangeTo.ClientID%>").value.trim();

                var H1RangeFrom = document.getElementById("<%=txtH1RangeFrom.ClientID%>").value.trim();
                var H1RangeTo = document.getElementById("<%=txtH1RangeTo.ClientID%>").value.trim();

                var H2RangeFrom = document.getElementById("<%=txtH2RangeFrom.ClientID%>").value.trim();
                var H2RangeTo = document.getElementById("<%=txtH2RangeTo.ClientID%>").value.trim();

                var CCCodeRangeFrom = document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").value.trim();
                var CCCodeRangeTo = document.getElementById("<%=txtCCCodeRangeTo.ClientID%>").value.trim();

                document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtLedgerRangeTo.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtH1RangeFrom.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtH1RangeTo.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtH2RangeFrom.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtH2RangeTo.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtCCCodeRangeTo.ClientID%>").style.borderColor = "";


                if (LedgerRangeFrom != "" && LedgerRangeFrom != "") {
                    if (parseFloat(LedgerRangeFrom) > parseFloat(LedgerRangeTo)) {
                        $noCon("#divWarning").html("Sorry, From range should not be greater than To range !");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").focus();
                        ret = false;
                    }
                }
                if (H1RangeFrom != "" && H1RangeTo != "") {
                    if (parseFloat(H1RangeFrom) > parseFloat(H1RangeTo)) {
                        $noCon("#divWarning").html("Sorry, From range should not be greater than To range !");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("<%=txtH1RangeFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtH1RangeFrom.ClientID%>").focus();
                        ret = false;
                    }
                }
                if (H2RangeFrom != "" && H2RangeTo != "") {
                    if (parseFloat(H2RangeFrom) > parseFloat(H2RangeTo)) {
                        $noCon("#divWarning").html("Sorry, From range should not be greater than To range !");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("<%=txtH2RangeFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtH2RangeFrom.ClientID%>").focus();
                        ret = false;
                    }
                }
                if (CCCodeRangeFrom != "" && CCCodeRangeTo != "") {
                    if (parseFloat(CCCodeRangeFrom) > parseFloat(CCCodeRangeTo)) {
                        $noCon("#divWarning").html("Sorry, From range should not be greater than To range !");
                        $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                        });
                        document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").focus();
                        ret = false;
                    }
                }

            }
            if (dateFrmDt > dateToDt) {
                $noCon("#divWarning").html("Sorry, From date should not be greater than To date !");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromdate.ClientID%>").focus();
                ret = false;
            }

            if (ToDate == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted field below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTodate.ClientID%>").focus();
                ret = false;
            }

            if (FrmDate == "") {
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted field below.");
                $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromdate.ClientID%>").focus();
                ret = false;
            }


            var ddlCntryIdvalues;
            var sel = "", selname = "";

            if (ret == true) {
                $("#cphMain_ddlLedger option:selected").each(function () {
                    var $this = $(this);
                    if ($this.length) {
                        var selVal = $this.val();
                        var selText = $this.text();
                        sel = sel + selVal + ",";
                        selname = selname + selText + ",";
                        //alert(sel);
                    }
                });
            }

            document.getElementById("<%=hiddenLedgerIds.ClientID%>").value = sel;
            document.getElementById("<%=hiddenLedgerNames.ClientID%>").value = selname;
            return ret;
        }


        $(document).ready(function () {

            var LedgerId = document.getElementById("<%=hiddenLedgerIds.ClientID%>").value;
            if (LedgerId != "") {

                var totalString = LedgerId;

                eachString = totalString.split(',');
                var newVar = new Array();
                for (count = 0; count < eachString.length; count++) {
                    if (eachString[count] != "") {
                        newVar.push(eachString[count]);
                    }
                }
                //alert(newVar);
                $("#cphMain_ddlLedger").val(newVar).trigger("change");
            }
        });
      
        function PrintClick(PrintMode) {

            var strPrintMode = PrintMode;

            var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
            var OrgId = '<%=Session["ORGID"]%>';

            var AllLedgerSts = 0;
            if (document.getElementById("<%=cbxExtngSplr.ClientID%>").checked == true) {
                AllLedgerSts = 1;
            }

            var AccntGroupId = "", AccntGroup = "", LedgerRangeFrom = "", LedgerRangeTo = "", H1RangeFrom = "", H1RangeTo = "", H2RangeFrom = "", H2RangeTo = "", CCCodeRangeFrom = "", CCCodeRangeTo = "";
            if (document.getElementById("<%=ddlParentGroup.ClientID%>").value != "--SELECT GROUP--" && document.getElementById("<%=ddlParentGroup.ClientID%>").value != "0" && document.getElementById("<%=ddlParentGroup.ClientID%>").value != "") {
                AccntGroupId = document.getElementById("<%=ddlParentGroup.ClientID%>").value;
                AccntGroup = $("#cphMain_ddlParentGroup option:selected").html();
            }

            if (document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").value != "--SELECT FROM--" && document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").value != "0" && document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").value != "") {
                LedgerRangeFrom = document.getElementById("<%=txtLedgerRangeFrom.ClientID%>").value;
            }
            if (document.getElementById("<%=txtLedgerRangeTo.ClientID%>").value != "--SELECT TO--" && document.getElementById("<%=txtLedgerRangeTo.ClientID%>").value != "0" && document.getElementById("<%=txtLedgerRangeTo.ClientID%>").value != "") {
                LedgerRangeTo = document.getElementById("<%=txtLedgerRangeTo.ClientID%>").value;
            }

            if (document.getElementById("<%=txtH1RangeFrom.ClientID%>").value != "--SELECT FROM--" && document.getElementById("<%=txtH1RangeFrom.ClientID%>").value != "0" && document.getElementById("<%=txtH1RangeFrom.ClientID%>").value != "") {
                H1RangeFrom = document.getElementById("<%=txtH1RangeFrom.ClientID%>").value;
            }
            if (document.getElementById("<%=txtH1RangeTo.ClientID%>").value != "--SELECT TO--" && document.getElementById("<%=txtH1RangeTo.ClientID%>").value != "0" && document.getElementById("<%=txtH1RangeTo.ClientID%>").value != "") {
                H1RangeTo = document.getElementById("<%=txtH1RangeTo.ClientID%>").value;
            }

            if (document.getElementById("<%=txtH2RangeFrom.ClientID%>").value != "--SELECT FROM--" && document.getElementById("<%=txtH2RangeFrom.ClientID%>").value != "0" && document.getElementById("<%=txtH2RangeFrom.ClientID%>").value != "") {
                H2RangeFrom = document.getElementById("<%=txtH2RangeFrom.ClientID%>").value;
            }
            if (document.getElementById("<%=txtH2RangeTo.ClientID%>").value != "--SELECT TO--" && document.getElementById("<%=txtH2RangeTo.ClientID%>").value != "0" && document.getElementById("<%=txtH2RangeTo.ClientID%>").value != "") {
                H2RangeTo = document.getElementById("<%=txtH2RangeTo.ClientID%>").value;
            }

            if (document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").value != "--SELECT FROM--" && document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").value != "0" && document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").value != "") {
                CCCodeRangeFrom = document.getElementById("<%=txtCCCodeRangeFrom.ClientID%>").value;
            }
            if (document.getElementById("<%=txtCCCodeRangeTo.ClientID%>").value != "--SELECT TO--" && document.getElementById("<%=txtCCCodeRangeTo.ClientID%>").value != "0" && document.getElementById("<%=txtCCCodeRangeTo.ClientID%>").value != "") {
                CCCodeRangeTo = document.getElementById("<%=txtCCCodeRangeTo.ClientID%>").value;
            }

            var datefrom = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var dateto = document.getElementById("<%=txtTodate.ClientID%>").value;

            var Mode = 0;
            if (document.getElementById("<%=radioDetail.ClientID%>").checked == true) {
                Mode = 0;
            }
            if (document.getElementById("<%=radioSummary.ClientID%>").checked == true) {
                Mode = 1;
            }

            var SubLedgerSts = 0;
            if (document.getElementById("<%=cbxSubLedgerSts.ClientID%>").checked == true) {
                SubLedgerSts = 1;
            }

            var LedgerIds = document.getElementById("<%=hiddenLedgerIds.ClientID%>").value;

            var sel = "";
            var selname = "";
            $("#cphMain_ddlLedger option:selected").each(function () {
                var $this = $(this);
                if ($this.length) {
                    var selVal = $this.val();
                    var selText = $this.text();
                    sel = sel + selVal + ",";
                    selname = selname + selText + ",";
                    //alert(sel);
                }
            });

            if ((selname.indexOf('"') > -1)) {
                selname = selname.replace(/"/g, '‡');
            }
            if ((selname.indexOf("'") > -1)) {
                selname = selname.replace(/'/g, '¦');
            }

            $noCon.ajax({
                type: "POST",
                async: false,
                url: "fms_Ledger_Statement.aspx/List_Print",
                data: '{CorpId:"' + CorpId + '",OrgId:"' + OrgId + '",AllLedgerSts:"' + AllLedgerSts + '",AccntGroupId:"' + AccntGroupId + '",AccntGroup:"' + AccntGroup + '",LedgerRangeFrom:"' + LedgerRangeFrom + '",LedgerRangeTo:"' + LedgerRangeTo + '",H1RangeFrom:"' + H1RangeFrom + '",H1RangeTo:"' + H1RangeTo + '",H2RangeFrom:"' + H2RangeFrom + '",H2RangeTo:"' + H2RangeTo + '",CCCodeRangeFrom:"' + CCCodeRangeFrom + '",CCCodeRangeTo:"' + CCCodeRangeTo + '",datefrom:"' + datefrom + '",dateto:"' + dateto + '",LedgerIds:"' + LedgerIds + '",Ledgers:"' + selname + '",Mode:"' + Mode + '",SubLedgerSts:"' + SubLedgerSts + '",strPrintMode:"' + strPrintMode + '"  }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d != "") {
                        window.open(response.d, '_blank');
                    }
                },
                failure: function (response) {
                    alert("error");
                }
            });
            return false;
        }

        function DivDisplay(Row, LdgrId,VochrAcntId,VochrId) {

            var Id = String(LdgrId);
            Id = Id + Row;
            //alert(Id);
            if ($("#divAsPerDtls" + Id).hasClass('collapse in') == true) {
                $("#divAsPerDtls" + Id).hide();
                $("#divAsPerDtls" + Id).removeClass("collapse in");
                $("#divAsPerDtls" + Id).addClass("collapse");
            }
            else {

                var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
                var OrgId = '<%= Session["ORGID"] %>';

                var FrmDate = document.getElementById("cphMain_txtFromdate").value;
                var ToDate = document.getElementById("cphMain_txtTodate").value;

                if (LdgrId != "") {
                    $noCon.ajax({
                        type: "POST",
                        async: false,
                        url: "fms_Ledger_Statement.aspx/LoadAsPerDetails",
                        data: '{OrgId:"' + OrgId + '" ,CorpId:"' + CorpId + '",LdgrId:"' + LdgrId + '",Row:"' + Row + '",FrmDate:"' + FrmDate + '",ToDate:"' + ToDate + '",VochrAcntId:"' + VochrAcntId + '",VochrId:"' + VochrId + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            if (response.d != "") {
                                document.getElementById("divAsPerDtls" + Id).innerHTML = response.d;
                                //alert(response.d);
                                $("#divAsPerDtls" + Id).show();
                                $("#divAsPerDtls" + Id).removeClass("collapse");
                                $("#divAsPerDtls" + Id).addClass("collapse in");

                                return false;
                            }
                        },
                        failure: function (response) {

                        }
                    });
                }
                return false;


            }
        }

        function SearchOPtion() {

            if (document.getElementById("cphMain_cbxExtngSplr").checked == true) {

                document.getElementById("cphMain_ddlParentGroup").disabled = true;
                $("div#divddlAccGrp input.ui-autocomplete-input").attr("disabled", true);
                $au('input.grp').attr('disabled', true);
                document.getElementById("cphMain_ddlParentGroup").value = "--SELECT GROUP--";
                $au('input.grp').val("--SELECT GROUP--");
                document.getElementById("cphMain_txtLedgerRangeTo").disabled = true;
                document.getElementById("cphMain_txtLedgerRangeFrom").disabled = true;
                document.getElementById("cphMain_txtH1RangeTo").disabled = true;
                document.getElementById("cphMain_txtH1RangeFrom").disabled = true;
                document.getElementById("cphMain_txtH2RangeTo").disabled = true;
                document.getElementById("cphMain_txtH2RangeFrom").disabled = true;
                document.getElementById("cphMain_txtCCCodeRangeTo").disabled = true;
                document.getElementById("cphMain_txtCCCodeRangeFrom").disabled = true;
                document.getElementById("cphMain_ddlLedger").disabled = true;
                $au('#cphMain_ddlLedger').val("");
                document.getElementById("cphMain_cbxExtngSplr").disabled = false;
                document.getElementById("cphMain_cbxSubLedgerSts").disabled = true;

                $au('input.codfrm').attr('disabled', true);
                $au('input.codfrm').val("--SELECT FROM--");
                $au('input.codto').attr('disabled', true);
                $au('input.codto').val("--SELECT TO--");
            }
            else if (document.getElementById("cphMain_cbxSubLedgerSts").checked == true) {

                $("div#divddlAccGrp input.ui-autocomplete-input").attr("disabled", false);
                document.getElementById("cphMain_ddlParentGroup").disabled = false;
                document.getElementById("cphMain_txtLedgerRangeTo").disabled = true;
                document.getElementById("cphMain_txtLedgerRangeFrom").disabled = true;
                document.getElementById("cphMain_txtH1RangeTo").disabled = true;
                document.getElementById("cphMain_txtH1RangeFrom").disabled = true;
                document.getElementById("cphMain_txtH2RangeTo").disabled = true;
                document.getElementById("cphMain_txtH2RangeFrom").disabled = true;
                document.getElementById("cphMain_txtCCCodeRangeTo").disabled = true;
                document.getElementById("cphMain_txtCCCodeRangeFrom").disabled = true;
                document.getElementById("cphMain_cbxExtngSplr").disabled = true;
                document.getElementById("cphMain_cbxExtngSplr").checked = false;
                document.getElementById("cphMain_ddlLedger").disabled = false;

                $au('input.codfrm').attr('disabled', true);
                $au('input.codfrm').val("--SELECT FROM--");
                $au('input.codto').attr('disabled', true);
                $au('input.codto').val("--SELECT TO--");
            }
            else {
                $au('input.grp').attr('disabled', false);
                $("div#divddlAccGrp input.ui-autocomplete-input").attr("disabled", false);
                if (document.getElementById("<%=HiddenCodeFormate.ClientID%>").value == "1" && document.getElementById("<%=HiddenCodeStatus.ClientID%>").value == "1") {
                    document.getElementById("cphMain_txtLedgerRangeTo").disabled = false;
                    document.getElementById("cphMain_txtLedgerRangeFrom").disabled = false;
                    document.getElementById("cphMain_txtH1RangeTo").disabled = false;
                    document.getElementById("cphMain_txtH1RangeFrom").disabled = false;
                    document.getElementById("cphMain_txtH2RangeTo").disabled = false;
                    document.getElementById("cphMain_txtH2RangeFrom").disabled = false;
                    document.getElementById("cphMain_txtCCCodeRangeTo").disabled = false;
                    document.getElementById("cphMain_txtCCCodeRangeFrom").disabled = false;

                    $au('input.codfrm').attr('disabled', false);
                    $au('input.codto').attr('disabled', false);
                }
                document.getElementById("cphMain_ddlLedger").disabled = false;
                document.getElementById("cphMain_cbxExtngSplr").disabled = false;
                document.getElementById("cphMain_cbxSubLedgerSts").disabled = false;
            }
        }

        function CostCentreDisplay(VoucherId) {

            var dateTo = document.getElementById("<%=txtTodate.ClientID%>").value;
            var datefrom = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var corpid = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
            var orgid = '<%= Session["ORGID"] %>';
            var userid = '<%= Session["USERID"] %>';
            if (VoucherId != "") {
                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Ledger_Statement.aspx/CostCentreDetails",
                    data: '{intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",datefrom:"' + datefrom + '",dateTo:"' + dateTo + '",VoucherId:"' + VoucherId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d != "") {
                            document.getElementById("divBank").innerHTML = response.d;
                        }
                    },
                    failure: function (response) {

                    }
                });
            }
            return false;
        }

        function PostdatedChqDisplay(LdgrId) {

            var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
             var OrgId = '<%= Session["ORGID"] %>';
             var Crncy = document.getElementById("<%=hiddenDefaultCrncyId.ClientID%>").value;

             if (LdgrId != "") {
                 $noCon.ajax({
                     type: "POST",
                     async: false,
                     url: "fms_Ledger_Statement.aspx/LoadPostdatedChqDtls",
                     data: '{OrgId:"' + OrgId + '" ,CorpId:"' + CorpId + '",LdgrId:"' + LdgrId + '",Crncy:"' + Crncy + '"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {
                         if (response.d != "") {
                             document.getElementById("tblPostdateChq").innerHTML = response.d;
                             $(".post_bx1").show(300);
                             return false;
                         }
                     },
                     failure: function (response) {

                     }
                 });
             }
             return false;
        }

        function CloseChq() {
            $(".post_bx1").hide(300);
        }


        function LinkClick(Id, VoucherType) {
            if (Id != "") {
                if (VoucherType == "0") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Receipt_Account/fms_Receipt_Account.aspx?ViewId=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                else if (VoucherType == "1") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Payment_Account/fms_Payment_Account.aspx?ViewId=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                else if (VoucherType == "2") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Journal/fms_Journal.aspx?ViewId=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                else if (VoucherType == "3") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Credit_Note/fms_Credit_Note.aspx?Id=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                else if (VoucherType == "4") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Debit_Note/fms_Debit_Note.aspx?Id=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                else if (VoucherType == "5") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Sales_Master/fms_Sales_Master.aspx?ViewId=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                else if (VoucherType == "6") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Purchase_Master/Purchase_master.aspx?ViewId=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                else if (VoucherType == "7" || VoucherType == "8") {
                    var nWindow = window.open("/FMS/FMS_Master/fms_Postdated_Cheque/fms_Postdated_Cheque.aspx?ViewId=" + Id + "&VId=1", 'PoP_Up', 'width=1199,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                }
                return false;
            }
        }


        //0039
        function CheckInfo(VoucherAccId) {

            var dateTo = document.getElementById("<%=txtTodate.ClientID%>").value;
            var datefrom = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var corpid = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
            var orgid = '<%= Session["ORGID"] %>';
            var userid = '<%= Session["USERID"] %>';

            if (VoucherAccId != "") {

                $noCon.ajax({
                    type: "POST",
                    async: false,
                    url: "fms_Ledger_Statement.aspx/checkDetails",
                    data: '{intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",datefrom:"' + datefrom + '",dateTo:"' + dateTo + '",VoucherAccId:"' + VoucherAccId + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        if (response.d != "") {
                            document.getElementById("divCheckInfo").innerHTML = response.d;
                        }
                    },
                    failure: function (response) {

                    }
                });
            }
            return false;
        }
        //end



    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenLedgerIds" runat="server" />
    <asp:HiddenField ID="hiddenLedgerNames" runat="server" />
    <asp:HiddenField ID="hiddenDate" runat="server" />
    <asp:HiddenField ID="hiddenDefaultCrncyId" runat="server" />
    <asp:HiddenField ID="HiddenStartDate" runat="server" />
    <asp:HiddenField ID="HiddenCodeFormate" runat="server" />
    <asp:HiddenField ID="HiddenCodeStatus" runat="server" />
    <asp:HiddenField ID="HiddenEndDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldDecmlCnt" runat="server" />
    <asp:HiddenField ID="hiddenCorpId" runat="server" />

      <ol class="breadcrumb">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Ledger Statement </li>
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
                    <asp:Label ID="lblEntry" runat="server">Ledger Statement  </asp:Label>
                </h2>


                 <div class="form-group fg2 fg2_mr">
                    <label for="email" class="fg2_la1 pad_l">All Ledger:<span class="spn1">&nbsp;</span></label>
                    <div class="check1">
                         <label class="switch">
                             <input  type="checkbox" runat="server" onclick="SearchOPtion();" onkeydown="return  IncrmntConfrmCounter();"  onkeypress="return DisableEnter(event)" id="cbxExtngSplr" /> 
                             <span class="slider_tog round"></span>
                         </label>
                    </div>
                </div>


         
                <div class="form-group fg2 fg2_mr">
                    <label for="email" class="fg2_la1">Account Group:<span class="spn1"></span></label>
                    <div id="divddlAccGrp">
                        <asp:DropDownList ID="ddlParentGroup" class="form-control fg2_inp1 " runat="server" Style="">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg2 fg2_mr">
                    <label for="email" class="fg2_la1">Ledger Code Range:<span class="spn1">&nbsp;</span></label>
                    <div class="col-md-6 pa_l">
                        <%--<input id="txtLedgerRangeFrom" runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)" style="" placeholder="From" />--%>
                        <asp:DropDownList ID="txtLedgerRangeFrom" class="form-control fg2_inp1 codfrm" runat="server" Style=""></asp:DropDownList>
                    </div>
                    <div class="col-md-6 pa_l">
                       <%-- <input id="txtLedgerRangeTo" runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)" style="" placeholder="To" />--%>
                        <asp:DropDownList ID="txtLedgerRangeTo" class="form-control fg2_inp1 codto" runat="server" Style=""></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg2 fg2_mr">
                    <label for="email" class="fg2_la1">Hierarchy1 Code Range:<span class="spn1">&nbsp;</span></label>
                    <div class="col-md-6 pa_l">
                         <%-- <input id="txtH1RangeFrom"  runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)"  style="" placeholder="From" />--%>
                        <asp:DropDownList ID="txtH1RangeFrom" class="form-control fg2_inp1 codfrm" runat="server" Style=""></asp:DropDownList>
                    </div>
                    <div class="col-md-6 pa_l">
                         <%--<input id="txtH1RangeTo"  runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)"  style="" placeholder="To" />--%>
                        <asp:DropDownList ID="txtH1RangeTo" class="form-control fg2_inp1 codto" runat="server" Style=""></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg2 fg2_mr">
                    <label for="email" class="fg2_la1">Hierarchy2 Code Range:<span class="spn1">&nbsp;</span></label>
                    <div class="col-md-6 pa_l">
                        <%--<input id="txtH2RangeFrom" runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)" style="" placeholder="From" />--%>
                        <asp:DropDownList ID="txtH2RangeFrom" class="form-control fg2_inp1 codfrm" runat="server" Style=""></asp:DropDownList>
                    </div>
                    <div class="col-md-6 pa_l">
                        <%--<input id="txtH2RangeTo" runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)" style="" placeholder="To" />--%>
                        <asp:DropDownList ID="txtH2RangeTo" class="form-control fg2_inp1 codto" runat="server" Style=""></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg2 fg2_mr">
                    <label for="email" class="fg2_la1">CC Code Range:<span class="spn1">&nbsp;</span></label>
                    <div class="col-md-6 pa_l">
                        <%--<input id="txtCCCodeRangeFrom" runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)" style="" placeholder="From" />--%>
                        <asp:DropDownList ID="txtCCCodeRangeFrom" class="form-control fg2_inp1 codfrm" runat="server" Style=""></asp:DropDownList>
                    </div>
                    <div class="col-md-6 pa_l">
                        <%--<input id="txtCCCodeRangeTo" runat="server" maxlength="100" autocomplete="off" class="form-control fg2_inp1 allownumericwithoutdecimal" onkeypress="return isTagEnter(event)" style="" placeholder="To" />--%>
                        <asp:DropDownList ID="txtCCCodeRangeTo" class="form-control fg2_inp1 codto" runat="server" Style=""></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg2 fg2_mr">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtFromdate" runat="server" type="text" onkeypress="return DisableEnter(event)" autocomplete="off" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var StartDateVal = document.getElementById("cphMain_HiddenStartDate").value;
                        var EndDateVal = document.getElementById("cphMain_HiddenEndDate").value;

                        $noCon('#datepicker').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            //startDate: StartDateVal,
                            //endDate: EndDateVal,
                        });
                    </script>
                </div>

                <div class="form-group fg2 fg2_mr">
                    <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span> </label>
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" onkeypress="return DisableEnter(event)" autocomplete="off" class="form-control inp_bdr" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var StartDateVal = document.getElementById("cphMain_HiddenStartDate").value;
                        var EndDateVal = document.getElementById("cphMain_HiddenEndDate").value;
                        $noCon('#datepicker1').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            //startDate: StartDateVal,
                            //endDate: EndDateVal,
                        });
                    </script>
                </div>

                 <div class="form-group fg6 fg2_mr">
                    <label for="email" class="fg2_la1">Ledger:<span class="spn1"></span></label>
                    <div id="divddlCountry">
                        <asp:DropDownList ID="ddlLedger" data-placeholder="Select Ledger" multiple="mutiple" class="form-control fg2_inp1 form1 select2 " runat="server" onkeyup="IncrmntConfrmCounter()" onmouseclick="IncrmntConfrmCounter()" style="width:90%;">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg7 fg2_mr">
                    <label for="pwd" class="fg2_la1">Mode:<span class="spn1"></span> </label>
                    <div class="row" style="cursor:pointer;">
                        <div class="col-sm-10">
                            <div class="form-check">
                                <asp:RadioButton class="form-check-input" runat="server" ID="radioDetail" GroupName="radioLedger" Checked="true" />
                                <label class="form-check-label" for="cphMain_radioDetail">Detail</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton runat="server" class="form-check-input" ID="radioSummary" GroupName="radioLedger" />
                                <label class="form-check-label" for="cphMain_radioSummary">Summary</label>
                            </div>
                        </div>
                    </div>
                </div>

      <div class="form-group fg5">
          <label for="pwd" class="fg2_la1">Include Sub-Ledger:<span class="spn1"></span> </label>
          <div class="check1">
            <div class="">
              <label class="switch">
                  <input id="cbxSubLedgerSts" type="checkbox" runat="server" onclick="SearchOPtion();" onkeypress="return DisableEnter(event)" />
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>

                <div class="fg7">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" runat="server"  class="submit_ser"  OnClientClick="return SearchValidation();" OnClick="btnSearch_Click"  /> 
                </div>
                <div class="clearfix"></div>
                <div class="devider"></div>

                <div id="divReport" runat="server">
                </div>

                  <button id="print" onclick="return PrintClick('pdf');" class="print_o"><i class="fa fa-print"></i></button>
                  <button id="csv" onclick="return PrintClick('csv');" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>

            </div>
        </div>
    </div>

    <div id="divPrintCaption" runat="server" style="display: none"></div>

    <div id="divPrintReport" runat="server" style="display: none">
        <br />
        <br />
    </div>

    <div id="divTitle" runat="server" style="display: none">LEDGER STATEMENT</div>

<!---cc_bx1_opened--->
    <div class="cc_bx1">
        <div class="modal-content cc_bx">
      <div class="modal-header">
        <h4 class="modal-title tr_c" id="exampleModalLabel">COST CENTRE</h4>
        <button type="button" class="close js-close-modal" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mdl_cc">
        
          <div id="divBank"></div>

      </div>
      <div class="modal-footer">
        <button class="btn btn-danger js-close-modal" style="margin:auto;float: left;" onclick="return false;">Close</button>
      </div>
    </div>  
    </div>
<!---cc_bx1_closed--->

<!----post_dated detailed_section_popup_opened--->
<div id="divPostdatedChq" class="post_bx1" style="display:none;">
  <h1><i class="fa fa-close cls_post" onclick="return CloseChq()"></i> Postdated Cheque</h1>
  <div class="post_bx1_1">

    <table id="tblPostdateChq" class="display table-bordered" cellspacing="0" width="100%">
    </table>

  </div>
</div>
<!----post_dated detailed_section_popup_closed--->

<!-- 0039>
    <!---cc_bx1_opened--->
    <div class="cc_bx1">
        <div class="modal-content cc_bx">
      <div class="modal-header">
        <h4 class="modal-title tr_c" id="H1">TRANSACTION DETAILS</h4>
        <button type="button" class="close js-close-modal" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mdl_cc">
        
          <div id="divCheckInfo"></div>

      </div>
      <div class="modal-footer">
        <button class="btn btn-danger js-close-modal" style="margin:auto;float: left;" onclick="return false;">Close</button>
      </div>
    </div>  
    </div>
<!---cc_bx1_closed--->


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
                $au('#cphMain_ddlParentGroup').selectToAutocomplete1Letter();

                $au('#cphMain_txtLedgerRangeFrom').selectToAutocomplete1Letter();
                $au('#cphMain_txtLedgerRangeTo').selectToAutocomplete1Letter();

                $au('#cphMain_txtH1RangeFrom').selectToAutocomplete1Letter();
                $au('#cphMain_txtH1RangeTo').selectToAutocomplete1Letter();

                $au('#cphMain_txtH2RangeFrom').selectToAutocomplete1Letter();
                $au('#cphMain_txtH2RangeTo').selectToAutocomplete1Letter();

                $au('#cphMain_txtCCCodeRangeFrom').selectToAutocomplete1Letter();
                $au('#cphMain_txtCCCodeRangeTo').selectToAutocomplete1Letter();
            });
       
        </script>


<!---cost centre display_script--->
<script type="text/javascript">
    $(".js-open-modal").click(function () {
        $(".cc_bx1").addClass("visible");
    });
    $(".js-open-cc").click(function () {
        $(".cc_bx1").addClass("visible");
    });
    $(".js-close-modal").click(function () {
        $(".cc_bx1").removeClass("visible");
    });

</script>

</asp:Content>

