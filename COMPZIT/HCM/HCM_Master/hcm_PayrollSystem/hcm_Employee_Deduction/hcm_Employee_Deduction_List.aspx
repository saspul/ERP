<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Employee_Deduction_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Employee_Deduction_hcm_Employee_Deduction_List" %>

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
      <%--<link href="../../../../css/HCM/main.css" rel="stylesheet" />--%>
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />

      <script src="/js/HCM/Common.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              LoadDeleList();
              LoadCustomerList();
              ChangeCheckbox();
          
              var sessionValue = '<%= Session["Succes"] %>';
         
              if (sessionValue == "confirmed")
              {

                  $noCon(window).scrollTop(0);
                  $noCon("#successalert").html("Employee deduction details  Confirmed Sucessfully.");
                  $noCon("#successalert").fadeTo(2000, 500).slideUp(500, function () {

           
                  });

                  $noCon("#successalert").alert();
              } else if (sessionValue == "saved") {

                  $noCon(window).scrollTop(0);
                  $noCon("#successalert").html("Employee deduction details  inserted sucessfully.");
                  $noCon("#successalert").fadeTo(2000, 500).slideUp(500, function () {

                
                  });

                  $noCon("#successalert").alert();
              } 
              else if (sessionValue == "updated") {

                  $noCon(window).scrollTop(0);
                  $noCon("#successalert").html("Employee deduction details updated sucessfully.");
                  $noCon("#successalert").fadeTo(2000, 500).slideUp(500, function () {


                  });

                  $noCon("#successalert").alert();
              }
              else if (sessionValue == "DELETE") {

                  $noCon(window).scrollTop(0);
                  $noCon("#successalert").html("Employee deduction details  Deleted Sucessfully.");
                  $noCon("#successalert").fadeTo(2000, 500).slideUp(500, function () {


                  });

                  $noCon("#successalert").alert();
              }
              
              $noCon("#datatable_fixed_column_info").hide();
              $noCon("#datatable_fixed_column_wrapper input.form-control:first").focus();
              '<%= Session["Succes"]='"'+null+'"' %>';
          });

          function SuccesMessage() {
             
              SuccessMsg("SAVE", "Confirmed Successfully.");
            
           
              return false;
          }


          function ChangeCheckbox() {

              if (document.getElementById("cphMain_CbxCnclStatus").checked) {
                  document.getElementById("cphMain_divDeleList").style.display = "block";
                  document.getElementById("cphMain_divList").style.display = "none";
                  $noCon("#TableDelete_wrapper input.form-control:first").focus();
              }
              else {
                  document.getElementById("cphMain_divDeleList").style.display = "none";
                  document.getElementById("cphMain_divList").style.display = "block";
                  $noCon("#datatable_fixed_column_wrapper input.form-control:first").focus();
              }
           
          }
          </script>
   <script>
     
       //for search option
       var $NoConfi = jQuery.noConflict();
       var $NoConfi3 = jQuery.noConflict();

      
       function LoadCustomerList() {
         

           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var Cnclsts = 0;
           if (document.getElementById("<%=CbxCnclStatus.ClientID%>").checked)
               Cnclsts = 1;
          
           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */

         
           var otable = $NoConfi3('#datatable_fixed_column').DataTable({

               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'dataVIewDeduction.ashx',

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
                   aoData.push({ "name": "MODE", "value": Cnclsts });
                 
                   
               },
              
           });


           // Apply the filter

           $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });

          

           return false;
       }


       function LoadDeleList() {


           var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
           var Cnclsts = 0;
           if (document.getElementById("<%=CbxCnclStatus.ClientID%>").checked)
               Cnclsts = 1;

           var responsiveHelper_datatable_fixed_column = undefined;


           var breakpointDefinition = {
               tablet: 1024,
               phone: 480
           };

           /* COLUMN FILTER  */


           var otable = $NoConfi3('#TableDelete').DataTable({

               'bProcessing': true,
               'bServerSide': true,
               'sAjaxSource': 'dataVIewDeduction.ashx',

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
                       responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#TableDelete'), breakpointDefinition);
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
                   aoData.push({ "name": "MODE", "value": Cnclsts });

               },

           });


           // Apply the filter

           $NoConfi("#TableDelete thead th input[type=text]").on('keyup change', function () {

               otable
                   .column($NoConfi(this).parent().index() + ':visible')
                   .search(this.value)
                   .draw();

           });



           return false;
       }

       function ViewRow(id,x) {
          
           document.getElementById("<%=HiddenViewId.ClientID%>").value = id;
           document.getElementById("<%=HiddenFieldDeleView.ClientID%>").value = x;
           document.getElementById("<%=btnRedirect.ClientID%>").click(); 
           return false;
       }
    </script>
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
         <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" OnClick="btnRedirect_Click" />
    <asp:HiddenField ID="HiddenViewId" runat="server" />
    
                                                      <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" value="0"/>
                                          <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    
      <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server"  Value="0"/>
        <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="hiddenCancelId" runat="server" />
    <asp:HiddenField ID="HiddenStrReason" runat="server" />
     <asp:HiddenField ID="hiddenViewStatus" runat="server" />  
    <asp:HiddenField ID="hiddenRsnid" runat="server" />
      <asp:HiddenField ID="HiddenFieldDeleView" runat="server" />
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
                    <div class="alert alert-success" id="successalert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button>
    <strong>Success! </strong>
                 
   
</div>
    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/employee-payment-deduction-module.png" style="vertical-align: middle;" />
           Employee Deduction List
        </div >
      
        <br />

        <div onclick="location.href='hcm_Employee_Deduction_Master.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;z-index:1">

       
        </div>
         


        <%--START-EMP:-0009 --%>
         <div class="smart-form" style="float: left; width: 93.4%;">
          <div style="width: 100%; float: left;  border: 1px solid #c3c3c3;margin-left:-13px;height: 50px; background:#fafafa;margin-bottom: 7px;">


                                <div style="width: 45%; float: right;">               
                          <asp:Button ID="btnCnclSearch" style="margin-top:2.3%; height:26px;cursor:pointer; width: 104px;" runat="server" class="btn btn-primary" Text="Search" OnClientClick="return ChangeCheckbox();" />     
               </div>
            <div style=" width: 55%; float: right;">
                
                        <section style="width:38%;float:right;margin-top:2.4%;margin-bottom:0px;">
                      
                <label class="checkbox" style="float: left;">
                <input name="checkbox-inline" id="CbxCnclStatus" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" runat="server"  type="checkbox"  />
                 <i></i></label>
                            <label class="lblh2" style="float: left;width: 70%;Height:33px;margin-top:0.7%;"> <h class="page-title txt-color-blueDark">Show Deleted Entries </h></label>
                 </section> 
        
                </div>


                        </div>
             </div>

        <%--END-EMP:-0009 --%>




         <div id="divList" runat="server" class="widget-body no-padding" style="width: 93.5%;margin-top:5%;">

            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family:Calibri;" >
                <thead>
                    <tr>
                         <th class="hasinput" style="width: 20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="DOC NUMBER"  /></th>                        
                         <th class="hasinput" style="width: 15%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="EMPLOYEE ID"</th>  
                        <th class="hasinput" style="width: 15%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="EMPLOYEE NAME"</th>
                        <th class="hasinput" style="width:15%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="DEDUCTION" /></th>
                          <th class="hasinput" style="width:20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="AMOUNT" /></th>
                       
                            <th class="hasinput" style="width:20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="AMOUNT PAID" /></th>
                  
                            <th class="hasinput" style="width:20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="NO. OF INSTALLMENT" /></th>
                  
                         <th class="hasinput" style="width: 7.5%"></th>
                         <th class="hasinput" style="width: 7.5%"></th>
                    </tr>
<tr >
   
    <th data-class="expand">DOC NUMBER</th>
     <th data-class="expand">EMPLOYEE ID</th>
      <th data-class="expand">EMPLOYEE NAME</th>
    <th data-class="expand">DEDUCTION</th>   
    <th data-class="expand">AMOUNT</th> 
      <th data-class="expand">AMOUNT PAID</th> 
      <th data-class="expand">NO. OF INSTALLMENT</th> 
    <th data-class="expand">VIEW</th>
       <th data-class="expand">DELETE</th>
  
    </tr>
                    </thead>
                <tbody> 
            <tr> 
                <td colspan="7" class="dataTables_empty">Loading details...</td> 
            </tr> 
            </tbody> 
                    </table>
        </div>

          


         <div id="divDeleList" runat="server" class="widget-body no-padding" style="width: 93.5%;margin-top:5%;">

            <table id="TableDelete" class="table table-striped table-bordered" width="100%" style="font-family:Calibri;" >
                <thead>
                    <tr>
                         <th class="hasinput" style="width: 20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="DOC NUMBER"  /></th>                        
                          <th class="hasinput" style="width: 15%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="EMPLOYEE"</th>
                        <th class="hasinput" style="width:15%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="DEDUCTION" /></th>
                          <th class="hasinput" style="width:20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="AMOUNT" /></th>
                       
                            <th class="hasinput" style="width:20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="AMOUNT PAID" /></th>
                  
                            <th class="hasinput" style="width:20%"><input type="text" class="form-control" onkeypress="return DisableEnter(event);" placeholder="NO. OF INSTALLMENT" /></th>
                  
                         <th class="hasinput" style="width: 15%"></th>
                        
                    </tr>
<tr >
   
    <th data-class="expand">DOC NUMBER</th>
      <th data-class="expand">EMPLOYEE</th>
    <th data-class="expand">DEDUCTION</th>   
    <th data-class="expand">AMOUNT</th> 
      <th data-class="expand">AMOUNT PAID</th> 
      <th data-class="expand">NO. OF INSTALLMENT</th> 
    <th data-class="expand">VIEW</th>
  
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
     <%--START-EMP:-0009 --%>

         <div id="dialog_simple" title="Dialog Simple Title">
            <!-- widget content -->

            <div class="widget-body no-padding" id="divCancelPopUp">


                  <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none; margin-top: 1%">

                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
                </div>

                <div style="width: 100%; float: left; clear: both; margin-top: 5%">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Cancel Reason*</label>

                        <label class="input" style="float: left; width: 60%;">
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" onblur="RemoveTag(txtCancelReason)" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="text-transform: uppercase; resize: none;"></textarea>
                        </label>

                    </section>


                </div>
                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return CancelDeduction();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();"class="btn btn-default"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>
                   
                </div>
            </div>
                </div>
       
          <%--END-EMP:-0009 --%>
    <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          .glyphicon-search::before {
    content:url(/Images/HCM/Img/Icons/search.png);
    margin-left: -43%;
}

          #datatable_fixed_column_wrapper, #TableDelete_wrapper {
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
    </style>
     <script src="../../../../js/jQuery/jquery-2.2.3.min.js"></script>  
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
        <script src="../../../../js/HCM/Common.js"></script>
       <script type="text/javascript">
           var $nooC = jQuery.noConflict();

           $nooC(function () {
               $nooC('#dialog_simple').dialog({
                   autoOpen: false,
                   width: 600,
                   resizable: false,
                   modal: true,
                   title: "Employee Deduction",

               });           

           });
           function DeleteRow(StrId) {


               ezBSAlert({
                   type: "confirm",
                   messageText: "Do you want to cancel this entry?",
                   alertType: "info"
               }).done(function (e) {
                   if (e == true) {
                       var SearchString = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;

                       if (SearchString == 1) {
                           document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;

                     document.getElementById("txtCancelReason").value = "";
                     document.getElementById("divErrMsgCnclRsn").style.display = "none";
                     document.getElementById("txtCancelReason").style.borderColor = "";

                     $nooC('#dialog_simple').dialog('open');

                     return false;
                 }
                 else {

                     var Reason = "";
                     var strReasonMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                       var UserId = '<%=Session["USERID"]%>';
                     var Details = PageMethods.DeleteDedctn(StrId, Reason, strReasonMust, UserId, function (response) {
                         window.location = 'hcm_Employee_Deduction_List.aspx';
                     });
                 }
                    return false;

                }
                else {
                    return false;
                }
            });
               return false;
             
           }


           function CancelDeduction() {
               if (document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value != null) {
                var DedctnID = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                var Reason = document.getElementById("txtCancelReason").value;
                var strReasonMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;

                var UserId = '<%=Session["USERID"]%>';

                   if (validateSaveCancelRsn() == true) {
                     
                    var SearchString = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    var Details = PageMethods.DeleteDedctn(DedctnID, Reason, strReasonMust, UserId, function (response) {
                     window.location = 'hcm_Employee_Deduction_List.aspx';
                    });

                  
                }
            }
           }
           function CloseCancelView() {

               ReasonConfirm = document.getElementById("txtCancelReason").value;
               if (ReasonConfirm != "") {


                   ezBSAlert({
                       type: "confirm",
                       messageText: "Do you want to close  without completing cancellation process?",
                       alertType: "info"
                   }).done(function (e) {
                       if (e == true) {
                       window.location = 'hcm_Employee_Deduction_List.aspx';
                       return false;

                   }
                   else {
                       return false;
                   }
               });

               }
               else {
                   window.location = 'hcm_Employee_Deduction_List.aspx';
               }

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
                       document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                       document.getElementById("txtCancelReason").style.borderColor = "red";
                       document.getElementById("divErrMsgCnclRsn").style.display = "";
                       return false;
                   }
                   else {
                       $nooC('#dialog_simple').dialog('close');
                   }

               }
               return true;
           }

           function DeleteNotPosble() {
                   SuccessMsg("SAVE", "Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
                   return false;
           }

           function CancelAlert(href) {
               window.location = href;
               return false;
           }
    </script>  
</asp:Content>

