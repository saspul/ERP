<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master"  AutoEventWireup="true" CodeFile="fms_Postdated_Cheque_Report.aspx.cs" Inherits="FMS_FMS_Reports_fms_Postdated_Cheque_fms_Postdated_Cheque_Report" EnableEventValidation="false" %>

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

    <script>

        var $noCon = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();
        var $NoConfi = jQuery.noConflict();
        $noCon(window).load(function () {
            LoadEmpList();
            var BankParty = "radio_Bank";
            if (document.getElementById("cphMain_radio_Bank").checked == true) {
                BankParty = "radio_Bank";
            }
            else {
                BankParty = "radio_Party";
            }
            EnableParty_Bank_Ledger(BankParty);
        });
        var $au = jQuery.noConflict();
       

        function LoadParty() {
            var intOrgID = '<%= Session["ORGID"] %>';
            var intCorrpID = '<%= Session["CORPOFFICEID"] %>';
            var Type = document.getElementById("cphMain_ddlTransactionType").value;
            $("#cphMain_ddlParty").empty();
            var ddlTestDropDownListXML = "";
            ddlTestDropDownListXML = $("#cphMain_ddlParty");
            var OptionStart = $("<option>--SELECT--</option>");
            OptionStart.attr("value", "--SELECT--");
            ddlTestDropDownListXML.append(OptionStart);
            $.ajax({
                async: false,
                type: "POST",
                url: "fms_Postdated_Cheque_Report.aspx/LoadPartyLedger",
                data: '{Type:"' + Type + '",intOrgID:"' + intOrgID + '",intCorrpID:"' + intCorrpID + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    result = response.d;
                    var tableName = "dtTablePartyLedger";
                    $noCon(result).find(tableName).each(function () {
                        var OptionValue = $noCon(this).find('LDGR_ID').text();
                        var OptionText = $noCon(this).find('LDGR_NAME').text();
                        var option = $noCon("<option>" + OptionText + "</option>");
                        option.attr("value", OptionValue);
                        ddlTestDropDownListXML.append(option);
                    });
                    if (document.getElementById("cphMain_HiddenPartyId").value != "") {
                        $noCon("#cphMain_ddlParty").val(document.getElementById("cphMain_HiddenPartyId").value);

                    }
                },
                failure: function (response) {

                }
            });
        }
        function EnableParty_Bank_Ledger(Id) {
            LoadParty();
            if (Id == "radio_Bank") {
                document.getElementById("cphMain_ddlBank").disabled = false;
                document.getElementById("cphMain_ddlParty").disabled = true;
                $noCon("#cphMain_ddlParty").val("--SELECT--");
                document.getElementById("cphMain_HiddenPartyId").value = "";
                $("div#divddlParty input.ui-autocomplete-input").attr("disabled", "disabled");
                $("div#divddlBank input.ui-autocomplete-input").attr("disabled", false);
                $au(function () {
                    $au("#cphMain_ddlBank").selectToAutocomplete1Letter();
                    $au("#cphMain_ddlParty").selectToAutocomplete1Letter();
                });
            }
            else if (Id == "radio_Party") {
                document.getElementById("cphMain_ddlBank").disabled = true;
                $noCon("#cphMain_ddlBank").val("--SELECT--");
                document.getElementById("cphMain_ddlParty").disabled = false;
                $("div#divddlBank input.ui-autocomplete-input").attr("disabled", "disabled");
                $("div#divddlParty input.ui-autocomplete-input").attr("disabled", false);
                $au(function () {
                    $au("#cphMain_ddlBank").selectToAutocomplete1Letter();
                    $au("#cphMain_ddlParty").selectToAutocomplete1Letter();
                });
            }
        }

        function LoadEmpList() {
            var orgID = '<%= Session["ORGID"] %>';
               var corptID = '<%= Session["CORPOFFICEID"] %>';
               var responsiveHelper_datatable_fixed_column = undefined;
               var breakpointDefinition = {
                   tablet: 1024,
                   phone: 480
               };
               /* COLUMN FILTER  */
               var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                   "bSort": false,
                   //"searching": false,
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
               });
               // Apply the filter
               $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {
                   otable
                    //   .column($NoConfi(this).parent().index() + ':visible')
                       .search(this.value)
                       .draw();

               });
               /* END COLUMN FILTER */
        }
        function SearchValidate() {
            var ret = true;
            document.getElementById("cphMain_txtDateTo").style.borderColor = "";

                if (document.getElementById("cphMain_txtDateTo").value == "") {
                    document.getElementById("cphMain_txtDateTo").style.borderColor = "red";
                    ret = false;
                }
            if (ret == false) {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                $(window).scrollTop(0);
                return false;
            }

            var ddlPartyText = "";
            if (document.getElementById("cphMain_ddlParty").value != "--SELECT--") {
                var strddlParty = document.getElementById("cphMain_ddlParty");
                var ddlPartyText = strddlParty.options[strddlParty.selectedIndex].text;
            }
            document.getElementById("cphMain_HiddenPartyText").value = ddlPartyText;

            return ret;
        }
        function SavePartyId() {
            if (document.getElementById("cphMain_ddlParty").value != "" && document.getElementById("cphMain_ddlParty").value != "--SELECT--") {
                document.getElementById("cphMain_HiddenPartyId").value = document.getElementById("cphMain_ddlParty").value;
            }
        }
        function PrintClick_Old() {
            window.open("../../Print/Common_print.htm");
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="HiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenPartyId" runat="server" />
    <asp:HiddenField ID="HiddenPartyText" runat="server" />


    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Postdated Cheque Report</li>
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
                <h1>Postdated Cheque Report</h1>

                <div class="form-group fg7">
                    <label for="pwd" class="fg2_la1">As On Date:<span class="spn1">*</span></label>
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                    <input id="txtDateTo" runat="server" name="txtDateTo" readonly="readonly" onkeypress="return isTag(event)" onkeydown="return isTag(event)" class="form-control inp_bdr" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="10" onchange="showToDate()" type="text" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                                <script>
                                    $noCon('#datepicker1').datepicker({
                                        autoclose: true,
                                        format: 'dd-mm-yyyy',
                                        timepicker: false,
                                       // startDate: StartDateVal,
                                     //   endDate: EndDateVal
                                    });
            </script>
                </div>
                <div class="fg7">
                    <label for="email" class="fg2_la1">Status:<span class="spn1"></span></label>
                    <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 fg_chs1" runat="server">
                    <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Payment Pending" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Payment Completed" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Payment Rejected" Value="0"></asp:ListItem>

                </asp:DropDownList>
                </div>
                <div class="fg7">
                    <label for="email" class="fg2_la1">Transaction Type:<span class="spn1"></span></label>
                 <asp:DropDownList ID="ddlTransactionType" onchange="return LoadParty()" class="form-control fg2_inp1 fg_chs1" runat="server">
                    <asp:ListItem Text="Payment" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Receipt" Value="1"></asp:ListItem>
                </asp:DropDownList>
                </div>
                <div class="fg8">
                    <div class="row">
                        <div class="col-sm-10">
                            <div class="form-check" >
                                <input class="form-check-input" onchange="return EnableParty_Bank_Ledger('radio_Bank')" type="radio" runat="server" name="gridRadios" id="radio_Bank" value="option1" checked="true"/>
                                <label class="form-check-label" for="gridRadios1">Bank</label>
                            </div>
                            <div class="form-check" >
                                <input class="form-check-input"  onchange="return EnableParty_Bank_Ledger('radio_Party')" type="radio" runat="server" name="gridRadios" id="radio_Party" value="option2"/>
                                <label class="form-check-label" for="gridRadios2">Party</label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="fg7">
                    <label for="email" class="fg2_la1">Bank:<span class="spn1"></span></label>
                    <div id="divddlBank">
                        <asp:DropDownList ID="ddlBank" class="form-control fg2_inp1 fg_chs1 ddl" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="fg7">
                    <label class="fg2_la1">Party:<span class="spn1"></span></label>
                    <div id="divddlParty">
                       <asp:DropDownList ID="ddlParty" onchange="return SavePartyId()" class="form-control fg2_inp1 fg_chs1 ddl" runat="server"></asp:DropDownList>
                    </div>
                </div>

              
                                    <div class="fg8">
                <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return SearchValidate()" OnClick="btnSearch_Click" />

            </div>
<%--                                              <div class="form-group col-md-2" style="cursor: default; /*! float: right; */ height: 35px; /*! margin-right: -2.5%; */ /*! margin-top: 2%; */ font-family: Calibri;width: 8%;margin-bottom: 0%;" class="print" >
     <a id="print_cap" target="_blank" data-title="Day Book" href="../../Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 70%;margin-right:15%;height: 82%;">
        <span style="margin-top: -26px; float: right;/*! font-family: Calibri; */font-size: 16px;color: black;">Print</span></a>                                  
</div>--%>
                <div class="clearfix"></div>
                <div class="free_sp"></div>
                <div class="devider"></div>
                      <button id="print_old" onclick="return PrintClick_Old();" style="display:none" class=""><i class="fa fa-print"></i></button>
                    <asp:Button ID="btnPrint" runat="server" class="submit_ser" style="display:none" OnClick="btnPrint_Click" />
                <a href="javascript:;" type="button" class="print_o"  onclick="PrintClick()" title="Print">
                <i class="fa fa-print"></i>
                </a>

       <asp:Button ID="btnCSV" runat="server" style="display:none" OnClientClick="return SearchValidate()" OnClick="btnCSV_Click" />
        <a href="javascript:;" type="button" onclick="CsvClick()" class="imprt_o" title="CSV">
             <i class="fa fa-file-excel-o" aria-hidden="true"></i>
        </a>
             
                 <div id="open_bl">
                    <div id="DivReport" runat="server" class="table_box tb_scr">
                    </div>
                 </div>
            </div>
        </div>
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

        .ui-autocomplete {
            position: absolute;
            cursor: default;
            z-index: 4000 !important;
        }
    </style>

        <script>
            function PrintClick() {
                var ddlPartyText = "";
                if (document.getElementById("cphMain_ddlParty").value != "--SELECT--") {
                    var strddlParty = document.getElementById("cphMain_ddlParty");
                    var ddlPartyText = strddlParty.options[strddlParty.selectedIndex].text;
                }                
                document.getElementById("cphMain_HiddenPartyText").value = ddlPartyText;
                document.getElementById("<%=btnPrint.ClientID%>").click();
            }


            function CsvClick() {
                var ddlPartyText = "";
                if (document.getElementById("cphMain_ddlParty").value != "--SELECT--") {
                    var strddlParty = document.getElementById("cphMain_ddlParty");
                    var ddlPartyText = strddlParty.options[strddlParty.selectedIndex].text;
                }
                document.getElementById("cphMain_HiddenPartyText").value = ddlPartyText;
                document.getElementById("<%=btnCSV.ClientID%>").click();
            }

    </script>

</asp:Content>

