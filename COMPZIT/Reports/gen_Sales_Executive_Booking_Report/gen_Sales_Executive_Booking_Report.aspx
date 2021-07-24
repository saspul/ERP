<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Sales_Executive_Booking_Report.aspx.cs" Inherits="Reports_gen_Sales_Executive_Booking_Report_gen_Sales_Executive_Booking_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
   <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
     <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
     <script src="/js/New js/msdropdown/jquery.dd.js"></script>
     <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script>
        function divButtonMonthlyClick() {

            $("#divMain").hide();
            $("#divTables").hide();
            document.getElementById("<%=hiddenMode.ClientID%>").value = "1";
            //hiding other
            document.getElementById('divDdlQuarter').style.display = "none";
            document.getElementById('divMonthDdl').style.display = "";
            document.getElementById("<%=lblSubHead.ClientID%>").innerHTML = "Monthly Booking Report For Sales Executive";
            $("#divYear").removeClass().addClass("form-group fg7 sa_fg4");
            $("#divMonthDdl").removeClass().addClass("form-group fg7 sa_fg4");
            $("#divDivision ").removeClass().addClass("form-group fg2 sa_fg4");
            $("#divCurrency").removeClass().addClass("form-group fg2 sa_fg4");
            $("#divSearch").removeClass().addClass("fg7 pull-right sa_fg4");
            LoadList();
        }

        function divQuarterlyClick() {

            $("#divMain").hide();
            $("#divTables").hide();

            document.getElementById("<%=hiddenMode.ClientID%>").value = "2";

            //hiding other
            document.getElementById('divMonthDdl').style.display = "none";
            document.getElementById('divDdlQuarter').style.display = "";

            document.getElementById("<%=lblSubHead.ClientID%>").innerHTML = "Quarterly Booking Report For Sales Executive";

            $("#divYear").removeClass().addClass("form-group fg7 sa_fg4");
            $("#divDdlQuarter").removeClass().addClass("form-group fg7 sa_fg4");
            $("#divDivision ").removeClass().addClass("form-group fg2 sa_fg4");
            $("#divCurrency").removeClass().addClass("form-group fg2 sa_fg4");
            $("#divSearch").removeClass().addClass("fg7 pull-right sa_fg4");
            $("#btnQuarter" + document.getElementById("<%=ddlQuarter.ClientID%>").innerHTML).addClass("act");
            LoadList();
        }

        function divButtonYearlyClick() {

            $("#divMain").hide();
            $("#divTables").hide();

            document.getElementById("<%=hiddenMode.ClientID%>").value = "3";

            //hiding other
            document.getElementById('divMonthDdl').style.display = "none";
            document.getElementById('divDdlQuarter').style.display = "none";

            document.getElementById("<%=lblSubHead.ClientID%>").innerHTML = "Yearly Booking Report For Sales Executive";

            $("#divYear").removeClass().addClass("form-group fg5 sa_fg4");
            $("#divDivision ").removeClass().addClass("form-group fg2 sa_fg4");
            $("#divCurrency").removeClass().addClass("form-group fg2 sa_fg4");
            $("#divSearch").removeClass().addClass("fg5 pull-right sa_fg4");
            LoadList();
        }




        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            document.getElementById("<%=ddlCurrency.ClientID%>").innerHTML = document.getElementById("<%=HiddenFieldCurrencyDdl.ClientID%>").value;
            var $aus = jQuery.noConflict();
            $aus("#cphMain_ddlCurrency").msDropdown({ roundedBorder: false });
            $aus("#cphMain_ddlCurrency").msDropdown({ visibleRows: 4 });
            $aus("").msDropdown();
            divButtonMonthlyClick();
            $("#divMain").fadeIn();
            $("#divTables").fadeIn();
        });

        var $au = jQuery.noConflict();
        $au(function () {
            $au(".ddl").selectToAutocomplete1Letter();
        });

    </script>

<script>
    var objDataP = {};
    function PrintClick() {

        var OrgId = '<%= Session["ORGID"] %>';
        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var UserId = '<%= Session["USERID"] %>';
        if (CorpId != "" && CorpId != null && OrgId != "" && OrgId != null) {

            $.ajax({
                type: 'POST',
                async: false,
                url: "gen_Sales_Executive_Booking_Report.aspx/PrintList",
                data: JSON.stringify(objDataP),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
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
</script>

     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             Load_dt();
         });

         function LoadList() {
             Load_dt();
             getdata(1);
             return false;
         }

         //Efficiently Paging Through Large Amounts of Data
         var intOrderByColumn = 0;
         var intOrderByStatus = 0;
         var intToltalSearchColumns = 0;

         //------------Load column filters and table----------

         function Load_dt() {

             var strPagingTable = '';
             strPagingTable += '<div id="divHeader_dt"></div>';
             strPagingTable += '<div class="r_1024"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_1024" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var Mode = document.getElementById("<%=hiddenMode.ClientID%>").value;

             var url = "/Reports/gen_Sales_Executive_Booking_Report/gen_Sales_Executive_Booking_Report.aspx/LoadStaticDatafordt";
             var objData = {};
             objData.Mode = Mode;

             $.ajax({
                 type: 'POST',
                 dataType: 'json',
                 data: JSON.stringify(objData),
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
             var strUserId = '<%= Session["USERID"] %>';

             var strCustomer = document.getElementById("<%=ddlCustomer.ClientID%>").value
             var strCurrency = document.getElementById("<%=ddlCurrency.ClientID%>").value;
             var strYear = document.getElementById("<%=ddlYears.ClientID%>").innerHTML;

             var Mode = document.getElementById("<%=hiddenMode.ClientID%>").value;

             var strMonth = "";
             if (Mode == "1") {
                 strMonth = document.getElementById("<%=ddlMonths.ClientID%>").innerHTML;
             }

             var strQuarter = "";
             if (Mode == "2") {
                 strQuarter = document.getElementById("<%=ddlQuarter.ClientID%>").innerHTML;
             }



             var Customer = document.getElementById("<%=ddlCustomer.ClientID%>");
             var CustomerText = Customer.options[Customer.selectedIndex].text;
             var Currency = document.getElementById("<%=ddlCurrency.ClientID%>");
             var CurrencyText = Currency.options[Currency.selectedIndex].text;
             var YearText = document.getElementById("<%=ddlYears.ClientID%>").innerHTML;
             var MonthText = document.getElementById("<%=ddlMonthName.ClientID%>").innerHTML;
             var QuarterText = document.getElementById("<%=ddlQuarterName.ClientID%>").innerHTML

             objDataP = {};
             objDataP.OrgId = strOrgId;
             objDataP.CorpId = strCorpId;
             objDataP.UserId = strUserId;
             objDataP.Customer = strCustomer;
             objDataP.Currency = strCurrency;
             objDataP.CustomerText = CustomerText;
             objDataP.CurrencyText = CurrencyText;
             objDataP.Year = strYear;
             objDataP.Month = strMonth;
             objDataP.Quarter = strQuarter;
             objDataP.YearText = YearText;
             objDataP.MonthText = MonthText;
             objDataP.QuarterText = QuarterText;
             objDataP.Mode = Mode;
             //print





             var url = "/Reports/gen_Sales_Executive_Booking_Report/gen_Sales_Executive_Booking_Report.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.UserId = strUserId;
             objData.Customer = strCustomer;
             objData.Currency = strCurrency;
             objData.Year = strYear;
             objData.Month = strMonth;
             objData.Quarter = strQuarter;
             objData.Mode = Mode;
             objData.PageNumber = strPageNumber;
             objData.PageMaxSize = strPageSize;
             objData.strCommonSearchTerm = strCommonSearchString;
             objData.OrderColumn = intOrderByColumn;
             objData.OrderMethod = intOrderByStatus;
             objData.strInputColumnSearch = strInputColumnSearch;

             $.ajax({

                 type: 'POST',
                 data: JSON.stringify(objData),
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     document.getElementById("divPagingTable_processing").style.display = "none";
                     $('#tblPagingTable tbody').html(result.d[0]);
                     var TotalRows = result.d[1];
                     $("#cphMain_divReport").html(result.d[2]);//datatable

                     var intToltalColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

                     var intAdditionalCoumns = intToltalColumns - (intToltalSearchColumns);

                     if (intAdditionalCoumns < 0) {
                         intAdditionalCoumns = 0;
                     }

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

                    

                     document.getElementById("<%=lblToalRowCountmont.ClientID%>").innerHTML = TotalRows;

                 },
                 error: function () {
                     alert("error");
                 }
             });
             return false;
         }


         function getColumnSearchData() {

             //this function collects data from input column search boxes and along with the id
             //— ^
             var inputSearchTerms = "";
             for (var intSearchColumnCount = 0; intSearchColumnCount < intToltalSearchColumns; intSearchColumnCount++) {
                 if (document.getElementById("txtSearchColumn_" + intSearchColumnCount)) {
                     var searchString = document.getElementById("txtSearchColumn_" + intSearchColumnCount).value.trim();
                     if (searchString != "") {

                         searchString = ValidateSearchInputData(searchString);

                         if (inputSearchTerms == "") {
                             inputSearchTerms = intSearchColumnCount + "^" + searchString;
                         } else {
                             inputSearchTerms += "—" + intSearchColumnCount + "^" + searchString;
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
    </script>

    <script>
        function ClickYear(Row) {
            $('.clsYear').each(function () {
                var id = $(this).attr("id");
                if ($(this).hasClass("act") == true) {
                    $(this).removeClass("act");
                }
            });
            $("#btnYear" + Row).addClass("act");
            $(".rpt_d1").fadeOut();
            document.getElementById("<%=ddlYears.ClientID%>").innerHTML = $("#btnYear" + Row).text();
            return false;
        }

        function ClickMonth(Row) {
            $('.clsMnth').each(function () {
                var id = $(this).attr("id");
                if ($(this).hasClass("act") == true) {
                    $(this).removeClass("act");
                }
            });
            $("#btnMnth_" + Row).addClass("act");
            $(".rpt_d2").fadeOut();
            document.getElementById("<%=ddlMonthName.ClientID%>").innerHTML = $("#btnMnth_" + Row).text();
            document.getElementById("<%=ddlMonths.ClientID%>").innerHTML = parseInt(Row) + 1;
            return false;
        }

        function ClickQuarter(Row) {
            $('.clsQuarter').each(function () {
                var id = $(this).attr("id");
                if ($(this).hasClass("act") == true) {
                    $(this).removeClass("act");
                }
            });
            $("#btnQuarter" + Row).addClass("act");
            $(".rpt_d2").fadeOut();
            document.getElementById("<%=ddlQuarterName.ClientID%>").innerHTML = "Quarter " + Row;
            document.getElementById("<%=ddlQuarter.ClientID%>").innerHTML = Row;
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" ></asp:ScriptManager>
    <ol class="breadcrumb">
        <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
        <li><a href="#">Reports</a></li>
        <li class="active">Booking Report For Sales Executive</li>
    </ol>
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <asp:HiddenField ID="HiddenFieldCurrencyDdl" runat="server" />
     <asp:HiddenField ID="hiddenMode" runat="server" />
    <div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1>Booking Report For Sales Executive</h1>
        <div class="clearfix"></div>
       <button class="btn pull-right show_ser" title="show search area" style="display:none;">
      <i class="fa fa-caret-down"></i>
    </button>

<%--<asp:UpdatePanel ID="UpdatePanelForTable" runat="server" UpdateMode="Always">
    <ContentTemplate> --%>

    <div class="search_bo1 hide_box" style="display:block;">
  <a id="divButtonMonthly" class="tabli sa_480_btn tb_a1 sel_tba" onclick="return divButtonMonthlyClick();"><i class=""><img src="/Images/icon_rpt/month_b.png"></i> Monthly</a>
<a id="divButtonQuarterly" class="tabli sa_480_btn tb_a2" onclick="return divQuarterlyClick();" ><i class=""><img src="/Images/icon_rpt/quar_b.png"></i> Quarterly</a>
<a id="divButtonYearly" class="tabli sa_480_btn tb_a3" onclick="return divButtonYearlyClick();"><i class=""><img src="/Images/icon_rpt/year_b.png"></i> Yearly</a>
<div class="clearfix"></div>
      
      <div id="divMain" class="tab4 tbe_pdg" style="display:block;">
    <p class="plc1 pl_rg" id="lblSubHead" runat="server">Monthly BOOKING REPORT FOR Sales Executive</p>

      <div class="form-group fg7 sa_fg4" id="divYear">
        <label for="email" class="fg2_la1">Year<span class="spn1"></span>:</label>
         <a class="form-control fg2_inp1 btn_d1"><span id="ddlYears" runat="server"></span><i class="fa fa-caret-down flt_r"></i></a>
        <div id="divddlYears" runat="server" class="rpt_ddwn rpt_d1" style="display:none;">
        </div>          
      </div>
     <div class="form-group fg7 sa_fg4" id="divDdlQuarter">
        <label for="email" class="fg2_la1">Quarter<span class="spn1"></span>:</label>
        <a class="form-control fg2_inp1 btn_d2"><span id="ddlQuarterName" runat="server"></span><span style="display:none;" id="ddlQuarter" runat="server"></span><i class="fa fa-caret-down flt_r"></i> </a> 
        <div class="rpt_ddwn rpt_d2" style="display:none;">
          <button id="btnQuarter1" class="btn_qr clsQuarter" onclick="return ClickQuarter(1);">Quarter 1</button>
          <button id="btnQuarter2" class="btn_qr clsQuarter" onclick="return ClickQuarter(2);">Quarter 2</button>
          <button id="btnQuarter3" class="btn_qr clsQuarter" onclick="return ClickQuarter(3);">Quarter 3</button>
          <button id="btnQuarter4" class="btn_qr clsQuarter" onclick="return ClickQuarter(4);">Quarter 4</button>
        </div>      
      </div>
      <div class="form-group fg7 sa_fg4" id="divMonthDdl">
        <label for="email" class="fg2_la1">Month<span class="spn1"></span>:</label>
        <a class="form-control fg2_inp1 btn_d2"><span id="ddlMonthName" runat="server"></span><span style="display:none;" id="ddlMonths" runat="server"></span><i class="fa fa-caret-down flt_r"></i> </a> 
        <div id="divddlMonths" runat="server" class="rpt_ddwn rpt_d2" style="display:none;">
        </div>         
      </div>

        <div class="form-group fg2 sa_fg4" id="divDivision ">
        <label for="email" class="fg2_la1">Customer:<span class="spn1"></span></label>
           <asp:DropDownList ID="ddlCustomer" class="form-control fg2_inp1 ddl" runat="server" >
           </asp:DropDownList>
      </div>

      <div class="form-group fg2 sa_fg4" id="divCurrency">
        <label for="email" class="fg2_la1">Currency:<span class="spn1">*</span></label>
        <asp:DropDownList ID="ddlCurrency" class="form-control fg2_inp1 inp_mst" runat="server">
        </asp:DropDownList>          
      </div>
          
      <div class="fg7 pull-right sa_fg4" id="divSearch">
        <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
        <asp:Button ID="btnSearch" runat="server" class="submit_ser" Text="" OnClientClick="return LoadList();" />
      </div>
    </div>


  <div class="clearfix"></div>
    <button class="btn pull-right hide_ser flt_r" title="hide search area">
      <i class="fa fa-caret-up"></i>
    </button>
  </div>

<div class="clearfix"></div>
<div class="devider"></div>

      <div class="tab4 tbe_pdg" style="display:block;">
    
  <p class="plc1 pull-right pl_rg wdt tr_r">Total number of records: <asp:Label ID="lblToalRowCountmont" runat="server" ></asp:Label></p>

<div id="divTables" class="r_1024">
 <!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="r_1024"></div>
<!----table---->
</div>
</div>


<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</div>

<div class="clearfix"></div>


</div>
      
		</div>
      <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
    <a href="#" id="scroll" style="display: none;"><span class="fa fa-angle-up"></span></a>
    
  <script type="text/javascript">
      $(document).ready(function () {
          $(".cont_contr").scroll(function () {
              if ($(this).scrollTop() > 60) {
                  $('#scroll').fadeIn();
                  $('#divID, #divID1, #divID2, .rpt_ddwn, .rpt_ddwn1').fadeOut();
              } else {
                  $('#scroll').fadeOut();
              }
          });
          $('#scroll').click(function () {
              $(".cont_contr").animate({ scrollTop: 0 }, 600);
              return false;
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

<script type="text/javascript">
    $(".tb_a1").click(function () {
        $(".tb_a1").addClass("sel_tba");
        $(".tb_a2, .tb_a3").removeClass("sel_tba");
        $("#divMain").fadeIn();
        $("#divTables").fadeIn();
    });
    $(".tb_a2").click(function () {
        $(".tb_a2").addClass("sel_tba");
        $(".tb_a1, .tb_a3").removeClass("sel_tba");
        $("#divMain").fadeIn();
        $("#divTables").fadeIn();
    });
    $(".tb_a3").click(function () {
        $(".tb_a3").addClass("sel_tba");
        $(".tb_a1, .tb_a2").removeClass("sel_tba");
        $("#divMain").fadeIn();
        $("#divTables").fadeIn();
    });
</script>

<script>
    $(document).ready(function () {
        $("body").click(function () {
            $(".rpt_d1, .rpt_d2").hide();
        });

        $(".btn_d1").click(function (event) {
            $(".rpt_d1").toggle();
            $(".rpt_d2").fadeOut();
            event.stopPropagation();
        });
        $(".btn_d2").click(function () {
            $(".rpt_d2").toggle();
            $(".rpt_d1").fadeOut();
            event.stopPropagation();
        });
    });
    $(".btn_d2").on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 40) {
            $('.rpt_d2').show();
        }
    });
</script>
<script>
    $(document).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;

        if (keyCode == 9) {
            $('.dd .ddChild').hide();
        }
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
                    background-color: #D5E5F4;
                    color: #161A1C;
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
    </style>  
</asp:Content>

