<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Daily_Open_Lead_Division.aspx.cs" Inherits="Reports_Daily_Open_Lead_Division_Daily_Open_Lead_Division" %>

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

    var $au = jQuery.noConflict();
    $au(function () {
        $au(".ddl").selectToAutocomplete1Letter();
    });

    function SearchValidation() {
        ret = true;
        var ddlCustomer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
        var ddlProject = document.getElementById("<%=ddlProject.ClientID%>").value;
        var ddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
        var ddlEmployee = document.getElementById("<%=ddlEmployee.ClientID%>").value;
        $("#divddlCurrency> input").css("borderColor", "");
        document.getElementById("<%=ddlCurrency.ClientID%>").style.borderColor = "";

        var ddlCurrncy = document.getElementById("<%=ddlCurrency.ClientID%>").value;

        if (ddlCurrncy == "--SELECT CURRENCY--") {//evm-0020
            $("#danger-alert").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
            $("#danger-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            document.getElementById("<%=ddlCurrency.ClientID%>").style.borderColor = "Red";
            $("#divddlCurrency> input").css("borderColor", "red");
            document.getElementById("<%=ddlCurrency.ClientID%>").focus();
            ret = false;
        }

        if (ret == true) {
            document.getElementById("<%=HiddenSearchField.ClientID%>").value = ddlCustomer + ',' + ddlProject + ',' + ddlStatus + ',' + ddlEmployee;
        }
        return ret;
    }

</script>

<script>
    function PrintClick() {

        var OrgId = '<%= Session["ORGID"] %>';
        var CorpId = '<%= Session["CORPOFFICEID"] %>';
        var UserId = '<%= Session["USERID"] %>';

        var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
        var strCustomer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
        var strProject = document.getElementById("<%=ddlProject.ClientID%>").value;
        var strDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;
        var strEmployee = document.getElementById("<%=ddlEmployee.ClientID%>").value;
        var strCurrency = document.getElementById("<%=ddlCurrency.ClientID%>").value;

        var ddlStatus = document.getElementById("<%=ddlStatus.ClientID%>");
        var ddlStatusText = ddlStatus.options[ddlStatus.selectedIndex].text;
        var Customer = document.getElementById("<%=ddlCustomer.ClientID%>");
        var CustomerText = Customer.options[Customer.selectedIndex].text;
        var Project = document.getElementById("<%=ddlProject.ClientID%>");
        var ProjectText = Project.options[Project.selectedIndex].text;
        var Division = document.getElementById("<%=ddlDivision.ClientID%>");
        var DivisionText = Division.options[Division.selectedIndex].text;
        var Employee = document.getElementById("<%=ddlEmployee.ClientID%>");
        var EmployeeText = Employee.options[Employee.selectedIndex].text;
        var Currency = document.getElementById("<%=ddlCurrency.ClientID%>");
        var CurrencyText = Currency.options[Currency.selectedIndex].text;

        if (CorpId != "" && CorpId != null && OrgId != "" && OrgId != null) {

            var objData = {};
            objData.OrgId = OrgId;
            objData.CorpId = CorpId;
            objData.UserId = UserId;
            objData.ddlStatus = strddlStatus;
            objData.Customer = strCustomer;
            objData.Project = strProject;
            objData.Division = strDivision;
            objData.Employee = strEmployee;
            objData.Currency = strCurrency;
            objData.ddlStatusText = ddlStatusText;
            objData.CustomerText = CustomerText;
            objData.ProjectText = ProjectText;
            objData.DivisionText = DivisionText;
            objData.EmployeeText = EmployeeText;
            objData.CurrencyText = CurrencyText;

            $.ajax({
                type: 'POST',
                async: false,
                url: "Daily_Open_Lead_Division.aspx/PrintList",
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
             Load_dt();
             getdata(1);
         });

         function LoadList() {
             if (SearchValidation() == true) {
                 getdata(1);
             }
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
             strPagingTable += '<div><table id="tblPagingTable" class="display table-bordered pro_tab1" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "/Reports/Daily_Open_Lead_Division/Daily_Open_Lead_Division.aspx/LoadStaticDatafordt";
             var objData = {};

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

             //if (strOrgId == "" || strCorpId == "") {
             //    window.location.href = "/Default.aspx";
             //    return false;
             //}

             var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
             var strCustomer = document.getElementById("<%=ddlCustomer.ClientID%>").value;
             var strProject = document.getElementById("<%=ddlProject.ClientID%>").value;
             var strDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;
             var strEmployee = document.getElementById("<%=ddlEmployee.ClientID%>").value;
             var strCurrency = document.getElementById("<%=ddlCurrency.ClientID%>").value;

             var url = "/Reports/Daily_Open_Lead_Division/Daily_Open_Lead_Division.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.UserId = strUserId;
             objData.ddlStatus = strddlStatus;
             objData.Customer = strCustomer;
             objData.Project = strProject;
             objData.Division = strDivision;
             objData.Employee = strEmployee;
             objData.Currency = strCurrency;
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

                     document.getElementById("divPagingTable_processing").style.display = "none";

                     document.getElementById("<%=lblToalRowCount.ClientID%>").innerHTML = "Total number of records:" + TotalRows;

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

     function SettypingTimer() {
         //on keyup, start the countdown
         clearTimeout(typingTimer);
         typingTimer = setTimeout(doneTyping, doneTypingInterval);
     }

     //user is "finished typing," do something
     function doneTyping() {
         //do something
         getdata(1);
     }

     //$("th i").click(function () {
     //    alert();
     //});

     //$('.pull-right hed_fa').click(function () {
     //    alert("1  " + $(this).hasClass('fa fa-sort')); alert("2  " + $(this).hasClass('fa fa-caret-up')); alert("3  " + $(this).hasClass('fa fa-caret-down'));
     //    if ($(this).hasClass('fa fa-sort') == true) {
     //        $(this).addClass('fa fa-caret-up');
     //    }
     //    else if ($(this).hasClass('fa fa-caret-up') == true) {
     //        $(this).addClass('fa fa-caret-down');
     //    }
     //    else {
     //        $(this).addClass('fa fa-sort');
     //    }
     //});

     //--------------------------------------Pagination--------------------------------------

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">

    
     <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

     <asp:HiddenField ID="HiddenSearchField" runat="server" />
     <asp:HiddenField ID="hiddenRsnid" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrency" runat="server" />    
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
     <asp:HiddenField ID="hiddenNext" runat="server" />


  <ol class="breadcrumb">
    <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
    <li class="active">Reports</li>
    <li class="active">Open Opportunities for Division Manager</li> 
  </ol>

<!---alert_message_section---->
<div class="myAlert-top alert alert-success" id="success-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Success!</strong> Changes completed succesfully
</div>

<div class="myAlert-bottom alert alert-danger" id="danger-alert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Danger!</strong> Request not conmpleted
</div>
<!----alert_message_section_closed---->

	<div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1>Open Opportunities for Division Manager</h1>
        <div class="clearfix"></div>
          <a class="btn pull-right show_ser" title="show search area" style="display:none;">
            <i class="fa fa-caret-down"></i>
          </a>

          <div class="search_bo1 hide_box" style="display:block;">

            <div class="form-group fg2 sa_fg4">
              <label for="email" class="fg2_la1">Status:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1" runat="server">
                  </asp:DropDownList>          
            </div>

            <div class="form-group fg2 sa_fg4">
              <label for="email" class="fg2_la1">Customer:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlCustomer" class="form-control fg2_inp1 ddl" runat="server">
                 </asp:DropDownList>
            </div>

              <div class="form-group fg2 sa_fg4">
                <label for="email" class="fg2_la1">Project:<span class="spn1"></span></label>
                <asp:DropDownList ID="ddlProject" class="form-control fg2_inp1 ddl" runat="server">
                    </asp:DropDownList>
              </div>

            <div class="form-group fg2 sa_fg4">
              <label for="email" class="fg2_la1">Division:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlDivision" class="form-control fg2_inp1 ddl" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true">
                 </asp:DropDownList>      
            </div>

            <div class="form-group fg2 sa_fg4">
              <label for="email" class="fg2_la1">Employee:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlEmployee" class="form-control fg2_inp1 ddl" runat="server">
                  </asp:DropDownList>          
            </div>

             <div class="form-group fg2 sa_fg4">
              <label for="email" class="fg2_la1">Currency:<span class="spn1">*</span></label>
               <div id="divddlCurrency">
                <asp:DropDownList ID="ddlCurrency" class="form-control fg2_inp1 inp_mst" runat="server">
                   </asp:DropDownList>
               </div>
<%--                 <select class="form-control fg2_inp1 inp_mst">
                  <option value='ad' data-image="/CustomImages/Country_Icon_Images/INR.png" data-imagecss="flag ad" data-title="Indian Rupee" selected="">INR</option>
                  <option value='ae' data-image="/CustomImages/Country_Icon_Images/INR.png" data-imagecss="flag ae" data-title="Qatar Riyal">QAR</option>
                  <option value='af' data-image="/CustomImages/Country_Icon_Images/INR.png" data-imagecss="flag af" data-title="US Dollar">USD</option> 
                 </select>--%>
            </div>

           
           <div class="fg8 mar_bo1 tr_l sa_fg4">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
              <asp:Button ID="btnSearch" runat="server" class="submit_ser" Text="" OnClientClick="return LoadList();" />
          </div>

  <div class="clearfix"></div>
    <a class="btn pull-right hide_ser flt_r" title="hide search area">
      <i class="fa fa-caret-up"></i>
    </a>
  </div>

    <div class="clearfix"></div>
    <div class="devider"></div>
          
        <p class="plc1 pull-right pl_rg wdt tr_r"><asp:Label ID="lblToalRowCount" runat="server"></asp:Label></p>

        <div class="r_1024">

 <!----table---->
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
       <div id="divReport" runat="server" class="tab_res"></div>
<!----table---->

  </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
      

<!-------working area_closed---->

</div>    
</div>

<!---print_button--->
<a href="javascript:;" type="button" class="print_o" title="Print page" onclick="PrintClick();">
  <i class="fa fa-print"></i>
</a>
<!---print_button_closed--->

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
$(document).ready(function() {
    $noCon("#cphMain_ddlCurrency").msDropdown({ roundedBorder: false });
})
</script>

<script>
    $(document).ready(function(e) {
        $noCon("#cphMain_ddlCurrency").msDropdown({ visibleRows: 4 });
    });
    $(document).on('keydown', function(e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            $('.dd .ddChild').hide();
        }
    });
</script>

</asp:Content>

