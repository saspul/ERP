<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Interview_Evaluation_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Interview_Evaluation_Report_hcm_Interview_Evaluation_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

<style>
        .cont_rght {
            width: 100%;
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
     function CallCSVBtn() {
         document.getElementById("<%=BtnCSV.ClientID%>").click();
     }
     </script>

     <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        //var $p = jQuery.noConflict();
        //$p(document).ready(function () {
        //    $p('#ReportTable').DataTable({
        //        "pagingType": "full_numbers",
        //        "bSort": true,
        //        "pageLength": 25,
        //    });
        //});

     </script>

    <script>
        function SearchValidation() {

            var ddlManPwr = document.getElementById("<%=ddlManPower.ClientID%>").value;
            if (ddlManPwr == '--SELECT MANPOWER--') {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=ddlManPower.ClientID%>").style.borderColor = "red";
                return false;
            }
            else {
                return true;
            }
        }
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
  
        </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenCandidateId" runat="server" />

                     <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
                                <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 38%;" ><span style="margin-top: 2.7px; float: right;margin-right: 18%;">CSV</span></a> 
    <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 4%; font-family: Calibri;" class="print">
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
            <img src="/Images/BigIcons/Interview Evaluation Report.png" style="vertical-align: middle;" />
     Interview Evaluation Report
        </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;height:88px;">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
   <ContentTemplate> 


      <div style="margin-top:2.5%;margin-left:2%;width:42%;float:left;">
         <h2>MPR Ref#* : </h2>
           <asp:DropDownList ID="ddlManPower" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 50%; float: left; margin-left: 2%;" AutoPostBack="true" OnSelectedIndexChanged="ddlManPower_SelectedIndexChanged">
           </asp:DropDownList>
        </div>
        <div style="margin-top:2.5%;margin-left:1%;width:42%;float:left;">
         <h2>Candidate : </h2>
        <asp:DropDownList ID="ddlCandidate" onkeydown="return isTag(event)" onkeypress="return isTag(event)" class="form1" runat="server" Style="height: 28px; width: 50%; float: left; margin-left: 2%;">
           </asp:DropDownList>
        </div>

         </ContentTemplate>
</asp:UpdatePanel>

    <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:2%;margin-top:2.5%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation()" OnClick="btnSearch_Click"  />
          
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
      Interview Evaluation Report
      </div>
   
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


