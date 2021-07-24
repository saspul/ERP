<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_approval_assignment_list.aspx.cs" Inherits="Master_gen_approval_assignment_gen_approval_assignment_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script>
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <script>

    

        function SuccessIns() {
            $("#success-alert").html("Approval Assignment details inserted successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessUpd() {
            $("#success-alert").html("Approval Assignment details updated successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCnfm() {
            $("#success-alert").html("Approval Assignment details Confirmed successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessReopen() {
            $("#success-alert").html("Approval Assignment details Reopened successfully");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function SuccessCancelation() {
            $("#success-alert").html("Approval Set cancelled successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {

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
      <li class="active">Approval Assignment</li>
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











    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">APPROVAL ASSIGNMENT LIST</h1>

         

<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->
            <div class="tab_res" id="divList" runat="server">
        </div>
      


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











<!----------------------------------------------Content_section_opened------------------------------------------------------------->

<!-------------------footer_section_opened------------------------------------->
  <div class="footer" onclick="closeNav4(), closeNav5(), closeNav()">
    <p class="tr_l foot_l up_cs"><i class="ft_ico"><img src="../images/ft_ico.png"></i> Procurement Management</p>
    <p class="p_col1"><img src="../images/logo.png" class="img_foot"></p>
    <p class="pull-right tr_c foot_l ">Designed by <span>democompany</span> Technologies</p>
  </div>
<!-------------------footer_section_closed------------------------------------->

<!--wrapper_closed-->


<!---print_button--->
<!---<a href="#" type="button" class="print_o" title="Print page">
  <i class="fa fa-print"></i>
</a>--->
<!---print_button_closed--->

<!---import_button_section--->
<a href="gen_approval_assignment.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
  <i class="fa fa-plus-circle"></i>
</a>
       <button id="print" onclick="return PrintClick();" class="print_o" title="Print page"><i class="fa fa-print"></i></button>
      <button id="csv" onclick="return PrintCSV();" title="CSV" class="imprt_o"><i class="fa fa-file-excel-o"></i></button>
   
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
<!---<div class="import_opt">
  <button class="csv_b"><i class="fa fa-file-excel-o" aria-hidden="true"></i>CSV</button> 
  <button class="pdf_b"><i class="fa fa-file-pdf-o" aria-hidden="true"></i>PDF</button>
</div>--->
<!---import_button_section_closed--->


<!--add_new_button--->

<!---add_new_button_closed-->

<!---alert_message_section---->
<div class="myAlert-top alert alert-success">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully is simply dummy text of the printing and typesetting industry.
</div>

<div class="myAlert-bottom alert alert-danger">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted is simply dummy text of the printing and typesetting industry.
</div>
<!----alert_message_section_closed---->



<div class="footer" onclick="closeNav4(), closeNav5(), closeNav()">
  <p class="tr_l foot_l up_cs"><i class="ft_ico"><img src="../images/ft_ico.png"></i> Procurement Management</p>
  <p class="p_col1"><img src="../images/logo.png" class="img_foot"></p>
  <p class="pull-right tr_c foot_l ">
    Designed by <span>democompany</span> Technologies
  </p>
</div>

<!----------------------------------------------Content_section_closed------------------------------------------------------------->



<!----==========Procurement_management_script_section_started=======--->


<!-------------print_script_start--------------------->
     
<script>
    function getdetails1(href) {
        window.location = href;
        return false;
    }

    function PrintClick() {

        var orgID = '<%= Session["ORGID"] %>';
        var corptID = '<%= Session["CORPOFFICEID"] %>';

       
        if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
           // alert("d");
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_approval_assignment_list.aspx/PrintList",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '"}',
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

            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
               
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_approval_assignment_list.aspx/PrintCSV",

                    data: '{orgID: "' + orgID + '",corptID: "' + corptID + '" }',
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

