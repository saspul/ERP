<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Leave_Settlement_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Leave_Settment_hcm_Leave_Settlement_List" %>

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

    <script type="text/javascript">
           var $noCon = jQuery.noConflict();
           $noCon(window).load(function () {

               document.getElementById("<%=ddlEmployee.ClientID%>").focus();
               $noCon("#divddlEmployee input.ui-autocomplete-input").focus();
               $noCon("#divddlEmployee input.ui-autocomplete-input").select();

               LoadLeavSettlmtList();
               loadTableDesg();

               //messages
               var session = '<%=Session["SUCCESS"]%>';

               if (session == "SAVE") {
                   AddSuccesMessage();
               }
               else if (session == "UPDATE") {
                   UpdateSuccesMessage();
               }
               else if (session == "CONFIRM") {
                   ConfirmSuccesMessage();
               }
               else if (session == "DELETE") {
                   DeleteSuccesMessage();
               }
               else if (session == "PAID") {
                   PaidSuccesMessage();
               }
               '<%Session["SUCCESS"] = '"' + null + '"'; %>';

           });


        function loadTableDesg() {
            var $noC = jQuery.noConflict();
            $noC(function () {

                $noCon('#dialog_simple').dialog({
                    autoOpen: false,
                    width: 600,
                    resizable: false,
                    modal: true,
                    title: "Leave Settlement",
                    //position: 'top'

                });

            });
        }
        //show messages 
        function AddSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details inserted successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }
        function UpdateSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details updated successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }
        function ConfirmSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details confirmed successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }
        function DeleteSuccesMessage() {

            $noCon("#divdatealert").html("Leave settlement details cancelled successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }

        function PaidSuccesMessage() {
            $noCon("#divdatealert").html("Leave settlement payment process paid successfully.");
            $noCon("#divdatealert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divdatealert").alert();
            return false;
        }

        function LeavSettmtViewId(viewid) {

            document.getElementById("<%=hiddenViewValue.ClientID%>").value = viewid;
            //document.getElementById('<%=btnView.ClientID %>').click();
            var nWindow = window.open('/HCM/HCM_Master/hcm_PayrollSystem/hcm_Leave_Settment/hcm_Leave_Settlement.aspx?READ=' + viewid + '', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
            return false;
        }

     </script>


    <script>
        function EditRow(strId) {
         
            document.getElementById("<%=hiddenEdit.ClientID%>").value = strId;
            document.getElementById('<%=btnEdit.ClientID %>').click();
            return false;
        }

        function ViewRow(strId) {           
            document.getElementById("<%=hiddenViewId.ClientID%>").value = strId;
            document.getElementById("<%=btnEdit.ClientID%>").click();
            return false;
        }

        function CancelRow(strId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to Delete?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    var strCancelMust = document.getElementById("<%=hiddenCnclrsnMust.ClientID%>").value;
                    document.getElementById("<%=hiddenDeleteID.ClientID%>").value = strId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        document.getElementById("divErrMsgCnclRsn").style.display = "none";
                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
                        $noCon('#dialog_simple').dialog('open');
                    }
                    else {
                        DeleteByID(strId, strCancelReason, strCancelMust);
                    }

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

                var objOrg2 = {};
                objOrg2.strLevSettlmntId = strId.toString();
                objOrg2.strUserId = strUserID.toString();
                objOrg2.strCancelReason = strCancelReason.toString();
                objOrg2.strCancelMust = strCancelMust.toString();
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_Leave_Settlement_List.aspx/CancelLeaveSettlmt",
                    data: JSON.stringify(objOrg2),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        result = response.d;

                        if (result == "TRUE") {

                            window.location = "hcm_Leave_Settlement_List.aspx";

                        }

                    },
                    failure: function (response) {

                    }
                });
            }

            return false;
        }


        function CancelNotPossible() {
            alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            return false;
        }


    </script>

     <script>
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

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    
    <asp:HiddenField ID="hiddenViewValue" runat="server" />

    <asp:HiddenField ID="hiddenEdit" runat="server" />
         <asp:HiddenField ID="hiddenViewId" runat="server" />
    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />
     <asp:HiddenField ID="hiddenDeleteID" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
         <asp:HiddenField ID="hiddenConfrm" runat="server" />
        <asp:HiddenField ID="hiddenPaidMode" runat="server" />


    <asp:Button ID="btnEdit" runat="server" Text="Button" OnClick="btnEdit_Click" style="display:none"/>

    <asp:Button ID="btnView" runat="server" Text="Button"  OnClick="btnView_Click" style="display:none"/>

     <div class="alert alert-success" id="divdatealert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

    <div class="cont_rght">

            <div onclick="location.href='hcm_Leave_Settlement.aspx'" id="divAdd" class="add" runat="server" style="position: fixed; height:26.5px; right:0%;margin-top: 2%; z-index: 1;">
        </div>

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Leave Settlement.png" style="vertical-align: middle;" />
           Leave Settlement List
        </div >

        <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 93.5%; margin-top: 1%;height: 88px;">

            <div id="divddlEmployee" style="width: 100%; float: left;" class="formdiv">
                <div style="width: 35%; float: left;">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Employee</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>

                        </label>
                    </section>
                </div>

                 <div style="width: 31%; float: left;">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Status</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control" class="form1" runat="server" onkeypress="return DisableEnter(event)">
                            <asp:ListItem Text="Not Confirmed" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Confirmed" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Payment Pending" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Paid" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Closed" Value="4"></asp:ListItem>
                            </asp:DropDownList>

                        </label>
                    </section>
                </div>

                <div style="float: left;margin-left: 4%;margin-top: 0.5%;" class="smart-form">
                    <section style="width: 95%; margin-left: 5%;">

                        <label class="checkbox">
                            <input name="cphMain_cbxCnclStatus" id="cbxCnclStatus" runat="server" onkeydown="return DisableEnter(event);" type="checkbox" />
                            <i></i>Show Deleted Entries</label>
                    </section>
                </div>

                <div style="float: right;margin-right: 4%;">
                    <asp:Button ID="btnSearch" Style="cursor: pointer; float: right; margin-right: 10%;" runat="server" class="btn  btn-primary" Text="Search" OnClick="btnSearch_Click" />

                </div>
             </div>


        </div>


         <div id="divList" runat="server" class="widget-body" style="margin-top:2%;width: 93.5%;">
             <br />
             <br />
         </div>



               <%--------------------------------View for error Reason--------------------------%>


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
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" style="text-transform: uppercase; resize: none;"></textarea>
                        </label>

                    </section>
                </div>

                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return validateSaveCancelRsn();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" class="btn btn-default"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>

                </div>
            </div>

     </div>

   </div>
   
    <script>
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
                    var ItemID = document.getElementById("<%=hiddenDeleteID.ClientID%>").value;
                            var strCancelMust = document.getElementById("<%=hiddenCnclrsnMust.ClientID%>").value;
                            DeleteByID(ItemID, strCancelReason, strCancelMust);
                            $noCon('#dialog_simple').dialog('close');
                        }

                    }
                    return false;
                }
            </script>


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

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />


    <script>
        var $au = jQuery.noConflict();

        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });
    </script>

     <style>
        table.dataTable tbody td {
            word-break:break-all;          
        }
        
         .table {
            font-size:13px;
        }
          
        #datatable_fixed_column_wrapper {
            border: 1px solid #ddd;
        }
    </style>



    <script>
        var $noCon4JS = jQuery.noConflict();
        function ezBSAlert(options) {
            var deferredObject = $noCon4JS.Deferred();
            var defaults = {
                type: "alert", //alert, prompt,confirm 
                modalSize: 'modal-sm', //modal-sm, modal-lg
                okButtonText: 'Ok',
                cancelButtonText: 'Cancel',
                yesButtonText: 'Yes',
                noButtonText: 'No',
                headerText: 'Attention',
                messageText: 'Message',
                alertType: 'default', //default, primary, success, info, warning, danger
                inputFieldType: 'text', //could ask for number,email,etc
            }
            $noCon4JS.extend(defaults, options);

            var _show = function () {
                var headClass = "navbar-default";
                switch (defaults.alertType) {
                    case "primary":
                        headClass = "alert-primary";
                        break;
                    case "success":
                        headClass = "alert-success";
                        break;
                    case "info":
                        headClass = "alert-info";
                        break;
                    case "warning":
                        headClass = "alert-warning";
                        break;
                    case "danger":
                        headClass = "alert-danger";
                        break;
                }
                $noCon4JS('BODY').append(
                    '<div id="ezAlerts" class="modal fade">' +
                    '<div class="modal-dialog" class="' + defaults.modalSize + '">' +
                    '<div class="modal-content">' +
                    '<div id="ezAlerts-header" class="modal-header ' + headClass + '">' +
                    '<button id="close-button" type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>' +
                    '<h4 id="ezAlerts-title" class="modal-title">Modal title</h4>' +
                    '</div>' +
                    '<div id="ezAlerts-body" class="modal-body">' +
                    '<div id="ezAlerts-message" ></div>' +
                    '</div>' +
                    '<div id="ezAlerts-footer" class="modal-footer">' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>'
                );

                $noCon4JS('.modal-header').css({
                    'padding': '15px 15px',
                    '-webkit-border-top-left-radius': '5px',
                    '-webkit-border-top-right-radius': '5px',
                    '-moz-border-radius-topleft': '5px',
                    '-moz-border-radius-topright': '5px',
                    'border-top-left-radius': '5px',
                    'border-top-right-radius': '5px'
                });

                $noCon4JS('#ezAlerts-title').text(defaults.headerText);
                $noCon4JS('#ezAlerts-message').html(defaults.messageText);

                var keyb = "false", backd = "static";
                var calbackParam = "";
                switch (defaults.type) {
                    case 'alert':
                        keyb = "true";
                        backd = "true";
                        $noCon4JS('#ezAlerts-footer').html('<button class="btn btn-' + defaults.alertType + '">' + defaults.okButtonText + '</button>').on('click', ".btn", function () {
                            calbackParam = true;
                            $noCon4JS('#ezAlerts').modal('hide');
                        });
                        break;
                    case 'confirm':
                        var btnhtml = '<button id="ezok-btn" class="btn btn-primary">' + defaults.yesButtonText + '</button>';
                        if (defaults.noButtonText && defaults.noButtonText.length > 0) {
                            btnhtml += '<button id="ezclose-btn" class="btn btn-default">' + defaults.noButtonText + '</button>';
                        }
                        $noCon4JS('#ezAlerts-footer').html(btnhtml).on('click', 'button', function (e) {
                            if (e.target.id === 'ezok-btn') {
                                calbackParam = true;
                                $noCon4JS('#ezAlerts').modal('hide');
                            } else if (e.target.id === 'ezclose-btn') {
                                calbackParam = false;
                                $noCon4JS('#ezAlerts').modal('hide');
                            }
                        });
                        break;
                    case 'prompt':
                        $noCon4JS('#ezAlerts-message').html(defaults.messageText + '<br /><br /><div class="form-group"><input type="' + defaults.inputFieldType + '" class="form-control" id="prompt" /></div>');
                        $noCon4JS('#ezAlerts-footer').html('<button class="btn btn-primary">' + defaults.okButtonText + '</button>').on('click', ".btn", function () {
                            calbackParam = $noCon4JS('#prompt').val();
                            $noCon4JS('#ezAlerts').modal('hide');
                        });
                        break;
                }

                $noCon4JS('#ezAlerts').modal({
                    show: false,
                    backdrop: backd,
                    keyboard: keyb,
                    timeout: 40
                }).on('hidden.bs.modal', function (e) {
                    $noCon4JS('#ezAlerts').remove();
                    deferredObject.resolve(calbackParam);
                }).on('shown.bs.modal', function (e) {
                    if ($noCon4JS('#prompt').length > 0) {
                        $noCon4JS('#prompt').focus();
                    }
                }).modal('show');
            }

            _show();
            return deferredObject.promise();
        }
    </script>




      <script>
          function ToPaid(Id, RowCount) {
              ezBSAlert({
                  type: "confirm",
                  messageText: "Are you sure you want to pay the settlement?",
                  alertType: "info"
              }).done(function (e) {
                  if (e == true) {
                  var objId = {};
                  objId.Id = Id
                  $noCon.ajax({
                      async: false,
                      type: "POST",
                      url: "hcm_Leave_Settlement_List.aspx/UpdateSettledStatus",
                      data: JSON.stringify(objId),
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {
                          result = response.d;
                          if (result == "TRUE") {
                              document.getElementById("cphMain_btnSearch").click();
                              //window.location = "hcm_End_Service_Leave_Stlmnt_List.aspx";
                          }

                      },
                      failure: function (response) {
                      }
                  });
                  }
                  else {
                      return false;
                  }
              });
              return false;
          }

          function ToPaidAll() {

              ezBSAlert({
                  type: "confirm",
                  messageText: "Are you sure you want to pay all the listed settlement?",
                  alertType: "info"
              }).done(function (e) {

                  if (e == true) {
                      var strOrgID = '<%=Session["ORGID"]%>';
                  var strCorpID = '<%=Session["CORPOFFICEID"]%>';
                  var objId = {};
                  objId.strOrgID = strOrgID;
                  objId.strCorpID = strCorpID;
                  $noCon.ajax({
                      async: false,
                      type: "POST",
                      url: "hcm_Leave_Settlement_List.aspx/PaidAll_UpdateSettledStatus",
                      data: JSON.stringify(objId),
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function (response) {
                          result = response.d;
                          if (result == "TRUE") {
                              document.getElementById("cphMain_btnSearch").click();
                          }

                      },
                      failure: function (response) {
                      }
                  });
                  }
                  else {
                    return false;
                   }
              });

            return false;

        }
    </script>


   
</asp:Content>

