<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Tax_deducted_atSource_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Tax_deducted_atSource_fms_Tax_deducted_atSource_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <script>


        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {

            // alert(document.getElementById("<%=Hiddencncl.ClientID%>").value);

            LoadEmpList();   // emp0025

           // loadTableDesg();
            //if (SuccessMsg == "successcncl") {

            //}
        });



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
                //"bFilter": false,
                //"bInfo": false,
                //"bLengthChange": false
                "bAutoWidth": false,
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

        function SuccessClose() {



            $noCon("#success-alert").html("Tax Details cancelled successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();

            return false;
        }
        //function loadTableDesg() {

        //    $noCon(function () {
        //        $noCon('#dialog_simple').dialog({
        //            autoOpen: false,
        //            width: 600,
        //            resizable: false,
        //            modal: true,
        //            title: "Tax Deducted at Source",
        //        });
        //    });
        //}




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
            alert(Id);
        }


        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this tax details?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    //  alert(strCancelMust);
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        document.getElementById("divErrMsgCnclRsn").style.display = "none";
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
        //function OpenCancelBlock() {
        //    $noCon("#success-alert").html("Sorry, cancellation denied. This tax details is already selected somewhere!.");
        //    $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
        //    });
        //    $noCon("#success-alert").alert();
        //}

        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';

            if (strId != "" && strUserID != '') {
                // alert(strId); alert(strCancelReason); alert(strCancelMust); alert(strUserID);
                var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, function (response) {

                    var SucessDetails = response;
                    if (SucessDetails == "successcncl") {
                        //$noCon("#success-alert").html("Tax details cancelled successfully.");
                        //$noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                        //});
                        //$noCon("#success-alert").alert();


                        document.getElementById("<%=Hiddencncl.ClientID%>").value = "cncl"
                        window.location = "fms_Tax_deducted_atSource_List.aspx?InsUpd=cncl";


                           }
                           else {
                        window.location = "fms_Tax_deducted_atSource_List?InsUpd=Error";
                           }
                       });
                   }

                   return false;
               }
               function CloseCancelView() {
                   ReasonConfirm = document.getElementById("txtCancelReason").value;
              //     $("#ezok-btn").focus();
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
            document.getElementById("divErrMsgCnclRsn").style.display = "none";
            document.getElementById("lblErrMsgCancelReason").style.display = "none";
            
            document.getElementById("txtCancelReason").style.borderColor = "";

            var strCancelReason = document.getElementById("txtCancelReason").value;
            if (strCancelReason == "") {
                document.getElementById("txtCancelReason").style.borderColor = "red";
                document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                document.getElementById("divErrMsgCnclRsn").style.display = "";
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
                    document.getElementById("divErrMsgCnclRsn").style.display = "";
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
        function ErrorCancelation() {
            $noCon("#divWarning").html("Try again!");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            $noCon("#divWarning").alert();
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
        <ol class="breadcrumb sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Tax Deducted at Source (TDS) </li>
    </ol>

      <!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->
        <div class="content_sec2 cont_contr">
            <div class="content_area_container cont_contr">
            <div class="content_box1 cont_contr">
                <h1 class="h1_con">Tax Deducted at Source (TDS) LIST</h1>


                <div class="form-group fg2">
                   <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
                    <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1" runat="server" >
                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="fg2">
                    <label class="form1 mar_bo mar_tp">
                        <span class="button-checkbox">
                            <asp:CheckBox ID="CbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
                            <button type="button" class="btn-d" data-color="p"></button>
                        </span>
                        <p class="pz_s">Show Deleted Entries?</p>
                    </label>
                </div>

                <div class="fg2">
                       <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                    <asp:Button ID="btnCnclSearch" runat="server" class="submit_ser"  OnClick="btnCnclSearch_Click" />
                </div>

                <div class="clearfix"></div>
                <div class="devider"></div>


                <div id="divList" runat="server" >
                </div>

 <div id="divAdd" onclick="location.href='fms_Tax_deducted_atSource.aspx'" class="add" runat="server" style="position: fixed; height: 26.5px; right: 0.7%; display: block">
                    <a href="fms_Tax_deducted_atSource.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                        <i class="fa fa-plus-circle"></i>
                    </a>
                </div>
                            

            </div>
                </div>
            </div>
    <%--------------------------------View for error Reason--------------------------%>
            <!-- Modal1 -->
    <div class="modal fade" id="dialog_simple" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document" id="divCancelPopUp">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                       <div class="alert alert-danger fade in" id="divErrMsgCnclRsn" style="display: none;"></div>
                           <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                       
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-primary" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

<!-- Modal1 -->

   

</asp:Content>

