<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_JobCostSummary_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_JobCostSummary_Report_hcm_JobCostSummary_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

      <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                //"pageLength": 25
                "bLengthChange": false,
                "bPaginate": true
            });
        });

        function printsorted() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
           // $('#cphMain_divPrintReportSorted table tr').find('td:eq(3),th:eq(3)').remove();
        }
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

            }
    </script>
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:5.5%;color:rgb(83, 101, 51);font-family:Calibri;width:10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left:35%;margin-top: 5%;"><span style="margin-top: 7%;float: right;margin-right: 21%;">CSV</span> </a>
       <div style="cursor: default; float: right; height: 25px; margin-right:-2.5%;margin-top:6%;font-family:Calibri;" class="print" onclick="printsorted()">            
          <a id="A1" target="_blank" data-title="Item Listing"  href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color:rgb(83, 101, 51)" >
           <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
            <span style="margin-top: 2%;float: right;margin-right: 0%;">Print</span></a>                                    
     </div>
    <div style="display:none;cursor: default; float: right; height: 25px; margin-right:3.5%;margin-top:6%;font-family:Calibri;" class="print" onclick="printredirect()">            
          <a id="print_cap" target="_blank" data-title="Item Listing"  href="../../../Reports/Print/48_Print.htm" style="color:rgb(83, 101, 51)" >
           <img src="../../../Images/Other%20Images/imgPrint.png" style="max-width: 45%">
            Print</a>                                    
     </div>

    <div id="divSuccessUpd" style="visibility: hidden">
        <asp:Label ID="lblSuccessUpd" runat="server"></asp:Label>
    </div>


    <div class="cont_rght">
        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/job-cost-report-48.png" style="vertical-align: middle;" />
            Job Cost Summary Report
        </div>




             <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;height:60px; margin-bottom:1%;">
               <div style="margin-top:1%;margin-left:5%;width:24%;float:left;">
                  <h2>Division</h2>
                  <asp:DropDownList ID="ddlDivision" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 30px; width: 52%; float: left; margin-left: 4%;">
                 </asp:DropDownList>
               </div>
                  <div style="margin-top:1%;margin-left:1%;width:24%;float:left;">
                  <asp:DropDownList runat="server" ID="ddlYear" style="float: left;width: 60%;" class="form1" onkeypress="return IsEnter(event);" onchange="IncrmntConfrmCounter()" >
               </asp:DropDownList>
                  </div>

                <div style="margin-top:1%;margin-left:1%;width:24%;float:left;">
                <asp:DropDownList runat="server" ID="ddlMonth" onchange="IncrmntConfrmCounter()" class="form1" style="float: left;width: 60%;" onkeypress="return IsEnter(event);" >
                </asp:DropDownList>
                </div>

                <div style="margin-top:1%;margin-left:1%;width:10%;float:left;">
              <asp:Button ID="btnSearch" style="cursor:pointer;float:left;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return validateSearch();" OnClick="btnSearch_Click" />
                   </div>
                </div>

             <br />
            <br />
       
        <div id="divReport" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
            <div id="divTitle" runat="server" style="display: none">
   Job Cost Summary Report
      </div>
               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
                <style>#ReportTable_filter input {
    height: 20px;
    width: 200px;
    color: #336B16;
    font-size: 14px;
}
 .cont_rght {
    width: 100%;
}
                </style>
         <div id="divPrintReport" runat="server" style="display: none">
                                    <br />
                                </div>
        <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
    </div>
   </div>



        <style>
        #cphMain_divReport {
            float: left;
            width: 98.5%;
        }

        #cphMain_divAdd {
            position: fixed;
            /*right: 4%;*/
            padding-left: 83.5%;
        }

        #TableRprtRow .tdT {
            line-height: 100%;
        }

        
                #ReportTable_filter input {
            height: 22px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }
        
    </style>

    <script>
        var $NoConfi = jQuery.noConflict();
        function validateSearch() {
            var ret = true;
            document.getElementById("cphMain_ddlYear").style.borderColor = "";
            document.getElementById("cphMain_ddlMonth").style.borderColor = "";
            if (document.getElementById("cphMain_ddlYear").value != '--SELECT YEAR--' || document.getElementById("cphMain_ddlMonth").value != '--SELECT MONTH--') {
                if (document.getElementById("cphMain_ddlYear").value == '--SELECT YEAR--') {
                    document.getElementById("cphMain_ddlYear").style.borderColor = "red";
                    document.getElementById("cphMain_ddlYear").focus();
                    ret = false;
                }
                if (document.getElementById("cphMain_ddlMonth").value == '--SELECT MONTH--') {
                    document.getElementById("cphMain_ddlMonth").style.borderColor = "red";
                    document.getElementById("cphMain_ddlMonth").focus();
                    ret = false;
                }
            }       
            return ret;
        }

    </script>

</asp:Content>

