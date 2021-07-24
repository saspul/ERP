<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Lead_Summary_Popup.aspx.cs" Inherits="Reports_gen_Lead_Summary_gen_Lead_Summary_Popup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script> 
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenFromDtae" runat="server" />
    <asp:HiddenField ID="hiddenToDtae" runat="server" />
    <asp:HiddenField ID="hiddenDivision" runat="server" /> 
    <asp:HiddenField ID="hiddenUserId" runat="server" /> 
    <asp:HiddenField ID="hiddenStatusId" runat="server" /> 
     <ol class="breadcrumb">
         <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="#">Reports</a></li>
        <li class="active">Opportunity Summary</li>
    </ol>
    <div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1 class="h1_con">Opportunity Summary</h1>

        <div class="top_br_container hc_at tbr_contr">
          <div class="top_br_1 pa_h1 tb_hdr">
            <div class="col-md-6 tx_100 hcm_1_2">
              <ul>
                <li><span class="fg6 li_100">Lead Summary Between</span> <span class="fg6 li_100_1" id="lblDate"></span></li>
                <li><span class="fg6 li_100">Division</span> <span class="fg6 li_100_1" id="lblDivision"></span></li>
              </ul>
            </div>
            <div class="col-md-6 tx_100 hcm_1_2">
              <ul>
                <li><span class="fg6 li_100">Employee</span> <span class="fg6 li_100_1" id="lblEmployee"></span></li>
                <li><span class="fg6 li_100">Status</span> <span class="fg6 li_100_1" id="lblStatus"></span></li>
              </ul>
            </div>
          </div>
        </div>

    <div class="clearfix"></div>
    <div class="devider"></div>

        <p class="plc1 pull-right pl_rg wdt tr_r" id="lblCnt"></p>

        <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_1024"></div>


        <div class="clearfix"></div>
        <div class="free_sp"></div>

  </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
      

<!-------working area_closed---->

</div>
    <a href="#" type="button" class="list_b" title="Back to List" onclick="LeadSummary();">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
     <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
 <script>
     function LeadSummary() {
         var FromDate = document.getElementById("<%=hiddenFromDtae.ClientID%>").value;
         var ToDate = document.getElementById("<%=hiddenToDtae.ClientID%>").value;
         var Division = document.getElementById("<%=hiddenDivision.ClientID%>").value;
         window.location = "gen_Lead_Summary.aspx?fd=" + FromDate + "&td=" + ToDate + "&di=" + Division;
     }
     function PrintClick() {
         var orgID = '<%= Session["ORGID"] %>';
             var corptID = '<%= Session["CORPOFFICEID"] %>';
             var FromDate = document.getElementById("<%=hiddenFromDtae.ClientID%>").value;
             var ToDate = document.getElementById("<%=hiddenToDtae.ClientID%>").value;
         var DivID = document.getElementById("<%=hiddenDivision.ClientID%>").value;
         var userID = document.getElementById("<%=hiddenUserId.ClientID%>").value;
         var stsID = document.getElementById("<%=hiddenStatusId.ClientID%>").value;
             if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                 if (FromDate != "" && ToDate != "" && DivID != "--SELECT DIVISION--") {
                     $.ajax({
                         type: "POST",
                         async: false,
                         contentType: "application/json; charset=utf-8",
                         url: "gen_Lead_Summary_Popup.aspx/PrintList",
                         data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",FromDate: "' + FromDate + '",ToDate: "' + ToDate + '",DivID: "' + DivID + '",userID: "' + userID + '",stsID: "' + stsID + '"}',
                         dataType: "json",
                         success: function (data) {
                             if (data.d != "") {
                                 window.open(data.d, '_blank');
                             }
                         }
                     });
                 }
             }
             else {
                 window.location = '/Security/Login.aspx';
             }
             return false;
         }
         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             Load_dt();
             getdata(1);
         });

          //Efficiently Paging Through Large Amounts of Data
          var intOrderByColumn = 1;
          var intOrderByStatus = 0;
          var intToltalSearchColumns = 0;

          //------------Load column filters and table----------

          function Load_dt() {

              var strPagingTable = '';
              strPagingTable += '<div id="divHeader_dt"></div>';
              strPagingTable += '<div class="r_1024"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_1024" style="width:100%;">';
              strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
              strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
              strPagingTable += '<tfoot id="trPagingTableFoot"></tfoot>';
              strPagingTable += '</table></div>';

              $("#divPagingTableContainer").html(strPagingTable);

              intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

              var url = "gen_Lead_Summary_Popup.aspx/LoadStaticDatafordt";
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
              var strInputColumnSearch = "";//individual column search

              if (document.getElementById("txtCommonSearch_dt")) {
                  strCommonSearchString = document.getElementById("txtCommonSearch_dt").value.trim();
                  strCommonSearchString = ValidateSearchInputData(strCommonSearchString);
              }

              if (document.getElementById("ddl_page_size")) {
                  strPageSize = document.getElementById("ddl_page_size").value;
              }

              var strOrgId = '<%= Session["ORGID"] %>';
         var strCorpId = '<%= Session["CORPOFFICEID"] %>';
              var url = "gen_Lead_Summary_Popup.aspx/GetData";
         var objData = {};
         objData.OrgId = strOrgId;
         objData.CorpId = strCorpId;
         objData.PageNumber = strPageNumber;
         objData.PageMaxSize = strPageSize;
         objData.strCommonSearchTerm = strCommonSearchString;
         objData.OrderColumn = intOrderByColumn;
         objData.OrderMethod = intOrderByStatus;
         objData.strInputColumnSearch = strInputColumnSearch;
         objData.FromDate = document.getElementById("<%=hiddenFromDtae.ClientID%>").value;
         objData.ToDate = document.getElementById("<%=hiddenToDtae.ClientID%>").value;
         objData.DivID = document.getElementById("<%=hiddenDivision.ClientID%>").value;
         objData.userID = document.getElementById("<%=hiddenUserId.ClientID%>").value;
         objData.stsID = document.getElementById("<%=hiddenStatusId.ClientID%>").value;
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
                 $("#lblCnt").html("Total number of records: " + result.d[3]);

                 $("#lblDate").html(": " + objData.FromDate + " TO " + objData.ToDate);
                 $("#lblDivision").html(": "+result.d[4]);
                 $("#lblEmployee").html(": "+result.d[5]);
                 $("#lblStatus").html(": "+result.d[6]);


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
</asp:Content>

