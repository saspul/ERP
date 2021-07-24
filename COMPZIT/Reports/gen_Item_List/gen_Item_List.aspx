<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Item_List.aspx.cs" Inherits="Reports_gen_Item_Listing_gen_Item_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
   <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>

    <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script src="/js/New js/msdropdown/jquery.dd.js"></script>

    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
     <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">

      

        function getdetails(href) {
            window.location = href;
            return false;
        }
        

        // for not allowing <> tags
        function isTag(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }


        //function printsorted() {
        //    document.getElementById("cphMain_divPrintReportSorted").innerHTML = $('#ReportTable')[0].outerHTML;
        //    //   $('#cphMain_divPrintReportSorted table tr').find('td:eq(4),th:eq(4)').remove();
        //}
    </script>

   <script type="text/javascript">

       var $noCon = jQuery.noConflict();
       $noCon(window).load(function () {


       });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:HiddenField ID="hiddenNext" runat="server" />
    <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
    <asp:HiddenField ID="hiddenMemorySize" runat="server" />
    <asp:HiddenField ID="hiddenSearch" runat="server" Value="--SELECT ALL DIVISION--" />
     <asp:HiddenField ID="HiddenCount" runat="server" />



    <%--newd--%>
    

    
	<ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
    <li><a href="gen_Item_List.aspx">Reports</a></li>
    <li class="active">Item Listing</li> 
  </ol>

	
  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr"> 
      <div class="content_box1 cont_contr">
        <h1 class="h1_con">Item Listing</h1>
        <div class="clearfix"></div>
          <button class="btn pull-right show_ser" title="show search area" style="display:none;">
            <i class="fa fa-caret-down"></i>
          </button>

        <%--  <div class="" style="display:block;">--%>


            <div class="form-group fg2 sa_fg2">
              <label for="email" class="fg2_la1">Status:<span class="spn1">*</span></label>
                 <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1" runat="server" >
                    <asp:ListItem Value="1">Active</asp:ListItem>
                  <asp:ListItem Value="0">Inactive</asp:ListItem>
                  <asp:ListItem Value="2">All</asp:ListItem>
                </asp:DropDownList>
               
            </div>


        <div class="form-group fg2 sa_fg2 b_box">
          <label for="email" class="fg2_la1">Product Nature:<span class="spn1">*</span></label>

               <select  id="prnature" class="form-control fg2_inp1 inp_mst" runat="server" >
                <option value='1' data-image="../../Images/opp/sa1.png" data-imagecss="flag 1" data-title="Saleable" selected="">Saleable</option>
                <option value='2' data-image="../../Images/opp/st1.png" data-imagecss="flag 2" data-title="Stockable">Stockable</option>
                <option value='0' data-image="../../Images/opp/ss1.png" data-imagecss="flag 0" data-title="Both">Both</option>
              </select>   
           
       
        </div>

              <div class="form-group fg2 sa_fg2">
              <label for="email" class="fg2_la1">Product Group:<span class="spn1">*</span></label>
              <select class="form-control fg2_inp1 inp_mst" id="ddlProductGroup" runat="server">
               
              </select>           
            </div>

            <div class="form-group fg2 sa_fg2">
              <label for="email" class="fg2_la1">Main Category:<span class="spn1">*</span></label>
              <select class="form-control fg2_inp1 inp_mst" id="ddlCategoryType" runat="server">
                
              </select>           
            </div>
            <div class="clearfix"></div>

            <div class="form-group fg2 sa_fg2">
              <label for="email" class="fg2_la1">Division<span class="spn1"></span>:</label>
              <select class="form-control fg2_inp1" id="ddlDivisionSearch" runat="server">
               
              </select>           
            </div>

              <div class="fg2 sa_fg2">
                <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
                <button class="submit_ser"></button>
                <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   --> 
              </div>

          <div class="clearfix"></div>
            <button class="btn pull-right hide_ser flt_r" title="hide search area">
              <i class="fa fa-caret-up"></i>
            </button>
        <%--  </div>
         --%>
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



          <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
          
               var  strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
                 //  alert(strddlStatus);
        

             Load_dt();
             getdata(1);
         });

         function LoadList() {
           var  strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;

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

             var url = "gen_Item_List.aspx/LoadStaticDatafordt";
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
            
              var   strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
               
               var  nature = document.getElementById("<%=prnature.ClientID%>").value;
          //   alert(nature);
             var productgrp = 0;
             if (document.getElementById("<%=ddlProductGroup.ClientID%>").value != "--SELECT PRODUCT GROUP--") {
                 productgrp = document.getElementById("<%=ddlProductGroup.ClientID%>").value;
             }

             var categorytyp = document.getElementById("<%=ddlCategoryType.ClientID%>").value;

             var division = 0;
             if (document.getElementById("<%=ddlDivisionSearch.ClientID%>").value != "--SELECT ALL DIVISION--") {
                   division = document.getElementById("<%=ddlDivisionSearch.ClientID%>").value;
             }
             var url = "gen_Item_List.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.Userid = strUserId;
             objData.ddlStatus = strddlStatus;
             objData.nature = nature;
             objData.productgrp = productgrp;
             objData.categorytyp = categorytyp;
             objData.division = division;
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

    <%--newd--%>

  <script>
      function PrintClick() {
          var orgID = '<%= Session["ORGID"] %>';
           var corptID = '<%= Session["CORPOFFICEID"] %>';
          var strUserId = '<%= Session["USERID"] %>';

          var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
          var sts = $("#cphMain_ddlStatus :selected").text();
          var nature = document.getElementById("<%=prnature.ClientID%>").value;
          var nat = $("#cphMain_prnature :selected").text();
          var productgrp = 0;
          if (document.getElementById("<%=ddlProductGroup.ClientID%>").value != "--SELECT PRODUCT GROUP--") {
              productgrp = document.getElementById("<%=ddlProductGroup.ClientID%>").value;
            var  grp = $("#cphMain_ddlProductGroup :selected").text();
             }

             var categorytyp = document.getElementById("<%=ddlCategoryType.ClientID%>").value;
          var cty = $("#cphMain_ddlCategoryType :selected").text();
          var division = 0;
          if (document.getElementById("<%=ddlDivisionSearch.ClientID%>").value != "--SELECT ALL DIVISION--") {
              division = document.getElementById("<%=ddlDivisionSearch.ClientID%>").value;
             var div = $("#cphMain_ddlDivisionSearch :selected").text();
             }
           if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
               $.ajax({
                   type: "POST",
                   async: false,
                   contentType: "application/json; charset=utf-8",
                   url: "gen_Item_List.aspx/PrintList",
                   data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",userid:"' + strUserId + '",status:"' + strddlStatus + '", nature:"' + nature + '",productgrp :"' + productgrp + '",categorytyp:"' + categorytyp + '",division:"' + division + '",grp:"'+grp+'",cty:"'+cty+'",div:"'+div+'",sts:"'+sts+'",nat:"'+nat+'"}',
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
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlProductGroup').selectToAutocomplete1Letter();

            $au('#cphMain_ddlCategoryType').selectToAutocomplete1Letter();

            $au('#cphMain_ddlDivisionSearch').selectToAutocomplete1Letter();

        });
    </script>
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
                $noCon("#cphMain_prnature").msDropdown({ roundedBorder: false });
            })
</script>

<script>
    $(document).ready(function (e) {
        $noCon("#cphMain_prnature").msDropdown({ visibleRows: 4 });
    });
    $(document).on('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        if (keyCode == 9) {
            $('.dd .ddChild').hide();
        }
    });
</script> 
</asp:Content>
