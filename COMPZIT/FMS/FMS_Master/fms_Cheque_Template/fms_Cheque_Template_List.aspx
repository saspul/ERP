<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Cheque_Template_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Cheque_Template_fms_Cheque_Template_List" %>

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


        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
            LoadEmpList();   
         //   loadTableDesg();
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

        function SuccessClose() {
            $noCon("#success-alert").html("Cheque template cancelled successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            
            return false;
        }

        var $noCon = jQuery.noConflict();
        //for search option
        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();

        function getdetails(href) {
            window.location = href;
            return false;
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
            LoadEmpList();
        }
        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this cheque template?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        document.getElementById("lblErrMsgCancelReason").style.display = "none";
                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
                        $('#dialog_simple').modal('show');
                    }
                    else {
                        DeleteByID(StrId, strCancelReason, strCancelMust);
                        $('#dialog_simple').modal('hide');
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
                var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, function (response) {
                    var SucessDetails = response;
                    if (SucessDetails == "successcncl") {
                        document.getElementById("<%=Hiddencncl.ClientID%>").value = "cncl"
                        window.location = "fms_Cheque_Template_List.aspx?InsUpd=cncl";
                    }
                    else {
                        window.location = "fms_Cheque_Template_List?InsUpd=Error";
                    }
                });
            }
            return false;
        }
        function CloseCancelView() {
            ReasonConfirm = document.getElementById("txtCancelReason").value;
            if (document.getElementById("<%=Hiddencnclsts.ClientID%>").value == "") {
                       ezBSAlert({
                           type: "confirm",
                           messageText: "Do you want to close  without completing cancellation process?",
                           alertType: "info"

                       }).done(function (e) {
                           if (e == true) {
                               // alert("1");
                               $('#dialog_simple').modal('hide');
                           }
                           else {
                               // alert("2");
                               $('#dialog_simple').modal('show');
                               return false;
                           }
                       });
                       //     alert();
                       //    $("#ezok-btn").focus();
                       return false;
                   }
               }
               function ValidateCancelReason() {
                   // replacing < and > tags

                   var ret = true;
                   document.getElementById("lblErrMsgCancelReason").style.display = "none";
                   document.getElementById("txtCancelReason").style.borderColor = "";
                   var strCancelReason = document.getElementById("txtCancelReason").value;
                   if (strCancelReason == "") {
                       document.getElementById("txtCancelReason").style.borderColor = "red";
                       document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                       document.getElementById("lblErrMsgCancelReason").style.display = "block";
                       $("div.war").fadeIn(200).delay(500).fadeOut(400);
                       return ret;
                   }
                   else {
                       strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                       strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                       strCancelReason = strCancelReason.replace(/\n /, "\n");
                       if (strCancelReason.length < "10") {
                           document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                           document.getElementById("txtCancelReason").style.borderColor = "red";
                           document.getElementById("lblErrMsgCancelReason").style.display = "block";
                           $("div.war").fadeIn(200).delay(500).fadeOut(400);
                           return ret;
                       }
                       else {

                       }
                   }

                if (ret == true) {
                var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                DeleteByID(strId, strCancelReason, strCancelMust);
                $('#dialog_simple').modal('hide');
            }
            return false;
        }
        function ErrorCancelation() {
            $noCon("#divWarning").html("Try again!");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            
            ddlStatus.Focus();
            return false;
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenEditID" runat="server" />
    <asp:HiddenField ID="hiddenViewID" runat="server" />
    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />
    <asp:HiddenField ID="hiddenDeleteID" runat="server" />
    <asp:HiddenField ID="HiddenRoleEdit" runat="server" />
    <asp:HiddenField ID="HiddenRoleAllDiv" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="Hiddencnclsts" runat="server" />
    <asp:HiddenField ID="Hiddencncl" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
    <%-- emp0025--%>

    <asp:Button ID="btnEdit" runat="server" Text="Button" style="display:none"/>

    <ol class="breadcrumb">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Cheque Template</li>
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
    <div class="content_area_container cont_contr">
        <div class="content_box1 cont_contr">
            <h1>Cheque Template</h1>
            <div class="fg2">
                <label class="form1 mar_bo mar_tp">
                    <span class="button-checkbox">
                        <input name="checkbox-inline" id="CbxCnclStatus" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" runat="server" type="checkbox" />
                        <button type="button" class="btn-d" data-color="p"></button>
                    </span>
                    <p class="pz_s">Show Deleted Entries</p>
                </label>
            </div>
            <div class="fg2">
                <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                <asp:Button ID="btnCnclSearch" runat="server" class="submit_ser" OnClick="btnCnclSearch_Click" />
            </div>

            <div class="clearfix"></div>

            <div class="devider divid"></div>
            <div id="divAdd" onclick="location.href='fms_Cheque_Template.aspx'" class="add" runat="server">
                <a href="fms_Cheque_Template.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                    <i class="fa fa-plus-circle"></i>
                </a>
            </div>

            <div id="divList" runat="server" class="widget-body" style="margin-top: 2%; width: 99%;">
                <br />
                <br />
            </div>

        </div>
    </div>
                   
    <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

