<%@ Page Language="C#"  MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="Compzit_Mailbox.aspx.cs" Inherits="Transaction_Compzit_Mailbox_Compzit_Mailbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
    <link href="/css/New%20css/hcm_ns.css" rel="stylesheet" />
    <script src="/js/Common/Common.js"></script>
    <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
    <script src="/js/New%20js/date_pick/datepicker.js"></script>
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
    </style>

     <script language="javascript" type="text/javascript">
         var submit = 0;
         function CheckIsRepeat() {
             if (++submit > 1) {

                 return false;
             }
             else {
                 return true;
             }
         }
         function CheckSubmitZero() {
             submit = 0;
         }
    </script>
     <%--End:-EMP-0009 --%>
 
     <script type="text/javascript">

         function ShowError() {
             $("#danger-alert").html("You Can Not Perform This Action Right Now! Some One Accessed This Mail.");
             $("#danger-alert").fadeTo(3000, 500).slideUp(500, function () {
             });
         }

         //Start:-EMP-0009
         function ShowMail(evt, corp, y) {

             $('.frst_row').each(function () {
                 $(this).removeClass("sel_ms_rw");
             });
             $('#tr' + evt).addClass("sel_ms_rw");

             $(".show_dtl1").fadeIn("slow");
             $(".new_msg_op").hide(200);
             $(".msg_dtz_mb2").show(200);

             if (document.getElementById("<%=HiddenFieldMultiSelctn.ClientID%>").value == 1) {

                 var rowid = "tr";
                 rowid = rowid.concat(evt);

                 if (y == 0) {

                     if (document.getElementById(rowid).style.background == "rgb(161, 179, 131) none repeat scroll 0% 0%" || document.getElementById(rowid).style.background == "rgb(161, 179, 131)") {

                         var values = document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value.split(",");
                         for (var i = 0 ; i < values.length ; i++) {
                             if (values[i] == evt) {
                                 values.splice(i, 1);
                                 document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = values.join(",");
                             }
                         }

                         document.getElementById(rowid).style.background = "rgb(221, 224, 219)";
                         var oldrow = document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value;
                         var a = oldrow.split(',');
                         document.getElementById("<%=hiddenMailId.ClientID%>").value = a[a.length - 1];
                     }
                     else {
                         if (document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value == "") {
                             document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = evt;
                         }
                         else {
                             document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value + "," + evt;
                         }

                         document.getElementById(rowid).style.background = "rgb(161, 179, 131)";
                         document.getElementById("<%=hiddenMailId.ClientID%>").value = evt;
                     }
                 }
                 document.getElementById("<%=hiddenMailRow.ClientID%>").value = rowid;



                 document.getElementById('divContent').innerHTML = "Loading....";


                 document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value = corp;
                 var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                 var MailIdFnl = document.getElementById("<%=hiddenMailId.ClientID%>").value;

                 if (MailIdFnl != "") {

                     var result = PageMethods.Read_Mail_DetailsById(MailIdFnl, UserId, function (response) {

                         var Array = response;
                         var mailhtml = Array[0];
                         var atthtml = Array[1];
                         var mailaction = Array[2];
                         var FromMail = Array[3];
                         var Content = Array[5];
                         var AttchmntCount = Array[6];

                         document.getElementById("<%=divMailHead.ClientID%>").innerHTML = mailhtml;
                         document.getElementById('divContent').innerHTML = Content;

                         var menuId = document.getElementById("<%=hiddenMenu.ClientID%>").value;

                         if(menuId=="3"){
                             hiddenTrash();
                             Load_dt();
                         }
                         else{
                             VisibleTrash();
                         }

                         if(parseInt(AttchmntCount)>0){
                             document.getElementById('popoverOpener').style.display="block";
                             document.getElementById('AttchmntCount').innerHTML=AttchmntCount;
                             document.getElementById('divAttachDetails').innerHTML = atthtml;
                         }

                         var rowid = "tr";
                         rowid = rowid.concat(evt);
                         document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = rowid;

                         //mail action 2 means mail is allocate mail
                         if (mailaction == 2) {

                             AllocatedMail();
                         }
                         else {
                             RejectedMail();
                         }

                         if (document.getElementById("<%=hiddenMailForward.ClientID%>").value == 0) {
                             document.getElementById('divForward').style.display = "none";
                         }
                         if (document.getElementById("<%=hiddenMailAllocate.ClientID%>").value == 0) {
                             document.getElementById('divAllocate').style.display = "none";
                         }
                         if (document.getElementById("<%=HiddenMailNewLead.ClientID%>").value == 0) {
                             document.getElementById('divNewLead').style.display = "none";
                         }
                         if (document.getElementById("<%=hiddenMailAttach.ClientID%>").value == 0) {
                             document.getElementById('divAttach').style.display = "none";
                         }

                         var rows = $('#tblPagingTable tbody tr');
                         var x = 0;
                         for (var i = 0; i < rows.length; i++) {
                             var MailId = rows[i].id;
                             if (document.getElementById(MailId).style.background == "rgb(161, 179, 131) none repeat scroll 0% 0%" || document.getElementById(MailId).style.background == "rgb(161, 179, 131)") {
                                 x++;
                             }
                         }

                         document.getElementById("<%=divMailHead.ClientID%>").style.visibility = "visible";
                         if (x == 0) {

                         }
                         else if (x > 1) {

                             document.getElementById('divForward').style.display = "none";
                             document.getElementById('divAllocate').style.display = "none";
                             document.getElementById('divNewLead').style.display = "none";
                             document.getElementById('divAttach').style.display = "none";

                             document.getElementById('divContent').innerHTML = "";
                             document.getElementById('divAttachment').innerHTML = "";

                             document.getElementById("<%=divMailHead.ClientID%>").style.visibility = "hidden";
                         }
                         else if (x == 1) {

                             document.getElementById('divForward').style.display = "";
                             document.getElementById('divAllocate').style.display = "";
                             document.getElementById('divNewLead').style.display = "";
                             document.getElementById('divAttach').style.display = "";
                         }
                     });

                 }
                 else {

                     var rows = $('#tblPagingTable tbody tr');
                     var x = 0;
                     for (var i = 0; i < rows.length; i++) {
                         var MailId = rows[i].id;
                         if (document.getElementById(MailId).style.background == "rgb(161, 179, 131) none repeat scroll 0% 0%" || document.getElementById(MailId).style.background == "rgb(161, 179, 131)") {
                             x++;
                         }
                     }

                     document.getElementById("<%=divMailHead.ClientID%>").style.visibility = "visible";
                     if (x == 0) {

                     }
                     else if (x > 1) {
                         document.getElementById('divForward').style.display = "none";
                         document.getElementById('divAllocate').style.display = "none";
                         document.getElementById('divNewLead').style.display = "none";
                         document.getElementById('divAttach').style.display = "none";

                         document.getElementById('divContent').innerHTML = "";
                         document.getElementById('divAttachment').innerHTML = "";

                         document.getElementById("<%=divMailHead.ClientID%>").style.visibility = "hidden";
                     }
                     else if (x == 1) {

                         document.getElementById('divForward').style.display = "";
                         document.getElementById('divAllocate').style.display = "";
                         document.getElementById('divNewLead').style.display = "";
                         document.getElementById('divAttach').style.display = "";
                     }
                 }

             }
             else {

                 if (y == 0) {

                     if (document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value != "") {
                         var values = document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value.split(",");
                         for (var i = 0 ; i < values.length ; i++) {
                             document.getElementById("tr" + values[i]).style.background = "rgb(221, 224, 219)";
                         }
                         document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";
                     }
                     document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = evt;
                 }

                 document.getElementById('divContent').innerHTML = "Loading....";
                 document.getElementById("<%=hiddenMailId.ClientID%>").value = evt;
                 document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value = corp;
                 var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;


                 var result = PageMethods.Read_Mail_DetailsById(evt, UserId, function (response) {

                     var Array = response;
                     var mailhtml = Array[0];
                     var atthtml = Array[1];
                     var mailaction = Array[2];
                     var FromMail = Array[3];
                     var Content = Array[5];
                     var AttchmntCount = Array[6];

                     document.getElementById("<%=divMailHead.ClientID%>").innerHTML = mailhtml;
                     document.getElementById('divContent').innerHTML = Content;

                     var menuId = document.getElementById("<%=hiddenMenu.ClientID%>").value;

                     if(menuId=="3"){
                         hiddenTrash();
                     }
                     else{
                         VisibleTrash();
                     }

                     if(parseInt(AttchmntCount)>0){
                         document.getElementById('popoverOpener').style.display="block";
                         document.getElementById('AttchmntCount').innerHTML=AttchmntCount;
                         document.getElementById('divAttachDetails').innerHTML = atthtml;
                     }

                     var rowid = "tr";
                     rowid = rowid.concat(evt);
                     document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = rowid;
                     document.getElementById(rowid).style.background = "rgb(161, 179, 131)";
                     //mail action 2 means mail is allocate mail
                     if (mailaction == 2) {

                         AllocatedMail();
                     }
                     else {
                         RejectedMail();
                     }
                     try {
                         var oldrow = document.getElementById("<%=hiddenMailRow.ClientID%>").value;
                         document.getElementById("<%=hiddenMailRow.ClientID%>").value = rowid;
                         if (rowid == oldrow) { }
                         else {
                             document.getElementById(oldrow).style.background = "rgb(221, 224, 219)";
                         }
                     }
                     catch (err) {
                     }

                     if (document.getElementById("<%=hiddenMailForward.ClientID%>").value == 0) {
                         document.getElementById('divForward').style.display = "none";
                     }
                     if (document.getElementById("<%=hiddenMailAllocate.ClientID%>").value == 0) {
                         document.getElementById('divAllocate').style.display = "none";
                     }
                     if (document.getElementById("<%=HiddenMailNewLead.ClientID%>").value == 0) {
                         document.getElementById('divNewLead').style.display = "none";
                     }
                     if (document.getElementById("<%=hiddenMailAttach.ClientID%>").value == 0) {
                         document.getElementById('divAttach').style.display = "none";
                     }




                     var rows = $('#tblPagingTable tbody tr');
                     var x = 0;
                     for (var i = 0; i < rows.length; i++) {
                         var MailId = rows[i].id;

                         if (document.getElementById(MailId).style.background == "rgb(161, 179, 131) none repeat scroll 0% 0%" || document.getElementById(MailId).style.background == "rgb(161, 179, 131)") {

                             x++;
                         }
                     }

                     document.getElementById("<%=divMailHead.ClientID%>").style.visibility = "visible";

                     if (x == 0) {

                     }
                     else if (x > 1) {

                         document.getElementById('divForward').style.display = "none";
                         document.getElementById('divAllocate').style.display = "none";
                         document.getElementById('divNewLead').style.display = "none";
                         document.getElementById('divAttach').style.display = "none";
                     }
                     else if (x == 1) {

                         document.getElementById('divForward').style.display = "";
                         document.getElementById('divAllocate').style.display = "";
                         document.getElementById('divNewLead').style.display = "";
                         document.getElementById('divAttach').style.display = "";
                     }

                 });
             }
         }
         //End:-EMP-0009
         function NextDisable() {
             document.getElementById('btnNext').disabled = true;
             document.getElementById('btnNext').style.background = "#9c9c9c";
             document.getElementById('btnNext').style.cursor = "default";
         }

         function NextEnable() {
             document.getElementById('btnNext').disabled = false;
             document.getElementById('btnNext').style.background = "";
             document.getElementById('btnNext').style.cursor = "pointer";
         }

         function PreviousDisable() {
             document.getElementById('btnPrevious').disabled = true;
             document.getElementById('btnPrevious').style.background = "#9c9c9c";
             document.getElementById('btnPrevious').style.cursor = "default";

         }

         function PreviousEnable() {
             document.getElementById('btnPrevious').disabled = false;
             document.getElementById('btnPrevious').style.background = "";
             document.getElementById('btnPrevious').style.cursor = "pointer";
         }

         function InboxSelect() {
             document.getElementById(1).style.background = "#515a41";
         }

         function HiddenGetMessageImage() {
             document.getElementById('imgGetMessage').style.display = "none";
         }
         function VisibleGetMessageImage() {
             document.getElementById('imgGetMessage').style.display = "";
             return true;
         }

         function ReadReceiveMail() {

             document.getElementById("<%=hiddenReadingReceivedMails.ClientID%>").value = "1";

             var ServerPath = document.getElementById("<%=hiddenServerMapPath.ClientID%>").value;
             //document.getElementById('divLoading').style.display = "block";
             var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
             var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
             var result = PageMethods.Read_Received_Mail(ServerPath, OrgId, UserId, function (response) {
                 // passing 1 means taking the mails frfom inbox to show first

                 GetMailByStore(1, 0);
                 setTimeout(resetrefresh, 3000);

             });

             return false;
         }

         function resetrefresh() {
             document.getElementById("<%=hiddenReadingReceivedMails.ClientID%>").value = "0";
         }

         function RefreshMail() {

             GetMailByStore(1,0);
             document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = "0";

             return false;
         }

         function hide() {
             //document.getElementById('divLoading').style.display = "none";
         }

         function OpenAttachements() {
             if ($('#divAttachDetails:visible').length == 0) {
                 document.getElementById('divAttachDetails').style.display = "";
             }
             else {
                 document.getElementById('divAttachDetails').style.display = "none";
             }
         }

         function openfile(evt, Id) {
             var path = document.getElementById("<%=hiddenServerMapPath.ClientID%>").value;
             path = path.concat(evt);
             document.getElementById(Id).href = path;
             document.getElementById(Id).href;
         }

         var $noCon = jQuery.noConflict();
         $noCon(window).load(function () {
             document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";
             document.addEventListener("keydown", keyDownTextField, false);
             document.addEventListener("keyup", keyUpTextField, false);
             document.getElementById("<%=hiddenMenu.ClientID%>").value="1";
         });

         function keyDownTextField(e) {

             if ((e.keyCode || e.which) == 17) {
                 document.getElementById("<%=HiddenFieldMultiSelctn.ClientID%>").value = 1;
             }
         }

         function keyUpTextField(e) {

             if ((e.keyCode || e.which) == 17) {
                 document.getElementById("<%=HiddenFieldMultiSelctn.ClientID%>").value = 0;
             }
         }

         //End:-EMP-0009
         function Autorefresh() {

             var values = document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value.split(",");
             if (values.length < 2) {


                 if (document.getElementById("<%=hiddenReadingReceivedMails.ClientID%>").value == "0") {

                     if (document.getElementById("<%=hiddenTableValueRotation.ClientID%>").value == "0") {
                         var prev = document.getElementById("<%=hiddenPrevious.ClientID%>").value;
                         var event = document.getElementById("<%=hiddenMenu.ClientID%>").value;

                         if (event == 1 || event == 0) {
                             if (prev == 0) {

                                 CheckCount(1);
                                 var MailCount = document.getElementById("<%=HiddenFieldMailCount.ClientID%>").value;
                                 var NewMailCount = document.getElementById("<%=HiddenFieldNewMailCount.ClientID%>").value;

                                 if (NewMailCount > MailCount) {

                                     GetMailByStore(1, 1);
                                 }

                             }
                         }


                     }
                 }
                 else {
                     //do nothing
                 }
             }
         }

         function focusChangeRotator() {   
             //setTimeout(FocusingOnSelected,40);
         }

         function FocusingOnSelected() {

             var rowid = document.getElementById("<%=hiddenFocusRowId.ClientID%>").value;

             if (rowid != "0" && rowid != "") {
                 if ($("#" + rowid).length) {

                     var rotation = document.getElementById("<%=hiddenTableValueRotation.ClientID%>").value;

                     if (rotation == "1") {
                         var evt = document.getElementById("<%=hiddenMailId.ClientID%>").value;
                         var corp = document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value;
                         ShowMail(evt, corp, 1);
                     }
                     //Start:-EMP-0009  
                     //document.getElementById("<%=hiddenTableValueRotation.ClientID%>").value = "0";  
                     var values = document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value.split(",");
                     for (var i = 0 ; i < values.length ; i++) {
                         document.getElementById("tr" + values[i]).style.background = "rgb(161, 179, 131)";
                     }
                     //End:-EMP-0009


                     return true;
                 }
                 else {
                     document.getElementById("<%=hiddenTableValueRotation.ClientID%>").value = "1";
                     GetMailBox(2);
                     document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = rowid;
                     focusChangeRotator();
                 }
             }
             else {
                 return true;
             }
         }

         function CheckCount(evt) {
             var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
             var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
             var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
             var AllMail = document.getElementById("<%=hiddenAllMailEnable.ClientID%>").value;


             if (evt != '' && evt != null && CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && UserId != '' && UserId != null && AllMail != '' && AllMail != null) {

                 $.ajax({
                     type: "POST",
                     async: false,
                     contentType: "application/json; charset=utf-8",
                     url: "Compzit_Mailbox.aspx/CheckMailCount",
                     data: '{evt: "' + evt + '",CorpId:"' + CorpId + '" ,OrgId:"' + OrgId + '",UserId:"' + UserId + '",AllMail:"' + AllMail + '"}',
                     dataType: "json",
                     success: function (data) {

                         if (data.d != '') {
                             var Array = data.d;

                             document.getElementById("<%=HiddenFieldNewMailCount.ClientID%>").value = Array[0];
                         }
                     },
                     error: function (result) {

                     }
                 });
             }
             return true
         }

         function GetMailByStore(evt, sndr) {

             $('.clsMailStorage').each(function () {
                 $(this).removeClass("sel_act_msg");
             });
             $('#li' + evt).addClass("sel_act_msg");

             var Name = $('#span' + evt).html();
             var Image = $('#itag' + evt).attr('class');

             document.getElementById("<%=divMailStorageSelected.ClientID%>").innerHTML = "<span class=\"sp_msg1\"><i class=\"" + Image + "\"></i> <span>" + Name + "</span> <i class=\"fa fa-sort\"></i></span>";
             document.getElementById("<%=divMailStorageSelectedDisp.ClientID%>").innerHTML = "<span class=\"sel_msg_sec sp_msg1\">" + Name + " <i class=\"" + Image + "\"></i> </span>";

             //set previous and next to default value
             document.getElementById("<%=hiddenNext.ClientID%>").value = 0;
             document.getElementById("<%=hiddenPrevious.ClientID%>").value = 0;

             var Next = document.getElementById("<%=hiddenNext.ClientID%>").value;
             var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
             var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
             var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
             var AllMail = document.getElementById("<%=hiddenAllMailEnable.ClientID%>").value;
             if (sndr == 0) {
                 //document.getElementById('divLoading').style.display = "block";
             }
             document.getElementById("<%=hiddenMenu.ClientID%>").value = evt;

             if (evt != '' && evt != null && CorpId != '' && CorpId != null && OrgId != '' && OrgId != null && UserId != '' && UserId != null && AllMail != '' && AllMail != null) {
                 LoadList();
             }

             var MenuValue = document.getElementById("<%=hiddenMenu.ClientID%>").value;
             document.getElementById(MenuValue).style.background = "";

             if (sndr == 0) {
                 document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";
             }
             return true;
         }

         function GetMailBox(evt) {

             document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";
             document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = "0";
             //evt =1 means previous and evt=2 means next
             LoadList();
         }

         function OnSuccess(response, Read_Mail_Box) {
             alert(response);
         }
         function OnError(error, Read_Mail_Box) {
             alert(error);
         }

         function WriteMailBody() {
             var MailBody = '<h1> ';
             MailBody = MailBody.concat('<br /> ');
             MailBody = MailBody.concat('<br /> ');
             MailBody = MailBody.concat('<br /> ');
             MailBody = MailBody.concat('</h1>');
             document.getElementById("<%=divMailHead.ClientID%>").innerHTML = MailBody;
             document.getElementById('divContent').innerHTML = "";
             document.getElementById('divAttachDetails').innerHTML = "";
             document.getElementById('divAttachment').innerHTML = "";
             AttachmentDefaultColor();
         }

         function openattachment(filename) {
             alert(filename);
         }

         //Start:-EMP-0009
         function PushToTrash() {
             if (confirm('Do You Want This Mail Push To Trash') == true) {              
                 OpenModalReopenReason();
             };
         }

         function pushTotrashSub() {

             //document.getElementById('divLoading').style.display = "block";
             var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
             var CurDiv = document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value;
             var ReasnId = document.getElementById("ddlReopenReason").value;
             var Desc = document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value;

             var rows = $('#tblPagingTable tbody tr');

             for (var i = 0; i < rows.length; i++) {
                 var MailId = rows[i].id;
                 if (document.getElementById(MailId).style.background == "rgb(161, 179, 131) none repeat scroll 0% 0%" || document.getElementById(MailId).style.background == "rgb(161, 179, 131)") {
                     var a = MailId.split('r');
                     MailId = a[1];

                     var PushTrash = PageMethods.PushToTrash(MailId, UserId, CurDiv, ReasnId, Desc, function (response) {

                         var Res = response;

                         if (Res == "NO") {
                             ShowError();
                         }

                         //evt =1 means previous and evt=2 means next
                         LoadList();
                     });
                 }
             }

             document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";
             document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = "0";
         }
         //End:-EMP-0009
         function hiddenTrash() {
             document.getElementById('divTrash').style.display = "none";
         }

         function VisibleTrash() {
             document.getElementById('divTrash').style.display = "";
         }

         function CloseAttachClose() {
             if (confirm('Are you Sure you want to Close?') == true) {
                 $('#divModelAttach').modal('hide');
             }
         }

         function CloseAttach() {
             $('#divModelAttach').modal('hide');
         }


         function OpenAttach() {
             document.getElementById('divErrorRsn').style.display = "none";
             document.getElementById('divAttachReport').style.display = "none";

             var d = new Date();
             document.getElementById("<%=txtToDate.ClientID%>").value = ("0" + d.getDate()).slice(-2) + "-" + ("0" + (d.getMonth() + 1)).slice(-2) + "-" + d.getFullYear();
             d.setMonth(d.getMonth() - 1);
             document.getElementById("<%=txtFromDate.ClientID%>").value = ("0" + d.getDate()).slice(-2) + "-" + ("0" + (d.getMonth() + 1)).slice(-2) + "-" + d.getFullYear();
             document.getElementById("<%=ddlCustomer.ClientID%>").selectedIndex = 0;
             document.getElementById('divModelCommon').style.display = "";
         }


         function CloseAllocateClose() {
             if (confirm('Are you Sure you want to Close?') == true) {
                 $('#divModelAllocate').modal('hide');
             }
         }
         function CloseAllocate() {
             $('#divModelAllocate').modal('hide');
         }
         function OpenAllocate() {
             var $noC = jQuery.noConflict();
             document.getElementById('divAllocateError').style.display = "none";
             document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";
             $noC("input.ui-autocomplete-input").css("borderColor", "");

             document.getElementById("<%=ddlEmployee.ClientID%>").value = "--SELECT EMPLOYEE--";
             var a = $noC("#cphMain_ddlEmployee option:selected").text();
             $noC("input.ui-autocomplete-input").val(a);

             document.getElementById("<%=ddlEmployee.ClientID%>").focus();
             $noC("#cphMain_ddlEmployee").select();
         }
         function CloseForwardClose() {
             if (confirm('Are you Sure you want to Close?') == true) {
                 $('#divModelForward').modal('hide');
             }
         }
         function CloseForward() {
             $('#divModelForward').modal('hide');
         }
         function OpenForward() {
             document.getElementById('divForwardError').style.display = "none";
             document.getElementById("<%=ddlDivisions.ClientID%>").style.borderColor = "";
             document.getElementById("<%=ddlDivisions.ClientID%>").value = "--SELECT DIVISION--";
             document.getElementById('divModelCommon').style.display = "";
            
         }
         function ValidateDivision() {

             document.getElementById('divForwardError').style.display = "none";
             var Division = document.getElementById("<%=ddlDivisions.ClientID%>").value;
             document.getElementById("<%=ddlDivisions.ClientID%>").style.borderColor = "";
             if (Division == "--SELECT DIVISION--") {
                 document.getElementById('divForwardError').style.display = "";
                 document.getElementById("<%=lblForwardError.ClientID%>").innerHTML = "Please Choose A Division";
                 document.getElementById("<%=ddlDivisions.ClientID%>").focus();
                 document.getElementById("<%=ddlDivisions.ClientID%>").style.borderColor = "Red";
                 return false;
             }
             else {
                 var Divisions = document.getElementById("<%=ddlDivisions.ClientID%>");
                 var Division = Divisions.options[Divisions.selectedIndex].value;
                 //check mail send to the same division or not
                 if (Division == document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value) {
                     document.getElementById('divForwardError').style.display = "";
                     document.getElementById("<%=lblForwardError.ClientID%>").innerHTML = "Can Not Forward The Mail To The Same Division";
                     document.getElementById("<%=ddlDivisions.ClientID%>").focus();
                     document.getElementById("<%=ddlDivisions.ClientID%>").style.borderColor = "Red";
                     return false;
                 }

                 var MailId = document.getElementById("<%=hiddenMailId.ClientID%>").value;
                 var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                 var CurDiv = document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value;
                 var Forward = PageMethods.ForwardMail(Division, MailId, UserId, CurDiv, function (response) {

                     var Res = response;

                     if (Res == "NO") {
                         ShowError();
                     }

                     //evt =1 means previous and evt=2 means next
                     LoadList();
                 });

                 CloseForward();

                 document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";
                 document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = "0";
                 return true;
             }

             return true;
         }

         function ValidateUsers() {
             var $noC = jQuery.noConflict();

             document.getElementById('divAllocateError').style.display = "none";
             var Division = document.getElementById("<%=ddlEmployee.ClientID%>").value;

             $noC("input.ui-autocomplete-input").css("borderColor", "");
             document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";

             if (Division == "--SELECT EMPLOYEE--") {
                 document.getElementById('divAllocateError').style.display = "";
                 document.getElementById("<%=lblAllocateErrorRsn.ClientID%>").innerHTML = "Please Choose An Employee";

                 document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                 $noC("input.ui-autocomplete-input").css("borderColor", "Red");
                 document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                 $noC("#cphMain_ddlEmployee").select();
                 return false;
             }
             else {
                 var Users = document.getElementById("<%=ddlEmployee.ClientID%>");
                 var UserId = Users.options[Users.selectedIndex].value;

                 var MailId = document.getElementById("<%=hiddenMailId.ClientID%>").value;
                 var CurDiv = document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value;
                 var CurUser = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                 //document.getElementById('divLoading').style.display = "block";

                 var Allocate = PageMethods.AllocateEmail(MailId, UserId, CurDiv, CurUser, function (response) {

                     var Res = response;

                     if (Res == "NO") {
                         ShowError();
                     }

                     //evt =1 means previous and evt=2 means next
                     LoadList();
                 });
                 CloseAllocate();
                 document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = "0";
                 document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";
             }
             return false;
         }

         function NewLead() {
             var MailId = document.getElementById("<%=hiddenMailId.ClientID%>").value;
             if (confirm('Do You Want New Window For Lead Page ?') == true) {
                 window.open('/Transaction/gen_Lead/gen_Lead.aspx?md=' + MailId)
             }
             else {
                 window.location = '/Transaction/gen_Lead/gen_Lead.aspx?md=' + MailId + '&Prev=Mail';
             };
         }

         function AllocatedMail() {
             if (document.getElementById("<%=hiddenMailAllocate.ClientID%>").value == 0) {
                 document.getElementById('divAllocate').style.display = "none";
             }
             document.getElementById('divReject').style.display = "";
         }
         function RejectedMail() {
             document.getElementById('divAllocate').style.display = "";
             document.getElementById('divReject').style.display = "none";
         }

         function OpenReject() {
             if (confirm('Do You Want To Reject This Mail') == true) {

                 var MailId = document.getElementById("<%=hiddenMailId.ClientID%>").value;
                 //document.getElementById('divLoading').style.display = "block";
                 var Allocate = PageMethods.Reject_Mail(MailId, function (response) {

                     var Next = document.getElementById("<%=hiddenNext.ClientID%>").value;
                     var Previous = document.getElementById("<%=hiddenPrevious.ClientID%>").value;
                     var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
                     var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                     var MailStore = document.getElementById("<%=hiddenMenu.ClientID%>").value;
                     var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                     var AllMail = document.getElementById("<%=hiddenAllMailEnable.ClientID%>").value;

                     //evt =1 means previous and evt=2 means next
                     LoadList();
                 });
                 RejectedMail();
                 //document.getElementById('divLoading').style.display = "none";
                 return true;
             }
         }

         function AttachmentColorChange() {
             //document.getElementById('divAttachment').style.backgroundColor = "rgb(181, 188, 169)";
         }

         function AttachmentDefaultColor() {
             //document.getElementById('divAttachment').style.backgroundColor = "lightgray";
         }

         function SearchLeads() {

             document.getElementById('divErrorRsn').style.display = "none";
             document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
             document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";

             var ret = true;

             if (document.getElementById("<%=txtToDate.ClientID%>").value == "") {
                 document.getElementById('divErrorRsn').style.display = "";
                 document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "red";
                 document.getElementById("<%=txtToDate.ClientID%>").focus();
                 ret = false;
             }
             if (document.getElementById("<%=txtFromDate.ClientID%>").value == "") {
                 document.getElementById('divErrorRsn').style.display = "";
                 document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "red";
                 document.getElementById("<%=txtFromDate.ClientID%>").focus();
                 ret = false;
             }

             if (ret == true) {

                 var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
                 var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                 var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                 var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                 var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                 var CustomerId = document.getElementById("<%=ddlCustomer.ClientID%>").value;
                 if (CustomerId == "--SELECT CUSTOMER--") {
                     CustomerId = 0;
                 }
                 var Leads = PageMethods.SearchLead(OrgId, CorpId, UserId, FromDate, ToDate, CustomerId, function (response) {
                     var html = response;
                     document.getElementById('divAttachReport').style.display = "";
                     document.getElementById('divAttachReport').innerHTML = html;
                 });
             }
             document.getElementById("<%=HiddenFieldNewRow.ClientID%>").value = "";

             return false;
         }

         function HideLoading() {
             //document.getElementById('divLoading').style.display = "";
         }

         function MailLeadAttach(evt) {
             if (confirm('Do You Want To Merge The Current Mail To This Lead ?') == true) {
                 var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
                 var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                 var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                 var MailId = document.getElementById("<%=hiddenMailId.ClientID%>").value;
                 var CurDiv = document.getElementById("<%=hiddenMailDivisionId.ClientID%>").value;
                 //document.getElementById('divLoading').style.display = "block";

                 var Attach = PageMethods.MailLeadAttach(OrgId, CorpId, UserId, evt, MailId, CurDiv, function (response) {

                     var Res = response;

                     if (Res == "NO") {
                         ShowError();
                     }

                     var Next = document.getElementById("<%=hiddenNext.ClientID%>").value;
                     var Previous = document.getElementById("<%=hiddenPrevious.ClientID%>").value;
                     var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
                     var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                     var MailStore = document.getElementById("<%=hiddenMenu.ClientID%>").value;
                     var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                     var AllMail = document.getElementById("<%=hiddenAllMailEnable.ClientID%>").value;

                     //evt =1 means previous and evt=2 means next
                     LoadList();
                 });
                 CloseAttach();
                 //document.getElementById('divLoading').style.display = "none";
                 document.getElementById("<%=hiddenFocusRowId.ClientID%>").value = "0";    
             }
             return false;
         }

          </script>
 
    <script>
        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
                $au('#cphMain_ddlDivisions').selectToAutocomplete1Letter();
                $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                });
            });
        })(jQuery);
                    </script>

   <script>

       var $Mo = jQuery.noConflict();

       function OpenModalReopenReason() {

           document.getElementById('<%=btnReopenReasonSave.ClientID%>').style.visibility = "visible";

           //for options in Task Subject

           var OptionsRsn = document.getElementById("<%=divOptionsReopenReason.ClientID%>").innerHTML;
           alert(OptionsRsn);

           var DfltOptnRsn = '<option  value="--SELECT REASON--">--SELECT REASON--</option>';
           var TotalOptnRsn = "";
           if (OptionsRsn == "") {
               TotalOptnRsn = DfltOptnRsn;
           }
           else {

               TotalOptnRsn = DfltOptnRsn + OptionsRsn;

           }

           var ReopenReasonHtml = '<select id="ddlReopenReason" class="form-control fg2_inp1 fg_chs1 inp_mst mod_inp100"> ';
           ReopenReasonHtml += TotalOptnRsn;
           ReopenReasonHtml += ' </select>  ';

           document.getElementById('SpanddlReopenReason').innerHTML = ReopenReasonHtml;

           document.getElementById('divErrorRsnReopenReason').style.display = "none";
           document.getElementById("<%=lblErrorRsnReopenReason.ClientID%>").innerHTML = "";
           document.getElementById("ddlReopenReason").style.borderColor = "";
           document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").style.borderColor = "";

           document.getElementById("ddlReopenReason").disabled = false;
           document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").disabled = false;

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

           if (confirm("Are you Sure you want to Close?")) {

               document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = "";
               $('#myModalReopenReason').modal('hide');
               return false;
           }
           else {
               return false;
           }
       }

       function CheckReopenReason() {
           var ret = true;
           if (CheckIsRepeat() == true) {
           }
           else {

               ret = false;
               return ret;
           }


           // replacing < and > tags

           var RdescWithoutReplace = document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value;
           var RdescreplaceText1 = RdescWithoutReplace.replace(/</g, "");
           var RdescreplaceText2 = RdescreplaceText1.replace(/>/g, "");
           document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value = RdescreplaceText2;



           document.getElementById("ddlReopenReason").style.borderColor = "";
           document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").style.borderColor = "";


           var DropdownListRsn = document.getElementById("ddlReopenReason");
           var SelectedValueRsn = DropdownListRsn.value;

           var RDescptn = document.getElementById("<%=txtReopenReasonDescptn.ClientID%>").value;



           document.getElementById('divErrorRsnReopenReason').style.display = "none";
           document.getElementById("<%=lblErrorRsnReopenReason.ClientID%>").innerHTML = "";

           if (SelectedValueRsn == "--SELECT REASON--" || SelectedValueRsn == "") {

               document.getElementById('divErrorRsnReopenReason').style.display = "block";
               document.getElementById("<%=lblErrorRsnReopenReason.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

               if (SelectedValueRsn == "--SELECT REASON--") {

                   document.getElementById("ddlReopenReason").focus();

                   document.getElementById("ddlReopenReason").style.borderColor = "Red";
                   ret = false;
               }


           }

           if (ret == true) {
               $('#myModalReopenReason').modal('hide');
               pushTotrashSub();
               CheckSubmitZero();
           }
           if (ret == false) {
               CheckSubmitZero();

           }

           return false;
       }


        //<!-- Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TXTBOX
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
        // for not allowing <> tags
        function isTag(obj, evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                if (obj == "cphMain_txtComments" || obj == "cphMain_txtPriceTerm" || obj == "cphMain_txtPymntTerm" || obj == "cphMain_txtDlvryTerm" || obj == "cphMain_txtValidityTerm" || obj == "cphMain_txtReopenReasonDescptn" || obj == "cphMain_txtManufacturerTerm") {

                }
                else {
                    return false;
                }
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
            return ret;
        }
    </script>


     <script>

         //--------------------------------------Pagination--------------------------------------

         $(document).ready(function () {
             Load_dt();
             getdata(1);

             document.getElementById("PushToTrash").style.display="none";
             document.getElementById("cbxAll").checked=false;
             CheckAll();
         });

         function LoadList() {
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
             strPagingTable += '<div><table id="tblPagingTable" class="display table-bordered pro_tab1" style="width:100%;">';
             strPagingTable += '<thead class="thead1"><tr id="thPagingTable_SearchColumns"></tr></thead>';
             strPagingTable += '<tbody id="trPagingTableBody"></tbody>';
             strPagingTable += '</table></div>';

             $("#divPagingTableContainer").html(strPagingTable);

             intToltalSearchColumns = document.getElementById('tblPagingTable').rows[0].cells.length;

             var strMailStore = document.getElementById("<%=hiddenMenu.ClientID%>").value;

             var url = "/Transaction/Compzit_Mailbox/Compzit_Mailbox.aspx/LoadStaticDatafordt";
             var objData = {};
             objData.MailStore = strMailStore;

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
             //var strPageSize = 10;
             var strPageSize = 5;
             var strCommonSearchString = "";
             var strInputColumnSearch = getColumnSearchData();//individual column search

             var strOrgId = '<%= Session["ORGID"] %>';
             var strCorpId = '<%= Session["CORPOFFICEID"] %>';
             var strUserId = '<%= Session["USERID"] %>';

             //if (strOrgId == "" || strCorpId == "") {
             //    window.location.href = "/Default.aspx";
             //    return false;
             //}

             var strAllMailEnable = document.getElementById("<%=hiddenAllMailEnable.ClientID%>").value;
             var strMailStore = document.getElementById("<%=hiddenMenu.ClientID%>").value;
 
             var url = "/Transaction/Compzit_Mailbox/Compzit_Mailbox.aspx/GetData";
             var objData = {};
             objData.OrgId = strOrgId;
             objData.CorpId = strCorpId;
             objData.UserId = strUserId;
             objData.AllMailEnable = strAllMailEnable;
             objData.MailStore = strMailStore;
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

                     $('[data-toggle="tooltip1"]').tooltip();

                     CheckAll();

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

    <script>
        function OpenModalForward(Id) {
            document.getElementById("<%=hiddenMailId.ClientID%>").value=Id;
            OpenForward();
            return false;
        }
        function OpenModalAllocate(Id) {
            document.getElementById("<%=hiddenMailId.ClientID%>").value=Id;
            OpenAllocate();
            return false;
        }
        function OpenModalMerge(Id) {
            document.getElementById("<%=hiddenMailId.ClientID%>").value=Id;
            OpenAttach();
            return false;
        }
        function OpenModalLead(Id) {
            document.getElementById("<%=hiddenMailId.ClientID%>").value=Id;
            NewLead();
            return false;
        }
        function OpenModalPushToTrash(Id) {
            document.getElementById("<%=hiddenMailId.ClientID%>").value=Id;
            PushToTrash();
            return false;
        }
        function OpenModalReject(Id) {
            document.getElementById("<%=hiddenMailId.ClientID%>").value=Id;
            OpenReject();
            return false;
        }
    </script>

    <script>
        function CheckAll(){
            if(document.getElementById("cbxAll").checked==true){
                $('.ChkCls').attr("checked",true);
            }
            else{
                $('.ChkCls').removeAttr("checked");
            }
        }

        function DisplayPushToTrash(){
            document.getElementById("PushToTrash").style.display="block";
        }
    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

        <asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
        <%--Start:-EMP-0009 --%>
        <asp:HiddenField ID="HiddenFieldNewRow" runat="server"  />
        <asp:HiddenField ID="HiddenFieldMultiSelctn" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldMailCount" runat="server"  />
        <asp:HiddenField ID="HiddenFieldNewMailCount" runat="server"  />
         <%--End:-EMP-0009 --%>
        <asp:HiddenField ID="hiddenMailRow" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenMenu" runat="server" Value="1" />
        <asp:HiddenField ID="hiddenNext" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenPrevious" runat="server"  Value="0" />
        <asp:HiddenField ID="hiddenCorpId" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenOrgId" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenAttachPath" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenMailId" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenServerMapPath" runat="server" Value="" />
        <asp:HiddenField ID="hiddenServerErrorPath" runat="server" Value="" />
        <asp:HiddenField ID="hiddenAllMailEnable" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenMailForward" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenMailAllocate" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenMailAttach" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenMailNewLead" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenMailDivisionId" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenFocusRowId" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenTableValueRotation" runat="server" Value="0" />
        <asp:HiddenField ID="hiddenReadingReceivedMails" runat="server" Value="0" />

    <!---breadcrumb_section_started---->    
    <ol class="breadcrumb">
      <li><a id="aHome" runat="server" href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
      <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx">Sales Force Automation</a></li>
      <li class="active">Compzit Mail</li>
    </ol>
    <!---breadcrumb_section_closed----> 

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
        <div class="content_box1 cont_contr pa_al0_mb">

        <div id="divLoading" style="display:none;">
            <img src="../../Images/Other Images/LoadingMail.gif" style="" />
        </div>


          <div class="fix_mail_head">
            <div class="mb_head_70">
              <h3>Compzit Mail</h3>
            </div>

              <a id="PushToTrash" class="btn btn_chse_sec push_btn" title="Push to Trash" style="display: none;" data-toggle="modal" data-target="#myModalReopenReason"><i class="fa fa-trash fa_stf"></i></a>


            <div class="mb_head_30">
              <div class="dropdown btn_chse_sec1">

                <button id="divMailStorageSelected" runat="server" class="dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true"></button>

                <ul id="divMailStorage" runat="server" class="dropdown-menu drop_dn mail_drop"></ul>

              </div>
              <a class="btn btn_chse_sec" title="Refresh" onclick="return RefreshMail();"><i class="fa fa-refresh fa_stf"></i></a>
              <button class="btn btn_chse_sec" title="Get Message" onclick="return ReadReceiveMail();"><i class="fa fa-cloud-download fa_stf"></i></button>
            </div>
          </div>
          <div class="area_msg_bx">

            <div class="r_480 dt_tblz sp_msg1">

              <div id="divMailStorageSelectedDisp" runat="server" style="margin-bottom:1%;"></div>

 <!----table---->
       <div id="divReport" runat="server" class="tab_res"></div>
       <div id="divPagingTable_processing" style="display: none;">Processing...</div>
       <div id="divPagingTableContainer"></div>
<!----table---->

              <div class="msg_dtl_box1 msg_dtz_mb2">
                  <div id="divModelCommon" class="show_dtl1 dx_mb1" style="display: none;">
                     <span>
                       <span class="heig_msg1">

                         <div id="divMailHead" runat="server" class="dtl_heaz"></div>

                         <div class="dtl_msgbox">
                             
                         <div id="divContent" class="dtl_bx_ar"></div>

                         <a class="attach_doc" id="popoverOpener" data-height="400" data-width="600" style="display:none;"><i class="fa fa-paperclip"></i> <span id="AttchmntCount" class="badge cht1 badge-success bdg_attch">4</span></a>
                         <a class="btn act_btn bn1 flt_r hide_msg_lst hid_dtl1 cls_msg_dtl" title="Close Details"><i class="fa fa-close"></i></a>
                          
                           <div id="popoverWrapper">
                            <div class="popover" role="tooltip">
                              <div class="arrow"></div>
                              <h3 class="popover-title">Attachment</h3>

                              <div id="divAttachDetails" class="popover-content"></div>

                                <div class="clearfix"></div><div class="devider mb_bmsg"></div>
                                <a class="btn btn-danger btn-dz flt_r bt_clz_atch"><i class="fa fa-close"></i></a>
                            </div>
                          </div>

                         </div>
                       </span>
                     </span>
                   </div>
              </div>

          </div>
        </div>
      </div>
    </div>
   </div>


 <!-- Allocate_to_Modal1 -->
<div id="divModelAllocate" class="modal fade" id="allocate_to" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog ad_sd_mod1 flt_r mod_mail_mrtp" role="document" style="width: 40%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Allocate To</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return CloseAllocateClose();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body padng_btm">

        <div id="divAllocateError" style="display:none;">
            <asp:Label ID="lblAllocateErrorRsn" runat="server"></asp:Label>
        </div>

        <div class="form-group fg12 sa_2">
          <label for="email" class="fg2_la1">Employee:<span class="spn1">*</span></label>
          <asp:DropDownList ID="ddlEmployee" runat="server" class="form-control fg2_inp1 fg_chs1 inp_mst"></asp:DropDownList> 
        </div>
      </div>

      <div class="modal-footer">
        <button id="btnAllocateSave" class="btn sub1" onclick="return ValidateUsers();">Allocate</button>
       <button type="submit" class="btn sub4" data-dismiss="modal" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>

 <!-- Forward_to_Modal1 -->
<div id="divModelForward" class="modal fade" id="forward_to" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog ad_sd_mod1 flt_r mod_mail_mrtp" role="document" style="width: 40%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H5">Forward To</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return CloseForwardClose();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body padng_btm">

       <div id="divForwardError" style="display:none;">
           <asp:Label ID="lblForwardError" runat="server" ></asp:Label>
       </div>  

        <div class="form-group fg12 sa_2">
          <label for="email" class="fg2_la1">Division:<span class="spn1">*</span></label>
          <asp:DropDownList ID="ddlDivisions" class="form-control fg2_inp1 fg_chs1 inp_mst" runat="server"></asp:DropDownList>
        </div>
      </div>

      <div class="modal-footer">
       <button id="btnForwardSave" type="button" class="btn sub1" onclick="return ValidateDivision();">Forward</button>
       <button type="submit" class="btn sub4" data-dismiss="modal" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>

 <!-- Merge_to_Modal1 -->
<div id="divModelAttach" class="modal fade" id="merge_to" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod2 mo3" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H6">Merge To</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return CloseAttachClose();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body padng_btm">

       <div id="divErrorRsn" style="display:none;  padding-top: 0.5%; padding-bottom: 0.5%;  font-family:Calibri; border-radius: 8px;background: #edf6dc;padding: 1% 1% 1% 1%;font-weight: bold;text-align: center;font-size: 15px;color: #53844E; margin-bottom:2%">
           <asp:Label ID="lblAttachErrorRsn" runat="server">Some of the information you entered is not correct or missing. Please check the highlighted fields below.</asp:Label>
       </div>

        <div class="form-group fg2 mar_at flt_l">
          <div class="tdte">
            <label for="pwd" class="fg2_la1">From Date:<span class="spn1">*</span> </label>
            <div id="datepickerfrmdate" class="input-group date" data-date-format="mm-dd-yyyy">
              <asp:TextBox ID="txtFromDate" class="form-control inp_bdr inp_mst" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return isNumberDate(event);"></asp:TextBox>                                                                    
              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
            </div>
          </div>
        </div>

          <script type="text/javascript">
              $noCon('#datepickerfrmdate').datepicker({
                  autoclose: true,
                  format: 'dd-mm-yyyy',
                  //startDate: new Date(),
                  timepicker: false
              });
          </script>

        <div class="form-group fg2 mar_at flt_l">
          <div class="tdte">
            <label for="pwd" class="fg2_la1">To Date:<span class="spn1">*</span> </label>
            <div id="datepickertodate" class="input-group date" data-date-format="mm-dd-yyyy">
              <asp:TextBox ID="txtToDate" class="form-control inp_bdr inp_mst" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return isNumberDate(event);"></asp:TextBox>
              <span class="input-group-addon date1"><i class="fa fa-calendar"></i></span>
            </div>
          </div>
        </div>

          <script type="text/javascript">
              $noCon('#datepickertodate').datepicker({
                  autoclose: true,
                  format: 'dd-mm-yyyy',
                  //startDate: new Date(),
                  timepicker: false
              });
          </script>

        <div class="form-group fg2 sa_2">
          <label for="email" class="fg2_la1">Customer:<span class="spn1"></span></label>
          <asp:DropDownList ID="ddlCustomer" class="form-control fg2_inp1 fg_chs1" runat="server" onchange="CustomerLoad()"></asp:DropDownList>
        </div>
        <div class="fg2 sa_480">
          <label for="pwd" class="fg2_la1 nbsp1">&nbsp;</label>
          <button id="btnAttachSave" class="submit_ser" onclick="return SearchLeads();"></button>
        </div>

        <div class="clearfix"></div>
        <div class="r_480">
            
            <div id="divAttachReport" class="table-responsive"></div>

        </div>
      </div>

    </div>
  </div>
</div>

<!-- Modal_status -->
<div id="myModalReopenReason" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog ad_sd_mod1 flt_r mod_mail_mrtp" role="document" style="width: 40%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Reason For Push To Trash</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="return CloseModalReopenReason();">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body padng_btm">

       <div id="divErrorRsnReopenReason" style="display:none;">
           <asp:Label ID="lblErrorRsnReopenReason" runat="server"></asp:Label>
       </div>

        <div class="form-group fg12 sa_2">
          <label for="email" class="fg2_la1">Reason:<span class="spn1">*</span></label>
          <span id="SpanddlReopenReason"></span>
        </div>
        <div class="fg12 sa_o_fg1">
          <div class="">
            <label for="email" class="fg2_la1">Description: <span class="spn1">&nbsp;</span></label>
            <asp:TextBox ID="txtReopenReasonDescptn" rows="3" cols="40" class="form-control flt_l txt_01 dt_wdt mod_inp100" placeholder="Description" TextMode="MultiLine" runat="server" onkeypress="return isTag('cphMain_txtReopenReasonDescptn', event);" onkeydown="textCounter(cphMain_txtReopenReasonDescptn,450);" onkeyup="textCounter(cphMain_txtReopenReasonDescptn,450);" Style="resize: none;"></asp:TextBox>
          </div>
        </div>
      </div>

      <div class="modal-footer">
       <asp:Button ID="btnReopenReasonSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckReopenReason();"  />
       <button type="submit" class="btn sub4" data-dismiss="modal" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>

<div id="divOptionsReopenReason" runat="server" style="display: none"></div>

<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>

<script>
    $(document).ready(function(){
        $(".frst_row td").click(function(){

        });
        $(document).on('keydown', function(e) { 
            var keyCode = e.keyCode || e.which; 

            if (keyCode == 27) { 
                $('.msg_dtz_mb2').hide("");
            } 
        });
        $(".hid_dtl1").click(function(){
            $(".show_dtl1").fadeOut("slow");
            $(".scnd_row, .trd_row").fadeIn("slow");
            $(".dt_tblz").removeClass("dtl_hei_move");
            $('.msg_dtz_mb2').hide("");
        });
        $(".dt_tblz .btn-d").click(function(){
            $(".push_btn").show();
        });
        $(".dt_tblz .btn-p").click(function(){
            $(".push_btn").hide();
        });
    });
</script>

<script type="text/javascript">
    'use strict';
class Popover {
    constructor(element, trigger, options) {
        this.options = { // defaults
            position: Popover.LEFT
        };
        this.element = element;
        this.trigger = trigger;
        this._isOpen = false;
        Object.assign(this.options, options);
        this.events();
        this.initialPosition();
    }

    events() {
        this.trigger.addEventListener('click', this.toggle.bind(this));
    }

    initialPosition() {
      let triggerRect = this.trigger.getBoundingClientRect();
        this.element.style.top = ~~triggerRect.top + 'px';
        this.element.style.left = ~~triggerRect.left + 'px';
    }

    toggle(e) {
        e.stopPropagation();
        if (this._isOpen) {
            this.close(e);
        } else {
            this.element.style.display = 'block';
            this._isOpen = true;
            this.outsideClick();
            this.position();
        }
    }

    targetIsInsideElement(e) {
      let target = e.target;
        if (target) {
            do {
                if (target === this.element) {
                    return true;
                }
            } while (target = target.parentNode);
        }
        return false;
    }

    close(e) {
        if (!this.targetIsInsideElement(e)) {
            this.element.style.display = 'block';
            this._isOpen = false;
            this.killOutSideClick();
        }
    }

    position(overridePosition) {
      let triggerRect = this.trigger.getBoundingClientRect(),
        elementRect = this.element.getBoundingClientRect(),
        position = overridePosition || this.options.position;
        this.element.classList.remove(Popover.TOP, Popover.BOTTOM, Popover.LEFT, Popover.RIGHT); // remove all possible values
        this.element.classList.add(position);
        if (position.indexOf(Popover.BOTTOM) !== -1) {
            this.element.style.left = ~~triggerRect.left + ~~((triggerRect.width / 2) - ~~(elementRect.width / 2)) + 'px';
            this.element.style.top = ~~triggerRect.bottom + 'px';
        } else if (position.indexOf(Popover.TOP) !== -1) {
            this.element.style.left = ~~triggerRect.left + ~~((triggerRect.width / 2) - ~~(elementRect.width / 2)) + 'px';
            this.element.style.top = ~~(triggerRect.top - elementRect.height) + 'px';
        } else if (position.indexOf(Popover.LEFT) !== -1) {
            this.element.style.top = ~~((triggerRect.top + triggerRect.height / 2) - ~~(elementRect.height / 2)) + 'px';
            this.element.style.left = ~~(triggerRect.left - elementRect.width) + 'px';
        } else {
            this.element.style.top = ~~((triggerRect.top + triggerRect.height / 2) - ~~(elementRect.height / 2)) + 'px';
            this.element.style.left = ~~triggerRect.right + 'px';
            this.element.classList.add(position);
        }
    }

    outsideClick() {
        document.addEventListener('', this.close.bind(this));
    }

    // killOutSideClick() {
    //   document.removeEventListener('click', this.close.bind(this));
    // }

    isOpen() {
        return this._isOpen;
    }
}

    Popover.TOP = 'top';
    Popover.RIGHT = 'right';
    Popover.BOTTOM = 'bottom';
    Popover.LEFT = 'left';

    document.addEventListener('DOMContentLoaded', function() {
      let btn = document.querySelector('#popoverOpener, #popoverOpener1, #popoverOpener3, #popoverOpener4'),
        template = document.querySelector('.popover'),
        pop = new Popover(template, btn, {
            position: Popover.LEFT
        }),
        links = template.querySelectorAll('.popover-content a');
        for (let i = 0, len = links.length; i < len; ++i) {
          let link = links[i];
            console.log(link);
            link.addEventListener('click', function(e) {
                e.preventDefault();
                pop.position(this.className);
                this.blur();
                return true;
            });
        }
    });

    $(document).on('keydown', function(e) { 
        var keyCode = e.keyCode || e.which; 

        if (keyCode == 27) { 
            $('.popover.left').hide("");
        } 
    });
    $(document).on("click", ".popover.left .btn-dz" , function(){
        $('.popover.left').hide("");
    });
</script>
<script type="text/javascript">
    $(document).ready(function(){
        $(".msg_dtz_mb2").click(function(e){
            $(".popover.left").hide(200);
        });
    });
</script>
<style type="text/css">
  .content_container{overflow-y: hidden;}
</style>
 
</asp:Content>


