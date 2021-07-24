<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Transfer_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Transfer_hcm_Emp_Transfer_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
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
    <script src="/js/HCM/Common.js"></script>

        <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
         <script>


             var $noCon = jQuery.noConflict();
             $noCon(window).load(function () {
                 LoadLeavSettlmtList();
                 document.getElementById("freezelayer").style.display = "none";
                 //messages
                 var session = '<%=Session["SUCCESS_EMPTRNS"]%>';

                 if (session == "SAVE") {
                     AddSuccesMessage();
                 }
                 else if (session == "UPDATE") {
                     UpdateSuccesMessage();
                 }
                 else if (session == "CONFIRM") {
                     ConfirmSuccesMessage();
                 }

                 '<%Session["SUCCESS_EMPTRNS"] = '"' + null + '"'; %>';

             });
             //show messages 
             function AddSuccesMessage() {

                 $noCon("#success-alert").html("Employee transfer details inserted successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

                 });
                 $noCon("#success-alert").alert();
                 return false;
             }

             function UpdateSuccesMessage() {

                 $noCon("#success-alert").html("Employee transfer details updated successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

                 });
                 $noCon("#success-alert").alert();
                 return false;
             }
             function ConfirmSuccesMessage() {

                 $noCon("#success-alert").html("Employee transfer details confirmed successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

                 });
                 $noCon("#success-alert").alert();
                 return false;
             }
             function ConfirmRenewMessage() {

                 $noCon("#success-alert").html("Employee transfer details renewed successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {

                 });
                 $noCon("#success-alert").alert();
                 return false;
             }
             //for search option
             var $NoConfi = jQuery.noConflict();
             var $NoConfi3 = jQuery.noConflict();


             function LoadLeavSettlmtList() {


                 var responsiveHelper_datatable_fixed_column = undefined;


                 var breakpointDefinition = {
                     tablet: 1024,
                     phone: 480
                 };

                 $NoConfi3('#datatable_fixed_column').dataTable({
                     //"bFilter": false,
                     "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
                         "t" +
                         "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
                     "autoWidth": true,
                     "oLanguage": {
                         "sSearch": '<span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>'
                     },
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

             }

             function OpenViewRenwlInvalid() {

             }
             function OpenViewRenwl(RenewId) {

                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "hcm_Emp_Transfer_List.aspx/readEmptransferDates",
                     data: '{strEmpTransId: "' + RenewId + '"}',
                     dataType: "json",
                     success: function (data) {

                         document.getElementById("<%=txtFromdate.ClientID%>").value = data.d[0];
                         if (data.d[1] != "") {
                             document.getElementById("<%=txtTodate.ClientID%>").value = data.d[1];
                             document.getElementById('divTodateContainer').style.display = "block";
                         } else {
                             document.getElementById('divTodateContainer').style.display = "none";
                         }
                     }
                 });
                 document.getElementById("<%=hiddenRenewId.ClientID%>").value = RenewId;
                 document.getElementById("MymodalCancelView").style.display = "block";
                 document.getElementById("freezelayer").style.display = "";
             }

             function RenewTransfer() {



                 var EmpTransId = document.getElementById("<%=hiddenRenewId.ClientID%>").value;
                 var FromDate = document.getElementById("<%=txtFromdate.ClientID%>").value;
                 var Todate = document.getElementById("<%=txtTodate.ClientID%>").value;

                 if (FromDate != "") {
                     $.ajax({
                         type: "POST",
                         async: false,
                         contentType: "application/json; charset=utf-8",
                         url: "hcm_Emp_Transfer_List.aspx/RenewEmptransfer",
                         data: '{strEmpTransId: "' + EmpTransId + '",strFromDate:"' + FromDate + '",strToDate:"' + Todate + '"}',
                         dataType: "json",
                         success: function (data) {
                         }
                     });
                     CloseRenewView();
                     ConfirmRenewMessage();
                 }
                 else {
                     document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "red";
                 }
             }
             function CloseRenewView() {
                 document.getElementById("MymodalCancelView").style.display = "none";
                 document.getElementById("freezelayer").style.display = "none";
             }


             function DateChk(obj) {

                 document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
                 document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
                 var dateFromDate = document.getElementById("<%=txtFromdate.ClientID%>").value;
                 var arrdateFromDate = dateFromDate.split("-");
                 var FromDate = new Date(arrdateFromDate[2], arrdateFromDate[1] - 1, arrdateFromDate[0]);

                 var dateTodate = document.getElementById("<%=txtTodate.ClientID%>").value;
                  var arrdateTodate = dateTodate.split("-");
                  var Todate = new Date(arrdateTodate[2], arrdateTodate[1] - 1, arrdateTodate[0]);

                  if (document.getElementById('divTodateContainer').style.display != "none") {


                      if (FromDate != "" && Todate != "") {
                          if (Todate < FromDate) {
                              document.getElementById(obj).value = "";
                              document.getElementById(obj).style.borderColor = "red";
                          }

                      }

                  }

              }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
     <asp:HiddenField ID="hiddenRenewId" runat="server" />
 <div class="alert alert-success" id="success-alert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
    <div class="cont_rght">

        <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
            <asp:Label ID="lblEntry" runat="server">Employee Transfer</asp:Label>
        </div>
        <div runat="server" id="divAddSection" style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left">
            <label class="HeadLabel">NEW TRANSFER</label>
            <div style="width: 80%; margin-left: 27%;">
                <asp:Button runat="server" ID="btnSingleTransfer" Style="display: none" OnClick="btnSingleTransfer_Click" />
                <div id="divSingleClick" class="NavigateDiv" onclick="document.getElementById('<%= btnSingleTransfer.ClientID %>').click()" >
                    <label style="font-family: calibri; margin-left: 20%; font-size: 20px; color: #563b24; margin-top: 6%; float: left; cursor: pointer;">SINGLE</label>
                    <img style="float: right; margin-right: 29%; margin-top: 4px;" src="../../../Images/Icons/single_employee.png" />

                </div>
                <asp:Button runat="server" ID="btnBulkTransfer" Style="display: none" OnClick="btnBulkTransfer_Click" />
                <div id="divBulkClick" class="NavigateDiv" onclick="document.getElementById('<%= btnBulkTransfer.ClientID %>').click()" style="width: 25%; margin-left: 2%;">
                    <label style="font-family: calibri; margin-left: 20%; font-size: 20px; color: #563b24; margin-top: 6%; float: left; cursor: pointer;">BULK</label>
                    <img style="float: right; margin-right: 29%; margin-top: 4px;" src="../../../Images/Icons/employees.png" />
                </div>
            </div>

        </div>


        <div style="width: 100%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke; float: left; margin-top: 1%;">
            <label class="HeadLabel">TRANSFER LIST</label>
            <div style="width:100%; padding: 10px;padding-top: 0px; float: left" class="smart-form">


                <div style="float: left; width: 91%; margin-top: 1%">

                    <div style="width: 25%; float: left; padding: 3px; border: 1px solid #32638d; color: #046065; background-color: #d2d6d7;">
                        <div class="inline-group" style="float: left; margin-right: 0%; width: 100%;">
                            <label class="radio" style="font-family: Calibri; font-size: 15px;">
                                <input id="radioIndividual" checked="true" runat="server" name="RadioMode" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>Single</label>

                            <label class="radio" style="font-family: Calibri; font-size: 15px;margin-left: 12%;">
                                <input id="radioBulk" runat="server" name="RadioMode" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>Bulk</label>
                        </div>
                    </div>
                    <div style="width: 36%; float: left; padding: 3px; border: 1px solid #32638d; margin-left: 2%; color: #046065; background-color: #d2d6d7;">
                        <div class="inline-group" style="float: left; margin-right: 0%; width: 100%;">
                              <label class="radio" style="font-family: Calibri; font-size: 15px;">
                                <input id="radioIOtransfer" checked="true" runat="server" name="RadioType" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>Inter Office Transfer</label>
                            
                              <label class="radio" style="font-family: Calibri; font-size: 15px;">
                                <input id="radioBUtransfer"  runat="server" name="RadioType" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>Business Unit Transfer</label>

                        </div>
                    </div>

                    <div style="width: 27%; float: left; padding: 3px; border: 1px solid #32638d; margin-left: 2%; color: #046065; background-color: #d2d6d7;">
                        <div class="inline-group" style="float: left; margin-right: 0%; width: 100%;">
                            <label class="radio" style="font-family: Calibri; font-size: 15px;">
                                <input id="radioManReq" checked="true" runat="server" name="RadioLinked" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>ManPower Request</label>
                            <label class="radio" style="font-family: Calibri; font-size: 15px;">
                                <input id="radioNormal" runat="server" name="RadioLinked" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>Normal</label>
                        </div>
                    </div>
                    <div style="width: 25%; float: left; padding: 3px; border: 1px solid #32638d; margin-top: 1%; color: #046065; background-color: #d2d6d7;">
                        <div class="inline-group" style="float: left; margin-right: 0%; width: 100%;">

                            <label class="radio" style="font-family: Calibri; font-size: 15px;">
                                <input id="radioTemporary" checked="true" runat="server" name="RadioMethod" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>Temporary</label>

                            <label class="radio" style="font-family: Calibri; font-size: 15px;">
                                <input id="radioPermanent" runat="server" name="RadioMethod" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event)" type="radio" />
                                <i></i>Permanent</label>
                        </div>
                    </div>
                </div>
                <div style="float: right; width: 9%; margin-top: 1%">


                    <section ">
                        <label >
                            <asp:Button ID="btnSearch" runat="server" Style="margin-left: 81%; height: 31px; margin-left: 5px; padding: 0 22px; font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif; cursor: pointer;" class="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
                        </label>

                    </section>
                </div>

         
            </div>

            <div id="divList" runat="server" class="widget-body" style="margin-top:2%;width: 100%;float:left">
             <br />
             <br />
         </div>
        </div>

    </div>
     

     <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseRenewView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Renew Employee Transfer</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                                                            <div style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%; float: left;">
                                                            <label class="lblh2" style="float: left; width:30%;">From Date*</label>

                                                            <label class="input" style="float: left; width: 60%;">
                                                                <input id="txtFromdate" disabled="disabled" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtFromdate')" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
                                                                <script>

                                                                    $noCon('#cphMain_txtFromdate').datepicker({
                                                                        autoclose: true,
                                                                        format: 'dd-mm-yyyy',

                                                                        timepicker: false
                                                                    });

                                                                </script>
                                                            </label>
                                                        </section>
                                                    </div>
                                                    <div id="divTodateContainer" style="width: 50%; float: left;">
                                                        <section style="width: 95%; margin-left: 3%; float: left;">
                                                            <label class="lblh2" style="float: left; width: 30%;">To Date*</label>
                                                            <label class="input" style="float: left; width: 60%;">
                                                                <input id="txtTodate" runat="server" type="text" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtTodate')" class="Tabletxt form-control" placeholder="dd-mm-yyyy" maxlength="50" />
                                                                <script>

                                                                    $noCon('#cphMain_txtTodate').datepicker({
                                                                        autoclose: true,
                                                                        format: 'dd-mm-yyyy',

                                                                        timepicker: false
                                                                    });

                                                                </script>
                                                            </label>
                                                        </section>
                                                    </div>


                        <input type="button" id="btnRenew" class="save" style="width: 90px; float:right;margin-right:44%;margin-top: 3%;" onclick="RenewTransfer();" runat="server" value="Save" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 43px;">
                    </div>


                </div>
            </div>  

     <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: black; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.8; z-index: 29; height: auto !important;"
        class="freezelayer" id="freezelayer">
    </div>




    <style>
        .cont_rght {
            width: 97%;
        }

        .HeadLabel {
            font-family: calibri;
            font-size: 16px;
            text-decoration: underline;
            color: #094707;
        }

        input[type="radio"] {
            display: table-row-group;
        }

        table.dataTable tbody td {
            word-break: break-all;
        }

        .table {
            font-size: 13px;
        }

        #datatable_fixed_column_wrapper {
            border: 1px solid #b3b3b3;
        }


        .table > thead > tr > th {
            vertical-align: bottom;
            background: unset;
            color: unset;
        }

        .NavigateDiv {
            width: 25%;
            height: 40px;
            border: 1.5px solid #105a63;
            float: left;
            cursor: pointer;
            background-color: white;
            border-radius: 9px;
        }

            .NavigateDiv:hover {
                border: 1.5px solid #c33700;
                background-color: #deffd2;
            }

        table.dataTable tbody td {
            padding-top: 8px;
            padding-bottom: 10px;
            padding-left: 1%;
            padding-right: 1%;
        }

        .table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
            border-right: 1px solid #c8b6b6;
        }

        .table {
            font-size: 13px;
        }

        .table-striped > tbody > tr:nth-of-type(2n+1) {
            background-color: #eaeaea;
        }

        .table > thead > tr > th {
            padding: 8px 10px;
        }

        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }
    </style>
</asp:Content>

