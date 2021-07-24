<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Employee_Details_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Employee_Details_Report_hcm_Employee_Details_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
     <style>
        .cont_rght {
            width: 98%;
        }
</style>


<style>
    /*--------------------------------------------------for modal Bundle info------------------------------------------------------*/
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }

         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
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

    <%--<link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />--%>
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlDesgntn').selectToAutocomplete1Letter();
                $au('#cphMain_ddlDeptmnt').selectToAutocomplete1Letter();
                $au('#cphMain_ddlGrade').selectToAutocomplete1Letter();
                $au('#cphMain_ddlNation').selectToAutocomplete1Letter();             
                $au('#cphMain_ddlDivsn').selectToAutocomplete1Letter();
                $au('#cphMain_ddlPrjct').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                  
                });
            });
        })(jQuery);





                    </script>
<script src="/JavaScript/jquery-1.8.3.min.js"></script>
 <script type="text/javascript">
     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {
         //LoadEmployeeDetailsList();
         SearchData();
         document.getElementById("freezelayer").style.display = "none";
         document.getElementById("MymodalBundleInfo").style.display = "none";

         document.getElementById("<%=divPrintCaptionDetails.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=lblPrintBndlDtls.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintReportDetails.ClientID%>").style.visibility = "hidden";
     });


     function HideShowFiltr() {
         if (document.getElementById('divFilter').style.display == "block") {
             document.getElementById('divFilter').style.display = "none";

         } else if (document.getElementById('divFilter').style.display == "none") {
             document.getElementById('divFilter').style.display = "block";

         }


     }
     function OpenCancelView(id) {
         document.getElementById("MymodalBundleInfo").style.display = "block";
         document.getElementById("freezelayer").style.display = "";
         var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
         var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
         var UserId = id;


         var Details = PageMethods.EmployeeDetails(CorpId, OrgId, UserId, function (response) {
             
                  document.getElementById("<%=lblEmp.ClientID%>").innerHTML = response[0];            
                  document.getElementById("<%=lblDesg.ClientID%>").innerHTML = response[1];  
                  document.getElementById("<%=lblDeprtmnt.ClientID%>").innerHTML = response[2];   
                  document.getElementById("<%=lblDivsn.ClientID%>").innerHTML = response[3];  
                  document.getElementById("<%=lblGrade.ClientID%>").innerHTML = response[4];   
                  document.getElementById("<%=lblPrjct.ClientID%>").innerHTML = response[5];
                  document.getElementById("<%=lblNation.ClientID%>").innerHTML = response[6];
                  document.getElementById("<%=lblRelgn.ClientID%>").innerHTML = response[7];
                  document.getElementById("<%=lblGender.ClientID%>").innerHTML = response[8];
                  document.getElementById("<%=lblAge.ClientID%>").innerHTML = response[9];
                  document.getElementById("<%=lblWrkSts.ClientID%>").innerHTML = response[10];
                  document.getElementById("<%=lblNumYears.ClientID%>").innerHTML = response[11];
             
                 //For Print
                 document.getElementById("<%=divPrintCaptionDetails.ClientID%>").innerHTML = response[12];
                 document.getElementById("<%=lblPrintBndlDtls.ClientID%>").innerHTML = response[13];

            
                   

          });
     }

     function CloseCancelView() {
         document.getElementById('divMessageArea').style.display = "none";
         document.getElementById('imgMessageArea').src = "";
         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
         document.getElementById("MymodalBundleInfo").style.display = "none";
         document.getElementById("freezelayer").style.display = "none";
         }

     function Autocomplt() {
         $au('#cphMain_ddlDivsn').selectToAutocomplete1Letter();
         $au('#cphMain_ddlPrjct').selectToAutocomplete1Letter();
     }
     function SearchValidation() {

         document.getElementById("<%=txtAgeFrom.ClientID%>").style.borderColor = "";
         document.getElementById("<%=txtAgeTo.ClientID%>").style.borderColor = "";
         var FromAge = document.getElementById("<%=txtAgeFrom.ClientID%>").value;
         var ToAge = document.getElementById("<%=txtAgeTo.ClientID%>").value;
         if (FromAge != "" && ToAge != "") {
             if (FromAge >= ToAge) {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "From age cannot be greater than or equal to To age.";
                 document.getElementById("<%=txtAgeFrom.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtAgeTo.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtAgeFrom.ClientID%>").focus();
                 return false;
             }
         }
         HideShowFiltr();
     }
     // FOR TYPING NUMBER ONLY
     function isNumber(evt) {
         evt = (evt) ? evt : window.event;
         var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         //at enter
         if (keyCodes == 13 || keyCodes == 16) {
           
             return false;
         }
             //0-9
         else if (keyCodes >= 48 && keyCodes <= 57) {
             return true;
         }
             //numpad 0-9
         else if (keyCodes >= 96 && keyCodes <= 105) {
             return true;
         }
             //left arrow key,right arrow key,home,end ,delete
         else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
             return true;

         }
         else {
             var ret = true;
             if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                 ret = false;
             }
             return ret;
         }
     }

     function DisableEnter(evt) {
         evt = (evt) ? evt : window.event;
         var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
         if (keyCodes == 13) {

             return false;

         }
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         var ret = true;
         if (charCode == 60 || charCode == 62) {
             ret = false;
         }
         return ret;
     }
   
     </script>


      <%--  for giving pagination to the html table--%>
<%--    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>--%>

    <%--<link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />--%>
    <script>
        var $p = jQuery.noConflict();
        //$p(document).ready(function () {
        //    $p('#ReportTable').DataTable({
        //        "bSort": true,
        //        // "pageLength": 25,
        //        "pagingType": "full_numbers",
        //        "bLengthChange": false,
        //        "bPaginate": false
        //    });
        //   });
        function printsorted() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            $('#cphMain_divPrintReportSorted table tr').find('td:eq(6),th:eq(6)').remove();
        }
        function CallCSVBtn() {
            document.getElementById("<%=BtnCSV.ClientID%>").click();

          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenVisaQuotaId" runat="server" />
     <asp:HiddenField ID="hiddenCorpId" runat="server" />
     <asp:HiddenField ID="hiddenOrgId" runat="server" />



    <asp:HiddenField ID="hiddenDesignationId" runat="server" />
    <asp:HiddenField ID="hiddenDepartmentId" runat="server" />

    <asp:HiddenField ID="hiddenDivisionId" runat="server" />
    <asp:HiddenField ID="hiddenProjectId" runat="server" />
    <asp:HiddenField ID="hiddenReligionId" runat="server" />
    <asp:HiddenField ID="hiddenGradeId" runat="server" />
    <asp:HiddenField ID="hiddenStatusId" runat="server" />
    <asp:HiddenField ID="hiddenNationalityId" runat="server" />
    <asp:HiddenField ID="hiddenField7" runat="server" />


    <%--      <div style="cursor: default; float: right; height: 25px; margin-right:3.5%;margin-top:8%;font-family:Calibri;" class="print" onclick="printsorted()">            
                                 <a id="A2" target="_blank" data-title="Item Listing" href="../Print/sort_EmpDtlsRprt.htm"  style="color:rgb(83, 101, 51)" >
                                <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
                                Sorted Print</a>                                    
                                </div>--%>
      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:3%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:3%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
       <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left:45%;margin-top: 5%;" ><span style="margin-top: 7%;float: right;margin-right: 13%;">CSV</span> </a> 
    <div style="cursor: default; float: right; height: 25px; margin-right: -2.5%; margin-top: 3.5%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A3" target="_blank" data-title="Item Listing" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
        <span style="margin-top: 2px; float: right;">Print</span></a>                                  
</div>
<div style="display:none; default; float: right; height: 25px; margin-right: 1.5%; margin-top: 3.5%; font-family: Calibri;" class="print" onclick="printredirect()">
     <a id="print_cap" target="_blank" data-title="Item Listing" href="/HCM/HCM_Reports/Print/19_Print.htm" style="color: rgb(83, 101, 51)">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%">
        <span style="margin-top: 2px; float: right;">Print</span></a>                                  
</div>
   
    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

<div class="cont_rght">
    
    <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;margin-left:-0.5%;">
            <img src="/Images/BigIcons/Employee datail report.png" style="vertical-align: middle;" />
     Employee Details Report
        </div >


    <div style="width: 100%; float: left; font-size: 18px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;  cursor:pointer;text-decoration: underline;margin-bottom:1%;" onclick="HideShowFiltr();">Filter Options+</div>
    <div id="divFilter" style="border:.5px solid #9ba48b; background-color: #f3f3f3;width: 100%;margin-top:4%;height:270px;display:none;width:96%;padding:2%;">

        
         <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Designation </h2>
                <asp:DropDownList ID="ddlDesgntn" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div>  

        <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Department </h2>
                <asp:DropDownList ID="ddlDeptmnt" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div> 
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                   <ContentTemplate> 
         <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Division </h2>
                <asp:DropDownList ID="ddlDivsn" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" runat="server" onkeydown="return DisableEnter(event)" AutoPostBack="true"  OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                </asp:DropDownList>
         </div>  

        <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
            <h2 style="margin-left: 0%">Project </h2>
                <asp:DropDownList ID="ddlPrjct" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList> 
            
          
         </div> 

                       
                       </ContentTemplate>

            </asp:UpdatePanel>
         <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
               <h2 style="margin-left: 0%">Pay Grade </h2>
                <asp:DropDownList ID="ddlGrade" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div>  

        <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Status* </h2>
                <asp:DropDownList ID="ddlStatus" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                <asp:ListItem Text="WORKING" Value="0"></asp:ListItem>
                <asp:ListItem Text="ON LEAVE" Value="1"></asp:ListItem>
                <asp:ListItem Text="RESIGNED" Value="2"></asp:ListItem>
                <asp:ListItem Text="IN ACTIVE" Value="3"></asp:ListItem>
                </asp:DropDownList>
         </div> 
         <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-right: 7%;">
             <h2 style="margin-left: 0%">Nationality </h2>
                <asp:DropDownList ID="ddlNation" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div>  

        <div class="eachform" style="width: 47%; float: right; margin-top: -3.8%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Religion </h2>
                <asp:DropDownList ID="ddlRelgn" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                </asp:DropDownList>
         </div> 
     

         <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Gender </h2>
                <asp:DropDownList ID="ddlGender" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                 <asp:ListItem Text="--SELECT--" Value="3"></asp:ListItem>
                 <asp:ListItem Text="MALE" Value="0"></asp:ListItem>
                 <asp:ListItem Text="FEMALE" Value="1"></asp:ListItem>
                 <asp:ListItem Text="OTHER" Value="2"></asp:ListItem>
                </asp:DropDownList>
         </div>  

        <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%">Age </h2>
          
                <div id="AgeFrom" style="width: 26%;margin-left: 35%;">
                    <label style="color:#909c7b;font-family: calibri;">From</label>
              
                <asp:TextBox ID="txtAgeFrom"  class="form1" runat="server"  MaxLength="2" Style="width: 23%; text-transform: uppercase; height: 30px;float:none;margin-left:4%;font-family:Calibri;" onkeypress="return isNumber(event);" onkeydown="return isNumber(event);"></asp:TextBox>
               </div>
           <div id="AgeTo" style="width: 25%;margin-right: 19%;float:right;margin-top:-6%;">
                     <label style="color:#909c7b;font-family: calibri;">To</label>
                <asp:TextBox ID="txtAgeTo"  class="form1" runat="server"  MaxLength="2" Style="width: 23%; text-transform: uppercase;  height: 30px;float:none;margin-left:4%;font-family:Calibri;" onkeypress="return isNumber(event);" onkeydown="return isNumber(event);"></asp:TextBox>
        </div>
                 </div> 


         <div class="eachform" style="width: 47%; float: left; margin-top: 0%;margin-left: 0%;">
             <h2 style="margin-left: 0%;width:25%;">Number of Years at Al-Balagh</h2>
                <asp:DropDownList ID="ddlNumYear" class="form1"   style="width: 52.6%; text-transform: uppercase; margin-right: 8.8%; height: 30px" onkeydown="return DisableEnter(event)" runat="server">
                     <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="1+YEARS" Value="1"></asp:ListItem>
                     <asp:ListItem Text="3+YEARS" Value="2"></asp:ListItem>
                     <asp:ListItem Text="5+YEARS" Value="3"></asp:ListItem>
                     <asp:ListItem Text="8+YEARS" Value="4"></asp:ListItem>
                     </asp:DropDownList>
         </div>  

         <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
              <%--<asp:Button ID="btnSearch" style="cursor:pointer;margin-top: 0%;float:left;margin-left: 55%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />--%>            
             <asp:Button ID="btnclear" style="cursor:pointer;margin-top: 0%;float:right;text-transform: capitalize;margin-right: 1%;width: 97px;height: 27px;"  runat="server" class="cancel"  Text="Clear"  OnClick="btnclear_Click" />
             <a id="btnSearchData" style="cursor:pointer;float:right;margin-right: 3%;margin-top: 1px;" onclick="SearchData();" class="searchlist_btn_lft"> Search</a>

         </div> 
        
       <%--  <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
          <asp:Button ID="btnclear" style="cursor:pointer;margin-top: 0%;float:left;"  runat="server" class="searchlist_btn_lft"  Text="Clear" OnClick="btnclear_Click" />
         </div>--%> 
      

   </div>

    <br />




    <div id="divReportEmployeeDtl" class="widget-body no-padding dataTables_wrapper" style="margin-top: 0.5%;width: 100%;margin-left:0.2%;">
            <table id="datatable_fixed_column" class="table table-striped table-bordered" width="100%" style="font-family: Calibri;">
                <thead>
                    <tr class="SearchRow" >
                         <th class="hasinput" style="width: 15%">
                            <input type="text" class="form-control" placeholder="EMPLOYEE ID" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 20%">
                            <input  type="text" class="form-control" placeholder="EMPLOYEE NAME" onkeydown="return DisableEnter(event)" /></th>
                        <th class="hasinput" style="width: 15%">
                            <input  type="text" class="form-control" placeholder="DESIGNATION" onkeydown="return DisableEnter(event)" /></th>      
                         <th class="hasinput" style="width: 15%">
                            <input  type="text" class="form-control" placeholder="DEPARTMENT" onkeydown="return DisableEnter(event)" /></th> 
                         <th class="hasinput" style="width: 15%">
                            <input  type="text" class="form-control" placeholder="DIVISION" onkeydown="return DisableEnter(event)" /></th> 
                          <th class="hasinput" style="width: 15%">
                            <input  type="text" class="form-control" placeholder="PAY GRADE" onkeydown="return DisableEnter(event)" /></th>                                                                
                        <th class="hasinput" style="width: 5%"></th>
                    </tr>
                    <tr>
                        <th data-class="expand">EMPLOYEE ID</th>
                        <th data-class="expand">EMPLOYEE NAME</th>
                        <th data-class="expand">DESIGNATION</th>
                        <th data-class="expand">DEPARTMENT</th>
                        <th data-class="expand">DIVISION</th>
                        <th data-class="expand">PAY GRADE</th>
                        <th data-class="expand">MORE INFO</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="10" class="dataTables_empty">Loading details...</td>
                    </tr>
                </tbody>
            </table>
        </div>    


         <link href="/css/New%20Plugins/bootstrap.min.css" rel="stylesheet" />


    <link href="/css/New%20Plugins/font-awesome.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production.min.css" rel="stylesheet" />
    <link href="/css/New%20Plugins/smartadmin-production-plugins.min.css" rel="stylesheet" />


    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script> 
    <script src="/css/New%20Plugins/libs/jquery-ui-1.10.3.min.js"></script>  
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/css/New%20Plugins/datatables/dataTables.bootstrap.min.js"></script>

            








     <div id="divReport" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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
     Employee Details Report
      </div>
    </div>

 <%--------------------------------View for Bundle informatn--------------------------%>

    <div id="MymodalBundleInfo" class="MyModalJobShedule" >
         

            <div class="modal-headerCancelView">
                  <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                  <h3 style="font-family: Calibri; font-size: 18px; margin-left: 42%; padding-bottom: 0.7%; padding-top: 0.6%;">Employee Details</h3>
             </div>
            

         <div class="modal-body">

            <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 1%; font-family: Calibri;" class="print" onclick="printredirect()">
                <a id="A1" target="_blank" data-title="Item Listing" href="/HCM/HCM_Reports/Print/18_Print.htm" style="color: rgb(83, 101, 51)">
                 <img src="/Images/Other Images/imgPrint.png" style="max-width: 45%"/>
                 <span style="margin-top: 2px; float: right;">Print</span></a>                                    
            </div>

          

            <div id="divEmployee" style="width: 45%; float: left; margin-top: 2%;">
                   <h2 style="margin-left: 2%; width: 27%; float: left;">Employee  </h2>
                   <label id="lblEmp" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit;word-break:break-all;"></label>
            </div>

            <div id="divDesg" style="width: 45%; float: right; margin-top: 2%;">
                   <h2 style="margin-left: 2%; width: 30%; float: left;">Designation </h2>
                   <label id="lblDesg" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 60%; cursor: inherit;word-break:break-all;"></label>
            </div>

           
                  <div id="divDeptmnt" style="width: 45%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 27%; float: left;">Department  </h2>
                   <label id="lblDeprtmnt" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit;word-break:break-all;"></label>
            </div>

            <div id="divDivsn" style="width: 45%; float: right; margin-top: 1%;margin-right:6.4%;">
                   <h2 style="margin-left: 2%; width: 30%; float: left;">Division </h2>
                   <label id="lblDivsn" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 60%; cursor: inherit;word-break:break-all;"></label>
            </div>

                  <div id="divGrade" style="width: 45%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 27%; float: left;">Pay Grade </h2>
                   <label id="lblGrade" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit;word-break:break-all;"></label>
            </div>

            <div id="divPrjct" style="width: 45%; float: right; margin-top: 1%;margin-right:6.4%;">
                   <h2 style="margin-left: 2%; width: 30%; float: left;">Project </h2>
                   <label id="lblPrjct" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 60%; cursor: inherit;word-break:break-all;"></label>
            </div>

                  <div id="divNatnlty" style="width: 45%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 27%; float: left;">Nationality </h2>
                   <label id="lblNation" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit;word-break:break-all;"></label>
            </div>

            <div id="divRelgn" style="width: 45%; float: right; margin-top: 1%;margin-right:6.4%;">
                   <h2 style="margin-left: 2%; width: 30%; float: left;">Religion </h2>
                   <label id="lblRelgn" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 60%; cursor: inherit;word-break:break-all;"></label>
            </div>

                  <div id="divGender" style="width: 45%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 27%; float: left;">Gender </h2>
                   <label id="lblGender" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit;word-break:break-all;"></label>
            </div>

            <div id="divAge" style="width: 45%; float: right; margin-top: 1%;margin-right:6.4%;">
                   <h2 style="margin-left: 2%; width: 30%; float: left;">Age </h2>
                   <label id="lblAge" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 60%; cursor: inherit;word-break:break-all;"></label>
            </div>

                  <div id="divWrkSts" style="width: 45%; float: left; margin-top: 1%;">
                   <h2 style="margin-left: 2%; width: 27%; float: left;">Working Status  </h2>
                   <label id="lblWrkSts" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 70%; cursor: inherit;word-break:break-all;"></label>
            </div>

            <div id="divNumYears" style="width: 45%; float: right; margin-top: 1%;margin-right:6.4%;">
                   <h2 style="margin-left: 2%; width: 30%; float: left;">Number of Years at Al-Balagh  </h2>
                   <label id="lblNumYears" runat="server" style="float: left; color: #042f95; font-family: calibri; width: 20%; cursor: inherit;margin-top:4%;word-break:break-all;"></label>
            </div>

             </div>

           
           

        <%--    <div class="modal-footerCancelView" style="margin-top: 26.3%;">
                   </div>--%>

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
        #cphMain_divReport {
    overflow-x: visible;
}
        /*#ReportTable_filter {
            font-family: Calibri;
font-weight: bold;
font-size: 14px;
display: none;

        }*/
          .MyModalJobShedule {
    display: none;
    position: fixed;
    z-index: 100;
    padding-top: 0%;
    left: 8%;
    top: 18%;
    width: 84%;
    height: 58%;
    overflow: auto;
    background-color: white;
    border: 3px solid;
    border-color: #6f7b5a;
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

        function SearchData() {

            var OrgId = "";
            var CorpId = "";

            var DesignationId = "";
            var DepartmentId = "";
            var DivisionId = "";
            var ProjectId = "";
            var ReligionId = "";

            var GenderId = "";
            var NumOfYears = "";
            var PayGradeId = "";
            var AgeFrom = "";
            var AgeTo = "";
            var StatusId = "";
            var NationalityId = "";            
            






           
            OrgId = '<%= Session["ORGID"] %>';
            CorpId = '<%= Session["CORPOFFICEID"] %>';

            if (OrgId == "" || CorpId == "") {
                window.location = '/Security/Login.aspx';
            }

            if (document.getElementById("cphMain_ddlDesgntn").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlDesgntn");
                DesignationId = e.options[e.selectedIndex].value;
            }


            if (document.getElementById("cphMain_ddlDeptmnt").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlDeptmnt");
                DepartmentId = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlDivsn").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlDivsn");
                DivisionId = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlPrjct").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlPrjct");
                ProjectId = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlRelgn").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlRelgn");
                ReligionId = e.options[e.selectedIndex].value;
            }


            if (document.getElementById("cphMain_ddlGender").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlGender");
                GenderId = e.options[e.selectedIndex].value;
            }


            if (document.getElementById("cphMain_ddlNumYear").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlNumYear");
                NumOfYears = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlGrade").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlGrade");
                PayGradeId = e.options[e.selectedIndex].value;
            }

            AgeFrom = document.getElementById("cphMain_txtAgeFrom").value;
            AgeTo = document.getElementById("cphMain_txtAgeTo").value;



            if (document.getElementById("cphMain_ddlStatus").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlStatus");
                StatusId = e.options[e.selectedIndex].value;
            }

            if (document.getElementById("cphMain_ddlNation").value != "--SELECT--") {
                var e = document.getElementById("cphMain_ddlNation");
                NationalityId = e.options[e.selectedIndex].value;
            }

           


             LoadEmployeeDetailsList(OrgId, CorpId, DesignationId, DepartmentId, DivisionId, ProjectId, ReligionId, GenderId, NumOfYears, PayGradeId, AgeFrom, AgeTo, StatusId, NationalityId);
        }

    </script>
    




     <script type="text/javascript">
         var $NoConfi = jQuery.noConflict();
         var $NoConfi3 = jQuery.noConflict();
         function LoadEmployeeDetailsList(OrgId, CorpId, DesignationId, DepartmentId, DivisionId, ProjectId, ReligionId, GenderId, NumOfYears, PayGradeId, AgeFrom, AgeTo, StatusId, NationalityId) {


        var responsiveHelper_datatable_fixed_column = undefined;


        var breakpointDefinition = {
            tablet: 1024,
            phone: 480
        };

        /* COLUMN FILTER  */

        var otable = $NoConfi3('#datatable_fixed_column').DataTable({
            'bProcessing': true,
            'bServerSide': true,
            'sAjaxSource': 'data_Employee_Details_Report.ashx',

            "bDestroy": true,
            "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>>r>" +
                    "t" +
                    "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
            "autoWidth": true,
            "oLanguage": {
                "sSearch": '<span class="input-group-addon"><i  class="glyphicon glyphicon-search"></i></span>'

            },
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
            },

            "fnServerParams": function (aoData) {
                aoData.push({ "name": "OrgId", "value": OrgId });
                aoData.push({ "name": "CorpId", "value": CorpId });
                aoData.push({ "name": "DesignationId", "value": DesignationId });
                aoData.push({ "name": "DepartmentId", "value": DepartmentId });
                aoData.push({ "name": "DivisionId", "value": DivisionId });
                aoData.push({ "name": "ProjectId", "value": ProjectId });
                aoData.push({ "name": "ReligionId", "value": ReligionId });

                aoData.push({ "name": "GenderId", "value": GenderId });
                aoData.push({ "name": "NumOfYears", "value": NumOfYears });
                aoData.push({ "name": "PayGradeId", "value": PayGradeId });
                aoData.push({ "name": "AgeFrom", "value": AgeFrom });
                aoData.push({ "name": "AgeTo", "value": AgeTo });
                aoData.push({ "name": "StatusId", "value": StatusId });
                aoData.push({ "name": "NationalityId", "value": NationalityId });
            },
            aoColumnDefs: [
              {
                  bSortable: false,
                  aTargets: [-1, -2, -3,-4,-5,-6]
              }
            ]
        });


        // Apply the filter

        $NoConfi("#datatable_fixed_column thead th input[type=text]").on('keyup change', function () {

            otable
                .column($NoConfi(this).parent().index() + ':visible')
                .search(this.value)
                .draw();

        });
        /* END COLUMN FILTER */
        ScrollTop();
         }

    </script>


<script>
    function ScrollTop() {
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
    }
</script>


<%--         <script src="/js/jQuery/jquery-2.2.3.min.js"></script>  
       <script src="/js/jQueryUI/jquery-ui.min.js"></script>--%>


   <style>
       .table td + td+td+td,
.table th + th+th+th
{
    text-align:center;
}
          #datatable_fixed_column_wrapper {
            border: 1px solid #065757;
        }
        .dt-toolbar  {
    border-bottom: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.dt-toolbar-footer  {
    border-top: 1px solid  #c8b6b6;
    background: #f4f6f0;
}
.table > thead > tr > th {
    background: #eee;
    color:#fff;
}
.table-bordered, .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
    border-bottom: 1px solid #c8b6b6;
    border-right: 1px solid  #c8b6b6;
}
.table {
    font-size: 13px;
}
.table-striped > tbody > tr:nth-of-type(2n+1) {
    background-color: #eaeaea;
}
        table.dataTable thead .sorting {
              background-color: #79895f;
        }
        table.dataTable thead .sorting_asc, table.dataTable thead .sorting_desc {
    background-color: #92a276;
}
        .table > thead > tr > th {
            padding: 8px 10px;
        }
        .table > tbody > tr > td {
            padding: 5px 10px;
            border-bottom: none;
        }

        .table {
            color: #3e3737;
            font-weight: bolder;
        }


        input[type=text] {
  width: 100%;
 
}
      .cont_rght {
            width: 98%;
        }  


div.dataTables_wrapper div.dataTables_processing {   
   top: 600%;
}


table.dataTable thead > tr > th.sorting_disabled {   
    background-color: #79895f;
}


    </style>


</asp:Content>

