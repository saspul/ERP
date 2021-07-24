<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Monthly_Salary_Satement.aspx.cs" Inherits="HCM_HCM_Master_hcm_PayrollSystem_hcm_Monthly_Salary_Process_hcm_Monthly_Salary_Satement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

       <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatable-export/dataTables.buttons.min.js"></script>
    <script src="/css/New%20Plugins/datatable-export/buttons.flash.min.js"></script>
    <script src="/css/New%20Plugins/datatable-export/jszip.min.js"></script>
    <script src="/css/New%20Plugins/datatable-export/pdfmake.min.js"></script>
    <script src="/css/New%20Plugins/datatable-export/vfs_fonts.js"></script>
    <script src="/css/New%20Plugins/datatable-export/buttons.html5.min.js"></script>
    <script src="/css/New%20Plugins/datatable-export/buttons.print.js"></script>

    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/datatable-export/buttons.dataTables.min.css" rel="stylesheet" />
    <link href="/css/HCM/CommonCss.css" rel="stylesheet" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:HiddenField ID="HiddenFieldIndividualRound" runat="server" Value="0"/>
     <asp:HiddenField ID="HiddenFieldListMode" runat="server" Value="0"/>
    <asp:HiddenField ID="hiddenDate" runat="server" />
                                 <div id="divList" class="list"  onclick="return ConfirmCancel();"  runat="server" style="position:fixed; right:0%; top:30%;height:26.5px;z-index:1;"> </div>

    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/mnthly_salary.png" style="vertical-align: middle;" /><span id="idPageHead" runat="server">Monthly Salary Statement</span> 
        </div>          
        <div style="width:99%;border: 1px solid #065757;margin-top: 1%;background:#f4f6f0;">        
            </div>        
        <br />  


    <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: -7.5%; font-family: Calibri;" class="print">
        <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Master/hcm_PayrollSystem/hcm_Monthly_Salary_Process/Common_print.htm" style="color: rgb(83, 101, 51); margin-right: 15%">
            <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%; margin-right: 15%" />
            <span style="margin-top: -28px; float: right;">Print</span></a>
    </div>
    <div style="width: 99%; Height: 50px; border: 1px solid #065757; margin-top: 1%; background: #f4f6f0;">



        <div class="eachform" style="width: 25%; margin-bottom: 0%;">
            <div class="subform" style="width: 215px; padding-top: 10px;">
                <asp:CheckBox ID="cbxAllowance" Text=""  runat="server" Checked="false" class="form2" />
                <h3 style="margin-top: 1%;">Show Primary Allowance</h3>
                
            </div>
        </div>
        <div class="eachform" style="width: 25%; margin-bottom: 0%;">
            <div class="subform" style="width: 215px;">
                <asp:CheckBox ID="cbxDeduction" Text="" runat="server" Checked="false" class="form2" />
                <h3 style="margin-top: 1%;">Show Primary Deduction</h3>
                
            </div>
        </div>
        <div class="eachform" style="width:25%;height: 16px;">
                             <asp:Button ID="btnSearch"  style="cursor:pointer;margin-top: -0.4%;margin-left: 10%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return PrintSalryDtls();"  />
                     </div>
    </div>

    <div id="divSalaryStatement" runat="server" class="widget-body no-padding" style="margin-top: 2%; width: 100%;overflow-x:auto;">
    </div>
   

    <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>

      <style>

                 .bold_th {
        font-weight:bold
        }
        table.dataTable tbody td {
            word-break: break-all;
        }

        .table {
            font-size: 13px;
        }

        input[type="radio"] {
            display: table-cell;
        }
        .datepicker table tr td, .datepicker table tr th {
            text-align: center;
            width: 10px;
            height: 0px;
            border-radius: 0px;
            border: none;
            visibility: visible;
        }


.table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
   
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
  
    </style>

    <script>

        var $nooC = jQuery.noConflict();

        $nooC(document).ready(function () {           

            PrintSalryDtls();         
            
             });     

        var $NoConfi = jQuery.noConflict();
        var $NoConfi3 = jQuery.noConflict();    

        function ConfirmCancel() {
            
            if (document.getElementById("<%=HiddenFieldListMode.ClientID%>").value=="5") {
                window.location.href = "/HCM/HCM_Master/hcm_PayrollSystem/hcm_Payment_Closing_Process/hcm_Payment_Closing_Process_List.aspx";
            }
            else {
                window.location.href = "hcm_Monthly_Salary_Process_List.aspx";
            }
            return false;
        }

        function PrintSalryDtls() {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var salProcessDetails = '<%= Session["SALARPRSS"] %>';
            var fields = salProcessDetails.split('~');
            var SaveOrConf = fields[0];
            var CorpdepId = fields[1];
            var staffWrk = fields[2];
            var ddate = fields[3];
            var month = fields[4];
            var Year = fields[5];

            var cbxAllowance = 0;
            var cbxDeduction = 0;
            if (document.getElementById("<%=cbxAllowance.ClientID%>").checked) {
                cbxAllowance = 1;
            }
            if (document.getElementById("<%=cbxDeduction.ClientID%>").checked) {
                cbxDeduction = 1;
            }

            $.ajax({
                url: "SalaryProcess.ashx",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: { 'orgID': '' + orgID + '', 'corptID': '' + corptID + '', 'SaveOrConf': '' + SaveOrConf + '', 'CorpdepId': '' + CorpdepId + '', 'staffWrk': '' + staffWrk + '', 'ddate': '' + ddate + '', 'month': '' + month + '', 'Year': '' + Year + '', 'cbxAllowance': '' + cbxAllowance + '', 'cbxDeduction': '' + cbxDeduction + '' },
                responseType: "json",
                success: OnComplete,
                error: OnFail
            });

            return false;
        }

        function OnComplete(result) {

            document.getElementById("<%=divSalaryStatement.ClientID%>").innerHTML = result;           

            $nooC('#datatable_fixed_column').DataTable({
                "paging":   false,
                "ordering": false,
                "info": false,
                "searching": false,
                dom: 'Bfrtip',
                buttons: [
                    'csv'
                ]
            });
        }
        function OnFail(result) {
            alert('Request failed');
        }
       
      
        </script>

        <style>
        
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
            .dt-buttons {
                    padding-left: 95%;
    margin-top: 5px;
    margin-bottom: 3px;
            }
            .dt-button buttons-csv buttons-html5 {

            }
            #datatable_fixed_column_wrapper {
                margin-left:12px;
            }
   </style>

</asp:Content>

