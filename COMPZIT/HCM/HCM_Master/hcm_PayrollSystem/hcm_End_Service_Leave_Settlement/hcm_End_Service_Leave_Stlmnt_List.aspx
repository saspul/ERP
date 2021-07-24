<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_End_Service_Leave_Stlmnt_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_End_Service_Leave_Settlement_hcm_End_Service_Leave_Stlmnt_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">




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
    
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />

   <%-- <script src="/js/HCM/Common.js"></script>--%>
    <script>

        var $noCon = jQuery.noConflict();
        $noCon(document).ready(function () {
            LoadTableStyle();
        });
        var $noCon1 = jQuery.noConflict();
        function LoadTableStyle() {


            var responsiveHelper_dt_basic = undefined;


            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };

            $noCon1('#dt_basic').dataTable({
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
                    if (!responsiveHelper_dt_basic) {
                        responsiveHelper_dt_basic = new ResponsiveDatatablesHelper($noCon1('#dt_basic'), breakpointDefinition);
                    }
                },
                "rowCallback": function (nRow) {
                    responsiveHelper_dt_basic.createExpandIcon(nRow);
                },
                "drawCallback": function (oSettings) {
                    responsiveHelper_dt_basic.respond();
                }
            });

        }

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
      //  noCon4JScommon
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
                        //cancl rsn must

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

                //(string strServiceLveSttlmntID, string strUserID, string strCancelReason, string strCancelMust)
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
                            //deleted
                            // alert("del");
                            window.location = "hcm_End_Service_Leave_Stlmnt_List.aspx";

                        }

                    },
                    failure: function (response) {
                        //alert(response.d);

                    }
                });
            }


            return false;
        }
    </script>

    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            loadTableDesg();
            if (document.getElementById("<%=HiddentxtDateOfLeaving.ClientID%>").value != "0") {
                document.getElementById("txtDateOfLeaving").value = document.getElementById("<%=HiddentxtDateOfLeaving.ClientID%>").value;
            }


            var session = '<%=Session["SUCCESS_MSG"]%>';
                        if (session == "PAID") {
                            PaidSuccesMessage();
                        }
           '<%Session["SUCCESS_MSG"] = '"' + null + '"'; %>';


            //messages
            var SuccessMsg = document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value;
           
            if (SuccessMsg == "SAVE") {
                AddSuccesMessage();
            }
            else if (SuccessMsg == "UPDATE") {
                UpdateSuccesMessage();
            }
            else if (SuccessMsg == "CONFIRM") {
                ConfirmSuccesMessage();
            }
            else if (SuccessMsg == "DELETE") {
                DeleteSuccesMessage();
            }

            document.getElementById("<%=HiddenSuccessMsgType.ClientID%>").value = "0";
            document.getElementById("cphMain_ddlEmployee").focus();


        });


        function loadTableDesg() {
            var $noC = jQuery.noConflict();
            $noC(function () {

                // $('#cphMain_TabContainer').tabs();

                //$('#dialog_link').click(function () {
                //    $('#dialog_simple').dialog('open');
                //    return false;

                //});

                $noCon('#dialog_simple').dialog({
                    autoOpen: false,
                    width: 600,
                    resizable: false,
                    modal: true,
                    title: "End Of Service Settlement",
                    //position: 'top'

                });


            });
        }
        //show messages 
        function AddSuccesMessage() {

            // SuccessMsg("SAVE", " End Of Service Settlement details inserted successfully.");
            // document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details inserted successfully.";

            $noCon("#success-alert").html("End Of Service Settlement details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        } function UpdateSuccesMessage() {

            // SuccessMsg("SAVE", "End Of Service Settlement details updated successfully.");
            //  document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details updated successfully.";
            $noCon("#success-alert").html("End Of Service Settlement details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        } function ConfirmSuccesMessage() {

            //SuccessMsg("SAVE", "End Of Service Settlement confirmed successfully.");
            // document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details confirmed successfully.";
            $noCon("#success-alert").html("End Of Service Settlement details confirmed successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        function DeleteSuccesMessage() {

            //SuccessMsg("SAVE", "End Of Service Settlement cancelled successfully.");
            // document.getElementById("spanMsgHead").innerText = "End Of Service Settlement details cancelled successfully.";
            $noCon("#success-alert").html("End Of Service Settlement details cancelled successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }

        function CancelNotPosible() {

            SuccessMsg("SAVE", "Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            //$noCon("#success-alert").html("End Of Service Settlement details inserted successfully.");
            //$noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            //});
            //$noCon("#success-alert").alert();

            return false;
        }

        function PaidSuccesMessage() {            
            $noCon("#success-alert").html("End of service settlement payment process paid successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }

        function ViewPopUp(viewid) {

            document.getElementById("<%=hiddenViewValue.ClientID%>").value = viewid;
              document.getElementById('<%=btnView.ClientID %>').click();
              return false;
          }
          function openWindowLeave() {
              var nWindow = window.open('/HCM/HCM_Master/hcm_PayrollSystem/hcm_End_Service_Leave_Settlement/hcm_End_Service_Leave_Settlement.aspx', 'PoP_Up', 'width=1300,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
              return false;
          }
    </script>
    <style>
        .cont_rght {
         
            padding: 20px 0 0;
        }
  
        /*body {
  font-family: Calibri;
}*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">







    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:Button runat="server" ID="btnEdit" OnClick="btnEdit_Click" Style="display: none;" />
    <asp:Button ID="btnView" runat="server" Text="Button" OnClick="btnView_Click" Style="display: none" />



    <asp:HiddenField ID="hiddenViewValue" runat="server" />

    <asp:HiddenField ID="hiddenRsnid" runat="server" />

    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenSearch" runat="server" />

    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
    <asp:HiddenField ID="hiddenDeleteID" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />

    <asp:HiddenField ID="hiddenEditID" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenViewID" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenSuccessMsgType" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenEnableConfirm" Value="0" runat="server" />
    <asp:HiddenField ID="hiddenPaidMode" runat="server" />

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>

    <div class="cont_rght">

        <div class="alert alert-success" id="success-alert" style="display: none;">
            <button type="button" class="close" data-dismiss="alert">x</button>
        </div>
        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/end of service settlement.png" style="vertical-align: middle;" />
            End Of Service Settlement 
        </div>

        <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 93.5%; margin-top: 1%;">

            <div style="width: 100%; float: left;" class="formdiv">
                <div style="width:35%; float: left;">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Employee</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList runat="server" ID="ddlEmployee" onkeypress="return DisableEnter(event)" CssClass="form-control"></asp:DropDownList>

                        </label>
                    </section>
                </div>
                <div style="width: 35%; float: left;">
                    <section style="width: 95%; margin-left: 7%;">
                        <label class="lblh2" style="float: left; width: 35%;">Date of Leaving</label>
                        <label class="input" style="float: left; width: 60%;">
                            <%--<asp:TextBox ID="txtDateOfLeaving2" CssClass="form-control" onkeydown="return isNumberrr(event,'cphMain_txtRefNo');" onblur="return RemoveTag('cphMain_txtRefNo');" onkeypress="return isTag(event);" runat="server" MaxLength="3" Style="text-transform: uppercase; margin-right: 4%;"></asp:TextBox>--%>
                            <input id="txtDateOfLeaving" name="txtDateOfLeaving" type="text" class="form-control datepicker" onkeypress="return DisableEnter(event)" data-dateformat="dd/mm/yy" placeholder="dd-mm-yyyy" maxlength="50" onchange="GetDate()" />
                            <asp:HiddenField ID="HiddentxtDateOfLeaving" runat="server" Value="0" />
                            <script>
                               
                                $noCon('#txtDateOfLeaving').datepicker({
                                    autoclose: true,
                                    format: 'dd/mm/yyyy',

                                    timepicker: false
                                });
                                function GetDate() {
                                    //$noCon("#txtDateOfLeaving").datepicker().datepicker("setDate", new Date());

                                    DateCheck();
                                    $noCon('#cphMain_HiddentxtDateOfLeaving').val($noCon('#txtDateOfLeaving').val());

                                }
                                function SetDate() {


                                    $noCon('#txtDateOfLeaving').val($noCon('#cphMain_HiddentxtDateOfLeaving').val());

                                }
                                function DateCheck() {

                                    var ret = true;

                                    var Rcptdate = document.getElementById("txtDateOfLeaving").value;


                                    if (Rcptdate == "") {

                                    }
                                    else {
                                        var RCPTdata = Rcptdate.split("/");

                                        if (isNaN(parseInt(RCPTdata[0])) == true || isNaN(parseInt(RCPTdata[1])) == true || isNaN(parseInt(RCPTdata[2])) == true) {
                                            ret = false;
                                        }
                                        else {

                                            if (isNaN(Date.parse(RCPTdata[2] + "/" + RCPTdata[1] + "/" + RCPTdata[0]))) {

                                                ret = false;

                                            }
                                            else {

                                                var FormatDatearr = Rcptdate.split("/");
                                                var txtDay = FormatDatearr[0];
                                                var txtMonth = FormatDatearr[1];
                                                var txtYear = FormatDatearr[2];

                                                if (txtDay < 10) {
                                                    txtDay = "0" + parseInt(txtDay);
                                                }
                                                if (txtMonth < 10) {
                                                    txtMonth = "0" + parseInt(txtMonth);
                                                }
                                                if (txtYear.length != 4) {
                                                    ret = false;
                                                }

                                                document.getElementById("txtDateOfLeaving").value = txtDay + '/' + txtMonth + '/' + txtYear;

                                                if (isNaN(Date.parse(txtYear + "/" + txtMonth + "/" + txtDay))) {

                                                    ret = false;

                                                }



                                            }

                                        }
                                    }
                                    if (ret == false) {
                                        $noCon("#txtDateOfLeaving").datepicker().datepicker("setDate", new Date());
                                    }

                                }
                            </script>
                        </label>
                    </section>
                </div>

                 <div style="width: 30%; float: left;">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 25%;">Status</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control" class="form1" runat="server" onkeypress="return DisableEnter(event)">
                            <asp:ListItem Text="Not Confirmed" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Confirmed" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Payment Pending" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Paid" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Closed" Value="5"></asp:ListItem>
                            </asp:DropDownList>

                        </label>
                    </section>
                </div>

            </div>

            <div style="width: 100%; float: left;" class="formdiv">
                <div style="width: 35%; float: left;">

                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Employee Status</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList ID="ddlEmployeeStatus" CssClass="form-control" class="form1" runat="server" onkeypress="return DisableEnter(event)">
                                <asp:ListItem Text="--SELECT STATUS--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Resignation" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Termination" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Retirement" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Abscond" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Death" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Rejoin" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Under Police custody" Value="7"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="8"></asp:ListItem>
                            </asp:DropDownList>

                        </label>
                    </section>
                </div>
                <div style="width: 35%; float: left;" class="smart-form">
                    <section style="width: 60%; margin-left: 7%;">

                        <label class="checkbox" style="font-family: Calibri; font-size: 17px; text-align: left; color: #909c7b;">
                            <input name="cphMain_cbxCnclStatus" id="cbxCnclStatus" runat="server" onkeydown="return DisableEnter(event);" type="checkbox" />
                            <%--<asp:CheckBox ID="cbxCnclStatus" name="checkbox" Text="" runat="server" onkeydown="return DisableEnter(event);" Checked="false" />--%>

                            <i></i>Show Deleted Entries</label>
                    </section>
                </div>
                <div style="width: 20%; float: right;">
                    <asp:Button ID="btnSearch" Style="cursor: pointer;  margin-right: 10%;" runat="server" class="btn  btn-primary" Text="Search" OnClick="btnSearch_Click" />

                </div>
            </div>


            <br style="clear: both" />
        </div>
        <br />

        <div onclick="location.href='hcm_End_Service_Leave_Settlement.aspx'" id="divAdd" class="add" runat="server" style="position: fixed; height: 26.5px; right: 1%; z-index: 1;">

            <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
        <%--  <br />
        <br />--%>
        <div id="divReport" class=" no-padding" style=" width: 93.5%;   border: 1px solid #ddd;" runat="server">
            <table id="dt_basic" class="table table-striped table-bordered table-hover" width="100%">
                <thead>
                    <tr>
                        <th data-hide="phone">ID</th>
                        <th data-class="expand"><i class="fa fa-fw fa-user text-muted hidden-md hidden-sm hidden-xs"></i>Name</th>
                        <th data-hide="phone"><i class="fa fa-fw fa-phone text-muted hidden-md hidden-sm hidden-xs"></i>Phone</th>
                        <th>Company</th>
                        <th data-hide="phone,tablet"><i class="fa fa-fw fa-map-marker txt-color-blue hidden-md hidden-sm hidden-xs"></i>Zip</th>
                        <th data-hide="phone,tablet">City</th>
                        <th data-hide="phone,tablet"><i class="fa fa-fw fa-calendar txt-color-blue hidden-md hidden-sm hidden-xs"></i>Date</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>Jennifer</td>
                        <td>1-342-463-8341</td>
                        <td>Et Rutrum Non Associates</td>
                        <td>35728</td>
                        <td>Fogo</td>
                        <td>03/04/14</td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Clark</td>
                        <td>1-516-859-1120</td>
                        <td>Nam Ac Inc.</td>
                        <td>7162</td>
                        <td>Machelen</td>
                        <td>03/23/13</td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Brendan</td>
                        <td>1-724-406-2487</td>
                        <td>Enim Commodo Limited</td>
                        <td>98611</td>
                        <td>Norman</td>
                        <td>02/13/14</td>
                    </tr>

                </tbody>
            </table>
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
                        <button type="button" id="btnCancelRsnSave" onclick="return validateSaveCancelRsn();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" class="btn btn-default" onclick="closePopUP();"><i class="fa fa-times"></i>&nbsp; Cancel</button>
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
                function closePopUP() {
                    $noCon('#dialog_simple').dialog('close');
                    return false;
                }
            </script>
            <!-- end widget content -->
        </div>



    </div>


    <script>
        function ToPaid(Id, RowCount) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to pay the settlement?",
                alertType: "info"
            }).done(function (e) {
                if (e == true){
            var objId = {};
            objId.Id = Id          
            $noCon.ajax({
                async: false,
                type: "POST",
                url: "hcm_End_Service_Leave_Stlmnt_List.aspx/UpdateSettledStatus",
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
                url: "hcm_End_Service_Leave_Stlmnt_List.aspx/PaidAll_UpdateSettledStatus",
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
    <script src="/js/HCM/Common.js"></script>
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });
    </script>
</asp:Content>

