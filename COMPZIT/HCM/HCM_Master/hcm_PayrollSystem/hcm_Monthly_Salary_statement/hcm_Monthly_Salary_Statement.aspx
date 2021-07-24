<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Monthly_Salary_Statement.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_statement_hcm_Monthly_Salary_Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">   
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              LoadEmpList();
          });
          </script>
   <script>
       function PrintSalaryDetails(x) {
           var data = document.getElementById("Para" + x).value;
           document.getElementById("<%=HiddenViewId.ClientID%>").value = data;
           document.getElementById("<%=btnRedirect2.ClientID%>").click();
           return false;
       }
       //for search option
       var $NoConfi = jQuery.noConflict();
       var $NoConfi3 = jQuery.noConflict();
       function LoadEmpList() {
           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var responsiveHelper_datatable_fixed_column = undefined;
           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };
           var otable = $NoConfi3('#datatable_fixed_column').DataTable({
               //"bFilter": false,
               //"bInfo": false,
               //"bLengthChange": false
               //"bAutoWidth": false,
               //"bPaginate": false,
               //"bStateSave": true // saves sort state using localStorage
               "bDestroy": false,
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
           // Apply the filter
           $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();
           });
       }
       function DisableEnter(evt) {
           evt = (evt) ? evt : window.event;
           var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
           if (keyCodes == 13) {
               return false;
           }
       }
    </script>
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenViewId" runat="server" />
    <asp:Button ID="btnRedirect2" runat="server" Text="Button" Style="display: none;" OnClick="btnRedirect2_Click" />
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div id="main" role="main">
        <div id="content">

            <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="" id="wid-id-0">


                            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                                <img src="/Images/BigIcons/Monthly_stmt_all.png" style="vertical-align: middle;" />
                                Monthly Salary Statement
                            </div>

                            <br />
                            <div style="float: left; width: 98%; background: white; padding-left: 1%;">

                                <div class="smart-form" style="float: left; width: 100%;">
                                    <div style="width: 100%; float: left;" class="formdiv">



                                        <div style="width: 50%; float: left;">
                                            <section style="width: 95%; margin-left: 5%; margin-bottom: 0px;">
                                                <label class="lblh2" style="float: left; width: 27%;">Year*</label>
                                                <div>
                                                    <label class="select">
                                                        <asp:DropDownList ID="ddlyear" runat="server" Style="width: 50%;" onkeypress="return DisableEnter(event)"></asp:DropDownList>
                                                    </label>
                                                </div>
                                            </section>
                                        </div>
                                        <div style="width: 50%; float: left;">
                                            <section style="width: 95%; margin-left: 4%;">
                                                <label class="lblh2" style="float: left; width: 27%;">Month*</label>
                                                <div id="div1" style="word-break: break-all; word-wrap: break-word;">
                                                    <label class="select" style="float: left; width: 50%; word-break: break-all; word-wrap: break-word;">
                                                        <asp:DropDownList ID="ddlMonth" onchange="IncrmntConfrmCounter();"  class="form1" runat="server" onkeypress="return DisableEnter(event)"></asp:DropDownList>
                                                    </label>
                                                </div>
                                            </section>
                                        </div>
                                        <div style="width: 50%; float: left;margin-top:1%;">
                                            <section style="width: 95%; margin-left: 5%; margin-bottom: 0px;">
                                                <label class="lblh2" style="float: left; width: 27%;">Mode*</label>
                                                <div>
                                                    <label class="select">
                                                        <asp:DropDownList ID="ddlMode" runat="server" Style="width: 50%;" onkeypress="return DisableEnter(event)">
                                                            <asp:ListItem Value="0" Text="Departmentwise"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Consolidated"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </label>
                                                </div>
                                            </section>
                                        </div>




                                        <div style="width: 50%; float: left; margin-top: 1%;">

                                            <section style="width: 95%; margin-left: 4%;">
                                                <label class="lblh2" style="float: left; width: 27%;">Type*</label>

                                                <div>
                                                    <label class="select">
                                                        <asp:DropDownList ID="ddlType" runat="server" Style="width: 50%;" onkeypress="return DisableEnter(event)">
                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Confirm Pending"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Confirmed"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Paid"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="Closed"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </label>
                                                </div>

                                            </section>


                                        </div>


                                        <asp:Button ID="btnSrch" runat="server" Style="margin-left: 52.5%; height: 31px; padding: 0 22px; font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif; cursor: pointer; float: left; margin-top: 1%;" class="btn btn-primary" Text="Search" OnClick="btnSrch_Click" OnClientClick="return validateSearch();" />
                                    </div>
                                    <div class="jarviswidget-color-greenLight jarviswidget-sortable" id="wid-id-3" data-widget-editbutton="false" role="widget">

                                        <div id="divlistview" style="width: 100%; float: left; margin-top: 1%" runat="server">
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>
                    </article>
                </div>
            </section>
        </div>
    </div>
    <style>
        table.dataTable tbody td {
            word-break: break-all;
        }

        .table {
            font-size: 13px;
        }

        #datatable_fixed_column_wrapper {
            border: 1px solid #b0adad;
            padding-top: 1%;
            padding: 2%;
        }
    </style>
</asp:Content>



