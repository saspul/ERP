<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit.master" CodeFile="open_Lead_SalesExecutive.aspx.cs" Inherits="Reports_open_Lead_SalesExecutive_open_Lead_SalesExecutive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>

    <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script src="/js/New js/msdropdown/jquery.dd.js"></script>

    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
     <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

       <style>
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

           .ui-autocomplete {
               position: absolute;
               cursor: default;
               z-index: 4000 !important;
           }

           .dd .ddTitle .ddTitleText {
               padding: 7px 20px 7px 5px;
           }
           .dd .divider {
               border-left: none;
           }
    </style> 
<script type="text/javascript">

    var $noCon = jQuery.noConflict();
    $noCon(window).load(function () {


    });

</script>
        <script>
            function PrintClick() {
                var orgID = '<%= Session["ORGID"] %>';
                var corptID = '<%= Session["CORPOFFICEID"] %>';
                var strddlStatus = document.getElementById("<%=ddlLeadsts.ClientID%>").value;
                var customer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
                var project = document.getElementById("<%=ddlProjct.ClientID%>").value;
                var CrncyId = document.getElementById("<%=ddlCurrency.ClientID%>").value;

               
                var ddlStatus = document.getElementById("<%=ddlLeadsts.ClientID%>");
                var sts = ddlStatus.options[ddlStatus.selectedIndex].text;
                var Customer = document.getElementById("<%=ddlCustomer.ClientID%>");
        var cus = Customer.options[Customer.selectedIndex].text;
        var Project = document.getElementById("<%=ddlProjct.ClientID%>");
        var prj= Project.options[Project.selectedIndex].text;
              


                var Currency = document.getElementById("<%=ddlCurrency.ClientID%>");
                var crncy = Currency.options[Currency.selectedIndex].text;
              
            var strUserId = '<%= Session["USERID"] %>';

               
                if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                    var objData = {};
                    objData.orgID = orgID;
                    objData.corptID = corptID;
                    objData.CrncyID =CrncyId;
                    objData.strUserId = strUserId;
                    objData.strddlStatus =strddlStatus;
                    objData.customer = customer;
                    objData.project = project;
                    objData.sts=sts;
                    objData.cus=cus;
                    objData.prj= prj;
                    objData.crncy = crncy;
                    
                    $.ajax({
                        type: 'POST',
                        async: false,
                        url: "Open_Lead_SalesExecutive.aspx/PrintList",
                        data: JSON.stringify(objData),
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
          <%--  var strddlStatus = 0;
            if (document.getElementById("<%=ddlLeadsts.ClientID%>").value != "ALL STATUS") {
                 strddlStatus = document.getElementById("<%=ddlLeadsts.ClientID%>").value;
                 //  alert(strddlStatus);
             }--%>

             Load_dt();
             getdata(1);
         });

         function LoadList() {
            <%-- var strddlStatus = 0;
             if (document.getElementById("<%=ddlLeadsts.ClientID%>").value != "ALL STATUS") {
                 strddlStatus = document.getElementById("<%=ddlLeadsts.ClientID%>").value;
             }--%>

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

             var url = "open_Lead_SalesExecutive.aspx/LoadStaticDatafordt";
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
             //   alert("f");
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
             var strddlStatus = 0;
             if (document.getElementById("<%=ddlLeadsts.ClientID%>").value != "ALL STATUS") {
                 strddlStatus = document.getElementById("<%=ddlLeadsts.ClientID%>").value;
                 //   alert(strddlStatus);
             }
             var customer = 0;
             if (document.getElementById("<%=ddlCustomer.ClientID%>").value != "--SELECT CUSTOMER--") {
                 customer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
             }
             var project = 0;
             if (document.getElementById("<%=ddlProjct.ClientID%>").value != "--SELECT PROJECT--") {
                 project = document.getElementById("<%=ddlProjct.ClientID%>").value;
             }
             var currency = 0;
             if (document.getElementById("<%=ddlCurrency.ClientID%>").value != "--SELECT CURRENCY--") {
                 currency = document.getElementById("<%=ddlCurrency.ClientID%>").value;
             }


             var url = "/Reports/open_Lead_SalesExecutive/open_Lead_SalesExecutive.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.Userid = strUserId;
             objData.ddlStatus = strddlStatus;
             objData.customer = customer;
             objData.project = project;
             objData.currency = currency;
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

                     document.getElementById("divPagingTable_processing").style.display = "none";

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
             //  alert(inputSearchTerms);
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
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();

            $au('#cphMain_ddlProjct').selectToAutocomplete1Letter();

        });
    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
   
            <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>

    <%--newd--%>
    

    
	<ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
    <li><a href="open_Lead_SalesExecutive.aspx">Reports</a></li>
    <li class="active">Open Opportunities for Sales Executive</li> 
  </ol>

	<div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1>Open Opportunities for Sales Executive</h1>
        <div class="clearfix"></div>
          <button class="btn pull-right show_ser" title="show search area" style="display:none;">
            <i class="fa fa-caret-down"></i>
          </button>

          <div class="" style="display:block;">


            <div class="form-group fg5 sa_fg4">
              <label for="email" class="fg2_la1">Status:<span class="spn1"></span></label>

                 <asp:DropDownList ID="ddlLeadsts" class="form-control fg2_inp1" runat="server" >
                   
                </asp:DropDownList>
               
            </div>


        <div class="form-group fg5 sa_fg4">
          <label for="email" class="fg2_la1">Customer:<span class="spn1"></span></label>
              <select class="form-control fg2_inp1 " id="ddlCustomer" runat="server">
        </select> 
            <%--<asp:DropDownList ID="ddlCustomer"  class="form-control fg2_inp1" runat="server" >
                    </asp:DropDownList>
        --%>
        </div>
              <div class="form-group fg5 sa_fg4">
                <label for="email" class="fg2_la1">Project:<span class="spn1"></span></label>
                   <select class="form-control fg2_inp1 " id="ddlProjct" runat="server">
        </select> 
                  <%-- <asp:DropDownList ID="ddlProjct" class="form-control fg2_inp1" runat="server">
                   
                </asp:DropDownList>--%>
             
              </div>

              <div class="form-group fg5 sa_fg4">
                <label for="email" class="fg2_la1">Currency:<span class="spn1">*</span></label>
                   <div id="divddlCurrency">
                <asp:DropDownList ID="ddlCurrency" class="form-control fg2_inp1 inp_mst" runat="server">
                   </asp:DropDownList>
               </div>
                  

                <%--<select name="countries" id="countries" class="form-control fg2_inp1 inp_mst" >
                  <option value='ad' data-image="..\images\icons\opp\inr.png" data-imagecss="flag ad" data-title="Indian Rupee" selected="">INR</option>
                  <option value='ae' data-image="..\images\icons\opp\inr.png" data-imagecss="flag ae" data-title="Qatar Riyal">QAR</option>
                  <option value='af' data-image="..\images\icons\opp\inr.png" data-imagecss="flag af" data-title="US Dollar">USD</option>
                </select>--%>         
              </div>

            <div class="fg8 tr_l sa_fg4">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
              <button class="submit_ser"  onclick="return LoadList();"></button>
            
          </div>

         
    <div class="clearfix"></div>
    <div class="devider"></div>

      <%--  <p class="plc1 pull-right pl_rg wdt tr_r">Total number of records: 100</p>--%>

        <%--<div class="r_1024">

            </div>--%>
          
         <p class="plc1 pull-right pl_rg wdt tr_r" id="lblNumRec"></p>
           <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_800"></div>

      <div class="clearfix"></div>

        </div>
    </div>
            </div>
      <%--newd--%>
    <a href="javascript:;" type="button" class="print_o" title="Print page" onclick="PrintClick();">
  <i class="fa fa-print"></i>
</a>
      

        <script>
            $(document).ready(function () {
                $(".hide_ser").click(function () {
                    $(".hide_box").fadeOut(400);
                    $(".show_ser").fadeIn(400);
                });
                $(".show_ser").click(function () {
                    $(".hide_box").fadeIn(600);
                    $(".show_ser").fadeOut(600);
                });
            });
</script>

        <script>
            $(document).ready(function () {
                $noCon("#cphMain_ddlCurrency").msDropdown({ roundedBorder: false });
            })
</script>

<script>
    $(document).ready(function (e) {
        $noCon("#cphMain_ddlCurrency").msDropdown({ visibleRows: 4 });
    });
    $(document).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            $('.dd .ddChild').hide();
        }
    });
</script>   
</asp:Content>


