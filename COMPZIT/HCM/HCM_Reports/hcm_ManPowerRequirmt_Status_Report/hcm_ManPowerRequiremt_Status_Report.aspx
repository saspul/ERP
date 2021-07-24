<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_ManPowerRequiremt_Status_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_ManPowerRequirmt_Status_Report_hcm_ManPowerRequiremt_Status_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

<style>
        .cont_rght {
            width: 100%;
        }

    /*--------------------------------------------------for modal ManPower Requirement info------------------------------------------------------*/
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
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";
         document.getElementById("<%=ddlDepartmnt.ClientID%>").focus();
         document.getElementById("<%=ddlDesignation.ClientID%>").focus();
         document.getElementById("<%=ddlDivision.ClientID%>").focus();
         document.getElementById("<%=ddlProject.ClientID%>").focus();


         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintOnBrdDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";
 

     });
     


     function OpenManPowerRequiremtDetails(ManPwrId,sts) {

         document.getElementById("MymodalBundleInfo").style.display = "block";
         document.getElementById("freezelayer").style.display = "";

         document.getElementById("<%=hiddenManpwrId.ClientID%>").value = ManPwrId;

         var Details = PageMethods.ManPowerRequiremtDetails(ManPwrId,sts, function (response) {

             if (response[0] != "" && response[0] != null) {
                 document.getElementById("<%=lblRef.ClientID%>").innerHTML = response[0];
             }

             if (response[1] != "" && response[1] != null) {
                 document.getElementById("<%=lblResrc.ClientID%>").innerHTML = response[1];
             }

             if (response[2] != "" && response[2] != null) {
                 document.getElementById("<%=lblDivsn.ClientID%>").innerHTML = response[2];
             }

             if (response[3] != "" && response[3] != null) {
                 document.getElementById("<%=lblDsgntn.ClientID%>").innerHTML = response[3];
             }

             if (response[4] != "" && response[4] != null) {
                 document.getElementById("<%=divOnBoardingDtls.ClientID%>").innerHTML = response[4];
             }

           
        


         });

     }


     //function SearchValidation() {

     //    return true;
     //}
     function DetailsPrint() {

         //printing detail table

         var ManpwrId = document.getElementById("<%=hiddenManpwrId.ClientID%>").value;
         var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
         var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;

         var Details = PageMethods.ManpwrDetailsPrint(ManpwrId, CorpId, OrgId, function (response) {

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

     function CloseManPowerRequiremtDetails() {
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
              //  "pageLength": 25,
                "bDestroy": true,
                "bLengthChange": false,
                "bPaginate": false
            });


           

        });

     </script>

    

    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>

        
    var $au = jQuery.noConflict();
           (function ($au) {
               $au(function () {
                   var prm = Sys.WebForms.PageRequestManager.getInstance();
                   //  prm.add_initializeRequest(InitializeRequest);
                   prm.add_endRequest(EndRequest);
                   $au('#cphMain_ddlDepartmnt').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlDesignation').selectToAutocomplete1Letter();
                   $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
                   $au('form').submit(function () {
                   });
               });
           })(jQuery);


           function EndRequest(sender, args) {
               // after update occur on UpdatePanel re-init the Autocomplete
               $au('#cphMain_ddlDepartmnt').selectToAutocomplete1Letter();

               $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
               $p('#ReportTable').DataTable({
                   "pagingType": "full_numbers",
                   "bSort": true,
                  // "pageLength": 25,
                   "bDestroy": true,
                   "bLengthChange": false,
                   "bPaginate": false
               });

          }

           function SearchValidation() {

               var ret = true;
               //selected();
               document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
                      //  document.getElementById("<%=ddlDepartmnt.ClientID%>").style.borderColor = "";
                      document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "";
                      //  document.getElementById('divMessageArea').style.display = "";
                      var fromdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                      var toDate = document.getElementById("<%=txtTodate.ClientID%>").value;

                      //  var varddlDep = document.getElementById("<%=ddlDepartmnt.ClientID%>").value;


                      if (fromdate == "" && toDate == "") {
                          document.getElementById('divMessageArea').style.display = "";
                          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select a date range";
                             document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                             document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                             document.getElementById("<%=txtFromDate.ClientID%>").focus();

                             ret = false;
                         }
                         else if (fromdate == "") {
                             document.getElementById('divMessageArea').style.display = "";
                             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please select a date range";
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();

                ret = false;

            }
            else if (toDate == "") {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please a date range";
                document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtTodate.ClientID%>").focus();
                ret = false;
            }

    if (fromdate != "" && toDate != "") {

        var arrDateFromchk = fromdate.split("-");
        dateDateFromchk = new Date(arrDateFromchk[2], arrDateFromchk[1] - 1, arrDateFromchk[0]);

        var arrDateTochk = toDate.split("-");
        dateDateTochk = new Date(arrDateTochk[2], arrDateTochk[1] - 1, arrDateTochk[0]);
        if (dateDateFromchk > dateDateTochk) {

            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From date should be less than to date";
                         document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                         document.getElementById("<%=txtTodate.ClientID%>").style.borderColor = "Red";
                         document.getElementById("<%=txtFromDate.ClientID%>").focus();

                         ret = false;
                     }
                 }
                 return ret;


             }

         
           //function DropDepart() {
               
           //    $au('#cphMain_ddlDepartmnt').selectToAutocomplete1Letter();
                      
           //    $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
             
                      
                      

           //}
        function printsorted() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
         //   $('#cphMain_divPrintReportSorted table tr').find('td:eq(3),th:eq(3)').remove();
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
    <asp:HiddenField ID="hiddenManpwrId" runat="server" />
      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:1.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A3"  data-title="Item Listing"  style="float: right; margin-top:3%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left:45%;margin-top: 5%;" ><span style="margin-top: 6%;float: right;margin-right: 11%;">CSV</span> </a> 
        <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 3.5%; font-family: Calibri;" class="print"  onclick="printsorted()">
     <a id="A2" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -22px; float: right;margin-right: -3%;"> Print</span></a>                                  
</div>

    <div style="display:none;cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/hcm_ManPowerRequirmt_Status_Report/Print/26_Print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>                                  
</div>


    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght" style="min-height: 256px;">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="\Images\BigIcons\ManPowerRequirementStatusReport.png" style="vertical-align: middle;" />
     Manpower Requirement Status Report
        </div >


      
    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;margin-top:3%;height:180px;">
          
         <div class="row">
 <br />
       <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
   <ContentTemplate>
     <div class="col-md-4" style="width: 33.3%;">
        <%--<div style="margin-top:2.5%;margin-left:5%">--%>
         <h2 >Department   </h2>
         
        <asp:DropDownList ID="ddlDepartmnt" class="form1" runat="server" Style="height: 28px;  width: 52%; float: right;" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmnt_SelectedIndexChanged">
           </asp:DropDownList>
        <%--</div>--%>
 </div>

       <div class="col-sm-4">
           <%--<div  style="margin-top: 2.5%; margin-left: 8%">--%>
           <h2>Division </h2>

           <asp:DropDownList ID="ddlDivision" class="form1" runat="server" Style="height: 28px;  width: 52%; float: right;">
           </asp:DropDownList>
           <%--</div>--%>
       </div>
       </ContentTemplate>
        </asp:UpdatePanel>

  <div class="col-sm-4">
      <%--<div  style="margin-top:2.5%;margin-left:10%">--%>
       
         <h2>Designation </h2>
    
        <asp:DropDownList ID="ddlDesignation" class="form1" runat="server" Style="height: 28px; width: 52%; float: left;margin-left: 8%;">
           </asp:DropDownList>
        <%--</div>--%>

         </div>
            
            
  </div>

<%--        <asp:UpdatePanel EnableViewState="true" UpdateMode="Conditional" runat="server">
   <ContentTemplate>
    
        <div style="margin-top:2.5%;margin-left:5%">
         <h2 >Department  * </h2>
        <asp:DropDownList ID="ddlDepartmnt" class="form1" runat="server" Style="height: 28px; width: 20%; float: left; margin-left: 2%;" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmnt_SelectedIndexChanged">
           </asp:DropDownList>
        </div>--%>
            <%--//Evm -27--%>

        <%--<div  style="margin-top: 2.5%; margin-left: 8%">
            <h2 style="margin-left: 2%;">Division </h2>
            <asp:DropDownList ID="ddlDivision" class="form1" runat="server" Style="height: 28px; width: 20%; float: left; margin-left: 2%;">
            </asp:DropDownList>
        </div>
       </ContentTemplate>
        </asp:UpdatePanel>--%>
        <br />
         <div class="row">
  <div class="col-sm-4"  >

   
         <h2>Project  </h2>
        <asp:DropDownList ID="ddlProject" class="form1" runat="server" Style="height: 28px; margin-top:0.5%; width: 52%; float: right; margin-left: 2%;">
           </asp:DropDownList>  

  </div>
  
             <div class="col-sm-4">
                 <%--<div class="eachform" style="float: left; width: 19%; margin-top: 1.5%; margin-left: -22.3%;">--%>
                 <h2> From Date *</h2>

                 <div id="div1" class="input-append date" style="float: right; margin-right: 8%; width: 48%;">



                     <asp:TextBox ID="txtFromDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height: 30px; width: 88.6%; margin-top: 0%; float: left; margin-left: -2.3%;"></asp:TextBox>

                     <input type="image" runat="server" id="Image1" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style="height: 22px; width: 22px; margin-top: -0.2%;" />
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
                         $noC('#div1').datetimepicker({
                             format: 'dd-MM-yyyy',
                             language: 'en',
                             pickTime: false,
                             //endDate: new Date(),
                         });

                     </script>
                     <p style="visibility: hidden">Please enter</p>
                 </div>
                 </div>
            
    <div class="col-sm-4" >
  <%--<div class="eachform" style="float:left;width:25%;margin-top:1.5%;margin-left:2%;">--%>
                <h2 >To Date *</h2>
                
               <div id="div2" class="input-append date" style="float:right;margin-right:17%;width: 48%;">

                        <asp:TextBox ID="txtTodate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:88.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image2" class="add-on" src="../../../../Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;margin-top:-0.2%;" />
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
                            $noC('#div2').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                // startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              <%--</div>--%>

 </div>
    <%--</div>--%>
</div> 
<br />
 <div class="row">
     <div class="col-sm-8">

        
       <h2 >Status </h2>
        <asp:DropDownList ID="DdlStatus" class="form1" runat="server" Style="height: 28px; width: 27%; float: left; margin-left: 13.5%;">
           
           </asp:DropDownList>
      </div>

      
  
  <div class="col-sm-4">
        <asp:Button ID="btnSearch" Style="cursor: pointer; float: right; margin-right: 10%; margin-top: 1%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation()" OnClick="btnSearch_Click" />

  </div>
 
</div> 
        </div>
           </div>
         <%--<div style="margin-top:2.5%; margin-left: -4%;">--%>
       
          
        
       
        <%-- <div style="margin-top:2.5%;margin-left: 1%">--%>
       
        
             <%-- </div>--%>
             
             
        
       
      
              
            


        
             
          
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

        <div id="divPrintReportSorted" runat="server" style="display: none">
                                    <br />
                                </div>
    <div id="divTitle" runat="server" style="display: none">
    Manpower Requirements Status Report
      </div>



 <%--------------------------------View for ManPower Requirement informatn--------------------------%>

    <div id="MymodalBundleInfo" class="modalInfoView" >

         <div class="modal-InfoView" style="width:100%">
 

            <div class="modal-headerInfoView">
                  <img class="closeInfoView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseManPowerRequiremtDetails();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                  <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Manpower Requirement Details</h3>
             </div>
            

            <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 1%; font-family: Calibri;" class="print">
            <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/24_Print.htm" style="color: rgb(83, 101, 51)" onclick="DetailsPrint()">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>    </div>   

           <div class="modal-bodyInfoView">

               <div style="border:.5px solid #929292; background-color: #c9c9c9;width: 100%;margin-top:1%;height:90px;">


               <div id="divRef" style="width: 40%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 1%; width: 16%; float: left;color: #603504;">Ref#</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblRef" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 30%; cursor: inherit"></label>
                 </div>

               <div id="divResrc" style="width: 40%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 1%; width: 34%; float: left;color: #603504;">No of Resources</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblResrc" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 59%; cursor: inherit;"></label>
                </div>

                <div id="divDivsn" style="width: 45%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 1%; width: 16%; float: left;color: #603504;">Division</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblDivsn" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 64%; cursor: inherit"></label>
              <%--  </div>
                    <div id="div1" style="width: 20%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 1%; width: 16%; float: left;color: #603504;">Division</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="Label1" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 64%; cursor: inherit"></label>
                </div>--%>

               <div id="divDsgntn" style="width: 45%; float: left; margin-top: 1%;word-wrap:break-word;">
                   <h2 style="margin-left: 1%; width: 34%; float: left;color: #603504;">Designation</h2>
                   <div><h2 style="color: #603504;width: 4%;">:</h2></div>
                   <label id="lblDsgntn" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 60%; cursor: inherit;"></label>
                   <br />
                   <br />
                   <br />

               </div>
                  
              </div>

               <h2><u>Selected Candidates</u></h2><br /><br /><br />

            <div id="divOnBoardingDtls" class="table-responsive" runat="server" style="overflow:auto;max-height:220px;" >
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


    #ReportTableDtl_length {
    margin-bottom: 1%;
    font-family: Calibri;
    font-weight: bold;
    font-size: 14px;
    padding-bottom: 0.7%;
}

    #ReportTableDtl_filter {
    font-family: Calibri;
    font-weight: bold;
    font-size: 14px;
}

    #ReportTableDtl_info {
    font-family: Calibri;
    font-weight: 600;
    font-size: 14px;
}

    #ReportTableDtl_paginate {
    font-family: Calibri;
    font-size: 13px;
}
                #ReportTable_filter input {
            height: 20px;
            width: 208px;
            color: #336B16;
            font-size: 14px;
            margin-bottom: 5%;
        }

      .open > .dropdown-menu {
            display: none;
        }
    </style>

    </div>
</asp:Content>

