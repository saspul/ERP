<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_Job_Role_List.aspx.cs" Inherits="Master_gen_Job_Role_gen_Job_Role_List" %>

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
            // $au('#cphMain_ddlJobrole').selectToAutocomplete1Letter();
         });
         function AutoCo() {
             $au('#cphMain_ddlDesignation').selectToAutocomplete1Letter();
            // $au('#cphMain_ddlJobrole').selectToAutocomplete1Letter();
         }
    </script>    
    <script type="text/javascript">

        function SuccessConfirmation() {
            $("#success-alert").html("Job Role  inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Job Role  updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

        }

        function  SuccessCancelation() {
            $("#success-alert").html("Job Role  cancelled successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

        }


        function Successchng() {
            $("#success-alert").html("Job Role  Status Changed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });

        }

        function Error() {
            $("#divWarning").html("Some error occured!");
            $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }

        function alreadys() {
            $("#divWarning").html("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            $("#divWarning").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
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

            
               // var JobroleTypeText = JobroleType.options[JobroleType.selectedIndex].text;

                $("div#divDesg input.ui-autocomplete-input").css("borderColor", "");
                $("div#divJobr input.ui-autocomplete-input").css("borderColor", "");

             
              //  if (DesgTypeText == "--SELECT--") {

               //     document.getElementById("<%=ddlDesignation.ClientID%>").style.borderColor = "Red";
               //     document.getElementById("<%=ddlDesignation.ClientID%>").focus();

                //    $("div#divDesg input.ui-autocomplete-input").css("borderColor", "red");
                 //   $("div#divDesg input.ui-autocomplete-input").select();
                 //   $("div#divDesg input.ui-autocomplete-input").focus();

                   // ret = false;
               // }
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
    <asp:HiddenField ID="HiddenCancelReasonMust" runat="server" />
    

   <ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
    <li class="active">Job Role</li>
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
          <h1 class="h1_con">JOB ROLE</h1>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
          <div class="form-group fg2" id="divDesg">
              <label for="email" class="fg2_la1">Designation:<span class="spn1"></span></label>
               <asp:DropDownList ID="ddlDesignation" class="form-control fg2_inp1 inp_mst" runat="server"   ></asp:DropDownList>           
            </div>

        <div class="form-group fg2" id="divJobr">
              <label for="email" class="fg2_la1">Status:<span class="spn1">*</span></label>
              <asp:DropDownList ID="ddlSts"  class="form-control fg2_inp1 inp_mst" runat="server" >

                  <asp:ListItem Value="2">All</asp:ListItem>
                  <asp:ListItem Value="1">Active</asp:ListItem>
                  <asp:ListItem Value="0">Inactive</asp:ListItem>
              </asp:DropDownList>        
            </div>
           
                                 </ContentTemplate>
   </asp:UpdatePanel>


             <div class="fg7_5 sa_fg2">
            <label class="form1 mar_bo mar_tp">
              <span class="button-checkbox">
                <button type="button" class="btn-d" data-color="p"></button>
                <asp:CheckBox ID="cbxCnclStatus" Text="" class="hidden" runat="server" Checked="false" onclick="DisableEnter(event)" onkeydown="return DisableEnter(event)" />
              </span>
              <p class="pz_s">Show Deleted Entries</p>
            </label>
          </div>


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
    <a href="gen_Job_Role.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
  <i class="fa fa-plus-circle"></i>
</a>


       <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for delete</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>
                    <textarea id="txtCancelReason" placeholder="Write reason for delete" rows="6" class="text_ar1" onblur="RemoveTag('txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(txtCancelReason,450)" onkeyup="textCounter(txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnCancelRsnSave" onclick="return ValidateCancelReason();" class="btn btn-success" data-toggle="modal">SAVE</button>
                    <button type="button" id="btnCnclRsn" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>




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


         var strOrgId = '<%= Session["ORGID"] %>';
         var strCorpId = '<%= Session["CORPOFFICEID"] %>';
         var DsnContrl = '<%= Session["DSGN_CONTROL"] %>';
         var Usrid = '<%= Session["USERID"] %>';
         var DsgnTyp = '<%= Session["DSGN_TYPID"] %>';


         var strddlStatus = document.getElementById("<%=ddlSts.ClientID%>").value;


         var strCancelStatus = 0;
         if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                 strCancelStatus = 1;
             }

        // var Status = document.getElementById("<%=HiddenFieldSts.ClientID%>").value;
        // var CnclSts = document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value;
         var Divs = document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value;
         var DivsT = document.getElementById("<%=HiddenFieldDesignationT.ClientID%>").value;
      //   var Jobr = document.getElementById("<%=HiddenFieldJobrole.ClientID%>").value;
         ///  var JobrT = document.getElementById("<%=HiddenFieldJobroleT.ClientID%>").value;



         var objData = {};
         objData.OrgId = strOrgId;
         objData.CorpId = strCorpId;
         objData.ddlStatus = strddlStatus;
         objData.CancelStatus = strCancelStatus;
         objData.Usrid = Usrid;
         objData.DsnContrl = DsnContrl;
         objData.DsgnTyp = DsgnTyp;
         objData.Divs = Divs;







    
         if (strCorpId != "" && strCorpId != null && strOrgId != "" && strOrgId != null) {
             
                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "gen_Job_Role_List.aspx/PrintList",
                     data: JSON.stringify(objData),
                     dataType: 'json',
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
             document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value = document.getElementById("<%=ddlDesignation.ClientID%>").value;
             document.getElementById("<%=HiddenFieldDesignationT.ClientID%>").value = $("#cphMain_ddlDesignation option:selected").text();
           
             //document.getElementById("<%=HiddenFieldJobroleT.ClientID%>").value = $("#cphMain_ddlJobrole option:selected").text();

             Load_dt();
             getdata(1);
             $("div#divDesg input.ui-autocomplete-input").select();
             $("div#divDesg input.ui-autocomplete-input").focus();
         });

         function LoadList() {
             document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value = document.getElementById("<%=ddlDesignation.ClientID%>").value;
             document.getElementById("<%=HiddenFieldDesignationT.ClientID%>").value = $("#cphMain_ddlDesignation option:selected").text();
         
            // document.getElementById("<%=HiddenFieldJobroleT.ClientID%>").value = $("#cphMain_ddlJobrole option:selected").text();
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

             var url = "gen_Job_Role_List.aspx/LoadStaticDatafordt";
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
             var DsnContrl = '<%= Session["DSGN_CONTROL"] %>';
             var Usrid = '<%= Session["USERID"] %>';
             var DsgnTyp = '<%= Session["DSGN_TYPID"] %>';

             


             var strddlStatus = document.getElementById("<%=ddlSts.ClientID%>").value;


             var strCancelStatus = 0;
             if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                 strCancelStatus = 1;
             }
             var strEnableModify = document.getElementById("<%=HiddenFieldUpdRole.ClientID%>").value;
             var strEnableCancel = document.getElementById("<%=HiddenFieldCnclRole.ClientID%>").value;
             var url = "gen_Job_Role_List.aspx/GetData";
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
             objData.DsnContrl = DsnContrl;
             objData.Usrid = Usrid;
             objData.DsgnTyp = DsgnTyp;
             objData.OrderMethod = intOrderByStatus;
             objData.strInputColumnSearch = strInputColumnSearch;
             objData.Divs = document.getElementById("<%=HiddenFieldDesignation.ClientID%>").value;
             //objData.Jobr = document.getElementById("<%=HiddenFieldJobrole.ClientID%>").value;
             $.ajax({

                 type: 'POST',
                 data: JSON.stringify(objData),
                 dataType: 'json',
                 contentType: "application/json; charset=utf-8",
                 url: url,
                 success: function (result) {
                     document.getElementById("divPagingTable_processing").style.display = "none";
                     $('#tblPagingTable tbody').html(result.d[0]);
                     $("#cphMain_divReport").html(result.d[2]);//datatable

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





         function OpenCancelView(StrId) {



             // alert("b");


             ezBSAlert({
                 type: "confirm",
                 messageText: "Do you want to cancel this Job Role ?",
                 alertType: "info"

             }).done(function (e) {
                 if (e == true) {
                     var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
                 document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                 var strCancelReason = "";
                 if (strCancelMust == 1) {
                     //cancl rsn must

                     document.getElementById("lblErrMsgCancelReason").style.display = "none";

                     document.getElementById("txtCancelReason").style.borderColor = "";
                     document.getElementById("txtCancelReason").value = "";
                     $('#dialog_simple').modal('show');
                     $('#dialog_simple').on('shown.bs.modal', function () {
                         document.getElementById("txtCancelReason").focus();
                     });

                 }
                 else {
                     DeleteByID(StrId, strCancelReason, strCancelMust);
                     $('#dialog_simple').modal('hide');
                 }
                 return false;

             }
             else {
                 return false;
             }
         });
         return false;

         }


         function ValidateCancelReason() {
             var ret = true;
             document.getElementById("lblErrMsgCancelReason").style.display = "none";
             document.getElementById("txtCancelReason").style.borderColor = "";

             var strCancelReason = document.getElementById("txtCancelReason").value;
             if (strCancelReason == "") {
                 document.getElementById("txtCancelReason").style.borderColor = "red";
                 document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
                 document.getElementById("lblErrMsgCancelReason").style.display = "";
                 $("div.war").fadeIn(200).delay(500).fadeOut(400);
                 return ret;
             }
             else {
                 strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
                 strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
                 strCancelReason = strCancelReason.replace(/\n /, "\n");
                 if (strCancelReason.length < "10") {
                     document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                     document.getElementById("txtCancelReason").style.borderColor = "red";
                     document.getElementById("lblErrMsgCancelReason").style.display = "";
                     $("div.war").fadeIn(200).delay(500).fadeOut(400);
                     return ret;
                 }
                 else {

                 }
             }
             if (ret == true) {
                 var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
             var strCancelMust = document.getElementById("<%=HiddenCancelReasonMust.ClientID%>").value;
             DeleteByID(strId, strCancelReason, strCancelMust);
             $('#dialog_simple').modal('hide');
         }

         return false;

     }



     function DeleteByID(strId, strCancelReason, strCancelMust) {
         var strUserID = '<%=Session["USERID"]%>';
         var strOrgIdID = '<%=Session["ORGID"]%>';
         var strCorpID = '<%=Session["CORPOFFICEID"]%>';

         if (strId != "" && strUserID != '') {
             var Details = PageMethods.CancelReason(strId, strCancelMust, strUserID, strCancelReason, strOrgIdID, strCorpID, function (response) {

                 var SucessDetails = response;
                 if (SucessDetails == "successcncl") {

                     // window.location = 'Payroll_Structure_List.aspx?InsUpd=Cncl';
                     getdata(1);

                     SuccessCancelation();
                 }
                 else {
                     Error();
                 }
             });
         }

         return false;
     }


         function ChangeStatus(strId, Status) {

             //  alert("B");
             ezBSAlert({
                 type: "confirm",
                 messageText: "Do you want to change the status of the Job Role?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     if (strId != "") {
                         var Details = PageMethods.ChangeStatus(strId, Status, function (response) {

                             var SucessDetails = response;
                             if (SucessDetails == "successchng") {

                                 //     window.location = 'Payroll_Structure_List.aspx?InsUpd=Sts';
                                 getdata(1);

                                 Successchng();
                             }
                             else {
                                 Error();
                             }
                         });
                     }
                     return false;

                 }
                 return false;

             });
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
</asp:Content>

