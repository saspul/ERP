<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_CostGrp_Performance.aspx.cs" Inherits="FMS_FMS_Reports_fms_CostGrp_Performance_fms_CostGrp_Performance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
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
              $noCon(".select2").select2();
              var data = document.getElementById("<%=hiddenCostGrpIds.ClientID%>").value;
           
              var eachString = data.split(',');
              $noCon('#cphMain_ddlCostGroup').val(eachString);
              $noCon("#cphMain_ddlCostGroup").trigger("change");
              LoadEmpList();
          });
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
                  //"binfo": false,
                  //"blengthchange": false
                  //"bautowidth": false,
                  // "bpaginate": false,
                  //"bstatesave": true // saves sort state using localstorage
                  "bDestroy": true,

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
              document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
              var fromdate = document.getElementById("cphMain_txtFromdate").value;
              var toDate = document.getElementById("cphMain_txtTodate").value;

              if (fromdate == "" || toDate == "") {
                  document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                  document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                  $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                  });
                  $noCon("#divWarning").alert();
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
                      $noCon("#divWarning").alert();
                      $noCon(window).scrollTop(0);
                      document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                      document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                      ret = false;
                  }
              }
              document.getElementById("<%=hiddenCostGrpIds.ClientID%>").value = $('#cphMain_ddlCostGroup').val();
              return ret;
          }


      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:HiddenField ID="HiddenFieldDecmlCnt" runat="server" />
    <asp:HiddenField ID="hiddenCostGrpIds" runat="server" />
      <asp:HiddenField ID="hiddenCostGrp" runat="server" />

    <asp:HiddenField ID="HiddenFinancialYearTo" runat="server" />
    <asp:HiddenField ID="HiddenFinancialYearFrom" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Cost Centre Perfomance  </li>
    </ol>
    <!---alert_message_section---->
    <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not completed
    </div>
    <div class="content_sec2 cont_contr">
        <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h2>
                    <asp:Label ID="lblEntry" runat="server"> COST GROUP PERFORMANCE ANALYSIS </asp:Label>
                </h2>

                 <div class="form-group fg7 fg4_2 sa_480">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1">*</span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtFromdate" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>
                        var StartDateVal = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
                        var EndDateVal = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;
                        $noCon('#cphMain_txtFromdate').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            startDate: StartDateVal,
                            endDate: EndDateVal,
                        });
                    </script>
                </div>

                <div class="form-group fg7 fg4_2 sa_480">
                    <label for="pwd" class="fg2_la1">To Date:<span class="spn1">*</span> </label>
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" onkeypress="return DisableEnter(event)" class="form-control inp_bdr inp_mst" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                    </div>
                    <script>

                        var StartDateVal = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
                        var EndDateVal = document.getElementById("<%=HiddenFinancialYearTo.ClientID%>").value;
                        var datepickerDate1 = document.getElementById("<%=HiddenFinancialYearFrom.ClientID%>").value;
                        var arrDatePickerDate1 = datepickerDate1.split("-");
                        var varday = arrDatePickerDate1[0];
                        dateAudit = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, varday);
                        $noCon('#cphMain_txtTodate').datepicker({
                            autoclose: true,
                            format: 'dd-mm-yyyy',
                            timepicker: false,
                            startDate: StartDateVal,
                            endDate: EndDateVal,
                        });
                    </script>
                </div>

                <div class="form-group fg5 fg4_2 sa_480">
                    <label for="email" class="fg2_la1">Level:<span class="spn1">*</span></label>
                    <asp:DropDownList ID="ddlHeirarchy" AutoPostBack="true" OnSelectedIndexChanged="ddlHeirarchy_SelectedIndexChanged" class="form-control fg2_inp1 fg_chs1 inp_mst ddl" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="form-group fg4 fg2_hc3 sa_480">
                    <label for="email" class="fg2_la1">Cost Group<span class="spn1"></span>:</label>
                    <asp:DropDownList ID="ddlCostGroup"  class="form-control fg2_inp1 fg_chs1 ddl select2" data-placeholder="select cost group" multiple="multiple" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="form-group fg8 fg4_2 sa_480">
                    <label for="email" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                    <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();" />
                </div>

                <div class="clearfix"></div>
                <div class="free_sp"></div>
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


    <div id="divTitle" runat="server" style="display: none">
        COST GROUP PERFORMANCE ANALYSIS
    </div>

    <script>

        function PrintClick(PrintMode) {
            var strPrintMode = PrintMode;
            var corpid = '<%= Session["CORPOFFICEID"] %>';
            var orgid = '<%= Session["ORGID"] %>';
            var userid = '<%= Session["USERID"] %>';
            var CG = document.getElementById("<%=hiddenCostGrpIds.ClientID%>").value;

            var sel = "";
            var selname = "";
            $("#cphMain_ddlCostGroup option:selected").each(function () {
                var $this = $(this);
                if ($this.length) {
                    var selVal = $this.val();
                    var selText = $this.text();
                    sel = sel + selVal + ",";
                    selname = selname + selText + ",";
                    //alert(sel);
                }
            });
           
            var heirarchy = "";
            if (document.getElementById("<%=ddlHeirarchy.ClientID%>").value!= "--SELECT LEVEL--") {
                heirarchy = document.getElementById("<%=ddlHeirarchy.ClientID%>").value;
            }
            var datefrom = document.getElementById("<%=txtFromdate.ClientID%>").value;
            var dateto = document.getElementById("<%=txtTodate.ClientID%>").value;
            var DecimaCount = document.getElementById("<%=HiddenFieldDecmlCnt.ClientID%>").value;
            $noCon.ajax({
                type: "POST",
                async: false,
                url: "fms_CostGrp_Performance.aspx/List_Print",
                data: '{selname:"' + selname + '",heirarchy:"' + heirarchy + '",CG:"' + CG + '",intuserid:"' + userid + '",intorgid:"' + orgid + '" ,intcorpid:"' + corpid + '",datefrom:"' + datefrom + '",dateto:"' + dateto + '",DecimaCount:"' + DecimaCount + '" ,strPrintMode:"' + strPrintMode + '"   }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d != "") {
                        window.open(response.d, '_blank');
                    }
                }
            });
            return false;
            //    window.open("../../Print/Common_print.htm");
            //    return false;
            //}
        }
       
    </script>
</asp:Content>

