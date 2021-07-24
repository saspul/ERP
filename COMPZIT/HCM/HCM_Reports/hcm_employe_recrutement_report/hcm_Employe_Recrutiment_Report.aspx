<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Employe_Recrutiment_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_VisaBundle_Report_hcm_employe_recrutement_report_hcm_Employe_Recrutiment_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">


    <style>
        .cont_rght {
            width: 98%;
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
             padding: 0% 4% 7% 4%;
         }

         .modal-footerInfoView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
</style>


    <style type="text/css">
        .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            /*width: 52.6%;*/
            border: 1px solid #B0BECA;
            max-height: 135px;
            overflow-x: auto;
            font-family: Calibri;
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
   
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlYear').selectToAutocomplete1Letter();
               



                $au('form').submit(function () {


                });
            });
        })(jQuery);





                    </script>


    <script src="/JavaScript/jquery-1.8.3.min.js"></script>

 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";

         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
          document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";
      });




     function OpenVisaDetails(Year, month) {

          document.getElementById("<%=lblYear.ClientID%>").innerHTML = Year;
         document.getElementById("<%=lblMonth.ClientID%>").innerHTML = month;
       
          document.getElementById("MymodalBundleInfo").style.display = "block";
          document.getElementById("freezelayer").style.display = "";

          var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
          var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
         var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;

       
         var Details = PageMethods.EmployeeRecuirmentDetails(Year, month, CorpId, OrgId, UserId, function (response) {


              if (response[1] != "" && response[1] != null) {
                  document.getElementById("<%=divEmpRecDtls.ClientID%>").innerHTML = response[1];

              }
             if (response[2] != "" && response[2] != null) {
                 document.getElementById("<%=divPrintCaptionDetails.ClientID%>").innerHTML = response[2];

              }

             if (response[3] != "" && response[3] != null) {
                 document.getElementById("<%=divPrintReportDetails.ClientID%>").innerHTML = response[3];

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

     function CallCSVBtn() {
         document.getElementById("<%=BtnCSV.ClientID%>").click();

       }




     </script>


    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": false,
               // "pageLength": 25,
                "bLengthChange": false,
                "bPaginate": false
            });
        });


        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
<asp:HiddenField ID="hiddenOrgId" runat="server" />
<asp:HiddenField ID="hiddenUserId" runat="server" />

         <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4.5%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left:45%;margin-top: 5%;" ><span style="margin-top: 7%;float: right;margin-right: 13%;">CSV</span></a> 
<div style="cursor: default; float: right; height: 25px; margin-right: -3.5%; margin-top: 3.5%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Employee Recruitment" href="/HCM/HCM_Reports/Print/Common_print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%;margin-bottom:-46%;margin-left:-18%;">
        <span style="margin-top: 2px; margin-left:35%;">Print</span></a>                                  
</div>

    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
    <div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/Employee Recruitment report.png" style="vertical-align: middle;"  /> 
          Employee Recruitment Report
        </div >



         <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:3%;height:92px; margin-bottom:1%;">

         <div class="eachform" style="float:left;width:25%;margin-top:3%;margin-left:3%;">
                <h2 style="margin-left: 11%;">Year</h2>
                
               <div id="divYear" class="input-append date" style="float:right;margin-right:8%;width: 55%;margin-top:-2%">
                        
                 <asp:DropDownList ID="ddlYear" Height="30px" Width="100%" class="form1" runat="server" Style="margin-left: 1.8%;text-align:center;margin-right:0%;float:left"></asp:DropDownList>
                   </div>
             </div>
              <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 2.5%;float:right;margin-right:10%"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
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
     Employee Recruitment Report
      </div>
         
        </div>


    <div id="MymodalBundleInfo" class="modalInfoView" >

         <div class="modal-InfoView" style="width:100%">
 

            <div class="modal-headerInfoView">
                  <img class="closeInfoView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseVisaDetails();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                  <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Employee Recruitment More Info </h3>
             </div>
           
 
            <a id="A1" target="_blank" data-title="Employee Recruitment" href="/HCM/HCM_Reports/Print/46_print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-left:91%; margin-bottom:-2.5%;">
        <span style="margin-top: 2px; margin-left:94%;">Print</span></a>     

             <div class="modal-bodyInfoView" style="overflow:auto;height:300px;">

            
            <div id="divIssue" style="width: 100%; float: right; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 23%; float: left;">Year : </h2>
                   <label id="lblYear" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 10%; cursor: inherit"></label>
            </div>

            <div id="divExpiry" style="width: 100%; float: right; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 23%; float: left;">Month : </h2>
                   <label id="lblMonth" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 10%; cursor: inherit"></label>
            <br /><br /><br />  
            </div>


            <div id="divEmpRecDtls" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </div>

            </div>


            <div class="modal-footerInfoView" style="margin-top: 21px;">
                   </div>

    </div>


        </div>

     <div id="divPrintCaptionDetails" class="table-responsive" runat="server">
            </div>

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
         height: 22px;
         width: 200px;
         color: #336B16;
         font-size: 14px;
     }
                #ReportTable_filter input {
            height: 22px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }
    </style>
</asp:Content>

