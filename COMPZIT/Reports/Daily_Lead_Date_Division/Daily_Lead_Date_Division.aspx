<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Daily_Lead_Date_Division.aspx.cs" Inherits="Reports_Daily_Lead_Date_Division_Daily_Lead_Date_Division" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <!----date_ranger_picker_section_script-->
    <script type="text/javascript" src="/js/date_r/moment.min.js"></script>
    <script type="text/javascript" src="/js/date_r/daterangepicker.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/date_r/daterangepicker.css" />
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script> 
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
    <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script src="/js/New js/msdropdown/jquery.dd.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();
            $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
            $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        });
        function AutocompleteEmp() {
            $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
            $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
        }
        function SearchValidation() {
            var FromDate = document.getElementById("<%=ddlCurrency.ClientID%>").value;                
            document.getElementById("cphMain_ddlCurrency_msdd").style.borderColor = "";
            var ret = true;               
            if (FromDate == "--SELECT CURRENCY--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("cphMain_ddlCurrency_msdd").style.borderColor = "red";
                document.getElementById("cphMain_ddlCurrency_msdd").focus();
                ret = false;
            }
            if (ret == true) {
                LoadList();
            }
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
     </asp:ScriptManager>
     <asp:HiddenField ID="HiddenSearchField" runat="server" />
     <asp:HiddenField ID="hiddenRsnid" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrency" runat="server" />
     <asp:HiddenField ID="hiddenNext" runat="server" />
     <asp:HiddenField ID="hiddenFromDtae" runat="server" />   
     <asp:HiddenField ID="hiddenToDtae" runat="server" />   
     <asp:HiddenField ID="HiddenFieldCustomer" runat="server" />   
     <asp:HiddenField ID="HiddenFieldProject" runat="server" />   
     <asp:HiddenField ID="HiddenFieldCurrency" runat="server" />   
     <asp:HiddenField ID="HiddenFieldStatus" runat="server" />  
      <asp:HiddenField ID="HiddenFieldEmployee" runat="server" />  
     <asp:HiddenField ID="HiddenFieldDivision" runat="server" />  
     <asp:HiddenField ID="HiddenFieldCustomerT" runat="server" />   
     <asp:HiddenField ID="HiddenFieldProjectT" runat="server" />   
     <asp:HiddenField ID="HiddenFieldCurrencyT" runat="server" />   
     <asp:HiddenField ID="HiddenFieldStatusT" runat="server" />  
     <asp:HiddenField ID="HiddenFieldDateRange" runat="server" /> 
      <asp:HiddenField ID="HiddenFieldEmployeeT" runat="server" />  
     <asp:HiddenField ID="HiddenFieldDivisionT" runat="server" />  

     <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="#">Reports</a></li>
         <li class="active">Deal Closure Report for Division Manager</li> 
    </ol>
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
   <div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1>Deal Closure Report for Division Manager</h1>
        <div class="clearfix"></div>
          <button class="btn pull-right show_ser" title="show search area" style="display:none;">
            <i class="fa fa-caret-down"></i>
          </button>

          <div class="search_bo1 hide_box" style="display:block;">
            <div class="form-group fg2 sa_fg4 sa_480">
              <label for="email" class="fg2_la1">Date Range:<span class="spn1"></span></label>
              <button id="reportrange" style="background: #fff; cursor: pointer; padding: 7px 10px; border: 1px solid #ccc; width:90%;text-align: left;border-radius: 4px;height: 34px;" autofocus="" onclick="return false;">
                <span runat="server" id="dateRange"></span> <i class="fa fa-caret-down flt_r" style="padding-top: 3px;"></i>
              </button>
            </div>

           <div class="form-group fg2 sa_fg4 sa_480">
              <label for="email" class="fg2_la1">Status:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlStatus"  class="form-control fg2_inp1" runat="server">
              </asp:DropDownList>      
            </div>

        <div class="form-group fg2 sa_fg4 sa_480">
          <label for="email" class="fg2_la1">Customer:<span class="spn1"></span></label>
             <asp:DropDownList ID="ddlCustomer" class="form-control fg2_inp1" runat="server">
                    </asp:DropDownList>
        </div>

        <div class="form-group fg2 sa_fg4 sa_480">
          <label for="email" class="fg2_la1">Project:<span class="spn1"></span></label>
            <asp:DropDownList ID="ddlProject" class="form-control fg2_inp1" runat="server">
            </asp:DropDownList>
        </div>
               <asp:UpdatePanel ID="UpdatePanel1"  EnableViewState="true" UpdateMode="Conditional" runat="server">
                <ContentTemplate>

            <div class="form-group fg2 sa_fg4 sa_480">
              <label for="email" class="fg2_la1">Division:<span class="spn1"></span></label>
                  <asp:DropDownList ID="ddlDivision" class="form-control fg2_inp1" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>          
            </div>

              <div class="form-group fg2 sa_fg4 sa_480">
              <label for="email" class="fg2_la1">Employee:<span class="spn1"></span></label>
                   <asp:DropDownList  ID="ddlEmployee"  class="form-control fg2_inp1" runat="server" >
                    </asp:DropDownList>       
            </div>
             </ContentTemplate>                    
            </asp:UpdatePanel>
            <div class="form-group fg2 sa_fg4 sa_480">
              <label for="email" class="fg2_la1">Currency:<span class="spn1">*</span></label>
               <asp:DropDownList ID="ddlCurrency" class="form-control fg2_inp1 inp_mst" runat="server">
               </asp:DropDownList>
            </div>


           <div class="fg2 mar_bo1 sa_fg4 sa_480">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
              <button class="submit_ser" onclick="return SearchValidation();"></button>
              <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->  
          </div>

          <div class="clearfix"></div>
            <button class="btn pull-right hide_ser flt_r" title="hide search area">
              <i class="fa fa-caret-up"></i>
            </button>
          </div>

    <div class="clearfix"></div>
    <div class="devider"></div>

        <p class="plc1 pull-right pl_rg wdt tr_r" id="lblCnt">Total number of records: 0</p>

           <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_800"></div>

        <!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
      

<!-------working area_closed---->

</div>    
</div>
     <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
     <script>
         function PrintClick() {
             var objData = {};
             objData.orgID = '<%= Session["ORGID"] %>';
             objData.corptID = '<%= Session["CORPOFFICEID"] %>';
             objData.FromDate = document.getElementById("<%=hiddenFromDtae.ClientID%>").value;
             objData.ToDate = document.getElementById("<%=hiddenToDtae.ClientID%>").value;
             objData.CurrencyId = document.getElementById("<%=HiddenFieldCurrency.ClientID%>").value;
             objData.ProjectId = document.getElementById("<%=HiddenFieldProject.ClientID%>").value;
             objData.StatusId = document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
             objData.CustomerId = document.getElementById("<%=HiddenFieldCustomer.ClientID%>").value;
             objData.CurrencyIdT = document.getElementById("<%=HiddenFieldCurrencyT.ClientID%>").value;
             objData.ProjectIdT = document.getElementById("<%=HiddenFieldProjectT.ClientID%>").value;
             objData.StatusIdT = document.getElementById("<%=HiddenFieldStatusT.ClientID%>").value;
             objData.CustomerIdT = document.getElementById("<%=HiddenFieldCustomerT.ClientID%>").value;
             objData.hiddenDfltCurrencyMstrId = document.getElementById("<%=hiddenDfltCurrency.ClientID%>").value;
             objData.dateRange = document.getElementById("<%=HiddenFieldDateRange.ClientID%>").value;
             objData.userId = '<%= Session["USERID"] %>';
             objData.Division = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
             objData.DivisionT = document.getElementById("<%=HiddenFieldDivisionT.ClientID%>").value;
             objData.Employee = document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value;
             objData.EmployeeT = document.getElementById("<%=HiddenFieldEmployeeT.ClientID%>").value;

             if (objData.corptID != "" && objData.corptID != null && objData.orgID != "" && objData.orgID != null) {

                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "Daily_Lead_Date_Division.aspx/PrintList",
                     data: JSON.stringify(objData),
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

             var dateRange = document.getElementById('cphMain_dateRange').innerHTML;
             var strDateRange = dateRange.split(" ");
             document.getElementById("<%=hiddenFromDtae.ClientID%>").value = strDateRange[0];
             document.getElementById("<%=hiddenToDtae.ClientID%>").value = strDateRange[7];

             document.getElementById("<%=HiddenFieldCurrency.ClientID%>").value = document.getElementById("<%=ddlCurrency.ClientID%>").value;
             document.getElementById("<%=HiddenFieldProject.ClientID%>").value = document.getElementById("<%=ddlProject.ClientID%>").value;
             document.getElementById("<%=HiddenFieldStatus.ClientID%>").value = document.getElementById("<%=ddlStatus.ClientID%>").value;
             document.getElementById("<%=HiddenFieldCustomer.ClientID%>").value = document.getElementById("<%=ddlCustomer.ClientID%>").value;
             document.getElementById("<%=HiddenFieldDivision.ClientID%>").value = document.getElementById("<%=ddlDivision.ClientID%>").value;
             document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value;
             document.getElementById("<%=HiddenFieldCurrencyT.ClientID%>").value = $("#cphMain_ddlCurrency option:selected").text();
             document.getElementById("<%=HiddenFieldProjectT.ClientID%>").value = $("#cphMain_ddlProject option:selected").text();
             document.getElementById("<%=HiddenFieldStatusT.ClientID%>").value = $("#cphMain_ddlStatus option:selected").text();
             document.getElementById("<%=HiddenFieldCustomerT.ClientID%>").value = $("#cphMain_ddlCustomer option:selected").text();
             document.getElementById("<%=HiddenFieldDateRange.ClientID%>").value = document.getElementById('cphMain_dateRange').innerHTML;
             document.getElementById("<%=HiddenFieldDivisionT.ClientID%>").value = $("#cphMain_ddlDivision option:selected").text();
             document.getElementById("<%=HiddenFieldEmployeeT.ClientID%>").value = $("#cphMain_ddlEmployee option:selected").text();
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
             var dateRange = document.getElementById('cphMain_dateRange').innerHTML;
             var strDateRange = dateRange.split(" ");
             document.getElementById("<%=hiddenFromDtae.ClientID%>").value = strDateRange[0];
             document.getElementById("<%=hiddenToDtae.ClientID%>").value = strDateRange[7];

             document.getElementById("<%=HiddenFieldCurrency.ClientID%>").value = document.getElementById("<%=ddlCurrency.ClientID%>").value;
             document.getElementById("<%=HiddenFieldProject.ClientID%>").value = document.getElementById("<%=ddlProject.ClientID%>").value;
             document.getElementById("<%=HiddenFieldStatus.ClientID%>").value = document.getElementById("<%=ddlStatus.ClientID%>").value;
             document.getElementById("<%=HiddenFieldCustomer.ClientID%>").value = document.getElementById("<%=ddlCustomer.ClientID%>").value;
             document.getElementById("<%=HiddenFieldDivision.ClientID%>").value = document.getElementById("<%=ddlDivision.ClientID%>").value;
             document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value = document.getElementById("<%=ddlEmployee.ClientID%>").value;
             document.getElementById("<%=HiddenFieldCurrencyT.ClientID%>").value = $("#cphMain_ddlCurrency option:selected").text();
             document.getElementById("<%=HiddenFieldProjectT.ClientID%>").value = $("#cphMain_ddlProject option:selected").text();
             document.getElementById("<%=HiddenFieldStatusT.ClientID%>").value = $("#cphMain_ddlStatus option:selected").text();
             document.getElementById("<%=HiddenFieldCustomerT.ClientID%>").value = $("#cphMain_ddlCustomer option:selected").text();
             document.getElementById("<%=HiddenFieldDateRange.ClientID%>").value = document.getElementById('cphMain_dateRange').innerHTML;
             document.getElementById("<%=HiddenFieldDivisionT.ClientID%>").value = $("#cphMain_ddlDivision option:selected").text();
             document.getElementById("<%=HiddenFieldEmployeeT.ClientID%>").value = $("#cphMain_ddlEmployee option:selected").text();
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
             strPagingTable += '<div class="r_1024"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_800" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '<tfoot id="trPagingTableFoot"></tfoot>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "Daily_Lead_Date_Division.aspx/LoadStaticDatafordt";
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
             var url = "Daily_Lead_Date_Division.aspx/GetData";
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
              objData.CurrencyId = document.getElementById("<%=HiddenFieldCurrency.ClientID%>").value;
              objData.ProjectId = document.getElementById("<%=HiddenFieldProject.ClientID%>").value;
              objData.StatusId = document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
              objData.CustomerId = document.getElementById("<%=HiddenFieldCustomer.ClientID%>").value;
              objData.hiddenDfltCurrencyMstrId = document.getElementById("<%=hiddenDfltCurrency.ClientID%>").value;
              objData.dateRange = document.getElementById("<%=HiddenFieldDateRange.ClientID%>").value;
             objData.userId = '<%= Session["USERID"] %>';
             objData.Division = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
             objData.Employee = document.getElementById("<%=HiddenFieldEmployee.ClientID%>").value;
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
          $(document).ready(function (e) {
              var $aus = jQuery.noConflict();
              $aus("#cphMain_ddlCurrency").msDropdown({ roundedBorder: false });
              $aus("#cphMain_ddlCurrency").msDropdown({ visibleRows: 4 });
              $aus("").msDropdown();
          });
    </script> 
    <script type="text/javascript">
        $(function () {
            var start = moment().subtract(29, 'days');
            var end = moment();
            var $auST = jQuery.noConflict();
            function cb(start, end) {
                $auST('#reportrange span').html(start.format('DD-MM-YYYY') + '   To    ' + end.format('DD-MM-YYYY'));
            }


            $auST('#reportrange').daterangepicker({
                startDate: start,
                endDate: end,
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                }
            }, cb);
            cb(start, end);
            document.getElementById("<%=HiddenFieldDateRange.ClientID%>").value = document.getElementById('cphMain_dateRange').innerHTML;
            document.getElementById('reportrange').focus();
            $auST('.daterangepicker ').hide();
            $auST("#reportrange").click(function () {
                document.getElementById('reportrange').focus();
            });
        });
</script>
<script>
    $(document).ready(function () {
        $(".hide_ser").click(function () {
            $(".hide_box").fadeOut(400);
            $(".show_ser").fadeIn(400);
            return false;
        });
        $(".show_ser").click(function () {
            $(".hide_box").fadeIn(600);
            $(".show_ser").fadeOut(600);
            return false;
        });
    });
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
                    background-color: #08c;
                    color: #fff;
                    font-family: Calibri;
                }
                 .dd .ddTitle .ddTitleText {
    padding: 7px 20px 7px 5px;
}
                .dd .divider {
    border-left: none;
}
                .fa.pull-right {
    margin-left: 1px !important;
     margin-right: 2px !important;
}
                .daterangepicker .ranges li:hover {
    background-color: #08c;
    color: #fff;
}
    #reportrange:focus {
          border:1px solid #48acf2 !important;
           box-shadow: 0 0 2px #2196F3;
           outline:none!important;
    }    
                
    </style> 
</asp:Content>

