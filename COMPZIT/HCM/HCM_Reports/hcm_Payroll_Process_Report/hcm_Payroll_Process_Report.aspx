<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Payroll_Process_Report.aspx.cs" Inherits="HCM_HCM_Reports_hcm_Payroll_Process_Report_hcm_Payroll_Process_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    
<style>
    /*EVM-0027*/
    table, tr, td {
  /*border: 3px solid red;*/
}
tr.noBorder td {
  border: 0;
}
/*end*/
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
                $au('#cphMain_ddlBank').selectToAutocomplete1Letter();
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

        </script>
 <script src="/JavaScript/jquery-1.8.3.min.js"></script>

 <script type="text/javascript">

     var $noCon = jQuery.noConflict();
     $noCon(window).load(function () {
         $noCon('div#divddlDepartmnt input.ui-autocomplete-input').focus();
         document.getElementById("<%=divPrintReport.ClientID%>").style.visibility = "hidden";
         document.getElementById("<%=divPrintCaption.ClientID%>").style.visibility = "hidden";

     });



     function SearchValidation() {

         var ret = true;

         $noCon('#cphMain_ddlYear').each(function () {
             var strYear = document.getElementById("<%=ddlYear.ClientID%>").value;
             if (strYear == "--SELECT YEAR--") {
                 //  isValid = false;
                 flag = false;
                 document.getElementById("<%=ddlYear.ClientID%>").style.borderColor = "Red";
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 ret = false;
             }
             else {
                 document.getElementById("<%=ddlYear.ClientID%>").style.borderColor = "";

             }
         });

         $noCon('#cphMain_ddlMonth').each(function () {
             var strMnth = document.getElementById("<%=ddlMonth.ClientID%>").value;

             if (strMnth == "--SELECT MONTH--") {
                 //  isValid = false;
                 flag = false;
                 document.getElementById("<%=ddlMonth.ClientID%>").style.borderColor = "Red";

                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 ret = false;
             }
             else {
                 document.getElementById("<%=ddlMonth.ClientID%>").style.borderColor = "";

             }
             });
         $noCon('#cphMain_ddlDepartmnt').each(function () {

             if ($noCon.trim($noCon(this).val()) == '--SELECT DEPARTMENT--') {
                 //  isValid = false;
                 flag = false;
                 $noCon('div#divddlDepartmnt input.ui-autocomplete-input').focus();
                 $noCon('div#divddlDepartmnt input.ui-autocomplete-input').css({
                     "border": "1px solid red",
                     "background": ""
                 });
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 ret = false;
             }
             else {
                 $noCon('div#divddlDepartmnt input.ui-autocomplete-input').css({
                     "border": "",
                     "background": ""
                 });
             }
         });
         return ret;
     }
     function CallCSVBtn() {
         document.getElementById("<%=BtnCSV.ClientID%>").click();
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
        function printsorted() {
            document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
            //    $('#cphMain_divPrintReportSorted table tr').find('td:eq(4),th:eq(4)').remove();
        }
     </script>

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenManpwrId" runat="server" />
                      <asp:Button ID="BtnCSV" style="float: right; height: 25px; margin-top:4.5%;text-align:center;display:none" runat="server" class="searchlist_btn_rght" Text="CSV"  OnClick="BtnCSV_Click"  />
       <a id="A2"  data-title="Item Listing"  style="float: right; margin-top:4.5%;color:rgb(83, 101, 51);font-family:Calibri;width: 10%;" href="javascript:;" onclick="CallCSVBtn();">
                                <img  src="../../../Images/Icons/new_CSV.PNG" title="Export to CSV" style="max-width: 20%;margin-left: 39%;" ><span style="margin-top: 1px; float: right;margin-right: 20%;">CSV</span></a> 
    <div style="cursor: default; float: right; height: 25px; margin-right:-2.5%; margin-top: 4.5%; font-family: Calibri;" class="print" onclick="printsorted()">
     <a id="A1" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/sort_EmpDtlsRprt.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;"> Print</span></a>                                  
</div>
    <div style="cursor: default; float: right; height: 25px; margin-right: 1.5%; margin-top: 4.5%; font-family: Calibri;display:none" class="print">
     <a id="print_cap" target="_blank" data-title="Visa Bundle" href="/HCM/HCM_Reports/Print/Common_print.htm" style="color: rgb(83, 101, 51);margin-right:15%">
       <img src="/Images/Other Images/imgPrint.png" style="max-width: 60%;margin-right:15%">
        <span style="margin-top: -28px; float: right;">Print</span></a>                                  
</div>


    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
       <div class="cont_rght" style="min-height: 256px;">
               <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="\Images\BigIcons\Payroll Process.png" style="vertical-align: middle;" />
     Payroll Process Report
        </div >
    <div style="border:.5px solid #9ba48b; background-color: #f3f3f3;margin-top:3%;height:125px;">
          
         <div class="row">
 <br />
       <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
   <ContentTemplate>
         <div class="col-md-4" style="width: 34%;">
         <h2 style="margin-left: 4%; width: 32%;" >Department*</h2>   <div id="divddlDepartmnt">
        <asp:DropDownList ID="ddlDepartmnt"  class="form1" runat="server" Style="height: 28px; width: 51%; float: right;" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartmnt_SelectedIndexChanged" > 
           </asp:DropDownList></div>
 </div>
       <div class="col-sm-4" style="width: 30%; margin-left: 2%;">
           <h2>Division </h2>
           <asp:DropDownList ID="ddlDivision" class="form1" runat="server" Style="height: 28px; width: 62%; float: right;">
           </asp:DropDownList>
       </div>
       </ContentTemplate>
           </asp:UpdatePanel>
               <div class="col-sm-4" style="width: 30%;">
         <h2>Bank </h2>
    
        <asp:DropDownList ID="ddlBank" class="form1" runat="server" Style="height: 28px; width: 52%; float: left; margin-left: 27%;">
           </asp:DropDownList>
         </div>
             </div>

         <div class="row" style="margin-top: 2%;">
                     <div class="col-sm-4" style="margin-left: 0.7%; width: 34.4%;">
                 <h2 style="margin-left: 2%; width: 39%;"> Salary month *</h2>
                                    <div id="divddlMonth">
                         <asp:DropDownList runat="server" class="form1" ID="ddlMonth" Style="float: left; width: 55%;"  >
                                    </asp:DropDownList></div>
                             
          </div>
                 <div class="col-sm-4" style="width: 31%; margin-left: 0.5%;">
                 <h2 style="width: 30%; margin-left: 2%;"> Year *</h2>
                                                      <div id="divddlYear">

                                    <asp:DropDownList runat="server" class="form1"  ID="ddlYear"  Style="float: left; width: 66%;" >
                                    </asp:DropDownList></div>

          </div>
              <div class="col-sm-4" >
            
                 <h2 style="margin-left: -2%;"> Search Option</h2>
                                    <asp:DropDownList runat="server" class="form1"  ID="ddlSearchOption"  Style="float: left; width: 25%; margin-left: 4%;" >
                                        <asp:ListItem Value="0">Basic</asp:ListItem>
                                           <asp:ListItem Value="1">Advanced</asp:ListItem>
                                    </asp:DropDownList>

       
       
        <asp:Button ID="btnSearch" Style="width: 30%; float: right; margin-top: 0%;margin-right: 3%;" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation()" OnClick="btnSearch_Click"/>
   </div>

 
 </div>
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
     Payroll Process Report
      </div>
             <div id="divPrintReportSorted" runat="server" style="display: none">
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


      .open > .dropdown-menu {
            display: none;
        }
    </style>
    
</asp:Content>

