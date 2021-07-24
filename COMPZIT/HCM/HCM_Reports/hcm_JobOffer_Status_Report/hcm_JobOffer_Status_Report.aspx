<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_JobOffer_Status_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_JobOffer_Status_Report_hcm_JobOffer_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

<style>
        .cont_rght {
            width: 100%;
        }

         .ui-autocomplete {
             padding: 0;
             list-style: none;
             background-color: #fff;
             width: 218px;
             border: 1px solid #B0BECA;
             max-height: 135px;
             overflow-x: auto;
             font-family: Calibri;
         }
         #ReportTable_filter input {
            height: 20px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }

             .ui-autocomplete .ui-menu-item {
                 border-top: 1px solid #B0BECA;
                 display: block;
                 padding: 4px 6px;
                 color: #353D44;
                 cursor: pointer;
                 font-family: Calibri;
             }

                 .ui-autocomplete .ui-menu-item:first-child {
                     border-top: none;
                     font-family: Calibri;
                 }

                 .ui-autocomplete .ui-menu-item.ui-state-focus {
                     background-color: #D5E5F4;
                     color: #161A1C;
                     font-family: Calibri;
                 }
</style>
    
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {
         document.getElementById("freezelayer").style.display = "none";

         document.getElementById("<%=ddlManPower.ClientID%>").focus();
         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";

     });

     </script>

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
              //  "pageLength": 25,
                "bLengthChange": false,
                "bPaginate": false
            });
        });

     </script>

    <script>
        function isTag(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 || charCode == 13) {
                ret = false;
            }
            return ret;
        }

        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });
        function printsorted() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            //    $('#cphMain_divPrintReportSorted table tr').find('td:eq(4),th:eq(4)').remove();
        }
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

         }
        </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenCandidateId" runat="server" />

      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:1%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 39%;margin-top: 29%;"><span style="margin-top: 3px; float: right;margin-right: 20%;margin-top: 33%;">CSV</span> </a>
        <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 4%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -26px; float: right;"> Print</span></a>                                  
</div>
    <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 4%; font-family: Calibri;display:none" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -26px; float: right;">Print</span></a>                                  
</div>

    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

<div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Job Offer Status.png" style="vertical-align: middle;" />
     Job Offer Status Report
        </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;height:88px;">

      

       <div style="margin-top:2.5%;margin-left:2%;width:31%;float:left;">
         <h2>Man Power Request : </h2>
           <asp:DropDownList ID="ddlManPower" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 50%; float: left; margin-left: 2%;" >
           </asp:DropDownList>
        </div>

         <div style="margin-top:2.5%;margin-left:1%;width:25%;float:left;">
         <h2>Assigned To : </h2>
        <asp:DropDownList ID="ddlEmployee" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 50%; float: left; margin-left: 2%;">
           </asp:DropDownList>
        </div>


        <div style="margin-top:2.5%;margin-left:1%;width:28%;float:left;">
         <h2>Project : </h2>
        <asp:DropDownList ID="ddlProject" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 50%; float: left; margin-left: 2%;">
           </asp:DropDownList>
        </div>

       

    <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:2%;margin-top:2.5%;"  runat="server" class="searchlist_btn_lft" Text="Search"  OnClick="btnSearch_Click"  />
          
   </div>

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

    <div id="divPrintCaption" runat="server" style="display: none; height: 150px">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


    <div id="divPrintReport" runat="server" style="display: none">
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>


    
      <div id="divTitle" runat="server" style="display: none">
        Job Offer Status Report
      </div>
      </div>
    
               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>


  

        <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>



    <div id="divPrintCaptionDetails" class="table-responsive" runat="server">
            </div>

   <label id="lblPrintOnBrdDtls" runat="server" style="float: left; cursor: inherit"></label>

    <div id="divPrintReportDetails" class="table-responsive" runat="server">
         <br />
       </div>




</asp:Content>

