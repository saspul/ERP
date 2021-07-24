<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_ProjectsList.aspx.cs" Inherits="Master_gen_Projects_gen_ProjectsList" %>

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
     <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
 <script src="/js/New js/msdropdown/jquery.dd.js"></script>
 <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script>
        var $au = jQuery.noConflict();
        $au(function () {
            $au('#cphMain_ddlDivision').selectToAutocomplete1Letter();
        });
    </script>        
    <script type="text/javascript">
        function SuccessConfirmation() {
            $("#success-alert").html("Project details inserted successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdation() {
            $("#success-alert").html("Project details updated successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function SuccessCancelation() {
            $("#success-alert").html("Project cancelled successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
        }
        function DuplicationName() {
            $("#divWarning").html("Re-Calling denied!. Project name can’t be duplicated.");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessRecall() {
            $("#success-alert").html("Project recalled successfully.");
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
        </script>
    <script>

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
        function SearchValidation() {
            ret = true;
            document.getElementById("<%=ddlMode.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
            $("div#divUnit input.ui-autocomplete-input").css("borderColor", "");
            var ddlDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;
            if (ddlDivision == '--SELECT DIVISION--') {
                document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                $("div#divUnit input.ui-autocomplete-input").css("borderColor", "red");
                $("div#divUnit input.ui-autocomplete-input").select();
                $("div#divUnit input.ui-autocomplete-input").focus();
                ret= false;
              }
              var ddlMode = document.getElementById("<%=ddlMode.ClientID%>").value;
              var searchStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
              var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");
              var cbx = 0;
              if (cbxStatus.checked) {
                  cbx = 1;
              }
              else {
                  cbx = 0;
              }
              if (ret == true) {
                  document.getElementById("<%=HiddenSearchField.ClientID%>").value = searchStatus + ',' + cbx + ',' + ddlDivision + ',' + ddlMode;
                  LoadList();
              }
              return false;

        }
        function CancelNotPossible() {
            $("#divWarning").html("Sorry, Cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function OpenCancelView(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to cancel this project?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var strCancelMust = document.getElementById("<%=HiddenFieldCancelReasMust.ClientID%>").value;
                    document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = StrId;
                    var strCancelReason = "";
                    if (strCancelMust == 1) {
                        document.getElementById("cphMain_txtCancelReason").style.borderColor = "";
                        document.getElementById("cphMain_txtCancelReason").value = "";
                        $('#dialog_simple').modal('show');
                    }
                    else {
                        ReOpenConfByID(StrId, 0, strCancelReason, strCancelMust);
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
        function ReOpenConfByID(StrId, Mode, reasonmust, cnclRsn) {
            //mode(0-Delete,1-confirm,3-reopen)
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userID = '<%= Session["USERID"] %>';
            var MasterDbId = StrId;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_ProjectsList.aspx/ReOpenConfByID",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",userID: "' + userID + '",MasterDbId: "' + MasterDbId + '",Mode: "' + Mode + '",reasonmust: "' + reasonmust + '",cnclRsn: "' + cnclRsn + '"}',
                dataType: "json",
                success: function (data) {
                    window.location.href = "gen_ProjectsList.aspx?InsUpd=" + data.d;
                }
            });
            return false;
        }
        function ReCallAlert(StrId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to recall this project?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    ReOpenConfByID(StrId, 1, null, null);
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;
        }
        function SuccessSts() {
            $("#success-alert").html("Project status changed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AlreadySts() {
            $("#divWarning").html("Sorry, This project status is already changed!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function ErrorCancelation() {
            $("#divWarning").html("Some error occurred.Try again!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AlreadyCncl() {
            $("#divWarning").html("Sorry, This entry is already cancelled!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        function AlreadyRecl() {
            $("#divWarning").html("Sorry, recalling denied. This entry is already recalled!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            return false;
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
   </asp:ScriptManager>
   <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
   <asp:HiddenField ID="HiddenFieldCancelReasMust" runat="server" Value="0"/>
   <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
   <asp:HiddenField ID="HiddenFieldUpdRole" runat="server" />
   <asp:HiddenField ID="HiddenFieldCnclRole" runat="server" />
     <asp:HiddenField ID="HiddenFieldReclRole" runat="server" />
   <asp:HiddenField ID="hiddenSearch" runat="server" />
   <asp:HiddenField ID="HiddenFieldSts" runat="server" />
   <asp:HiddenField ID="HiddenFieldCnclSts" runat="server" />
   <asp:HiddenField ID="HiddenFieldDivision" runat="server" />
   <asp:HiddenField ID="HiddenFieldTypeText" runat="server" /> 
   <asp:HiddenField ID="HiddenSearchField" runat="server" />
   <asp:HiddenField ID="hiddenRsnid" runat="server" />
   <asp:HiddenField ID="HiddenFieldMode" runat="server" />
   <asp:HiddenField ID="HiddenFieldModeText" runat="server" />
    
    <ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
    <li class="active">Project Master</li>
  </ol>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
       
  <div class="content_sec2 cont_contr">
		<div class="content_area_container cont_contr">	
      <div class="content_box1 cont_contr">
        <h1 class="h1_con">PROJECT MASTER</h1>

        <div class="form-group fg2 sa_fg4" id="divUnit">
          <label for="email" class="fg2_la1">Division:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlDivision" class="form-control fg2_inp1 inp_mst" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group fg2 sa_fg4 fg_m_10 sa_480">
          <label for="email" class="fg2_la1">Mode:<span class="spn1">*</span></label>
          <select  id="ddlMode" class="form-control fg2_inp1 inp_mst" runat="server">
            <option value='102' data-image="\Images\opp\bid_b.png" data-imagecss="flag ad" data-title="Main Category" selected="">Bidding</option>
            <option value='101' data-image="\Images\opp\awd_b.png" data-imagecss="flag ae" data-title="Sub Category">Awarded</option>
            <option value='0' data-image="\Images\opp\bth_b.png" data-imagecss="flag af" data-title="Small Category">Both</option>
          </select>  
        </div>

        <div class="form-group fg7 sa_fg4">
          <label for="email" class="fg2_la1">Status:<span class="spn1">*</span></label>
          <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 inp_mst" runat="server">
                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                </asp:DropDownList>          
        </div>

        <div class="fg7 sa_fg4">
          <label class="form1 mar_bo mar_tp lb_wa">
            <span class="button-checkbox">
              <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
              <input type="checkbox" class="hidden" id="cbxCnclStatus" runat="server"/>
            </span>
            <p class="pz_s">Show Deleted Entries</p>
          </label>
        </div>

        <div class="fg8">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
          <button class="submit_ser" onclick="return SearchValidation();"></button>
          <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->
        </div>

        <div class="clearfix"></div>
        <div class="devider"></div>

     <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_900"></div>
      
    </div>



  </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
<!-------working area_closed---->

  <div class="modal fade" id="dialog_simple" tabindex="-1" data-backdrop="static"    role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog mod1" role="document" id="divCancelPopUp">
            <div class="modal-content">
                <div class="modal-header mo_hd1">
                    <h5 class="modal-title" id="H1">Reason for cancel</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div id="lblErrMsgCancelReason" class="al-box war">Warning Alert !!!</div>

                    <textarea id="txtCancelReason" runat="server" placeholder="Write reason for cancel" rows="6" class="text_ar1" onblur="RemoveTag('cphMain_txtCancelReason')" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCancelReason,450)" onkeyup="textCounter(cphMain_txtCancelReason,450)" style="resize: none;"></textarea>
                </div>
                <div class="modal-footer">

                   <asp:Button ID="btnRsnSave" Text="Save" class="btn btn-success" runat="server"  OnClientClick="return ValidateCancelReason();"/>                   
                   <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>

                   
                </div>
            </div>
        </div>
    </div>
 <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
    <a href="gen_Projects.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
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
        .fg2 {
    padding-right: 0px;
}
    </style>
 <script>
     //for search option
     var $NoConfi = jQuery.noConflict();
     var $NoConfi3 = jQuery.noConflict();
     function ValidateCancelReason() {
         // replacing < and > tags
         var ret = true;
         document.getElementById("lblErrMsgCancelReason").style.display = "none";
         document.getElementById("cphMain_txtCancelReason").style.borderColor = "";
         var strCancelReason = document.getElementById("cphMain_txtCancelReason").value;
         if (strCancelReason == "") {
             document.getElementById("cphMain_txtCancelReason").style.borderColor = "red";
             document.getElementById("lblErrMsgCancelReason").innerHTML = " Please fill this out";
             document.getElementById("lblErrMsgCancelReason").style.display = "";
             $("div.war").fadeIn(200).delay(500).fadeOut(400);
             return false;
         }
         else {
             strCancelReason = strCancelReason.replace(/(^\s*)|(\s*$)/gi, "");
             strCancelReason = strCancelReason.replace(/[ ]{2,}/gi, " ");
             strCancelReason = strCancelReason.replace(/\n /, "\n");
             if (strCancelReason.length < "10") {
                 document.getElementById("lblErrMsgCancelReason").innerHTML = " Cancel reason should be minimum 10 characters";
                 document.getElementById("cphMain_txtCancelReason").style.borderColor = "red";
                 document.getElementById("lblErrMsgCancelReason").style.display = "";
                 $("div.war").fadeIn(200).delay(500).fadeOut(400);
                 return false;
             }
         }
         var strId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
         var strCancelMust = document.getElementById("<%=HiddenFieldCancelReasMust.ClientID%>").value;
         ReOpenConfByID(strId, 0, strCancelReason, strCancelMust);
         $('#dialog_simple').modal('hide');
         return false;
     }
     //EVM-0024
     function CloseCancelView() {
         ezBSAlert({
             type: "confirm",
             messageText: "Do you want to close  without completing cancellation process?",
             alertType: "info"
         }).done(function (e) {
             if (e == true) {
                 $('#dialog_simple').modal('hide');
                 document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
             }
             else {
                 $('#dialog_simple').modal('show');
                 return false;
             }
         });
         return false;
     }
     //END

     function ChangeStatus(StrId, stsmode, cnclusrId) {
         if (cnclusrId == "0") {
             ezBSAlert({
                 type: "confirm",
                 messageText: "Do you want to change the status of this project?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var usrId = '<%= Session["USERID"] %>';
                     var corptID = '<%= Session["CORPOFFICEID"] %>';
                     var Details = PageMethods.ChangeStatus(StrId, stsmode, usrId, corptID, function (response) {
                         var SucessDetails = response;
                         if (SucessDetails == "success") {
                             window.location = 'gen_ProjectsList.aspx?InsUpd=StsCh';
                         }
                         else if (SucessDetails == "AlCncl") {
                             window.location = 'gen_ProjectsList.aspx?InsUpd=AlCncl';
                         }
                         else if (SucessDetails == "AlSts") {
                             window.location = 'gen_ProjectsList.aspx?InsUpd=AlSts';
                         }
                         else {
                             window.location = 'gen_ProjectsList.aspx?InsUpd=Error';
                         }
                     });
                 }
             });
             return false;
         }
         return false;
     }


     function PrintClick() {
         var orgID = '<%= Session["ORGID"] %>';
         var corptID = '<%= Session["CORPOFFICEID"] %>';
         var Status = document.getElementById("<%=HiddenFieldSts.ClientID%>").value;
         var CnclSts = document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value;
         var Divs = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
         var divText = document.getElementById("<%=HiddenFieldTypeText.ClientID%>").value;
         var Mode = document.getElementById("<%=HiddenFieldMode.ClientID%>").value;
         var modeText = document.getElementById("<%=HiddenFieldModeText.ClientID%>").value;
         var userId = '<%= Session["USERID"] %>';
         if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
             $.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "gen_ProjectsList.aspx/PrintList",
                 data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Status: "' + Status + '",CnclSts: "' + CnclSts + '",Divs: "' + Divs + '",divText: "' + divText + '",Mode: "' + Mode + '",modeText: "' + modeText + '",userId: "' + userId + '"}',
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
     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
             var strCancelStatus = 0;
             if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                 strCancelStatus = 1;
             }
             document.getElementById("<%=HiddenFieldSts.ClientID%>").value = strddlStatus;
             document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value = strCancelStatus;
             document.getElementById("<%=HiddenFieldDivision.ClientID%>").value = document.getElementById("<%=ddlDivision.ClientID%>").value;
             document.getElementById("<%=HiddenFieldTypeText.ClientID%>").value = $("#cphMain_ddlDivision option:selected").text();
             document.getElementById("<%=HiddenFieldMode.ClientID%>").value = document.getElementById("<%=ddlMode.ClientID%>").value;
             document.getElementById("<%=HiddenFieldModeText.ClientID%>").value = $("#cphMain_ddlMode option:selected").text();

             Load_dt();
             getdata(1);
             $("div#divUnit input.ui-autocomplete-input").select();
             $("div#divUnit input.ui-autocomplete-input").focus();
         });

         function LoadList() {
             var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
             var strCancelStatus = 0;
             if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                 strCancelStatus = 1;
             }
             document.getElementById("<%=HiddenFieldSts.ClientID%>").value = strddlStatus;
             document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value = strCancelStatus;
             document.getElementById("<%=HiddenFieldDivision.ClientID%>").value = document.getElementById("<%=ddlDivision.ClientID%>").value;
             document.getElementById("<%=HiddenFieldTypeText.ClientID%>").value = $("#cphMain_ddlDivision option:selected").text();
             document.getElementById("<%=HiddenFieldMode.ClientID%>").value = document.getElementById("<%=ddlMode.ClientID%>").value;
             document.getElementById("<%=HiddenFieldModeText.ClientID%>").value = $("#cphMain_ddlMode option:selected").text();
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
             strPagingTable += '<div class="r_900"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_900" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "gen_ProjectsList.aspx/LoadStaticDatafordt";
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
             var url = "gen_ProjectsList.aspx/GetData";
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
             objData.Divs = document.getElementById("<%=HiddenFieldDivision.ClientID%>").value;
             objData.Mode = document.getElementById("<%=HiddenFieldMode.ClientID%>").value;
             objData.Recall = document.getElementById("<%=HiddenFieldReclRole.ClientID%>").value;
             objData.userId = '<%= Session["USERID"] %>';
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
      <script>
          $(document).ready(function () {
              var $aus = jQuery.noConflict();
              $aus("#cphMain_ddlMode").msDropdown({ roundedBorder: false });
              $aus("#cphMain_ddlMode").msDropdown({ visibleRows: 4 });
              $aus("").msDropdown();
              $("div#divUnit input.ui-autocomplete-input").select();
              $("div#divUnit input.ui-autocomplete-input").focus();
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
                 .flag {
    padding: 0 !important;
    margin: 0 5px 0 0;
}
    </style>           
</asp:Content>