<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="pms_VendorCategoryList.aspx.cs" Inherits="PMS_PMS_Master_pms_Vendor_Category_pms_VendorCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/js/New%20js/js/boot.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/New css/pro_mng.css" />

<%--    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>--%>

    <script>

        $(window).load(function () {
            $("#cphMain_ddlStatus").focus();

            LoadEmpList();
        });
        $(document).ready(function () {
            $("#cphMain_ddlStatus").focus();
        });
        function LoadEmpList() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var responsiveHelper_datatable_fixed_column = undefined;
            var breakpointDefinition = {
                tablet: 1024,
                phone: 480
            };
            var otable = $('#datatable_fixed_column').DataTable({
                "bDestroy": true,
                "preDrawCallback": function () {
                    if (!responsiveHelper_datatable_fixed_column) {
                        responsiveHelper_datatable_fixed_column = new ResponsiveDatatablesHelper($('#datatable_fixed_column'), breakpointDefinition);
                    }
                },
                "rowCallback": function (nRow) {
                    responsiveHelper_datatable_fixed_column.createExpandIcon(nRow);
                },
                "drawCallback": function (oSettings) {
                    responsiveHelper_datatable_fixed_column.respond();
                }
            });
            $("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {
                otable
                    .column($(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();

            });
        }


        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this vendor category details?",
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

            if (strId != "" && strUserID != '') {
                var Details = PageMethods.CancelVenderCategoryReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {

                    var SucessDetails = response;
                    if (SucessDetails == "successcncl") {

                        window.location = 'pms_VendorCategoryList.aspx?InsUpd=Cncl';


                    }
                    else {
                        window.location = 'pms_VendorCategoryList.aspx?InsUpd=Error';
                    }
                });
            }

            return false;
        }

        function SuccessCancelation() {
            $("#success-alert").html("Vender category details cancelled successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpdate() {
            $("#success-alert").html("Vender category updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ErrorCancelation() {
            $("#divWarning").html("Try again!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:HiddenField ID="HiddenFieldQryString" runat="server" />
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />

    <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Pms.aspx">Procurement Management</a></li>
        <li class="active">Vendor Category</li>
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
                <h1 class="h1_con">Vendor Category LIST</h1>

                <div class="form-group fg2">
                    <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
                    <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1" runat="server">
                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                        <asp:ListItem Text="All" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="fg2">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <asp:CheckBox ID="cbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
                            <button type="button" class="btn-d" data-color="p"></button>
                        </span>
                        <p class="pz_s">Show Deleted Entries</p>
                    </label>
                </div>

                <div class="fg2">
                    <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClick="btnSearch_Click" />
                </div>
                <div class="clearfix"></div>
                <div class="devider"></div>
                <div id="divList" runat="server" class="tab_res">
                </div>
            </div>
        </div>
    </div>
    <div id="divAdd" onclick="location.href='pms_Vendor_Category.aspx'" class="add" runat="server">
        <a href="pms_Vendor_Category.aspx" type="button"  id="myBtn" title="Add New">
            <i class="fa fa-plus-circle"></i>
        </a>
    </div>
            <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
      <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>
   
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
        function PrintVersnError() {
            $noCon("#divWarning").html("Please select a version for printing from account setting.");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });

            return false;
        }
        function PrintClick() {

            var orgID = '<%= Session["ORGID"] %>';
               var corptID = '<%= Session["CORPOFFICEID"] %>';
               
               var statusid = 0;
               
               var Suplier = 0;
               var CnclSts = 1;
               statusid = document.getElementById("cphMain_ddlStatus").value;
               if (document.getElementById("cphMain_cbxCnclStatus").checked == true)
                   {
                   CnclSts = 0;
               }
               if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                  // alert("d");
                   $.ajax({
                       type: "POST",
                       async: false,
                       contentType: "application/json; charset=utf-8",
                       url: "pms_VendorCategoryList.aspx/PrintList",
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
            var CnclSts = 1;
            statusid = document.getElementById("cphMain_ddlStatus").value;
            if (document.getElementById("cphMain_cbxCnclStatus").checked == true) {
                CnclSts = 0;
            }
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
               
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "pms_VendorCategoryList.aspx/PrintCSV",

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

