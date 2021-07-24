<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzitFinance.master" AutoEventWireup="true" CodeFile="fms_Day_Book.aspx.cs" Inherits="FMS_FMS_Reports_fms_DayBook_fms_Day_Book" %>

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
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
    <script src="/js/jquery.min.js"></script>
    <style>
        .list-group {
    margin-bottom: 0px;
    padding-left: 0;
}
        .auto1 {
    width: 92%;
    margin-left: 17px;
}
         input[type="radio"] {
            display: table-cell;
        }
         input[type="checkbox"] {
    margin: 0px 0 0;
    line-height: normal;
}
         .cont_rght {
    min-height: auto;
}
         .table {
    width: 100%;
    max-width: 100%;
    margin-bottom: 0px;
}
        .form-control {
            padding: 0px 2px;
        }
        .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
    padding: 5px 3px;
}
    </style>
    <script>
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
            return false;
        }
   
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            LoadEmpList();

        });

        $('.sorting_asc').click(function (e) {
        });
        $('.sorting_asc').click(function (e) {
        });

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

            /* COLUMN FILTER  */
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({

               "order": [[1, 'asc']],
                //"bFilter": false,
                //"bInfo": false,
                //"bLengthChange": false
                //"bAutoWidth": false,
                //"bPaginate": false,
                //"bStateSave": true // saves sort state using localStorage
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
                },
                "columnDefs": [
                                     {
                                         "searchable": false,
                                         "orderable": false,
                                         "targets": 0
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
        function DayBookValidate() {
            var ret = true;
            var date = document.getElementById("<%=txtDate.ClientID%>").value;
            document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "";
            if (date == "") {
                document.getElementById("<%=txtDate.ClientID%>").style.borderColor = "red";
                ret = false;
            }
            return ret;
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
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
           <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      <asp:HiddenField ID="hiddenupd" runat="server" />

        <div class="cont_rght" style="width:100%;margin-left:2%;padding-top: 1%;">
                  <div style="height:34px;">
  
                    <div class="alert alert-danger" id="divWarning" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
                    <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
            <section id="widget-grid" class="">

                <div class="row">
                    <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-right: 0px;">
                        <div class="" id="wid-id-0">


       <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/daybook.png" style="vertical-align: middle;" />  Day Book  
        </div>    
      
       

                            <br>

  <div style="width: 100%; border: 1px solid #8e8f8e; padding: 0px; background-color: #f6f6f6; float: left">
       
    <div class="auto1" style="width: 100%;margin-left: 0px;">
<div class="cont_rght" style="width:100%">
<div class="sect250" style="margin: 0px 0 30px;">
<div class="row">
<div class="container" style="padding-top:18px;padding-bottom: 33px;">
 

 

    <!-- Start:-New design -->
   
                          <div class="row">
                          <div class="row">
                                    <div class="form-group col-md-4">
                              <label for="txtDate" class="col-md-3 col-form-label">Date<span>*</span></label>
                              <div class="col-md-8">
                                    <input id="txtDate" readonly="readonly"  style="width: 100%;background-color: #fff;" runat="server" type="text" onkeypress="return DisableEnter(event)"  class="Tabletxt form-control datepicker"  data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" />
                                        <script>
                                            $noCon('#cphMain_txtDate').datepicker({
                                                autoclose: true,
                                                format: 'dd-mm-yyyy',
                                                endDate: new Date(),
                                                timepicker: false
                                            });
                       </script>
                                      </div>
                            </div>
                            <div class="form-group col-md-6">
                              <label for="example-text-input" class="col-md-3 col-form-label">Transaction Type<span></span></label>
                              <div class="col-md-5">
                                               <asp:DropDownList ID="ddlMode" class="form-control"  onkeypress="return isTag(event)" onkeydown="return isTag(event)" runat="server" >
                    </asp:DropDownList>

                                      </div>
                                     
                            </div>
                             <div class="form-group col-md-1">
                             <asp:Button ID="btnSearch"   runat="server"   class="btn btn-primary btn-grey  btn-width" OnClientClick="return DayBookValidate();" OnClick="btnSearch_Click" text="Search" />
                            
                             </div>
                              <div class="form-group col-md-2" style="cursor: default; /*! float: right; */ height: 35px; /*! margin-right: -2.5%; */ /*! margin-top: 2%; */ font-family: Calibri;width: 8%;margin-bottom: 0%;" class="print" >
     <a id="print_cap" target="_blank" data-title="Day Book" href="../../Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 70%;margin-right:15%;height: 82%;">
        <span style="margin-top: -26px; float: right;/*! font-family: Calibri; */font-size: 16px;color: black;">Print</span></a>                                  
</div>
                             <br>
      <!--<div class="">
                            
                            </div>-->
             <div class="container" style="margin-top: 6%;width: 100%;padding-left: 0px;padding-right: 0px;">  
            <div class="row">   
       <div id="divDayBook" class="container" runat="server" style="padding-right:3px;padding-left: 3px;">                 
<%--<table class="table table-bordered table-responsive" id="tabMain">
  <thead>
    <tr>
      <th style="width:5%">SL NO</th>
      <th style="width:20%">PARTICULARS</th>
        <th style="width:15%;text-align:left;">TRANSACTION TYPE</th>
         <th style="width:20%;text-align:left;">REFERENCE NUMBER</th>
         <th style="width:20%;text-align:right;">DEBIT</th>
         <th style="width:20%;text-align:right;">CREDIT</th>
    </tr>
  </thead>
  
  
  <tbody id="tabMainBody" runat="server">
  </tbody>

</table>--%>

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
                                 <div id="divTitle" runat="server" style="display: none">
     Day Book
      </div>
                          
                                    <div style="clear: both"></div>
                          <div class="form-row form-inline">
                                    <div class="col-sm-4 col-md-4 padding-10" style="margin-top:3px;padding:0;width: 100%;float: right;margin-right: 1%;">
                              
                              
                            </div>
                                  </div>
                          <div style="clear:both"></div>   
     <!-- End:-New design -->

<%--<div>
<div class="col-md-12" style="padding:9px;">
<div style="float:right;">
    <asp:Button ID="bttnsave"   runat="server" OnClientclick="return ValidateBudgt(this);" class="btn btn-primary btn-grey  btn-width" text="Save" />
    <asp:Button ID="btnUpdate"   runat="server" OnClientclick="return ValidateBudgt(this);" class="btn btn-primary btn-grey  btn-width" text="Update" />
    <asp:Button ID="btnConfirm"   runat="server" OnClientclick="return ValidateBudgt(this);" class="btn btn-primary btn-grey  btn-width" text="Confirm" />
    <asp:Button ID="btnCancel" runat="server" OnClientclick="return ConfirmMessage();"  class="btn btn-primary btn-grey  btn-width" text="Cancel"  />

</div>
</div>  
</div>--%>
  </div>
  
</div>
</div>


</div>
  
    </div>

  </div> 
                            </div>
                    </article>  </div>  </section> 

                  </div>  </div>

     

</asp:Content>

