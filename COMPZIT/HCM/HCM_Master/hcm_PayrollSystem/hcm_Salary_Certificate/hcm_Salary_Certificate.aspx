<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Salary_Certificate.aspx.cs" Inherits="HCM_HCM_Master_hcm_Salary_Certificate_hcm_Salary_Certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">


    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>

    <script src="/js/bootstrap/bootstrap.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />

    <script src="/js/jQueryUI/jquery-ui.min.js"></script>
    <script src="/js/jQueryUI/jquery-ui.js"></script>

    <script src="/js/HCM/Common.js"></script>

    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }


        function ConfirmMessageLIST() {
            if (confirmbox > 0)
                ConfirmMessage("hcm_Salary_Certificate_List.aspx");
            else
                window.location.href = "hcm_Salary_Certificate_List.aspx";
            return false;
        }

        function ConfirmCancel() {
            if (confirmbox > 0)
                CancelAlert("hcm_Salary_Certificate_List.aspx");
            else
                window.location.href = "hcm_Salary_Certificate_List.aspx";
            return false;
        }

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            LoadEmployeeDetails();
            LoadPopup();

        });

        function LoadEmployeeDetails() {

            var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;

            var Edit = '<%=Session["EDIT_ID"]%>';
            var View = '<%=Session["VIEW_ID"]%>';

            document.getElementById("<%=hiddenEmpId.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value;

            var DecimalCnt = document.getElementById("<%=hiddenDecimalCount.ClientID%>").value;

            if (EmpId != "--SELECT EMPLOYEE--") {

                var Details = PageMethods.EmployeeDtlsDisplay(EmpId, DecimalCnt, function (response) {

                    document.getElementById("<%=lblEmpName.ClientID%>").innerHTML = response[0];
                    document.getElementById("<%=lblDesgntn.ClientID%>").innerHTML = response[1];
                    document.getElementById("<%=lblDeprtmnt.ClientID%>").innerHTML = response[2];
                    document.getElementById("<%=lblPassportNo.ClientID%>").innerHTML = response[4];
                    document.getElementById("<%=lblNatnlId.ClientID%>").innerHTML = response[3];
                    document.getElementById("<%=lblDivsn.ClientID%>").innerHTML = response[7];

                    if (Edit == "" && View == "") {
                        document.getElementById("<%=lblBasicPay.ClientID%>").innerHTML = response[5];
                        document.getElementById("<%=lblAllwnce.ClientID%>").innerHTML = response[6];

                        document.getElementById("<%=hiddenBasicPay.ClientID%>").value = response[5];
                        document.getElementById("<%=hiddenAllowance.ClientID%>").value = response[6];
                    }

                });
            }
        }
        var $noconflic = jQuery.noConflict();
        function ValidateSalaryCertfct() {

            var ret = true;

            document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";
            $noconflic("div#divddlEmployee input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("<%=txtRsn.ClientID%>").style.borderColor = "";

            var EmpId = document.getElementById("<%=ddlEmployee.ClientID%>").value;
            var Reasn = document.getElementById("<%=txtRsn.ClientID%>").value.trim();

            if (EmpId == "--SELECT EMPLOYEE--") {
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                $noconflic("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "red");
                $noCon("#divDangerAlert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divDangerAlert").fadeTo(2000, 500).slideUp(500, function () {
                    document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                    document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";

                    $noconflic("#divddlEmployee input.ui-autocomplete-input").css("borderColor", "red");
                    $noconflic("#divddlEmployee input.ui-autocomplete-input").focus();
                    $noconflic("#divddlEmployee input.ui-autocomplete-input").select();
                });
                $noCon(window).scrollTop(0);
                ret = false;
            }

            if (Reasn == "") {
                document.getElementById("<%=txtRsn.ClientID%>").style.borderColor = "Red";
                $noCon("#divDangerAlert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $noCon("#divDangerAlert").fadeTo(2000, 500).slideUp(500, function () {
                    document.getElementById("<%=txtRsn.ClientID%>").focus();
                    document.getElementById("<%=txtRsn.ClientID%>").style.borderColor = "Red";
                });
                $noCon(window).scrollTop(0);
                ret = false;
            }

            return ret;
        }

        function ConfirmApprove() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to approve?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "") {
                        var CrtfctId = document.getElementById("<%=hiddenEdit.ClientID%>").value;
                    }
                    else if (document.getElementById("<%=hiddenView.ClientID%>").value != "") {
                        var CrtfctId = document.getElementById("<%=hiddenView.ClientID%>").value;
                    }
                    var UserId = '<%=Session["USERID"]%>';
                    var RejctReasn = "";

                    var Details = PageMethods.ApproveReject(CrtfctId, "1", UserId, RejctReasn, function (response) {

                        window.location.href = "hcm_Salary_Certificate_List.aspx";
                        return false;

                    });
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function ConfirmReject() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to reject?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    OpenPopup();
                }
                else {
                    return false;
                }
            });
            return false;
        }

        function LoadPopup() {
            var $noC = jQuery.noConflict();
            $noC(function () {

                $noCon('#dialog_simple').dialog({
                    autoOpen: false,
                    width: 600,
                    resizable: false,
                    modal: true,
                    title: "Salary certificate",
                    //position: 'top'

                });

            });
        }

        function OpenPopup() {

            document.getElementById("divErrMsgCnclRsn").style.display = "none";
            document.getElementById("txtRejctReason").style.borderColor = "";

            document.getElementById("txtRejctReason").value = "";

            $noCon('#dialog_simple').dialog('open');
            return false;
        }

        function closePopUP() {
            $noCon('#dialog_simple').dialog('close');
            return false;
        }

        function ValidateSaveCancelRsn() {

            var ret = true;

            document.getElementById("divErrMsgCnclRsn").style.display = "none";
            document.getElementById("txtRejctReason").style.borderColor = "";

            var strRejctReason = document.getElementById("txtRejctReason").value;
            if (strRejctReason == "") {
                document.getElementById("txtRejctReason").style.borderColor = "red";
                document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                document.getElementById("divErrMsgCnclRsn").style.display = "";
                document.getElementById("txtRejctReason").focus();
                ret = false;
            }
            else {
                strRejctReason = strRejctReason.replace(/(^\s*)|(\s*$)/gi, "");
                strRejctReason = strRejctReason.replace(/[ ]{2,}/gi, " ");
                strRejctReason = strRejctReason.replace(/\n /, "\n");
                if (strRejctReason.length < "10") {
                    document.getElementById("lblErrMsgCancelReason").innerHTML = " Reject reason should be minimum 10 characters";
                    document.getElementById("txtRejctReason").focus();
                    document.getElementById("txtRejctReason").style.borderColor = "red";
                    document.getElementById("divErrMsgCnclRsn").style.display = "";
                    ret = false;
                }
                else {
                    RejectRequest();
                }
            }
            return ret;
        }

        function RejectRequest() {

            if (document.getElementById("<%=hiddenEdit.ClientID%>").value != "") {
                var CrtfctId = document.getElementById("<%=hiddenEdit.ClientID%>").value;
            }
            else if (document.getElementById("<%=hiddenView.ClientID%>").value != "") {
                var CrtfctId = document.getElementById("<%=hiddenView.ClientID%>").value;
            }
            var UserId = '<%=Session["USERID"]%>';

            var RejctReasn = document.getElementById("txtRejctReason").value;

            var Details = PageMethods.ApproveReject(CrtfctId, "2", UserId, RejctReasn, function (response) {

                window.location.href = "hcm_Salary_Certificate_List.aspx";
                return false;
            });

            $noCon('#dialog_simple').dialog('close');
        }


    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenEmpId" runat="server" />
    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="hiddenBasicPay" runat="server" />
        <asp:HiddenField ID="hiddenAllowance" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />
    


 <div id="main" role="main" style="height: 1004px;">

    <div id="content">

            <div class="alert alert-success" id="divSuccessAlert" style="display: none">
                <button type="button" class="close" data-dismiss="alert">x</button>
            </div>
           <div class="alert alert-danger" id="divDangerAlert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

      <section id="widget-grid" class="">
       <div class="row">

    <div id="divList" class="list" onclick="ConfirmMessageLIST();" runat="server" style="position: fixed; right: 0%; top: 40%; height: 26.5px;"></div>
    


           <article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
               <div id="wid-id-0">
                            <header>
                                <label id="lblHeader" class="pageh2" runat="server">Salary Certificate Generation</label>
                            </header>
                                                       
        <div class="smart-form" style="float: left; width: 93.5%;">

          <div style="background: white;float:left;width:98%;margin-top: 1%;border: 1px solid;padding: 8px;margin-bottom:0%;">

            <div style="float: left; width: 98%; background: white; margin-top: 0%; padding-left: 1%;">

                    <div style="width: 100%; float: left;" class="formdiv">
                        <div id="divddlEmployee" style="width: 50%; float: left;">
                               <section style="width: 95%; margin-left: 5%;">
                                     <label id="lblEmp" runat="server" class="lblh2" style="float: left; width: 35%;">Employee*</label>
                                     <label class="select" style="float: left; width: 60%;">
                                        <%--<asp:DropDownList runat="server" ID="ddlEmployee1" onchange="LoadEmployeeDetails();"></asp:DropDownList>--%>
                                        <asp:DropDownList runat="server" ID="ddlEmployee" onkeypress="return DisableEnter(event);" CssClass="form-control" onchange="LoadEmployeeDetails()" ></asp:DropDownList>

                                     </label>
                                </section>
                           </div>
                        </div>



                    <div style="clear: both; width: 100%; border: .5px solid #9ba48b; background-color: #f3f3f3; width: 98%; margin-top: 2%; padding: 0%; float: left; margin-bottom: 0%;">

                                 <div style="width: 100%; float: left;" class="formdiv">

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 5%;">
                                             <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Employee</label>
                                                 <asp:Label ID="lblEmpName" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                     </div>
                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 7%;">
                                              <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Designation</label>
                                                  <asp:Label ID="lblDesgntn" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                      </div>

                                </div>

                                 <div style="width: 100%; float: left;" class="formdiv">

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 5%;">
                                             <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Department</label>
                                              <asp:Label ID="lblDeprtmnt" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                     </div>

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 7%;">
                                              <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Division</label>
                                              <asp:Label ID="lblDivsn" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                      </div>

                                </div>

                        
                                <div style="width: 100%; float: left;" class="formdiv">

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 5%;">
                                             <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Passport Number</label>
                                              <asp:Label ID="lblPassportNo" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                     </div>

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 7%;">
                                              <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">National ID Number</label>
                                                 <asp:Label ID="lblNatnlId" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                      </div>

                                </div>

                                <div style="width: 100%; float: left;" class="formdiv">

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 5%;">
                                             <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Basic Pay</label>
                                              <asp:Label ID="lblBasicPay" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                     </div>

                                     <div style="width: 50%; float: left;">
                                          <section style="width: 95%; margin-left: 7%;">
                                              <label class="lblh2" style="float: left; width: 35%;margin-top:0%;">Allowance</label>
                                              <asp:Label ID="lblAllwnce" runat="server" style="width: 55%;"></asp:Label>
                                           </section>
                                      </div>

                                </div>

                 </div>

                        <div style="width: 100%; float: left;" class="formdiv">
                                
                             <div style="width: 50%; float: left;">
                                <section style="width: 95%; margin-left: 5%;">
                                   <label id="lblReason" runat="server" class="lblh2" style="float: left; width: 35%;">Reason*</label>
                                 <asp:TextBox ID="txtRsn" runat="server" class="form-control" MaxLength="500" TextMode="MultiLine" Style="height:115px;width:326px;resize:none;border: 1px solid #cfcccc;font-family: calibri;" onchange="IncrmntConfrmCounter();" onkeydown="textCounter(cphMain_txtRsn,450)" onkeyup="textCounter(cphMain_txtRsn,450)" onblur="return isTag(event)"></asp:TextBox>     
                               </section>
                             </div>

                            <div id="divRejectReasn" runat="server" style="width: 50%; float: left;">
                                <section style="width: 95%; margin-left: 7%;">
                                   <label class="lblh2" style="float: left; width: 35%;">Reject Reason</label>
                                 <asp:TextBox ID="txtRejctReasnDisplay" runat="server" class="form-control" MaxLength="500" TextMode="MultiLine" Style="height:115px;width:298px;resize:none;border: 1px solid #cfcccc;font-family: calibri;" Enabled="false"></asp:TextBox>     
                               </section>
                             </div>

                        </div>

                </div>

             </div>

        <footer id="footerEndSrv" style="background: white; float: right; border-top: none;margin-right:34%;margin-top:1%;">
                  <asp:Button ID="btnConfirm" runat="server" Style="float:left;" class="btn btn-primary" Text="Request Certificate"  OnClientClick="return ValidateSalaryCertfct();" OnClick="btnConfirm_Click"/>                   
                  <asp:Button ID="btnHRApprove" runat="server" Style="float:left;" class="btn btn-primary" Text="HR Approve"  OnClientClick="return ConfirmApprove();" />                              
                  <asp:Button ID="btnHRReject" runat="server" Style="float:left;" class="btn btn-primary" Text="HR Reject"  OnClientClick="return ConfirmReject();" />                                                
                  <asp:Button ID="btnPrint" runat="server" Style="margin-left: 13px;" class="btn btn-primary" Text="Print the Certificate"  OnClientClick="return Print();" OnClick="btnPrint_Click"/>                             
                  <asp:Button ID="btnClear" runat="server" Style="margin-left: 13px;" class="btn btn-primary" Text="Cancel"  OnClientClick="return ConfirmCancel();"/>                   
        </footer>



        </div>
     </div>
    </article>
   </div>
 </section>


                    <!-- Reject reason -->

        <div id="dialog_simple" title="Dialog Simple Title">


            <div class="widget-body no-padding" id="divCancelPopUp">

                <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none; margin-top: 1%">

                    <i class="fa-fw fa fa-times"></i>
                    <strong>Error!</strong>&nbsp;<label id="lblErrMsgCancelReason"> Please fill this out</label>
                </div>

                <div style="width: 100%; float: left; clear: both; margin-top: 5%">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Reject Reason*</label>

                        <label class="input" style="float: left; width: 60%;">
                            <textarea name="txtRejctReason" rows="2" cols="20" id="txtRejctReason" class="form-control" style="resize: none;" onkeydown="textCounter(txtRejctReason,450)" onkeyup="textCounter(txtRejctReason,450)" onblur="return isTag(event)" onclick=""></textarea>
                        </label>

                    </section>
                </div>

                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateSaveCancelRsn();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" class="btn btn-default" onclick="closePopUP()"><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>

                </div>
            </div>

     </div>


   </div>
 </div>

    <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

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
</asp:Content>

