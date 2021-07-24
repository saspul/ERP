<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_OnBoarding_Status_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_OnBoarding_Status_Report_hcm_OnBoarding_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

<style>
        .cont_rght {
            width: 98%;
        }

    /*--------------------------------------------------for modal OnBoarding Status info------------------------------------------------------*/
         .modalInfoView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 10%;
             top: 10%;
             width: 80%; /* Full width */
             height: 250px; /* Full height */
             /*overflow: auto;*/ /* Enable scroll if needed */
             background-color: transparent;
         }

         .modal-InfoView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeInfoView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeInfoView:hover,
             .closeInfoView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerInfoView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyInfoView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerInfoView {
             padding: 1% 1%;
           background-color: #91a172;
             color: white;
         }

</style>

 <script src="/JavaScript/jquery-1.8.3.min.js"></script>

 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";

         document.getElementById("<%=ddlManPower.ClientID%>").focus();

         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";
 
     });
     function printsorted() {
         document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
         $('#cphMain_divPrintReportSorted table tr').find('td:eq(4),th:eq(4)').remove();
     }

     function OpenOnBoardingDetails(CandidateId) {

         document.getElementById("MymodalBundleInfo").style.display = "block";
         document.getElementById("freezelayer").style.display = "";
         
         document.getElementById("<%=hiddenCandidateId.ClientID%>").value = CandidateId;

         var Details = PageMethods.OnBoardingDetails(CandidateId, function (response) {

             if (response[0] != "" && response[0] != null) {
                 document.getElementById("<%=lblName.ClientID%>").innerHTML = response[0];
             }

             if (response[1] != "" && response[1] != null) {
                 document.getElementById("<%=lblLocatn.ClientID%>").innerHTML = response[1];
             }

             if (response[2] != "" && response[2] != null) {
                 document.getElementById("<%=lblRef.ClientID%>").innerHTML = response[2];
             }

             if (response[3] != "" && response[3] != null) {
                 document.getElementById("<%=lblVisa.ClientID%>").innerHTML = response[3];
             }

             if (response[4] != "" && response[4] != null) {
                 document.getElementById("<%=lblNation.ClientID%>").innerHTML = response[4];
             }

             if (response[5] != "" && response[5] != null) {
                 document.getElementById("<%=divOnBoardingDtls.ClientID%>").innerHTML = response[5];
             }
             

         });

     }


     function DetailsPrint() {
         //print onboarding status details

         var CandidateId = document.getElementById("<%=hiddenCandidateId.ClientID%>").value;
         var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
         var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;

         var Details = PageMethods.OnBoardingDetailsPrint(CandidateId,CorpId,OrgId, function (response) {

             if (response[0] != "" && response[0] != null) {
                 document.getElementById("<%=divPrintCaptionDetails.ClientID%>").innerHTML = response[0];
             }

             if (response[1] != "" && response[1] != null) {
                 document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").innerHTML = response[1];
             }

             if (response[2] != "" && response[2] != null) {
                 document.getElementById("<%=divPrintReportDetails.ClientID%>").innerHTML = response[2];
             }

         });

     }


     function CloseOnBoardingDetails() {
         document.getElementById('divMessageArea').style.display = "none";
         document.getElementById('imgMessageArea').src = "";
         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";
     }

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
                // "pageLength": 25,
                "bLengthChange": false,
                "bPaginate": false
            });
        });

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
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

         }
        </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenCandidateId" runat="server" />
      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:3.5%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left:35%;margin-top: 5%;"><span style="margin-top: 7%;float: right;margin-right: 21%;">CSV</span></a>
    <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 4%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A2" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -26px; float: right;">Print</span></a>                                  
</div>
    <div style="display:none;cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 4%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/22_Print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -26px; float: right;">Print</span></a>                                  
</div>

    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

<div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Onboarding_status_report_48.png" style="vertical-align: middle;" />
     On Boarding Status Report
        </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;height:88px;">

      <div style="margin-top:2.5%;margin-left:5%">
         <h2>Man Power Request* : </h2>
        <asp:DropDownList ID="ddlManPower" class="form1" runat="server" Style="height: 28px; width: 25%; float: left; margin-left: 2%;">
           </asp:DropDownList>
        </div>

    <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right:20%"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation()" OnClick="btnSearch_Click"  />
          
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
   Onboarding Status Report
      </div>
               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
      </div>



     <%--------------------------------View for OnBoarding informatn--------------------------%>

    <div id="MymodalBundleInfo" class="modalInfoView" >

         <div class="modal-InfoView" style="width:100%">
 

            <div class="modal-headerInfoView">
                  <img class="closeInfoView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseOnBoardingDetails();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                  <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">On Boarding Status Details</h3>
             </div>
            

            <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 2%; font-family: Calibri;" class="print">
            <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/20_Print.htm" style="color: rgb(83, 101, 51)" onclick="DetailsPrint()">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -26px; float: right;">Print</span></a>    </div>  

           <div class="modal-bodyInfoView">

               <div style="border:.5px solid #929292; background-color: #c9c9c9;width: 100%;margin-top:3%;height:115px;">


               <div id="divName" style="width: 60%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 20%; float: left;color: #603504;">Name</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblName" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit"></label>
                 </div>

                <div id="divLocatn" style="width: 40%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 20%; float: left;color: #603504;margin-left:15%">Location</h2>
                    <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblLocatn" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 50%; cursor: inherit; margin-left:5%"></label>
                </div>

               <div id="divRef" style="width: 60%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 20%; float: left;color: #603504;">Reference</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblRef" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit"></label>
                 </div>

               <div id="divVisa" style="width: 40%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 20%; float: left;color: #603504;margin-left:15%">Visa</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblVisa" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 50%; cursor: inherit; margin-left:5%"></label>
                </div>

               <div id="divNation" style="width: 60%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 20%; float: left;color: #603504;">Nationality</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblNation" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit"></label>
                   <br />
                   <br />
                   <br />

               </div>
                  
              </div>

            <div id="divOnBoardingDtls" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            </div>

          </div>

          <div class="modal-footerInfoView" style="margin-top: 21px;">
                   </div>


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

    <style>
        
                #ReportTable_filter input {
            height: 22px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }
    </style>


</asp:Content>

