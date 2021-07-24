<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_VisaBundle_Report.aspx.cs" Inherits="HCM_HCM_Reports_Visa_Bundle_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
 <style>
        .cont_rght {
            width: 100%;
        }

    

</style>


<style>
    /*--------------------------------------------------for modal Bundle info------------------------------------------------------*/
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
             padding: 1% 4% 7% 4%;
         }

         .modal-footerInfoView {
             padding: 2% 1%;
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
          document.getElementById("<%=txtFromDate.ClientID%>").focus();

          document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
          document.getElementById("<%=lblPrintBndlDtls.ClientID%>").style.visibility = "hidden";
          document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";
      });

 
     function printsorted() {
         document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
         $('#cphMain_divPrintReportSorted table tr').find('td:eq(3),th:eq(3)').remove();
     }
  
     function OpenVisaDetails(VisaId) {

          document.getElementById("MymodalBundleInfo").style.display = "block";
          document.getElementById("freezelayer").style.display = "";

          var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
          var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
          var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;


          var Details = PageMethods.VisaBundleDetails(VisaId, CorpId, OrgId, UserId, function (response) {

                if (response[0] != "" && response[0] != null) {
                    document.getElementById("<%=lblBundleNo.ClientID%>").innerHTML = response[0];
                }

                if (response[1] != "" && response[1] != null) {
                    document.getElementById("<%=lblIssueDt.ClientID%>").innerHTML = response[1];

                }
                if (response[2] != "" && response[2] != null) {
                    document.getElementById("<%=lblExpiryDt.ClientID%>").innerHTML = response[2];
                }

                if (response[3] != "" && response[3] != null) {
                    document.getElementById("<%=divBundleDtls.ClientID%>").innerHTML = response[3];
                }

                if (response[4] != "" && response[4] != null) {
                    document.getElementById("<%=divPrintCaptionDetails.ClientID%>").innerHTML = response[4];
                }

                if (response[5] != "" && response[5] != null) {
                    document.getElementById("<%=lblPrintBndlDtls.ClientID%>").innerHTML = response[5];
                }

                if (response[6] != "" && response[6] != null) {
                    document.getElementById("<%=divPrintReportDetails.ClientID%>").innerHTML = response[6];
                }


          });
      }
    
   

     function CloseVisaDetails() {
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


        // for not allowing enter
        function DisableEnter(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
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
<asp:HiddenField ID="hiddenUserId" runat="server" />

        <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:1.5%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left:45%;margin-top: 5%;" ><span style="margin-top: 6%;float: right;margin-right: 13%;">CSV</span> </a> 
     
<div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 2%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A2" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">  Print</span></a>                                  
</div>
<div style="display:none;cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 2%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print</span></a>                                  
</div>

    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

<div class="cont_rght">

    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="\Images/BigIcons/VisaBundle_Report.png" style="vertical-align: middle;" />
     Visa Bundle Report
        </div >

    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;margin-top:1%;height:92px;padding: 1%;">

        <div style="float: left;width: 55%;border: 1px solid #9ba48b;height: 100%;">
        <h2 style="float: left;width: 22%;margin-top: 1%;margin-left: 39%;color: #536533;">Expiry Date : </h2>

         <div class="eachform" style="float: left;width: 50%;">
                <h2 style="margin-top: 2%;margin-left: 9%;">From Date</h2>
                
               <div id="divFrmDate" class="input-append date" style="float: left;width: 40%;margin-left: 6%;margin-top: 1%;">
                        
                 <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:77.6%;margin-top: 0%;float:left;margin-left: -2.3%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image"  id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;" />

                           <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                           <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker.js">
                            </script>
                            <script type="text/javascript"
                                src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                            </script>
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divFrmDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(),
                            });
                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>

            </div>
      

      <div class="eachform" style="float:left;width:50%;"">
                <h2 style="margin-top: 2%;">To Date</h2>
                
                 <div id="divToDate" class="input-append date" style="float:left;margin-left:15%;width: 46%;margin-top:1%">

                  <asp:TextBox ID="txtToDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  Style="height:30px;width:73.6%;margin-top: 0%;float:left;margin-left: 0%;" onkeypress="return DisableEnter(event)"></asp:TextBox>

                        <input type="image" id="Image2" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:0%;"  />
                       
                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                 startDate: new Date(),
                            });

                        </script>

                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>
            </div>
        <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 2.5%;float:right;margin-right:5%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />

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
    Visa Bundle Report
      </div>
               <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
           
     </div>

 <%--------------------------------View for Bundle informatn--------------------------%>

    <div id="MymodalBundleInfo" class="modalInfoView" style="display:none; float:left" >

         <div class="modal-InfoView" style="width:100%; float:left">
 

            <div class="modal-headerInfoView">
                  <img class="closeInfoView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseVisaDetails();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                  <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Visa Bundle Details</h3>
             </div>
            
             <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 2%; font-family: Calibri;" class="print">
            <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/28_Print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;">Print</span></a>    </div>


          <div class="modal-bodyInfoView" style="float: left;width: 93%; float:left; margin-top:0%">

             <div style="border:.5px solid #929292; background-color: #c9c9c9;width: 100%;margin-top:0%;height:115px;float: left;"">
            <div id="divBundleNo" style="width: 100%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 23%; float: left;color: #603504;">Bundle Number</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblBundleNo" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 50%; cursor: inherit"></label>
            </div>

            <div id="divIssue" style="width: 100%; float: right; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 23%; float: left;color: #603504;">Issued Date</h2>
                <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblIssueDt" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 50%; cursor: inherit"></label>
            </div>

            <div id="divExpiry" style="width: 100%; float: right; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 23%; float: left;color: #603504;">Expiry Date</h2>
                <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblExpiryDt" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 50%; cursor: inherit"></label>
            <br /><br /><br />  
            </div>

          </div>

            <div id="divBundleDtls" class="table-responsive" runat="server"  style="height: 180px; float: left;width: 100%; overflow: auto;margin-top: 2%; float:left;">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </div>

            </div>


            <div class="modal-footerInfoView" style="margin-top: 0px;float:left;width:98%">
                
                   </div>

    </div>


        </div>

     <div id="divPrintCaptionDetails" class="table-responsive" runat="server">
            </div>

     <label id="lblPrintBndlDtls" runat="server" style="float: left; cursor: inherit"></label>

     <div id="divPrintReportDetails" class="table-responsive" runat="server">
         <br />
         <br />
         <br />
       </div>


    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>



    <style>
         #ReportTable_filter input {
         height: 17px;
         width: 200px;
         color: #336B16;
         font-size: 14px;
            margin-bottom: 5%;

     }
 
   
    .open > .dropdown-menu {
    display: none;
}
      </style>


</asp:Content>

