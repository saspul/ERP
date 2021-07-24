<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="Employee_Perfomance_Templt_List.aspx.cs" Inherits="Employee_Performance_Templt_Employee_Perfomance_Templt_List" %>

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
    <script src="/js/HCM/Common.js"></script>

    <script>
    
     
        var $noCon1= jQuery.noConflict();
        $noCon1(window).load(function () {
           
           // alert(document.getElementById("<%=Hiddencncl.ClientID%>").value);
           
            LoadEmpList();   // emp0025
      
            loadTableDesg();
            if (SuccessMsg == "successcncl") {
              
            }
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
                //"bAutoWidth": false,
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

          

            $noCon("#success-alert").html("Performance template cancelled successfully.");
             $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
             });
             $noCon("#success-alert").alert();

             return false;
         }
        function loadTableDesg() {

            $noCon(function () {
                $noCon('#dialog_simple').dialog({
                    autoOpen: false,
                    width: 600,
                    resizable: false,
                    modal: true,
                    title: "Performance Template",
                });
            });
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
            alert(Id);
        }


        function OpenCancelView(StrId) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this performance template?",
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
        function OpenCancelBlock()
        {
            $noCon("#success-alert").html("Sorry, cancellation denied. This performance template is already selected somewhere!.");
            $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            $noCon("#success-alert").alert();
        }

        function DeleteByID(strId, strCancelReason, strCancelMust) {
            var strUserID = '<%=Session["USERID"]%>';

                   if (strId != "" && strUserID != '') {
                     // alert(strId); alert(strCancelReason); alert(strCancelMust); alert(strUserID);
                       var Details = PageMethods.CancelMemoReason(strId, strCancelMust, strUserID, strCancelReason, function (response) {

                           var SucessDetails = response;
                           if (SucessDetails == "successcncl") {
                               $noCon("#success-alert").html("Performance template cancelled successfully.");
                               $noCon("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                               });
                               $noCon("#success-alert").alert();

                              
                               document.getElementById("<%=Hiddencncl.ClientID%>").value ="cncl"
                               window.location = "Employee_Perfomance_Templt_List.aspx?InsUpd=cncl'";


                           }
                           else {
                               window.location = 'Employee_Perfomance_Templt_List?InsUpd=Error';
                           }
                       });
                   }

                   return false;
        }
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
       <asp:HiddenField ID="hiddenEnableCancl" runat="server" /> <%-- emp0025--%>

    <asp:Button ID="btnEdit" runat="server" Text="Button" style="display:none"/>

              <div class="alert alert-success" id="success-alert" style="display:none">
            <button type="button" class="close" data-dismiss="alert">x</button> 
        </div>
        <div class="cont_rght">

                   
          
        

            <div onclick="location.href='Employee_Performance_Templt.aspx'" id="divAdd" class="add" runat="server" style="position: fixed; height:26.5px; right:0%;margin-top: 2%; z-index: 1;">
        </div>

        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/PERFORMANCE TEMPLATE.png" style="vertical-align: middle;" />
          Performance Templates
        </div >
                        

         <div style="width: 99%; float: left;  border: 1px solid #c3c3c3;height: 50px; background:#fafafa;margin-bottom: 7px;margin-top: 2%;">


          

              <div class="eachform" style="width: 22%;margin: 0 0 0px;margin-top: 1%;float: left;margin-left: 3%;">  <%--emp0025--%>

                <h2 style="margin-top:1%;">Status</h2>

                <asp:DropDownList ID="ddlStatus" Height="30px" Width="160px" class="form1" runat="server" Style="margin-left: 15%;">
                   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                   
                </asp:DropDownList>

                 </div>
            <div style="width: 29%; float: left;margin-left: 7%;">
                
                        <section style="width:55%;float:right;margin-bottom:0px;margin-right: 0%;">
                      
                <label class="checkbox" style="float: left;">
                <input name="checkbox-inline" id="CbxCnclStatus" onkeypress="return DisableEnter(event)" onkeydown="return DisableEnter(event)" runat="server"  type="checkbox"  />
                 <i></i></label>
                            <label class="lblh2" style="float: left;width: 100%;Height:33px;margin-top:6.7%;"> <h class="page-title txt-color-blueDark">Show Deleted Entries </h></label>
                 </section> 
        
                </div>
                                   <div style="width: 37%; float: left;">               
                          <asp:Button ID="btnCnclSearch" style="margin-top:2.3%; height:31px;cursor:pointer; width: 104px;margin-left: 60%;" runat="server" class="btn btn-primary" Text="Search" OnClick="btnCnclSearch_Click" />     
               </div>

                        </div>

         <div id="divList" runat="server" class="widget-body" style="margin-top:2%;width: 99%;">
             <br />
             <br />
         </div>

               
               <%--------------------------------View for error Reason--------------------------%>


        <div id="dialog_simple" title="Dialog Simple Title"  style="display:none;">
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
                            <textarea name="txtCancelReason" rows="2" cols="20" id="txtCancelReason" class="form-control" style="text-transform: uppercase; resize: none;"   onkeydown="textCounter(txtCancelReason,500)" onkeyup="textCounter(txtCancelReason,500)"></textarea>
                        </label>

                    </section>
                </div>

                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="border-top: none;">
                    <div class="ui-dialog-buttonset">
                        <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-danger"><i class="fa fa-trash-o"></i>&nbsp; SAVE</button>
                        <button type="button" class="btn btn-default" onclick="return CloseCancelView();"  ><i class="fa fa-times"></i>&nbsp; Cancel</button>
                    </div>

                </div>
            </div>

     </div>

   </div>
    <style>
        .fa {
            font-size: large;
        }
    </style>

    <script type="text/javascript" src="js/loader.js"></script>
<script>


    function FunctionPreview(id) {

        var nWindow = window.open('../Employee_Performance_Templt/Employee_Performance_Templt.aspx?ViewId=' + id + '&RFGP=VW', 'PoP_Up', 'width=1500,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
        // nWindow.focus();
    }

</script>

</asp:Content>

