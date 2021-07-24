<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Emp_Conduct_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Employee_Conduct_Management_hcm_Emp_Conduct_hcm_Emp_Conduct_List" %>

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
    <%--<link href="/css/HCM/main.css" rel="stylesheet" />--%>
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/datepicker/bootstrap-datepicker.js"></script>
    <link href="/js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
    <style>
        #ReportTable_filter input {

    height: 32px;
    width: 176px;
    color: #336B16;
    font-size: 14px;

}
    </style>

    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        function ConductSuccessInsertion() {
            $noCon("#success-alert").html("Message send  successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;

        }
       </script>

    <script>
    
        function EditItem(ItemID) {

            document.getElementById("<%=hiddenEditID.ClientID%>").value = ItemID;
            document.getElementById("<%=hiddenViewID.ClientID%>").value = "0";
            document.getElementById('<%= btnEdit.ClientID %>').click();

            return false;
        }
        function ViewItem(ItemID) {
            document.getElementById("<%=hiddenEditID.ClientID%>").value = "0";
            document.getElementById("<%=hiddenViewID.ClientID%>").value = ItemID;
            document.getElementById('<%= btnEdit.ClientID %>').click();
            return false;
        }
        function DeleteItem(ItemID) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this entry?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=hiddenCnclrsnMust.ClientID%>").value;
                    document.getElementById("<%=hiddenDeleteID.ClientID%>").value = ItemID;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {

                        document.getElementById("divErrMsgCnclRsn").style.display = "none";
                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
                        $noCon('#dialog_simple').dialog('open');

                    }
                    else {
                        DeleteByID(ItemID, strCancelReason, strCancelMust);
                    }
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;

        }
        function DeleteByID(ItemID, strCancelReason, strCancelMust) {

            var strUserID = '<%=Session["USERID"]%>';
            if (strUserID == '') {

            }

            if (ItemID != "" && strUserID != '') {
                var objOrg2 = {};
                objOrg2.strServiceLveSttlmntID = ItemID
                objOrg2.strUserID = strUserID;
                objOrg2.strCancelReason = strCancelReason
                objOrg2.strCancelMust = strCancelMust
                $noCon.ajax({
                    async: false,
                    type: "POST",
                    url: "hcm_End_Service_Leave_Stlmnt_List.aspx/CancelServiceStlmnt",
                    data: JSON.stringify(objOrg2),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        result = response.d;

                        if (result == "TRUE") {
                            

                        }

                    },
                    failure: function (response) {

                    }
                });
            }
            return false;
        }

        function loadDialogue() {
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
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            LoadEmpList();
            loadDialogue();
        });

        function getdetails(href) {
            window.location = href;
            return false;
        }

     
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
            var otable = $NoConfi3('#ReportTable').DataTable({
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
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($NoConfi3('#ReportTable'), breakpointDefinition);
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
            $NoConfi("#ReportTable thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });




            /* END COLUMN FILTER */

        }
      

        
     


       
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:HiddenField ID="hiddenEditID" runat="server" />
    <asp:HiddenField ID="hiddenViewID" runat="server" />
    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />
    <asp:HiddenField ID="hiddenDeleteID" runat="server" />
     <asp:HiddenField ID="HiddenDivApprove" runat="server" />
    
    <asp:Button ID="btnEdit" runat="server" Text="Button"  style="display:none"/>

    <div class="alert alert-success" id="divdatealert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>
        <div class="cont_rght">
              <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>

           <%-- <div onclick="location.href='hcm_Emp_Conduct_Incident.aspx'" id="divAdd" class="add" runat="server" style="position: fixed; height:26.5px; right:0%;margin-top: 2%; z-index: 1;">
        </div>--%>

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Employee_Conduct_big.png" style="vertical-align: middle;" />
          Employee Conduct List
        </div >
       
        


         <div id="divList" runat="server" class="widget-body" style="margin-top:2%;">
             <br />
             <br />
         </div>



               <%--------------------------------View for error Reason--------------------------%>


        <div id="dialog_simple" title="Dialog Simple Title" style="display:none;">
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
      <style>
        .fa {
            font-size: large;
        }
          #ReportTable_length select {
              width: 60px;
          }
    </style>

</asp:Content>

