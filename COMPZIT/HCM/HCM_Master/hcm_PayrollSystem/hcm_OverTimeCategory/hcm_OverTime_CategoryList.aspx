<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_OverTime_CategoryList.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_OverTimeCategory_hcm_OverTime_CategoryList" %>

   
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
    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="/js/HCM/Common.js"></script>


         <script type="text/javascript">
             var $noCon = jQuery.noConflict();
             $noCon(window).load(function () {
                 // $noCon('#filSearch').focus();
                loadTableDesg();
                LoadOvertimeCategCnclList(0);
                
                 //messages
                var SuccessMsg = document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value;

                if (SuccessMsg == "SAVE") {
                    AddSuccesMessage();
                }
                else if (SuccessMsg == "UPDATE") {
                    UpdateSuccesMessage();
                }
                else if (SuccessMsg == "DELETE") {
                    DeleteSuccesMessage();
                }
                document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value = "0";
                 $noCon("#datatable_fixed_column_wrapper input.form-control:first").focus();
             });


             //show messages 

             function AddSuccesMessage() {
                 $noCon("#success-alert").html("Over time category details inserted successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                 $noCon("#success-alert").alert();

                 return false;
             }
             function UpdateSuccesMessage() {
                 $noCon("#success-alert").html("Over time category details updated successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                 $noCon("#success-alert").alert();

                 return false;
             }

             //for cancel reson popup
             function DeleteSuccesMessage() {
                 $noCon("#success-alert").html("Over time category cancelled successfully.");
                 $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                 });
                 $noCon("#success-alert").alert();

                 return false;
             }

           
             function loadTableDesg() {
                 var $noCon = jQuery.noConflict();
                 $noCon(function () {
                     $noCon('#dialog_simple').dialog({
                         autoOpen: false,
                         width: 600,
                         resizable: false,
                         modal: true,
                         title: "Over time category",
                     });
                 });
             }

             //for search option
             var $NoConfi = jQuery.noConflict();
             var $NoConfi3 = jQuery.noConflict();

             function LoadOvertimeCategCnclList(CnclSts) {
                 document.getElementById("<%=HiddenViewId.ClientID%>").value = CnclSts;
                 if (CnclSts == 1) {

                 $NoConfi('#otable').DataTable({
                         "columnDefs": [
                             {
                                 "targets": [2],
                                 "visible": false,
                                 "searchable": false
                             },
                             {
                                 "targets": [3],
                                 "visible": false
                             }
                         ]
                     });
               

             }
                 var orgID = '<%= Session["ORGID"] %>';
                 var corptID = '<%= Session["CORPOFFICEID"] %>';
                 var userId = '<%= Session["USERID"] %>';

             var responsiveHelper_datatable_fixed_column = undefined;

             var breakpointDefinition = {
                 tablet: 1024,
                 phone: 480
             };

             /* COLUMN FILTER  */
             var otable = $NoConfi3('#datatable_fixed_column').DataTable({

                 'bProcessing': true,
                 'bServerSide': false,
             

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
   
             });
             //var otable = $NoConfi('#datatable_fixed_column').DataTable({


             //});

             // Apply the filter

             $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                 otable
                     .column($NoConfi(this).parent().index() + ':visible')
                     .search(this.value)
                     .draw();

             });
             /* END COLUMN FILTER */
           
         }
    
    </script>

    <script>


        function getEditRow(StrId) {
         
            document.getElementById("<%=HiddenEditId.ClientID%>").value = StrId;
            window.location = 'hcm_OverTime_Category_Master.aspx?Id=' + StrId;
            return false;
        }
        //evm-0027
        function CancelNotPossible() {
            alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
            return false;

        }
        //end
        function OpenCancelView(StrId)
        {
            
            //EVM-0027 

                var SearchString = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
            if (confirm("Do you want to delete  this overtime category?")) {
                if (SearchString == 1) {
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;

                    document.getElementById("txtCancelReason").value = "";
                    document.getElementById("divErrMsgCnclRsn").style.display = "none";
                    document.getElementById("txtCancelReason").style.borderColor = "";
                    $noCon('#dialog_simple').dialog('open');
                    return false;
                }
                else {


                    var OvrtmID = document.getElementById("<%=HiddenEditId.ClientID%>").value;
                    var OvrtmReason = "";
                    var strReasonMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    var UserId = '<%=Session["USERID"]%>';

                    var Details = PageMethods.ChangeOvrtmCancel(StrId, OvrtmReason, strReasonMust, UserId, function (response) {

                        var SucessDetails = response;

                        if (SucessDetails == "success") {
                            if (SearchString == "") {
                                window.location = 'hcm_OverTime_CategoryList.aspx';
                            }
                            else {
                                window.location = 'hcm_OverTime_CategoryList.aspx';

                            }
                        }
                        else {

                            window.location = 'hcm_OverTime_CategoryList.aspx';
                        }
                    });
                }
            }
            else
            {
               // window.location = 'hcm_OverTime_CategoryList.aspx';
            }
        }

        function CloseCancelView() {
            
            ReasonConfirm = document.getElementById("txtCancelReason").value;
            //alert(ReasonConfirm);
            if (ReasonConfirm != "") {
                if (confirm("Do you want to close  without completing cancellation process?")) {
                    window.location = 'hcm_OverTime_CategoryList.aspx';
                }
            }
            else {
                window.location = 'hcm_OverTime_CategoryList.aspx';
            }
           
        }

        function CancelAlert(href) {
                window.location = href;
                return false;
        }

        function CancelCategory() {
            //   SuccessCancelation();
            
            if (document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value != null) {
                var OvrtmID = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                var OvrtmReason = "";
                var strReasonMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;

                var UserId = '<%=Session["USERID"]%>';

                if (validateSaveCancelRsn() == true) {
                    var SearchString = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    var Details = PageMethods.ChangeOvrtmCancel(OvrtmID, OvrtmReason, strReasonMust, UserId, function (response) {
                        var SucessDetails = response;

                        if (SucessDetails == "success") {
                            if (SearchString == "") {
                                window.location = 'hcm_OverTime_CategoryList.aspx';
                            }
                            else {
                                window.location = 'hcm_OverTime_CategoryList.aspx';
                            }
                        }
                        else {
                            window.location = 'hcm_OverTime_CategoryList.aspx';
                        }
                    });
                  
                    SuccessCancelation();
                }
            }
        }

        function SuccesMessage() {

            SuccessMsg("SAVE", "Saved Successfully.");
            return false;
        }

      
    </script>
 
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      

        <asp:HiddenField ID="HiddenEditId" runat="server" />
     <asp:HiddenField ID="HiddenViewId" runat="server" />
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="hiddenCancelId" runat="server" />
    <asp:HiddenField ID="HiddenStrReason" runat="server" />

     <asp:HiddenField ID="hiddenViewStatus" runat="server" />
    
    <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <asp:HiddenField ID="HiddenSuccessMsgType" Value="0" runat="server" />

         


    <%--<input type="submit" name="btnRedirect" id="btnRedirect" runat="server" onserverclick="btnRedirect_Click" />--%>
       <asp:Button ID="btnRedirect" runat="server" style="display:none" Text="Button" OnClick="btnRedirect_Click" />

       <div class="cont_rght" >
                        <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 5%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
                   <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;margin-left: 0%;
margin-bottom: 0%;">
            <img src="/Images/BigIcons/over-time-categories.png" style="vertical-align: middle;" />
           Over Time Category
        </div >

           <br />

    <div onclick="location.href='hcm_OverTime_Category_Master.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;z-index:1">

    </div>

             <div class="smart-form" style="float: left;margin-left:0%;">

             <div style="width: 99.7%; float: left;  border: 1px solid #c3c3c3;margin-left:-13px;height: 50px; background:#fafafa;margin-bottom: 7px;">


                                <div style="width: 45%; float: right;">               
                          <asp:Button ID="btnCnclSearch" style="margin-top:2.3%; height:26px;cursor:pointer; width: 104px;" runat="server" class="btn btn-primary" Text="Search" OnClick="btnCnclSearch_Click"/>     
               </div>
            <div style=" width: 55%; float: right;">
                
                        <section style="width:38%;float:right;margin-top:2.4%;margin-bottom:0px;">
                      
                <label class="checkbox" style="float: left;">
                <input name="checkbox-inline" id="CbxCnclStatus" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" runat="server"  type="checkbox" />
                 <i></i></label>
                            <label class="lblh2" style="float: left;width: 70%;Height:33px;margin-top:0.7%;"> <h class="page-title txt-color-blueDark">Show Deleted Entries </h></label>
                 </section> 
        
                </div>


                        </div>
      <div id="divReport" class="widget-body no-padding" style="width: 100%;" runat="server">
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
                        <button type="button" id="btnCancelRsnSave" onclick="return CancelCategory();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();"class="btn btn-default"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>
                   
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
                            var StrId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
                            var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                           
                            $noCon('#dialog_simple').dialog('close');
                        }

                    }
                    return true;
                }






            </script>


            <style>
                    td:nth-child(2), th:nth-child(2) {
                    text-align: right;
                }

                td:nth-child(3), th:nth-child(3),
                td:nth-child(4), th:nth-child(4),
                td:nth-child(5), th:nth-child(5) {
                    text-align: center;
                }

                table.dataTable tbody td {
                    word-break: break-all;
                }

                .table {
                    font-size: 13px;
                }
                .dataTables_filter .input-group-addon {
                    padding-top: 6px;
                }

                .glyphicon-search::before {
                    content: url(/Images/HCM/Img/Icons/search.png);
                    margin-left: -43%;
                }

                #datatable_fixed_column_wrapper {
                    border: 1px solid #ddd;
                }
                .input-group-addon {

                    height: 18px!important;
                }
                .dt-toolbar {
                   width: 98.7%;
                }
                #divGreySection {
                    background-color: #efefef;
                    border: 1px solid;
                    border-color: #cfcfcf;
                    padding: 15px;
                    height: auto;
                    margin-top: 4%;
                    width: 100%;
                }
                #datatable_fixed_column_filter {
                    padding-bottom: .5%;
                }
                .cont_rght {
                    padding: 30px 0 0;
                }
                .col-sm-12 {
                    box-sizing: border-box;
                    position: relative;
                    padding-left: 16px;
                    padding-right: 16px;
                }
                #cphMain_divReport {
    overflow-x: hidden;
}
                .table {
    font-size: 11px;
}


            </style>
</asp:Content>

