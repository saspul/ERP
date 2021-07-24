<%@ Page Language="C#"  MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Active_Leads.aspx.cs" Inherits="Reports_gen_Active_Leads_gen_Active_Leads" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
 <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
 <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script> 
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
  </asp:ScriptManager>
     <asp:HiddenField ID="hiddenCrncyId" runat="server" />
   <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="#">Reports</a></li>
        <li class="active">Active Opportunity Summary</li>
    </ol>
    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr"> 
      <div class="content_box1 cont_contr">
        <h1 class="h1_con">Active Opportunity Summary</h1>

 <div class="form-group fg2 sa_fg4" id="divCrncy">
        <label for="email" class="fg2_la1">Currency:<span class="spn1">*</span></label>
        <select class="form-control fg2_inp1 inp_mst" id="ddlCurrency" runat="server">
        </select> 
      </div>

      <div class="fg5 sa_fg4">
        <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
        <button class="submit_ser" onclick="LoadList();"></button>
        <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->   
      </div>

    <div class="clearfix"></div>
    <div class="devider"></div>

        <p class="plc1 pull-right pl_rg wdt tr_r" id="lblNumRec"></p>
           <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_800"></div>

      <div class="clearfix"></div>

  </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
      

<!-------working area_closed---->

</div>
    <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
 <script>
    
       var $au = jQuery.noConflict();
     $au(function () {
         $au('#cphMain_ddlCurrency').selectToAutocomplete1Letter();
         //$("div#divCrncy input.ui-autocomplete-input").select();
         $("div#divCrncy input.ui-autocomplete-input").focus();
         $(".ui-autocomplete-input")[0].setSelectionRange(0, 0);
     });

     function PrintClick() {
         var orgID = '<%= Session["ORGID"] %>';
         var corptID = '<%= Session["CORPOFFICEID"] %>';
         var CrncyID = document.getElementById("<%=hiddenCrncyId.ClientID%>").value;
          if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
              $.ajax({
                  type: "POST",
                  async: false,
                  contentType: "application/json; charset=utf-8",
                  url: "gen_Active_Leads.aspx/PrintList",
                  data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",CrncyID: "' + CrncyID + '"}',
                  dataType: "json",
                  success: function (data) {
                      if (data.d != "") {
                          window.open(data.d, '_blank');
                      }
                  }
              });
          }
          else {
              window.location = '/Security/Login.aspx';
          }
          return false;
      }
     //--------------------------------------Pagination--------------------------------------

     $(document).ready(function () {
         document.getElementById("<%=hiddenCrncyId.ClientID%>").value = document.getElementById("<%=ddlCurrency.ClientID%>").value;
             Load_dt();
             getdata(1);
             $('.ui-autocomplete-input').on('keyup keypress', function (e) {
                 var keyCode = e.keyCode || e.which;
                 if (keyCode === 13) {
                     e.preventDefault();
                     return false;
                 }
             });
         });

     function LoadList() {
         document.getElementById("<%=hiddenCrncyId.ClientID%>").value = document.getElementById("<%=ddlCurrency.ClientID%>").value;
             getdata(1);
             return false;
         }

         //Efficiently Paging Through Large Amounts of Data
         var intOrderByColumn = 1;
         var intOrderByStatus = 0;
         var intToltalSearchColumns = 0;

         //------------Load column filters and table----------

         function Load_dt() {

             var strPagingTable = '';
             strPagingTable += '<div id="divHeader_dt"></div>';
             strPagingTable += '<div class="r_800"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_800" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '<tfoot id="trPagingTableFoot"></tfoot>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "gen_Active_Leads.aspx/LoadStaticDatafordt";
             $.ajax({
                 type: 'POST',
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     $("#divHeader_dt").html(result.d[0]);
                     $("#thPagingTable_SearchColumns").html(result.d[1]);
                     intToltalSearchColumns = result.d[2];
                     //bind on paste event to enable search on paste via mouse
                     $("input").on('paste', function (e) {
                         setTimeout(function () { $(e.target).keyup(); }, 100);
                     });
                 },
                 error: function () {
                     Error();
                 }
             });
         }

         //-----------Load datatable & pagination----------

         function getdata(strPageNumber) {
             document.getElementById("divPagingTable_processing").style.display = "";
             var strPageSize = 10;
             var strCommonSearchString = "";
             var strInputColumnSearch = getColumnSearchData();//individual column search

             if (document.getElementById("txtCommonSearch_dt")) {
                 strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                 strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
             }

             if (document.getElementById("ddl_page_size")) {
                 strPageSize = document.getElementById("ddl_page_size").value;
             }

             var strOrgId = '<%= Session["ORGID"] %>';
             var strCorpId = '<%= Session["CORPOFFICEID"] %>';
             var url = "gen_Active_Leads.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.PageNumber = strPageNumber;
             objData.PageMaxSize = strPageSize;
             objData.strCommonSearchTerm = strCommonSearchString;
             objData.OrderColumn = intOrderByColumn;
             objData.OrderMethod = intOrderByStatus;
             objData.strInputColumnSearch = strInputColumnSearch;
             objData.CrncyID = document.getElementById("<%=hiddenCrncyId.ClientID%>").value;
             $.ajax({

                 type: 'POST',
                 data: JSON.stringify(objData),
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     document.getElementById("divPagingTable_processing").style.display = "none";
                     $('#tblPagingTable tbody').html(result.d[0]);
                     $('#tblPagingTable tfoot').html(result.d[1]);
                     $("#cphMain_divReport").html(result.d[2]);//datatable
                     $("#lblNumRec").html("Total number of records: " + result.d[3]);
                     var intToltalColumns = document.getElementById('tblPagingTable').rows[1].cells.length;
                     if (document.getElementById("td_No_data_row_dt")) {
                         $("#td_No_data_row_dt").attr('colspan', intToltalColumns);
                     }
                     //enable sort icon 
                     if (intOrderByStatus == 1) {
                         $("#tdColumnHead_" + intOrderByColumn).addClass("asc");
                     }
                     else {
                         $("#tdColumnHead_" + intOrderByColumn).addClass("desc");
                     }
                    
                 },
                 error: function () {
                     Error();
                 }
             });
             return false;
         }


         function getColumnSearchData() {

             //this function collects data from input column search boxes and along with the id
             //— ‡
             var inputSearchTerms = "";
             for (var intSearchColumnCount = 0; intSearchColumnCount < intToltalSearchColumns; intSearchColumnCount++) {
                 if (document.getElementById("txtSearchColumn_" + intSearchColumnCount)) {
                     var searchString = document.getElementById("txtSearchColumn_" + intSearchColumnCount).value.trim();
                     if (searchString != "") {

                         searchString = ValidateSearchInputData(searchString);

                         if (inputSearchTerms == "") {
                             inputSearchTerms = intSearchColumnCount + "‡" + searchString;
                         } else {
                             inputSearchTerms += "—" + intSearchColumnCount + "‡" + searchString;
                         }
                     }
                 }
             }
             return inputSearchTerms;
         }
         function SetOrderByValue(intOrderBy) {
             intOrderByColumn = intOrderBy;
             if (intOrderByStatus == 1) {
                 intOrderByStatus = 0;
             }
             else {
                 intOrderByStatus = 1;
             }
             //redraw
             getdata(1);
         }
         function ValidateSearchInputData(strSearchString) {
             var text = strSearchString;
             var replaceText1 = text.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             var replaceText3 = replaceText2.replace(/'/g, "");
             strSearchString = replaceText3;
             if (strSearchString.length > 100) {
                 strSearchString = strSearchString.substring(0, 100);
             }
             else {
             }
             return strSearchString;
         }

         //Efficiently Paging Through Large Amounts of Data

         //setup before functions
         var typingTimer;                //timer identifier
         var doneTypingInterval = 1000;  //time in ms (5 seconds)

         function SettypingTimer(evt) {
             evt = (evt) ? evt : window.event;
             var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
             if (keyCodes == 13 || keyCodes == 9) {
                 return false;
             }
             //on keyup, start the countdown
             clearTimeout(typingTimer);
             typingTimer = setTimeout(doneTyping, doneTypingInterval);
         }

         //user is "finished typing," do something
         function doneTyping() {
             //do something
             getdata(1);
         }
        
         //--------------------------------------Pagination--------------------------------------
    </script> 
<style>
         .ui-autocomplete {
            padding: 0;
            list-style: none;
            background-color: #fff;
            width: 218px;
            border: 1px solid #B0BECA;
            max-height: 140px;
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
</asp:Content>

