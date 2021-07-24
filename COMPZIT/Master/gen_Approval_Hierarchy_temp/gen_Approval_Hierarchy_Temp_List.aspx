<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Approval_Hierarchy_Temp_List.aspx.cs" Inherits="Master_gen_Approval_Hierarchy_temp_gen_Approval_Hierarchy_Temp_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <script>
      var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {  
            LoadEmpList(); 
        });
        function OpenCancelView(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this template?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
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
        function LoadEmpList() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            var otable = $NoConfi3('#datatable_fixed_column').DataTable({
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
        }
        function AlreadyCancelMsg() {       
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#divWarning").html("Template is already cancelled");
            $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });   
        }
        function SuccessConfirmation() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#success-alert").html("Approval hierarchy details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdation() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#success-alert").html("Approval hierarchy details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCancelation() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#success-alert").html("Approval hierarchy details cancelled successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }   
        function ErrorCancelation() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $("#divWarning").html("Try again!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <!----------------------------------------------Content_section_opened------------------------------------------------------------->
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
<!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li class="active">Approval Hierarchy Template</li>
    </ol>
<!---breadcrumb_section_started----> 

     <!---alert_message_section---->
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
<!----alert_message_section_closed---->

    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Approval Hierarchy Template LIST</h1>
          
          <div class="form-group fg4">
            <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
            <select class="form-control fg2_inp1 fg_chs1" id="ddlStatus" runat="server">
              <option value="1" selected="selected">Active</option>
              <option value="0">Inactive</option>
              <option value="2">All</option>
            </select>           
          </div>

          <div class="fg2">
            <label class="form1 mar_bo mar_tp">
              <span class="button-checkbox">
                <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
                <input type="checkbox" class="hidden" id="cbxCnclStatus" runat="server" />
              </span>
              <p class="pz_s">Show Deleted Entries</p>
            </label>
          </div>

          <div class="fg2">
            <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
            <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClick="btnSearch_Click" />
          </div>

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->
        <div class="tab_res" id="divList" runat="server">
        </div><!---tab_res_closed--->


<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
        </div>
      </div>
    </div>

<!----------------------------------------------Content_section_opened------------------------------------------------------------->

     <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static"    role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document" id="divCancelPopUp">
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


    <!---print_button--->
<%--<a href="#" type="button" class="print_o" title="Print page">
  <i class="fa fa-print"></i>
</a>--%>
<!---print_button_closed--->

<!---import_button_section--->
<%--<a href="#" type="button" class="imprt_o" title="Export" onclick="import_1()">
  <i class="fa fa-code-fork" aria-hidden="true"></i>
</a>--%>

<%--<div class="import_opt">
  <button class="csv_b"><i class="fa fa-file-excel-o" aria-hidden="true"></i>CSV</button> 
  <button class="pdf_b"><i class="fa fa-file-pdf-o" aria-hidden="true"></i>PDF</button>
</div>--%>
<!---import_button_section_closed--->


<!--add_new_button--->
                <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
          <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>

<a href="gen_Approval_Hierarchy_Temp.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
  <i class="fa fa-plus-circle"></i>
</a>
    <style>
        #cphMain_myBtn{
            position: fixed;
            top: 252px;
            right: 2px;
            z-index: 99;
            font-size: 28px;
            border: none;
            outline: none;
            background-color: #48acf2;
            color: #fff;
            cursor: pointer;
            padding: 0px;
            padding-top: 0px;
            border-radius: 4px;
            border-radius: 37px;
            width: 55px;
            height: 40px;
            text-align: center;
            transition-delay: 0.1s;
            padding-top: 0px;
        }
    </style>
<!---add_new_button_closed-->
<!----==========Procurement_management_script_section_started=======--->
<!-------------print_script_start--------------------->
<script>
    $(document).ready(function () {
        $(".imprt_o").click(function () {
            $(".import_opt").toggle(300);
        });
    });
</script>
<script type="text/javascript">
    $(".wr2").click(function () {
        $(".import_opt").hide(400);
    });
</script>
<!-------------print_script_close--------------------->
      <script>
          //for search option
          var $NoConfi = jQuery.noConflict();
          var $NoConfi3 = jQuery.noConflict();
          function ValidateCancelReason() {
              // replacing < and > tags
              var ret = true;
              document.getElementById("lblErrMsgCancelReason").style.display = "none";
              document.getElementById("txtCancelReason").style.borderColor = "";
              var strCancelReason = document.getElementById("txtCancelReason").value;
              if (strCancelReason == "") {
                  document.getElementById("txtCancelReason").style.borderColor = "red";
                  document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                  document.getElementById("lblErrMsgCancelReason").style.display = "";
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
                      document.getElementById("lblErrMsgCancelReason").style.display = "";
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
    </script>
   
           <script>
               function getdetails(href) {
                   window.location = href;
                   return false;
               }
               function DeleteByID(strId, strCancelReason, strCancelMust) {
                   var strUserID = '<%=Session["USERID"]%>';
                   var strOrgIdID = '<%=Session["ORGID"]%>';
                   var strCorpID = '<%=Session["CORPOFFICEID"]%>';

                   if (strId != "" && strUserID != '') {
                       var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {
                           var SucessDetails = response;
                           if (SucessDetails == "successcncl") {
                               window.location = 'gen_Approval_Hierarchy_Temp_List.aspx?InsUpd=Cncl';
                           }
                           else if (SucessDetails == "AlreadyDele") {
                               window.location = 'gen_Approval_Hierarchy_Temp_List.aspx?InsUpd=AlCancl';
                           }
                           else {
                               window.location = 'gen_Approval_Hierarchy_Temp_List.aspx?InsUpd=Error';
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
                               $('#dialog_simple').modal('show');
                               return false;
                           }
                       });
                       return false;
                   }
               }
               //END

               function PrintClick() {

                   var orgID = '<%= Session["ORGID"] %>';
                     var corptID = '<%= Session["CORPOFFICEID"] %>';

                     var statusid = 0;

                     var Suplier = 0;
                     var CnclSts = 0;
                     statusid = document.getElementById("cphMain_ddlStatus").value;
                     if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                         CnclSts = 1;
                     }
                     if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                       
                         $.ajax({
                             type: "POST",
                             async: false,
                             contentType: "application/json; charset=utf-8",
                             url: "gen_Approval_Hierarchy_Temp_List.aspx/PrintList",
                             data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '" }',
                             dataType: "json",
                             success: function (data) {
                            
                                 if (data.d != "") {
                                    
                                     window.open(data.d, '_blank');
                                 }
                                 else {
                                     Error();

                                 }
                             }
                         });
                     }
                     else {
                         window.location = '/Security/Login.aspx';
                     }
                     return false;
               }

               function PrintCSV() {

                   var orgID = '<%= Session["ORGID"] %>';
                   var corptID = '<%= Session["CORPOFFICEID"] %>';

                   var statusid = 0;

                   var Suplier = 0;
                   var CnclSts = 0;
                   statusid = document.getElementById("cphMain_ddlStatus").value;
                   if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                       CnclSts = 1;
                   }
                     if (corptID != "" && corptID != null && orgID != "" && orgID != null) {

                         $.ajax({
                             type: "POST",
                             async: false,
                             contentType: "application/json; charset=utf-8",
                             url: "gen_Approval_Hierarchy_Temp_List.aspx/PrintCSV",

                             data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '" }',
                             dataType: "json",
                             success: function (data) {
                                 //  alert("d");
                                 if (data.d != "") {
                                     // 
                                     window.open(data.d, '_blank');
                                 }
                                 else {
                                     Error();

                                 }
                             }
                         });
                     }
                     else {
                         window.location = '/Security/Login.aspx';
                     }
                     return false;
                 }
               </script>
</asp:Content>

