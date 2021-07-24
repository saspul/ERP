<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageNewHcm.master" AutoEventWireup="true" CodeFile="hcm_Salary_Certificate_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_Salary_Certificate_hcm_Salary_Certificate_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="../../../../JavaScript/jquery-1.8.3.min.js"></script>

   <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>

    <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />

    <link href="../../../../css/HCM/CommonCss.css" rel="stylesheet" />
    <script src="../../../../js/jQueryUI/jquery-ui.min.js"></script>
    <script src="../../../../js/jQueryUI/jquery-ui.js"></script>
    <script src="../../../../js/datepicker/bootstrap-datepicker.js"></script>
    <link href="../../../../js/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="/js/HCM/Common.js"></script>
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


        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            var session = '<%=Session["SUCCESS"]%>';

            if (session == "SAVE") {
                AddSuccesMessage();
            }
            else if (session == "APPROVE") {
                ApprvSuccesMessage();
            }
            else if (session == "REJECT") {
                RejctSuccesMessage();
            }
            else if (session == "DONEAPPROVE") {
                AlrdyApprvdSuccesMessage();
            }
            else if (session == "DONEREJECT") {
                AlrdyRejctdSuccesMessage();
            }

            '<%Session["SUCCESS"] = '"' + null + '"'; %>';

        });


        function AddSuccesMessage() {

            $noCon("#divSuccessAlert").html("Salary certificate request inserted successfully.");
            $noCon("#divSuccessAlert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divSuccessAlert").alert();
            return false;
        }

        function ApprvSuccesMessage() {

            $noCon("#divSuccessAlert").html("Salary certificate request approved successfully.");
            $noCon("#divSuccessAlert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divSuccessAlert").alert();
            return false;
        }

        function RejctSuccesMessage() {

            $noCon("#divSuccessAlert").html("Salary certificate request rejected successfully.");
            $noCon("#divSuccessAlert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divSuccessAlert").alert();
            return false;
        }

        function AlrdyApprvdSuccesMessage() {

            $noCon("#divWarningAlert").html("Salary certificate request already approved.");
            $noCon("#divWarningAlert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divWarningAlert").alert();
            return false;
        }

        function AlrdyRejctdSuccesMessage() {

            $noCon("#divWarningAlert").html("Salary certificate request already rejected.");
            $noCon("#divWarningAlert").fadeTo(2000, 500).slideUp(500, function () {

            });
            $noCon("#divWarningAlert").alert();
            return false;
        }

        function EditItem(Id) {

            document.getElementById("<%=hiddenEdit.ClientID%>").value = Id;
            document.getElementById("<%=hiddenView.ClientID%>").value = "0";
            document.getElementById('<%= btnEdit.ClientID %>').click();
            return false;
        }

        function ViewItem(Id) {

            document.getElementById("<%=hiddenView.ClientID%>").value = Id;
            document.getElementById("<%=hiddenEdit.ClientID%>").value = "0";
            document.getElementById('<%= btnEdit.ClientID %>').click();
            return false;
        }

        </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:HiddenField ID="hiddenCnclrsnMust" runat="server" />
    <asp:HiddenField ID="hiddenEdit" runat="server" />
    <asp:HiddenField ID="hiddenView" runat="server" />

     <div class="alert alert-success" id="divSuccessAlert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

    <div class="alert alert-warning" id="divWarningAlert" style="display:none">
    <button type="button" class="close" data-dismiss="alert">x</button></div>

    <div class="cont_rght">

        <div class="alert alert-success" id="success-alert" style="display: none;">
            <button type="button" class="close" data-dismiss="alert">x</button>
        </div>
        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/SalaryCertificate.png" style="vertical-align: middle;" />
            Salary Certificate
        </div>

        <div onclick="location.href='hcm_Salary_Certificate.aspx'" id="divAdd" class="add" runat="server" style="position: fixed; height: 26.5px; right: 1%; z-index: 1;"></div>


            <asp:Button runat="server" ID="btnEdit" Style="display: none;" OnClick="btnEdit_Click" />

          <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 93.5%; margin-top: 1%;height: 88px;">

                 <div style="width: 31%; float: left;margin-top: 2%;">
                    <section style="width: 95%; margin-left: 5%;">
                        <label class="lblh2" style="float: left; width: 35%;">Status</label>
                        <label class="select" style="float: left; width: 60%;">
                            <asp:DropDownList ID="ddlStatus" CssClass="form-control" class="form1" runat="server" onkeypress="return DisableEnter(event)">
                            <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Approved" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
                            </asp:DropDownList>

                        </label>
                    </section>
                </div>


              <div style="float: left;margin-left: 4%;margin-top: 2%;display:none;" class="smart-form">
                    <section style="width: 95%; margin-left: 5%;">

                        <label class="checkbox">
                            <input name="cphMain_cbxCnclStatus" id="cbxCnclStatus" runat="server" onkeydown="return DisableEnter(event);" type="checkbox" />
                            <i></i>Show Deleted Entries</label>
                    </section>
              </div>

             <div style="float: right;margin-right: 4%;margin-top: 2%;">
                    <asp:Button ID="btnSearch" Style="cursor: pointer; float: right; margin-right: 10%;" runat="server" class="btn  btn-primary" Text="Search" OnClick="btnSearch_Click" />

             </div>

              </div>

         <div id="divList" runat="server" class="widget-body" style="margin-top:2%;width: 93.5%;">
             <br />
             <br />
         </div>



    </div>


</asp:Content>

