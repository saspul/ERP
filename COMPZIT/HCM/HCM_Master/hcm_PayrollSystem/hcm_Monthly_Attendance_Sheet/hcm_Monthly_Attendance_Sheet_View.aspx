<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Monthly_Attendance_Sheet_View.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Attendance_Sheet_hcm_Monthly_Attendance_Sheet_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    
    <script src="../../../../css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="../../../../css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="../../../../css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="../../../../css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../../css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="../../../../css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="../../../../css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
     <script src="/js/HCM/Common.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              LoadCustomerList();
              $noCon("input.form-control:first").focus();
          });


          </script>
   <script>
       //for search option
       var $NoConfi = jQuery.noConflict();
       var $NoConfi3 = jQuery.noConflict();
       var $nooCONfi = jQuery.noConflict();

       function LoadCustomerList() {
           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var ViewId = document.getElementById("<%=hiddenViewId.ClientID%>").value;


           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */


           var otable = $NoConfi3('#datatable_fixed_column').DataTable({

               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'dataView.ashx',

               "bDestroy": true,
               "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                       "t" +
                       "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
               "autoWidth": true,
               "oLanguage": {
                   "sSearch": ' <span  class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

               },
               "columnDefs": [ {
                   "targets": 0,
                   "orderable": false
               }],
               "pageLength": 25,
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
                   $("#cbMandatory").prop('checked', false);
                   document.getElementById("<%=BtnPross.ClientID%>").style.display = "none";
                   $("#cbMandatory").prop('disabled', true);
                   if ($('#datatable_fixed_column >tbody').find('input[type="checkbox"]:enabled').length > 0) {
                       $("#cbMandatory").prop('disabled', false);
                   }                     
               },
               "fnServerParams": function (aoData) {
                   aoData.push({ "name": "ORG_ID", "value": orgID });
                   aoData.push({ "name": "CORPT_ID", "value": corptID });
                   aoData.push({ "name": "View_Id", "value": ViewId });

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



       function LoadDailyWrkshtDtls(Id) {
           var ViewId = Id;
           var TableSts = document.getElementById("<%=HiddenFieldTableSts.ClientID%>").value;
           var responsiveHelper_datatable_fixed_column = undefined;

           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */


           var otable = $nooCONfi('#TableWrkshtdtls').DataTable({
               //"scrollY": "300px",
               //"scrollCollapse": true,
               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'dataView1.ashx',

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
                       responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($nooCONfi('#TableWrkshtdtls'), breakpointDefinition);
                   }
               },
               "rowCallback": function (nRow) {
                   responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
               },
               "drawCallback": function (oSettings) {
                   responsiveHelper_datatable_fixed_column.respond();
               },
               "fnServerParams": function (aoData) {
                   aoData.push({ "name": "View_Id", "value": ViewId });
                   aoData.push({ "name": "Table_Sts", "value": TableSts });
                   
               }
           });


           // Apply the filter

           $nooCONfi("#TableWrkshtdtls thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($nooCONfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });
           /* END COLUMN FILTER */






           return false;
       }

    </script>
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       
    <asp:HiddenField ID="HiddenFieldTableSts" runat="server" value="0"/>

      <asp:HiddenField ID="hiddenViewId" runat="server" />

       <asp:HiddenField ID="HiddenFieldConfirmId" runat="server" />

   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght" >


          <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button>  
        </div>
          <div class="alert alert-warning" id="warning-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button>  
        </div>

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/employee-daily-hour-calculation.png" style="vertical-align: middle;" />
           Monthly Attendance Sheet
        </div >

      
        <br />

        
        <div onclick="location.href='hcm_Monthly_Attendance_Sheet_List.aspx'" id="divList" class="list" runat="server" style=" position: fixed; height:26.5px; right:1%;top:30%;">

       
        </div>
       

          <div id="divOrgBranchList" class="widget-body no-padding">
               <asp:Button ID="BtnPross" runat="server" Style="  display:none;height: 31px;padding: 0 22px;font: 300 15px/29px 'Open Sans',Helvetica,Arial,sans-serif;cursor: pointer;float:right;margin-right:15%;margin-top:1%;" class="btn btn-primary" Text="Confirm"  OnClientClick="return valdatepross();" />
            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family:Calibri;" >
                <thead>
                    <tr>
                        <th class="hasinput" style="width:5%;text-align: center;"> </th>
                         <th class="hasinput" style="width: 30%"><input type="text" class="form-control" placeholder="O.T Category" onkeydown="return DisableEnter(event)" /></th>                        
                          <th class="hasinput" style="width: 15%"><input type="text" class="form-control" placeholder="Date" onkeydown="return DisableEnter(event)" style="text-align:center;" /></th>
                        <th class="hasinput" style="width:15%"><input type="text" class="form-control" placeholder="Number Of Employee" onkeydown="return DisableEnter(event)" /></th>
                          <th class="hasinput" style="width:30%"><input type="text" class="form-control" placeholder="File Name" onkeydown="return DisableEnter(event)" /></th>
                         <th class="hasinput" style="width: 5%"></th>
                    </tr>
<tr >
    <th data-class="expand"><label class="checkbox" style="display: block;"><input type="checkbox" title="SELECT ALL"  onchange="return changeAll();"   onkeypress="return DisableEnter(event)"  id="cbMandatory"><i style="margin-left: 0%;"></i></label></th>
    <th data-class="expand">O.T Category</th>
    <th data-class="expand">Date</th>
    <th data-class="expand">Number of employee</th>   
    <th data-class="expand">File Name</th> 
    <th data-class="expand">Action</th>
    
  
    </tr>
                    </thead>
                <tbody> 
            <tr> 
                <td colspan="7" class="dataTables_empty">Loading details...</td> 
            </tr> 
            </tbody> 
                    </table>
        </div>

          
    </div>


      <%-- Popup window--%>
     <div id="dialog_simple" title="Dialog Simple Title" hidden="hidden" style="font-family:Calibri;font-size:16px;">
       

          <div id="divWrkshtDtls" class="widget-body no-padding" >

            <table id="TableWrkshtdtls" class="table table-striped table-bordered" style="font-family:Calibri;"  width="100%">
                <thead>
                    <tr>
                         <th class="hasinput" style="width: 10%"><input type="text" class="form-control" placeholder="Employee Code" onkeydown="return DisableEnter(event)" /></th>                        
                          <th class="hasinput" style="width: 15%"><input type="text" class="form-control" placeholder="Employee" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width:10%"><input type="text" class="form-control" placeholder="Designation" onkeydown="return DisableEnter(event)" /></th>
                          <th class="hasinput" style="width:10%"><input type="text" class="form-control" placeholder="Project Ref#" onkeydown="return DisableEnter(event)" /></th>
                          <th class="hasinput" style="width: 5%"><input type="text" class="form-control" placeholder="Attendance" onkeydown="return DisableEnter(event)"  /></th>
                        <th class="hasinput" style="width:5%"><input type="text" class="form-control" placeholder="O.T" onkeydown="return DisableEnter(event)"  /></th>

                           <th class="hasinput" style="width:5%"><input type="text" class="form-control" placeholder="Idle Hour" onkeydown="return DisableEnter(event)"  /></th>
                           <th class="hasinput" style="width:5%"><input type="text" class="form-control" placeholder="Final O.T" onkeydown="return DisableEnter(event)"  /></th>
                           <th class="hasinput" style="width:5%"><input type="text" class="form-control" placeholder="Rounded O.T" onkeydown="return DisableEnter(event)"  /></th>

                          <th class="hasinput" style="width:25%;"><input type="text" class="form-control" placeholder="Remarks" onkeydown="return DisableEnter(event)"  /></th>
                       
                    </tr>
<tr >
   
    <th data-class="expand">Employee Code</th>
      <th data-class="expand">Employee</th>
    <th data-class="expand">Designation</th>   
    <th data-class="expand">Project Ref#</th> 
    <th data-class="expand">Attendance</th>
     <th data-class="expand">O.T</th> 

     <th data-class="expand">Idle Hour</th> 
     <th data-class="expand">Final O.T</th> 
     <th data-class="expand">Rounded O.T</th> 

    <th data-class="expand">Remarks</th>
  
    </tr>
                    </thead>
                <tbody> 
            <tr> 
                <td colspan="7" class="dataTables_empty">Loading details...</td> 
            </tr> 
            </tbody> 
                    </table>
        </div>


        <footer style="background: white;font-family:Calibri;font-size:14px;">
           
        
             <asp:Button ID="btnConfirm" runat="server" Style="float: left; margin-left: 39%;margin-top:0.5%;" class="btn btn-primary" Text="Confirm"  OnClientClick="return ConfirmDtl('CONFIRM');" />
             <asp:Button ID="btnReopen" runat="server" Style="display:none;  float: left; margin-top:0.5%;" class="btn btn-primary" Text="Reopen"  OnClientClick="return ConfirmDtl('REOPEN');" />
            <asp:Button ID="btnCancel" runat="server" Style="float: left;margin-top:0.5%;margin-left:1%;" class="btn btn-primary" OnClientClick="  $nooC('#dialog_simple').dialog('close');$nooC('#dialog_Ament').dialog('close');" Text="Cancel" />
                                  
        </footer>
    </div>

     <div id="dialog_Ament" title="Dialog Simple Title" hidden="hidden" style="font-family:Calibri;font-size:16px;">
          <div id="div_Ament" class="widget-body no-padding" >
              </div>
     </div>

     <script src="../../../../js/jQuery/jquery-2.2.3.min.js"></script>  
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
        <script src="../../../../js/HCM/Common.js"></script>
       <script type="text/javascript">
           var $nooC = jQuery.noConflict();

           $nooC(function () {
               $nooC('#dialog_simple').dialog({
                   autoOpen: false,
                   width: 1300,
                   resizable: false,
                   modal: true,
                   title: "View Monthly Attendance Sheet",
                   position: 'top',
               });
               $nooC('#dialog_Ament').dialog({
                   autoOpen: false,
                   width: 1300,
                   resizable: false,
                   modal: true,
                   title: "View Amendment",
                   position: 'top',
               });
               
           });


           function ViewRow(Id) {
               
               $nooC('#dialog_simple').dialog('open');
               LoadDailyWrkshtDtls(Id);

               document.getElementById("<%=HiddenFieldConfirmId.ClientID%>").value = Id;

               var tableSts = document.getElementById("<%=HiddenFieldTableSts.ClientID%>").value;

               var Details = PageMethods.ConfrmSts(Id,tableSts, function (response) {

                   if (response == "1") {

                       document.getElementById("cphMain_btnConfirm").style.visibility = "hidden";
                       document.getElementById("cphMain_btnReopen").style.display = "";
                       document.getElementById('cphMain_btnReopen').onclick = function () { return ConfirmDtl('REOPEN'); };
                   }
                   else if (response == "2") {
                       document.getElementById("cphMain_btnConfirm").style.visibility = "hidden";
                       document.getElementById("cphMain_btnReopen").style.display = "";
                       document.getElementById('cphMain_btnReopen').onclick = function () { return ReOpenNotPossible('REOPEN'); };
                   }
                   else {

                       document.getElementById("cphMain_btnConfirm").style.visibility = "visible";
                       document.getElementById("cphMain_btnReopen").style.display = "none";
                       //document.getElementById('cphMain_btnReopen').onclick = function () { return ReOpenNotPossible('REOPEN'); };

                   }
               });


               return false;
           }

           function ConfirmCancel() {
               CancelAlert("hcm_Monthly_Attendance_Sheet_View.aspx");
               return false;
           }

           function ReOpenNotPossible(Mode) {
               alert("Sorry, reopen denied. This entry is already selected somewhere or it is a processed entry!");
               return false;
           }

    </script>  



    <style>
         table.dataTable tbody td {
            word-break:break-all;
           
        }
      
         .table {
            font-size:13px;
        }

           .ui-dialog {
           left:2%;
           top: 0.5%;        
        }
        .ui-dialog .ui-dialog-titlebar {
    padding: 0 10px;
    background: #fff;
    border-bottom-color: #c8b6b6;
}
       
          #datatable_fixed_column_wrapper,#TableWrkshtdtls_wrapper,#TableWrkshtdtlsAmnt{
            border: 1px solid  #c8b6b6;
        }
          .datatable_fixed_column_wrapper table > thead > tr > th {
    vertical-align: inherit;
    background: none;
    color: #352c2c;
}
    
   #datatable_fixed_column td:nth-child(1), #datatable_fixed_column th:nth-child(1),#datatable_fixed_column td:nth-child(3), #datatable_fixed_column th:nth-child(3), #datatable_fixed_column td:nth-child(4), #datatable_fixed_column th:nth-child(4) {
   text-align: center;
}
     #TableWrkshtdtls td:nth-child(5), #TableWrkshtdtls th:nth-child(5){
   text-align: center;
}
      #TableWrkshtdtlsAmnt td:nth-child(5), #TableWrkshtdtlsAmnt th:nth-child(5){
   text-align: center;
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
    </style>
    <script>


        function BlurIdleHr(x) {

            var RoundedOT = document.getElementById("txtIdleHR" + x).value.trim();

            if (RoundedOT.match(/^\d+(\.\d+)?$/) && RoundedOT <= 24) {
                var pieces = RoundedOT.split(".");
                if (pieces.length > 1) {
                    if (pieces[1].length > 2)
                        document.getElementById("txtIdleHR" + x).value = parseFloat(RoundedOT).toFixed(2);
                }
            }
            else {
                document.getElementById("txtIdleHR" + x).value = "0";
            }           
            var IdleHr = document.getElementById("txtIdleHR" + x).value.trim();
            var OT = document.getElementById("txtOT" + x).value.trim();
            if (OT != "") {


                IdleHr = parseFloat(IdleHr);
                OT = parseFloat(OT);

                if (IdleHr >= OT) {
                    document.getElementById("txtFinalOT" + x).value = "0";
                    document.getElementById("txtRoudedOT" + x).value = "0";
                }
                else {

                    var Reslt = OT - IdleHr;
                    var pieces = Reslt.toString().split(".");
                    if (pieces.length > 1 && pieces[1].length > 2) {
                        document.getElementById("txtFinalOT" + x).value = Reslt.toFixed(2);
                        document.getElementById("txtRoudedOT" + x).value = Reslt.toFixed(2);
                    }
                    else {
                        document.getElementById("txtFinalOT" + x).value = Reslt;
                        document.getElementById("txtRoudedOT" + x).value = Reslt;
                    }
                }

            }
            UpdateRow(x);
        }

        function BlurRoundedOT(x) {


            var RoundedOT = document.getElementById("txtRoudedOT" + x).value.trim();
            if (RoundedOT.match(/^\d+(\.\d+)?$/) && RoundedOT <= 24) {
                var pieces = RoundedOT.split(".");
                if (pieces.length > 1) {
                    if (pieces[1].length > 2)
                        document.getElementById("txtRoudedOT" + x).value = parseFloat(RoundedOT).toFixed(2);
                }
            }
            else {
                document.getElementById("txtRoudedOT" + x).value = "0";
            }
            UpdateRow(x);
        }
        function BlurRemark(x) {
            UpdateRow(x);
        }

        function UpdateRow(id) {

            var IdleHr = document.getElementById("txtIdleHR" + id).value.trim();
            var FinalOT = document.getElementById("txtFinalOT" + id).value.trim();
            var RoundedOT = document.getElementById("txtRoudedOT" + id).value.trim();
            var Remark = document.getElementById("txtRemrks" + id).value.trim();
            var tableSts = document.getElementById("<%=HiddenFieldTableSts.ClientID%>").value;
            var Details = PageMethods.UpdateRow(id, IdleHr, FinalOT, RoundedOT, Remark,tableSts, function (response) {

            });
            return false;

        }



        function ConfirmDtl(strMODE) {

            if (strMODE == "REOPEN") {
                strMODE = "REOPEN";
            } else {
                strMODE = "CONFIRM";

            }


            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to " + strMODE.toLocaleLowerCase() + "?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    var orgID = '<%= Session["ORGID"] %>';
                    var corptID = '<%= Session["CORPOFFICEID"] %>';
                    var userID = '<%= Session["USERID"] %>';
                    var Id = document.getElementById("<%=HiddenFieldConfirmId.ClientID%>").value;
                    if (orgID == "" || corptID == "" || userID == "") {
                        window.location.href = "/Default.aspx";
                    }
                    var tableSts = document.getElementById("<%=HiddenFieldTableSts.ClientID%>").value;

                    var Details = PageMethods.ConfirmDtls(Id, orgID, corptID, userID, strMODE,tableSts, function (response) {
                        if (response == "SUCCESS") {
                            var successMsg = "Confirmed successfully."
                            if (strMODE == "REOPEN") {
                                successMsg = "Reopened successfully."
                            }
                            window.location.href = "hcm_Monthly_Attendance_Sheet_View.aspx?InsUpd=" + strMODE;

                            //$nooC('#dialog_simple').dialog('close');
                            //$nooC("#success-alert").html(successMsg);
                            //$nooC("#success-alert").fadeTo(9000, 500).slideUp(500, function () {
                            //});
                            //$nooC("#success-alert").alert();
                        }
                        else if (response == "NO_LOA") {
                            //leave on absence
                            $nooC('#dialog_simple').dialog('close');
                            $nooC("#warning-alert").html("There is no leave type defined with \"leave-on-absence\" property");
                            $nooC("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                            });
                            $nooC("#warning-alert").alert();
                        }
                        else if (response == "ERROR") {
                            //error
                            $nooC('#dialog_simple').dialog('close');
                            $nooC("#warning-alert").html("Some error occured. Please contact system administrator.");
                            $nooC("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                            });
                            $nooC("#warning-alert").alert();
                        }
                        else if (response == "ALREADY_CONFIRMED") {
                            //error
                            $nooC('#dialog_simple').dialog('close');
                            $nooC("#warning-alert").html("Monthly attendance sheet already confirmed");
                            $nooC("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                            });
                            $nooC("#warning-alert").alert();
                        }



                    });
                    return false;


                }
                else {
                    return false;
                }
            });
            return false;
        }


        function SuccessConfirmation() {
            $nooC("#success-alert").html("Confirmed successfully.");
            $nooC("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $nooC("#success-alert").alert();
            return false;
        }
        function SuccessReopen() {
            $nooC("#success-alert").html("Reopened successfully.");
            $nooC("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $nooC("#success-alert").alert();
            return false;
        }
        function changeAll() {            
            if (document.getElementById("cbMandatory").checked == true) {              
                     $('#datatable_fixed_column >tbody').find('input[type="checkbox"]:not(:checked)').each(function () {
                          if ($(this).is(':enabled')) {
                              $(this).prop('checked', true);
                          }
                      });
                  }
                  else {
                      $('#datatable_fixed_column >tbody').find('input[type="checkbox"]:checked').each(function () {
                          $(this).prop('checked', false);
                      });
            }
            changeSingle();
                  return false;
        }
        function changeSingle() {
            var flag = 0;
            $('#datatable_fixed_column >tbody').find('input[type="checkbox"]:checked').each(function () {
                flag++;
            });
            if (flag == 0) {
                document.getElementById("<%=BtnPross.ClientID%>").style.display = "none";
                }
                else {
                 document.getElementById("<%=BtnPross.ClientID%>").style.display = "block";
                }
            return false;
        }
        function valdatepross() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to confirm?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                   
                    var ids = "";
                    $('#datatable_fixed_column >tbody').find('input[type="checkbox"]:checked').each(function () {                      
                        if (ids == "") {
                            ids = $(this).val();
                        }
                        else {
                            ids = ids+"-"+$(this).val();
                        }
                    });
                    var strMODE = "CONFIRM";                  
                    var orgID = '<%= Session["ORGID"] %>';
                    var corptID = '<%= Session["CORPOFFICEID"] %>';
                    var userID = '<%= Session["USERID"] %>';
                    if (orgID == "" || corptID == "" || userID == "") {
                        window.location.href = "/Default.aspx";
                    }
                    var tableSts = document.getElementById("<%=HiddenFieldTableSts.ClientID%>").value;

                    var Details = PageMethods.ConfirmDtlsAll(ids, orgID, corptID, userID, strMODE,tableSts, function (response) {
                        if (response == "SUCCESS") {
                            var successMsg = "Confirmed successfully."
                            window.location.href = "hcm_Monthly_Attendance_Sheet_View.aspx?InsUpd=" + strMODE;
                        }
                        else if (response == "NO_LOA") {
                            //leave on absence
                            $nooC('#dialog_simple').dialog('close');
                            $nooC("#warning-alert").html("There is no leave type defined with \"leave-on-absence\" property");
                            $nooC("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                            });
                            $nooC("#warning-alert").alert();
                        }
                        else if (response == "ERROR") {
                            //error
                            $nooC('#dialog_simple').dialog('close');
                            $nooC("#warning-alert").html("Some error occured. Please contact system administrator.");
                            $nooC("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                            });
                            $nooC("#warning-alert").alert();
                        }
                        else if (response == "ALREADY_CONFIRMED") {
                            //error
                            $nooC('#dialog_simple').dialog('close');
                            $nooC("#warning-alert").html("Monthly attendance sheet already confirmed");
                            $nooC("#warning-alert").fadeTo(9000, 500).slideUp(500, function () {
                            });
                            $nooC("#warning-alert").alert();
                        }
                    });
                    return false;
                   
                        }
                        else {
                      return false;
                        }
                    });
                    return false;
        }
        function ShowAmendment(id) {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userID = '<%= Session["USERID"] %>';
            if (orgID == "" || corptID == "" || userID == "") {
                window.location.href = "/Default.aspx";
            }
            var Details = PageMethods.ShowAmendmentDtls(id, orgID, corptID, function (response) {
                $nooC('#dialog_Ament').dialog('open');
                document.getElementById("div_Ament").innerHTML=response;                
            });
           return false;
        }
    </script>
    </asp:Content>

