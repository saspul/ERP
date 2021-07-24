<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Welfare_Service_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Welfare_Service_hcm_Employee_Welfare_Service_hcm_Emp_Welfare_Service_List" %>

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
    
      <style>

   


         /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
      


         /* Modal Content */
       


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         .main_table > tbody > tr:nth-child(2n+1) > td, .main_table > tbody > tr:nth-child(2n+1) > th {
    height: 30px;
    background: #E9E9E9;
    font-size: 14px;
    color: #0d0d0e;
}
 .smart-form {
    margin: 0;
    outline: 0;
    color: #070708;
    position: relative;
}
 .ui-dialog .ui-dialog-title {
  text-align: center;
  width: 95%;
}
     </style>

       <script src="../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
            //  document.getElementById("cphMain_txtFromdate").focus();
              LoadEmployeeList();



              loadTableDesg();
          });
          function loadTableDesg() {

              $noCon(function () {
                  $noCon('#dialog_simple').dialog({
                      autoOpen: false,
                      width: 600,
                      resizable: false,
                      modal: true,
                      title: "Employee Welfare Service ",
                  });
              });
          }


          </script>
    
    <script type="text/javascript">
        function CancelNotPossible() {
            ezBSAlert({
                type: "alert",
                messageText: "Sorry, Cancellation Denied. This welfare service is already selected somewhere or it is a confirmed welfare service!",
                alertType: "info"
                
            });
            return false;
            }
        var $Mo = jQuery.noConflict();

        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this welfare service?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {


                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                        document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                        alert(StrId);
                        var strCancelReason = "";
                        if (strCancelMust == 1) {
                            //cancl rsn must

                            document.getElementById("divErrMsgCnclRsn").style.display = "none";
                            document.getElementById("txtCancelReason").style.borderColor = "";
                            document.getElementById("txtCancelReason").value = "";
                            $noCon('#dialog_simple').dialog('open');

                        }
                        else {
                            DeleteByID(StrId, strCancelReason, strCancelMust);
                            $noCon('#dialog_simple').dialog('close');
                        }
                        return false;
                    }

                    else {
                        return false;
                    }
                });
                return false;

            }
            function CloseCancelView() {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to close  without completing cancellation process?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $noCon('#dialog_simple').dialog('close');

                        document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
                    }
                    else {
                        $noCon('#dialog_simple').dialog('open');
                        return false;
                    }
                });
                return false;
            }


    </script>

         <script>
             function SuccessConfirmation() {
                 $noCon("#success-alert").html("Welfare service details inserted successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                 $noCon("#success-alert").alert();
                 return false;
             }
             function SuccessUpdation() {
                 $noCon("#success-alert").html("Welfare service details updated successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                 $noCon("#success-alert").alert();
                 return false;
             }

             function SuccessCancelation() {
                 $noCon("#success-alert").html("Welfare service cancelled successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                 $noCon("#success-alert").alert();
                 return false;

             }
             function SuccessStatusChange() {
                 $noCon("#success-alert").html("Welfare service status changed successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                 $noCon("#success-alert").alert();
                 return false;
             }
             function getdetails(href) {
                 window.location = href;
                 return false;
             }
             function OpenCancelView(StrId) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Do you want to cancel this welfare service?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                         document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                         var strCancelReason = "";
                         if (strCancelMust == 1) {
                             //cancl rsn must
                             document.getElementById("divErrMsgCnclRsn").style.display = "none";
                             document.getElementById('txtCancelReason').style.borderColor = "";
                             document.getElementById('txtCancelReason').value = "";
                             $noCon('#dialog_simple').dialog('open');

                         }
                         else {
                             DeleteByID(StrId, strCancelReason, strCancelMust);
                             $noCon('#dialog_simple').dialog('close');
                         }
                         return false;

                     }
                     else {
                         return false;
                     }
                 });




                 return false;

             }

             function DeleteByID(strId, strCancelReason, strCancelMust) {
                 var strUserID = '<%=Session["USERID"]%>';
                 if (strId != "" && strUserID != '') {
                     // alert(strId); alert(strCancelReason); alert(strCancelMust); alert(strUserID);
                     var Details = PageMethods.CancelWelfareService(strId, strCancelMust, strUserID, strCancelReason, function (response) {

                         var SucessDetails = response;
                         if (SucessDetails == "successcncl") {

                             window.location = 'hcm_Emp_Welfare_Service_List.aspx?InsUpd=Cncl';


                         }
                         else {
                             window.location = 'hcm_Emp_Welfare_Service_List.aspx?InsUpd=Error';
                         }
                     });
                 }

                 return false;
             }
             //validation when cancel process
             function ValidateCancelReason() {
                 // replacing < and > tags

                 var ret = true;
                 document.getElementById("divErrMsgCnclRsn").style.display = "none";
                 document.getElementById("txtCancelReason").style.borderColor = "";
                 var strCancelReason = document.getElementById("txtCancelReason").value;
                 if (strCancelReason == "") {
                     document.getElementById("txtCancelReason").style.borderColor = "red";
                     document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                     document.getElementById("divErrMsgCnclRsn").style.display = "";
                     return ret;
                 }
                 else {
                     strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                     strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                     strCancelReason = strCancelReason.replace(/\n /, "\n");
                     if (strCancelReason.length < "10") {
                         document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                         document.getElementById("txtCancelReason").style.borderColor = "red";
                         document.getElementById("divErrMsgCnclRsn").style.display = "";
                         return ret;
                     }
                     else {

                     }
                 }
                 if (ret == true) {
                     var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                     var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                     DeleteByID(strId, strCancelReason, strCancelMust);
                     $noCon('#dialog_simple').dialog('close');
                 }

                 return false;

             }

             function ChangeStatus(StrId, stsmode, cnclusrId) {
                 if (cnclusrId == "") {
                     var strUserID = '<%=Session["USERID"]%>';
                     ezBSAlert({
                         type: "confirm",
                         messageText: "Do you want to change the status of this welfare service?",
                         alertType: "info"
                     }).done(function (e) {
                         if (e == true) {
                             var Details = PageMethods.ChangeSrvcStatus(StrId, stsmode,strUserID, function (response) {
                                 var SucessDetails = response;
                                 if (SucessDetails == "success") {
                                     window.location = 'hcm_Emp_Welfare_Service_List.aspx?InsUpd=StsCh';
                                 }
                                 else {
                                     window.location = 'hcm_Emp_Welfare_Service_List.aspx?InsUpd=Error';
                                 }
                             });
                         }
                     });
                     return false;
                 }
             }
             // for not allowing <> tags
             function isTag(evt) {

                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

                 var charCode = (evt.which) ? evt.which : evt.keyCode;
                 var ret = true;
                 if (charCode == 60 || charCode == 62) {
                     ret = false;
                 }
                 return ret;
             }

             //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
             function textCounter(field, maxlimit) {
                 if (field.value.length > maxlimit) {
                     field.value = field.value.substring(0, maxlimit);
                 } else {

                 }
             }
             // for not allowing enter
             function DisableEnter(evt) {
                 evt = (evt) ? evt : window.event;
                 var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                 if (keyCodes == 13) {
                     return false;
                 }
             }
          </script>

    <style>
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
        }
    </style>
     <script>



        

    </script>
 
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
            
      <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
      <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
      <asp:HiddenField ID="HiddenEnableDelete" runat="server" />
      <asp:HiddenField ID="HiddenEnableModify" runat="server" />
          <asp:HiddenField ID="HiddenUsrId" runat="server" />
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <div class="cont_rght" >
        <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 0%;width: 98%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="../../../../Images/BigIcons/welfare-icon.PNG" style="vertical-align: middle;" />  Welfare Service 
        </div>       
            <div style="width:98%;border: 1px solid #065757;margin-top: 1%;background:#f4f6f0;">
                <div style="width:100%;margin-top:3%;">
         <div class="eachform" style="width: 30%;margin-left:1%;">
                <h2 style="margin-bottom: 0%;">From</h2>
               <input id="txtFromdate" runat="server" type="text" tabindex="1" style="width:65%;margin-left: 24%;" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtFromdate')" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />

            <script>
                $noCon('#cphMain_txtFromdate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
       </script>
            </div>
           <div class="eachform" style="width: 30%;margin-left:1%;">
                <h2 style="margin-bottom: 0%;">To</h2>
               <input id="txtTodate" runat="server" type="text" tabindex="2" style="width:65%;margin-left: 16%;" onkeypress="return DisableEnter(event)" onchange="DateChk('cphMain_txtTodate')" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />

            <script>
                $noCon('#cphMain_txtTodate').datepicker({
                    autoclose: true,
                    format: 'dd-mm-yyyy',
                    timepicker: false
                });
       </script>
            </div>
            <div class="eachform" style="width:25%; margin-bottom: 0%;">               
                <div class="subform" style="width: 215px; margin-bottom: 6%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" TabIndex="3" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>
               </div>

</div>
                <div style="width:100%;">
               <div class="eachform" style="width: 30%;margin-left:1%;">
                <h2 style="margin-bottom: 0%;">Designation</h2>
                     <asp:DropDownList ID="ddlDesignation" Height="30px" TabIndex="4" class="form1" runat="server" style="height:30px;width:66%;cursor: pointer;float: left;margin-left: 3%;cursor: pointer;">
                </asp:DropDownList>
            </div>

        <div class="eachform" style="width: 30%;margin-left:1%;">
                <h2 style="margin-bottom: 0%;">Status*</h2>
                <asp:DropDownList ID="ddlStatus" Height="30px"  Width="160px" TabIndex="5" class="form1" runat="server" Style="height:30px;width:66%;cursor: pointer;float: left;margin-left: 3%;cursor: pointer;">
                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>   
                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                     <asp:ListItem Text="All" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
      
                <div class="eachform" style="width:25%;float: right;">
                             <asp:Button ID="btnSearch"  style="cursor:pointer;" runat="server" TabIndex="6" class="searchlist_btn_lft" Text="Search" OnClientClick="return LoadEmployeeList();"  /> 
                     </div></div>
    </div>
            
        <br />

       <div id="divAdd"  onclick="location.href='hcm_Emp_welfare_service.aspx'" class="add" runat="server" style=" position: fixed; height:26.5px;right:0.7%;display:block">


        </div>
      <%--  <br />
        <br />--%>

          <div id="diEmployeeList" class="widget-body no-padding" style="margin-top: 0.5%;width: 98%;margin-left:0.2%;">
            <table id="datatable_fixed_column" class="table table-striped table-bordered" style="font-family: Calibri; width:100%">
                <thead>
                    <tr class="SearchRow" >
                        <th class="hasinput" style="width:25%">
                            <input  type="text" class="form-control" tabindex="7" placeholder="SERVICE NAME" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 25%">
                          <input  type="text" class="form-control" tabindex="8" placeholder="CATEGORY NAME" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 4%;"></th>  
                         <th class="hasinput" style="width: 8%;"></th>  
                        <th class="hasinput" style="width: 4%;"></th> 
                        <th class="hasinput" style="width: 4%;"></th>  
                    </tr>
                    <tr>
                         <th data-class="expand"style="color:#fff;font-size: 15px;">Service Name</th>                   
             
                        <th data-class="expand" style="text-align:center;font-size: 15px; color:#fff;" >Category Name</th>
                        <th data-class="expand" style="text-align:center; font-size: 15px; color:#fff;" >Status</th>
                        <th data-class="expand" style="text-align:center;font-size: 15px; color:#fff;" >Applicable</th>
                        <th data-class="expand" style="text-align:center; font-size: 15px; color:#fff;">Edit</th>
                         <th data-class="expand" style="text-align:center;font-size: 15px; color :#fff;">Delete</th>
                       
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="8" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>
        </div>




        <div id="divReport" class="table-responsive" runat="server" style="display:none;">
           
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


        
           
                                            <%--------------------------------View for error Reason--------------------------%>
          
        <div id="dialog_simple" title="Dialog Simple Title"style="display:none" >
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
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();"class="btn btn-default"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>
                   
                </div>
            </div>
                </div>  

    </div>
   
      <script>
          //for search option
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();
          function LoadEmployeeList() {
              var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';
              var EnableEdit = document.getElementById("<%=HiddenEnableModify.ClientID%>").value;
              var EnableDelete = document.getElementById("<%=HiddenEnableDelete.ClientID%>").value;
              var dtFromDate = document.getElementById("cphMain_txtFromdate").value;
              var dtToDate = document.getElementById("cphMain_txtTodate").value;
              var dtDesgn = document.getElementById("cphMain_ddlDesignation").value;
              var Status = document.getElementById("cphMain_ddlStatus").value;
              var CnclSts = 0;
              var responsiveHelper_datatable_fixed_column = undefined;
              var breakpointDefinition = {
                  tablet: 1024,
                  phone: 480
              };

              /* COLUMN FILTER  */
              if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                  CnclSts = 1;
                  var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                      'bProcessing': true,
                      'bServerSide': true,
                      'sAjaxSource': 'data.ashx',
                      "order": [[0, 'asc']],

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
                          aoData.push({ "name": "FROMDATE", "value": dtFromDate });
                          aoData.push({ "name": "TODATE", "value": dtToDate });
                          aoData.push({ "name": "DESIGNATION", "value": dtDesgn });
                          aoData.push({ "name": "STATUS", "value": Status });
                          aoData.push({ "name": "CANCEL", "value": CnclSts });
                      },
                      "columnDefs": [
                     
                          //{
                          //    "targets": [3],
                          //    "visible": true
                          //},
                          {
                              "targets": [4],
                              "visible": false
                          },
                          {
                              "targets": [5],
                              "visible": false
                          }
                      ],


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
              else {
                  if (EnableEdit == "Active" && EnableDelete == "Active") {
                      var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                          'bProcessing': true,
                          'bServerSide': true,
                          'sAjaxSource': 'data.ashx',
                          "order": [[0, 'asc']],
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
                              aoData.push({ "name": "FROMDATE", "value": dtFromDate });
                              aoData.push({ "name": "TODATE", "value": dtToDate });
                              aoData.push({ "name": "DESIGNATION", "value": dtDesgn });
                              aoData.push({ "name": "STATUS", "value": Status });
                              aoData.push({ "name": "CANCEL", "value": CnclSts });
                          },
                          "columnDefs": [
                                                     
                              {
                                  "targets": [4],
                                  "visible": true
                              },
                    {
                        "targets": [5],
                        "visible": true
                    }
                          ],
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
                  else if (EnableEdit != "Active" && EnableDelete == "Active") {
                      var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                          'bProcessing': true,
                          'bServerSide': true,
                          'sAjaxSource': 'data.ashx',
                          "order": [[0, 'asc']],
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
                              aoData.push({ "name": "FROMDATE", "value": dtFromDate });
                              aoData.push({ "name": "TODATE", "value": dtToDate });
                              aoData.push({ "name": "DESIGNATION", "value": dtDesgn });
                              aoData.push({ "name": "STATUS", "value": Status });
                              aoData.push({ "name": "CANCEL", "value": CnclSts });
                          },
                          "columnDefs": [
                                           {
                                  "targets": [4],
                                  "visible": flase
                              },
                    {
                        "targets": [5],
                        "visible": true
                    }
                          ],
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
                  else if (EnableEdit == "Active" && EnableDelete != "Active") {
                      var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                          'bProcessing': true,
                          'bServerSide': true,
                          'sAjaxSource': 'data.ashx',
                          "order": [[0, 'asc']],
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
                              aoData.push({ "name": "FROMDATE", "value": dtFromDate });
                              aoData.push({ "name": "TODATE", "value": dtToDate });
                              aoData.push({ "name": "DESIGNATION", "value": dtDesgn });
                              aoData.push({ "name": "STATUS", "value": Status });
                              aoData.push({ "name": "CANCEL", "value": CnclSts });
                          },
                          "columnDefs": [
                         
                              {
                                  "targets": [4],
                                  "visible": true
                              },
                    {
                        "targets": [5],
                        "visible": false
                    }
                          ],
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
                  else if (EnableEdit != "Active" && EnableDelete != "Active") {
                      var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                          'bProcessing': true,
                          'bServerSide': true,
                          'sAjaxSource': 'data.ashx',
                          "order": [[0, 'asc']],
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
                              aoData.push({ "name": "FROMDATE", "value": dtFromDate });
                              aoData.push({ "name": "TODATE", "value": dtToDate });
                              aoData.push({ "name": "DESIGNATION", "value": dtDesgn });
                              aoData.push({ "name": "STATUS", "value": Status });
                              aoData.push({ "name": "CANCEL", "value": CnclSts });
                          },
                          "columnDefs": [
                   
                              {
                                  "targets": [4],
                                  "visible": false
                              },
                    {
                        "targets": [5],
                        "visible": false
                    }
                          ],
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
              }
          }

    </script>
    <style>
        .table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
/*#datatable_fixed_column > thead > tr > th {
    background: #eee!important;
    color:#fff;
}*/
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.table {
    font-size: 13px;
}
.table-striped > tbody > tr:nth-of-type(2n+1) {
    background-color: #eaeaea;
}
        table.dataTable thead .sorting {
              background-color: #79895f;
        }
        table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
    background-color: #92a276;
}
        .table > thead > tr > th {
            padding: 8px 10px;
        }
        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }

        .table {
            color: #3e3737;
            font-weight: bolder;
        }
        </style>


</asp:Content>

