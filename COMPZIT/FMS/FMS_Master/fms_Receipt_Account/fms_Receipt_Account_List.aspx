<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Receipt_Account_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
       
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
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
    <script>


        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
           
            $("#divAccount" + ">input").focus();
       
            $("#divAccount > input").select();
       
            var cnclSts = '<%= Session["CANCEL_STS"] %>';
            if (cnclSts != '') {
                if (cnclSts == 'successcncl') {
                    SuccessClose();
                }
                else if (cnclSts == 'UpdCancl') {
                    SuccessDeleted();
                }
                else if (cnclSts == 'failed') {
                    SuccessError();
                }
            }


            var ReopenSts = '<%= Session["REOPEN_STS"] %>';
            if (ReopenSts != '') {
                if (ReopenSts == 'successReopen') {
                    SuccessReoen();
                }
                    //0039
                if (ReopenSts == 'Reopns') {
                    SuccessReoen();
                }
                    //end
                else if (ReopenSts == 'Updreopen') {
                    WarnigReopen();
                }
                else if (ReopenSts == 'failed') {
                    SuccessErrorReoen();
                }
                else if (ReopenSts == 'alrdydeleted') {
                    SuccessDeletedList();
                }
                else if (ReopenSts == 'acntclosed') {
                    AcntClosedList();
                }
                else if (ReopenSts == 'auditclosed') {
                    AuditClosedList();
                }
                


            }

            var CONFIRMSts = '<%= Session["CONFIRM_STS"] %>';
            if (CONFIRMSts != '') {
                if (CONFIRMSts == 'successConfirm') {
                    SuccessConfirm();
                }
                else if (CONFIRMSts == 'failed') {
                    SuccessErrorReoen();
                }
                else if (CONFIRMSts == 'alrdydeleted') {
                    SuccessDeletedList();
                }
                else if (CONFIRMSts == 'acntclosed') {
                    AcntClosedList();
                }
                else if (CONFIRMSts == 'Auditclosed') {
                    AuditClosed();
                }

            }
        //    loadTableDesg();
            LoadEmpList();   // emp0025

        

        });

        function SuccessMsg() {

            $noCon("#success-alert").html("Receipt details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           

            return false;


        }
        function SuccessUpdMsg() {

            $noCon("#success-alert").html("Receipt details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
           

            return false;


        }
        function loadTableDesg() {

            //$noCon(function () {
            //    $noCon('#dialog_simple').dialog({
            //        autoOpen: false,
            //        width: 600,
            //        resizable: false,
            //        modal: true,
            //        title: "Receipt",
            //    });
            //});
        }
        function AuditClosedList() {
            $noCon("#divWarning").html("This action is  denied! Audit is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function Alreadyreopened() {
            $noCon("#divWarning").html("Entry already reopened.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function AcntClosedList() {
            $noCon("#divWarning").html("This action is  denied! Account is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function SuccessDeletedList() {

            $noCon("#divWarning").html("This action is  denied! This Receipt is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });

            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }
        function SalesAmountExceeded() {
            $noCon("#divWarning").html("Receipt amount should not be greater than sales amount.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function SalesAmountFullySettld() {
            $noCon("#divWarning").html("Sale amount is already settled.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        //0039
        function AlreadyConfrm() {
            $noCon("#divWarning").html("Receipt confirmed already.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        //END
        function SuccessConfirm() {
            $noCon("#success-alert").html("Receipt Confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        //0039
        function Reopened() {
            $noCon("#success-alert").html("Receipt Reopened successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        //end
        //0039
        function AllReopened() {
            $noCon("#divWarning").html("Receipt already Reopened .");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        //end

        function SuccessError() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["CANCEL_STS"] = "' + null + '"; %>';

              //var delayInMilliseconds = 3000; //1 second

              //setTimeout(function () {
              //    window.location = "fms_Ledger_List.aspx";
              //    //your code to be executed after 1 second
              //}, delayInMilliseconds);

            return false;
        }
        function SuccessErrorReoen() {
            $noCon("#divWarning").html("Some error occured!.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';

             //var delayInMilliseconds = 3000; //1 second

             //setTimeout(function () {
             //    window.location = "fms_Ledger_List.aspx";
             //    //your code to be executed after 1 second
             //}, delayInMilliseconds);

            return false;
        }
        function AlreadyConfirmed() {
            $noCon("#divWarning").html("Entry Already confirmed");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';

              //var delayInMilliseconds = 3000; //1 second

              //setTimeout(function () {
              //    window.location = "fms_Ledger_List.aspx";
              //    //your code to be executed after 1 second
              //}, delayInMilliseconds);

            return false;
        }

        function SuccessDeleted() {
            $noCon("#divWarning").html("This action is  denied! This Receipt is already canceled .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["CANCEL_STS"] = "' + null + '"; %>';

            //var delayInMilliseconds = 3000; //1 second

            //setTimeout(function () {
            //    window.location = "fms_Ledger_List.aspx";
            //    //your code to be executed after 1 second
            //}, delayInMilliseconds);

            return false;
        }
        function WarnigReopen() {
            $noCon("#divWarning").html("This action is  denied! This Receipt is already Reopened .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';
            return false;
        }


        function AcntClosed() {
            $noCon("#divWarning").html("This action is  denied! Account is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AuditClosed() {
            $noCon("#divWarning").html("This action is  denied! Audit is already closed .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessDeleted() {

            $noCon("#divWarning").html("This action is  denied! This Receipt is already deleted .");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });


            return false;
        }
        function PrintRcpt(id) {
            var UsrName = '<%= Session["USERFULLNAME"] %>';
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
            var strId = id;
            var crncyAbrvt = document.getElementById("<%=HiddenCurrrencyAbrvtn.ClientID%>").value; 
            var crncyId = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

            if (strCorpID != "" && strCorpID != null && strOrgIdID != "" && strOrgIdID != null && strUserID != null && strUserID != "" && strId != "" && crncyAbrvt != "") {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "fms_Receipt_Account_List.aspx/printReceiptDetails",
                    data: '{strId: "' + strId + '",strUserID: "' + strUserID + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",crncyAbrvt: "' + crncyAbrvt + '",crncyId: "' + crncyId + '",UsrName: "' + UsrName + '"}',
                    dataType: "json",
                    success: function (data) {
                        if (data.d != "") {
                            if (data.d != "false") {
                                window.open(data.d, '_blank');
                            }
                        }
                        else {
                            PrintVersnError();
                        }

                    }
                });
            }
            else {
                window.location = '/Security/Login.aspx';
            }
            return false;
        }





        function SuccessClose() {
            var ret = false;
            $noCon("#success-alert").html("Receipt details deleted successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["CANCEL_STS"] = "' + null + '"; %>';
         
            
            return false;
        }
        //0039

        function AlreadyCancel() {
            var ret = false;
            $noCon("#divWarning").html("Receipt details already deleted.");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["CANCEL_STS"] = "' + null + '"; %>';


            return false;
        }
        //end
        function SuccessReoen() {
            var ret = false;
            $noCon("#success-alert").html("Receipt reopened successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

            });
            '<%Session["REOPEN_STS"] = "' + null + '"; %>';

            return false;
        }
        


        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this receipt details?",
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
                        $('#dialog_simple').modal('show');
                        $('#dialog_simple').on('shown.bs.modal', function () {
                            document.getElementById("txtCancelReason").focus();
                        });
                        //$noCon('#dialog_simple').dialog('open');

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

        function ReOpen(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reopen this receipt?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                   
                        ReOpenByID(StrId);
                      
                   
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

                "columnDefs": [
                    {
                        "targets": 0,
                        "orderData": 5,
                    },
                     {
                         "targets": 5,
                         "visible": false
                     },
                ],
                "order": [[0, 'desc']],

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

            $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {
                otable
                    .column($NoConfi(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });//EVM-0020
        }


        function addCommas(nStr) {
            nStr += '';
            var x = nStr.split('.');
            var x1 = x[0];
            var x2 = x[1];

            if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "1") {
                 var rgx = /(\d+)(\d{7})/;
                 if (rgx.test(x1)) {
                     x1 = x1.replace(rgx, '$1' + ',' + '$2');
                 }
                 rgx = /(\d+)(\d{5})/;
                 if (rgx.test(x1)) {
                     x1 = x1.replace(rgx, '$1' + ',' + '$2');
                 }
                 rgx = /(\d+)(\d{3})/;
                 if (rgx.test(x1)) {
                     x1 = x1.replace(rgx, '$1' + ',' + '$2');
                 }
             }

             if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "2") {
                         var rgx = /(\d+)(\d{9})/;
                         if (rgx.test(x1)) {
                             x1 = x1.replace(rgx, '$1' + ',' + '$2');
                         }

                         rgx = /(\d+)(\d{6})/;
                         if (rgx.test(x1)) {
                             x1 = x1.replace(rgx, '$1' + ',' + '$2');
                         }
                         rgx = /(\d+)(\d{5})/;
                         if (rgx.test(x1)) {
                             x1 = x1.replace(rgx, '$1' + ',' + '$2');
                         }
                         rgx = /(\d+)(\d{3})/;
                         if (rgx.test(x1)) {
                             x1 = x1.replace(rgx, '$1' + ',' + '$2');
                         }
                     }
                     if (document.getElementById("<%=hiddenCurrencyModeId.ClientID%>").value == "3") {
                         var rgx = /(\d+)(\d{9})/;
                         if (rgx.test(x1)) {
                             x1 = x1.replace(rgx, '$1' + ',' + '$2');
                         }
                         rgx = /(\d+)(\d{6})/;
                         if (rgx.test(x1)) {
                             x1 = x1.replace(rgx, '$1' + ',' + '$2');
                         }
                         rgx = /(\d+)(\d{3})/;
                         if (rgx.test(x1)) {
                             x1 = x1.replace(rgx, '$1' + ',' + '$2');
                         }
                     }

                     if (isNaN(x2))
                         document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1;
                           //return x1;
                       else
                           document.getElementById("<%=Hiddenreturnfun.ClientID%>").value = x1 + "." + x2;


                   }


        function ReciptListValidate()
        {

            var ret=true;
            document.getElementById("<%=txtFromdate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
            var fromdate = document.getElementById("cphMain_txtFromdate").value;
            var toDate = document.getElementById("cphMain_txtTodate").value;

            if (fromdate == "" && toDate == "") {
                document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
               $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
               });
             
                $noCon(window).scrollTop(0);
                ret = false;
            }

            if (fromdate == "" && toDate!="") {
                document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                 
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
               
                $noCon(window).scrollTop(0);
                ret = false;
            }
            if (toDate == "" && fromdate!="") {
                document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                $noCon("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                });
               
                $noCon(window).scrollTop(0);
                ret = false;
            }

            if (fromdate != "" && toDate != "") {

                var arrDateFromchk = fromdate.split("-");
                dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

                var arrDateTochk = toDate.split("-");
                dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
                if (dateDateFromchk > dateDateTochk) {
                    $noCon("#divWarning").html("From date should not be greater than to date.");
                    $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                    });
                   
                    $noCon(window).scrollTop(0);
                    document.getElementById("cphMain_txtFromdate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtTodate").style.borderColor = "Red";
                    ret = false;
                }
            }
            
           
            
            return ret;
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
     //    loadTableDesg();
         LoadEmpList();
      
            $au(".ddl").selectToAutocomplete1Letter();
           LoadEmpList();
        }
        function DeletePerfomanceTmplt(Id) {
            // alert(Id);
        }



        var $con2 = jQuery.noConflict();

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
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
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="HiddenSuccessMsgType" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <asp:HiddenField ID="HiddenProvisionSts" runat="server" />
    <asp:HiddenField ID="HiddenFinancialStartDate" runat="server" />
    <asp:HiddenField ID="HiddenReopenSts" runat="server" />
    <asp:HiddenField ID="HiddenFnancialEndDeate" runat="server" />
    <asp:HiddenField ID="HiddenCurrrencyAbrvtn" runat="server" />
    <asp:HiddenField ID="HiddenFieldAuditCloseReopenSts" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="Hiddenreturnfun" runat="server" />

     <asp:HiddenField ID="HiddenFieldRecurrRole" runat="server" />

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Receipt</li>
    </ol>
    <div class="myAlert-top alert alert-success" id="success-alert">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Success!</strong> Changes completed succesfully
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>Danger!</strong> Request not conmpleted
    </div>
       <div class="content_sec2 cont_contr">
              <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h1 class="h1_con">Receipt</h1>

                <div class="form-group fg5 mar_bo1" style="width: 29%; margin-top: 2%; margin-left: 1%; display: none">
                    <h2 style="margin-top: 1%;">Ledger </h2>
                    <div id="divddlLedger">
                        <asp:DropDownList ID="ddlLedger" Height="30px" Width="160px" class="form-control ddl form1" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" runat="server" Style="height: 30px; width: 226px; margin-left: 8%; margin-bottom: 2%; cursor: pointer;">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg5 mar_bo1">
                    <label for="email" class="fg2_la1">Account Book:<span class="spn1"></span></label>
                    <div id="divAccount">
                        <asp:DropDownList ID="ddlAccontLed" Height="30px" Width="240px" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" class="form-control fg2_inp1 fg_chs2 ddl " runat="server" Style="">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group fg7">
                    <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span> </label>
                    <div id="datepicker" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtFromdate" runat="server" type="text" style="" onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        <script>

                            var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value
                            var curentDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value
                                $noCon('#datepicker').datepicker({
                                autoclose: true,
                                format: 'dd-mm-yyyy',
                                startDate: StartDate,
                                endDate: curentDate,
                                timepicker: false
                            });
                        </script>
                    </div>
                </div>

                <div class="form-group fg7">
                    <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span></label>
                    <div id="datepicker1" class="input-group date" data-date-format="mm-dd-yyyy">
                        <input id="txtTodate" runat="server" type="text" style="" onkeypress="return DisableEnterAndComma(event)" onkeydown="return DisableEnterAndComma(event)" class="Tabletxt form-control datepicker" placeholder="dd-mm-yyyy" maxlength="50" />
                        <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                        <script>
                            var StartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value
                            var curentDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value
                            $noCon('#datepicker1').datepicker({
                                autoclose: true,
                                format: 'dd-mm-yyyy',
                                startDate: StartDate,
                                endDate: curentDate,
                                timepicker: false
                            });
                        </script>
                    </div>
                </div>

                <div class="form-group fg7 mar_lt">
                    <label for="email" class="fg2_la1">Receipt Status:<span class="spn1"></span></label>
                    <asp:DropDownList ID="ddlRcptSts" Height="30px" Width="160px" class="form-control fg2_inp1 fg_chs1" runat="server" Style="cursor: pointer;">
                        <asp:ListItem Text="All" Value="4" Selected="True"> </asp:ListItem>
                        <asp:ListItem Text="Pending" Value="0"> </asp:ListItem>
                        <asp:ListItem Text="Confirmed" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Reopened" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="fg5">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <button type="button" class="btn-d" data-color="p"></button>
                            <asp:CheckBox ID="cbxCnclStatus" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" Text="" runat="server" Checked="false" class="form2" />
                        </span>
                        <p class="pz_s">Show Deleted Entries</p>
                    </label>
                </div>

                <div class="fg8">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" Style="cursor: pointer;" runat="server" class="submit_ser" OnClientClick="return ReciptListValidate();" OnClick="btnSearch_Click" />
                </div>

                
  <div class="clearfix"></div>
  <div class="devider"></div>

                <div id="divList" runat="server"  >
                   
                </div>
                      
                </div>
                  </div>

 <button  id="print" onclick="return printsorted();"  class="print_o" title="Print page"><i class="fa fa-print"> </i></button>
  <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>
           
<%--<!--add_new_button--->
<a href="add_receipt.html" type="button" onclick="topFunction()" id="myBtn" title="Add New">
  <i class="fa fa-plus-circle"></i>
</a>
<!---add_new_button_closed-->--%>
          <div id="divAdd"  runat="server" onclick="location.href='fms_Receipt_Account.aspx'"  >
               <a   href="fms_Receipt_Account.aspx" type="button" onclick="topFunction()" id="myBtn"  title="Add New" >
                  <i class="fa fa-plus-circle"></i>
               </a>
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

           <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
               <br />
               <br />
               <br />
               <br />
               <br />
           </div>
            <div id="divPrintReport" runat="server" style="display: none">
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
            <div id="divPrintCaptionDrilDown" runat="server" style="display: none">
            </div>
            <div id="divPrintReportDrilDown" runat="server" style="display: none">
            </div>
     </div>   
   
    <div class="modal fade" id="dialog_simple" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" style="display:none;"">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none; margin-top: 1%">
                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason1"> Please fill this out</label>
                </div>

                <div class="modal-body">
                     <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" maxlength="500" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">Save</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>    
  


      <div class="pending" type="button"   data-toggle="modal" data-target="#myrecur" title="Pending Actions" id="menu1" runat="server">
  <i class="fa fa-retweet" aria-hidden="true"></i>
  <span class="badge beln cht cht1 pen_b" id="sPendOrdNum" runat="server"></span>
</div>

<!-- Modal -->
<div class="modal fade" id="myrecur" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog rec_db" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Pending Actions</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       <table class="table table-bordered table-fixed">
    <thead class="thead1">
      <tr>
        <th class="td_rec">Date</th>
        <th class="td_rec1">Ref#</th>
        <th class="td_rec">Action</th>
      </tr>
    </thead>
    <tbody id="myTable" runat="server">
     
    </tbody>
  </table>
      </div>
    </div>
  </div>
</div>




<div id="pan_l" class="l1">
</div>
    <!---slide toogle of pending Orders--->
<script>
    $(document).ready(function () {
        $(".flip_o").mouseover(function () {
            $(".l1").show("200");
        });
        $(".flip_o").mouseout(function () {
            $(".l1").hide("");
        });
    });

    function RecurReject(strid, obj) {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to reject this item?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {
        var UserId = '<%= Session["USERID"] %>';
        if (strid != "" && UserId != "") {
            $.ajax({
                type: "POST",
                async: false,
                url: "fms_Receipt_Account_List.aspx/RecurReject",
                data: '{strid:"' + strid + '",UserId:"' + UserId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    obj.closest('tr').remove();
                    var cnt = parseInt(document.getElementById("cphMain_sPendOrdNum").innerText);
                    cnt = cnt - 1;
                    if (cnt <= 0) {
                        document.getElementById("cphMain_menu1").style.display = "none";
                        $('#myrecur').modal('hide');
                    }
                    else {
                        document.getElementById("cphMain_sPendOrdNum").innerText = cnt;
                    }
                    $noCon("#success-alert").html("Item rejected successfully.");
                    $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                    });
                },
                failure: function (response) {
                }
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
    function ShowOrderDtls(strid) {
        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        if (strid != "" && CorpId != "") {
            $.ajax({
                type: "POST",
                async: false,
                url: "fms_Receipt_Account_List.aspx/ShowOrderDtls",
                data: '{strid:"' + strid + '",CorpId:"' + CorpId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("pan_l").innerHTML = response.d;
                },
                failure: function (response) {
                }
            });
        }
        return false;
    }

</script>





                <script>
                    //for search option
                    var $NoConfi = jQuery.noConflict();
                    var $NoConfi3 = jQuery.noConflict();

                  

                    function ValidateCancelReason() {
                        // replacing < and > tags

                        var ret = true;
                        document.getElementById("divErrMsgCnclRsn").style.display = "none";
                        document.getElementById("lblErrMsgCancelReason").style.display = "none";
                        document.getElementById("txtCancelReason").style.borderColor = "";

                        var strCancelReason = document.getElementById("txtCancelReason").value;
                        if (strCancelReason == "") {
                            document.getElementById("txtCancelReason").style.borderColor = "red";
                            document.getElementById("lblErrMsgCancelReason").style.display = "block";
                            document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                            document.getElementById("divErrMsgCnclRsn").style.display = "";
                            $("div.war").fadeIn(200).delay(500).fadeOut(400);
                            return ret;
                        }
                        else {
                            strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                            strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                            strCancelReason = strCancelReason.replace(/\n /, "\n");
                            if (strCancelReason.length < "10") {
                                document.getElementById("lblErrMsgCancelReason").style.display = "block";
                                document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                                document.getElementById("txtCancelReason").style.borderColor = "red";
                                document.getElementById("divErrMsgCnclRsn").style.display = "";
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
                            //$noCon('#dialog_simple').dialog('close');
                            $('#dialog_simple').modal('hide');
                        }

                        return false;

                    }



                    function ConfirmByID(StrId) {

                        ezBSAlert({
                            type: "confirm",
                            messageText: "Do you want to confirm this receipt?",
                            alertType: "info"
                        }).done(function (e) {
                            if (e == true) {
                                CheckSaleSettlements(StrId);//EVM-0020
                                return false;
                            }
                            else {
                                return false;
                            }
                        });
                        return false;

                    }

                    function CheckSaleSettlements(strPayemntId) {//EVM-0020

                        var strUserID = '<%=Session["USERID"]%>';
                        var strOrgIdID = '<%=Session["ORGID"]%>';
                        var strCorpID = '<%=Session["CORPOFFICEID"]%>';

                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "fms_Receipt_Account_List.aspx/CheckSaleSettlement",
                            data: '{strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '"}',
                            dataType: "json",
                            success: function (data) {

                                if (data.d == "successConfirm") {
                                    Confirm(strPayemntId);
                                    return false;
                                }
                                else if (data.d == "SalesAmtFullySettld") {

                                    ezBSAlert({
                                        type: "confirm",
                                        messageText: "One or more sale amount(s) is fully settled. Do you want to confirm by deleting added sales?",
                                        alertType: "info"
                                    }).done(function (e) {
                                        if (e == true) {

                                            Confirm(strPayemntId);
                                            return false;
                                        }
                                        else {
                                            return false;
                                        }
                                    });

                                }
                                else if (data.d == "SalesAmountExceeded") {
                                    SalesAmountExceeded();
                                }
                                else if (data.d == 'failed') {
                                    SuccessErrorReoen();
                                }
                            }
                        });
                    
                    }

                    function Confirm(strPayemntId) {

                        var strUserID = '<%=Session["USERID"]%>';
                        var strOrgIdID = '<%=Session["ORGID"]%>';
                        var strCorpID = '<%=Session["CORPOFFICEID"]%>';

                        var strfinancialID = '<%=Session["FINCYRID"]%>';
                        var strReturn = "";

                        if (strPayemntId != "" && strUserID != '') {

                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                url: "fms_Receipt_Account_List.aspx/ConfirmRcptDetails",
                                data: '{strUserID: "' + strUserID + '",strPayemntId: "' + strPayemntId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",strfinancialID: "' + strfinancialID + '"}',
                                dataType: "json",
                                success: function (data) {

                                    var CONFIRMSts = data.d[0];
                                    if (CONFIRMSts != '') {
                                        $(window).scrollTop(0);
                                        if (CONFIRMSts == 'successConfirm') {
                                            SuccessConfirm();
                                        }
                                        else if (CONFIRMSts == 'alrdyCnfrmd') {
                                            AlreadyConfirmed();
                                        }
                                        else if (CONFIRMSts == 'failed') {
                                            SuccessErrorReoen();
                                        }
                                        else if (CONFIRMSts == 'alrdydeleted') {
                                            SuccessDeletedList();
                                        }
                                        else if (CONFIRMSts == 'acntclosed') {
                                            AcntClosedList();
                                        }
                                        else if (CONFIRMSts == 'Auditclosed') {
                                            AuditClosed();
                                        }
                                        else if (CONFIRMSts == 'SalesAmountExceeded') {
                                            SalesAmountExceeded();
                                        }
                                        else if (CONFIRMSts == 'SalesAmtFullySettld') {
                                            SalesAmountFullySettld();
                                        }

                                    }
                                    if (CONFIRMSts != 'failed' && CONFIRMSts != '') {
                                        document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                        LoadEmpList();

                                        if (document.getElementById("<%=HiddenFieldRecurrRole.ClientID%>").value == "1") {
                                            if (data.d[3] != "" && data.d[3] != null) {
                                                document.getElementById("cphMain_sPendOrdNum").innerHTML = data.d[3];
                                                document.getElementById("cphMain_menu1").style.display = "block";
                                            }
                                            else {
                                                document.getElementById("cphMain_menu1").style.display = "none";
                                            }
                                            document.getElementById("cphMain_myTable").innerHTML = data.d[4];
                                        }
                                    }

                                }
                            });
                        }

                        return false;
                    }

                    function printsorted() {

                        var orgID = '<%= Session["ORGID"] %>';
                        var corptID = '<%= Session["CORPOFFICEID"] %>';

                        var FinancialStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                        var FinancialEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
                        var AccountBook = "";
                        var CurrencyID = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

                        var RcptStatus = document.getElementById("cphMain_ddlRcptSts").value;
                        var LedgrIdID = document.getElementById("<%=ddlLedger.ClientID%>").value;
                       // var Status = document.getElementById("cphMain_ddlRcptSts").value;
                    
                        if (document.getElementById("<%=ddlAccontLed.ClientID%>").value != "--SELECT--") {
                            AccountBook = $("#cphMain_ddlAccontLed :selected").text();
                            LedgrIdID = document.getElementById("<%=ddlAccontLed.ClientID%>").value;
                        }
                      
                        var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
                        var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
                        var CnclSts = 0;
                        var  Status = 0;
                        if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                            CnclSts = 1;
                            Status = 1;
                        }
                        if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                contentType: "application/json; charset=utf-8",
                                url: "fms_Receipt_Account_List.aspx/PrintList",
                                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",FinancialStartDate: "' + FinancialStartDate + '",FinancialEndDate: "' + FinancialEndDate + '",CurrencyID: "' + CurrencyID + '",RcptStatus: "' + RcptStatus + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",LedgrIdID: "' + LedgrIdID + '",Status: "' + Status + '",AccountBook: "' + AccountBook + '"}',
                                dataType: "json",
                                success: function (data) {
                                    if (data.d != "") {
                                        if (data.d != "") {
                                            window.open(data.d, '_blank');
                                            //document.getElementById("cphMain_divPrintReport").innerHTML = data.d;

                                            //window.open("../../Print/Common_print.htm");
                                            return false;
                                            //   window.open(data.d, '_blank');
                                        }
                                    }
                                    else {
                                        PrintVersnError();
                                    }
                                }
                            });
                        }
                        else {
                            window.location = '/Security/Login.aspx';
                        }
                        return false;
                    }

                    function PrintVersnError() {
                        $noCon("#divWarning").html("Please select a version for printing from account setting.");
                        $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                        });
                       
                        return false;
                    }
                    function PrintCSV() {

                        var orgID = '<%= Session["ORGID"] %>';
                         var corptID = '<%= Session["CORPOFFICEID"] %>';

                         var FinancialStartDate = document.getElementById("<%=HiddenFinancialStartDate.ClientID%>").value;
                         var FinancialEndDate = document.getElementById("<%=HiddenFnancialEndDeate.ClientID%>").value;
                         var AccountBook = "";
                         var CurrencyID = document.getElementById("<%=hiddenDfltCurrencyMstrId.ClientID%>").value;

                        var RcptStatus = document.getElementById("cphMain_ddlRcptSts").value;
                        var LedgrIdID = document.getElementById("<%=ddlLedger.ClientID%>").value;
                         // var Status = document.getElementById("cphMain_ddlRcptSts").value;

                        if (document.getElementById("<%=ddlAccontLed.ClientID%>").value != "--SELECT--") {
                             AccountBook = $("#cphMain_ddlAccontLed :selected").text();
                             LedgrIdID = document.getElementById("<%=ddlAccontLed.ClientID%>").value;
                        }

                        var from = document.getElementById("<%=txtFromdate.ClientID%>").value;
                         var toDt = document.getElementById("<%=txtTodate.ClientID%>").value;
                         var CnclSts = 0;
                         var Status = 0;
                         if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                             CnclSts = 1;
                             Status = 1;
                         }
                         if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                             $.ajax({
                                 type: "POST",
                                 async: false,
                                 contentType: "application/json; charset=utf-8",
                                 url: "fms_Receipt_Account_List.aspx/PrintCSV",
                                 data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",FinancialStartDate: "' + FinancialStartDate + '",FinancialEndDate: "' + FinancialEndDate + '",CurrencyID: "' + CurrencyID + '",RcptStatus: "' + RcptStatus + '",from: "' + from + '",toDt: "' + toDt + '",CnclSts: "' + CnclSts + '",LedgrIdID: "' + LedgrIdID + '",Status: "' + Status + '",AccountBook: "' + AccountBook + '"}',
                                 dataType: "json",
                                 success: function (data) {
                                     if (data.d != "") {
                                         if (data.d != "") {
                                             window.open(data.d, '_blank');
                                             //document.getElementById("cphMain_divPrintReport").innerHTML = data.d;

                                             //window.open("../../Print/Common_print.htm");
                                             return false;
                                             //   window.open(data.d, '_blank');
                                         }
                                     }
                                     else {
                                         PrintVersnError();
                                     }
                                 }
                             });
                         }
                         else {
                             window.location = '/Security/Login.aspx';
                         }
                         return false;
                     }

                     function PrintVersnError() {
                         $noCon("#divWarning").html("Please select a version for printing from account setting.");
                         $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
                         });

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
                  

                   return fals

               }
               //EVM-0024
        
               //END 
               function ReOpenByID(strmemotId) {

                   var usrId = '<%=Session["USERID"]%>';
                   var strOrgIdID = '<%=Session["ORGID"]%>';
                   var strCorpID = '<%=Session["CORPOFFICEID"]%>';
                   var strfinancialID = '<%=Session["FINCYRID"]%>';

                   var reopensts = document.getElementById("<%=HiddenReopenSts.ClientID%>").value;
                   var AcntClssts = document.getElementById("<%=HiddenProvisionSts.ClientID%>").value;
                   var AuditClssts = document.getElementById("<%=HiddenFieldAuditCloseReopenSts.ClientID%>").value;



                   if (strmemotId != "" && usrId != '') {

                       $.ajax({
                           type: "POST",
                           async: false,
                           contentType: "application/json; charset=utf-8",
                           url: "fms_Receipt_Account_List.aspx/ReopenReceiptDetails",
                           data: '{strmemotId: "' + strmemotId + '",usrId: "' + usrId + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",reopensts: "' + reopensts + '",AcntClssts: "' + AcntClssts + '",AuditClssts: "' + AuditClssts + '",strfinancialID: "' + strfinancialID + '"}',
                           dataType: "json",
                           success: function (data) {
                               var ReopenSts = data.d[0];
                               if (ReopenSts != '') {
                                   $(window).scrollTop(0);
                                   if (ReopenSts == 'successReopen') {
                                       SuccessReoen();
                                   }
                                   else if (ReopenSts == 'Updreopen') {
                                       WarnigReopen();
                                   }
                                   else if (ReopenSts == 'failed') {
                                       SuccessErrorReoen();
                                   }
                                   else if (ReopenSts == 'alrdydeleted') {
                                       SuccessDeletedList();
                                   }
                                   else if (ReopenSts == 'acntclosed') {
                                       AcntClosedList();
                                   }
                                   else if (ReopenSts == 'auditclosed') {
                                       AuditClosedList();
                                   }
                                   else if (ReopenSts == 'alrdyreopened') {
                                       Alreadyreopened();
                                   }
                               }

                               if (ReopenSts != 'failed' && ReopenSts != '') {
                                   document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                   LoadEmpList();

                                   if (document.getElementById("<%=HiddenFieldRecurrRole.ClientID%>").value == "1") {
                                       if (data.d[3] != "" && data.d[3] != null) {
                                           document.getElementById("cphMain_sPendOrdNum").innerText = data.d[3];
                                           document.getElementById("cphMain_menu1").style.display = "block";
                                       }
                                       else {
                                           document.getElementById("cphMain_menu1").style.display = "none";
                                       }
                                       document.getElementById("cphMain_myTable").innerHTML = data.d[4];
                                   }
                               }

                           }
                       });
                   }

                   return false;
               }



               function DeleteByID(strmemotId, cnclRsn, reasonmust) {
                   var usrId = '<%=Session["USERID"]%>';
                    var strOrgIdID = '<%=Session["ORGID"]%>';
                    var strCorpID = '<%=Session["CORPOFFICEID"]%>';
                    var strfinancialID = '<%=Session["FINCYRID"]%>';
                    if (strmemotId != "" && usrId != '') {


                        $.ajax({
                            type: "POST",
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "fms_Receipt_Account_List.aspx/CancelMemoReason",
                            data: '{strmemotId: "' + strmemotId + '",reasonmust: "' + reasonmust + '",usrId: "' + usrId + '",cnclRsn: "' + cnclRsn + '",strOrgIdID: "' + strOrgIdID + '",strCorpID: "' + strCorpID + '",strfinancialID: "' + strfinancialID + '"}',
                            dataType: "json",
                            success: function (data) {


                                var cnclSts = data.d[0];
                                if (cnclSts != '') {
                                    $(window).scrollTop(0);
                                    if (cnclSts == 'successcncl') {
                                        SuccessClose();
                                    }
                                    else if (cnclSts == 'AlreadyCancl') {
                                        AlreadyCancel();
                                    }
                                    else if (cnclSts == 'UpdCancl') {
                                        SuccessDeleted();
                                    }
                                    else if (cnclSts == 'failed') {
                                        SuccessError();
                                    }
                                }
                                if (cnclSts != 'failed' && cnclSts != '') {
                                    document.getElementById("cphMain_divList").innerHTML = data.d[1];
                                    LoadEmpList();
                                }

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
                               $('#dialog_simple').modal('hide');
                           }
                           else {
                               $('#dialog_simple').modal('show')
                               return false;
                           }
                       });
                       return false;
                   }
               }
               function DisableEnter(evt) {
                   evt = (evt) ? evt : window.event;
                   var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                   if (keyCodes == 13) {
                       return false;
                   }
               }

               function DisableEnterAndComma(evt) {
                   DisableEnter(evt);
                   evt = (evt) ? evt : window.event;
                   var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                   if (keyCodes == 188) {
                       return false;
                   }
               }

               //END


               </script>
    
   <script>
       var $aa = jQuery.noConflict();
       $aa(function () {
           $aa.widget("custom.combobox", {
               _create: function () {
                   this.wrapper = $aa("<span>")
                     .addClass("custom-combobox " + $aa(this.element).prop("id"))
                     .insertAfter(this.element);

                   this.element.hide();
                   this._createAutocomplete();
                   // this._createShowAllButton();
               },




               _createAutocomplete: function () {

                   var selected = this.element.children(":selected"),

                     value = selected.val() ? selected.text() : "";
                   var idd = $aa(this.element).prop("id");
                   this.input = $aa("<input>")
                     .appendTo(this.wrapper)
                     .val(value)
                     .attr("title", "")
                     .attr("placeholder", "--SELECT--")
                       //danger custom function here
                  // attr("change","ChangeProduct()")
                       .attr("onkeydown", "return isTag(event);")
                      // .attr("onchange", "return ChangeProduct(" + idd + ");")
                       .attr("tabindex", 7)
                     //.addClass( "custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left" )
                     .addClass("form-control  ui-autocomplete-input " + $aa(this.element).prop("id"))
                     .autocomplete({
                         delay: 0,
                         minLength: 0,

                         select: function (event, ui) {


                             // alert(idd);
                             // loadDataToModule();

                         },
                         change: function (event, ui) {

                             ChangeProduct(idd);
                             // alert("SELECTTTT"+idd);
                             //  ChangeProduct( idd );
                             // alert(this.val());
                         },

                         source: $aa.proxy(this, "_source")


                     })

                     .tooltip({
                         classes: {
                             "ui-tooltip": "ui-state-highlight"
                         }
                     });

                   this._on(this.input, {
                       autocompleteselect: function (event, ui) {
                           ui.item.option.selected = true;
                           this._trigger("select", event, {
                               item: ui.item.option

                           });

                           $aa(".selector").autocomplete({
                               autoFocus: true
                           });
                           //$aa(".selector").autocomplete({
                           //    focus: function (event, ui) { }
                           //});
                           // alert("fgdf");

                           //var valuesSel = "";
                           // ChangeProduct(ui.item.option.val());
                           // $(".ddlProduct_" + x).focus();
                       },



                       autocompletechange: "_removeIfInvalid"
                   });

                   //$aa(".combobox_ui_ddlProduct").change(function () {
                   //    alert(this.value);
                   //});


               },



               _source: function (request, response) {
                   var matcher = new RegExp($aa.ui.autocomplete.escapeRegex(request.term), "i");
                   response(this.element.children("option").map(function () {
                       var text = $aa(this).text();
                       if (this.value && (!request.term || matcher.test(text)))
                           return {
                               label: text,
                               value: text,
                               option: this
                           };
                   }));
               },

               _removeIfInvalid: function (event, ui) {

                   // Selected an item, nothing to do
                   if (ui.item) {

                       //  alert(ui.item.label);
                       return;
                   }

                   // Search for a match (case-insensitive)
                   var value = this.input.val(),
                     valueLowerCase = value.toLowerCase(),
                     valid = false;
                   this.element.children("option").each(function () {
                       if ($aa(this).text().toLowerCase() === valueLowerCase) {
                           this.selected = valid = true;
                           return false;
                       }
                   });

                   // Found a match, nothing to do
                   if (valid) {

                       return;
                   }

                   // Remove invalid value
                   this.input
                     .val("")

                   //.attr( "title", value + " didn't match any item" )
                   //.tooltip( "open" );
                   this.element.val("");

                   var selected = this.element.children(":selected"),

                   value = selected.val() ? selected.text() : "";
                   var idd = $aa(this.element).prop("id");
                   // ChangeProduct(idd);
                   //this._delay(function() {
                   //    this.input.tooltip( "close" ).attr( "title", "" );
                   //}, 2500 );
                   this.input.autocomplete("instance").term = "";
               },

               _destroy: function () {
                   this.wrapper.remove();
                   this.element.show();
               }
           });



       });



       $aa(document).ready(function () {

       });
    </script>
  
   
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au(".ddl").selectToAutocomplete1Letter();
         });
         </script>

</asp:Content>

