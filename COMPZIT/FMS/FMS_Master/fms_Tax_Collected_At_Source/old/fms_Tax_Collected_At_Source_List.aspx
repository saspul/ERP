<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzitFinance.master" AutoEventWireup="true" CodeFile="fms_Tax_Collected_At_Source_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Tax_Collected_At_Source_fms_Tax_Collected_At_Source_List" %>

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
    <style>
        .fa {
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
        font-size: 14px;
    font-size: large;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}
.table {
    font-family: OpenSans Semibold;
    text-transform: none;
    font-size: 10px;
    color: #5d5d5d;
}
  
    </style>
 <script src="/js/HCM/Common.js"></script>

    <script>


        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {

            loadTableDesg();
            LoadEmpList();   // emp0025

            //   loadTableDesg();

        });


        function loadTableDesg() {

            $noCon(function () {
                $noCon('#dialog_simple').dialog({
                    autoOpen: false,
                    width: 600,
                    resizable: false,
                    modal: true,
                    title: "Tax Collected at Source",
                });
            });
        }
        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this tax details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                           document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
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

        function LoadEmpList() {      // emp0025


            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';



            var responsiveHelper_datatable_fixed_column = undefined;


            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            /* COLUMN FILTER  */
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({
                //"bfilter": false,
                //"binfo": false,
                //"blengthchange": false
                //"bautowidth": false,
                // "bpaginate": false,
                //"bstatesave": true // saves sort state using localstorage
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

            // custom toolbar
            //$NoConfi("div.toolbar").html('<div class="text-right"><select / style="Margin-top:10px;"></div>');

            // Apply the filter
            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });




            /* END COLUMN FILTER */

        }


        function SuccessCancelation() {



            $noCon("#success-alert").html("Tax details cancelled successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function SuccessUpdate() {



            $noCon("#success-alert").html("Performance evaluation updatesd successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function ErrorCancelation() {



            $noCon("#divWarning").html("Try again!");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();

            return false;
        }
        function SuccessConfirm() {



            $noCon("#success-alert").html("Performance evaluation confirmed successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

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
            // after update occur on UpdatePanel re-init the Autocomplete
            LoadEmpList();

        }
        function DeletePerfomanceTmplt(Id) {
            // alert(Id);
        }



        var $con2 = jQuery.noConflict();

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
      <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
     <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
        <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
     <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
     <asp:HiddenField ID="HiddenSearchField" runat="server" />
    <asp:HiddenField ID="Hiddenenabledit" runat="server" />
        <asp:HiddenField ID="Hiddenenabladd" runat="server" />
          <asp:HiddenField ID="HiddenusrId" runat="server" />
          <asp:HiddenField ID="Hiddencnclsts" runat="server" />
     <asp:HiddenField ID="HiddenSuccessMsgType" runat="server" />
     <div class="cont_rght" >
         <div class="alert alert-success" id="success-alert" style="display: none;margin-left: 0%;width: 98%;">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
         
     
            
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
           
                 <img src="/Images/BigIcons/TCS.png" style="vertical-align: middle;"  />  <asp:Label ID="lblEntry" runat="server">Tax Collected at Source</asp:Label>
            </div>
     <div style="border:.1px solid #c3c3c3; background: #fafafa;width: 99%;margin-top:2%;padding: 1%;float: left;margin-left: 0%;">
            <div class="eachform" style="width: 22%;margin: 0 0 0px;">

                <h2 style="margin-top:1%;">Status</h2>

                <asp:DropDownList ID="ddlStatus" Height="30px" Width="160px" class="form1" runat="server" Style="margin-left: 15%;">
                   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                    <asp:ListItem Text="All" Value="2"></asp:ListItem>
                   
                </asp:DropDownList>

                 </div>
           <div id="divchkbx" class="eachform" style="width: 19%;margin-left: 10%;margin-bottom:     0px;">
            <div class="subform" style="width:215px;float: left;margin-left: 0%;">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" onkeypress="return DisableEnter(event);" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                </div>
           </div>
          <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:10%;"  runat="server" class="btn  btn-primary" Text="Search" OnClientClick="return LoadEmpList();" OnClick="btnSearch_Click" />

                  </div>
      <br />
            <br />
                 <br />
            <br />

                 <div onclick="location.href='fms_Tax_Collected_At_Source.aspx'" id="divAdd" class="add"  runat="server" style=" position: fixed; height:26.5px; right:1%;z-index: 1;">
            </div>
       
                <br />
            <br />
                 
          <div id="divList" runat="server" class="widget-body" style="margin-top:2%;width: 99%;">
             <br />
             <br />
         </div>

               
               <%--------------------------------View for error Reason--------------------------%>


        <%--<div id="Div1" title="Dialog Simple Title"  style="display:none;">
            <!-- widget content -->

            <div class="widget-body no-padding" id="div2">

                <div class="alert alert-danger fade in" id="div3" style="display: none; margin-top: 1%">

                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="Label1"> Please fill this out</label>
                </div>

                <div style="width: 100%; float: left; clear: both; margin-top: 5%">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Cancel Reason*</label>

                        <label class="input" style="float: left; width: 60%;">
                            <textarea name="txtCancelReason" rows="2" cols="20" id="Textarea1" class="form-control" style="text-transform: uppercase; resize: none;"   onkeydown="textCounter(txtCancelReason,500)" onkeyup="textCounter(txtCancelReason,500)"></textarea>
                        </label>

                    </section>
                </div>

                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="Button1" onclick="return ValidateCancelReason();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" class="btn btn-default" onclick="return CloseCancelView();"  ><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>

                </div>
            </div>

     </div>--%>


           
             
        

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
    <script>
        $(function () {
           
           // event.preventDefault();
        //    $noCon(".ui-dialog-titlebar-close").click(function (event) {
        //        alert("dfg");
        //      //  event.preventDefault();
        //    });
        //});
    </script>
    <div id="dialog_simple" title="Dialog Simple Title" style="display:none;" >
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
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" onblur="RemoveTag(txtCancelReason)" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="text-transform: uppercase; resize: none;font-family: calibri;"></textarea>
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
    <style>
         .ui-dialog .ui-dialog-titlebar-close {
               display: none;
                /*color:green;*/           
         }
    </style>
                <script>
                    //for search option
                    var $NoConfi = jQuery.noConflict();
                    var $NoConfi3 = jQuery.noConflict();

                  

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
    </script>
   
           <script>
               function getdetails(href) {
                   window.location = href;
                   return false;
               }

        
               function ErrorCancelation() {
                   $noCon("#success-alert").html("Conduct category status changed successfully.");
                   $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   $noCon("#success-alert").alert();

                   return fals

               }
               //EVM-0024
        
               //END 

               function DeleteByID(strId, strCancelReason, strCancelMust) {
                   var strUserID = '<%=Session["USERID"]%>';
                   var strOrgIdID = '<%=Session["ORGID"]%>';
                   var strCorpID = '<%=Session["CORPOFFICEID"]%>';

                   if (strId != "" && strUserID != '') {
                       // alert(strId); alert(strCancelReason); alert(strCancelMust); alert(strUserID);
                       var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason,strOrgIdID,strCorpID, function (response) {

                           var SucessDetails = response;
                           if (SucessDetails == "successcncl") {

                               window.location = 'fms_Tax_Collected_At_Source_List.aspx?InsUpd=Cncl';


                           }
                           else {
                               window.location = 'fms_Tax_Collected_At_Source_List.aspx?InsUpd=Error';
                           }
                       });
                   }

                   return false;
               }
              
               //EVM-0024
               function CloseCancelView() {
                   ReasonConfirm = document.getElementById("txtCancelReason").value;

                   if (document.getElementById("<%=Hiddencnclsts.ClientID%>").value == "") {
                       ezBSAlert({
                           type: "confirm",
                           messageText: "Do you want to close  without completing cancellation process?",
                           alertType: "info"
                       }).done(function (e) {
                           if (e == true) {
                               $noCon('#dialog_simple').dialog('close');
                           }
                           else {
                               $noCon('#dialog_simple').dialog('open');
                               return false;
                           }
                       });
                       return false;
                   }
               }
               //END


               </script>
     <script>

    </script>
     <%--<style>
        .table td + td + td + td,
        .table th + th + th + th {
            text-align: center;
        }

        #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }

        .dt-toolbar {
            border-bottom: 1px solid #c8b6b6;
            background: #f4f6f0;
        }

        .dt-toolbar-footer {
            border-top: 1px solid #c8b6b6;
            background: #f4f6f0;
        }

        .table > thead > tr > th {
            background: #eee;
            color: #fff;
        }

        .table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
            border-bottom: 1px solid #c8b6b6;
            border-right: 1px solid #c8b6b6;
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
         table.dataTable thead .sorting_disabled {
           background-color: #79895f;

        }
         
        /*table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
            background-color: #92a276;
        }*/

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

        #datatable_fixed_column_wrapper, #tableConfirm_wrapper {
            border: 1px solid #c8b6b6;
        }
    </style>--%>
</asp:Content>

