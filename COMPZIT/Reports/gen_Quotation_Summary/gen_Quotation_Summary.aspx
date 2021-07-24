<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Quotation_Summary.aspx.cs" Inherits="Reports_gen_Quotation_Summary_gen_Quotation_Summary" %>

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
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlDivisions').selectToAutocomplete1Letter();
        });
    </script>
    <script>

        function SearchValidation() {

            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
            var Division = document.getElementById("<%=ddlDivisions.ClientID%>").value;
            document.getElementById("<%=ddlDivisions.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
            $("div#divddl input.ui-autocomplete-input").css("borderColor", "");
            var ret = true;


            if (FromDate != "" && ToDate != "") {

                var RcptdatepickerDate = FromDate;
                var RarrDatePickerDate = RcptdatepickerDate.split("-");
                var RdateDateCntrlr = new Date(RarrDatePickerDate[2], RarrDatePickerDate[1] - 1, RarrDatePickerDate[0]);


                var CurrentDateDate = ToDate;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                if (RdateDateCntrlr > dateCurrentDate) {
                    $("#divWarning").html("From date cannot be greater than to date.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("cphMain_txtToDate").style.borderColor = "Red";
                    document.getElementById("cphMain_txtToDate").focus();
                    $cs('#cphMain_txtToDate').datepicker('hide');
                    ret = false;
                }

            }

            if (Division == "--SELECT DIVISION--") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=ddlDivisions.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=ddlDivisions.ClientID%>").focus();

                $("div#divddl input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divddl input.ui-autocomplete-input").select();
                $("div#divddl input.ui-autocomplete-input").focus();
                ret = false;
            }

            if (ToDate == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=txtToDate.ClientID%>").focus();
                ret = false;
            }

            if (FromDate == "") {
                $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                });
                document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "red";
                document.getElementById("<%=txtFromDate.ClientID%>").focus();
                ret = false;
            }
            if (ret == true) {
                LoadList();
            }
            return false;
        }
        function RemoveTag() {
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
        }
    </script>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" ></asp:ScriptManager>
    <asp:HiddenField ID="hiddenFromDtae" runat="server" />
    <asp:HiddenField ID="hiddenToDtae" runat="server" />
    <asp:HiddenField ID="hiddenDivision" runat="server" />
    <asp:HiddenField ID="HiddenFieldTypeText" runat="server" /> 
    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="#">Reports</a></li>
        <li class="active">Quotation Summary</li>
    </ol>
    <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1>Quotation Summary</h1>

          <div class="form-group fg5 sa_fg3">
            <label for="pwd" class="fg2_la1">From Date:<span class="spn1">*</span></label>
            <div id="datepickerFrom" class="input-group date dt_wdt" data-date-format="mm-dd-yyyy">
              <input autocomplete="off" class="form-control inp_bdr inp_mst" type="text" id="txtFromDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                <script>
                    var $cs = jQuery.noConflict();
                    $cs('#cphMain_txtFromDate').datepicker({
                        autoclose: true,
                        format: 'dd-mm-yyyy',
                        timepicker: false,
                        endDate: new Date(),
                    });
                            </script>
            </div>
          </div>

          <div class="form-group fg5 sa_fg3">
            <label for="pwd" class="fg2_la1">To Date:<span class="spn1">*</span></label>
            <div id="datepickerTo" class="input-group date dt_wdt" data-date-format="mm-dd-yyyy">
              <input autocomplete="off" class="form-control inp_bdr inp_mst" type="text" id="txtToDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                <script>
                    var $csi = jQuery.noConflict();
                    $csi('#cphMain_txtToDate').datepicker({
                        autoclose: true,
                        format: 'dd-mm-yyyy',
                        timepicker: false,
                        endDate: new Date(),
                    });
                            </script>
            </div>
          </div>

          <div class="form-group fg2 sa_fg3" id="divddl">
              <label for="email" class="fg2_la1">Division:<span class="spn1">*</span></label>
              <select class="form-control fg2_inp1" id="ddlDivisions" runat="server">
              </select>           
            </div>

            <div class="fg8">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
              <button class="submit_ser" onclick="return SearchValidation();"></button>
              <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   --> 
          </div>
          
    <div class="clearfix"></div>
    <div class="devider"></div>

        <p class="plc1 pull-right pl_rg wdt tr_r" id="lblCnt"></p>
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_900"></div>


  </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
      

<!-------working area_closed---->

</div>
   <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
     <script>
         function PrintClick() {
             var orgID = '<%= Session["ORGID"] %>';
             var corptID = '<%= Session["CORPOFFICEID"] %>';
             var FromDate = document.getElementById("<%=hiddenFromDtae.ClientID%>").value;
             var ToDate = document.getElementById("<%=hiddenToDtae.ClientID%>").value;
             var DivID = document.getElementById("<%=hiddenDivision.ClientID%>").value;
             if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                 if (FromDate != "" && ToDate != "" && DivID != "--SELECT DIVISION--") {

                     var divText = document.getElementById("<%=HiddenFieldTypeText.ClientID%>").value;
                     $.ajax({
                         type: "POST",
                         async: false,
                         contentType: "application/json; charset=utf-8",
                         url: "gen_Quotation_Summary.aspx/PrintList",
                         data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",FromDate: "' + FromDate + '",ToDate: "' + ToDate + '",DivID: "' + DivID + '",divText: "' + divText + '"}',
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
             $('.ui-autocomplete-input').on('keyup keypress', function (e) {
                 var keyCode = e.keyCode || e.which;
                 if (keyCode === 13) {
                     e.preventDefault();
                     return false;
                 }
             });
             $cs("#cphMain_txtFromDate").focus();
             $cs('#cphMain_txtFromDate').datepicker('hide');
             $cs("#cphMain_txtFromDate").click(function () {
                 $cs("#cphMain_txtFromDate").focus();
             });
             $cs("#cphMain_txtToDate").click(function () {
                 $cs("#cphMain_txtToDate").focus();
             });
             document.getElementById("<%=hiddenFromDtae.ClientID%>").value = document.getElementById("<%=txtFromDate.ClientID%>").value;
             document.getElementById("<%=hiddenToDtae.ClientID%>").value = document.getElementById("<%=txtToDate.ClientID%>").value;
             document.getElementById("<%=hiddenDivision.ClientID%>").value = document.getElementById("<%=ddlDivisions.ClientID%>").value;
             document.getElementById("<%=HiddenFieldTypeText.ClientID%>").value = $("#cphMain_ddlDivisions option:selected").text();
             Load_dt();
             getdata(1);
            
         });

         function LoadList() {
             document.getElementById("<%=hiddenFromDtae.ClientID%>").value = document.getElementById("<%=txtFromDate.ClientID%>").value;
              document.getElementById("<%=hiddenToDtae.ClientID%>").value = document.getElementById("<%=txtToDate.ClientID%>").value;
              document.getElementById("<%=hiddenDivision.ClientID%>").value = document.getElementById("<%=ddlDivisions.ClientID%>").value;
              document.getElementById("<%=HiddenFieldTypeText.ClientID%>").value = $("#cphMain_ddlDivisions option:selected").text();
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
              strPagingTable += '<div class="r_1024"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_900" style="width:100%;">';
              strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
              strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
              strPagingTable += '<tfoot id="trPagingTableFoot"></tfoot>';
              strPagingTable += '</table></div>';

              $("#divPagingTableContainer").html(strPagingTable);

              intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

              var url = "gen_Quotation_Summary.aspx/LoadStaticDatafordt";
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
              var url = "gen_Quotation_Summary.aspx/GetData";
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
