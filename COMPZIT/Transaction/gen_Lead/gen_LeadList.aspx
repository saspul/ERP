<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_LeadList.aspx.cs" Inherits="MasterPage_Default" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
    <script src="/js/Common/Common.js"></script> 
    <link href="/css/New css/pro_mng.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
    <script src="/js/New js/msdropdown/jquery.dd.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/New css/msdropdown/dd.css" />
      <script src="../../JavaScript/DatatablePlugin/select_datatable.js"></script>
    <script>
        function getdetails(href) {
            window.location = href;
            return false;
        }
        function SearchValidation() {
            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";
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


            if (document.getElementById("spanSrchStatus").style.display != "none") {
                var DropdownListSts = document.getElementById("<%=ddlLeadSts.ClientID%>");
                var SelectedValueSts = DropdownListSts.value;
                document.getElementById("<%=HiddenSearchStatus.ClientID%>").value = SelectedValueSts;
            }
            else {           
            }
            var SearchWord = document.getElementById("<%=txtCustomerName.ClientID%>").value;
            if (SearchWord == "") {
                document.getElementById("<%=HiddenSearchField.ClientID%>").value = "";
                ret=true;
            }
            else {
                if (SearchWord.length >= 3) {
                    var SearchWithoutReplace = document.getElementById("<%=txtCustomerName.ClientID%>").value;
                    var replaceText1 = SearchWithoutReplace.replace(/</g, "");
                    var replaceText2 = replaceText1.replace(/>/g, "");
                    document.getElementById("<%=txtCustomerName.ClientID%>").value = replaceText2;
                    document.getElementById("<%=HiddenSearchField.ClientID%>").value = replaceText2;
                    ret=true;
                }
                else {

                    ret=true;
                }
            } 
            if (ret == true) {
                LoadList();
            }
            return false;
        }
    </script>
    <script>
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

        function RemoveTag() {
            var SearchWithoutReplace = document.getElementById("<%=txtCustomerName.ClientID%>").value;
            var replaceText1 = SearchWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCustomerName.ClientID%>").value = replaceText2;
        }
        </script>
     <script>
         var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            // Run code
            // spanSrchStatus
            document.getElementById("spanSrchStatus").style.display = "";
            var L_MODE = document.getElementById("<%=hiddenLMode.ClientID%>").value;
            if (L_MODE == "NEW")
            {
                document.getElementById("spanSrchStatus").style.display = "none";
             
            }
            else if (L_MODE == "APRV")
            {
                document.getElementById("spanSrchStatus").style.display = "none";
               
            }
            else if (L_MODE == "ACTV")
            {
                document.getElementById("spanSrchStatus").style.display = "";
            }
            else if (L_MODE == "MCNVRTD") {
                document.getElementById("spanSrchStatus").style.display = "none";

            }
            else if (L_MODE == "MJUNK") {
                document.getElementById("spanSrchStatus").style.display = "none";

            }
            else if (L_MODE == "DPEND") {
                document.getElementById("spanSrchStatus").style.display = "none";

            }
            else if (L_MODE == "APRV_PNDNG") {
                document.getElementById("spanSrchStatus").style.display = "none";

            }
            else if (L_MODE == "MOPEND") {
                document.getElementById("spanSrchStatus").style.display = "none";

            }
            else if (L_MODE == "TJUNK") {
                document.getElementById("spanSrchStatus").style.display = "none";

            }
            else if (L_MODE == "TONOLD") {
                document.getElementById("spanSrchStatus").style.display = "none";

            }
            else if (L_MODE == "TCNVRTD") {
                document.getElementById("spanSrchStatus").style.display = "none";
            }   
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
   </asp:ScriptManager>
    <asp:HiddenField ID="HiddenSearchField" runat="server" />
    <asp:HiddenField ID="HiddenSearchStatus" runat="server" />
     <asp:HiddenField ID="hiddenLMode" runat="server" />
         <asp:HiddenField ID="hiddenNext" runat="server" />
        <asp:HiddenField ID="hiddenPrevious" runat="server" />
    <asp:HiddenField ID="hiddenTotalRowCount" runat="server" />
     <asp:HiddenField ID="hiddenMemorySize" runat="server" />
         <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
         <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
         <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
        <asp:HiddenField ID="hiddenCommodityValue" runat="server" />
         <asp:HiddenField ID="HiddenTeamId" runat="server" />


     <asp:HiddenField ID="HiddenFieldFromDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldToDate" runat="server" />
     <asp:HiddenField ID="HiddenFieldStatus" runat="server" />
     <asp:HiddenField ID="HiddenFieldSearchTxt" runat="server" />
     <asp:HiddenField ID="HiddenFieldAgeCondition" runat="server" />
     <asp:HiddenField ID="HiddenFieldAgeing1" runat="server" />
     <asp:HiddenField ID="HiddenFieldAgeing2" runat="server" />
     <asp:HiddenField ID="HiddenFieldStatusT" runat="server" />
     <asp:HiddenField ID="HiddenFieldL_MODE" runat="server" />

      <asp:HiddenField ID="hiddenResendQtnMailID" runat="server" />
      <asp:HiddenField ID="hiddenResendQtnMailType" runat="server" />
      <asp:HiddenField ID="hiddenQtnBackupID" runat="server" />
     <asp:HiddenField ID="hiddenCorporateId" runat="server" />
     <asp:HiddenField ID="hiddenCorporateDivId" runat="server" />
     <asp:HiddenField ID="hiddenFloatingValueMoney" runat="server" />
     <asp:HiddenField ID="hiddenFloatingValueTaxPercentage" runat="server" />
     <asp:HiddenField ID="hiddenFloatingValueUnit" runat="server" />
     <asp:HiddenField ID="hiddenTaxEnabled" runat="server" />
     <asp:HiddenField ID="hiddenFloatingValueCommonPercentage" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <asp:HiddenField ID="hiddenDfltQuotationFormatId" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyDisplay" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
    <asp:HiddenField ID="hiddenCurrencySymbol" runat="server" />
    <asp:HiddenField ID="hiddenCurrencyCode" runat="server" />
    <asp:HiddenField ID="hiddenLeadId" runat="server" />
     <asp:HiddenField ID="hiddenDivisionCode" runat="server" />
     <asp:HiddenField ID="hiddenUserCode" runat="server" />
     <asp:HiddenField ID="hiddenQtnRevisionVersn" runat="server" />
     <asp:HiddenField ID="hiddenQtnRefSerialId" runat="server" />
     <asp:HiddenField ID="hiddenMonthMM" runat="server" />
     <asp:HiddenField ID="hiddenYearYYYY" runat="server" />
     <asp:HiddenField ID="hiddenQtnTmpltId" runat="server" />
     <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
     <asp:HiddenField ID="hiddenQuotationID" runat="server" />
     <asp:HiddenField ID="hiddenRefNo" runat="server" />
      <asp:HiddenField ID="lblCustomerName" runat="server" />
      <asp:HiddenField ID="HiddenFieldTeamLeadId" runat="server" />
      <asp:HiddenField ID="lblDate" runat="server" />
      <asp:HiddenField ID="lblTitle" runat="server" />
      <asp:HiddenField ID="lblDivision" runat="server" />
      <asp:HiddenField ID="hiddenQuotationIds" runat="server" />
      <asp:HiddenField ID="hiddenQuotationStatus" runat="server" />
      <asp:HiddenField ID="hiddenLeadActiveUser" runat="server" />
      <asp:HiddenField ID="hiddenMailSts" runat="server" />
     <asp:HiddenField ID="hiddenTaskId" runat="server" />   
      <asp:HiddenField ID="hiddenProjectStatus" runat="server" />
      <asp:HiddenField ID="hiddenRfqId" runat="server" />
      <asp:HiddenField ID="hiddenInternalRef" runat="server" />
      <asp:HiddenField ID="hiddenProjectManager" runat="server" />
     <asp:HiddenField ID="hiddenTaskSubjctId" runat="server" />
      <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="hiddenFollowUpSrcId" runat="server" />
      <asp:HiddenField ID="hiddenReopenReasonId" runat="server" />
     <asp:HiddenField ID="HiddenFieldTaskUpd" runat="server" />
     <asp:HiddenField ID="hiddenLossReasonId" runat="server" />
     <asp:HiddenField ID="hiddenPartialWinIds" runat="server" />
    <asp:HiddenField ID="hiddenLeadMailId" runat="server" />
     <asp:HiddenField ID="hiddenMailFilePath" runat="server" />
    <asp:HiddenField ID="HiddenFieldtxtPartnWinAmount" runat="server" />
    
     <asp:Button ID="btnRejectMail" runat="server" OnClick="btnRejectMail_Click" style="visibility:hidden"/>
      <asp:Button runat="server" ID="btnPartWin" OnClick="btnPartialWin_Click" style="visibility:hidden" />
     <asp:Button runat="server" ID="btnConfirm" OnClick="btnConfirm_Click" style="visibility:hidden" />
      <asp:Button runat="server" ID="btnDelivered" OnClick="btnDelivered_Click" style="visibility:hidden" />   
    <asp:Button runat="server" ID="btnResendQtnMail" OnClick="btnReSendMailQtn_Click" style="visibility:hidden" />
    <asp:Button runat="server" ID="btnReSendMailQtn_BackUp" OnClick="btnReSendMailQtn_BackUp_Click" style="visibility:hidden" />
    
     <ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
    <li class="active">Opportunity</li>
  </ol>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

    <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr"> 
      <div class="content_box1 cont_contr">

           <div id="myModalLoadingMail" class="model">
            <div class="eachform" style="width:70%; height:70%; padding-left:45%; padding-top:15%;">
                 <img src="../../Images/Other Images/LoadingMail.gif" style="width:18%;" />
                 </div>
          </div>

        <h1 class="h1_con" id="spanPageHeading" runat="server">OPPORTUNITY</h1>
        <p id="pHeader" style="font-size: 16px;" runat="server"></p>
        <div class="form-group fg2 sa_o_fg1">
          <label for="pwd" class="fg2_la1">From Date:<span class="spn1"></span></label>
          <div id="datepicker" class="input-group date dt_wdt" data-date-format="mm-dd-yyyy">
            <input autocomplete="off" class="form-control inp_bdr" type="text" id="txtFromDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server"/>
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

        <div class="form-group fg2 sa_o_fg1">
          <label for="pwd" class="fg2_la1">To Date:<span class="spn1"></span></label>
          <div id="datepicker1" class="input-group date dt_wdt" data-date-format="mm-dd-yyyy">
            <input class="form-control inp_bdr" type="text"  autocomplete="off" id="txtToDate"  placeholder="DD-MM-YYYY" maxlength="20" runat="server" />
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

        <div class="form-group fg2 sa_o_fg6" id="spanSrchStatus">
          <label for="email" class="fg2_la1">Status<span class="spn1"></span>:</label>
             <asp:DropDownList ID="ddlLeadSts"  class="form-control fg2_inp1" runat="server"></asp:DropDownList>         
        </div>

        <div class="form-group fg2 sa_o_fg6" id="spanSrchName">
          <label for="email" class="fg2_la1">Customer Name:<span class="spn1"></span></label>
          <input id="txtCustomerName" placeholder="Minimum 3 Characters for Searching" type="text" class="form-control fg2_inp1" runat="server" maxlength="300" style="text-transform: uppercase;" onblur="RemoveTag()"/>
        </div>
        <div class="clearfix"></div>

        <div class="form-group fg2 sa_fg4 sa_480">
          <label for="email" class="fg2_la1">Ageing:<span class="spn1"></span></label>
          <div class="form-group fg6 sa_fg4 sa_480" style=" padding-bottom: 2px;width:62%;margin-right: 0px;">
            <select name="countries" id="txtAgeing" class="form-control fg2_inp1" onchange="chk_awd1()" runat="server">
              <option id="op_ag2" value='1' data-image="\Images\opp\op_1.png" data-imagecss="flag ad" data-title="Equal to" selected="">Equal</option>
              <option id="op_ag3" value='2' data-image="\Images\opp\op_2.png" data-imagecss="flag ae" data-title="Lessthan">Lessthan</option>
              <option id="Option1" value='3' data-image="\Images\opp\op_3.png" data-imagecss="flag af" data-title="Greaterthan">Greaterthan</option>
              <option id="Option2" value='4' data-image="\Images\opp\op_4.png" data-imagecss="flag ag" data-title="Lessthan Equal to">Lessthan Equal</option>
              <option id="Option3" value='5' data-image="\Images\opp\op_5.png" data-imagecss="flag ag" data-title="Greaterthan Equal to">Greaterthan Equal</option>
              <option id="Option4" value='6' data-image="\Images\opp\op_6.png" data-imagecss="flag ag" data-title="Not Equal to">Not Equal</option>
              <option id="op_ag1" value='7' data-image="\Images\opp\op_7.png" data-imagecss="flag ag" data-title="Between">Between</option>
            </select> 
          </div>

          <div class="form-group fg5 sa_o_fg6" style="width: 19%;margin-left: -18px;">
            <input id="ageing1" type="text" class="form-control fg2_inp1"  placeholder="0" runat="server" onkeydown="return isNumber(event);"/>
          </div>

          <div class="form-group fg5 sa_o_fg6" style="width: 19%;margin-left: -7px;">
            <input id="ageing2" type="text" class="form-control fg2_inp1" runat="server" placeholder="0" disabled="" onkeydown="return isNumber(event);"/>
          </div>
        </div>

        <div class="fg8 sa_o_fg6">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
          <button class="submit_ser"  onclick="return SearchValidation();"></button>
        </div>
              
              <div class="clearfix"></div>
              <div class="devider"></div>

          <div id="divPagingTable_processing" style="display: none;">Processing...</div>
      <div id="divPagingTableContainer"></div>
      <div id="divReport" runat="server" class="r_1024"></div>

  </div><!--content_container_closed------>
<!----frame_closed section to footer script section--->
</div>
<!-------working area_closed---->
</div>
<a href="#" type="button" class="print_o" title="Print page" onclick="return PrintClick();">
  <i class="fa fa-print"></i>
</a>
    <a href="gen_Lead.aspx" type="button" onclick="topFunction()" id="myBtn" runat="server" title="Add New">
  <i class="fa fa-plus-circle"></i>
</a>
<!-- Modal -->
<div class="modal fade" id="exampleModal_st" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header mo_hd1">
        <h5 class="modal-title" id="exampleModalLabel">Change Status</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
       ...
      </div>
      <div class="modal-footer mo_ft1">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal1">Yes</button>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
        
      </div>
    </div>
  </div>
</div>


<!-- Modal -->
<div class="modal fade" id="follow_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog snd_box_rgt" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Follow-up / Tasks
          <button class="btn act_btn bn8 bt_e" data-toggle="modal" data-target="#myModal_3" title="Add Followup / Task" id="SpanAddTask" onclick="return OpenModalTask('SpanAddTask',event);">
           <i class="fa fa-book"></i>
         </button></h5>
         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="r_480 mar_bt_480">
          <table class="table table-bordered tbl_480">
            <thead class="thead1">
              <tr>
               <th class="col-md-1">Sl#</th>
               <th class="col-md-3 tr_l">Subject</th>
               <th class="col-md-2 tr_c">From Date & Time</th>
               <th class="col-md-2 tr_c">Due Date & Time</th>
               <th class="col-md-2 tr_c">Actions</th>
             </tr>
           </thead>
           <tbody id="tbodyFollowup">
          </tbody>
        </table>
      </div>
    </div>
  </div>
</div>
</div>
<!-- Modal3 -->
<div class="modal fade" id="myModal_3" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top:7%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H2">Add Follow-Up / Task</h5>
        <button type="button" class="close" onclick="return CloseModalTask();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mod_bd1_800">
             <div class="myAlert-bottom alert alert-danger" id="divErrorRsnTask">
             </div>
        <div class="form-group fg4 sa_2">
             <label for="email" class="fg2_la1">Subject:<span class="spn1">*</span></label>
              <span id="SpanddlTask"></span>         
        </div>
        <div class="form-group fg6_5 sa_2 mar_at flt_l">
              <label for="pwd" class="fg2_la1">Due Week:<span class="spn1">*</span></label>
             <asp:DropDownList ID="ddlPlusWeek" class="form-control fg2_inp1  inp_mst" runat="server" onchange="return PlusWeek();"></asp:DropDownList>
        </div>

        <div class="clearfix"></div>

        <div class="form-group fg12">

          <div class="form-group fg4 sa_2">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">Due Date:<span class="spn1">*</span> </label>
              <div id="datepicker8" class="input-group date" data-date-format="DD-MM-YYYY">
                 <asp:TextBox ID="txtTaskDate" class="form-control inp_bdr inp_mst" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                   <script>
                       var $cssf = jQuery.noConflict();
                       $cssf('#cphMain_txtTaskDate').datepicker({
                           autoclose: true,
                           format: 'dd-mm-yyyy',
                           timepicker: false,
                           startDate: new Date(),
                       });
                            </script>
              </div>
            </div>
          </div>
                
                <div class="fg5 sa_2">
                  <label for="pwd" class="fg2_la1">Due Time:<span class="spn1">*</span></label>
                      <asp:DropDownList ID="ddlTaskHr" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>

             <div class="fg5 sa_2">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                   <asp:DropDownList ID="ddlTaskMin" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>
             <div class="fg7 sa_2">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                  <asp:DropDownList ID="ddlTask_AM_PM" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>
        </div>
          
          <div class="form-group fg12" id="divTaskClsTime" >

          <div class="form-group fg4 sa_2" id="divTaskClsDate">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">Closed Date:<span class="spn1">*</span> </label>
              <div id="Div1" class="input-group date" data-date-format="DD-MM-YYYY">
                 <asp:TextBox ID="txtClsTaskDate" class="form-control inp_bdr inp_mst" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>
                <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                   <script>
                       var $cssf = jQuery.noConflict();
                       $cssf('#cphMain_txtClsTaskDate').datepicker({
                           autoclose: true,
                           format: 'dd-mm-yyyy',
                           timepicker: false,
                           startDate: new Date(),
                       });
                            </script>
              </div>
            </div>
          </div>
                
                <div class="fg5 sa_2">
                  <label for="pwd" class="fg2_la1">Closed Time:<span class="spn1">*</span></label>
                      <asp:DropDownList ID="ddlClsTaskHr" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>

             <div class="fg5 sa_2">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                   <asp:DropDownList ID="ddlClsTaskMin" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>
             <div class="fg7 sa_2">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                  <asp:DropDownList ID="ddlClsTaskAM_PM" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>
             </div>
        </div>
           

        <div class="form-group fg12 sa_2 not_tx_ar">
          <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
          <textarea id="txtTaskDescptn" rows="3" cols="48" class="form-control flt_l dt_wdt" placeholder="Description" runat="server" onkeypress="return isTag('cphMain_txtTaskDescptn', event);" onkeydown="textCounter(cphMain_txtTaskDescptn,450);" onkeyup="textCounter(cphMain_txtTaskDescptn,450);" style="resize: none;"></textarea>
        </div>

           <div class="form-group fg2 fg2_mr sa_fg1">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1"></span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input type="checkbox" id="cbxTaskStatus"  runat="server" checked="checked"/>
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
                      


        <div class="clearfix"></div>
        <div class="free_sp"></div>


      </div>
      <div class="modal-footer">
           <asp:Button ID="btnTaskSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckTask();" OnClick="btnTaskSave_Click" />
           <asp:Button ID="btnTaskUpd" runat="server" class="btn sub1" Text="Update" OnClientClick="return CheckTask();" OnClick="btnTaskUpd_Click" />
           <button type="submit" class="btn sub4" onclick="return CloseModalTask();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>

<!-- Modal3 -->
<div class="modal fade" id="myModal_3_cls" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top:7%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H3">Close Follow-Up / Task</h5>
        <button type="button" class="close" onclick="return CloseModalCancelTask();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mod_bd1_800">
            <div class="myAlert-bottom alert alert-danger" id="divErrorRsnCancelTask">
             </div>
       
        <div class="form-group fg6 sa_2">
          <label for="email" class="fg2_la1">Added Date:<span class="spn1"></span></label>
              <asp:TextBox ID="txtACancelTaskDate" class="form-control fg2_inp1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>          
        </div>
        

        <div class="form-group fg6">
          <label for="pwd" class="fg2_la1">Added Time:<span class="spn1">*</span></label>
          <div class="fg4 sa_2">
               <asp:TextBox ID="lblACancelTaskHr" class="form-control fg2_inp1"  runat="server" disabled=""></asp:TextBox>   
         </div>

         <div class="fg4 sa_2">
              <asp:TextBox ID="lblACancelTaskMin" class="form-control fg2_inp1"  runat="server" disabled=""></asp:TextBox> 
          
         </div>
         <div class="fg4 sa_2">
              <asp:TextBox ID="lblACancelTask_AM_PM" class="form-control fg2_inp1"  runat="server" disabled=""></asp:TextBox> 
             
         </div>
        </div>

        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="form-group fg6 sa_2">
          <div class="tdte">
            <label for="pwd" class="fg2_la1">Completed Date:<span class="spn1">*</span> </label>
            <div id="datepicker6" class="input-group date" data-date-format="DD-MM-YYYY">
                 <asp:TextBox ID="txtCCancelTaskDate" class="form-control inp_bdr inp_mst cls_in1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return isNumberDate(event);"></asp:TextBox>
              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                 <script>
                     var $cssdf = jQuery.noConflict();
                     $cssdf('#cphMain_txtCCancelTaskDate').datepicker({
                         autoclose: true,
                         format: 'dd-mm-yyyy',
                         timepicker: false,
                         endDate: new Date(),
                     });
                            </script>
            </div>
          </div>
        </div>

        <div class="form-group fg6">
          <label for="pwd" class="fg2_la1">Completed Time:<span class="spn1">*</span></label>
          <div class="fg4 sa_2">
               <asp:DropDownList ID="ddlCCancelTaskHr" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>             
         </div>

         <div class="fg4 sa_2">
              <asp:DropDownList ID="ddlCCancelTaskMin" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList>         
         </div>
         <div class="fg4 sa_2">
              <asp:DropDownList ID="ddlCCancel_AM_PM" class="form-control fg2_inp1  inp_mst" runat="server"></asp:DropDownList> 
         </div>
        </div> 
      </div>
      <div class="modal-footer">
       <asp:Button ID="btnCancelTaskSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckCancelTask();" OnClick="btnCancelTaskSave_Click" />
       <button type="submit" class="btn sub4" onclick="return CloseModalCancelTask();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>


<!-- Modal -->
<div class="modal fade" id="attachview_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog snd_box_rgt" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H4">View Attachments
       <!--  <button class="btn act_btn bn8 bt_e" data-toggle="modal" data-target="#myModal_3" title="View Attachments">
           <i class="opp_ico_img"><img src="../images/icons/opp/view_mail.png"></i>
         </button> --></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="r_480">
          <table class="table table-bordered tbl_480">
            <thead class="thead1">
              <tr>
                <th class="col-md-1">Sl#</th>
                <th class="col-md-7 tr_l">Attachments </th>
                <th class="col-md-4">Date and Time</th>
              </tr>
            </thead>
            <tbody id="tbodyAttachment">            
            </tbody>
          </table>
        </div>      
      </div>
    </div>
  </div>
</div>



<!-- Modal -->
<div class="modal fade" id="note_qoute_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog snd_box_rgt" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H5">Notes 
        <button class="btn act_btn bn8 bt_e" data-toggle="modal" data-target="#myModal_2" title="Qoutation Notes" id='SpanAddFollowUp' onclick="return OpenModalFollowUp('SpanAddFollowUp',event);">
           <i class="opp_ico_img"><img src="/Images/opp/quot.notes.png"></i>
         </button></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="r_480 mar_bt_480">
          <table class="table table-bordered tbl_480">
            <thead class="thead1">
              <tr>
                 <th class="col-md-1">Sl#</th>
                <th class="col-md-5 tr_l">Note By</th>
                <th class="col-md-2 tr_c">Date</th>
                <th class="col-md-4 tr_c">Through</th>
                  </tr>
            </thead>
            <tbody id="tbodyNotes">
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</div>

<!-- Modal1 -->
<div class="modal fade" id="myModal_2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top: 8%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H6">Add Note</h5>
        <button type="button" class="close" onclick="return CloseModalFollowUp();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
            <div class="myAlert-bottom alert alert-danger" id="divErrorRsnFollowUp">
             </div>
        <div class="form-group fg6 mar_at flt_l">
             <label for="email" class="fg2_la1">Through:<span class="spn1">*</span></label>
              <span id="SpanddlFollowUp"></span>          
        </div>

        <div class="form-group fg6 mar_at flt_l">
          <div class="tdte">
            <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span> </label>
            <div id="datepicker3" class="input-group date" data-date-format="DD-MM-YYYY">
                 <asp:TextBox ID="txtFollowUpDate" class="form-control inp_bdr inp_mst" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>
              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
                 <script>
                     var $cssdfr = jQuery.noConflict();
                     $cssdfr('#cphMain_txtFollowUpDate').datepicker({
                         autoclose: true,
                         format: 'dd-mm-yyyy',
                         timepicker: false,
                         endDate: new Date(),
                     });
                            </script>
            </div>
          </div>
        </div>

            
        <div class="form-group fg12 mar_at flt_l">
              <label for="email" class="fg2_la1">Description:<span class="spn1">*</span></label>
              <textarea rows="3" cols="48" class="form-control flt_l  inp_mst not_tx_ar" placeholder="Description" id="txtFollowUpDescptn"  runat="server" onkeypress="return isTag('cphMain_txtFollowUpDescptn', event);" onkeydown="textCounter(cphMain_txtFollowUpDescptn,900);" onkeyup="textCounter(cphMain_txtFollowUpDescptn,900);" style="resize: none;"></textarea>
        </div>

        <div class="clearfix"></div>
        <div class="free_sp"></div>




      </div>
      <div class="modal-footer">
        <asp:Button ID="btnFollowUpSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckFollowUp();" OnClick="btnFollowUpSave_Click" />
       <button type="submit" class="btn sub4" onclick="return CloseModalFollowUp();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>
<!-- Modal -->
<div class="modal fade" id="reopen_qoute_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog los_res_mod" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H7">Reopen Reason</h5>
        <button type="button" class="close" onclick="return CloseModalReopenReason();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
            <div class="myAlert-bottom alert alert-danger" id="divErrorRsnReopenReason">
             </div>
         

        <div class="form-group fg12 mar_at flt_l">
          <label for="email" class="fg2_la1">Reason:<span class="spn1">*</span></label>
             <span id="SpanddlReopenReason"></span>           
        </div>
        <div class="form-group fg12 mar_at flt_l">
          <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
          <textarea id="txtReopenReasonDescptn"  runat="server" onkeypress="return isTag('cphMain_txtReopenReasonDescptn', event);" onkeydown="textCounter(cphMain_txtReopenReasonDescptn,900);" onkeyup="textCounter(cphMain_txtReopenReasonDescptn,900);" style="resize: none;" rows="3" cols="48" class="form-control flt_l not_tx_ar dt_wdt" placeholder="Description"></textarea>
        </div>
      </div>
      <div class="modal-footer">
       <asp:Button ID="btnReopenReasonSave" runat="server" class="btn sub1" Text="Submit" OnClientClick="return CheckReopenReason();" OnClick="btnReopenReasonSave_Click" />
       <button type="submit" class="btn sub4" onclick="return CloseModalReopenReason();" aria-label="Close">Cancel</button>
      </div>

    </div>
  </div>
</div>

<!-- Modal -->
<div class="modal fade" id="view_mail_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog snd_box_rgt" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H8">View Emails </h5>
        <!-- <button class="btn act_btn bn8 bt_e" data-toggle="modal" data-target="#myModal_3" title="View Mails">
           <i class="opp_ico_img"><img src="../images/icons/opp/snd_mail.png"></i>
         </button> --></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="r_480 mar_bt_480">
          <table class="table table-bordered tbl_480">
            <thead class="thead1">
              <tr>
                 <th class="col-md-1">Sl#</th>
                 <th class="col-md-2 tr_l">FROM</th>
                 <th class="col-md-2 tr_l">TO</th>
                 <th class="col-md-3 tr_l">Send / Received By</th>
                 <th class="col-md-2 tr_c">Date & Time</th>
                 <th class="col-md-1">In / Out</th>
                 <th class="col-md-1">Actions</th>
              </tr>
            </thead>
            <tbody id="tbodyMails">
          
          </tbody>
        </table>
      </div>
      </div>
    </div>
  </div>
</div>
<!-- Modal -->
<div class="modal fade" id="send_mail_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog snd_box_rgt" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H9">Resend Mails </h5>
        <!-- <button class="btn act_btn bn8 bt_e" data-toggle="modal" data-target="#myModal_3" title="Resend Mails">
           <i class="opp_ico_img"><img src="../images/icons/opp/snd_mail.png"></i>
         </button> --></h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="table_box tb_scr">
        <div class="r_480 mar_bt_480">
          <table class="table table-bordered tbl_480">
            <thead class="thead1">
              <tr>
                 <th class="col-md-1">Sl#</th>
                <th class="col-md-2 tr_l">Ref#</th>
                <th class="col-md-2 tr_c">From</th>
                <th class="col-md-2 tr_c">To</th>
                <th class="col-md-3 tr_c">Send As</th>
                <th class="col-md-2 tr_c">Actions</th>
                 
                  </tr>
            </thead>

          <tbody id="tbodyResendMails">
          
          </tbody>
        </table>
      </div>
    </div>
      </div>
    </div>
  </div>
</div>

    <!-- Modal_win -->
<div class="modal fade" id="win_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog los_res_mod" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H10">Add Project</h5>
        <button type="button" class="close" onclick="return CloseTenderRequestView();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
            <div id="divBidding" style="display:block">
        <div class="fg12">
            <span class="span_sm note1 tr_l">The Project You entered is not saved.Please provide RFQ Reference Number to save the entry.</span>
        </div><br><br>
        <div class="form-group fg12">
          <label for="email" class="fg2_la1">Tender / RFQ:<span class="spn1"></span></label>
             <asp:TextBox ID="txtRefNo" class="form-control fg2_inp1 win_op1" placeholder="Tender / RFQ" maxlength="100"  onkeypress="return isTagDisableEnter(cphMain_txtRefNo,event)" runat="server"></asp:TextBox>
        </div>
        </div>


           <div id="divAwarded" style="display:none">
        <div class="fg12">
            <span class="span_sm note1 tr_l">The Project You entered is not saved.Please select Project Manager and provide Internal Reference Number to save the entry.</span>
        </div><br><br>
                <div class="form-group fg12">
          <label for="email" class="fg2_la1">Project Manager:*<span class="spn1"></span></label>
                    <asp:DropDownList ID="ddlProjectManager" class="form-control fg2_inp1 win_op1"  onkeypress="return isTagDisableEnter(cphMain_txtInternalRefNum,event)" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                            </asp:DropDownList>           
        </div>
        <div class="form-group fg12">
          <label for="email" class="fg2_la1">Internal Ref#:*<span class="spn1"></span></label>
             <asp:TextBox ID="txtInternalRefNum" class="form-control fg2_inp1 win_op1" placeholder="Internal Ref#" maxlength="100"  onkeypress="return isTagDisableEnter(cphMain_txtInternalRefNum,event)" runat="server"></asp:TextBox>
        </div>
        </div>


      </div>
      <div class="modal-footer">
           <asp:Button ID="btnSubmit"  runat="server" value="Submit" OnClientClick="return RefIdTake();" OnClick="imgbtnWin_Click1" class="btn sub1" text="Submit"/>   
            <asp:Button ID="btnSubmitAwrd"  runat="server" value="Submit" OnClientClick="return InternalRefIdTake();" OnClick="imgbtnWin_Click1" class="btn sub1" text="Submit"/>   

       <button type="submit" class="btn sub4" onclick="return CloseTenderRequestView();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>

 <!-- Loss_info_Modal1 -->
<div class="modal fade" id="loss_info" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" style="z-index: 99999999999;">
  <div class="modal-dialog los_res_mod" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H11">Reason For Loss</h5>
        <button type="button" class="close" onclick="return CloseModalLossReason();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body padng_btm">
           <div class="myAlert-bottom alert alert-danger" id="divErrorRsnLossReason">
             </div>
        

        <div class="fg12 mar_bo1">
          <label for="email" class="fg2_la1">Reason:<span class="spn1">*</span></label>
             <span id="SpanddlLossReason"></span>         
        </div>
        <div class="fg12 mar_bo1">
          <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
          <textarea id="txtLossReasonDescptn"  runat="server" onkeypress="return isTag('cphMain_txtLossReasonDescptn', event);" onkeydown="textCounter(cphMain_txtLossReasonDescptn,900);" onkeyup="textCounter(cphMain_txtLossReasonDescptn,900);" style="resize: none;" rows="4" cols="48" class="form-control flt_l dt_wdt" placeholder="Write Something Here"></textarea>
        </div>
        <div class="fg12 ">
          <label for="email" class="fg2_la1 pad_l">Send regret mail:<span class="spn1"></span></label>
          <div class="check1 tr_l">
            <div class="">
              <label class="switch">
                <input type="checkbox" runat="server" id="cbxSendRegretMail" onkeypress="return isTagDisableEnter('cphMain_cbxSendRegretMail', event);" >
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>

        <div class="fg12">
            <span class="span_sm note1">(Please Review E-Mail Settings of-Employee,Division And Customer)</span>
        </div>

      </div>
      <div class="modal-footer">       
       <asp:Button ID="btnLossReasonSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckLossReason();" OnClick="btnLossReasonSave_Click" />
       <button type="submit" class="btn sub4" onclick="return CloseModalLossReason();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>


<div class="modal fade" id="par_win_box" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod1_100 flt_r" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H12">Quotation Partial Win</h5>
        <button type="button" class="close" onclick="return ClosePrtlWinContnr();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="form-group fg2 mar_at flt_l">
          <label for="email" class="fg2_la1">Total Amount:<span class="spn1"></span></label>
          <input id="txtTotalWinAmount" class="form-control fg2_inp1 tr_r" placeholder="0.00" disabled=""/>         
        </div>
        <div class="form-group fg2 mar_at flt_l" id="divProductGoup">
          <label for="email" class="fg2_la1">Product As:<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlProductGroup"  class="form-control fg2_inp1 pro_ip1" onchange="OpenPartial_Win()" onkeypress="return isTagDisableEnter(cphMain_ddlProductGroup,event)" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                            </asp:DropDownList>       
        </div>
        <div class="form-group fg5 mar_at flt_l">
          <div class="form-group">
            <label for="email" class="fg2_la1">Calculate Amount:<span class="spn1"></span></label>
               <asp:TextBox  runat="server" class="form-control inp_bdr tr_r" type="text" placeholder="0" disabled="" onclick="return false" onkeydown="return false" ID="txtPartnWinAmount" />
          
          </div>
        </div>
        <div class="form-group fg2 mar_at flt_r">
          <div class=" fg6 cal_wid26">
            <label for="email" class="fg2_la1">&nbsp;<span class="spn1"></span></label>               
            <button id="btnPartialWinAmount"  class="btn sub3"><i class="fa fa-calculator"></i> Calculate</button>
          </div>
          <div class="fg4">
            <label for="email" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
                <asp:Button runat="server" OnClientClick="return PartialWinClient()" OnClick="btnPartialWin_Click" ID="btnPartialWin" Text="Win" class="btn sub1" />
          </div>
        </div>
        <div class="clearfix"></div>
        <div class="spl_hcm wid_100_1 hei_102 bg_ne_1" style="margin-bottom: 10px;">
          <div class="table_box tb_scr r_1024" id="divProductTableContainer">
          </div>
        </div>

      </div>
    </div>
  </div>
</div>

    <div class="modal fade" id="send_mail" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod1_70 flt_r" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H13">Send Mail</h5>
        <button type="button" class="close" onclick="return CloseModalMail();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body min_hei_47">
           <div class="myAlert-bottom alert alert-danger" id="divErrorRsnMail">
             </div>
         

          <div class="form-group fg6 sa_fg4 sa_640">
            <label class="fg2_la1">From:</label>
               <asp:TextBox ID="txtFromAdress" class="form-control inp_wd_100"  disable="true" runat="server" autocomplete="off"></asp:TextBox>
          
          </div>
          <div class="form-group fg6 sa_fg4 sa_640">
            <label class="fg2_la1">To:</label>
                <asp:TextBox ID="txtToAddress" class="form-control inp_wd_100" onkeypress="return isTagDisableEnter('cphMain_txtToAddress', event);" runat="server" autocomplete="off"></asp:TextBox>
          </div>






           <div id="divCcBCc" style="float:right;width:38%;padding-top: 14px;display:none;">
                              <div class="divccdescription" style="margin-right: 76%;">
                            <div id="btnCC"  style="width:17px" class="buttonlink" onmouseover="CcDescriptionPosition('btnCC')" onclick="return ShowOrHideCc()">Cc</div>
                           <p id="CcDescriptions" class="CcDescription" style="position:absolute"></p>
                                  

                            </div>

                            <div class="divbccdescription" style="margin-right: 76%;">
                            <div id="btnBCc" style="width:20px;margin-top: -20px; margin-left: 22px;" class="buttonlink" onmouseover="BccDescriptionPosition('btnBCc')" onclick="return ShowOrHideBCc()">Bcc</div>
                             <p id="BccDescriptions" class="BccDescription" style="position:absolute"></p>
                                
                             </div> 

                                </div>
                            <div id="divCcContent" class="form-group fg6 sa_fg4 sa_640">

                             <label class="fg2_la1">CC:</label>  
                            <asp:TextBox ID="txtCccontent" class="form-control inp_wd_100" onkeypress="return isTagDisableEnter('cphMain_txtCccontent', event);" onkeyup="loadCorrespondingCc('cphMain_txtCccontent',event);" runat="server" autocomplete="off"></asp:TextBox>
                                 <img id="CloseCcimage" class="CloseCc" style="float:left; margin-top:-11%; margin-left: 101%; height:15px;width:15px; cursor:pointer;display:none;" onclick="return CloseCcMail();" src="../../Images/Icons/close-icon.CcBcc.png"/>
                             <div id="divCcHelper" style="display:none">


                             </div>
                                
                            </div>
                            
                         <div id="divBCcContent"  class="form-group fg6 sa_fg4 sa_640">
                            <label class="fg2_la1">BCC:</label>                            
                              <asp:TextBox ID="txtBCccontent" class="form-control inp_wd_100"  onkeypress="return isTagDisableEnter('cphMain_txtBCccontent', event);" onkeyup="loadCorrespondingBCc('cphMain_txtBCccontent',event);" runat="server" autocomplete="off"></asp:TextBox>
                             <img id="CloseBccImage" class="CloseBCc"  style="float:left; margin-top:-11%; margin-left: 101%; height:15px;width:15px; cursor:pointer;display:none;" onclick="return CloseBCcMail();" src="../../Images/Icons/close-icon.CcBcc.png"/>
                             <div id="divBCcHelper" style="display:none">
                             </div>
                         </div>





          <div class="form-group fg12 sa_fg4 sa_640">
            <label class="fg2_la1">Subject:</label>
                <asp:TextBox ID="txtMailSubject" class="form-control fg12 inp_wd_95" maxlength="150"  onkeypress="return isTagDisableEnter('cphMain_txtBCccontent', event);" onkeydown="loadCorrespondingBCc('cphMain_txtBCccontent',event);" runat="server"></asp:TextBox>
          </div>
          <div id="divContent" class="form-group fg12 inp_wd_95"></div>

          <div class="form-group fg12 inp_wd_95">
            <script src="https://cdn.ckeditor.com/4.8.0/full-all/ckeditor.js"></script>
            <textarea name=""  id="txtMailContent"  runat="server"  cols="30" rows="2"  disabled=""></textarea>
            <script type="text/javascript">
                CKEDITOR.replace('cphMain_txtMailContent', {
                    skin: 'moono',
                    enterMode: CKEDITOR.ENTER_BR,
                    shiftEnterMode: CKEDITOR.ENTER_P,
                    toolbar: [{ name: 'basicstyles', groups: ['basicstyles'], items: ['Bold', 'Italic', 'Underline', "-", 'TextColor', 'BGColor'] },
                               { name: 'styles', items: ['Format', 'Font', 'FontSize'] },
                               { name: 'scripts', items: ['Subscript', 'Superscript'] },
                               { name: 'justify', groups: ['blocks', 'align'], items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
                               { name: 'paragraph', groups: ['list', 'indent'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'] },
                               { name: 'links', items: ['Link', 'Unlink'] },
                               { name: 'insert', items: ['Image'] },
                               { name: 'spell', items: ['jQuerySpellChecker'] },
                               { name: 'table', items: ['Table'] }
                    ],
                });
            </script>
          </div>
           <div class="r_480" id="divAttachmentHeading">
            <table class="table table-bordered tbl_480">
              <thead class="thead1">
                <tr>
                  <th class="col-md-7 tr_l">Attachments</th>
                </tr>
              </thead>
              <tbody id="TableFileUploadContainer">
               
              </tbody>
            </table>
          </div>         
      </div>
      <div class="modal-footer">
           <asp:Button ID="btnSendMail" runat="server" class="btn sub1" Text="Send" OnClientClick="return CheckMail();"/>
           <asp:Button ID="btnMailReject" runat="server" class="btn sub1" Text="Reject" OnClientClick="return CheckReject();" OnClick="btnRejectMail_Click" />
           <asp:Button ID="btnReSendMail" runat="server" class="btn sub1" Text="Re-Send" OnClientClick="return CheckMail();" OnClick="btnReSendMail_Click" />
      </div>
    </div>
  </div>
</div>


      <div id="divOptionsLeadSource" runat="server" style="display: none">
    </div>
     <div id="divOptionsTaskSubject" runat="server" style="display: none">
    </div>
    <div id="divOptionsLossReason" runat="server" style="display: none">
    </div>
     <div id="divOptionsReopenReason" runat="server" style="display: none">
    </div>
<style>
    .selected {
    background-color: #98bedc !important;
}
        #cphMain_myBtn{
           position: fixed;
top: 220px;
right: 10px;
z-index: 99;
font-size: 20px;
border: none;
outline: none;
background-color: #48acf2;
color: #fff;
cursor: pointer;
padding: 0px;
    padding-top: 0px;
border-radius: 4px;
border-radius: 37px;
width: 46px;
height: 28px;
text-align: center;
transition-delay: 0.1s;
padding-top: 0px;
        }
    </style>
 <script>
     function PrintClick() {
         var orgID = '<%= Session["ORGID"] %>';
         var corptID = '<%= Session["CORPOFFICEID"] %>';
         var objData = {};
         objData.OrgId = orgID;
         objData.CorpId = corptID;
         objData.FromDate = document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value;
         objData.ToDate = document.getElementById("<%=HiddenFieldToDate.ClientID%>").value;
         objData.Status = document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
         objData.SearchText = document.getElementById("<%=HiddenFieldSearchTxt.ClientID%>").value;
         objData.Condition = document.getElementById("<%=HiddenFieldAgeCondition.ClientID%>").value;
         objData.Ageing1 = document.getElementById("<%=HiddenFieldAgeing1.ClientID%>").value;
         objData.Ageing2 = document.getElementById("<%=HiddenFieldAgeing2.ClientID%>").value;
         objData.StatusT = document.getElementById("<%=HiddenFieldStatusT.ClientID%>").value;
         objData.UpdRole = document.getElementById("<%=hiddenRoleUpdate.ClientID%>").value;
         objData.L_MODE = document.getElementById("<%=HiddenFieldL_MODE.ClientID%>").value;
         objData.hiddenLMode = document.getElementById("<%=hiddenLMode.ClientID%>").value;
         objData.HiddenTeamId = document.getElementById("<%=HiddenTeamId.ClientID%>").value;
         objData.UserId = '<%= Session["USERID"] %>';
         if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
             $.ajax({
                 type: "POST",
                 async: false,
                 contentType: "application/json; charset=utf-8",
                 url: "gen_TaskManipulation.aspx/PrintList",
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
 </script>
     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             
             document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value = document.getElementById("<%=txtFromDate.ClientID%>").value;
             document.getElementById("<%=HiddenFieldToDate.ClientID%>").value = document.getElementById("<%=txtToDate.ClientID%>").value;
             document.getElementById("<%=HiddenFieldStatus.ClientID%>").value = document.getElementById("<%=ddlLeadSts.ClientID%>").value;
             document.getElementById("<%=HiddenFieldSearchTxt.ClientID%>").value = document.getElementById("<%=txtCustomerName.ClientID%>").value;
             document.getElementById("<%=HiddenFieldAgeCondition.ClientID%>").value = document.getElementById("<%=txtAgeing.ClientID%>").value;
             document.getElementById("<%=HiddenFieldAgeing1.ClientID%>").value = document.getElementById("<%=ageing1.ClientID%>").value;
             document.getElementById("<%=HiddenFieldAgeing2.ClientID%>").value = document.getElementById("<%=ageing2.ClientID%>").value;
             document.getElementById("<%=HiddenFieldStatusT.ClientID%>").value = $("#cphMain_ddlLeadSts option:selected").text();
             Load_dt();
             getdata(1);
            
         });

         function LoadList() {
             document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value = document.getElementById("<%=txtFromDate.ClientID%>").value;
             document.getElementById("<%=HiddenFieldToDate.ClientID%>").value = document.getElementById("<%=txtToDate.ClientID%>").value;
             document.getElementById("<%=HiddenFieldStatus.ClientID%>").value = document.getElementById("<%=ddlLeadSts.ClientID%>").value;
             document.getElementById("<%=HiddenFieldSearchTxt.ClientID%>").value = document.getElementById("<%=txtCustomerName.ClientID%>").value;
             document.getElementById("<%=HiddenFieldAgeCondition.ClientID%>").value = document.getElementById("<%=txtAgeing.ClientID%>").value;
             document.getElementById("<%=HiddenFieldAgeing1.ClientID%>").value = document.getElementById("<%=ageing1.ClientID%>").value;
             document.getElementById("<%=HiddenFieldAgeing2.ClientID%>").value = document.getElementById("<%=ageing2.ClientID%>").value;
             document.getElementById("<%=HiddenFieldStatusT.ClientID%>").value = $("#cphMain_ddlLeadSts option:selected").text();
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
             strPagingTable += '<div class="r_1024"><table id="tblPagingTable" class="display table-bordered pro_tab1 tbl_1024" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var url = "gen_LeadList.aspx/LoadStaticDatafordt";
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
             var url = "gen_LeadList.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.UserId = '<%= Session["USERID"] %>';
             objData.FromDate = document.getElementById("<%=HiddenFieldFromDate.ClientID%>").value;
             objData.ToDate = document.getElementById("<%=HiddenFieldToDate.ClientID%>").value;
             objData.Status = document.getElementById("<%=HiddenFieldStatus.ClientID%>").value;
             objData.SearchText = document.getElementById("<%=HiddenFieldSearchTxt.ClientID%>").value;
             objData.Condition = document.getElementById("<%=HiddenFieldAgeCondition.ClientID%>").value;
             objData.Ageing1 = document.getElementById("<%=HiddenFieldAgeing1.ClientID%>").value;
             objData.Ageing2 = document.getElementById("<%=HiddenFieldAgeing2.ClientID%>").value;
             objData.UpdRole = document.getElementById("<%=hiddenRoleUpdate.ClientID%>").value;
             objData.L_MODE = document.getElementById("<%=HiddenFieldL_MODE.ClientID%>").value;
             objData.hiddenLMode = document.getElementById("<%=hiddenLMode.ClientID%>").value;
             objData.HiddenTeamId = document.getElementById("<%=HiddenTeamId.ClientID%>").value;
             

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
   <script>
       $(document).ready(function () {
           var $aus = jQuery.noConflict();
           $aus("#cphMain_txtAgeing").msDropdown({ roundedBorder: false });
           $aus("#cphMain_txtAgeing").msDropdown({ visibleRows: 4 });
           $aus("").msDropdown();
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
    <script>
        function chk_awd1() {
            if (document.getElementById("op_ag1").selected == true) {
                document.getElementById("cphMain_ageing2").disabled = false;
            } else {
                document.getElementById("cphMain_ageing2").disabled = true;
                document.getElementById("<%=ageing2.ClientID%>").value = "";
            }
        }

        function ViewDetails(Mode, Id, sts, refe,showAdd) {
            if (showAdd == "0") {
                document.getElementById("SpanAddFollowUp").style.display = "none";
                document.getElementById("SpanAddTask").style.display = "none";
                
            }
            else {
                document.getElementById("SpanAddFollowUp").style.display = "";
                document.getElementById("SpanAddTask").style.display = "";
            }

            document.getElementById("<%=hiddenRefNo.ClientID%>").value = refe;           
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userid = '<%= Session["USERID"] %>';
            var objData = {};
            objData.OrgId = orgID;
            objData.CorpId = corptID;
            objData.Mode = Mode;
            objData.Id = Id;
            objData.sts = sts;
            objData.refe = refe;
            objData.userid = userid;
            document.getElementById("<%=hiddenLeadId.ClientID%>").value = Id;
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_LeadList.aspx/ViewDetails",
                    data: JSON.stringify(objData),
                    dataType: "json",
                    success: function (data) {
                        if (Mode == "1") {
                            document.getElementById("tbodyAttachment").innerHTML = data.d;
                        }
                        else if (Mode == "2") {
                            document.getElementById("tbodyMails").innerHTML = data.d;
                        }
                        else if (Mode == "3") {
                            document.getElementById("tbodyNotes").innerHTML = data.d;
                        }
                        else if (Mode == "4") {
                            document.getElementById("tbodyFollowup").innerHTML = data.d;
                        }
                        else if (Mode == "5") {
                            document.getElementById("tbodyResendMails").innerHTML = data.d;
                        }
                    }
                });
            }
            else {
                window.location = '/Security/Login.aspx';
            }
            return false;
        }
        function ChangeStsQuot(Mode, Id) {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userid = '<%= Session["USERID"] %>';
            var objData = {};
            objData.OrgId = orgID;
            objData.CorpId = corptID;
            objData.Mode = Mode;
            objData.Id = Id;
            objData.userid = userid;
            document.getElementById("<%=hiddenLeadId.ClientID%>").value = Id;
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                var msg="";
                if (Mode == "1") {
                    msg = "Are you sure you want to confirm this quotation?";                 
                }
                else if (Mode == "2") {
                    msg = "Are you sure you want to deliver this quotation?";
                }
                else if (Mode == "3") {
                    msg = "Are you sure you want to re-open this quotation?";
                }
                ezBSAlert({
                    type: "confirm",
                    messageText: msg,
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                       
                        if (Mode == "1") {
                            __doPostBack("<%=btnConfirm.UniqueID %>", "");
                }
                else if (Mode == "2") {
                    __doPostBack("<%=btnDelivered.UniqueID %>", "");
                }
                else if (Mode == "3") {
                    OpenModalReopenReason();
                   }
                  return false;
                }
                else {
                    return false;
                }
            });

            }
            else {
                window.location = '/Security/Login.aspx';
            }
            return false;
        }
        function ChangeStsOpportunity(Mode, Id) {
            var orgID = '<%= Session["ORGID"] %>';
            var corptID = '<%= Session["CORPOFFICEID"] %>';
            var userid = '<%= Session["USERID"] %>';
            var objData = {};
            objData.OrgId = orgID;
            objData.CorpId = corptID;
            objData.Mode = Mode;
            objData.Id = Id;
            objData.userid = userid;
            document.getElementById("<%=hiddenLeadId.ClientID%>").value = Id;
            if (corptID != "" && corptID != null && orgID != "" && orgID != null) {
                var msg = "";
                if (Mode == "1") {
                    msg = "Are you sure you want to change the status of the opportunity to 'WIN'?";
                    ezBSAlert({
                        type: "confirm",
                        messageText: msg,
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {

                            if (Mode == "1") {
                                projectRefNo();
                            }
                            else if (Mode == "2") {
                                __doPostBack("<%=btnDelivered.UniqueID %>", "");
                        }
                        else if (Mode == "3") {
                            OpenModalLossReason();
                        }
                    return false;
                }
                else {
                    return false;
                }
                });
                }
                else if (Mode == "2") {



                    var strLeadId = document.getElementById("<%=hiddenLeadId.ClientID%>").value;
                    var strCorpId = '<%= Session["CORPOFFICEID"] %>';
                  
                    $Mo.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_LeadList.aspx/BindPrdctGrp",
                        data: '{strLeadId: "' + strLeadId + '",strCorpId: "' + strCorpId + '"}',
                        dataType: "json",
                        success: function (data) {
                            document.getElementById("<%=ddlProductGroup.ClientID%>").innerHTML = data.d;                           
                        }
                    });
                    OpenPartial_Win();
                    return false;
                }
                else if (Mode == "3") {
                    msg = "Are you sure you want to change the status of the lead to 'LOSS'?";
                    ezBSAlert({
                        type: "confirm",
                        messageText: msg,
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {

                            if (Mode == "1") {
                                projectRefNo();
                            }
                            else if (Mode == "2") {
                                __doPostBack("<%=btnDelivered.UniqueID %>", "");
                        }
                        else if (Mode == "3") {
                            OpenModalLossReason();
                        }
                    return false;
                }
                else {
                    return false;
                }
                });
                }
               
}
else {
    window.location = '/Security/Login.aspx';
}
    return false;
}

        function RefIdTake() {
            document.getElementById("<%=txtRefNo.ClientID%>").style.borderColor = "";
              document.getElementById("<%=hiddenProjectStatus.ClientID%>").value = "BIDDING";
              var ProjectRfq = document.getElementById("<%=txtRefNo.ClientID%>").value.trim();
              var replaceText1 = ProjectRfq.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtRefNo.ClientID%>").value = replaceText2;
            ProjectRfq = replaceText2;

            if (ProjectRfq != null && ProjectRfq != "") {
                document.getElementById("<%=hiddenRfqId.ClientID%>").value = ProjectRfq;
                $('#win_box').modal('hide');
                //ConfirmWin();
                return true;
            }
            else {
                ezBSAlert({
                    type: "alert",
                    messageText: "Please enter the value",
                    alertType: "info"
                });              
                //alert("Please enter the value");
                document.getElementById("<%=txtRefNo.ClientID%>").style.borderColor = "Red";
                return false;
            }
        }
        //QCLD4 EVM0012
        function InternalRefIdTake() {
            var $auPop = jQuery.noConflict();
            document.getElementById("<%=txtInternalRefNum.ClientID%>").style.borderColor = "";
            $auPop("div#divProjectManager input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("<%=hiddenProjectStatus.ClientID%>").value = "AWARDED";
            var ProjectManager = document.getElementById("<%=ddlProjectManager.ClientID%>").value;
            var InternalRef = document.getElementById("<%=txtInternalRefNum.ClientID%>").value.trim();
            var replaceText1 = InternalRef.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtInternalRefNum.ClientID%>").value = replaceText2;
            InternalRef = replaceText2;

            if (ProjectManager != null && ProjectManager != "--SELECT EMPLOYEE--" && InternalRef != null && InternalRef != "") {
                document.getElementById("<%=hiddenProjectManager.ClientID%>").value = ProjectManager;
                document.getElementById("<%=hiddenInternalRef.ClientID%>").value = InternalRef;
                $('#win_box').modal('hide');
                // hiddenProjectManager
                //hiddenInternalRef
                //ConfirmWin();
                return true;
            }
            else {
                ezBSAlert({
                    type: "alert",
                    messageText: "Please enter the value",
                    alertType: "info"
                });
                //alert("Please enter the value");
                if (ProjectManager == "--SELECT EMPLOYEE--") {
                    // document.getElementById("<%=ddlProjectManager.ClientID%>").style.borderColor = "";
                    $auPop("div#divProjectManager input.ui-autocomplete-input").css("borderColor", "Red");
                    $auPop("div#divProjectManager input.ui-autocomplete-input").focus();
                    $auPop("div#divProjectManager input.ui-autocomplete-input").select();
                }
                if (InternalRef == "") {
                    document.getElementById("<%=txtInternalRefNum.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtInternalRefNum.ClientID%>").focus();
                }
                return false;
            }
        }
        function CloseTenderRequestView() {
            $('#win_box').modal('hide');
            return false;
        }
        //0013
        function projectRefNo() {

            var ret = true;
           
                var leadId = document.getElementById("<%=hiddenLeadId.ClientID%>").value;

                $Mo.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_LeadList.aspx/ProjectLoad",
                    data: '{strLeadId: "' + leadId + '"}',
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "1") {
                            ezBSAlert({
                                type: "confirm",
                                messageText: "Are you sure you want to add the project ?",
                                alertType: "info"
                            }).done(function (e) {
                                if (e == true) {

                                    $('#win_box').modal('show');
                                    document.getElementById("divBidding").style.display = "block";
                                    document.getElementById("divAwarded").style.display = "none";
                                    document.getElementById("<%=btnSubmit.ClientID%>").style.display = "";
                                document.getElementById("<%=btnSubmitAwrd.ClientID%>").style.display = "none";
                        return false;
                    }
                    else {
                        return false;
                    }
                    });
                       ret = false;
                        }
                        else if (data.d == "2") {
                            ezBSAlert({
                                type: "confirm",
                                messageText: "Are you sure you want to add the project ?",
                                alertType: "info"
                            }).done(function (e) {
                                if (e == true) {

                                    $('#win_box').modal('show');
                                    document.getElementById("divBidding").style.display = "none";
                                    document.getElementById("divAwarded").style.display = "block";
                                    document.getElementById("<%=btnSubmit.ClientID%>").style.display = "none";
                                    document.getElementById("<%=btnSubmitAwrd.ClientID%>").style.display = "";
                                    return false;
                                }
                                else {
                                    return false;
                                }
                            });
                            ret = false;
                        }
                        else {

                        }
                    },
                    error: function (result) {
                        // alert("Error");
                    }
                });
           
            return false;
        }

        function PostbackFun(Email, MailType,LeadId) {
            document.getElementById("<%=hiddenResendQtnMailID.ClientID%>").value = Email;
            document.getElementById("<%=hiddenResendQtnMailType.ClientID%>").value = MailType;
            document.getElementById("<%=hiddenLeadId.ClientID%>").value = LeadId;
            ShowLoading();
             __doPostBack("<%=btnResendQtnMail.UniqueID %>", "");
            return false;
        }

        function PostbackFunForRevQutn(BkupId, Email, MailType, LeadId) {
            document.getElementById("<%=hiddenResendQtnMailID.ClientID%>").value = Email;
            document.getElementById("<%=hiddenResendQtnMailType.ClientID%>").value = MailType;
            document.getElementById("<%=hiddenQtnBackupID.ClientID%>").value = BkupId;
            document.getElementById("<%=hiddenLeadId.ClientID%>").value = LeadId;
            ShowLoading();
            __doPostBack("<%=btnReSendMailQtn_BackUp.UniqueID %>", "");
            return false;
        }
        function ShowLoading() {
            document.getElementById("myModalLoadingMail").style.display = "block";
        }
        function HideLoading() {
            document.getElementById("myModalLoadingMail").style.display = "none";
        }
        function SuccessMail() {
            $("#success-alert").html("Mail send  successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            HideLoading();
        }
        function SuccessConfirmation() {
            $("#success-alert").html("Quotation details confirmed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessDelivery() {
            $("#success-alert").html("Quotation details delivered successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function UnSuccessMail() {
            $("#divWarning").html("Mail was not send .Please check your connection .");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
            HideLoading();
        }
        function ErrorMsg() {
            $("#divWarning").html("Some error occured.Please review entered information !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessInsertionTask() {
            $("#success-alert").html("Follow-Up/Task details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdationTask() {
            $("#success-alert").html("Follow-Up/Task details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdationTaskSts() {
            $("#success-alert").html("Follow-Up/Task details status changed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessCancelationTask() {
            $("#success-alert").html("Follow-Up/Task closed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessLoss(strMsg) {
            $("#success-alert").html(strMsg);
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessWin(strMsg) {
            $("#success-alert").html(strMsg);
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessInsertionFollowUp() {
            $("#success-alert").html("Opportunity note inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });           
        }
        function SuccessReOpen() {
            $("#success-alert").html("Quotation details re-opened successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });          
        }
        function RejectedMail() {
            $("#success-alert").html("Mail rejected sucessfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            HideLoading();
        }
        function UpdateSuccessMail() {
            $("#success-alert").html("Mail send  successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });         
            HideLoading();
        }
        function UpdateUnSuccessMail() {
            $("#divWarning").html("Mail was not send .Please check your connection .");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });           
            HideLoading();
        }
        function SuccessInsertionList() {
            $("#success-alert").html("Opportunity details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessUpdationList() {
            $("#success-alert").html("Opportunity details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
</script>

<style type="text/css">
  .content_box1{padding-bottom: 80px!important;}
  .table-bordered>tbody>tr>td, .table-bordered>tbody>tr>th, .table-bordered>tfoot>tr>td, .table-bordered>tfoot>tr>th, .table-bordered>thead>tr>td, .table-bordered>thead>tr>th {
    padding: 3px!important;font-size: 12px!important;}
</style>
    <style>       
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
                  .fa.pull-right {
    margin-left: 1px !important;
     margin-right: 1px !important;
}
                   .model {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 100px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}
    </style>  


     <%-----------------------------------------------------FOR TASK------------------------------------------------------------------%>
    <script>
        var $Mo = jQuery.noConflict();
        function PlusWeek() {
            var DropdownListWeek = document.getElementById("<%=ddlPlusWeek.ClientID%>");
            var SelectedValueWeek = DropdownListWeek.value;
            var dateDateCntrlr = new Date();
            if (SelectedValueWeek != '--Select Week--') {
                var week = parseInt(SelectedValueWeek);

                dateDateCntrlr.setDate(dateDateCntrlr.getDate() + week * 7);
            }
            var dd = dateDateCntrlr.getDate();
            var mm = dateDateCntrlr.getMonth() + 1; //January is 0!
            var yyyy = dateDateCntrlr.getFullYear();
            if (dd < 10) {
                dd = '0' + dd
            }
            if (mm < 10) {
                mm = '0' + mm
            }
            var ddmmyyyyDate = dd + '-' + mm + '-' + yyyy;
            document.getElementById("<%=txtTaskDate.ClientID%>").value = ddmmyyyyDate;
            return false;
        }
        function OpenModalTask(objname, subEvent) {
            document.getElementById('<%=btnTaskSave.ClientID%>').style.display = "";
            document.getElementById('<%=btnTaskUpd.ClientID%>').style.display = "none";
           
            document.getElementById('divTaskClsDate').style.display = "none";
            document.getElementById('divTaskClsTime').style.display = "none";
          
            //for options in Task Subject

            var OptionsSbjct = document.getElementById("<%=divOptionsTaskSubject.ClientID%>").innerHTML;

            var DfltOptnSbjct = '<option  value="--SELECT SUBJECT--">--SELECT SUBJECT--</option>';
            var TotalOptnSbjct = "";
            if (OptionsSbjct == "") {
                TotalOptnSbjct = DfltOptnSbjct;
            }
            else {

                TotalOptnSbjct = DfltOptnSbjct + OptionsSbjct;

            }

            var TaskSbjctHtml = '<select id="ddlTaskSubject"  class="form-control fg2_inp1  inp_mst" > ';
            //  </select> </td>
            TaskSbjctHtml += TotalOptnSbjct;
            TaskSbjctHtml += ' </select>  ';

            document.getElementById('SpanddlTask').innerHTML = TaskSbjctHtml;

            document.getElementById("ddlTaskSubject").style.borderColor = "";
            document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";

            document.getElementById("ddlTaskSubject").disabled = false;
            document.getElementById("<%=ddlTaskHr.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTaskMin.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDate.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").disabled = false;
            document.getElementById("<%=cbxTaskStatus.ClientID%>").disabled = false;
            document.getElementById("<%=ddlPlusWeek.ClientID%>").disabled = false;

            var desiredValueSbjct = "--SELECT SUBJECT--";
            var elSbjct = document.getElementById("ddlTaskSubject");
            for (var i = 0; i < elSbjct.options.length; i++) {
                if (elSbjct.options[i].value == desiredValueSbjct) {
                    elSbjct.selectedIndex = i;
                    break;
                }
            }
            var desiredValueHr = "12";
            var elHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
            for (var i = 0; i < elHr.options.length; i++) {
                if (elHr.options[i].value == desiredValueHr) {
                    elHr.selectedIndex = i;
                    break;
                }
            }
            var desiredValueMin = "00";
            var elMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
            for (var i = 0; i < elMin.options.length; i++) {
                if (elMin.options[i].value == desiredValueMin) {
                    elMin.selectedIndex = i;
                    break;
                }
            }
            var desiredValueAMPM = "AM";
            var elAMPM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
            for (var i = 0; i < elAMPM.options.length; i++) {
                if (elAMPM.options[i].value == desiredValueAMPM) {
                    elAMPM.selectedIndex = i;
                    break;
                }
            }
            var desiredValueWeekSelect = "--Select Week--";
            var elWk = document.getElementById("<%=ddlPlusWeek.ClientID%>");
            for (var i = 0; i < elWk.options.length; i++) {
                if (elWk.options[i].value == desiredValueWeekSelect) {
                    elWk.selectedIndex = i;
                    break;
                }
            }
            document.getElementById("<%=txtTaskDate.ClientID%>").value = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").value = "";
            document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = true;
            document.getElementById("ddlTaskSubject").focus();
            document.getElementById("H2").innerText="Add Follow-Up / Task";
            return false;
        }


        function EditModalTask(objname, subEvent, TaskId, TaskSubjctId, TaskSubjctName, TaskDueDate, TaskDueHr, TaskDueMin, TaskDueAM_PM, Descptn, TaskSts) {
            document.getElementById('<%=btnTaskSave.ClientID%>').style.display = "none";
            document.getElementById('<%=btnTaskUpd.ClientID%>').style.display = "";
            document.getElementById('divTaskClsDate').style.display = "none";
            document.getElementById('divTaskClsTime').style.display = "none";

            
            document.getElementById('<%=HiddenFieldTaskUpd.ClientID%>').value = "0";
            document.getElementById('<%=hiddenTaskId.ClientID%>').value = TaskId;
           
            //for options in Task Subject

            var OptionsSbjct = document.getElementById("<%=divOptionsTaskSubject.ClientID%>").innerHTML;

            var DfltOptnSbjct = '<option  value="--SELECT SUBJECT--">--SELECT SUBJECT--</option>';
            var TotalOptnSbjct = "";
            if (OptionsSbjct == "") {
                TotalOptnSbjct = DfltOptnSbjct;
            }
            else {

                TotalOptnSbjct = DfltOptnSbjct + OptionsSbjct;

            }

            var TaskSbjctHtml = ' <select id="ddlTaskSubject"  class="form-control fg2_inp1  inp_mst" > ';
            //  </select> </td>
            TaskSbjctHtml += TotalOptnSbjct;
            TaskSbjctHtml += ' </select>  ';

            document.getElementById('SpanddlTask').innerHTML = TaskSbjctHtml;


            document.getElementById("ddlTaskSubject").style.borderColor = "";
            document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";

            document.getElementById("ddlTaskSubject").disabled = false;
            document.getElementById("<%=ddlTaskHr.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTaskMin.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDate.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").disabled = false;
            document.getElementById("<%=cbxTaskStatus.ClientID%>").disabled = false;
            document.getElementById("<%=ddlPlusWeek.ClientID%>").disabled = false;
            var desiredValueSbjct = TaskSubjctId;
            var elSbjct = document.getElementById("ddlTaskSubject");
            for (var i = 0; i < elSbjct.options.length; i++) {
                if (elSbjct.options[i].value == desiredValueSbjct) {
                    elSbjct.selectedIndex = i;
                    break;
                }
            }
            var TSbjct = document.getElementById("ddlTaskSubject").value;
            //  alert(LHead);
            if (TSbjct == "--SELECT SUBJECT--" || TSbjct == "") {
                //add option code
                $Mo("#ddlTaskSubject").append($Mo('<option>', {
                    value: TaskSubjctId,
                    text: TaskSubjctName
                }));
                var AdesiredValueSource = TaskSubjctId;
                var AelSbjct = document.getElementById("ddlTaskSubject");
                for (var i = 0; i < AelSbjct.options.length; i++) {
                    if (AelSbjct.options[i].value == AdesiredValueSource) {
                        AelSbjct.selectedIndex = i;
                        break;
                    }
                }
            }
            var desiredValueHr = TaskDueHr;
            var elHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
            for (var i = 0; i < elHr.options.length; i++) {
                if (elHr.options[i].value == desiredValueHr) {
                    elHr.selectedIndex = i;
                    break;
                }
            }

            var desiredValueMin = TaskDueMin;
            var elMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
            for (var i = 0; i < elMin.options.length; i++) {
                if (elMin.options[i].value == desiredValueMin) {
                    elMin.selectedIndex = i;
                    break;
                }
            }

            var desiredValueAMPM = TaskDueAM_PM;
            var elAMPM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
            for (var i = 0; i < elAMPM.options.length; i++) {
                if (elAMPM.options[i].value == desiredValueAMPM) {
                    elAMPM.selectedIndex = i;
                    break;
                }
            }
            var desiredValueWeekSelect = "--Select Week--";
            var elWk = document.getElementById("<%=ddlPlusWeek.ClientID%>");
                for (var i = 0; i < elWk.options.length; i++) {
                    if (elWk.options[i].value == desiredValueWeekSelect) {
                        elWk.selectedIndex = i;
                        break;
                    }
                }
            document.getElementById("<%=txtTaskDate.ClientID%>").value = TaskDueDate;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").value = Descptn;
            if (TaskSts == 'ACTIVE') {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = true;
            }
            else {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = false;
            }
            document.getElementById("H2").innerText = "Edit Follow-Up / Task";
            return false;
        }




        function StsModalTask(objname, subEvent, TaskId, TaskSubjctId, TaskSubjctName, TaskDueDate, TaskDueHr, TaskDueMin, TaskDueAM_PM, Descptn, TaskSts) {

            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to change status?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById('<%=HiddenFieldTaskUpd.ClientID%>').value = "1";
            document.getElementById('<%=btnTaskSave.ClientID%>').style.display = "none";
                    document.getElementById('<%=btnTaskUpd.ClientID%>').style.display = "";
            document.getElementById('divTaskClsDate').style.display = "none";
            document.getElementById('divTaskClsTime').style.display = "none";
            document.getElementById('<%=hiddenTaskId.ClientID%>').value = TaskId;
            //for options in Task Subject
            var OptionsSbjct = document.getElementById("<%=divOptionsTaskSubject.ClientID%>").innerHTML;
            var DfltOptnSbjct = '<option  value="--SELECT SUBJECT--">--SELECT SUBJECT--</option>';
            var TotalOptnSbjct = "";
            if (OptionsSbjct == "") {
                TotalOptnSbjct = DfltOptnSbjct;
            }
            else {
                TotalOptnSbjct = DfltOptnSbjct + OptionsSbjct;
            }

            var TaskSbjctHtml = ' <select id="ddlTaskSubject"  class="form-control fg2_inp1  inp_mst" > ';
            //  </select> </td>
            TaskSbjctHtml += TotalOptnSbjct;
            TaskSbjctHtml += ' </select>  ';
            document.getElementById('SpanddlTask').innerHTML = TaskSbjctHtml;
          
            document.getElementById("ddlTaskSubject").style.borderColor = "";
            document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";

            document.getElementById("ddlTaskSubject").disabled = false;
            document.getElementById("<%=ddlTaskHr.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTaskMin.ClientID%>").disabled = false;
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDate.ClientID%>").disabled = false;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").disabled = false;
            document.getElementById("<%=cbxTaskStatus.ClientID%>").disabled = false;
            document.getElementById("<%=ddlPlusWeek.ClientID%>").disabled = false;
            var desiredValueSbjct = TaskSubjctId;
            var elSbjct = document.getElementById("ddlTaskSubject");
            for (var i = 0; i < elSbjct.options.length; i++) {
                if (elSbjct.options[i].value == desiredValueSbjct) {
                    elSbjct.selectedIndex = i;
                    break;
                }
            }
            var TSbjct = document.getElementById("ddlTaskSubject").value;
            //  alert(LHead);
            if (TSbjct == "--SELECT SUBJECT--" || TSbjct == "") {
                //add option code
                $Mo("#ddlTaskSubject").append($Mo('<option>', {
                    value: TaskSubjctId,
                    text: TaskSubjctName
                }));
                var AdesiredValueSource = TaskSubjctId;
                var AelSbjct = document.getElementById("ddlTaskSubject");
                for (var i = 0; i < AelSbjct.options.length; i++) {
                    if (AelSbjct.options[i].value == AdesiredValueSource) {
                        AelSbjct.selectedIndex = i;
                        break;
                    }
                }
            }
            var desiredValueHr = TaskDueHr;
            var elHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
            for (var i = 0; i < elHr.options.length; i++) {
                if (elHr.options[i].value == desiredValueHr) {
                    elHr.selectedIndex = i;
                    break;
                }
            }

            var desiredValueMin = TaskDueMin;
            var elMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
            for (var i = 0; i < elMin.options.length; i++) {
                if (elMin.options[i].value == desiredValueMin) {
                    elMin.selectedIndex = i;
                    break;
                }
            }

            var desiredValueAMPM = TaskDueAM_PM;
            var elAMPM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
            for (var i = 0; i < elAMPM.options.length; i++) {
                if (elAMPM.options[i].value == desiredValueAMPM) {
                    elAMPM.selectedIndex = i;
                    break;
                }
            }
            var desiredValueWeekSelect = "--Select Week--";
            var elWk = document.getElementById("<%=ddlPlusWeek.ClientID%>");
            for (var i = 0; i < elWk.options.length; i++) {
                if (elWk.options[i].value == desiredValueWeekSelect) {
                    elWk.selectedIndex = i;
                    break;
                }
            }
            document.getElementById("<%=txtTaskDate.ClientID%>").value = TaskDueDate;
                document.getElementById("<%=txtTaskDescptn.ClientID%>").value = Descptn;
            if (TaskSts == 'ACTIVE') {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = false;
            }
            else {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = true;
            }
            document.getElementById('<%=btnTaskUpd.ClientID%>').click();
            return false;
                }
                else {
                    return false;
                }
            });
           return false;
        }






        function ViewModalTask(objname, subEvent, TaskSubjctId, TaskSubjctName, TaskDueDate, TaskDueHr, TaskDueMin, TaskDueAM_PM, Descptn, TaskSts, TaskClsDate, TaskClsHr, TaskClsMin, TaskClsAM_PM, ClsStatus) {
            document.getElementById('<%=btnTaskSave.ClientID%>').style.display = "none";
            document.getElementById('<%=btnTaskUpd.ClientID%>').style.display = "none";
            //for options in Task Subject
            var OptionsSbjct = document.getElementById("<%=divOptionsTaskSubject.ClientID%>").innerHTML;
            var DfltOptnSbjct = '<option  value="--SELECT SUBJECT--">--SELECT SUBJECT--</option>';
            var TotalOptnSbjct = "";
            if (OptionsSbjct == "") {
                TotalOptnSbjct = DfltOptnSbjct;
            }
            else {
                TotalOptnSbjct = DfltOptnSbjct + OptionsSbjct;
            }

            var TaskSbjctHtml = ' <select id="ddlTaskSubject"  class="form-control fg2_inp1  inp_mst" > ';
            //  </select> </td>
            TaskSbjctHtml += TotalOptnSbjct;
            TaskSbjctHtml += ' </select>  ';

            document.getElementById('SpanddlTask').innerHTML = TaskSbjctHtml;

           
            document.getElementById("ddlTaskSubject").style.borderColor = "";
            document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";

            document.getElementById("ddlTaskSubject").disabled = true;
            document.getElementById("<%=ddlTaskHr.ClientID%>").disabled = true;
            document.getElementById("<%=ddlTaskMin.ClientID%>").disabled = true;
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").disabled = true;
            document.getElementById("<%=txtTaskDate.ClientID%>").disabled = true;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").disabled = true;
            document.getElementById("<%=cbxTaskStatus.ClientID%>").disabled = true;
            document.getElementById("<%=ddlPlusWeek.ClientID%>").disabled = true;
           
            var desiredValueSbjct = TaskSubjctId;
            var elSbjct = document.getElementById("ddlTaskSubject");
            for (var i = 0; i < elSbjct.options.length; i++) {
                if (elSbjct.options[i].value == desiredValueSbjct) {
                    elSbjct.selectedIndex = i;
                    break;
                }
            }
            var TSbjct = document.getElementById("ddlTaskSubject").value;
            //  alert(LHead);
            if (TSbjct == "--SELECT SUBJECT--" || TSbjct == "") {
                //add option code
                $Mo("#ddlTaskSubject").append($Mo('<option>', {
                    value: TaskSubjctId,
                    text: TaskSubjctName
                }));
                var AdesiredValueSource = TaskSubjctId;
                var AelSbjct = document.getElementById("ddlTaskSubject");
                for (var i = 0; i < AelSbjct.options.length; i++) {
                    if (AelSbjct.options[i].value == AdesiredValueSource) {
                        AelSbjct.selectedIndex = i;
                        break;
                    }
                }
            }
            var desiredValueHr = TaskDueHr;
            var elHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
            for (var i = 0; i < elHr.options.length; i++) {
                if (elHr.options[i].value == desiredValueHr) {
                    elHr.selectedIndex = i;
                    break;
                }
            }

            var desiredValueMin = TaskDueMin;
            var elMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
                for (var i = 0; i < elMin.options.length; i++) {
                    if (elMin.options[i].value == desiredValueMin) {
                        elMin.selectedIndex = i;
                        break;
                    }
                }

                var desiredValueAMPM = TaskDueAM_PM;
                var elAMPM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
            for (var i = 0; i < elAMPM.options.length; i++) {
                if (elAMPM.options[i].value == desiredValueAMPM) {
                    elAMPM.selectedIndex = i;
                    break;
                }
            }
            var desiredValueWeekSelect = "--Select Week--";
            var elWk = document.getElementById("<%=ddlPlusWeek.ClientID%>");
            for (var i = 0; i < elWk.options.length; i++) {
                if (elWk.options[i].value == desiredValueWeekSelect) {
                    elWk.selectedIndex = i;
                    break;
                }
            }
            document.getElementById("<%=txtTaskDate.ClientID%>").value = TaskDueDate;
            document.getElementById("<%=txtTaskDescptn.ClientID%>").value = Descptn;

            if (TaskSts == 'ACTIVE') {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = true;

            }
            else {
                document.getElementById("<%=cbxTaskStatus.ClientID%>").checked = false;
            }

            if (ClsStatus == 'CLOSE') {

               
                document.getElementById('divTaskClsDate').style.display = "";
                document.getElementById('divTaskClsTime').style.display = "";
                document.getElementById("<%=txtClsTaskDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlClsTaskHr.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlClsTaskMin.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlClsTaskAM_PM.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtClsTaskDate.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlClsTaskHr.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlClsTaskMin.ClientID%>").disabled = true;
                    document.getElementById("<%=ddlClsTaskAM_PM.ClientID%>").disabled = true;


                    var desiredValueClsHr = TaskClsHr;
                    var elClsHr = document.getElementById("<%=ddlClsTaskHr.ClientID%>");
                for (var i = 0; i < elClsHr.options.length; i++) {
                    if (elClsHr.options[i].value == desiredValueClsHr) {
                        elClsHr.selectedIndex = i;
                        break;
                    }
                }

                var desiredValueClsMin = TaskClsMin;
                var elClsMin = document.getElementById("<%=ddlClsTaskMin.ClientID%>");
                for (var i = 0; i < elClsMin.options.length; i++) {
                    if (elClsMin.options[i].value == desiredValueClsMin) {
                        elClsMin.selectedIndex = i;
                        break;
                    }
                }

                var desiredValueClsAMPM = TaskClsAM_PM;
                var elClsAMPM = document.getElementById("<%=ddlClsTaskAM_PM.ClientID%>");
                for (var i = 0; i < elClsAMPM.options.length; i++) {
                    if (elClsAMPM.options[i].value == desiredValueClsAMPM) {
                        elClsAMPM.selectedIndex = i;
                        break;
                    }
                }
                document.getElementById("<%=txtClsTaskDate.ClientID%>").value = TaskClsDate;
            }
            else if (ClsStatus == 'OPEN') {              
                document.getElementById('divTaskClsDate').style.display = "none";
                document.getElementById('divTaskClsTime').style.display = "none";
            }
            document.getElementById("H2").innerText = "View Follow-Up / Task";
            return false;
        }
        function CloseModalTask() {          
            if (document.getElementById('<%=btnTaskSave.ClientID%>').style.display == "none" && document.getElementById('<%=btnTaskUpd.ClientID%>').style.display == "none") {
                document.getElementById("<%=txtTaskDate.ClientID%>").value = "";
                document.getElementById("<%=txtTaskDescptn.ClientID%>").value = ""; 
                $('#myModal_3').modal('hide');
                document.getElementById('<%=hiddenTaskId.ClientID%>').value = "";
                return false;
            }
            else {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to close?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=txtTaskDate.ClientID%>").value = "";
                        document.getElementById("<%=txtTaskDescptn.ClientID%>").value = "";
                        $('#myModal_3').modal('hide');
                     
                        document.getElementById('<%=hiddenTaskId.ClientID%>').value = "";
                        return false;
                    }
                    else {
                        return false;
                    }
                });
            }
            return false;
        }
        function CheckTask() {
            var ret = true;
            document.getElementById("<%=hiddenTaskSubjctId.ClientID%>").value = "";
            var TDateWithoutReplace = document.getElementById("<%=txtTaskDate.ClientID%>").value;
            var TDatereplaceText1 = TDateWithoutReplace.replace(/</g, "");
            var TDatereplaceText2 = TDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTaskDate.ClientID%>").value = TDatereplaceText2;

            var TdescWithoutReplace = document.getElementById("<%=txtTaskDescptn.ClientID%>").value;
            var TdescreplaceText1 = TdescWithoutReplace.replace(/</g, "");
            var TdescreplaceText2 = TdescreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtTaskDescptn.ClientID%>").value = TdescreplaceText2;

            document.getElementById("ddlTaskSubject").style.borderColor = "";
            document.getElementById("<%=ddlTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlTask_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "";


            var DropdownListSbjct = document.getElementById("ddlTaskSubject");
            var SelectedValueSbjct = DropdownListSbjct.value;
            document.getElementById("<%=hiddenTaskSubjctId.ClientID%>").value = SelectedValueSbjct;
            var HiddenSbjct = document.getElementById("<%=hiddenTaskSubjctId.ClientID%>").value
            var TDescptn = document.getElementById("<%=txtTaskDescptn.ClientID%>").value;

            //date
            var Taskdate = document.getElementById("<%=txtTaskDate.ClientID%>").value;

            var Tdata = Taskdate.split("-");



            if (isNaN(Date.parse(Tdata[2] + "-" + Tdata[1] + "-" + Tdata[0])) || SelectedValueSbjct == "--SELECT SUBJECT--" || HiddenSbjct == "--SELECT SUBJECT--" || HiddenSbjct == "" || TDescptn.length > 500) {

                $("#divErrorRsnTask").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                });

               
                if (SelectedValueSbjct == "--SELECT SUBJECT--") {
                    document.getElementById("ddlTaskSubject").focus();
                    document.getElementById("ddlTaskSubject").style.borderColor = "Red";
                    ret = false;
                }
                // using ISO 8601 Date String
                if (isNaN(Date.parse(Tdata[2] + "-" + Tdata[1] + "-" + Tdata[0]))) {
                    document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaskDate.ClientID%>").focus();
                    ret = false;
                }
                if (TDescptn.length > 500) {
                    document.getElementById("<%=txtTaskDescptn.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaskDescptn.ClientID%>").focus();
                    ret = false;
                }
            }

            if (ret == true) {
                //// AFTER if validation is true in above case
                //check if software date is less than current date
                var TaskdatepickerDate = document.getElementById("<%=txtTaskDate.ClientID%>").value;
                var arrDatePickerDate = TaskdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                //   alert('dateDateCntrlr ' + dateDateCntrlr);
                // alert('dateCurrentDate ' + dateCurrentDate);
                if (dateDateCntrlr < dateCurrentDate) {
                    document.getElementById("<%=txtTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtTaskDate.ClientID%>").focus();
                    $("#divErrorRsnTask").html("Sorry, Follow-Up/Task due date cannot be less than current date !.");
                    $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                    });
                  
                    ret = false;
                }
                else if (dateDateCntrlr > dateCurrentDate) {
                    // alert('greater');
                }

                else {
                    var CurrentDate = new Date();
                    //  alert(CurrentDate);
                    var hours = CurrentDate.getHours();

                    var minutes = ("0" + (CurrentDate.getMinutes())).slice(-2);

                    var DropdownListHr = document.getElementById("<%=ddlTaskHr.ClientID%>");
                    var SelectedValueHr = DropdownListHr.value;

                    var DropdownListMin = document.getElementById("<%=ddlTaskMin.ClientID%>");
                    var SelectedValueMin = DropdownListMin.value;

                    var DropdownListAM_PM = document.getElementById("<%=ddlTask_AM_PM.ClientID%>");
                    var SelectedValueAM_PM = DropdownListAM_PM.value;


                    if (SelectedValueAM_PM == "PM" && SelectedValueHr != 12) {

                        SelectedValueHr = parseInt(SelectedValueHr) + 12;
                    }
                    if (SelectedValueAM_PM == "AM" && SelectedValueHr == 12) {

                        SelectedValueHr = 0;
                    }
                    SelectedValueHr = parseInt(SelectedValueHr);
                    SelectedValueMin = parseInt(SelectedValueMin);
                    // alert('SelectedValueHr ' + SelectedValueHr);
                    //  alert('SelectedValueMin ' + SelectedValueMin);

                    if (hours > SelectedValueHr) {
                        $("#divErrorRsnTask").html("Sorry, Follow-Up/Task due time cannot be less than current time !.");
                        $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                        });

                        ret = false;
                    }
                    else if (hours == SelectedValueHr) {
                        if (minutes > SelectedValueMin) {
                            $("#divErrorRsnTask").html("Sorry, Follow-Up/Task due time cannot be less than current time !.");
                            $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                            });
                            ret = false;

                        }

                    }

            }
    }
            if (ret == true) {
                $('#myModal_3').modal('hide');
     
            }
    return ret;
}
</script>



    <%-----------------------------------------------------FOR CANCEL TASK------------------------------------------------------------------%>

    <script>
        var $Mo = jQuery.noConflict();
        function OpenModalCancelTask(objname, subEvent, TaskId, TaskInsDate, TaskInsHr, TaskInsMin, TaskInsAM_PM, TaskCurDate, TaskCurHr, TaskCurMin, TaskCurAM_PM) {

            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close this Follow-Up/Task?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById('<%=btnCancelTaskSave.ClientID%>').style.visibility = "visible";
                    document.getElementById('<%=hiddenTaskId.ClientID%>').value = TaskId;
               
                document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>").value = '';
                    document.getElementById("<%=lblACancelTaskHr.ClientID%>").value = '';
                    document.getElementById("<%=lblACancelTaskMin.ClientID%>").value = '';



                   

                document.getElementById("<%=ddlCCancelTaskHr.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlCCancelTaskMin.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "";


                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").disabled = true;

                    $('#myModal_3_cls').modal('show');
                  

                    document.getElementById("<%=lblACancelTaskHr.ClientID%>").value = TaskInsHr;

                    document.getElementById("<%=lblACancelTaskMin.ClientID%>").value = TaskInsMin;

                    document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>").value = TaskInsAM_PM;



                    var desiredValueCHr = TaskCurHr;
                    var elCHr = document.getElementById("<%=ddlCCancelTaskHr.ClientID%>");
                for (var i = 0; i < elCHr.options.length; i++) {
                    if (elCHr.options[i].value == desiredValueCHr) {
                        elCHr.selectedIndex = i;
                        break;
                    }
                }

                var desiredValueCMin = TaskCurMin;
                var elCMin = document.getElementById("<%=ddlCCancelTaskMin.ClientID%>");
                for (var i = 0; i < elCMin.options.length; i++) {
                    if (elCMin.options[i].value == desiredValueCMin) {
                        elCMin.selectedIndex = i;
                        break;
                    }
                }

                var desiredValueC_AMPM = TaskCurAM_PM;
                var elC_AMPM = document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>");
                for (var i = 0; i < elC_AMPM.options.length; i++) {
                    if (elC_AMPM.options[i].value == desiredValueC_AMPM) {
                        elC_AMPM.selectedIndex = i;
                        break;
                    }
                }
                document.getElementById("<%=txtACancelTaskDate.ClientID%>").value = TaskInsDate;
                document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value = TaskCurDate;


                    return false;
                    }
                    else {
                        return false;
                    }
                });
            return false;
        }


        function CloseModalCancelTask() {
            //   alert('close');
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without completing  closing process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").value = "";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value = ""; 
                    $('#myModal_3_cls').modal('hide');
                    document.getElementById('<%=hiddenTaskId.ClientID%>').value = "";
                    return false;
                    }
                    else {
                        return false;
                    }
                });
            return false;

        }
        function CheckCancelTask() {
            // alert('CheckFollowUp');
            var ret = true;          
            // replacing < and > tags

            var ATDateWithoutReplace = document.getElementById("<%=txtACancelTaskDate.ClientID%>").value;
            var ATDatereplaceText1 = ATDateWithoutReplace.replace(/</g, "");
            var ATDatereplaceText2 = ATDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtACancelTaskDate.ClientID%>").value = ATDatereplaceText2;

            var CTDateWithoutReplace = document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value;
            var CTDatereplaceText1 = CTDateWithoutReplace.replace(/</g, "");
            var CTDatereplaceText2 = CTDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value = CTDatereplaceText2;

            document.getElementById("<%=txtACancelTaskDate.ClientID%>").style.borderColor = "";

            document.getElementById("<%=ddlCCancelTaskHr.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCCancelTaskMin.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "";

            //date
            var ATaskdate = document.getElementById("<%=txtACancelTaskDate.ClientID%>").value;
            var CTaskdate = document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value;

            var ATdata = ATaskdate.split("-");
            var CTdata = CTaskdate.split("-");

           

            if (isNaN(Date.parse(CTdata[2] + "-" + CTdata[1] + "-" + CTdata[0]))) {
                $("#divErrorRsnCancelTask").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                });

              
                //   alert(isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])));
                //  alert(SelectedValueSrc);



                // using ISO 8601 Date String
                if (isNaN(Date.parse(CTdata[2] + "-" + CTdata[1] + "-" + CTdata[0]))) {
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").focus();
                    ret = false;

                }


            }

            if (ret == true) {
                //// AFTER if validation is true in above case
                //check if software date is less than current date
                var CTaskdatepickerDate = document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value;
                    var CarrDatePickerDate = CTaskdatepickerDate.split("-");
                    var CdateDateCntrlr = new Date(CarrDatePickerDate[2], CarrDatePickerDate[1] - 1, CarrDatePickerDate[0]);

                    var ATaskdatepickerDate = document.getElementById("<%=txtACancelTaskDate.ClientID%>").value;
                    var AarrDatePickerDate = ATaskdatepickerDate.split("-");
                    var AdateDateCntrlr = new Date(AarrDatePickerDate[2], AarrDatePickerDate[1] - 1, AarrDatePickerDate[0]);

                    var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                    //   alert('dateDateCntrlr ' + dateDateCntrlr);
                    // alert('dateCurrentDate ' + dateCurrentDate);
                if (CdateDateCntrlr < AdateDateCntrlr) {
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").focus();
                    $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed date cannot be less than inserted date !.");
                    $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                    });                 
                    ret = false;
                }
                else if (CdateDateCntrlr > dateCurrentDate) {
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").focus();
                    $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed date cannot be greater than current date !.");
                    $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                    });
                    ret = false;
                }
            if (ret == true) {


                if (CTaskdatepickerDate == ATaskdatepickerDate) {

                    var AlblListHr = document.getElementById("<%=lblACancelTaskHr.ClientID%>");
                    var ASelectedValueHr = AlblListHr.innerHTML;

                    var AlblListMin = document.getElementById("<%=lblACancelTaskMin.ClientID%>");
                    var ASelectedValueMin = AlblListMin.innerHTML;

                    var AlblListAM_PM = document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>");
                    var ASelectedValueAM_PM = AlblListAM_PM.innerHTML;

                    var CDropdownListHr = document.getElementById("<%=ddlCCancelTaskHr.ClientID%>");
                    var CSelectedValueHr = CDropdownListHr.value;

                    var CDropdownListMin = document.getElementById("<%=ddlCCancelTaskMin.ClientID%>");
                    var CSelectedValueMin = CDropdownListMin.value;

                    var CDropdownListAM_PM = document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>");
                    var CSelectedValueAM_PM = CDropdownListAM_PM.value;


                    if (CSelectedValueAM_PM == "PM" && CSelectedValueHr != 12) {

                        CSelectedValueHr = parseInt(CSelectedValueHr) + 12;
                    }
                    if (CSelectedValueAM_PM == "AM" && CSelectedValueHr == 12) {

                        CSelectedValueHr = 0;
                    }
                    if (ASelectedValueAM_PM == "PM" && ASelectedValueHr != 12) {

                        ASelectedValueHr = parseInt(ASelectedValueHr) + 12;
                    }
                    if (ASelectedValueAM_PM == "AM" && ASelectedValueHr == 12) {

                        ASelectedValueHr = 0;
                    }
                    CSelectedValueHr = parseInt(CSelectedValueHr);
                    CSelectedValueMin = parseInt(CSelectedValueMin);

                    ASelectedValueHr = parseInt(ASelectedValueHr);
                    ASelectedValueMin = parseInt(ASelectedValueMin);
                    // alert('SelectedValueHr ' + SelectedValueHr);
                    //  alert('SelectedValueMin ' + SelectedValueMin);

                    if (ASelectedValueHr > CSelectedValueHr) {
                        $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be less than inserted time !.");
                        $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                        });
                            ret = false;
                        }
                        else if (ASelectedValueHr == CSelectedValueHr) {
                            if (ASelectedValueMin > CSelectedValueMin) {
                                $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be less than inserted time !.");
                                $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                                });
                                ret = false;

                            }

                        }

                }
                if (ret == true) {

                    if (CTaskdatepickerDate == CurrentDateDate) {
                        var CurrentDate = new Date();
                        //  alert(CurrentDate);
                        var hours = CurrentDate.getHours();

                        var minutes = ("0" + (CurrentDate.getMinutes())).slice(-2);

                        var DropdownListHr = document.getElementById("<%=ddlCCancelTaskHr.ClientID%>");
                        var SelectedValueHr = DropdownListHr.value;

                        var DropdownListMin = document.getElementById("<%=ddlCCancelTaskMin.ClientID%>");
                        var SelectedValueMin = DropdownListMin.value;

                        var DropdownListAM_PM = document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>");
                        var SelectedValueAM_PM = DropdownListAM_PM.value;


                        if (SelectedValueAM_PM == "PM" && SelectedValueHr != 12) {

                            SelectedValueHr = parseInt(SelectedValueHr) + 12;
                        }
                        if (SelectedValueAM_PM == "AM" && SelectedValueHr == 12) {

                            SelectedValueHr = 0;
                        }
                        SelectedValueHr = parseInt(SelectedValueHr);
                        SelectedValueMin = parseInt(SelectedValueMin);
                        //   alert('SelectedValueHr ' + SelectedValueHr);
                        //  alert('SelectedValueMin ' + SelectedValueMin);

                        if (hours < SelectedValueHr) {
                            $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be greater than current time !.");
                            $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                            });                         
                            ret = false;
                        }
                        else if (hours == SelectedValueHr) {
                            if (minutes < SelectedValueMin) {
                                $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task completed time cannot be greater than current time !.");
                                $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                                });                      
                                ret = false;
                            }
                        }
                }
            }

        }
    }
            if (ret == true) {
                $('#myModal_3_cls').modal('hide');
    }
    return ret;
        }
        function isNumberDate(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                return false;
            }
                //dash
            else if (keyCodes == 173) {
                return true;
            }
                //0-9
            else if (keyCodes >= 48 && keyCodes <= 57) {
                return true;
            }
                //numpad 0-9
            else if (keyCodes >= 96 && keyCodes <= 105) {
                return true;
            }
                //left arrow key,right arrow key,home,end ,delete
            else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46) {
                return true;

            }
            else {
                var ret = true;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                    ret = false;
                }
                return ret;
            }
        }
</script>
     <%-----------------------------------------------------FOR FOLLOW UP------------------------------------------------------------------%>



    <script>
        var $Mo = jQuery.noConflict();
        function OpenModalFollowUp(objname, subEvent) {
            document.getElementById('<%=btnFollowUpSave.ClientID%>').style.visibility = "visible";
            var OptionsSrc = document.getElementById("<%=divOptionsLeadSource.ClientID%>").innerHTML;
            var DfltOptnSrc = '<option  value="--SELECT--">--SELECT--</option>';
            var TotalOptnSrc = "";
            if (OptionsSrc == "") {
                TotalOptnSrc = DfltOptnSrc;
            }
            else {

                TotalOptnSrc = DfltOptnSrc + OptionsSrc;

            }
            var LeadSrcHtml = ' <select id="ddlFollowUpLeadSource"  class="form-control fg2_inp1 inp_mst" > ';
            //  </select> </td>
            LeadSrcHtml += TotalOptnSrc;
            LeadSrcHtml += ' </select>  ';
            document.getElementById('SpanddlFollowUp').innerHTML = LeadSrcHtml;

            document.getElementById("ddlFollowUpLeadSource").style.borderColor = "";
            document.getElementById("<%=txtFollowUpDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtFollowUpDescptn.ClientID%>").style.borderColor = "";
            document.getElementById("ddlFollowUpLeadSource").disabled = false;
            document.getElementById("<%=txtFollowUpDate.ClientID%>").disabled = false;
            document.getElementById("<%=txtFollowUpDescptn.ClientID%>").disabled = false;           
            var desiredValueSource = "--SELECT--";
            var elSrc = document.getElementById("ddlFollowUpLeadSource");
            for (var i = 0; i < elSrc.options.length; i++) {
                if (elSrc.options[i].value == desiredValueSource) {
                    elSrc.selectedIndex = i;
                    break;
                }
            }
            document.getElementById("<%=txtFollowUpDate.ClientID%>").value = "";
            document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value = "";
            document.getElementById("ddlFollowUpLeadSource").focus();
            return false;
        }
        function CloseModalFollowUp() {
            //   alert('close');
            if (document.getElementById('<%=btnFollowUpSave.ClientID%>').style.visibility == "hidden") {
                document.getElementById("<%=txtFollowUpDate.ClientID%>").value = "";
                document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value = "";
                $('#myModal_2').modal('hide');
                return false;
            }
            else {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Are you sure you want to close?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        document.getElementById("<%=txtFollowUpDate.ClientID%>").value = "";
                        document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value = "";   
                        $('#myModal_2').modal('hide');
                    return false;
                }
                else {
                    return false;
                }
            });
            }
            return false;
        }
        function CheckFollowUp() {
            // alert('CheckFollowUp');
            var ret = true;         
            document.getElementById("<%=hiddenFollowUpSrcId.ClientID%>").value = "";
            // replacing < and > tags


            var FDateWithoutReplace = document.getElementById("<%=txtFollowUpDate.ClientID%>").value;
            var FDatereplaceText1 = FDateWithoutReplace.replace(/</g, "");
            var FDatereplaceText2 = FDatereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFollowUpDate.ClientID%>").value = FDatereplaceText2;

            var FdescWithoutReplace = document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value;
            var FdescreplaceText1 = FdescWithoutReplace.replace(/</g, "");
            var FdescreplaceText2 = FdescreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value = FdescreplaceText2;


            document.getElementById("ddlFollowUpLeadSource").style.borderColor = "";
            document.getElementById("<%=txtFollowUpDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtFollowUpDescptn.ClientID%>").style.borderColor = "";


            var DropdownListSrc = document.getElementById("ddlFollowUpLeadSource");
            var SelectedValueSrc = DropdownListSrc.value;
            document.getElementById("<%=hiddenFollowUpSrcId.ClientID%>").value = SelectedValueSrc;
            var HiddenSrc = document.getElementById("<%=hiddenFollowUpSrcId.ClientID%>").value
            var FDescptn = document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value;


            //date
            var FollowUpdate = document.getElementById("<%=txtFollowUpDate.ClientID%>").value;

            var Fdata = FollowUpdate.split("-");



            if (isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])) || SelectedValueSrc == "--SELECT--" || HiddenSrc == "--SELECT--" || HiddenSrc == "" || FDescptn == "" || FDescptn.length > 1000) {
                $("#divErrorRsnFollowUp").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnFollowUp").fadeTo(3000, 500).slideUp(500, function () {
                });             
                //   alert(isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])));
                //  alert(SelectedValueSrc);
                if (SelectedValueSrc == "--SELECT--") {

                    document.getElementById("ddlFollowUpLeadSource").focus();

                    document.getElementById("ddlFollowUpLeadSource").style.borderColor = "Red";
                    ret = false;
                }


                // using ISO 8601 Date String
                if (isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0]))) {
                    document.getElementById("<%=txtFollowUpDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFollowUpDate.ClientID%>").focus();
                    ret = false;

                }


                if (FDescptn == "" || FDescptn.length > 1000) {
                    document.getElementById("<%=txtFollowUpDescptn.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFollowUpDescptn.ClientID%>").focus();
                    ret = false;

                }

            }

            if (ret == true) {
                //// AFTER if validation is true in above case
                //check if software date is less than current date
                var FollowUpdatepickerDate = document.getElementById("<%=txtFollowUpDate.ClientID%>").value;
                var arrDatePickerDate = FollowUpdatepickerDate.split("-");
                var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                var arrCurrentDate = CurrentDateDate.split("-");
                var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);


                if (dateDateCntrlr > dateCurrentDate) {
                    document.getElementById("<%=txtFollowUpDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtFollowUpDate.ClientID%>").focus();
                    $("#divErrorRsnFollowUp").html("Sorry,  Date cannot be greater than current date !.");
                    $("#divErrorRsnFollowUp").fadeTo(3000, 500).slideUp(500, function () {
                    });                  
                    ret = false;
                }

            }
            if (ret == true) {
                $('#myModal_2').modal('hide');
            }
            return ret;
        }
    </script>
      <%-----------------------------------------------------FOR ReopenReason------------------------------------------------------------------%>

    <script>

        var $Mo = jQuery.noConflict();
        function OpenModalReopenReason() {

            document.getElementById('<%=btnReopenReasonSave.ClientID%>').style.visibility = "visible";
            //for options in Task Subject
            var OptionsRsn = document.getElementById("<%=divOptionsReopenReason.ClientID%>").innerHTML;
            var DfltOptnRsn = '<option  value="--SELECT REASON--">--SELECT REASON--</option>';
            var TotalOptnRsn = "";
            if (OptionsRsn == "") {
                TotalOptnRsn = DfltOptnRsn;
            }
            else {
                TotalOptnRsn = DfltOptnRsn + OptionsRsn;
            }

            var ReopenReasonHtml = ' <select id="ddlReopenReason"  class="form-control fg2_inp1 inp_mst reop_op1" > ';
            //  </select> </td>
            ReopenReasonHtml += TotalOptnRsn;
            ReopenReasonHtml += ' </select>  ';
            document.getElementById('SpanddlReopenReason').innerHTML = ReopenReasonHtml;
           
            document.getElementById("ddlReopenReason").style.borderColor = "";
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").style.borderColor = "";
            document.getElementById("ddlReopenReason").disabled = false;
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").disabled = false;
            $('#reopen_qoute_box').modal('show');         
            var desiredValueRsn = "--SELECT REASON--";
            var elRsn = document.getElementById("ddlReopenReason");
            for (var i = 0; i < elRsn.options.length; i++) {
                if (elRsn.options[i].value == desiredValueRsn) {
                    elRsn.selectedIndex = i;
                    break;
                }
            }
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = "";
            document.getElementById("ddlReopenReason").focus();
            return false;
        }

        function CloseModalReopenReason() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to close?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = "";
                    $('#reopen_qoute_box').modal('hide');
                    return false;
                    }
                    else {
                        return false;
                }
            });
           return false;
        }
        function CheckReopenReason() {
            var ret = true;           
            document.getElementById("<%=hiddenReopenReasonId.ClientID%>").value = "";
            // replacing < and > tags
            var RdescWithoutReplace = document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value;
            var RdescreplaceText1 = RdescWithoutReplace.replace(/</g, "");
            var RdescreplaceText2 = RdescreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = RdescreplaceText2;

            document.getElementById("ddlReopenReason").style.borderColor = "";
            document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").style.borderColor = "";


                var DropdownListRsn = document.getElementById("ddlReopenReason");
                var SelectedValueRsn = DropdownListRsn.value;
                document.getElementById("<%=hiddenReopenReasonId.ClientID%>").value = SelectedValueRsn;
                var HiddenRsn = document.getElementById("<%=hiddenReopenReasonId.ClientID%>").value
            var RDescptn = document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value;



          

            if (SelectedValueRsn == "--SELECT REASON--" || HiddenRsn == "--SELECT REASON--" || HiddenRsn == "") {
               
                $("#divErrorRsnReopenReason").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnReopenReason").fadeTo(3000, 500).slideUp(500, function () {
                });
               

                    if (SelectedValueRsn == "--SELECT REASON--") {

                        document.getElementById("ddlReopenReason").focus();

                        document.getElementById("ddlReopenReason").style.borderColor = "Red";
                        ret = false;
                    }
                }
                if (ret == true) {
                    $('#reopen_qoute_box').modal('hide');
                }               
                return ret;
            }
    </script>
    
    <%-----------------------------------------------------FOR LossReason------------------------------------------------------------------%>



    <script>

        var $Mo = jQuery.noConflict();
        function OpenModalLossReason() {           
                document.getElementById('<%=btnLossReasonSave.ClientID%>').style.visibility = "visible";
                //for options in Task Subject
                var OptionsRsn = document.getElementById("<%=divOptionsLossReason.ClientID%>").innerHTML;
                var DfltOptnRsn = '<option  value="--SELECT REASON--">--SELECT REASON--</option>';
                var TotalOptnRsn = "";
                if (OptionsRsn == "") {
                    TotalOptnRsn = DfltOptnRsn;
                }
                else {

                    TotalOptnRsn = DfltOptnRsn + OptionsRsn;

                }

                var LossReasonHtml = ' <select id="ddlLossReason"  class="form-control fg2_inp1 fg_chs1 inp_mst loss_op1" > ';
                //  </select> </td>
                LossReasonHtml += TotalOptnRsn;
                LossReasonHtml += ' </select>  ';

                document.getElementById('SpanddlLossReason').innerHTML = LossReasonHtml;


                document.getElementById("ddlLossReason").style.borderColor = "";
                document.getElementById("<%=txtLossReasonDescptn.ClientID%>").style.borderColor = "";

                document.getElementById("ddlLossReason").disabled = false;
                document.getElementById("<%=txtLossReasonDescptn.ClientID%>").disabled = false;
                $('#loss_info').modal('show');
                         
                var desiredValueRsn = "--SELECT REASON--";

                var elRsn = document.getElementById("ddlLossReason");
                for (var i = 0; i < elRsn.options.length; i++) {
                    if (elRsn.options[i].value == desiredValueRsn) {
                        elRsn.selectedIndex = i;
                        break;
                    }
                }
                document.getElementById("<%=txtLossReasonDescptn.ClientID%>").value = "";
                document.getElementById("ddlLossReason").focus();
                return false;
        }




        function CloseModalLossReason() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to close?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                document.getElementById("<%=txtLossReasonDescptn.ClientID%>").value = "";                                  
                $('#loss_info').modal('hide');
                return false;
                }
                else {
                    return false;
                }
            });           
            return false;
        }
        function CheckLossReason() {
            var ret = true;           
            document.getElementById("<%=hiddenLossReasonId.ClientID%>").value = "";
            // replacing < and > tags

            var RdescWithoutReplace = document.getElementById("<%=txtLossReasonDescptn.ClientID%>").value;
            var RdescreplaceText1 = RdescWithoutReplace.replace(/</g, "");
            var RdescreplaceText2 = RdescreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtLossReasonDescptn.ClientID%>").value = RdescreplaceText2;



            document.getElementById("ddlLossReason").style.borderColor = "";
            document.getElementById("<%=txtLossReasonDescptn.ClientID%>").style.borderColor = "";


            var DropdownListRsn = document.getElementById("ddlLossReason");
            var SelectedValueRsn = DropdownListRsn.value;
            document.getElementById("<%=hiddenLossReasonId.ClientID%>").value = SelectedValueRsn;
            var HiddenRsn = document.getElementById("<%=hiddenLossReasonId.ClientID%>").value
            var RDescptn = document.getElementById("<%=txtLossReasonDescptn.ClientID%>").value;




            if (SelectedValueRsn == "--SELECT REASON--" || HiddenRsn == "--SELECT REASON--" || HiddenRsn == "") {
                $("#divErrorRsnLossReason").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnLossReason").fadeTo(3000, 500).slideUp(500, function () {
                });
              
              
                //   alert(isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])));
                //  alert(SelectedValueSrc);
                if (SelectedValueRsn == "--SELECT REASON--") {
                    document.getElementById("ddlLossReason").focus();
                    document.getElementById("ddlLossReason").style.borderColor = "Red";
                    ret = false;
                }
            }
            if (ret == true) {
                $('#loss_info').modal('hide');               
            }
            return ret;
        }
    </script>
    <script>
        function OpenQuotationSts(leadId) {
            $Mo.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "gen_LeadList.aspx/QuotanStsLoad",
            data: '{strLeadId: "' + leadId + '"}',
            dataType: "json",
            success: function (data) {
                document.getElementById('ulSts' + leadId).innerHTML = data.d;
            },
            error: function (result) {
            }
        });
        return false;
    }
        function ChangeQuotSts(Stsid, stsName, leadId) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to change the status ?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $Mo.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_LeadList.aspx/QuotanStsSave",
                        data: '{strLeadId: "' + leadId + '",strId: "' + Stsid + '",strName: "' + stsName + '"}',
                        dataType: "json",
                        success: function (data) {                           
                            window.location.href = 'gen_LeadList.aspx?InsUpd=StsChange';
                    },
                    error: function (result) {
                        // alert("Error");
                    }
                });
                    return false;
                }
                else {
                    return false;
                }
            });
            return false;      
       }
            function SuccessStatusChange() {
                $("#success-alert").html("Quotation status changed successfully.");
                $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
                });               
            }
    </script>
    <script>
        var $dat = jQuery.noConflict();
        function OpenPartial_Win() {
            $('#par_win_box').modal('show');
           
                     var QtnId = document.getElementById("<%=hiddenLeadId.ClientID%>").value;
                     var TempTyp = document.getElementById("<%=hiddenQtnTmpltId.ClientID%>").value;
                     var OrgId = '<%= Session["ORGID"] %>';
                    var CorpId = '<%= Session["CORPOFFICEID"] %>';                  
                    var TaxEnable = document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value;
                    var ProductGroupId = document.getElementById("<%=ddlProductGroup.ClientID%>").value;

                    $Mo.ajax({
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "gen_LeadList.aspx/PartWinProductsLoad",
                        data: '{strOrgId: "' + OrgId + '",strCorpId: "' + CorpId + '",strQtnId: "' + QtnId + '",strTempTyp: "' + TempTyp + '",strTaxEnable: "' + TaxEnable + '",strPrdctGroup: "' + ProductGroupId + '"}',
                        dataType: "json",
                        success: function (data) {
                            document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value = data.d[3];
                            document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value = data.d[2];
                            document.getElementById('divProductTableContainer').innerHTML = data.d[0];
                            document.getElementById('txtTotalWinAmount').value = data.d[1];
                            var table = $dat('#ReportTableForPartial').DataTable({
                                select: true,
                            });

                            $dat('#btnPartialWinAmount').on('click', function () {

                                var WinAmount = 0;
                                table.rows('.selected').data().each(function (rowIdx) {
                                    if (TaxEnable == 0) {
                                        WinAmount = parseFloat(WinAmount) + parseFloat(rowIdx[8]);
                                    } else {
                                        WinAmount = parseFloat(WinAmount) + parseFloat(rowIdx[10]);
                                    }
                                });

                                var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                            if (FloatingValue != "") {
                                WinAmount = WinAmount.toFixed(FloatingValue);
                            }
                            document.getElementById('cphMain_txtPartnWinAmount').value = WinAmount;
                            return false;
                        });

                }


            });
             return false;
            }

            function ClosePrtlWinContnr() {
                $('#par_win_box').modal('hide');
            }

            function PartialWinClient() {
            var TaxEnable = document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value;
            var PrdctIds = "";
            var table = $dat('#ReportTableForPartial').DataTable();
            if (table.rows('.selected').data().length == 0) {
                return false;
            }
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure to win with the selected products?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var WinAmount = 0;
                    table.rows('.selected').data().each(function (rowIdx) {
                        PrdctIds = PrdctIds + "," + rowIdx[0];
                        if (TaxEnable == 0) {
                            WinAmount = parseFloat(WinAmount) + parseFloat(rowIdx[8]);
                        } else {
                            WinAmount = parseFloat(WinAmount) + parseFloat(rowIdx[10]);
                        }
                    });

                    document.getElementById("<%=hiddenPartialWinIds.ClientID%>").value = PrdctIds;
                     var FloatingValue = document.getElementById("<%=hiddenFloatingValueMoney.ClientID%>").value;
                    if (FloatingValue != "") {
                        WinAmount = WinAmount.toFixed(FloatingValue);
                    }
                    document.getElementById("<%=HiddenFieldtxtPartnWinAmount.ClientID%>").value = WinAmount;
                    document.getElementById('cphMain_txtPartnWinAmount').value = WinAmount;                                      
                    __doPostBack("<%=btnPartWin.UniqueID %>", "");                   
                    return false;
                }
                else {
                    document.getElementById("<%=hiddenPartialWinIds.ClientID%>").value = "";
                    return false;
                }
            });
            return false;          
        }
    </script>
      <%-------------------------------------------FOR MAIL----------------------------------------------------------%>
    <script>

        var $Mo = jQuery.noConflict();
        function ViewModalMail(objname, subEvent, LeadmailId, MailContent, MailSts, CcMailIds, BccMailIds, SubjectMail, MultyTo, from, toaddress, strSucessSts) {

            document.getElementById("<%=hiddenLeadMailId.ClientID%>").value = LeadmailId;

            if (strSucessSts == '1')//mail send successfully
            {
                document.getElementById("<%=btnReSendMail.ClientID%>").style.display = "none";
            }
            else {//mail sendng failed

                document.getElementById("<%=btnReSendMail.ClientID%>").style.display = "";
            }

            if (MailSts == 'IN') {
                document.getElementById("<%=btnMailReject.ClientID%>").style.display = "";
                document.getElementById("<%=btnReSendMail.ClientID%>").style.display = "none";
            }
            else {
                document.getElementById("<%=btnMailReject.ClientID%>").style.display = "none";
            }
            document.getElementById('divContent').innerHTML = "";
            document.getElementById("<%=txtMailContent.ClientID%>").style.display = "";
            document.getElementById("<%=btnSendMail.ClientID%>").style.display = "none";
            //document.getElementById('imgarrowLeftMail').style.visibility = "hidden";
            //document.getElementById('imgarrowRightMail').style.visibility = "visible";
            //document.getElementById("TableFileUploadContainer").innerHTML = "";
            localStorage.clear();
          
            document.getElementById('CloseBccImage').style.display = "none";
            document.getElementById('CloseCcimage').style.display = "none";

            document.getElementById('CcDescriptions').innerHTML = "View Cc Recipients"
            document.getElementById('BccDescriptions').innerHTML = "View Bcc Recipients"

            document.getElementById("<%=txtMailContent.ClientID%>").style.borderColor = "";

            document.getElementById("<%=txtMailContent.ClientID%>").readOnly = true;
            document.getElementById("<%=txtToAddress.ClientID%>").readOnly = true;
            document.getElementById("<%=txtCccontent.ClientID%>").readOnly = true;
            document.getElementById("<%=txtBCccontent.ClientID%>").readOnly = true;
            document.getElementById("<%=txtMailSubject.ClientID%>").readOnly = true;
            document.getElementById("<%=txtFromAdress.ClientID%>").readOnly = true;


            PageMethods.ReadMailAttachment(LeadmailId, function (response) {
                var Array = response;
                var ArrayLength = response.length;
                //    alert(ArrayLength);
                var Attcount = parseInt(0);
                var File = "";
                for (Attcount = 0; Attcount < parseInt(ArrayLength) ; Attcount++) {
                    var TransDtlId = Array[Attcount][0];
                    var FileName = Array[Attcount][1];
                    File = FileName;
                    var ActualFileName = Array[Attcount][2];
                    var MailSts = Array[Attcount][3];
                    //1 means its received mail
                    if (MailSts == 1) {
                        document.getElementById("<%=hiddenMailFilePath.ClientID%>").value = "/CustomImages/MailAttachments/";
                        document.getElementById('divContent').style.display = "";
                        document.getElementById("<%=txtMailContent.ClientID%>").style.display = "none";
                        document.getElementById('divContent').innerHTML = MailContent;
                        document.getElementById("<%=txtFromAdress.ClientID%>").value = from;
                        document.getElementById("<%=txtToAddress.ClientID%>").value = toaddress;
                        document.getElementById("<%=txtMailSubject.ClientID%>").value = SubjectMail;
                        document.getElementById('divCcContent').style.display = "none";
                        document.getElementById('divBCcContent').style.display = "none";

                    }
                    else {

                        document.getElementById("<%=txtFromAdress.ClientID%>").value = from;

                        document.getElementById("<%=hiddenMailFilePath.ClientID%>").value = "/CustomImages/LeadMailAttachments/";
                        document.getElementById('divContent').style.display = "none";
                        document.getElementById("<%=txtMailContent.ClientID%>").style.display = "";
                        document.getElementById("<%=txtMailContent.ClientID%>").value = MailContent;
                        if (CcMailIds != "" && CcMailIds != null) {
                            document.getElementById("<%=txtCccontent.ClientID%>").value = CcMailIds;
                            document.getElementById('divCcContent').style.display = "";
                        }
                        else {
                            document.getElementById('divCcContent').style.display = "none";

                        }
                        if (BccMailIds != "" && BccMailIds != null) {
                            document.getElementById("<%=txtBCccontent.ClientID%>").value = BccMailIds;
                            document.getElementById('divBCcContent').style.display = "";
                        }
                        else {
                            document.getElementById('divBCcContent').style.display = "none";
                        }
                        document.getElementById("<%=txtMailSubject.ClientID%>").value = SubjectMail;

                        if (MultyTo != "") {
                            document.getElementById("<%=txtToAddress.ClientID%>").value = toaddress + "," + MultyTo;
                        }
                        else {
                            document.getElementById("<%=txtToAddress.ClientID%>").value = toaddress;
                        }
                    }
                    if (TransDtlId != "") {
                        ViewAttachment(TransDtlId, FileName, ActualFileName);
                    }
                }

                if (File == "") {
                    //  document.getElementById('divAttachmentHeading').innerHTML = "No Attachments";
                    document.getElementById('divAttachmentHeading').style.display = "none";
                }
                else {
                    document.getElementById('divAttachmentHeading').style.visibility = "";
                }
            });
            return false;
        }

        function CloseModalMail() {
            if (document.getElementById('<%=btnSendMail.ClientID%>').style.display == "none" && document.getElementById('<%=btnReSendMail.ClientID%>').style.display == "none") {

                $('#send_mail').modal('hide');
                document.getElementById('divCcHelper').style.display = "none";
                document.getElementById('divBCcHelper').style.display = "none";
                document.getElementById('divCcContent').style.display = "none";
                document.getElementById('divBCcContent').style.display = "none";
                document.getElementById('divContent').innerHTML = "";
                document.getElementById('divContent').style.display = "none";
                document.getElementById("<%=txtMailContent.ClientID%>").style.display = ""
                return false;

            }
            else {
                ezBSAlert({
                    type: "confirm",
                    messageText: "Do you want to close this?",
                    alertType: "info"
                }).done(function (e) {
                    if (e == true) {
                        $('#send_mail').modal('hide');
                        document.getElementById('divCcHelper').style.display = "none";
                        document.getElementById('divBCcHelper').style.display = "none";
                        document.getElementById('divCcContent').style.display = "none";
                        document.getElementById('divBCcContent').style.display = "none";
                        document.getElementById('divContent').innerHTML = "";
                        document.getElementById('divContent').style.display = "none";
                        document.getElementById("<%=txtMailContent.ClientID%>").style.display = "";
                         return false;
                }
                else {
                    return false;
                }
            });               
            }
            return false;
        }
        function CheckMail() {
            var ret = true;           
            // replacing < and > tags
            var ContentWithoutReplace = document.getElementById("<%=txtMailContent.ClientID%>").value;
            var replaceText1 = ContentWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtMailContent.ClientID%>").value = replaceText2;
            var CcContentWithoutReplace = document.getElementById("<%=txtCccontent.ClientID%>").value;
            var replaceText3 = CcContentWithoutReplace.replace(/</g, "");
            var replaceText4 = replaceText3.replace(/>/g, "");
            document.getElementById("<%=txtCccontent.ClientID%>").value = replaceText4;
            var BccContentWithoutReplace = document.getElementById("<%=txtBCccontent.ClientID%>").value;
            var replaceText5 = BccContentWithoutReplace.replace(/</g, "");
            var replaceText6 = replaceText5.replace(/>/g, "");
            document.getElementById("<%=txtBCccontent.ClientID%>").value = replaceText6;
            var ToContentWithoutReplace = document.getElementById("<%=txtToAddress.ClientID%>").value;
            var replaceText7 = ToContentWithoutReplace.replace(/</g, "");
            var replaceText8 = replaceText7.replace(/>/g, "");
            document.getElementById("<%=txtToAddress.ClientID%>").value = replaceText8;



            document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCccontent.ClientID%>").style.borderColor = ""
            document.getElementById("<%=txtBCccontent.ClientID%>").style.borderColor = ""
            document.getElementById("<%=txtMailContent.ClientID%>").style.borderColor = "";

            var MailContent = document.getElementById("<%=txtMailContent.ClientID%>").value;

            //005 start
            var ToMail = document.getElementById("<%=txtToAddress.ClientID%>").value;
            var CcEmail = document.getElementById("<%=txtCccontent.ClientID%>").value;
            var BCcEmail = document.getElementById("<%=txtBCccontent.ClientID%>").value;
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;


            var ToMailSplit = [];
            ToMailSplit = ToMail.split(',');
            if (ToMailSplit != "") {
                for (ArrCount = 0; ArrCount < ToMailSplit.length; ArrCount++) {


                    if (!filter.test(ToMailSplit[ArrCount])) {

                        $("#divErrorRsnMail").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divErrorRsnMail").fadeTo(3000, 500).slideUp(500, function () {
                        });
                       

                        document.getElementById("<%=txtToAddress.ClientID%>").focus();
                        document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "red";
                        ret = false;
                    }


                }
            }
            else {
                $("#divErrorRsnMail").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnMail").fadeTo(3000, 500).slideUp(500, function () {
                });
               

                document.getElementById("<%=txtToAddress.ClientID%>").focus();
                document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "red";
                ret = false;
            }

            var CcEmailSplit = [];
            CcEmailSplit = CcEmail.split(',');

            if (CcEmailSplit != "") {

                for (ArrCount = 0; ArrCount < CcEmailSplit.length; ArrCount++) {

                    if (!filter.test(CcEmailSplit[ArrCount])) {
                        $("#divErrorRsnMail").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divErrorRsnMail").fadeTo(3000, 500).slideUp(500, function () {
                        });
                       

                        document.getElementById("<%=txtCccontent.ClientID%>").focus();
                         document.getElementById("<%=txtCccontent.ClientID%>").style.borderColor = "red";
                        ret = false;

                    }
                }
            }


            var BCcEmailSplit = [];
            BCcEmailSplit = BCcEmail.split(',');
            if (BCcEmailSplit != "") {
                for (ArrCount = 0; ArrCount < BCcEmailSplit.length; ArrCount++) {

                    if (!filter.test(BCcEmailSplit[ArrCount])) {
                        $("#divErrorRsnMail").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                        $("#divErrorRsnMail").fadeTo(3000, 500).slideUp(500, function () {
                        });
                       

                         document.getElementById("<%=txtBCccontent.ClientID%>").style.borderColor = "red";
                                document.getElementById("<%=txtBCccontent.ClientID%>").focus();
                         ret = false;
                     }

                 }
             }





            if (MailContent == "") {
                $("#divErrorRsnMail").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnMail").fadeTo(3000, 500).slideUp(500, function () {
                });

                

                        document.getElementById("<%=txtMailContent.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtMailContent.ClientID%>").focus();
                        ret = false;

                    }

                    if (ret == true) {
                        if (document.getElementById("<%=txtMailSubject.ClientID%>").value == "") {
                        if (confirm("Send this message without a subject ?")) {
                            ret = true;
                        }
                        else {
                            ret = false;
                        }
                    }
                }
                if (ret == true) {
                    $('#send_mail').modal('hide');
                    ShowLoading();
                }
                return ret;
            }
        function CheckReject() {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to reject the mail ?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    __doPostBack("<%=btnRejectMail.UniqueID %>", "");                     
                        return false;
                    }
                    else {
                        return false;
                    }
                });               
            return false;
            }
        var Filecounter = 0;
        function ViewAttachment(editTransDtlId, EditFileName, EditActualFileName) {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';
            var tdFileNameEdit = '<a  target="_blank" href=' + document.getElementById("<%=hiddenMailFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';
            FrecRow += '<td class="tr_l"  id="filePath' + Filecounter + '"  >' + tdFileNameEdit + '</td  >';
            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';
            jQuery('#TableFileUploadContainer').append(FrecRow);
            Filecounter++;
        }
    </script>
</asp:Content>

