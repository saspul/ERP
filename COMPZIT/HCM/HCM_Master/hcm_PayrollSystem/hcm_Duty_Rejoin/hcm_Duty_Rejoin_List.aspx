<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Duty_Rejoin_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Duty_Rejoin_hcm_Duty_Rejoin_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>    
    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
       
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>

    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
      

    <script>
        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();

        function LoadRejoinList() {

           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';

           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */

           var otable = $NoConfi3('#datatable_fixed_column').DataTable({

               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'data.ashx',

               "bDestroy": true,
               "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                       "t" +
                       "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
               "autoWidth": true,
               "oLanguage": {
                   "sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

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
               },
               "fnServerParams": function (aoData) {
                   aoData.push({ "name": "ORG_ID", "value": orgID });
                   aoData.push({ "name": "CORPT_ID", "value": corptID });
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


       function LoadConfirmList() {


           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var userID = '<%= Session["USERID"] %>';
           var HRconfirm=document.getElementById("<%=HiddenFieldHRrole.ClientID%>").value;
           var RadioBtn = 0;
           if (document.getElementById("cphMain_radioConfirm").checked) {
               RadioBtn = 1;
           }
          
           var ConfirmMode = document.getElementById("<%=HiddenFieldConfirmationMode.ClientID%>").value;



           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */

           var otable = $NoConfi3('#tableConfirm').DataTable({

               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'dataConfirm.ashx',

               "bDestroy": true,
               "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                       "t" +
                       "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
               "autoWidth": true,
               "oLanguage": {
                   "sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

               },
               "preDrawCallback": function () {
                   // Initialize the responsive datatables helper once.
                   if (!responsiveHelper_datatable_fixed_column) {
                       responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#tableConfirm'), breakpointDefinition);
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
                   aoData.push({ "name": "USER_ID", "value": userID });
                   aoData.push({ "name": "HR_CONFIRM", "value": HRconfirm });
                   aoData.push({ "name": "RADIO_BTN", "value": RadioBtn });
                   aoData.push({ "name": "CONF_MODE", "value": ConfirmMode });
                   
               }
           });


           // Apply the filter

           $NoConfi("#tableConfirm thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });
           /* END COLUMN FILTER */

       }



       function Rejoin(leaveId, UserId,username,designation,department,leavefrom,leaveTo) {
          
           document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value = leavefrom;
           document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value = UserId;
           document.getElementById("<%=HiddenFieldLeaveId.ClientID%>").value = leaveId;
           document.getElementById("lblEmp").innerText = username;
           document.getElementById("lblDesg").innerText = designation;
           document.getElementById("lblDept").innerText = department;
           if (leaveTo == "") {
               document.getElementById("lblLeaveDate").innerText =leavefrom;
           }
           else {
               document.getElementById("lblLeaveDate").innerText = "From " + leavefrom + " To " + leaveTo;
           }
           $nooC('#dialog_simple').dialog('open');
           $nooC('.ui-dialog-titlebar-close').attr('title', 'Close');
           document.getElementById("txtefctvedate").value = "";
           return false;
       }

       function Confirm(RejoinId, username, designation, department, leavefrom, leaveTo,RejoinDate,HandOverSts,RejoinStatus,userID,mode,HalfDaySts) {
           document.getElementById("<%=HiddenFieldRejoinUserId.ClientID%>").value = userID;         
           document.getElementById("<%=HiddenFieldLeaveId.ClientID%>").value = RejoinId;
           document.getElementById("<%=HiddenFieldRejoinStatus.ClientID%>").value = RejoinStatus;
           document.getElementById("Label1").innerText = username;
           document.getElementById("Label2").innerText = designation;
           document.getElementById("Label5").innerText = department;
           if (leaveTo == "") {
               document.getElementById("Label6").innerText = leavefrom;
           }
           else {
               document.getElementById("Label6").innerText = "From " + leavefrom + " To " + leaveTo;
           }
           document.getElementById("LabelRejoinDate").innerText = RejoinDate;
           document.getElementById("txtefctvedateRjct").value = RejoinDate;
          
           //$nooC('#txtefctvedateRjct').datepicker({
           //    autoclose: true,
           //    format: 'DD-MM-YYYY',
           //    timepicker: false,
           //    // endDate: PresentFulDate,                               
           //});

           if (document.getElementById("cphMain_radioConfirm").checked) {
               document.getElementById("txtefctvedateRjct").disabled = true;
           }

           if (document.getElementById("cphMain_radioReject").checked) {
               document.getElementById("txtefctvedateRjct").disabled = false;
           }
               
           
           if (HandOverSts == "1") {
               document.getElementById("LabelHandOvrSts").innerText = "Passport handed over to HR";
           }
           if (HalfDaySts == "1") {
               document.getElementById("lblHalfDay").innerText = "Half Day";
           }
           $nooC('#divConfirmDialog').dialog('open');
           $nooC('.ui-dialog-titlebar-close').attr('title', 'Close');

           if (RejoinStatus == "4") {
               document.getElementById("cphMain_btnConfirm").style.visibility = "hidden";
               document.getElementById("cphMain_btnReject").style.visibility = "hidden";
           }
           if (mode == "0") {
               document.getElementById("cphMain_btnReject").style.display = "none";
           }
           else {
               document.getElementById("cphMain_btnReject").style.display = "block";
           }
           return false;

       }

       function ChangeRadio() {
         
           if (document.getElementById("cphMain_radioRejoin").checked) {
               document.getElementById("divOrgBranchList").style.display = "block";
               document.getElementById("divConfirm").style.display = "none";
           }
           else {
               document.getElementById("divOrgBranchList").style.display = "none";
               document.getElementById("divConfirm").style.display = "block";
               LoadConfirmList();
           }
           $("#datatable_fixed_column_wrapper input.form-control:first").focus();
           $("#tableConfirm_wrapper input.form-control:first").focus();
       }
       function ConfirmCancel() {
           CancelAlert("hcm_Duty_Rejoin_List.aspx");
          // $nooC('#dialog_simple').dialog('close');
           return false;
       }

       
       function validateRejoin() {
                 
           document.getElementById("txtefctvedate").style.borderColor = "";
           var RcptdatepickerDate = document.getElementById("txtefctvedate").value;
           if (RcptdatepickerDate == "") {             
               document.getElementById("txtefctvedate").style.borderColor = "red";
               SuccessMsg("DUP", "Select resume date");              
               return false;
           }
           else {
               var RarrDatePickerDate = RcptdatepickerDate.split("-");
               var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);

                   
               var CurrentDateDate = document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value;
               var arrCurrentDate = CurrentDateDate.split("-");
               var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);
             
             
                   if (RdateDateCntrlr < dateCurrentDate)
                   {
                       document.getElementById("txtefctvedate").style.borderColor = "red";
                       SuccessMsg("DUP", "Resume date cannot be less than leave from date");
                       return false;
                    }
           }

           

           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var userID = '<%= Session["USERID"] %>';
           var empID = document.getElementById("<%=HiddenFieldEmployeeId.ClientID%>").value;
           var leaveId = document.getElementById("<%=HiddenFieldLeaveId.ClientID%>").value;
           var RejoinDate = RcptdatepickerDate;
           var HandSts = 0;
           if (document.getElementById("cphMain_cbxHandOver").checked == true) {
               HandSts = 1;
           }
           var HalfDaySts = 0;
           if (document.getElementById("cphMain_cbxHalfDay").checked == true) {
               HalfDaySts = 1;
           }
           ConfirmRejoin(orgID, corptID, userID, empID, leaveId, RejoinDate, HandSts, HalfDaySts);
           return false;
       }


        function ConfirmCancelPage() {

            CancelAlert("hcm_Duty_Rejoin_List.aspx");
           // $nooC('#divConfirmDialog').dialog('close');
            return false;
        }
        function validateConfirm() {

            var userID = '<%= Session["USERID"] %>';
            var RejoinId = document.getElementById("<%=HiddenFieldLeaveId.ClientID%>").value;
            var RejoinStatus = document.getElementById("<%=HiddenFieldRejoinStatus.ClientID%>").value;    
            var RejoinDate = document.getElementById("txtefctvedateRjct").value;

            document.getElementById("txtefctvedateRjct").style.borderColor = "";
            if (RejoinDate == "") {
                    document.getElementById("txtefctvedateRjct").style.borderColor = "red";
                    SuccessMsg("DUP", "Select resume date");
                    return false;
            }

            ConfirmBtn(userID, RejoinId, RejoinStatus, RejoinDate);
            return false;

        }


        function RejectRejoin() {
                 document.getElementById("divErrMsgCnclRsn").style.display = "none";
                 document.getElementById("txtCancelReason").style.borderColor = "";
                 document.getElementById("txtCancelReason").value = "";
                 $nooC('#DivCancel').dialog('open');
                 return false;
        }

     
        function validateSaveCancelRsn() {
           
                  
            document.getElementById("divErrMsgCnclRsn").style.display = "none";
            document.getElementById("txtCancelReason").style.borderColor = "";

            var strCancelReason = document.getElementById("txtCancelReason").value;
            if (strCancelReason == "") {
                document.getElementById("txtCancelReason").style.borderColor = "red";
                document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                document.getElementById("divErrMsgCnclRsn").style.display = "";
                return false;
            }
            else {
                strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                strCancelReason = strCancelReason.replace(/\n /, "\n");
                if (strCancelReason.length < "10") {
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Reject reason should be minimum 10 characters";
                    document.getElementById("txtCancelReason").style.borderColor = "red";
                    document.getElementById("divErrMsgCnclRsn").style.display = "";
                    return false;
                }
                else {

                    var userID = '<%= Session["USERID"] %>';
                    var RejoinId = document.getElementById("<%=HiddenFieldLeaveId.ClientID%>").value;
                    var Reason = strCancelReason;                  
                    ConfirmReject(userID, RejoinId, Reason);
                }

            }
            return false;
        }
        function closeRejectReason() {         
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to cancel?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $nooC('#DivCancel').dialog('close');
                        return false;
                    }
                    else {
                        return false;
                    }
                });
                return false;
        }



        function ConfirmRejoin(orgID, corptID, userID, empID, leaveId, RejoinDate, HandSts, HalfDaySts) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to resume?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Details = PageMethods.rejoinClick(orgID, corptID, userID, empID, leaveId, RejoinDate, HandSts,HalfDaySts, function (response) {
                        $nooC('#dialog_simple').dialog('close');
                        LoadRejoinList();
                        LoadConfirmList();

                        $nooC("#success-alert").html("Resume process completed successfully.");
                        $nooC("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $nooC("#success-alert").alert();
                       
                    });
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }

       

        function ConfirmBtn(userID, RejoinId, RejoinStatus, RejoinDate) {
            var ConfMode = document.getElementById("<%=HiddenFieldConfirmationMode.ClientID%>").value;
            var RejoinEmpId = document.getElementById("<%=HiddenFieldRejoinUserId.ClientID%>").value;
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Details = PageMethods.ConfirmClick(userID, RejoinId, RejoinStatus,RejoinDate,ConfMode,RejoinEmpId, function (response) {
                        $nooC('#divConfirmDialog').dialog('close');
                        LoadRejoinList();
                        LoadConfirmList();
                        $nooC("#success-alert").html("Confirmed successfully.");
                        $nooC("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $nooC("#success-alert").alert();
                      
                    });
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }



        function ConfirmReject(userID, RejoinId, Reason) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reject resume?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Details = PageMethods.rejectRejoin(userID, RejoinId, Reason, function (response) {
                        $nooC('#DivCancel').dialog('close');
                        $nooC('#divConfirmDialog').dialog('close');
                        LoadRejoinList();
                        LoadConfirmList();
                        $nooC("#success-alert").html("Resume process rejected successfully.");
                        $nooC("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                        });
                        $nooC("#success-alert").alert();
                       
                    });
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
     <asp:HiddenField ID="HiddenFieldConfirmRole" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenFieldReporterRole" runat="server" Value="0"/>
     <asp:HiddenField ID="HiddenFieldHRrole" runat="server" Value="0"/>

     <asp:HiddenField ID="HiddenFieldRejoinStatus" runat="server" />
     <asp:HiddenField ID="HiddenFieldEmployeeId" runat="server" />
     <asp:HiddenField ID="HiddenFieldLeaveId" runat="server" />
     <asp:HiddenField ID="HiddenFieldFromDate" runat="server" />

     <asp:HiddenField ID="HiddenFieldCurrSysDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldConfirmationMode" runat="server" Value="0"/>
    <asp:HiddenField ID="HiddenViewId" runat="server" />
    <asp:HiddenField ID="HiddenFieldRejoinUserId" runat="server" Value="0"/>
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>

    <div class="cont_rght">

         <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button>  
        </div>


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/duty-Rejoin.png" style="vertical-align: middle;" />
            Duty Resume
        </div>

        <br />

           <div class="widget-body smart-form" style="float: left; width: 100%;">




        <div style="width: 100%; float: left;margin-bottom:1%;" class="formdiv">
            <div style="width: 50%; float: left; font-size: 17px;">
                <section style="width: 95%; margin-left: 0%;">
                    <label class="lblh2" style="float: left; width: 27%;">Action*</label>
                    <div class="inline-group" style="background-color: #f5f5f5; padding-left: 4%; padding-top: 3px;  float: left; border: 1px solid #04619c; margin-bottom: 1px;font-family:Calibri;">

                                            <label class="radio" style="font-size:15px;">
                                                <input name="radioRejoin" checked="true"  runat="server" type="radio" id="radioRejoin" onkeypress="return DisableEnter(event)" onchange="ChangeRadio();" />
                                                <i></i>Resume</label>
                                            <label class="radio" style="font-size:15px;">
                                                <input name="radioRejoin"  runat="server" type="radio" id="radioConfirm" onkeypress="return DisableEnter(event)" onchange="ChangeRadio();" />
                                                <i></i>Confirm</label>
                                             <label class="radio" style="font-size:15px;">
                                                <input name="radioRejoin"  runat="server" type="radio" id="radioReject" onkeypress="return DisableEnter(event)" onchange="ChangeRadio();" />
                                                <i></i>Rejected</label>
                                        </div>
                </section>
            </div>
        </div>

                </div>



        <div id="divOrgBranchList" class="widget-body no-padding" style="margin-top: 5%;width: 93.5%;">
            <%-- Rejoin Table--%>
            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Employee ID" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Employee Name" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Designation" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Department" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 10%">
                            <input type="text" class="form-control" placeholder="Leave From Date" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 10%">
                            <input type="text" class="form-control" placeholder="Leave To Date" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 5%"></th>
                    </tr>
                    <tr>
                        <th data-class="expand">Employee Id</th>
                        <th data-class="expand">Employee Name</th>
                        <th data-class="expand">Designation</th>
                        <th data-class="expand">Department</th>
                        <th data-class="expand">Leave From Date</th>
                        <th data-class="expand">Leave To Date</th>
                        <th data-class="expand">Resume</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="6" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>
        </div>





        <div id="divConfirm" class="widget-body no-padding" style="margin-top: 5%;width: 93.5%;">

            <%-- Confirm Table--%>

            <table id="tableConfirm" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Employee Id" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Employee Name" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Designation" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input type="text" class="form-control" placeholder="Department" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 10%">
                            <input type="text" class="form-control" placeholder="Leave From Date" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 10%">
                            <input type="text" class="form-control" placeholder="Leave To Date" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 5%"></th>
                    </tr>
                    <tr>
                        <th data-class="expand">Employee Id</th>
                        <th data-class="expand">Employee</th>
                        <th data-class="expand">Designation</th>
                        <th data-class="expand">Department</th>
                        <th data-class="expand">Leave From Date</th>
                        <th data-class="expand">Leave To Date</th>
                        <th data-class="expand">Confirm</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="6" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>

        </div>


    </div>

               

    

    <%-- Rejoin window--%>
    <div id="dialog_simple" title="Dialog Simple Title" hidden="hidden" style="font-family:Calibri;font-size:16px;">
         <div class="widget-body smart-form" style="float: left; width: 100%;">
        <div style="width: 100%; float: left;margin-top:2%;" class="formdiv">
            <div style="width: 50%; float: left;">
                <section style="width: 95%; margin-left: 5%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Employee:</label>
                    <label id="lblEmp" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
            <div style="width: 50%; float: left;">

                <section style="width: 95%; margin-left: 7%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Designation:</label>
                    <label id="lblDesg" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
        </div>
        <div style="width: 100%; float: left;margin-top:2%;" class="formdiv">
            <div style="width: 50%; float: left;">
                <section style="width: 95%; margin-left: 5%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Department:</label>
                    <label id="lblDept" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
            <div style="width: 50%; float: left;">

                <section style="width: 95%; margin-left: 7%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Leave taken:</label>
                    <label id="lblLeaveDate" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
        </div>
        <div style="width: 100%; float: left;margin-top:2%;" class="formdiv">


             <div style="width: 50%; float: left;">
                <section style="width: 90%; margin-left: 5%;margin-top:-1%;">
                        <div >
                           <label class="checkbox" style="font-size:16px;color:black;">
                                <input type="checkbox" id="cbxHandOver" name="checkbox-inline"  onkeydown="return DisableEnter(event)" runat="server"  />
                                <i></i>Passport Handed Over To HR</label>
                        </div>
                      
                </section>
            </div>

            <div style="width: 50%; float: left;">
                <section style="width: 95%; margin-left: 7%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Resume Date*:</label>
                    <label id="Label3" class="input" style="float: left; width: 60%;">

                        <input id="txtefctvedate" name="txtefctvedate" type="text" class="Tabletxt form-control datepicker" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" onchange="GetDate()" />
                        <asp:HiddenField ID="Hiddentxtefctvedate" runat="server" Value="0" />
                        <script>

                            var presenrdate = document.getElementById("<%=HiddenFieldCurrSysDate.ClientID%>").value;
                            var arrpresenrdate = presenrdate.split("-");
                            var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);

                            var $noCon4 = jQuery.noConflict();
                            $noCon4('#txtefctvedate').datepicker({
                                autoclose: true,
                                format: 'dd-mm-yyyy',
                                timepicker: false,
                                endDate: PresentFulDate
                            });
                            function GetDate() {
                                //$noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtefctvedate').val());
                            }
                        </script>
                    </label>
                </section>
            </div>
           </div>

             <div style="width: 100%; float: left;margin-top:0%;" class="formdiv">
             <div style="width: 50%; float: left;">
                <section style="width: 90%; margin-left: 5%;margin-top:-1%;">
                        <div >
                           <label class="checkbox" style="font-size:16px;color:black;">
                                <input type="checkbox" id="cbxHalfDay" name="checkbox-inline"  onkeydown="return DisableEnter(event)" runat="server"  />
                                <i></i>Half Day</label>
                        </div>      
                </section>
            </div>
           </div>


        </div>

        

        <footer style="background: white;font-family:Calibri;font-size:14px;">
           
            <asp:Button ID="btnRejoin" runat="server" Style="float: left; margin-left: 70%;margin-top:3%;" class="btn btn-primary" Text="Resume"  OnClientClick="return validateRejoin();" />
            <asp:Button ID="btnCancel" runat="server" Style="float: left;margin-top:3%;margin-left:1%;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancel();" />
                                  
        </footer>
    </div>






     <%-- Confirm window--%>
    <div id="divConfirmDialog" title="Dialog Simple Title" hidden="hidden" style="font-family:Calibri;font-size:16px;">
        <div style="width: 100%; float: left;margin-top:2%;" class="formdiv">
            <div style="width: 50%; float: left;">
                <section style="width: 95%; margin-left: 5%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Employee:</label>
                    <label id="Label1" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
            <div style="width: 50%; float: left;">

                <section style="width: 95%; margin-left: 7%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Designation:</label>
                    <label id="Label2" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
        </div>
        <div style="width: 100%; float: left;margin-top:2%;" class="formdiv">
            <div style="width: 50%; float: left;">
                <section style="width: 95%; margin-left: 5%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Department:</label>
                    <label id="Label5" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
            <div style="width: 50%; float: left;">

                <section style="width: 95%; margin-left: 7%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Leave was taken:</label>
                    <label id="Label6" class="input" style="float: left; width: 60%;"></label>
                </section>
            </div>
        </div>
       

         <div style="width: 100%; float: left;margin-top:2%;" class="formdiv">
            <div style="width: 50%; float: left;">
                <section style="width: 95%; margin-left: 5%;display:none;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Resume Date:</label>
                    <label id="LabelRejoinDate" class="input" style="float: left; width: 60%;"></label>
                </section>
           
               <section style="width: 95%; margin-left: 5%;">
                    <label class="lblh2" style="float: left; width: 27%;color:black;">Resume Date*:</label>
                    <label id="Label4" class="input" style="float: left; width: 60%;">

                        <input id="txtefctvedateRjct" name="txtefctvedateRjct" type="text" class="Tabletxt form-control datepicker" data-dateformat="dd-mm-yyyy" placeholder="dd-mm-yyyy" maxlength="50" onchange="GetDate()" />
                        <script>

                            var presenrdate = document.getElementById("<%=HiddenFieldCurrSysDate.ClientID%>").value;
                            var arrpresenrdate = presenrdate.split("-");
                            var PresentFulDate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);

                            var $noCon4 = jQuery.noConflict();
                            $noCon4('#txtefctvedateRjct').datepicker({
                                autoclose: true,
                                format: 'dd-mm-yyyy',
                                timepicker: false,
                               // endDate: PresentFulDate,                               
                            });

                            //$noCon4(document).ready(function() {
                            //    alert("#ready")
                            //    $noCon4('#txtefctvedateRjct').datepicker('setDate', PresentFulDate);
                            //});​

                            function GetDate() {
                                //$noCon4('#cphMain_Hiddentxtefctvedate').val($noCon4('#txtefctvedate').val());
                            }
                        </script>
                    </label>
                </section>
            </div>


            <div style="width: 50%; float: left;">

                <section style="width: 95%; margin-left: 7%;">                 
                    <label id="LabelHandOvrSts" class="input" style="float: left; width: 60%;color:green;font-size:17px;"></label>
                </section>
            </div>
        </div>


         <div style="width: 100%; float: left;margin-top:2%;" class="formdiv">
            <div style="width: 50%; float: left;">
                <section style="width: 95%; margin-left: 5%;">                 
                    <label id="lblHalfDay" class="input" style="float: left; width: 60%;color:green;font-size:17px;"></label>
                </section>
            </div>
        </div>
        

        <footer style="background: white;font-family:Calibri;font-size:14px;">
            <asp:Button ID="btnConfirm" runat="server" Style="float: left; margin-left: 70%;margin-top:3%;" class="btn btn-primary" Text="Confirm"  OnClientClick="return validateConfirm();"  />
            <asp:Button ID="btnReject" runat="server" Style="float: left; margin-left: 1%;margin-top:3%;" class="btn btn-primary" Text="Reject"  OnClientClick="return RejectRejoin();"  />
            <asp:Button ID="btnCancelPage" runat="server" Style="float: left;margin-top:3%;margin-left:1%;" class="btn btn-primary" Text="Cancel" OnClientClick="return ConfirmCancelPage();" />                                 
        </footer>
    </div>




     <%--------------------------------View for error Reason--------------------------%>


        <div id="DivCancel" title="Dialog Simple Title" style="font-family:Calibri;font-size:16px;">
        <!-- widget content -->
           
        <div class="widget-body no-padding" id="divCancelPopUp">
          
            <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display:none;margin-top:1%">
								
								<i class="fa-fw fa fa-times"></i>
								<strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
							</div>
           
            <div style="width: 100%; float: left;clear:both;margin-top:5%">

                                            <section style="width: 95%; margin-left: 5%;">
                                                <label class="lblh2" style="float: left; width: 35%;color:black;">Reject Reason*</label>

                                                <label class="input" style="float: left; width: 60%;">
                                                    <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" onblur="RemoveTag(txtCancelReason)" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)"  style="text-transform: uppercase; resize: none;"></textarea>
                                                </label>

                                            </section>


                                        </div>
            <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top:none;">
            <div class="ui-dialog-buttonset"><button type="button" id="btnCancelRsnSave" onclick="return validateSaveCancelRsn();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; Save</button><button type="button" onclick="return closeRejectReason();" class="btn btn-default"><i class="fa fa-times"></i>&nbsp; Cancel</button></div>

            </div>
        </div>
        <!-- end widget content -->
    </div>

    
   

    <style>
        table.dataTable tbody td {
            word-break: break-all;
        }

        .table {
            font-size: 13px;
        }

        input[type="radio"] {
            display: table-cell;
        }
        .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 10px;
            height: 0px;
            border-radius: 0px;
            border: none;
            visibility: visible;
        }


.table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
    </style>
    <script src="../../../../js/jQuery/jquery-2.2.3.min.js"></script>  
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
        <script src="../../../../js/HCM/Common.js"></script>
       <script type="text/javascript">
           var $nooC = jQuery.noConflict();
 
           $nooC(function () {
               LoadRejoinList();
               LoadConfirmList();
               ChangeRadio();

              

               $nooC('#dialog_simple').dialog({
                   autoOpen: false,
                   width: 1000,
                   resizable: false,
                   modal: true,
                   title: "Resume Process",
                  
                  
               });

               $nooC('#divConfirmDialog').dialog({
                   autoOpen: false,
                   width: 1000,
                   resizable: false,
                   modal: true,
                   title: "Resume Confirm Process",
                  
               });
               $nooC('#DivCancel').dialog({
                   autoOpen: false,
                   width: 600,
                   resizable: false,
                   modal: true,
                   title: "Reject Reason",
                  
               });
               
           });

    </script>  
    <style>
       .ui-dialog {
           left:13%;
           top: 10%;        
        }

        .ui-dialog-title {
            font-family:Calibri;
            font-size:21px;
        }

        #datatable_fixed_column_wrapper, #tableConfirm_wrapper {
            border: 1px solid #c8b6b6;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.ui-dialog .ui-dialog-titlebar {
    padding: 0 10px;
    background: #fff;
    border-bottom-color: #d5cece;
}
    </style>
</asp:Content>


