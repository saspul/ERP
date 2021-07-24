<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="fms_Cost_Center_List.aspx.cs" Inherits="FMS_FMS_Master_fms_Cost_Center_fms_Cost_Center_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
     
    <script>
        var $noCon1 = jQuery.noConflict();
        $noCon1(window).load(function () {
        
            LoadEmpList();   // emp0025

        });

        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to delete this cost centre?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        //cancl rsn must

                        //document.getElementById("lblErrMsgCancelReason").style.display = "none";
                        //$("div.war").fadeIn(200).delay(500).fadeOut(400);
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
        function AlreadyCancelMsg() {
           
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $noCon("#divWarning").html("Cost centre is already cancelled");
            $noCon("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
           
           
        }
        function SuccessConfirmation() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $noCon("#success-alert").html("Cost centre details inserted successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            

            return false;


        }
        function SuccessUpdation() {
            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $noCon("#success-alert").html("Cost centre details updated successfully.");
            $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            

            return false;

        }

        function SuccessCancelation() {


            document.getElementById("<%=ddlStatus.ClientID%>").focus();
            $noCon("#success-alert").html("cost centre details cancelled successfully.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            

            return false;
        }
        
        function ErrorCancelation() {

            document.getElementById("<%=ddlStatus.ClientID%>").focus();

            $noCon("#divWarning").html("Try again!");
            $noCon("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
           

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

    <ol class="breadcrumb sticky1 sticky1">
        <li><a id="aHome" runat="server" href="">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Finance.aspx">Finance Management</a></li>
        <li class="active">Cost Centre</li>
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
                <h1>Cost Centre</h1>
                <div class="">
                    <div class="fg2">
                        <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
                        <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 fg_chs1" runat="server">
                            <asp:ListItem Text="All" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                            
                        </asp:DropDownList>
                    </div>

                    <div class="fg2">
                        <label class="form1 mar_bo mar_tp">
                            <span class="button-checkbox">
                                <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" onkeypress="return DisableEnter(event);" Checked="false" class="form2" />
                                <button type="button" class="btn-d" data-color="p"></button>
                            </span>
                            <p class="pz_s">Show Deleted Entries</p>
                        </label>
                    </div>
                    <div class="fg2">
                        <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                        <asp:Button ID="btnSearch" runat="server" class="submit_ser" OnClientClick="return LoadEmployeeList();" OnClick="btnSearch_Click" />
                    </div>
                </div>
                <div onclick="location.href='fms_Cost_Center.aspx'" id="divAdd" class="add" runat="server">
                    <a href="fms_Cost_Center.aspx" type="button" onclick="topFunction()" id="myBtn" title="Add New">
                        <i class="fa fa-plus-circle"></i>
                    </a>
                </div>
                <div id="divList" runat="server" class="table_box tb_scr">
                </div>
            </div>
        </div>
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


               function ErrorCancelation() {
                   $noCon("#success-alert").html("cost centre status changed successfully.");
                   $noCon("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                   });
                   

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
                       var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {

                           var SucessDetails = response;
                           if (SucessDetails == "successcncl") {

                               window.location = 'fms_Cost_Center_List.aspx?InsUpd=Cncl';


                           }
                           else {
                               window.location = 'fms_Cost_Center_List.aspx?InsUpd=Error';
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


               </script>
     <script>

    </script>

     
</asp:Content>


