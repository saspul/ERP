<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Document_Workflow_List.aspx.cs" Inherits="Master_gen_Document_Workflow_gen_Document_Workflow_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <script>

        var $noCon = jQuery.noConflict();

        $noCon(window).load(function () {

        });

        function AlreadyDeleted() {
            $("#danger-alert").html("Sorry, this document workflow is already deleted!");
            $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this Workflow?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        document.getElementById("lblErrMsgCancelReason").style.display = "none";

                        document.getElementById("txtCancelReason").style.borderColor = "";
                        document.getElementById("txtCancelReason").value = "";
                        $('#dialog_simple').modal('show');
                        $('#dialog_simple').on('shown.bs.modal', function () {
                            document.getElementById("txtCancelReason").focus();
                        });

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

        function ValidateCancelReason() {
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
        function DeleteByID(strId, strCancelReason, strCancelMust) {
            
            var strUserID = '<%=Session["USERID"]%>';
            var strOrgIdID = '<%=Session["ORGID"]%>';
            var strCorpID = '<%=Session["CORPOFFICEID"]%>';
           
            if (strId != "") {
              
                var Details = PageMethods.CancelReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {
                   
                    var SucessDetails = response;
                    
                    if (SucessDetails == "successcncl") {
                        
                        window.location = 'gen_Document_Workflow_List.aspx?InsUpd=Cncl';


                    }
                    else {
                        window.location = 'gen_Document_Workflow_List.aspx?InsUpd=Error';
                    }
                });
            }

            return false;
        }

   
        function ChangeStatus(strId, Status) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to change the status of the Workflow?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    if (strId != "") {
                        
                        var Details = PageMethods.ChangeStatus(strId, Status, function (response) {
                           
                            var SucessDetails = response;
                           
                            if (SucessDetails == "successchng") {
                               
                                window.location = 'gen_Document_Workflow_List.aspx?InsUpd=Sts';
                               
                            }
                            else {
                                Error();
                            }
                        });
                    }
                    return false;

                }
                return false;

            });
            return false;
        }


        function SuccessInsertion() {
            $("#success-alert").html("Document Workflow inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessUpdation() {
            $("#success-alert").html("Document Workflow updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessCancelation() {
            $("#success-alert").html("Document Workflow cancelled successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

        function SuccessStatusChng() {
           
            $("#success-alert").html("Document Workflow status changed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCnfm() {
            $("#success-alert").html("Docuemt Workflow details Confirmed successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function CancelNotPossible() {
            $("#danger-alert").html("Sorry, cancellation denied. This Document Workflow is already confirmed!");
            $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function StatusNotPossible() {
            $("#danger-alert").html("Sorry, Status Changing Denied. This Document Workflow is already confirmed!");
            $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
    </script>
 

<script>

    var $NoConfi = jQuery.noConflict();
        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
            LoadEmpList();
        });
        var $NoConfi3 = jQuery.noConflict();
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
    
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
    <asp:HiddenField ID="hiddenSearchField" runat="server" Value="0" />
    <asp:HiddenField ID="Hiddenenabledit" runat="server" />
    <asp:HiddenField ID="Hiddenenabladd" runat="server" />
    <asp:HiddenField ID="HiddenusrId" runat="server" />
    <asp:HiddenField ID="Hiddencnclsts" runat="server" />
    <asp:HiddenField ID="HiddenSuccessMsgType" runat="server" />
    <asp:HiddenField ID="HiddenEnableDelete" runat="server" />

    <!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
      <li class="active">Document Workflow</li>
    </ol>
<!---breadcrumb_section_started----> 

<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>

    <!--add_new_button--->
                <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
          <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>

       <div id="divAdd" onclick="location.href='gen_Document_Workflow.aspx'" runat="server">
           <a href="gen_Document_Workflow.aspx" type="button" id="myBtn" title="Add New">
             <i class="fa fa-plus-circle"></i>
           </a>
      </div>

<!---add_new_button_closed-->


    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Document Workflow LIST</h1>

          <div class="form-group fg2">
            <label for="email" class="fg2_la1">Document Section<span class="spn1"></span>:</label>
              <asp:DropDownList ID="dldocsec" runat="server" class="form-control fg2_inp1 fg_chs1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>     
          </div>

          <div class="form-group fg2">
            <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
              <asp:DropDownList ID="dlstatus" runat="server" class="form-control fg2_inp1 fg_chs1"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >
                  <asp:ListItem Value="1">Active</asp:ListItem>
                  <asp:ListItem Value="0">Inactive</asp:ListItem>
                  <asp:ListItem Value="2">All</asp:ListItem>
              </asp:DropDownList>
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
              <asp:Button ID="btnsearch" class="submit_ser" runat="server" OnClick="btnsearch_Click" />
          </div>

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->


            <div class="tab_res" id="divList" runat="server"></div>
      

<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
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
                    <button type="button" id="btnCnclRsn" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>



    <script>
        function PrintClick() {

            var orgID = '<%= Session["ORGID"] %>';
              var corptID = '<%= Session["CORPOFFICEID"] %>';

              var statusid = 0;

              var Suplier = 0;
              var CnclSts = 0;
              var docsec = 1;
              docsec = document.getElementById("cphMain_dldocsec").value;
              if (docsec == "--Select--")
              {
                  docsec = 0;
              }
              else
              {
                  docsec = document.getElementById("cphMain_dldocsec").value;
              }
              statusid = document.getElementById("cphMain_dlstatus").value;
              if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                  CnclSts = 1;
              }
              if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                  // alert("d");
                  $.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "gen_Document_Workflow_List.aspx/PrintList",
                      data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '",docsec:"'+docsec+'" }',
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
            var docsec = 1;
            docsec = document.getElementById("cphMain_dldocsec").value;
            statusid = document.getElementById("cphMain_dlstatus").value;
            if (docsec == "--Select--") {
                docsec = 0;
            }
            else {
                docsec = document.getElementById("cphMain_dldocsec").value;
            }
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {

                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_Document_Workflow_List.aspx/PrintCSV",

                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",statusid: "' + statusid + '",CnclSts: "' + CnclSts + '",docsec:"' + docsec + '" }',
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

