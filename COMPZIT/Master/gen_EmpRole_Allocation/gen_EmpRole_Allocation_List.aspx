<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_EmpRole_Allocation_List.aspx.cs" Inherits="Master_gen_EmpRole_Allocation_gen_EmpRole_Allocation_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
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
     <script>
         var $au = jQuery.noConflict();
         $au(function () {
             $au('#cphMain_ddlDesignation').selectToAutocomplete1Letter();
             $au('#cphMain_ddlJobrole').selectToAutocomplete1Letter();
         });
         function AutoCo() {
             $au('#cphMain_ddlDesignation').selectToAutocomplete1Letter();
             $au('#cphMain_ddlJobrole').selectToAutocomplete1Letter();
         }
    </script>    
    <script type="text/javascript">

            function SuccessConfirmation() {
                $("#success-alert").html("Employee role allocation inserted successfully.");
                $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                });
            }
            function SuccessUpdation() {
                $("#success-alert").html("Employee role allocation updated successfully.");
                $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                }); 

            }          
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

            //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
            function textCounter(field, maxlimit) {
                if (field.value.length > maxlimit) {
                    field.value = field.value.substring(0, maxlimit);
                } else {

                }
            }
            // for not allowing enter
            function DisableEnter(evt) {

                evt = (evt) ? evt : window.event;
                var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                if (keyCodes == 13) {
                    return false;
                }
            }
    </script>
 
        <script>
            function Validate() {
                var ret = true;
               
                var DesgType = document.getElementById("<%=ddlDesignation.ClientID%>");
                var DesgTypeText = DesgType.options[DesgType.selectedIndex].text;

                var JobroleType = document.getElementById("<%=ddlJobrole.ClientID%>");
                var JobroleTypeText = JobroleType.options[JobroleType.selectedIndex].text;
               
                $("div#divDesg input.ui-autocomplete-input").css("borderColor", "");
                $("div#divJobr input.ui-autocomplete-input").css("borderColor", "");

                if (JobroleTypeText == "--Select Job Role--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                     document.getElementById("<%=ddlJobrole.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlJobrole.ClientID%>").focus();

                    $("div#divJobr input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divJobr input.ui-autocomplete-input").select();
                    $("div#divJobr input.ui-autocomplete-input").focus();

                     ret = false;
                 }

                if (DesgTypeText == "--SELECT--") {
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlDesignation.ClientID%>").focus();

                    $("div#divDesg input.ui-autocomplete-input").css("borderColor", "red");
                    $("div#divDesg input.ui-autocomplete-input").select();
                    $("div#divDesg input.ui-autocomplete-input").focus();

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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
   </asp:ScriptManager>
   <asp:HiddenField ID="HiddenFieldCancelReasMust" runat="server" Value="0"/>
   <asp:HiddenField ID="HiddenFieldUpdRole" runat="server" />
   <asp:HiddenField ID="HiddenFieldCnclRole" runat="server" />
   <asp:HiddenField ID="hiddenSearch" runat="server" />
   <asp:HiddenField ID="HiddenFieldSts" runat="server" />
   <asp:HiddenField ID="HiddenFieldCnclSts" runat="server" />
   <asp:HiddenField ID="HiddenFieldDesignation" runat="server" />
   <asp:HiddenField ID="HiddenFieldDesignationT" runat="server" /> 
   <asp:HiddenField ID="HiddenFieldJobrole" runat="server" />
   <asp:HiddenField ID="HiddenFieldJobroleT" runat="server" /> 
   <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />
   <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
   <asp:HiddenField ID="hiddenSearchField" runat="server" />
   <ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
    <li class="active">Employee role allocation</li>
  </ol>
 <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">Employee role allocation</h1>
             <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>--%>
          <div class="form-group fg2" id="divDesg">
              <label for="email" class="fg2_la1">Designation:<span class="spn1">*</span></label>
               <asp:DropDownList ID="ddlDesignation" class="form-control fg2_inp1 inp_mst" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged"></asp:DropDownList>           
            </div>

        <div class="form-group fg2" id="divJobr">
              <label for="email" class="fg2_la1">Job Role:<span class="spn1">*</span></label>
              <asp:DropDownList ID="ddlJobrole"  class="form-control fg2_inp1 inp_mst" runat="server" >
                    <asp:ListItem Text="--Select Job Role--" Value="1"></asp:ListItem>
                </asp:DropDownList>        
            </div>
           
                              <%--   </ContentTemplate>
   </asp:UpdatePanel>--%>
          <div class="fg2">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
              <button class="submit_ser" onclick="return Validate();"></button>
              <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->
            </div>
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->

        
           <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_640"></div>
       

        </div>


<!---inner_content_sections area_closed--->

<!---frame_border_area_closed---->
        </div>
      </div>

 <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
    <a href="gen_EmpRole_Allocation.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
  <i class="fa fa-plus-circle"></i>
</a>
<style>
        #cphMain_myBtn{
            position: fixed;
            top: 252px;
            right: 2px;
            z-index: 99;
            font-size: 28px;
            border: none;
            outline: none;
            background-color: #48acf2;
            color: #fff;
            cursor: pointer;
            padding: 0px;
            padding-top: 0px;
            border-radius: 4px;
            border-radius: 37px;
            width: 55px;
            height: 40px;
            text-align: center;
            transition-delay: 0.1s;
            padding-top: 0px;
        }
    </style>
 <script>
     function PrintClick() {
         var orgID = '<%= Session["ORGID"] %>';
         var corptID = '<%= Session["CORPOFFICEID"] %>';
         var Status = document.getElementById("<%=HiddenFieldSts.ClientID%>").value;
         var CnclSts = document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value;
         var Divs = document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value;
         var DivsT = document.getElementById("<%=HiddenFieldDesignationT.ClientID%>").value;
         var Jobr = document.getElementById("<%=HiddenFieldJobrole.ClientID%>").value;
         var JobrT = document.getElementById("<%=HiddenFieldJobroleT.ClientID%>").value;
         if (corptID != "" && corptID != null && orgID != "" && orgID != null ) {
             if (Jobr != "--Select Job Role--" && Divs != "--SELECT--") {
                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "gen_EmpRole_Allocation_List.aspx/PrintList",
                     data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Status: "' + Status + '",CnclSts: "' + CnclSts + '",Divs: "' + Divs + '",DivsT: "' + DivsT + '",Jobr: "' + Jobr + '",JobrT: "' + JobrT + '"}',
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
 </script>
     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value = document.getElementById("<%=ddlDesignation.ClientID%>").value;
             document.getElementById("<%=HiddenFieldDesignationT.ClientID%>").value = $("#cphMain_ddlDesignation option:selected").text();
             document.getElementById("<%=HiddenFieldJobrole.ClientID%>").value = document.getElementById("<%=ddlJobrole.ClientID%>").value;
             document.getElementById("<%=HiddenFieldJobroleT.ClientID%>").value = $("#cphMain_ddlJobrole option:selected").text();

             Load_dt();
             getdata(1);
             $("div#divDesg input.ui-autocomplete-input").select();
             $("div#divDesg input.ui-autocomplete-input").focus();
         });

         function LoadList() {
             document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value = document.getElementById("<%=ddlDesignation.ClientID%>").value;
             document.getElementById("<%=HiddenFieldDesignationT.ClientID%>").value = $("#cphMain_ddlDesignation option:selected").text();
             document.getElementById("<%=HiddenFieldJobrole.ClientID%>").value = document.getElementById("<%=ddlJobrole.ClientID%>").value;
             document.getElementById("<%=HiddenFieldJobroleT.ClientID%>").value = $("#cphMain_ddlJobrole option:selected").text();
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
             strPagingTable += '<div class="r_640"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_640" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "gen_EmpRole_Allocation_List.aspx/LoadStaticDatafordt";
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
             var strddlStatus = document.getElementById("<%=HiddenFieldSts.ClientID%>").value;
             var strCancelStatus = document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value;
             var strEnableModify = document.getElementById("<%=HiddenFieldUpdRole.ClientID%>").value;
             var strEnableCancel = document.getElementById("<%=HiddenFieldCnclRole.ClientID%>").value;
             var url = "gen_EmpRole_Allocation_List.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.ddlStatus = strddlStatus;
             objData.CancelStatus = strCancelStatus;
             objData.EnableModify = strEnableModify;
             objData.EnableCancel = strEnableCancel;
             objData.PageNumber = strPageNumber;
             objData.PageMaxSize = strPageSize;
             objData.strCommonSearchTerm = strCommonSearchString;
             objData.OrderColumn = intOrderByColumn;
             objData.OrderMethod = intOrderByStatus;
             objData.strInputColumnSearch = strInputColumnSearch;
             objData.Divs = document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value;
             objData.Jobr = document.getElementById("<%=HiddenFieldJobrole.ClientID%>").value;
             $.ajax({

                 type: 'POST',
                 data: JSON.stringify(objData),
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     document.getElementById("divPagingTable_processing").style.display = "none";
                     $('#tblPagingTable tbody').html(result.d[0]);
                     $("#cphMain_divReport").html(result.d[1]);//datatable

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
                    background-color: #08c;
                    color: #fff;
                    font-family: Calibri;
                }
    </style>   
</asp:Content>

