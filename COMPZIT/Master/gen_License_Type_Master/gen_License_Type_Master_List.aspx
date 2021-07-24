<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit.master" CodeFile="gen_License_Type_Master_List.aspx.cs" Inherits="Master_gen_License_Type_Master_gen_License_Type_Master_List" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script> 
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
          <script type="text/javascript">
              function SuccessConfirmation() {
                  $("#success-alert").html("License details inserted successfully.");
                  $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                  });
              }
              function SuccessUpdation() {
                  $("#success-alert").html("License details updated successfully.");
                  $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                  });
              }
              function SuccessCancelation() {
                  $("#success-alert").html("License Type cancelled successfully.");
                  $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
                  });
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
                      messageText: "Do you want to cancel this License Type?",
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
                url: "gen_License_Type_Master_List.aspx/ReOpenConfByID",
                data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",userID: "' + userID + '",MasterDbId: "' + MasterDbId + '",Mode: "' + Mode + '",reasonmust: "' + reasonmust + '",cnclRsn: "' + cnclRsn + '"}',
                dataType: "json",
                success: function (data) {
                    window.location.href = "gen_License_Type_Master_List.aspx?InsUpd=" + data.d;
                }
            });
            return false;
        }
        function SuccessSts() {
            $("#success-alert").html("License status changed successfully.");
            $("#success-alert").fadeTo(2000, 500).slideUp(500, function () {
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
        function AlreadySts() {
            $("#divWarning").html("Sorry, This License status is already changed!");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
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
         

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
  </asp:ScriptManager>
        <asp:HiddenField ID="HiddenFieldCancelReasMust" runat="server" Value="0"/>
 <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
       <asp:HiddenField ID="hiddenSearchField" runat="server" />
     <asp:HiddenField ID="HiddenFieldSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldCnclSts" runat="server" />
     <asp:HiddenField ID="hiddenRsnid" runat="server" />
  



    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>

            <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
       <asp:HiddenField ID="HiddenFieldUpdRole" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCnclRole" runat="server" Value="0" />
 <ol class="breadcrumb">
 <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
        <li><a href="/Home/Compzit_Home/Compzit_Home_Hcm.aspx">HCM</a></li>
     
      <li class="active">License Type</li>
    </ol>
<!---breadcrumb_section_started----> 
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>

    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
    <div class="content_sec2 cont_contr">
      <div class="content_area_container cont_contr"> 
        <div class="content_box1 cont_contr">
<!---frame_border_area_opened---->

<!---inner_content_sections area_started--->
          <h1 class="h1_con">License Type</h1>

          <div class="form-group fg2">
              <label for="email" class="fg2_la1">Status:<span class="spn1">*</span></label>
                <asp:DropDownList ID="ddlStatus" class="form-control fg2_inp1 inp_mst" runat="server" >
                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                     <asp:ListItem Text="All" Value="2"></asp:ListItem>
                </asp:DropDownList>
                      
            </div>
            <div class="fg7_5 sa_fg4">
              <label class="form1 mar_bo mar_tp lb_wa">
                <span class="button-checkbox">
                  <button type="button" class="btn-d" data-color="p" onclick="myFunct()" ng-model="all"></button>
                  <input type="checkbox" class="hidden" id="cbxCnclStatus" runat="server"/>
                </span>
                <p class="pz_s">Show Deleted Entries</p>
              </label>
            </div>

            <div class="fg2">
              <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
 <asp:Button ID="Button1" class="submit_ser" runat="server"  OnClientClick="return LoadList();" />
              <button"></button>
              <!-- <button class="btn tab_but1 butn5"><i class="fa fa-search"></i> Search</button>   -->
            </div>
<!---=================section_devider============--->
      <div class="clearfix"></div>
      <div class="devider"></div>
<!---=================section_devider============--->
            
             <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_800"></div>
             </div><!--content_container_closed------>

<!----frame_closed section to footer script section--->
</div>
</div>

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

                   <asp:Button ID="Button2" Text="Save" class="btn btn-success" runat="server"  OnClientClick="return ValidateCancelReason();"/>                   
                   <button type="button" id="btnCnclRsn" onclick="return CloseCancelView();" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                    
                   
                </div>
            </div>
        </div>
    </div>



 <a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
    <a href="gen_License_Type_Master.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
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

       
          
 
<!----------------------------------------------Content_section_opened------------------------------------------------------------->
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
             var orgID = '<%= Session["ORGID"] %>';
             var corptID = '<%= Session["CORPOFFICEID"] %>';
             ezBSAlert({
                 type: "confirm",
                 messageText: "Do you want to change the status of this License Status?",
                 alertType: "info"
             }).done(function (e) {
                 if (e == true) {
                     var usrId = '<%= Session["USERID"] %>';

                     var Details = PageMethods.ChangeStatus(StrId, stsmode, usrId, orgID, corptID, function (response) {
                         var SucessDetails = response;
                         if (SucessDetails == "success") {
                             window.location = 'gen_License_Type_Master_List.aspx?InsUpd=StsCh';
                         }
                         else if (SucessDetails == "AlCncl") {
                             window.location = 'gen_License_Type_Master_List.aspx?InsUpd=AlCncl';
                         }
                         else if (SucessDetails == "AlSts") {
                             window.location = 'gen_License_Type_Master_List.aspx?InsUpd=AlSts';
                         }
                         else {
                             window.location = 'gen_License_Type_Master_List.aspx?InsUpd=Error';
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
         if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
             $.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "gen_License_Type_Master_List.aspx/PrintList",
                 data: '{orgID: "' + orgID + '",corptID: "' + corptID + '",Status: "' + Status + '",CnclSts: "' + CnclSts + '"}',
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
             Load_dt();
             getdata(1);
         });

         function LoadList() {
             var strddlStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
             var strCancelStatus = 0;
             if (document.getElementById("<%=cbxCnclStatus.ClientID%>").checked == true) {
                 strCancelStatus = 1;
             }
             document.getElementById("<%=HiddenFieldSts.ClientID%>").value = strddlStatus;
             document.getElementById("<%=HiddenFieldCnclSts.ClientID%>").value = strCancelStatus;
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
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "gen_License_Type_Master_List.aspx/LoadStaticDatafordt";
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
             var url = "gen_License_Type_Master_List.aspx/GetData";
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

    <!----new---->

    <%--<div class="cont_rght">

            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/Water-Card-Master.png" style="vertical-align: middle;"  />   <asp:Label ID="lblEntry" runat="server">License Type</asp:Label>
            </div>--%>
   <%--0006 start--%>
     <%--   <div class="eachform" style="width: 22%;margin-top: 2%;">

                <h2 style="margin-top:1%;">Status*</h2>

                <asp:DropDownList ID="ddlStatus" Height="30px" Width="160px" class="form1" runat="server" Style="margin-left: 15%;">
                   <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>
                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                   
                </asp:DropDownList>


            </div>

            <div class="eachform" style="width:21%; margin-bottom: 1.2%;margin-left: 0%;">               
                <div class="subform" style="width:89%;">


                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" Checked="false" class="form2" onkeypress="return DisableEnter(event)"/>
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>
                </div>
          <div style="width: 44%; margin-top: 2.2%; " class="eachform">
            <asp:Button ID="btnSearch" style="margin-top:-0.4%; cursor:pointer; width: 104px;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click" OnClientClick="return SearchValidation();"/>

        </div>--%>
                
        <%--stop 0006--%>

       <%-- <br />

        <div onclick="location.href='gen_License_Type_Master.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;">--%>

           <%-- <a href="gen_Product_Category.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        <%--</div>--%>
         <asp:HiddenField ID="hiddenNext" runat="server" />
        <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenMemorySize" runat="server" />
         <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
         <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
         <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
        <asp:HiddenField ID="hiddenRoleRecall" runat="server" />
        <asp:HiddenField ID="hiddenCommodityValue" runat="server" />
        <%--  <br />
        <br />--%>
   <%--     <div id="divReport" class="table-responsive" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>--%>
                  
                <%--------------------------------View for error Reason--------------------------%>
            <%--<div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">License Type</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>--%>   


     <%--<div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>--%>

    <%--</div>--%>
</asp:Content>

