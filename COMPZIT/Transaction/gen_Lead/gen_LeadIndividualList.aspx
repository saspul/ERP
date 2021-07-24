<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_LeadIndividualList.aspx.cs" Inherits="MasterPage_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
   <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>  
   <script src="/css/New%20Plugins/datatables/jquery.dataTables.min.js"></script>
   <script src="/css/New%20Plugins/datatable-responsive/datatables.responsive.min.js"></script>
   <script src="/js/Common/Common.js"></script> 
   <link href="/css/New css/pro_mng.css" rel="stylesheet" />
   <link rel="stylesheet" type="text/css" href="/css/New css/hcm_ns.css"/>
   <link href="/js/New%20js/date_pick/datepicker.css" rel="stylesheet" />
   <script src="/js/New%20js/date_pick/datepicker.js"></script>
   <script src="../../JavaScript/DatatablePlugin/select_datatable.js"></script>
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
      <script>
          //start-0006
          var confirmbox = 0;
          function IncrmntConfrmCounter() {
              confirmbox++;
          }
          function ConfirmMessage() {
              if (confirmbox > 0) {
                  ezBSAlert({
                      type: "confirm",
                      messageText: "Are you sure you want to leave this page?",
                      alertType: "info"
                  }).done(function (e) {
                      if (e == true) {

                          if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                              window.location.href = "gen_LeadList.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                          }
                          else {
                              window.location.href = "gen_LeadList.aspx";
                          }
                                    return false;
                                }
                                else {
                                    return false;
                                }
                            });
                
              }
              else {
                  if (document.getElementById("<%=hiddenL_MODE.ClientID%>").value != "") {
                      window.location.href = "gen_LeadList.aspx?L_MODE=" + document.getElementById("<%=hiddenL_MODE.ClientID%>").value + "";
                  }
                  else {
                      window.location.href = "gen_LeadList.aspx";
                  }

              }
              return false;
          }
          //stop-0006
    </script>
    <script>
        function getDetails(Id) {
            var userId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
            var leadId = document.getElementById("<%=hiddenLeadId.ClientID%>").value;
            //if (confirm(Id) == true) {
            // alert("hahah");
            PageMethods.TaskDelete(Id, userId, leadId, function (response) {
                document.getElementById('divTask').innerHTML = response;
            })
        }
        function getdetailsQtn(href) {
            window.location = href;
            return false;
        }
        function getdetailsMail(href) {
            window.location = href;
            return false;
        }
        function CancelAlertTask(href) {
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close this task?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {

                    window.location = href;
                                    return false;
                                }
                                else {
                                    return false;
                                }
                            });           
            return false;
        }
        //0013
        //QCLD4 EVM0012
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
                if (CheckIsRepeat() == true) {
                }
                else {
                    ret = false;
                    return ret;
                }
                var leadId = document.getElementById("<%=hiddenLeadId.ClientID%>").value;

                $Mo.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_LeadIndividualList.aspx/ProjectLoad",
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
        //0013
        function PostbackFun() {
            __doPostBack("<%=imgbtnWin.UniqueID %>", "");
            return false;
        }
        function ConfirmReOpen() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            if (confirm("Are you sure want to Re-Open the Opportunity ?")) {
                ret = true;
            }
            else {
                ret = false;
            }
            if (ret == false) {
                CheckSubmitZero();
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
        function SuccessInsertionFollowUp() {
            $("#success-alert").html("Opportunity note inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
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
        function SuccessReOpen() {
            $("#success-alert").html("Opportunity re-opened successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessAllocation() {
            $("#success-alert").html("Opportunity has been successfully allocated to selected user .");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessMail() {
            $("#success-alert").html("Mail send  successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            HideLoading();
        }
        function UnSuccessMail() {
            $("#divWarning").html("Mail was not send .Please check your connection .");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });           
            HideLoading();
        } function UpdateSuccessMail() {
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
        function RejectedMail() {
            $("#success-alert").html("Mail rejected sucessfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
            HideLoading();
        }
        function ShowLoading() {
          //  document.getElementById("myModalLoadingMail").style.display = "block";
           // document.getElementById("freezelayer").style.display = "";
        }
        function HideLoading() {
            document.getElementById("myModalLoadingMail").style.display = "none";
           // document.getElementById("freezelayer").style.display = "none";
        }
        function ErrorMsg() {
            $("#divWarning").html("Some error occured.Please review entered information !");
            $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
            });  
        }
        function SuccessUpdation() {
            $("#success-alert").html("Opportunity details updated successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }      
        function SuccessAddedNewLead() {
            $("#success-alert").html("Opportunity details inserted successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
        function SuccessStatusChange() {
            $("#success-alert").html("Opportunity status changed successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
        }
    </script>
    <%-------------------------------------------FOR MAIL----------------------------------------------------------%>
    <script>
        var $Mo = jQuery.noConflict();
        function OpenModalMail(objname, subEvent) {
            document.getElementById("<%=btnMailReject.ClientID%>").style.display = "none";
            document.getElementById("<%=btnSendMail.ClientID%>").style.display = "";
            document.getElementById("<%=btnReSendMail.ClientID%>").style.display = "none";
            document.getElementById('btnCC').style.visibility = "visible";
            document.getElementById('btnBCc').style.visibility = "visible";
            document.getElementById('divAttachmentHeading').style.visibility = "visible";
            document.getElementById('divAttachmentHeading').innerHTML = "Add Attachments";
            document.getElementById('imgarrowLeftMail').style.visibility = "visible";
            document.getElementById('imgarrowRightMail').style.visibility = "hidden";
            document.getElementById("TableFileUploadContainer").innerHTML = "";
            document.getElementById("<%=txtMailContent.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToAddress.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMailSubject.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtCccontent.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtBCccontent.ClientID%>").style.borderColor = "";
            localStorage.clear();           
            document.getElementById('CcDescriptions').innerHTML = "Add Cc Recipients"
            document.getElementById('BccDescriptions').innerHTML = "Add Bcc Recipients"
            document.getElementById('divBCcContent').style.display = "none";
            document.getElementById('divCcContent').style.display = "none";
            document.getElementById('divErrorRsnMail').style.visibility = "hidden";
            document.getElementById("<%=txtMailContent.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtMailContent.ClientID%>").readOnly = false;
            document.getElementById("<%=txtToAddress.ClientID%>").readOnly = false;
            document.getElementById("<%=txtMailSubject.ClientID%>").readOnly = false;
            document.getElementById("<%=txtCccontent.ClientID%>").readOnly = false;
            document.getElementById("<%=txtBCccontent.ClientID%>").readOnly = false;
            document.getElementById("<%=txtFromAdress.ClientID%>").readOnly = true;         
            var signature = document.getElementById("<%=hiddenMailSignature.ClientID%>").value;
            var toAddress = document.getElementById("<%=hiddenMailToAddress.ClientID%>").value;
            var OtherToAddrss = document.getElementById("<%=hiddenOtherToAddress.ClientID%>").value;
            var subject = document.getElementById("<%=hiddenMailSubject.ClientID%>").value;
            var fromAddress = document.getElementById("<%=hiddenMailFrom.ClientID%>").value;
            document.getElementById("<%=txtMailContent.ClientID%>").value = signature;
            document.getElementById("<%=txtToAddress.ClientID%>").value = toAddress;
            document.getElementById("<%=txtMailSubject.ClientID%>").value = subject;
            if (OtherToAddrss != "") {
                document.getElementById("<%=txtCccontent.ClientID%>").value = OtherToAddrss;
                ShowOrHideCc();
            }
            else {
                document.getElementById("<%=txtCccontent.ClientID%>").value = "";
            }
            document.getElementById("<%=txtBCccontent.ClientID%>").value = "";
            document.getElementById("<%=txtFromAdress.ClientID%>").value = fromAddress;           
            document.getElementById("<%=txtMailContent.ClientID%>").focus();
            AddFileUpload();
            return false;
        }


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
            document.getElementById('divErrorRsnMail').style.visibility = "hidden";
           // document.getElementById(").innerHTML = "";
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
                        document.getElementById('btnCC').style.visibility = "hidden";
                        document.getElementById('CcDescriptions').style.visibility = "hidden";
                        document.getElementById('divCcContent').style.display = "none";
                        document.getElementById('btnBCc').style.visibility = "hidden";
                        document.getElementById('BccDescriptions').style.visibility = "hidden";
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
                            document.getElementById('btnCC').style.visibility = "hidden";
                            document.getElementById('CcDescriptions').style.visibility = "hidden";
                            document.getElementById('divCcContent').style.display = "";
                        }
                        else {
                            document.getElementById('btnCC').style.visibility = "hidden";
                            document.getElementById('CcDescriptions').style.visibility = "hidden";
                            document.getElementById('divCcContent').style.display = "none";

                        }
                        if (BccMailIds != "" && BccMailIds != null) {
                            document.getElementById("<%=txtBCccontent.ClientID%>").value = BccMailIds;
                            document.getElementById('btnBCc').style.visibility = "hidden";
                            document.getElementById('BccDescriptions').style.visibility = "hidden";
                            document.getElementById('divBCcContent').style.display = "";
                        }
                        else {
                            document.getElementById('btnBCc').style.visibility = "hidden";
                            document.getElementById('BccDescriptions').style.visibility = "hidden";
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
                    document.getElementById('divAttachmentHeading').style.visibility = "hidden";
                }
                else {
                    document.getElementById('divAttachmentHeading').style.visibility = "visible";
                    document.getElementById('divAttachmentHeading').innerHTML = "Attachments";
                }
            });           
            return false;
        }

        function CloseModalMail() {
            if (document.getElementById('<%=btnSendMail.ClientID%>').style.display == "none" && document.getElementById('<%=btnReSendMail.ClientID%>').style.display == "none") {
                var $noCon = jQuery.noConflict();
                $noCon('#send_mail').removeClass('show');
                $noCon('#send_mail').modal('hide');
                $noCon('.modal-backdrop fade in').remove();

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

                        var $noCon = jQuery.noConflict();
                        $noCon('#send_mail').removeClass('show');
                        $noCon('#send_mail').modal('hide');                       
                        $noCon('.modal-backdrop fade in').remove();
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

                var $noCon = jQuery.noConflict();
                $noCon('#send_mail').removeClass('show');
                $noCon('#send_mail').modal('hide');
                $noCon('.modal-backdrop fade in').remove();
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


        //for Cc and Bcc of mail content
        function ShowOrHideCc() {
            if (document.getElementById('divCcContent').style.display != "") {

                document.getElementById('divCcContent').style.display = "";
                document.getElementById("<%=txtCccontent.ClientID%>").focus();
            }
            else {

                document.getElementById('divCcContent').style.display = "none";

            }
            return false;
        }
        function ShowOrHideBCc() {



            if (document.getElementById('divBCcContent').style.display != "") {

                document.getElementById('divBCcContent').style.display = "";
                document.getElementById("<%=txtBCccontent.ClientID%>").focus();
                }
                else {


                    document.getElementById('divBCcContent').style.display = "none";

                }

                return false;

            }
            function CloseBCcMail() {
                if (document.getElementById("<%=txtBCccontent.ClientID%>").value == "") {

                    document.getElementById('divBCcContent').style.display = "none";
                    document.getElementById('divBCcHelper').style.display = "none";
                }
                else {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure to remove the Bcc contacts?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            document.getElementById("<%=txtBCccontent.ClientID%>").value = "";
                            document.getElementById('divBCcContent').style.display = "none";
                            document.getElementById('divBCcHelper').style.display = "none";                    
                    return false;
                }
                else {
                    return false;
                }
            }); 
                }
                return false;
            }
            function CloseCcMail() {
                if (document.getElementById("<%=txtCccontent.ClientID%>").value == "") {

                document.getElementById('divCcContent').style.display = "none";
                document.getElementById('divCcHelper').style.display = "none";
                divCcHelper
            }
                else {
                    ezBSAlert({
                        type: "confirm",
                        messageText: "Are you sure to remove the Cc contacts?",
                        alertType: "info"
                    }).done(function (e) {
                        if (e == true) {
                            document.getElementById("<%=txtCccontent.ClientID%>").value = "";
                            document.getElementById('divCcContent').style.display = "none";
                            document.getElementById('divCcHelper').style.display = "none";                 
                            return false;
                        }
                        else {
                            return false;
                        }
                    }); 
               

            }
                return false;
        }

        function loadCorrespondingCc(textContent, event) {


            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 188) {

                PageMethods.CcHistoryLoad(document.getElementById("<%=txtCccontent.ClientID%>").value, function (response) {
                    var varCcMailId = response;
                    document.getElementById('divCcHelper').innerHTML = varCcMailId;
                    document.getElementById('divCcHelper').style.display = "";
                });
            }

        }



        // for bcc
        function loadCorrespondingBCc(textContent, event) {


            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 188) {

                PageMethods.BCcHistoryLoad(document.getElementById("<%=txtBCccontent.ClientID%>").value, function (response) {
                    var varBCcMailId = response;

                    document.getElementById('divBCcHelper').innerHTML = varBCcMailId;
                    document.getElementById('divBCcHelper').style.display = "";
                });
            }

        }
        function AddBCcToBCcText(strMailIds, spanid) {
            var stringLength = document.getElementById("<%=txtBCccontent.ClientID%>").value.length;
            if (document.getElementById("<%=txtBCccontent.ClientID%>").value.charAt(stringLength - 1) != ",") {

                document.getElementById("<%=txtBCccontent.ClientID%>").value += "," + strMailIds;
            }
            else {
                document.getElementById("<%=txtBCccontent.ClientID%>").value += strMailIds;
            }
            document.getElementById(spanid).style.display = "none";
            document.getElementById('divBCcHelper').style.display = "";

            document.getElementById("<%=txtBCccontent.ClientID%>").focus();
        }

        function AddCcToCcText(strMailIds, spanid) {
            var stringLength = document.getElementById("<%=txtCccontent.ClientID%>").value.length;
            if (document.getElementById("<%=txtCccontent.ClientID%>").value.charAt(stringLength - 1) != ",") {

                document.getElementById("<%=txtCccontent.ClientID%>").value += "," + strMailIds;
            }
            else {
                document.getElementById("<%=txtCccontent.ClientID%>").value += strMailIds;
            }
            document.getElementById(spanid).style.display = "none";
            document.getElementById('divCcHelper').style.display = "";

            document.getElementById("<%=txtCccontent.ClientID%>").focus();
        }



    </script>

    <script>

        function CcDescriptionPosition(object) {
            var $Mo = jQuery.noConflict();

            var offset = $Mo("#" + object).offset();

            var posY = 0;
            var posX = 0;
            posY = offset.top - 2;
            // alert(posY);
            posX = offset.left
            //  alert(posX);
            posX = 63.367;
            posY = 120;
            var d = document.getElementById('CcDescriptions');
            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
        }
        function BccDescriptionPosition(object) {
            var $Mo = jQuery.noConflict();

            var offset = $Mo("#" + object).offset();

            var posY = 0;
            var posX = 0;
            posY = offset.top - 2;

            posX = offset.left

            posX = 67.367;
            posY = 120;
            var d = document.getElementById('BccDescriptions');


            d.style.position = "absolute";
            d.style.left = posX + '%';
            d.style.top = posY + 'px';
            //  alert('a');
        }
    </script>
    <script type="text/javascript">

        var Filecounter = 0;

        function AddFileUpload() {

            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';


            var labelForStyle = '<label for="file' + Filecounter + '" class="custom-file-upload" style="padding-top:1px"; > <img src="../../Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter +

                           '" type="file" onchange="ChangeFile(' + Filecounter + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/>';

            FrecRow += '<td style="width: 27%;" >' + tdInner + '</td>';

            FrecRow += '<td  id="filePath' + Filecounter + '"  ></td  >';

            //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

            //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%; padding-left: 4px;"> <input type="image" class="QuotnEntryField" src="../../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input type="image" id="QuotnEntryFieldId' + Filecounter + '"  class="QuotnEntryField" src="../../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload(' + Filecounter + ');"    style=" cursor: pointer;" ></td>';

            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">INS</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;"></td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);

            document.getElementById('filePath' + Filecounter).innerHTML = 'No File Selected';
            document.getElementById('QuotnEntryFieldId' + Filecounter).focus();
            Filecounter++;

        }


        function ViewAttachment(editTransDtlId, EditFileName, EditActualFileName) {
            var FrecRow = '<tr id="FilerowId_' + Filecounter + '" >';


            var labelForStyle = '<label for="file' + Filecounter + '" class="custom-file-upload" > <img src="../../Images/Icons/cloud_upload.jpg"></img>Upload File</label>';
            var tdInner = labelForStyle + '<input   id="file' + Filecounter + '" name = "file' + Filecounter +

                           '" type="file" onchange="ChangeFile(' + Filecounter + ')" />';

            FrecRow += '<td style="width: 27%; display:none;" >' + tdInner + '</td>';

            var tdFileNameEdit = '<a class="AnchorAttachmntEdit" target="_blank" href=' + document.getElementById("<%=hiddenMailFilePath.ClientID%>").value + EditFileName + ' >' + EditActualFileName + '</a>';

            FrecRow += '<td colspan="2"  id="filePath' + Filecounter + '"  >' + tdFileNameEdit + '</td  >';

            //  FrecRow += ' <td> <input id="Button' + Filecounter + '" class="save" type="button" ' +

            //         'value="Remove" style="float: none;" onclick = "RemoveFileUpload(' + Filecounter + ')" /> </td >';

            FrecRow += '<td id="FileIndvlAddMoreRow' + Filecounter + '"  style="width: 1.5%; padding-left: 4px;"> <input disabled type="image" class="QuotnEntryField" src="../../Images/Icons/addFile.png" alt="Add" onclick="return CheckaddMoreRowsIndividualFiles(' + Filecounter + ');" style="  cursor: pointer;"></td>';
            FrecRow += '<td style="width: 1.5%; padding-left: 1px;"><input disabled type="image" class="QuotnEntryField" src="../../Images/Icons/deleteFile.png" alt="Delete"  onclick = "return RemoveFileUpload(' + Filecounter + ');"    style=" cursor: pointer;" ></td>';

            FrecRow += ' <td id="FileInx' + Filecounter + '" style="display: none;" > </td>';
            FrecRow += '<td id="FileSave' + Filecounter + '" style="display: none;"> </td>';
            FrecRow += '<td id="FileEvt' + Filecounter + '" style="display: none;">UPD</td>';
            FrecRow += '<td id="FileDtlId' + Filecounter + '" style="display: none;">' + editTransDtlId + '</td>';
            FrecRow += '<td id="DbFileName' + Filecounter + '" style="display: none;">' + EditFileName + '</td>';
            FrecRow += '</tr>';

            jQuery('#TableFileUploadContainer').append(FrecRow);
            document.getElementById("FileInx" + Filecounter).innerHTML = Filecounter;
            document.getElementById("FileIndvlAddMoreRow" + Filecounter).style.opacity = "0.3";
            // document.getElementById('filePath' + Filecounter).innerHTML = EditActualFileName;
            //   FileLocalStorageAdd(Filecounter);
            //document.getElementById("FilerowId_" + Filecounter).focus();
            Filecounter++;

        }


        function RemoveFileUpload(removeNum) {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to delete selected file?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    var Filerow_index = jQuery('#FilerowId_' + removeNum).index();
                    //  FileLocalStorageDelete(Filerow_index, removeNum);
                    jQuery('#FilerowId_' + removeNum).remove();



                    // alert(Filerow_index);

                    var TableFileRowCount = document.getElementById("TableFileUploadContainer").rows.length;

                    if (TableFileRowCount != 0) {
                        var idlast = $noC('#TableFileUploadContainer tr:last').attr('id');
                        //  var idsecondlast = $('#TableaddedRows tr:last').attr('id').prev();
                        //  $('#TableaddedRows tr').eq($('#TableaddedRows tr').length - 2).css("border", "1px solid red");
                        if (idlast != "") {
                            var res = idlast.split("_");
                            //  alert(res[1]);
                            document.getElementById("FileInx" + res[1]).innerHTML = " ";
                            document.getElementById("FileIndvlAddMoreRow" + res[1]).style.opacity = "1";
                        }
                    }
                    else {
                        AddFileUpload();


                    }                    
                    return false;
                }
                else {
                    return false;
                }
            }); 
            return false;
        }

    </script>
    <script>
        function ChangeFile(x) {

            if (document.getElementById('file' + x).value != "") {
                document.getElementById('filePath' + x).innerHTML = document.getElementById('file' + x).value;

            }
            else {
                document.getElementById('filePath' + x).innerHTML = 'No File Selected';


            }
            var SavedorNot = document.getElementById("FileSave" + x).innerHTML;
            //   alert('hi SavedorNot' + SavedorNot);
            if (SavedorNot == "saved") {
                var row_index = jQuery('#FilerowId_' + x).index();
                //    FileLocalStorageEdit(x, row_index);
            }
            else {
                // FileLocalStorageAdd(x);
            }

        }
        function CheckFileUploaded(x) {

            if (document.getElementById('file' + x).value != "") {
                return true;
            }
            else {
                return false;
            }


        }
        function CheckaddMoreRowsIndividualFiles(x) {
            // for add image in each row

            var check = document.getElementById("FileInx" + x).innerHTML;

            //for checking if to save  orelese if we had entered row and deleted row below and again click enter multiple data is stored in hiddenfield
            //       var SavedorNot = document.getElementById("tdSave" + x).innerHTML;
            //  alert(check);
            if (check == " ") {

                var Fevt = document.getElementById("FileEvt" + x).innerHTML;
                if (Fevt != 'UPD') {
                    if (CheckFileUploaded(x) == true) {
                        document.getElementById("FileInx" + x).innerHTML = x;
                        document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                        AddFileUpload();
                        return false;
                    }
                }
                else {

                    document.getElementById("FileInx" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRow" + x).style.opacity = "0.3";
                    AddFileUpload();
                    return false;
                }
            }
            return false;
        }

        function FileLocalStorageAdd(x) {

            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];


            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;
            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            return true;
            var $addFileAt = jQuery.noConflict();

            if (Fevt == 'INS') {

                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"

                });
            }
            else if (Fevt == 'UPD') {

                var client = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });
            }


            tbClientQuotationFileUpload.push(client);
            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));

            $addFileAt("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));



            //  alert("The FILE ADDED.");
            //  var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //   alert(h);

            document.getElementById("FileSave" + x).innerHTML = "saved";
            //   alert('saved');
            return true;

        }

        function FileLocalStorageDelete(row_index, x) {
            var $DelFile = jQuery.noConflict();
            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];



            // Using splice() we can specify the index to begin removing items, and the number of items to remove.
            tbClientQuotationFileUpload.splice(row_index, 1);
            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));
            $DelFile("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));
            //   alert("FILE deleted.");

            //   var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //  alert(h);


            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            if (Fevt == 'UPD') {
                var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

                if (FdetailId != '') {

                    // DeleteFileLSTORAGEAdd(x);
                }

            }
        }



        function FileLocalStorageEdit(x, row_index) {
            var tbClientQuotationFileUpload = localStorage.getItem("tbClientQuotationFileUpload");//Retrieve the stored data

            tbClientQuotationFileUpload = JSON.parse(tbClientQuotationFileUpload); //Converts string to object

            if (tbClientQuotationFileUpload == null) //If there is no data, initialize an empty array
                tbClientQuotationFileUpload = [];

            var FilePath = document.getElementById("filePath" + x).innerHTML;
            var FdetailId = document.getElementById("FileDtlId" + x).innerHTML;

            var Fevt = document.getElementById("FileEvt" + x).innerHTML;
            var $FileE = jQuery.noConflict();
            if (Fevt == 'INS') {


                tbClientQuotationFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //     FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "0"
                });//Alter the selected item on the table
            }
            else {

                tbClientQuotationFileUpload[row_index] = JSON.stringify({
                    ROWID: "" + x + "",
                    //   FILEPATH: "" + FilePath + "",
                    EVTACTION: "" + Fevt + "",
                    DTLID: "" + FdetailId + ""

                });//Alter the selected item on the table



            }



            localStorage.setItem("tbClientQuotationFileUpload", JSON.stringify(tbClientQuotationFileUpload));
            $FileE("#cphMain_HiddenField2_FileUpload").val(JSON.stringify(tbClientQuotationFileUpload));

            //        alert("The FILE EDITED.");

            //      var h = document.getElementById("<%=HiddenField2_FileUpload.ClientID%>").value;
            //     alert(h);
            return true;
        }
    </script>
    <%-----------------------------------------------------FOR FOLLOW UP------------------------------------------------------------------%>
    <script>
        var $Mo = jQuery.noConflict();
        function OpenModalFollowUp(objname, subEvent) {
            document.getElementById('<%=btnFollowUpSave.ClientID%>').style.visibility = "visible";                     
            //for options in LeadSource

            var OptionsSrc = document.getElementById("<%=divOptionsLeadSource.ClientID%>").innerHTML;

            var DfltOptnSrc = '<option  value="--SELECT--">--SELECT--</option>';
            var TotalOptnSrc = "";
            if (OptionsSrc == "") {
                TotalOptnSrc = DfltOptnSrc;
            }
            else {

                TotalOptnSrc = DfltOptnSrc + OptionsSrc;

            }

            var LeadSrcHtml = ' <select id="ddlFollowUpLeadSource" class="form-control fg2_inp1 inp_mst" > ';
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


           // document.getElementById("myModalFollowUp").style.display = "block";
            // document.getElementById("freezelayer").style.display = "";
           // $('#myModalFollowUp').modal('show');

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


            var d = document.getElementById('myModalFollowUp');
          //  d.style.position = "absolute";
           // d.style.left = posX + '%';
           // d.style.top = posY + 'px';


            document.getElementById("ddlFollowUpLeadSource").focus();

            return false;
        }


        function ViewModalFollowUp(objname, subEvent, LeadSrcId, LeadSrcName, FollowUpDate, Descptn) {
            document.getElementById("<%=btnFollowUpSave.ClientID%>").style.visibility = "hidden";                     
            //for options in LeadSource

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

            document.getElementById("ddlFollowUpLeadSource").disabled = true;
            document.getElementById("<%=txtFollowUpDate.ClientID%>").disabled = true;
            document.getElementById("<%=txtFollowUpDescptn.ClientID%>").disabled = true;


         //   document.getElementById("myModalFollowUp").style.display = "block";
         //   $('#myModalFollowUp').modal('show');
           // document.getElementById("freezelayer").style.display = "";

            var desiredValueSource = LeadSrcId;
            var elSrc = document.getElementById("ddlFollowUpLeadSource");
            for (var i = 0; i < elSrc.options.length; i++) {
                if (elSrc.options[i].value == desiredValueSource) {
                    elSrc.selectedIndex = i;
                    break;
                }
            }

            var FoSrc = document.getElementById("ddlFollowUpLeadSource").value;
            //  alert(LHead);
            if (FoSrc == "--SELECT--" || FoSrc == "") {
                //add option code
                $Mo("#ddlFollowUpLeadSource").append($Mo('<option>', {
                    value: LeadSrcId,
                    text: LeadSrcName
                }));
                var AdesiredValueSource = LeadSrcId;
                var AelSrc = document.getElementById("ddlFollowUpLeadSource");
                for (var i = 0; i < AelSrc.options.length; i++) {
                    if (AelSrc.options[i].value == AdesiredValueSource) {
                        AelSrc.selectedIndex = i;
                        break;
                    }
                }
            }
            document.getElementById("<%=txtFollowUpDate.ClientID%>").value = FollowUpDate;
            document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value = Descptn;
            return false;
        }
        function CloseModalFollowUp() {
            if (document.getElementById('<%=btnFollowUpSave.ClientID%>').style.visibility == "hidden") {
                document.getElementById("<%=txtFollowUpDate.ClientID%>").value = "";
                document.getElementById("<%=txtFollowUpDescptn.ClientID%>").value = "";             
                //document.getElementById("myModalFollowUp").style.display = "none";
                $('#myModalFollowUp').modal('hide');
               
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
                      
                        $('#myModalFollowUp').modal('hide');
                                    
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
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

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
                    $("#divErrorRsnFollowUp").html("Sorry, Date cannot be greater than current date !.");
                    $("#divErrorRsnFollowUp").fadeTo(3000, 500).slideUp(500, function () {
                    });  
                    ret = false;
                }

            }



            if (ret == true) {
                document.getElementById("myModalFollowUp").style.display = "none";
               

            }
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }




    </script>



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
            document.getElementById("H1").innerText="Add Follow-Up / Task";
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

            var TaskSbjctHtml = ' <select id="ddlTaskSubject"  class="form-control fg2_inp1" > ';
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
           // document.getElementById("myModalTask").style.display = "block";
           // document.getElementById("freezelayer").style.display = "";

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



        function EditModalTask(objname, subEvent, TaskId, TaskSubjctId, TaskSubjctName, TaskDueDate, TaskDueHr, TaskDueMin, TaskDueAM_PM, Descptn, TaskSts) {
            document.getElementById("H1").innerText = "Edit Follow-Up / Task";
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
           
            return false;
        }
        

        function ViewModalTask(objname, subEvent, TaskSubjctId, TaskSubjctName, TaskDueDate, TaskDueHr, TaskDueMin, TaskDueAM_PM, Descptn, TaskSts, TaskClsDate, TaskClsHr, TaskClsMin, TaskClsAM_PM, ClsStatus) {
            document.getElementById("H1").innerText = "View Follow-Up / Task";
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

                var TaskSbjctHtml = ' <select id="ddlTaskSubject"  class="form-control fg2_inp1" > ';
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
           // document.getElementById("myModalTask").style.display = "block";
           // document.getElementById("freezelayer").style.display = "";


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

                    posY = offset.top - 505;

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
                posY = offset.top - 410;

                document.getElementById('divTaskClsDate').style.display = "none";
                document.getElementById('divTaskClsTime').style.display = "none";
            }
          
            return false;
        }
        function CloseModalTask() {
            //   alert('close');

            if (document.getElementById('<%=btnTaskSave.ClientID%>').style.visibility == "hidden" && document.getElementById('<%=btnTaskUpd.ClientID%>').style.visibility == "hidden") {
                document.getElementById("<%=txtTaskDate.ClientID%>").value = "";
                document.getElementById("<%=txtTaskDescptn.ClientID%>").value = "";
             
                $('#myModalTask').modal('hide');
              
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
                      
                        $('#myModalTask').modal('hide');
                  
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
            // alert('CheckFollowUp');
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            document.getElementById("<%=hiddenTaskSubjctId.ClientID%>").value = "";
            // replacing < and > tags


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
                //   alert(isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])));
                //  alert(SelectedValueSrc);
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
                        $("#divErrorRsnTask").html("Sorry, Follow-Up/Task Due Time cannot be Less than Current Time !.");
                        $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                        });
                       
                        ret = false;
                    }
                    else if (hours == SelectedValueHr) {
                        if (minutes > SelectedValueMin) {
                            $("#divErrorRsnTask").html("Sorry, Follow-Up/Task Due Time cannot be Less than Current Time !.");
                            $("#divErrorRsnTask").fadeTo(3000, 500).slideUp(500, function () {
                            });
                          
                            ret = false;

                        }

                    }

            }
    }



    if (ret == true) {
        document.getElementById("myModalTask").style.display = "none";
       

    }
    if (ret == false) {
        CheckSubmitZero();

    }
            // alert(ret);
    return ret;
}




    </script>



    <%-----------------------------------------------------FOR CANCEL TASK------------------------------------------------------------------%>



    <script>

        var $Mo = jQuery.noConflict();




        function OpenModalCancelTask(objname, subEvent, TaskId, TaskInsDate, TaskInsHr, TaskInsMin, TaskInsAM_PM, TaskCurDate, TaskCurHr, TaskCurMin, TaskCurAM_PM) {
            //  alert(objname);
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close this Follow-Up/Task?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    $('#myModalCancelTask').modal('show');
                    
                    document.getElementById('<%=btnCancelTaskSave.ClientID%>').style.visibility = "visible";                 
                    document.getElementById('<%=hiddenTaskId.ClientID%>').value = TaskId;
               

                document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>").innerHTML = '';
                document.getElementById("<%=lblACancelTaskHr.ClientID%>").innerHTML = '';
                    document.getElementById("<%=lblACancelTaskMin.ClientID%>").innerHTML = '';



                  

                document.getElementById("<%=ddlCCancelTaskHr.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlCCancelTaskMin.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=ddlCCancel_AM_PM.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").style.borderColor = "";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "";


                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").disabled = true;


                   

                    document.getElementById("<%=lblACancelTaskHr.ClientID%>").innerHTML = TaskInsHr;

                    document.getElementById("<%=lblACancelTaskMin.ClientID%>").innerHTML = TaskInsMin;

                    document.getElementById("<%=lblACancelTask_AM_PM.ClientID%>").innerHTML = TaskInsAM_PM;



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
            ezBSAlert({
                type: "confirm",
                messageText: "Do you want to close  without completing  closing process?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                    document.getElementById("<%=txtACancelTaskDate.ClientID%>").value = "";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").value = "";

                   
                document.getElementById("myModalCancelTask").style.display = "none";
               
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
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

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
                    $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task Completed Date cannot be Less than Inserted Date !.");
                    $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                    });
                   
                    ret = false;
                }
                else if (CdateDateCntrlr > dateCurrentDate) {
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtCCancelTaskDate.ClientID%>").focus();
                    $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task Completed Date cannot be Greater than Current Date !.");
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
                            $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task Completed Time cannot be Less than Inserted Time !.");
                            $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                            });
                           
                            ret = false;
                        }
                        else if (ASelectedValueHr == CSelectedValueHr) {
                            if (ASelectedValueMin > CSelectedValueMin) {
                                $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task Completed Time cannot be Less than Inserted Time !.");
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
                            $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task Completed Time cannot be Greater than Current Time !.");
                            $("#divErrorRsnCancelTask").fadeTo(3000, 500).slideUp(500, function () {
                            });
                           
                            ret = false;
                        }
                        else if (hours == SelectedValueHr) {
                            if (minutes < SelectedValueMin) {
                                $("#divErrorRsnCancelTask").html("Sorry, Follow-Up/Task Completed Time cannot be Greater than Current Time !");
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
        document.getElementById("myModalCancelTask").style.display = "none";
       

    }
    if (ret == false) {
        CheckSubmitZero();

    }
            // alert(ret);
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


    <%-----------------------------------------------------FOR Allocate------------------------------------------------------------------%>



    <script>
      
        var $Mo = jQuery.noConflict();


            function OpenModalAllocate(objname, subEvent) {
                document.getElementById('<%=btnAllocateSave.ClientID%>').style.visibility = "visible";
  
            //for options in Task Subject

            var OptionsAllocateEmp = document.getElementById("<%=divOptionsAllocateEmp.ClientID%>").innerHTML;

            var DfltOptnAllocateEmp = '<option  value="--SELECT EMPLOYEE--">--SELECT EMPLOYEE--</option>';
            var TotalOptnAllocateEmp = "";
            if (OptionsAllocateEmp == "") {
                TotalOptnAllocateEmp = DfltOptnAllocateEmp;
            }
            else {

                TotalOptnAllocateEmp = DfltOptnAllocateEmp + OptionsAllocateEmp;

            }

            var AllocateEmpHtml = ' <select id="ddlAllocateEmp"  class="form-control fg2_inp1 fg_chs1" > ';
            //  </select> </td>
            AllocateEmpHtml += TotalOptnAllocateEmp;
            AllocateEmpHtml += ' </select>  ';

            document.getElementById('SpanddlAllocate').innerHTML = AllocateEmpHtml;

           
            document.getElementById("ddlAllocateEmp").style.borderColor = "";


            document.getElementById("ddlAllocateEmp").disabled = false;


          

            var desiredValueEmp = "--SELECT EMPLOYEE--";

            var elEmp = document.getElementById("ddlAllocateEmp");
            for (var i = 0; i < elEmp.options.length; i++) {
                if (elEmp.options[i].value == desiredValueEmp) {
                    elEmp.selectedIndex = i;
                    break;
                }
            }         
            document.getElementById("ddlAllocateEmp").focus();
            return false;
        }

        function CloseModalAllocate() {
            ezBSAlert({
                type: "confirm",
                messageText: "Are you sure you want to close?",
                alertType: "info"
            }).done(function (e) {
                if (e == true) {
                   
                    document.getElementById("myModalAllocate").style.display = "none";                   
                    return false;
                }
                else {
                    return false;
                }
            }); 
            return false;
        }
        function CheckAllocate() {
            // alert('CheckFollowUp');
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            document.getElementById("<%=hiddenAllocateEmpId.ClientID%>").value = "";

            document.getElementById("ddlAllocateEmp").style.borderColor = "";

            var DropdownListEmp = document.getElementById("ddlAllocateEmp");
            var SelectedValueEmp = DropdownListEmp.value;
            document.getElementById("<%=hiddenAllocateEmpId.ClientID%>").value = SelectedValueEmp;
            var HiddenEmp = document.getElementById("<%=hiddenAllocateEmpId.ClientID%>").value




          

            if (SelectedValueEmp == "--SELECT EMPLOYEE--" || HiddenEmp == "--SELECT EMPLOYEE--" || HiddenEmp == "") {
                $("#divErrorRsnAllocate").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                $("#divErrorRsnAllocate").fadeTo(3000, 500).slideUp(500, function () {
                });                 
                    //   alert(isNaN(Date.parse(Fdata[2] + "-" + Fdata[1] + "-" + Fdata[0])));
                    //  alert(SelectedValueSrc);
                    if (SelectedValueEmp == "--SELECT EMPLOYEE--") {

                        document.getElementById("ddlAllocateEmp").focus();

                        document.getElementById("ddlAllocateEmp").style.borderColor = "Red";
                        ret = false;
                    }


                }

                if (ret == true) {
                    document.getElementById("myModalAllocate").style.display = "none";
                  

                }
                if (ret == false) {
                    CheckSubmitZero();

                }
            // alert(ret);
                return ret;
            }


    </script>
    <script>

        function TaskStopped(Task_Id, LeadRandom_Id) {

            //web method for closing or deleting a task

            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;

            if (OrgId != '' && OrgId != null && Task_Id != '' && Task_Id != null && LeadRandom_Id != '' && LeadRandom_Id != null) {
                //     alert('hi entered');
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_LeadIndividualList.aspx/TaskClose",
                    data: '{organisationId:"' + OrgId + '" ,TaskId:"' + Task_Id + '"}',
                    dataType: "json",
                    success: function (data) {
                        window.location = 'gen_LeadIndividualList.aspx?Id=' + LeadRandom_Id + '&InsUpd=ClsTask';
                    },
                    error: function (result) {
                        // alert("Error");
                    }
                });

            }
        }
        //0013
        function ProjectLoad() {

            //web method for registering a project

            var LeadId = document.getElementById("<%=hiddenLeadId.ClientID%>").value;

            if (LeadId != '' && LeadId != null) {
                //     alert('hi entered');
                $.ajax({
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: "gen_LeadIndividualList.aspx/ForProjectLoad",
                    data: '{leadId:"' + LeadId + '"}',
                    dataType: "json",
                    success: function (data) {

                        window.location = 'gen_LeadIndividualList.aspx?LodId=' + LeadId + '&InsUpd=ClsTask';
                    },
                    error: function (result) {
                        // alert("Error");
                    }
                });

            }
        }

    </script>



   <%-- <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>--%>
     <script type="text/javascript">
         var $GoTop = jQuery.noConflict();
         $GoTop(function () {
             $GoTop('#scrollToTop').bind("click", function () {
                 $GoTop('html, body').animate({ scrollTop: 0 }, 500);

                 return false;
             });
         });
    </script>

    <script type="text/javascript">
       // var $noCon = jQuery.noConflict();
      //  $noCon(window).load(function () {
            // Run code
        // alert('loaded statr');

        var $noCon = jQuery.noConflict();
        //(window).load(function () {
            
            $noCon( window ).on("load", function() {


           // document.getElementById("myModalMail").style.display = "none";
            document.getElementById("myModalFollowUp").style.display = "none";
            document.getElementById("myModalTask").style.display = "none";
            document.getElementById("myModalCancelTask").style.display = "none";
            //document.getElementById("myModalLossReason").style.display = "none";
            document.getElementById("myModalAllocate").style.display = "none";
            document.getElementById("myModalLoadingMail").style.display = "none";  
                
            if (document.getElementById("<%=hiddenOpenAdditionalAttch.ClientID%>").value == "") {               
            }
            else {
                var ReopenString = document.getElementById("<%=hiddenOpenAdditionalAttch.ClientID%>").value;
                OpenQtnAtchmntAdditional();               
                if (ReopenString == "OPEN") {
                    SuccessInsertAddtnlQtnAttch();
                }
                else if (ReopenString == "REMOVE") {                   
                    SuccessDeleteAddtnlQtnAttch();
                }
                else if (ReopenString == "STSCHNGE") {
                    SuccessStsChngeAddtnlQtnAttch();
                }
                else if (ReopenString == "NOTUP") {
                    SuccessStsChngeAddtnlQtnAttchErr();
                }
            }

                if (document.getElementById("<%=hiddenOpenSupplierAttch.ClientID%>").value == "") {
                   
                }
                else {
                    var ReopenString = document.getElementById("<%=hiddenOpenSupplierAttch.ClientID%>").value;
                    OpenQtnAtchmntAdditional();                  
                if (ReopenString == "OPEN") {
                    SuccessInsertAddtnlQtnAttch();
                }
                else if (ReopenString == "REMOVE") {
                    SuccessDeleteSupplierQtnAttch();

                }
            }
                if (document.getElementById("<%=hiddenOpenTenderAttch.ClientID%>").value == "") {                  
                }
                else {
                    var ReopenString = document.getElementById("<%=hiddenOpenTenderAttch.ClientID%>").value;
                    OpenQtnAtchmntAdditional();                   
                if (ReopenString == "OPEN") {
                    SuccessInsertAddtnlQtnAttch();
                }
                else if (ReopenString == "REMOVE") {
                    SuccessDeleteTenderQtnAttch();

                }
            }



            //evm0012 regrt Mail
            if (document.getElementById("<%=hiddenRegretMailForLeadID.ClientID%>").value == "") {
                document.getElementById("MymodalRegretMail").style.display = "none";
            }
            else {
                LoadRegretMailWindow();
            }
            localStorage.clear();
        });
    </script>

    <script>
        function isTag(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;


            if (keyCode == 60 || keyCode == 62) {
                //< and >
                return false;
            }
        }
        function isTagDisableEnter(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;


            if (keyCode == 60 || keyCode == 62 || keyCode == 13) {
                //< and >
                return false;
            }
        }
        //<!-- Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TXTBOX
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }

        function PostbackFun(Email, MailType) {
            document.getElementById("<%=hiddenResendQtnMailID.ClientID%>").value = Email;
            document.getElementById("<%=hiddenResendQtnMailType.ClientID%>").value = MailType;
           /// document.getElementById("myModalMail").style.display = "none";
         
            ShowLoading();
            __doPostBack("<%=btnResendQtnMail.UniqueID %>", "");

            return false;
        }

        function PostbackFunForRevQutn(BkupId, Email, MailType) {
            document.getElementById("<%=hiddenResendQtnMailID.ClientID%>").value = Email;
            document.getElementById("<%=hiddenResendQtnMailType.ClientID%>").value = MailType;
            document.getElementById("<%=hiddenQtnBackupID.ClientID%>").value = BkupId;
           // document.getElementById("myModalMail").style.display = "none";
          
            ShowLoading();
            __doPostBack("<%=btnReSendMailQtn_BackUp.UniqueID %>", "");

            return false;
        }

        function LoadRegretMailWindow() {
            //Load Mail IDs and Mail content 
            document.getElementById("MymodalRegretMail").style.display = "block";
           

            var signatureRegretMail = document.getElementById("<%=hiddenMailSignature.ClientID%>").value;
            var toAddressRegretMail = document.getElementById("<%=hiddenMailToAddress.ClientID%>").value;
            var OtherToAddrssRegretMail = document.getElementById("<%=hiddenOtherToAddress.ClientID%>").value;
            var subjectRegretMail = document.getElementById("<%=hiddenMailSubject.ClientID%>").value;
            var fromAddressRegretMail = document.getElementById("<%=hiddenMailFrom.ClientID%>").value;
            document.getElementById("<%=txtMailContent.ClientID%>").value = signatureRegretMail;
            document.getElementById("<%=txtRegretMailTo.ClientID%>").value = toAddressRegretMail;
            document.getElementById("<%=txtRegretMailSubject.ClientID%>").value = "Rejection Letter for Business Proposal";
            if (OtherToAddrssRegretMail != "") {
                document.getElementById("<%=txtRegretMailCc.ClientID%>").value = OtherToAddrssRegretMail;
                ShowOrHideCc();
            }
            else {
                document.getElementById("<%=txtRegretMailCc.ClientID%>").value = "";

            }
            document.getElementById("<%=txtRegretMailBcc.ClientID%>").value = "";
            document.getElementById("<%=txtRegretMailFrom.ClientID%>").value = fromAddressRegretMail;
            document.getElementById("<%=txtRegretMailContent.ClientID%>").value = document.getElementById("<%=hiddenRegretMailContent.ClientID%>").value;


        }
        //for Cc and Bcc of mail content
        function ShowOrHideCcRegretMail() {
            if (document.getElementById('divRegretMailCc').style.display != "") {

                document.getElementById('divRegretMailCc').style.display = "";
                document.getElementById("<%=txtCccontent.ClientID%>").focus();
            }
            else {

                document.getElementById('divRegretMailCc').style.display = "none";

            }
            return false;
        }
        function ShowOrHideBCcRegretMail() {

            if (document.getElementById('divRegretMailBcc').style.display != "") {

                document.getElementById('divRegretMailBcc').style.display = "";
                document.getElementById("<%=txtRegretMailBcc.ClientID%>").focus();
            }
            else {

                document.getElementById('divRegretMailBcc').style.display = "none";

            }

            return false;

        }
        function CloseBCcMailRegretMail() {
            if (document.getElementById("<%=txtRegretMailBcc.ClientID%>").value == "") {

                document.getElementById('divRegretMailBcc').style.display = "none";
                // document.getElementById('divBCcHelper').style.display = "none";
            }
            else {
                if (confirm("Are you sure to remove the Bcc contacts? ")) {
                    document.getElementById("<%=txtRegretMailBcc.ClientID%>").value = "";
                    document.getElementById('divRegretMailBcc').style.display = "none";
                    // document.getElementById('divBCcHelper').style.display = "none";
                }
                else {
                    return false;
                }

            }

        }
        function CloseCcMailRegretMail() {
            if (document.getElementById("<%=txtRegretMailCc.ClientID%>").value == "") {

                    document.getElementById('divRegretMailCc').style.display = "none";
                    // document.getElementById('divCcHelper').style.display = "none";

                }
                else {
                    if (confirm("Are you sure to remove the Cc contacts? ")) {
                        document.getElementById("<%=txtRegretMailCc.ClientID%>").value = "";
                    document.getElementById('divRegretMailCc').style.display = "none";
                    //document.getElementById('divCcHelper').style.display = "none";
                }
                else {
                    return false;
                }

            }

        }
        function CloseModalMailRegretMail() {

            var RegretMailContent = document.getElementById("<%=txtRegretMailContent.ClientID%>").value;
            var RegretMailTo = document.getElementById("<%=txtRegretMailTo.ClientID%>").value;
            var RegretMailSubject = document.getElementById("<%=txtRegretMailSubject.ClientID%>").value;
            var RegretMailCc = document.getElementById("<%=txtRegretMailCc.ClientID%>").value;
            var RegretMailBcc = document.getElementById("<%=txtRegretMailBcc.ClientID%>").value;

            if (RegretMailContent = "" && RegretMailTo == "" && RegretMailSubject == "" && RegretMailCc == "" && RegretMailBcc == "") {


                document.getElementById("MymodalRegretMail").style.display = "none";
               
                return false;

            }
            else {

                if (confirm('Do You Want To Close This?') == true) {

                    document.getElementById("MymodalRegretMail").style.display = "none";
                  
                    return false;
                }
                else {
                    return false;
                }


            }
        }
        //QCLD4 this function evm0012
        function CheckRegretMail() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }

            // replacing < and > tags
            var ContentWithoutReplace = document.getElementById("<%=txtRegretMailContent.ClientID%>").value;
            var replaceText1 = ContentWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtRegretMailContent.ClientID%>").value = replaceText2;
            var CcContentWithoutReplace = document.getElementById("<%=txtRegretMailCc.ClientID%>").value.trim();
            var replaceText3 = CcContentWithoutReplace.replace(/</g, "");
            var replaceText4 = replaceText3.replace(/>/g, "");
            document.getElementById("<%=txtRegretMailCc.ClientID%>").value = replaceText4;
            var BccContentWithoutReplace = document.getElementById("<%=txtRegretMailBcc.ClientID%>").value;
            var replaceText5 = BccContentWithoutReplace.replace(/</g, "");
            var replaceText6 = replaceText5.replace(/>/g, "");
            document.getElementById("<%=txtRegretMailBcc.ClientID%>").value = replaceText6;
            var ToContentWithoutReplace = document.getElementById("<%=txtRegretMailTo.ClientID%>").value;
            var replaceText7 = ToContentWithoutReplace.replace(/</g, "");
            var replaceText8 = replaceText7.replace(/>/g, "");
            document.getElementById("<%=txtRegretMailTo.ClientID%>").value = replaceText8;


            document.getElementById('divErrorRsnRegretMail').style.visibility = "hidden";
            document.getElementById("<%=txtRegretMailTo.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtRegretMailCc.ClientID%>").style.borderColor = ""
            document.getElementById("<%=txtRegretMailBcc.ClientID%>").style.borderColor = ""
            document.getElementById("<%=txtRegretMailContent.ClientID%>").style.borderColor = "";

            var MailContent = document.getElementById("<%=txtRegretMailContent.ClientID%>").value;

            //005 start
            var ToMail = document.getElementById("<%=txtRegretMailTo.ClientID%>").value.trim();
            var CcEmail = document.getElementById("<%=txtRegretMailCc.ClientID%>").value.trim();
            var BCcEmail = document.getElementById("<%=txtRegretMailBcc.ClientID%>").value.trim();
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;


            var ToMailSplit = [];
            ToMailSplit = ToMail.split(',');
            if (ToMailSplit != "") {
                for (ArrCount = 0; ArrCount < ToMailSplit.length; ArrCount++) {


                    if (!filter.test(ToMailSplit[ArrCount])) {
                        document.getElementById("<%=lblErrorRsnRegretMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById('divErrorRsnRegretMail').style.visibility = "visible";

                        document.getElementById("<%=txtRegretMailTo.ClientID%>").focus();
                        document.getElementById("<%=txtRegretMailTo.ClientID%>").style.borderColor = "red";
                        ret = false;
                    }


                }
            }
            else {
                document.getElementById("<%=lblErrorRsnRegretMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById('divErrorRsnRegretMail').style.visibility = "visible";

                document.getElementById("<%=txtRegretMailTo.ClientID%>").focus();
                document.getElementById("<%=txtRegretMailTo.ClientID%>").style.borderColor = "red";
                ret = false;
            }

            var CcEmailSplit = [];
            CcEmailSplit = CcEmail.split(',');

            if (CcEmailSplit != "") {

                for (ArrCount = 0; ArrCount < CcEmailSplit.length; ArrCount++) {

                    if (!filter.test(CcEmailSplit[ArrCount])) {
                        document.getElementById("<%=lblErrorRsnRegretMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById('divErrorRsnRegretMail').style.visibility = "visible";

                        document.getElementById("<%=txtRegretMailCc.ClientID%>").focus();
                        document.getElementById("<%=txtRegretMailCc.ClientID%>").style.borderColor = "red";
                        ret = false;

                    }
                }
            }
            else {
                if (document.getElementById('divRegretMailCc').style.display != "none") {
                    document.getElementById("<%=lblErrorRsnRegretMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById('divErrorRsnRegretMail').style.visibility = "visible";

                    document.getElementById("<%=txtRegretMailCc.ClientID%>").focus();
                    document.getElementById("<%=txtRegretMailCc.ClientID%>").style.borderColor = "red";
                    ret = false;
                }
            }

            var BCcEmailSplit = [];
            BCcEmailSplit = BCcEmail.split(',');
            if (BCcEmailSplit != "") {
                for (ArrCount = 0; ArrCount < BCcEmailSplit.length; ArrCount++) {

                    if (!filter.test(BCcEmailSplit[ArrCount])) {
                        document.getElementById("<%=lblErrorRsnRegretMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById('divErrorRsnRegretMail').style.visibility = "visible";

                        document.getElementById("<%=txtRegretMailBcc.ClientID%>").style.borderColor = "red";
                        document.getElementById("<%=txtRegretMailBcc.ClientID%>").focus();
                        ret = false;
                    }

                }
            }
            else {
                if (document.getElementById('divRegretMailBcc').style.display != "none") {
                    document.getElementById("<%=lblErrorRsnRegretMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById('divErrorRsnRegretMail').style.visibility = "visible";

                    document.getElementById("<%=txtRegretMailBcc.ClientID%>").style.borderColor = "red";
                    document.getElementById("<%=txtRegretMailBcc.ClientID%>").focus();
                    ret = false;
                }
            }




            if (MailContent == "") {
                document.getElementById('divErrorRsnRegretMail').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnRegretMail.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                document.getElementById("<%=txtRegretMailContent.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtRegretMailContent.ClientID%>").focus();
                ret = false;

            }

            if (ret == true) {
                if (document.getElementById("<%=txtRegretMailSubject.ClientID%>").value == "") {
                     if (confirm("Send this message without a subject ?")) {
                         ret = true;
                     }
                     else {
                         ret = false;
                     }
                 }
             }




             if (ret == true) {
                 document.getElementById("MymodalRegretMail").style.display = "none";
           
                 ShowLoading();
             }
             if (ret == false) {
                 CheckSubmitZero();

             }

             return ret;
        }
    function ChangeStsOpportunity(Mode) {
        var orgID = '<%= Session["ORGID"] %>';
        var corptID = '<%= Session["CORPOFFICEID"] %>';
        var userid = '<%= Session["USERID"] %>';
        var objData = {};
        objData.OrgId = orgID;
        objData.CorpId = corptID;
        objData.Mode = Mode;
        objData.userid = userid;
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
                        projectRefNo();                           
                        return false;
                    }
                    else {
                        return false;
                    }
                });
            }
            else if (Mode == "2") {
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
                        OpenModalLossReason();
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
    </script>
     <style type="text/css">
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
     </style>
      <%-- <script src="../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>--%>
    <%--<script src="../../JavaScript/Autocomplete/jquery-ui.min.js"></script>--%>
    <script src="../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>
        var $dat = jQuery.noConflict();
        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlProjectManager').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingEmployee').selectToAutocomplete1Letter();
                $au('#cphMain_ddlExistingCustomer').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                });
            });
        })(jQuery);


        //FOR ADDITIONAL FILE UPLOADER
        function ClearDivDisplayImage(AddtnFileUpldr) {

            var hidnImageSize = document.getElementById("<%=hiddenAdditnFileSize.ClientID%>").value;
            var fuData = document.getElementById(AddtnFileUpldr);
            var size = fuData.files[0].size;
            var convertToKb = hidnImageSize / 1000;
            if (size > hidnImageSize) {
                document.getElementById(AddtnFileUpldr).value = "";
                alert(" Sorry Maximum file size exceeds. Please Upload Image of size less than " + convertToKb + "KB !.");
                //return false;
            }
            else {


            }
        }

        function OpenPartial_Win() {
         
            $('#par_win_box').modal('show');

            var QtnId = document.getElementById("<%=hiddenQuotationID.ClientID%>").value;
            var TempTyp = document.getElementById("<%=hiddenQtnTmpltId.ClientID%>").value;
            var OrgId = document.getElementById("<%=hiddenOrganisationId.ClientID%>").value;
            var CorpId = document.getElementById("<%=hiddenCorporateId.ClientID%>").value;
            var TaxEnable = document.getElementById("<%=hiddenTaxEnabled.ClientID%>").value;
            var ProductGroupId = document.getElementById("<%=ddlProductGroup.ClientID%>").value;
        
            $Mo.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "gen_LeadIndividualList.aspx/PartWinProductsLoad",
                data: '{strOrgId: "' + OrgId + '",strCorpId: "' + CorpId + '",strQtnId: "' + QtnId + '",strTempTyp: "' + TempTyp + '",strTaxEnable: "' + TaxEnable + '",strPrdctGroup: "' + ProductGroupId + '"}',
                dataType: "json",
                success: function (data) {

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
     <asp:HiddenField ID="hiddenL_MODE" runat="server" />
    <asp:HiddenField ID="hiddenActiveUserId" runat="server" />
    <asp:HiddenField ID="hiddenAllocateEmpId" runat="server" />
    <asp:HiddenField ID="hiddenLossReasonId" runat="server" />
    <asp:HiddenField ID="hiddenTaskId" runat="server" />
    <asp:HiddenField ID="hiddenTaskSubjctId" runat="server" />
    <asp:HiddenField ID="hiddenFollowUpSrcId" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="hiddenLeadFilePath" runat="server" />

    <asp:HiddenField ID="HiddenFieldAttachEditMode" runat="server" />


    <asp:HiddenField ID="HiddenField2_FileUpload" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenLeadId" runat="server" />
    <asp:HiddenField ID="hiddenLeadMailId" runat="server" />
    <asp:HiddenField ID="hiddenCorporateId" runat="server" />
    <asp:HiddenField ID="hiddenOrganisationId" runat="server" />
    <asp:HiddenField ID="hiddenMailFilePath" runat="server" />
    <asp:HiddenField ID="hiddenQtnAtchmntSlnmbr" runat="server" />
    <asp:HiddenField ID="hiddenQuotationID" runat="server" />
    <asp:HiddenField ID="hiddenCanclFileDtlId" runat="server" />
     <asp:HiddenField ID="hiddenCanclFileDtlName" runat="server" />
     <asp:HiddenField ID="hiddenOpenAdditionalAttch" runat="server" />
    <asp:HiddenField ID="hiddenOpenSupplierAttch" runat="server" />
     <asp:HiddenField ID="hiddenOpenTenderAttch" runat="server" />
    <asp:HiddenField ID="hiddenMailSignature" runat="server" />
    <asp:HiddenField ID="hiddenMailToAddress" runat="server" />
    <asp:HiddenField ID="hiddenOtherToAddress" runat="server" />
    <asp:HiddenField ID="hiddenMailSubject" runat="server" />
    <asp:HiddenField ID="hiddenMailFrom" runat="server" />
     <asp:HiddenField ID="hiddenDfltQuotationFormatId" runat="server" />
     <asp:HiddenField ID="hiddenRfqId" runat="server" />
     <asp:HiddenField ID="hiddenFilePath" runat="server" />
    
     <asp:HiddenField ID="hiddenDivisionCode" runat="server" />
     <asp:HiddenField ID="hiddenUserCode" runat="server" />
     <asp:HiddenField ID="hiddenCorporateDivId" runat="server" />
     <asp:HiddenField ID="hiddenQtnRevisionVersn" runat="server" />
     <asp:HiddenField ID="hiddenMonthMM" runat="server" />
     <asp:HiddenField ID="hiddenYearYYYY" runat="server" />
     <asp:HiddenField ID="hiddenQtnRefSerialId" runat="server" />
     <asp:HiddenField ID="hiddenRefNo" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
     <asp:HiddenField ID="hiddenTaxEnabled" runat="server" />
          
    <asp:HiddenField ID="hiddenFloatingValueMoney" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueUnit" runat="server" />
    <asp:HiddenField ID="hiddenFloatingValueCommonPercentage" runat="server" /> 
     <asp:HiddenField ID="hiddenCurrencyModeId" runat="server" />
     <asp:HiddenField ID="hiddenCurrencySymbol" runat="server" />
     <asp:HiddenField ID="hiddenCurrencyCode" runat="server" />
     <asp:HiddenField ID="hiddenDfltCurrencyDisplay" runat="server" />
  <asp:HiddenField ID="hiddenResendQtnMailID" runat="server" />
  <asp:HiddenField ID="hiddenResendQtnMailType" runat="server" />
  <asp:HiddenField ID="hiddenQtnTmpltId" runat="server" />
  <asp:HiddenField ID="hiddenFloatingValueTaxPercentage" runat="server" />

  <asp:HiddenField ID="hiddenProjectStatus" runat="server" />
  <asp:HiddenField ID="hiddenProjectManager" runat="server" />
  <asp:HiddenField ID="hiddenInternalRef" runat="server" />
    
        <asp:HiddenField ID="hiddenRegretMailForLeadID" runat="server" />
      <asp:HiddenField ID="hiddenRegretMailContent" runat="server" />
        <asp:HiddenField ID="HiddenLeadIdres" runat="server" />
     <asp:HiddenField ID="hiddenAdditnFileSize" runat="server" />
     <asp:HiddenField ID="hiddenPartialWinIds" runat="server" />
    
     <asp:HiddenField ID="HiddenFieldQuotIcon" runat="server" />
     <asp:HiddenField ID="HiddenFieldtxtPartnWinAmount" runat="server" />
      <asp:Button ID="btnRejectMail" runat="server" OnClick="btnRejectMail_Click" style="visibility:hidden"/>
    
    <asp:Button runat="server" ID="btnResendQtnMail" OnClick="btnReSendMailQtn_Click" style="visibility:hidden" />
     <asp:Button runat="server" ID="btnPartWin" OnClick="btnPartialWin_Click" style="visibility:hidden" />
    <asp:Button runat="server" ID="btnReSendMailQtn_BackUp" OnClick="btnReSendMailQtn_BackUp_Click" style="visibility:hidden" />
  <asp:HiddenField ID="hiddenQtnBackupID" runat="server" />
    <asp:HiddenField ID="HiddenFieldTaskUpd" runat="server" />

     <ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_Sales_Executive.aspx"">Sales Force Automation</a></li>
    <li><a href="gen_LeadList.aspx">Opportunity</a></li>
    <li class="active">Opportunity Information</li>
  </ol>
     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>
  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr"> 
      <div class="content_box1 cont_contr">
     
 <h2>OPPORTUNITY Information

    <a class="btn act_btn bn4 bt_e bt_fx_crqt" id="popoverOpener" data-height="600" data-width="400" title="Customer Requirements" onclick="return OpenDescription();" ><i class="fa fa-address-card-o"></i></a></h2>

        <div id="popoverWrapper">
          <div class="popover" role="tooltip">
            <div class="arrow"></div>
            <h3 class="popover-title">Customer Requirements</h3>
            <div class="popover-content">
             <CKEditor:CKEditorControl ID="CKEditorDescription" runat="server" BasePath="~/ckeditor" RemovePlugins="toolbar" Enabled="false" cols="30" rows="7"></CKEditor:CKEditorControl>
               <%-- <asp:TextBox ID="CKEditorDescription" runat="server" cols="64" rows="18" placeholder="Description" Style="resize: none;width:100%;outline:none!important;border:none;background-color:#fff;" TextMode="MultiLine" onkeypress="return isTag('cphMain_CKEditorDescription',event);" onkeydown="textCounter(cphMain_CKEditorDescription,295);" onkeyup="textCounter(cphMain_CKEditorDescription,295);" onblur="ReplaceTag('cphMain_CKEditorDescription',event);"></asp:TextBox>--%>

               

              <br /><div class="clearfix"></div>
              <div class="devider"></div>
              <button class="btn btn-danger btn-dz flt_r" style="margin-left:4px;" onclick="return CloseDescriptn();">Close</button>
            </div>
          </div>
        </div>

          <script>
              function OpenDescription() {
                  $("#popoverWrapper").fadeIn();
                  return false;
              }

              function CloseDescriptn() {
                  $("#popoverWrapper").fadeOut();
                  return false;
              }
          </script>

        <div class="clearfix"></div>

          <div class="top_br_container hc_at">
            <div class="top_br_1 pa_h1 pa_lft00">
              <div class="col-md-3 tx_100 hcm_1_2 ref_box_head pa_lft0">
                <ul>
                  <li><span class="fg6_42 flt_l li_100">Customer Name: </span> <span class="fg6_58 li_100_1"><asp:Label ID="lblCustName" runat="server" ></asp:Label></span></li>
                  <li><span class="fg6_42 flt_l li_100">Status:</span> <div id="divStatus" runat="server">  </div></li>
                </ul>
              </div>
              <div class="col-md-3 tx_100 hcm_1_2 ref_box_head">
                <ul>
                  <li><span class="fg6_36 flt_l li_100">Title: </span> <span class="fg6_64 li_100_1">  <asp:Label ID="lblTitle" runat="server" ></asp:Label></span></li>
                  <li><span class="fg6_36 flt_l li_100">Last Updation: </span> <span class="fg6_64 li_100_1"  id="spanLastUpdDate" runat="server"></span></li>
                </ul>
              </div>

              <div class="col-md-2 tx_100 hcm_1_2 ref_box_head">
                <ul>
                  <li><span class="fg6_30 flt_l li_100">Date: </span> <span class="fg6_70 li_100_1"> <asp:Label ID="lblDate" runat="server" ></asp:Label></span></li>
                  <li><span class="fg6_30 flt_l li_100">Source: </span> <span class="fg6_70 li_100_1"><asp:Label ID="lblLeadSource" runat="server" ></asp:Label></span> </li>
                </ul>
              </div>

              <div class="col-md-4 tx_100 hcm_1_2 ref_box_head">
                <ul>
                  <li><span class="fg6_25 flt_l li_100">Division: </span> <span class="fg6_70 li_100_1"><asp:Label ID="lblDivision" runat="server" ></asp:Label></span> </li>
                  <li><span class="fg6_25 flt_l li_100">Owner Name: </span>  <div id="divOwnerDetail" runat="server" ></div></li>
                </ul>
              </div>
            </div>
          </div>

        

       
      <div class="clearfix"></div>
      <div class="devider"></div> 



           <div class="col-md-6 mar_at flt_lfg6 pa_lft0">  
      <p class="plc1 pl_rg">Attachments</p>
               <div class="table_box tb_scr">
               <div id="divAttachment"  runat="server">
                </div>
                   </div>

</div>

          </div>




          <div class="col-md-6 mar_at flt_r">
       <p class="plc1 pl_rg">Notes
            <span id="divlnkFolpEdit" runat="server">
                </span>
          
          </p>

             

      <div class="table_box tb_scr">
          <div class="r_480 mar_bt_480">

           <div id="divFolup" runat="server">
                </div>

               
           </div>

          </div>
</div>


        <div class="clearfix"></div>
      <div class="devider"></div>




        
      <div class="col-md-12 mar_at flt_r pa_lft0">
      <p class="plc1 pl_rg">Follow-Up / Task
          <span id="divlnkTaskEdit" runat="server">
                </span></p>
      <div class="table_box tb_scr">
        <div class="r_480 mar_bt_480">
            <div id="divTask" runat="server">
                </div>

                

            </div></div></div>


        <div class="clearfix"></div>
        <div class="devider"></div>



        <div class="col-md-12 mar_at flt_l pa_lft0">
        <p class="plc1 pl_rg">Re-Send Mail</p>
      <div class="table_box tb_scr">
        <div class="r_480 mar_bt_480">
            <div id="divReSendMail"  runat="server">
                </div>
            </div></div></div>

        
        <div class="clearfix"></div>
            <div class="devider"></div>

        <div class="col-md-12 mar_at flt_l pa_lft0">
        <p class="plc1 pl_rg">MAIL</p>
      <div class="table_box tb_scr">
        <div class="r_480 mar_bt_480">
             <div id="divMail"  runat="server">
                </div>

                <div>
                    <div id="divlnkMailEdit" runat="server" hidden="hidden">
                    </div>
                    </div>
            </div>
          </div>
            </div>

        <div class="clearfix"></div>
      <div class="free_sp"></div>
      


</div><!--content_container_closed------>


</div>


    <a href="gen_LeadList.aspx" type="button" class="list_b" title="Back to List">
<i class="fa fa-arrow-circle-left"></i>
</a>


      <div id="divImgEditLead" runat="server"></div>
                

<a href="#" type="button"  id="A1" runat="server" class="dropdown dd_spl1 dislike chg_oppz" title="Change Opportunity Status">
<i class="fa fa-th-list"></i>
</a>
<div class="stat_sbox">
  <ul>
    <a href="#" onclick="return ChangeStsOpportunity('1');" title="Win" id="imgbtnWin" runat="server">
      <li class="">
        <div class="bo_not1 mrl_bon flt_l" title="Win">
          <i class="fa fa-square"></i>
        </div> Win
      </li>
    </a>
    <a href="#" onclick="return ChangeStsOpportunity('2');" title="partially win" id="imgbtnPartialWin" runat="server">
       <li>
        <div class="bo_not2 mrl_bon flt_l" title="partially win">
          <i class="fa fa-square"></i>
        </div> partially win
  </li>
    </a>
    <a href="#" onclick="return ChangeStsOpportunity('3');" title="Loss" id="imgbtnLoss" runat="server">
      <li>
        <div class="bo_not3 mrl_bon flt_l" title="Loss">
          <i class="fa fa-square"></i>
        </div> Loss
      </li>
    </a>
</ul>
</div>

<a href="#" type="button" id="A2" runat="server" class="dropdown dd_spl1 opp_btz " title="Quotation">
<i class="fa fa-file-text-o"></i>
</a>
<div class="stat_sbox1" >
  <ul id="divlnkQtnEdit" runat="server">
     
   
</ul>
</div>

<a href="#" type="button" id="btnAllocate" runat="server" class="allo_btn" onclick="return OpenModalAllocate('cphMain_btnAllocate', event);" data-toggle="modal" data-target="#myModalAllocate" title="Allocation">
<i class="fa fa-calendar-check-o"></i>
</a>

<a href="#" type="button" class="add_op_atch_btn" data-toggle="modal" data-target="#add_files" title="Add Files" id="btnadd_files" runat="server">
<i class="fa fa-paperclip"></i>
</a>
     
<a href="#" id="scroll" style="display: none;"><span class="fa fa-angle-up"></span></a>

                     
   <!-- Trigger/Open The Modal -->
<div class="modal fade" id="send_mail" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog mod1_70 flt_r" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H13">Send Mail</h5>
        <button type="button" class="close" data-dismiss="modal" onclick="return CloseModalMail();" aria-label="Close">
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


      <div id="div1" runat="server" style="display: none">
    </div>
     <div id="div4" runat="server" style="display: none">
    </div>
    <div id="div10" runat="server" style="display: none">
    </div>
     <div id="divOptionsReopenReason" runat="server" style="display: none">
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
           <asp:Button ID="btnSubmit"  runat="server" value="Submit" OnClientClick="return RefIdTake();" OnClick="imgbtnWin_Click" class="btn sub1" text="Submit"/>   
            <asp:Button ID="btnSubmitAwrd"  runat="server" value="Submit" OnClientClick="return InternalRefIdTake();" OnClick="imgbtnWin_Click" class="btn sub1" text="Submit"/>   

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
           <div class="myAlert-bottom alert alert-danger" id="divErrorRsnLossReason" style="left:5px;right:5px;height:auto;">
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
       <asp:Button ID="btnLossReasonSave" runat="server" class="btn sub1" Text="Submit" OnClientClick="return CheckLossReason();" OnClick="btnLossReasonSave_Click" />
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

        
<!-- The Modal Follow Up -->            
<div class="modal fade" id="myModalFollowUp" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top: 8%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Add Note</h5>
        <button type="button" class="close" onclick="return CloseModalFollowUp();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
           <div class="myAlert-bottom alert alert-danger" id="divErrorRsnFollowUp" style="left:5px;right:5px;height:auto">
           </div>
        <div class="form-group fg6 mar_at flt_l">
          <label for="email" class="fg2_la1">Through:<span class="spn1">*</span></label>                       
            <span id="SpanddlFollowUp"></span>   
             
        </div>
        <div class="form-group fg6 mar_at flt_l">
          <div class="tdte">
            <label for="pwd" class="fg2_la1">Date:<span class="spn1">*</span> </label>
            <div id="datepicker3" class="input-group date" data-date-format="dd-mm-yyyy">
              <%--<input class="form-control inp_bdr inp_mst"   /> --%>
                  <asp:TextBox ID="txtFollowUpDate" class="form-control inp_bdr inp_mst"  type="text"  runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>
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
         <%-- <textarea rows="3" cols="48" class="form-control flt_l  inp_mst not_tx_ar" placeholder="Description"></textarea>--%>
            <asp:TextBox ID="txtFollowUpDescptn" rows="3" cols="48" class="form-control flt_l  inp_mst not_tx_ar" TextMode="MultiLine"  placeholder="Description" runat="server" onkeypress="return isTag('cphMain_txtFollowUpDescptn', event);" onkeydown="textCounter(cphMain_txtFollowUpDescptn,900);" onkeyup="textCounter(cphMain_txtFollowUpDescptn,900);" ></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <div class="free_sp"></div>
      </div>
      <div class="modal-footer">
        <%--<button type="submit" >Save</button>--%>
          <asp:Button ID="btnFollowUpSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckFollowUp();" OnClick="btnFollowUpSave_Click" />
       <button type="submit" class="btn sub4" onclick="return CloseModalFollowUp();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>


<!-- The Modal Task -->           
<div class="modal fade" id="myModalTask" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top:7%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H1">Add Follow-Up / Task</h5>
        <button type="button" class="close" onclick="return CloseModalTask();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mod_bd1_800">
          <div class="myAlert-bottom alert alert-danger" id="divErrorRsnTask" style="left:5px;right:5px;height:auto">
             </div>
        <div class="form-group fg4 sa_2">
         <label for="email" class="fg2_la1">Subject:<span class="spn1"></span></label>                   
         <span id="SpanddlTask"></span>                    
        </div>
        <div class="form-group fg6_510 sa_2 mar_at flt_l">
          <label for="pwd" class="fg2_la1">Due Week:<span class="spn1"></span></label>       
             <asp:DropDownList ID="ddlPlusWeek" class="form-control fg2_inp1 inp_wd_100" runat="server" onchange="return PlusWeek();"></asp:DropDownList>
        </div>
        <div class="clearfix"></div>
        <div class="form-group fg12">
          <div class="form-group fg4 sa_2">
            <div class="tdte">
              <label for="pwd" class="fg2_la1">Due Date:<span class="spn1"></span> </label>
              <div id="datetimepickerTask" >                         
                  <div id="datepicker4" class="input-group date" data-date-format="dd-mm-yyyy">             
                  <asp:TextBox ID="txtTaskDate" class="form-control inp_bdr inp_mst"  type="text"  runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>
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
          </div>  

            <div id="TimepickerTask">

          <div class="fg2 sa_2">
            <label for="pwd" class="fg2_la1">Due Time:<span class="spn1"></span></label>
            
             
                 <asp:DropDownList  ID="ddlTaskHr"  class="form-control fg2_inp1" runat="server"></asp:DropDownList>
             
          </div>
          <div class="fg2 sa_2">
            <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
            <asp:DropDownList  ID="ddlTaskMin"   class="form-control fg2_inp1" runat="server"></asp:DropDownList>
            </div>
            <div class="time_bx sa_2">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlTask_AM_PM"  class="form-control fg2_inp1"  runat="server"></asp:DropDownList> 
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


             

          <div class="fg2 sa_2">
            <label for="pwd" class="fg2_la1">Closed Time:<span class="spn1"></span></label>
            
             
                 <asp:DropDownList  ID="ddlClsTaskHr"   class="form-control fg2_inp1" runat="server"></asp:DropDownList>
             
          </div>
          <div class="fg2 sa_2">
            <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
            <asp:DropDownList  ID="ddlClsTaskMin"   class="form-control fg2_inp1" runat="server"></asp:DropDownList>
            </div>
            <div class="time_bx sa_2">
              <label for="pwd" class="fg2_la1">&nbsp;<span class="spn1"></span></label>
              <asp:DropDownList ID="ddlClsTaskAM_PM"   class="form-control fg2_inp1"  runat="server"></asp:DropDownList> 
            </div>

            </div>


        </div> 
        <div class="form-group fg12 sa_2">
          <label for="email" class="fg2_la1">Description:<span class="spn1"></span></label>
        <%--  <textarea rows="3" cols="48" class="form-control flt_l inp_wd_100" placeholder="Description"></textarea>--%>

             <asp:TextBox ID="txtTaskDescptn"   rows="3" cols="48" class="form-control flt_l inp_wd_100" placeholder="Description" TextMode="MultiLine" runat="server" onkeypress="return isTag('cphMain_txtTaskDescptn', event);" onkeydown="textCounter(cphMain_txtTaskDescptn,450);" onkeyup="textCounter(cphMain_txtTaskDescptn,450);" ></asp:TextBox>

        </div>
        <div class="form-group fg2 fg2_mr sa_fg1">
          <label for="email" class="fg2_la1 pad_l">Status:<span class="spn1"></span></label>
          <div class="check1">
            <div class="">
              <label class="switch">
                <input type="checkbox" id="cbxTaskStatus" runat="server" checked="checked"/>
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        
          <asp:Button ID="btnTaskSave"  runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckTask();" OnClick="btnTaskSave_Click" />

           <asp:Button ID="btnTaskUpd"  runat="server" class="btn sub1"  Text="Update" OnClientClick="return CheckTask();" OnClick="btnTaskUpd_Click" />

       <button type="submit" class="btn sub4" onclick="return CloseModalTask();" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>

<!-- The Modal CancelTask -->                  
<div class="modal fade" id="myModalCancelTask" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog flt_r" role="document" style="margin-top:7%;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H2">Close Follow-Up / Task</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body mod_bd1_800">
        <div class="myAlert-bottom alert alert-danger" id="divErrorRsnCancelTask" style="left:5px;right:5px;height:auto">
             </div>
        <div class="form-group fg6 sa_2">
          <label for="email" class="fg2_la1">Added Date:<span class="spn1"></span></label>           
               <asp:TextBox ID="txtACancelTaskDate" class="form-control fg2_inp1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 48%; font-family: calibri; font-size: 15px; margin-right: 18%" onkeydown="return isNumberDate(event);"></asp:TextBox>
        </div>
        

        <div class="form-group fg6">
          <label for="pwd" class="fg2_la1">Added Time:<span class="spn1">*</span></label>

            <div id="TimepickerACancelTask"  >
          <div class="fg4 sa_2">
           
          <span class="form-control fg2_inp1" style="background-color:#eee" ><asp:Label ID="lblACancelTaskHr" runat="server" Text="Label" Style="font-size: 13px; color: rgb(51, 125, 78);"></asp:Label></span>
                                <span style="color: rgb(144, 156, 123); display:none; font-size: 13px; font-family: Calibri; padding-right: 3%; padding-left: 1%;">Hr</span>

          
         </div>

         <div class="fg4 sa_2">
          
            
              <span class="form-control fg2_inp1" style="background-color:#eee" > <asp:Label ID="lblACancelTaskMin" runat="server" Text="Label" Style="font-size: 13px; color: rgb(51, 125, 78);"></asp:Label></span>
                                <span style="color: rgb(144, 156, 123); display:none; font-size: 13px; font-family: Calibri; padding-right: 3%; padding-left: 1%;">Min</span>

         </div>
         <div class="fg4 sa_2">
            
  <span class="form-control fg2_inp1" style="background-color:#eee" ><asp:Label ID="lblACancelTask_AM_PM" runat="server" Text="Label" Style="font-size: 13px; color: rgb(51, 125, 78);"></asp:Label></span>

         </div>
        </div>
            </div>

        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="form-group fg6 sa_2">
          <div class="tdte">
            <label for="pwd" class="fg2_la1">Completed Date:<span class="spn1">*</span> </label>
            <div id="datepicker6" class="input-group date" data-date-format="mm-dd-yyyy">
             
                 <asp:TextBox ID="txtCCancelTaskDate" class="form-control inp_bdr inp_mst cls_in1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server"  onkeydown="return isNumberDate(event);"></asp:TextBox>
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


              <div id="TimepickerCCancelTask" >
                            
          <div class="fg4 sa_2">
             <asp:DropDownList ID="ddlCCancelTaskHr" class="form-control fg2_inp1  inp_mst"  runat="server"></asp:DropDownList>
         </div>

         <div class="fg4 sa_2">
          <asp:DropDownList ID="ddlCCancelTaskMin" class="form-control fg2_inp1  inp_mst"  runat="server"></asp:DropDownList>
         </div>
         <div class="fg4 sa_2">
             <asp:DropDownList ID="ddlCCancel_AM_PM" class="form-control fg2_inp1  inp_mst"  runat="server"></asp:DropDownList>
         </div>
                  </div>
        </div> 
      </div>
      <div class="modal-footer">
         <asp:Button ID="btnCancelTaskSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckCancelTask();" OnClick="btnCancelTaskSave_Click" />
       <button type="submit" class="btn sub4" data-dismiss="modal" aria-label="Close">Cancel</button>
      </div>
    </div>
  </div>
</div>



<!-- The Modal Allocate -->
    <div class="modal fade" id="myModalAllocate" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog ad_sd_mod1 flt_r" role="document" style="width: 40%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="H3">Allocate To</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                  <div class="myAlert-bottom alert alert-danger" id="divErrorRsnAllocate" style="left:5px;right:5px;height:auto">
                 </div>              
                <div class="modal-body padng_btm">
                    <div class="form-group fg6 sa_2">
                        <label for="email" class="fg2_la1">Employee:<span class="spn1"></span></label>
                        <span id="SpanddlAllocate"></span>
                    </div>
                </div>
                <<div class="modal-footer">
                    <asp:Button ID="btnAllocateSave" runat="server" class="btn sub1" Text="Save" OnClientClick="return CheckAllocate();" OnClick="btnAllocateSave_Click" />
                    <button type="submit" class="btn sub4" data-dismiss="modal" aria-label="Close">Cancel</button>
                </div>
            </div>

            <div class="modal-footerAllocate">
            </div>
        </div>
    </div>


 <!-- The Modal Loading MAIL -->
 <div id="myModalLoadingMail" class="modalLoadingMail">
  <!-- Modal content -->
    <div>
   <img src="../../Images/Other Images/LoadingMail.gif" style="width: 12%;" />
  </div>
 </div>
           
  <!-- The Modal MymodalRegretMail -->
 <div id="MymodalRegretMail" class="modalRegretMail">              
                <!-- Modal content -->
                <div class="modal-contentMail">
                    <div class="modal-headerMail">

                        <img class="closeMail" style="margin-top: 0.5%; cursor: pointer;" onclick="return CloseModalMailRegretMail();" src="../../Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px">
                        <h3 style="font-family: Calibri;">Send Mail</h3>
                    </div>
                    <div class="modal-bodyMail">
                        <div id="divErrorRsnRegretMail" class="ErrorRsnRegretMail" style="visibility: hidden; font-family: Calibri;margin-bottom: 2%;">
                            <asp:Label ID="lblErrorRsnRegretMail" runat="server"></asp:Label>
                        </div>
                         <div id="div5" style="height:auto";>
                             <div id="div6" style="float:left; width:60%" >
                                   <p style="color: #7b826e; font-family: Calibri; width: 44px;">From :</p>
                                 <asp:TextBox ID="txtRegretMailFrom" class="form1" Enabled="false" style="border-style: outset; width: 78%; margin-top:-26px;margin-left:29px;" disable="true" runat="server" autocomplete="off"></asp:TextBox>
                                     <%-- <div id="divFromAddress" style="display:block; width: 540px;overflow:auto; color: #7b826e; font-family: Calibri; margin-top:-18px;margin-left:61px;" runat="server"></div>--%>
                             </div>
                          
                            <div id="divRegretMailTo" style="float:left;width:60%;padding-top: 13px;margin-top: 3px;">
                               
                             <p style="color: #7b826e; font-family: Calibri;">To :</p>   
                            <asp:TextBox ID="txtRegretMailTo" class="form1" style="border-style: outset; width: 78%; margin-top:-26px;margin-left:29px;" onkeypress="return isTagDisableEnter('cphMain_txtToAddress', event);" runat="server" autocomplete="off"></asp:TextBox>
                           

                           </div>
                               
                                <div id="div7" style="float:right;width:38%;padding-top: 14px">
                              <div class="divccdescription" style="margin-right: 76%;">
                            <div id="Div8"  style="width:17px" class="buttonlink" onmouseover="CcDescriptionPosition('btnCC')" onclick="return ShowOrHideCcRegretMail()">Cc</div>
                           <p id="P1" class="CcDescription" style="position:absolute"></p>
                                  

                            </div>

                            <div class="divbccdescription" style="margin-right: 76%;">
                            <div id="Div9" style="width:20px;margin-top: -20px; margin-left: 22px;" class="buttonlink" onmouseover="BccDescriptionPosition('btnBCc')" onclick="return ShowOrHideBCcRegretMail()">Bcc</div>
                             <p id="P2" class="BccDescription" style="position:absolute"></p>
                                
                             </div> 

                                </div>
                            <div id="divRegretMailCc" style="display:none; float:left; width:60%; padding-top:2px">

                             <p style="color: #7b826e; font-family: Calibri; padding-top: 12px;">Cc :</p>   
                            <asp:TextBox ID="txtRegretMailCc" class="form1" style="border-style: outset; width: 78%;margin-top: -29px; padding-top: 1px;" onkeypress="return isTagDisableEnter('cphMain_txtCccontent', event);" onkeyup="loadCorrespondingCc('cphMain_txtCccontent',event);" runat="server" autocomplete="off"></asp:TextBox>
                                 <img id="Img3" class="CloseCc" style="float:left; margin-top:-11%; margin-left: 101%; height:15px;width:15px; cursor:pointer" onclick="return CloseCcMailRegretMail();" src="../../Images/Icons/close-icon.CcBcc.png"/>
                             <div id="div11" style="display:none">


                             </div>
                                
                            </div>
                            
                         <div id="divRegretMailBcc"  style="display:none;float:left; width:60%; padding-top:2px">
                             <p style="color: #7b826e; font-family: Calibri; padding-top: 12px;">Bcc :</p>   
                             
                              <asp:TextBox ID="txtRegretMailBcc" class="form1" style="border-style: outset; width: 78%;margin-top: -29px; padding-top: 1px;"  onkeypress="return isTagDisableEnter('cphMain_txtBCccontent', event);" onkeyup="loadCorrespondingBCc('cphMain_txtBCccontent',event);" runat="server" autocomplete="off"></asp:TextBox>
                             <img id="Img4" class="CloseBCc"  style="float:left; margin-top:-11%; margin-left: 101%; height:15px;width:15px; cursor:pointer" onclick="return CloseBCcMailRegretMail();" src="../../Images/Icons/close-icon.CcBcc.png"/>
                             <div id="div13" style="display:none">


                             </div>
                         </div>
                            </div>

                        <div id="divRegretMailSubject"style="float:left;width:60%;margin-top:2px">
                        <p style="color: #7b826e; padding-top: 3%; font-family: Calibri;">Subject :</p>
                        <asp:TextBox ID="txtRegretMailSubject" class="form1" maxlength="150" style="border-style:outset;width: 78%; padding-top: 5px; margin-top: -28px" onkeypress="return isTagDisableEnter('cphMain_txtBCccontent', event);" onkeydown="loadCorrespondingBCc('cphMain_txtBCccontent',event);" runat="server"></asp:TextBox>
                        </div>


                        <div id="div16" style="float:left;width:100%; padding-top:10px"> 
                        <div id="div17" ></div>
                        <asp:TextBox ID="txtRegretMailContent" TextMode="MultiLine" runat="server" onkeypress="return isTag('cphMain_txtMailContent', event);" Style="resize: none; width: 97%; height: 100px; font-family: Calibri; font-size: 14px;" placeholder="Content*"></asp:TextBox>
                        </div>
                        <div class="leads_form_left" style="width: 100%; padding-top: 2%; margin-left: 0%;">
                            &nbsp;&nbsp;
                           
                        </div>

                        <div class="subform" style="margin-left: 43.8%; padding-top: 0%;">
                            <%--<div class="save" onclick="return SaveAdditional();">Save</div>--%>
                            <asp:Button ID="btnSendRegretMail" runat="server" class="save" Text="Send" OnClientClick="return CheckRegretMail();" OnClick="btnSendRegretMail_Click" />
                            <asp:Button ID="btnCancelRegretMail" runat="server" class="save" Text="Cancel" OnClientClick="return CloseModalMailRegretMail();"  />
                              
                        </div>
                    </div>
                    <div class="modal-footerMail">
                    </div>
                </div>

            </div>


<!-- Modal_send-->
<div class="modal fade" id="add_files" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog wid_100_1_mod" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="H4">Add Files</h5>
        <button type="button" class="close" onclick="return CloseQtnAtchmntAdditional();" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body" id="divBodyFiles">
           <div class="myAlert-bottom alert alert-danger" id="divErrorRsnQtnAttchmntAdditional">
           </div>
           <div class="myAlert-top alert alert-success" id="divSuccesRsnQtnAttchmntAdditional">
          </div>
        <div class="col-md-4" id="divAddFiles" runat="server">
          <h5>Aditional Files
            <div class="icn_upl flt_r">
              <button class="btn act_btn bn2" onclick="return CheckForDeleteQtnAddtnlAttchmnt('A');" title="Attach Selected With Mail" >
                <i class="fa fa-paperclip"></i>
              </button>
             <asp:Button ID="btnDeleteQtnAdtnlFiles" style="display:none;" runat="server" class="save" Text="Delete Selected"  OnClick="btnDeleteQtnAdtnlFiles_Click" />
              <asp:Button ID="btnAttachFileWithMail" runat="server" style="display:none;" class="save" Text="Attach Selected With Mail"  OnClick="btnAttachFileWithMail_Click" />
              <button class="btn act_btn bn3" onclick="return CheckForDeleteQtnAddtnlAttchmnt('D');" title="Delete Selected">
                <i class="fa fa-trash"></i>
              </button>
            </div>
          </h5>
          <div class="r_1024">
            <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
              <thead class="thead1">
                <tr>
                  <th class="col-md-2">
                    <span class="button-checkbox lbr_chk flt_l">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxA();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>Â&nbsp;</button>
                      <input type="checkbox" class="hidden" id="cbxAllA">
                    </span>
                  </th>
                  <th class="col-md-8 tr_l">Attachments</th>
                  <th class="col-md-2">Actions</th>
                </tr>
              </thead>
              <tbody id="QtnAtchmntAddtnlFiles" runat="server">                                               
              </tbody>
            </table>
          </div>
        </div>
        <div class="col-md-4" id="divSupFiles" runat="server">
          <h5>Supplier Qoutes
            <div class="icn_upl flt_r">
              <button class="btn act_btn bn3" onclick="return CheckForDeleteQtnSupplierAttchmnt();" title="Delete Selected">
                <i class="fa fa-trash"></i>
              </button>
            <asp:Button ID="btnSupplierQuoteDelete" style="display:none;" runat="server" class="save" Text="Delete Selected" OnClick="btnSupplierQuoteDelete_Click"  />
            </div>
          </h5>
          <div class="r_1024">
            <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
              <thead class="thead1">
                <tr>
                  <th class="col-md-1">
                    <span class="button-checkbox lbr_chk flt_n mr_rgt_chk">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxS();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>Â&nbsp;</button>
                      <input type="checkbox" class="hidden" id="cbxAllS">
                    </span>
                  </th>
                  <th class="col-md-9 tr_l">Attachments</th>
                  <th class="col-md-2">Actions</th>
                </tr>
              </thead>
              <tbody id="QtnAtchmntSupplierFiles" runat="server">
                                             
              </tbody>
            </table>
          </div>
        </div>
        <div class="col-md-4" id="divTenFiles" runat="server">
          <h5>Tender Files
            <div class="icn_upl flt_r">
              <button class="btn act_btn bn3" onclick="return CheckForDeleteQtnTenderAttchmnt();" title="Delete Selected">
                <i class="fa fa-trash"></i>
              </button>
                  <asp:Button ID="btnQtnAtchmntTenderDelete" runat="server" style="display:none;" Text="Delete Selected" OnClick="btnQtnAtchmntTenderDelete_Click" />
            </div>
          </h5>
          <div class="r_1024">
            <table class="display table-bordered pro_tab1 tbl_800" cellspacing="0" width="100%">
              <thead class="thead1">
                <tr>
                  <th class="col-md-1">
                    <span class="button-checkbox lbr_chk flt_n mr_rgt_chk">
                      <button type="button" class="active btn-p" data-color="p" onclick="return ClickCbxT();" ng-model="all"><i class="state-icon fa fa-check-square-o"></i>Â&nbsp;</button>
                      <input type="checkbox" class="hidden" id="cbxAllT">
                    </span>
                  </th>
                  <th class="col-md-9 tr_l">Attachments</th>
                  <th class="col-md-2">Actions</th>
                </tr>
              </thead>
              <tbody id="QtnAtchmntTenderFiles" runat="server">
                                             
              </tbody>
            </table>
          </div>
        </div>
      </div>

      <div class="modal-footer">
        <asp:Button ID="btnUploadQtnAttchAddtnl" runat="server" class="btn sub1" Text="Upload" OnClick="btnUploadQtnAttchAddtnl_Click" OnClientClick="return CheckQtnAttchmntAdditional();" />
        <button type="submit" class="btn sub4" onclick="return CloseQtnAtchmntAdditional();" aria-label="Close">Cancel</button>
      </div>

    </div>
  </div>
</div>
<script>   
    var FilecounterA = 0;
    function AddFileUploadA() {
        var FrecRow = '<tr id="FilerowIdA_' + FilecounterA + '" class="trA">'; 
        FrecRow += '<td class="tr_l" colspan="2">';
        FrecRow += '<input type="file" id="fileA' + FilecounterA + '" name = "fileA' + FilecounterA +'" onchange="ChangeFileA(' + FilecounterA + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/  multiple="">';
        FrecRow += '<label for="fileA' + FilecounterA + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
        FrecRow += '<div id="filePathA' + FilecounterA + '" class="file_n"></div>';
        FrecRow += '</td>';
        FrecRow += '<td>'; 
        FrecRow += '<div class="btn_stl1">';
        FrecRow += '<button id="FileIndvlAddMoreRowA' + FilecounterA + '" class="btn act_btn bn2" onclick="return CheckaddMoreRowsIndividualFilesA(' + FilecounterA + ');" title="Add">';
        FrecRow += '<i class="fa fa-plus-circle"></i>';
        FrecRow += '</button>';
        FrecRow += '<button  class="btn act_btn bn3" onclick="return RemoveFileUploadA(' + FilecounterA + ');"" title="Delete">';
        FrecRow += '<i class="fa fa-trash"></i>';
        FrecRow += '</button>';
        FrecRow += '</div>';                                        
        FrecRow += '</td>';     
        FrecRow += ' <td id="FileInxA' + FilecounterA + '" style="display: none;" > </td>';
        FrecRow += '<td id="FileSaveA' + FilecounterA + '" style="display: none;"> </td>';
        FrecRow += '<td id="FileEvtA' + FilecounterA + '" style="display: none;">INS</td>';
        FrecRow += '<td id="FileDtlIdA' + FilecounterA + '" style="display: none;"></td>';
        FrecRow += '<td id="DbFileNameA' + FilecounterA + '" style="display: none;"></td>';
        FrecRow += '</tr>';
        jQuery('#cphMain_QtnAtchmntAddtnlFiles').append(FrecRow);
        document.getElementById('filePathA' + FilecounterA).innerHTML = 'No File Selected';
        FilecounterA++;
    } 
    //id="FileIndvlDelRowA' + FilecounterA + '" style="display:none;"
    function ClickCbxA() {
        if (document.getElementById("cbxAllA").checked == true) {
            $('#cphMain_QtnAtchmntAddtnlFiles input[type=checkbox]:checked').click();
        }
        else {
            $('#cphMain_QtnAtchmntAddtnlFiles input[type=checkbox]:not(:checked)').click();
        }
        return false;
    }
    function ClickCbxS() {
        if (document.getElementById("cbxAllS").checked == true) {
            $('#cphMain_QtnAtchmntSupplierFiles input[type=checkbox]:checked').click();
        }
        else {
            $('#cphMain_QtnAtchmntSupplierFiles input[type=checkbox]:not(:checked)').click();
        }
        return false;
    }
    function ClickCbxT() {
        if (document.getElementById("cbxAllT").checked == true) {
            $('#cphMain_QtnAtchmntTenderFiles input[type=checkbox]:checked').click();
        }
        else {
            $('#cphMain_QtnAtchmntTenderFiles input[type=checkbox]:not(:checked)').click();
        }
        return false;
    }
    function CloseQtnAtchmntAdditional() {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to close?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {             
                document.getElementById("<%=hiddenOpenTenderAttch.ClientID%>").value = "";
                document.getElementById("<%=hiddenOpenSupplierAttch.ClientID%>").value = ""; 
                document.getElementById("<%=hiddenOpenAdditionalAttch.ClientID%>").value = "";             
                $('#add_files').modal('hide');
                return false;
            }
            else {
                return false;
            }
        });      
        return false;
        }
    function RemoveFileUploadA(removeNum) {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected file?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {             
                jQuery('#FilerowIdA_' + removeNum).remove();
                var TableFileRowCount = $(".trA").length; 
                if (TableFileRowCount != 0) {
                    var idlast = $('#cphMain_QtnAtchmntAddtnlFiles tr:last').attr('id');
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("FileInxA" + res[1]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRowA" + res[1]).disabled = false;
                    }
                }
                else {
                    AddFileUploadA();
                }
                return false;
            }
            else {
                return false;
            }
        });
      return false;          
    }
    function ChangeFileA(x) {
        IncrmntConfrmCounter();
        if (document.getElementById('fileA' + x).value != "") {
            document.getElementById('filePathA' + x).innerHTML = document.getElementById('fileA' + x).value;
        }
        else {
            document.getElementById('filePathA' + x).innerHTML = 'No File Selected';
        }      
    }
    function CheckFileUploadedA(x) {
        if (document.getElementById('fileA' + x).value != "") {
            return true;
        }
        else {
            return false;
        }
    }
    function CheckaddMoreRowsIndividualFilesA(x) {
        // for add image in each row
        var check = document.getElementById("FileInxA" + x).innerHTML;
        if (check == " ") {
            var Fevt = document.getElementById("FileEvtA" + x).innerHTML;
            if (Fevt != 'UPD') {
                if (CheckFileUploadedA(x) == true) {
                    document.getElementById("FileInxA" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRowA" + x).disabled = true;
                    AddFileUploadA();
                    return false;
                }
            }
            else {
                document.getElementById("FileInxA" + x).innerHTML = x;
                document.getElementById("FileIndvlAddMoreRowA" + x).disabled = true;
                AddFileUploadA();
                return false;
            }
        }
        return false;
    }
    //Supplier
    var FilecounterS = 0;
    function AddFileUploadS() {
        var FrecRow = '<tr id="FilerowIdS_' + FilecounterS + '" class="trS">'; 
        FrecRow += '<td class="tr_l" colspan="2">';
        FrecRow += '<input type="file" id="fileS' + FilecounterS + '" name = "fileS' + FilecounterS +'" onchange="ChangeFileS(' + FilecounterS + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/  multiple="">';
        FrecRow += '<label for="fileS' + FilecounterS + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
        FrecRow += '<div id="filePathS' + FilecounterS + '" class="file_n"></div>';
        FrecRow += '</td>';
        FrecRow += '<td>'; 
        FrecRow += '<div class="btn_stl1">';
        FrecRow += '<button id="FileIndvlAddMoreRowS' + FilecounterS + '" class="btn act_btn bn2" onclick="return CheckaddMoreRowsIndividualFilesS(' + FilecounterS + ');" title="Add">';
        FrecRow += '<i class="fa fa-plus-circle"></i>';
        FrecRow += '</button>';
        FrecRow += '<button  class="btn act_btn bn3" onclick = "return RemoveFileUploadS(' + FilecounterS + ');"" title="Delete">';
        FrecRow += '<i class="fa fa-trash"></i>';
        FrecRow += '</button>';
        FrecRow += '</div>';                                        
        FrecRow += '</td>';     
        FrecRow += ' <td id="FileInxS' + FilecounterS + '" style="display: none;" > </td>';
        FrecRow += '<td id="FileSaveS' + FilecounterS + '" style="display: none;"> </td>';
        FrecRow += '<td id="FileEvtS' + FilecounterS + '" style="display: none;">INS</td>';
        FrecRow += '<td id="FileDtlIdS' + FilecounterS + '" style="display: none;"></td>';
        FrecRow += '<td id="DbFileNameS' + FilecounterS + '" style="display: none;"></td>';
        FrecRow += '</tr>';
        jQuery('#cphMain_QtnAtchmntSupplierFiles').append(FrecRow);
        document.getElementById('filePathS' + FilecounterS).innerHTML = 'No File Selected';
        FilecounterS++;
    }   
    function RemoveFileUploadS(removeNum) {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected file?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {              
                jQuery('#FilerowIdS_' + removeNum).remove();
                var TableFileRowCount =$(".trS").length; 
                if (TableFileRowCount != 0) {
                    var idlast = $('#cphMain_QtnAtchmntSupplierFiles tr:last').attr('id');
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("FileInxS" + res[1]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRowS" + res[1]).disabled = false;
                    }
                }
                else {
                    AddFileUploadS();
                }
                return false;
            }
            else {
                return false;
            }
        });
        return false;          
    }
    function ChangeFileS(x) {
        IncrmntConfrmCounter();
        if (document.getElementById('fileS' + x).value != "") {
            document.getElementById('filePathS' + x).innerHTML = document.getElementById('fileS' + x).value;
        }
        else {
            document.getElementById('filePathS' + x).innerHTML = 'No File Selected';
        }  
    }
    function CheckFileUploadedS(x) {
        if (document.getElementById('fileS' + x).value != "") {
            return true;
        }
        else {
            return false;
        }
    }
    function CheckaddMoreRowsIndividualFilesS(x) {
        // for add image in each row
        var check = document.getElementById("FileInxS" + x).innerHTML;
        if (check == " ") {
            var Fevt = document.getElementById("FileEvtS" + x).innerHTML;
            if (Fevt != 'UPD') {
                if (CheckFileUploadedS(x) == true) {
                    document.getElementById("FileInxS" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRowS" + x).disabled = true;
                    AddFileUploadS();
                    return false;
                }
            }
            else {
                document.getElementById("FileInxS" + x).innerHTML = x;
                document.getElementById("FileIndvlAddMoreRowS" + x).disabled = true;
                AddFileUploadS();
                return false;
            }
        }
        return false;
    }
    //Tender Files
    var FilecounterT = 0;
    function AddFileUploadT() {
        var FrecRow = '<tr id="FilerowIdT_' + FilecounterT + '" class="trT">'; 
        FrecRow += '<td class="tr_l" colspan="2">';
        FrecRow += '<input type="file" id="fileT' + FilecounterT + '" name = "fileT' + FilecounterT +'" onchange="ChangeFileT(' + FilecounterT + ')" accept=".xlsx,.xls,image/*,.doc, .docx,.csv,.ppt, .pptx,.txt,.pdf"/  multiple="">';
        FrecRow += '<label for="fileT' + FilecounterT + '" class="la_up"><i class="fa fa-upload" aria-hidden="true"></i> Upload file</label>';
        FrecRow += '<div id="filePathT' + FilecounterT + '" class="file_n"></div>';
        FrecRow += '</td>';
        FrecRow += '<td>'; 
        FrecRow += '<div class="btn_stl1">';
        FrecRow += '<button id="FileIndvlAddMoreRowT' + FilecounterT + '" class="btn act_btn bn2" onclick="return CheckaddMoreRowsIndividualFilesT(' + FilecounterT + ');" title="Add">';
        FrecRow += '<i class="fa fa-plus-circle"></i>';
        FrecRow += '</button>';
        FrecRow += '<button class="btn act_btn bn3" onclick = "return RemoveFileUploadT(' + FilecounterT + ');"" title="Delete">';
        FrecRow += '<i class="fa fa-trash"></i>';
        FrecRow += '</button>';
        FrecRow += '</div>';                                        
        FrecRow += '</td>';     
        FrecRow += ' <td id="FileInxT' + FilecounterT + '" style="display: none;" > </td>';
        FrecRow += '<td id="FileSaveT' + FilecounterT + '" style="display: none;"> </td>';
        FrecRow += '<td id="FileEvtT' + FilecounterT + '" style="display: none;">INS</td>';
        FrecRow += '<td id="FileDtlIdT' + FilecounterT + '" style="display: none;"></td>';
        FrecRow += '<td id="DbFileNameT' + FilecounterT + '" style="display: none;"></td>';
        FrecRow += '</tr>';
        jQuery('#cphMain_QtnAtchmntTenderFiles').append(FrecRow);
        document.getElementById('filePathT' + FilecounterT).innerHTML = 'No File Selected';
        FilecounterT++;
    }   
    function RemoveFileUploadT(removeNum) {
        ezBSAlert({
            type: "confirm",
            messageText: "Are you sure you want to delete selected file?",
            alertType: "info"
        }).done(function (e) {
            if (e == true) {               
                jQuery('#FilerowIdT_' + removeNum).remove();
                var TableFileRowCount = $(".trT").length;               
                if (TableFileRowCount != 0) {
                    var idlast = $('#cphMain_QtnAtchmntTenderFiles tr:last').attr('id');
                    if (idlast != "") {
                        var res = idlast.split("_");
                        //  alert(res[1]);
                        document.getElementById("FileInxT" + res[1]).innerHTML = " ";
                        document.getElementById("FileIndvlAddMoreRowT" + res[1]).disabled = false;
                    }
                }
                else {
                    AddFileUploadT();
                }
                return false;
            }
            else {
                return false;
            }
        });
        return false;          
    }
    function ChangeFileT(x) {
        IncrmntConfrmCounter();
        if (document.getElementById('fileT' + x).value != "") {
            document.getElementById('filePathT' + x).innerHTML = document.getElementById('fileT' + x).value;
            //document.getElementById('filePathT' + x).style.display="none";
            //document.getElementById('filePathT' + x).style.display="";
        }
        else {
            document.getElementById('filePathT' + x).innerHTML = 'No File Selected';
        }       
    }
    function CheckFileUploadedT(x) {
        if (document.getElementById('fileT' + x).value != "") {
            return true;
        }
        else {
            return false;
        }
    }
    function CheckaddMoreRowsIndividualFilesT(x) {
        // for add image in each row
        var check = document.getElementById("FileInxT" + x).innerHTML;
        if (check == " ") {
            var Fevt = document.getElementById("FileEvtT" + x).innerHTML;
            if (Fevt != 'UPD') {
                if (CheckFileUploadedT(x) == true) {
                    document.getElementById("FileInxT" + x).innerHTML = x;
                    document.getElementById("FileIndvlAddMoreRowT" + x).disabled = true;
                    AddFileUploadT();
                    return false;
                }
            }
            else {
                document.getElementById("FileInxT" + x).innerHTML = x;
                document.getElementById("FileIndvlAddMoreRowT" + x).disabled = true;
                AddFileUploadT();
                return false;
            }
        }
        return false;
    }

    $(document).ready(function(){ 
        AddFileUploadA();
        AddFileUploadS();
        AddFileUploadT();
        if(document.getElementById("<%=HiddenFieldAttachEditMode.ClientID%>").value=="0"){
            document.getElementById("<%=btnUploadQtnAttchAddtnl.ClientID%>").style.display="none";
            $("#divBodyFiles").find("input:not(.notv),button:not(.notv),checkbox,select:not(.notv)").prop("disabled", true);            
        }

    });
    function OpenQtnAtchmntAdditional() {
        document.getElementById("<%=hiddenOpenTenderAttch.ClientID%>").value = "";
        document.getElementById("<%=hiddenOpenSupplierAttch.ClientID%>").value = ""; 
        document.getElementById("<%=hiddenOpenAdditionalAttch.ClientID%>").value = "";
        UnCheckQtnAddtnlAttchmnt();     
        UnCheckQtnTenderAttchmnt();
        UnCheckQtnSupplierQuoteAttchmnt();
        $('#divBodyFiles input[type=checkbox]:checked').click();
        $('#add_files').modal('show');
    }
    function UnCheckQtnAddtnlAttchmnt() {
        var table = document.getElementById("cphMain_QtnAtchmntAddtnlFiles");
        for (var i = 0, row; row = table.rows[i]; i++) {
            if($(table.rows[i]).hasClass("edit")){
                var QtnAttchId = "";
                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        QtnAttchId = col.innerHTML;
                    }
                    if (j == 3) {
                        if (document.getElementById('chbx_AddtnlFl' + QtnAttchId).checked == true && QtnAttchId != "") {
                            document.getElementById('chbx_AddtnlFl' + QtnAttchId).checked = false;
                        }
                    }
                }
            }
        }
    }
    function CheckForDeleteQtnAddtnlAttchmnt(TYPE) {
        var ret = true;       
        document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = "";
        document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = "";
        var table = document.getElementById("cphMain_QtnAtchmntAddtnlFiles");
        for (var i = 0, row; row = table.rows[i]; i++) {
            if($(table.rows[i]).hasClass("edit")){
                var QtnAttchId = "";
                var QtnAttchFileName = "";
                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        QtnAttchId = col.innerHTML;
                    }
                    if (j == 1) {
                        QtnAttchFileName = col.innerHTML;
                    }
                    if (j == 3) {
                        if (document.getElementById('chbx_AddtnlFl' + QtnAttchId).checked == true && QtnAttchId != "" && QtnAttchFileName != "") {
                            var detailId = QtnAttchId;
                            //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                            if (detailId != '') {
                                var CanclIds = document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value;
                                if (CanclIds == '') {
                                    document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = detailId;
                                }
                                else {

                                    document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value + ',' + detailId;
                                }
                            }
                            var detailFileName = QtnAttchFileName;
                            if (detailFileName != '') {
                                var CanclFileNames = document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value;
                                if (CanclFileNames == '') {
                                    document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = detailFileName;
                                }
                                else {
                                    document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value + ',' + detailFileName;
                                }
                            }
                        }
                    }
                }
             }
            }
    
            if (TYPE == "D") {
                if (document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value == "") {
                    ret = false;
                    $("#divErrorRsnQtnAttchmntAdditional").html("Please select atleast a file inorder to remove.");
                    $("#divErrorRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
                    });          
                }
                else{
                    document.getElementById("<%=btnDeleteQtnAdtnlFiles.ClientID%>").click();
                }
            } 
            else {
                document.getElementById("<%=btnAttachFileWithMail.ClientID%>").click();               
         }
    return false;
    }
    function CheckForDeleteQtnAddtnlAttchmntInd(TYPE,id,nam) {
        var ret = true;       
        document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value =id;
        document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = nam;          
        document.getElementById("<%=btnDeleteQtnAdtnlFiles.ClientID%>").click();              
        return false;
    }
    function CheckForDeleteQtnSupplierAttchmnt() {
        var ret = true;
       
         document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = "";
           document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = "";
        var table = document.getElementById("cphMain_QtnAtchmntSupplierFiles");
           for (var i = 0, row; row = table.rows[i]; i++) {
               if($(table.rows[i]).hasClass("edit")){
                   var QtnAttchId = "";
                   var QtnAttchFileName = "";
                   //iterate through rows
                   //rows would be accessed using the "row" variable assigned in the for loop
                   for (var j = 0, col; col = row.cells[j]; j++) {
                       if (j == 0) {
                           QtnAttchId = col.innerHTML;

                       }
                       if (j == 1) {
                           QtnAttchFileName = col.innerHTML;

                       }

                       if (j == 3) {
                           if (document.getElementById('chbx_SupplierFl' + QtnAttchId).checked == true && QtnAttchId != "" && QtnAttchFileName != "") {
                               var detailId = QtnAttchId;
                               //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                               if (detailId != '') {
                                   var CanclIds = document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value;

                                   if (CanclIds == '') {
                                       document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = detailId;

                                   }
                                   else {

                                       document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value + ',' + detailId;
                                   }

                               }



                               var detailFileName = QtnAttchFileName;
                               //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                               if (detailFileName != '') {
                                   var CanclFileNames = document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value;

                                   if (CanclFileNames == '') {
                                       document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = detailFileName;

                                   }
                                   else {

                                       document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value + ',' + detailFileName;
                                   }

                               }

                           }
                       }
                       //iterate through columns
                       //columns would be accessed using the "col" variable assigned in the for loop
                       // alert(col.innerHTML);
                   }
               }
    }

        if (document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value == "") {
            ret = false;
            $("#divErrorRsnQtnAttchmntAdditional").html("Please select atleast a file inorder to remove.");
            $("#divErrorRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            }); 
        }
        else{
            document.getElementById("<%=btnSupplierQuoteDelete.ClientID%>").click();  
        }        
         return false;
    }
    function CheckForDeleteQtnSupplierAttchmntInd(id,nam) {    
        document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = id;
        document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = nam;      
        document.getElementById("<%=btnSupplierQuoteDelete.ClientID%>").click();      
        return false;
    }
    function CheckForDeleteQtnTenderAttchmnt() {
        var ret = true;
       
      document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = "";
        document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = "";
        var table = document.getElementById("cphMain_QtnAtchmntTenderFiles");
        for (var i = 0, row; row = table.rows[i]; i++) {
            if($(table.rows[i]).hasClass("edit")){
                var QtnAttchId = "";
                var QtnAttchFileName = "";
                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        QtnAttchId = col.innerHTML;

                    }
                    if (j == 1) {
                        QtnAttchFileName = col.innerHTML;

                    }

                    if (j == 3) {
                        if (document.getElementById('chbx_TenderFl' + QtnAttchId).checked == true && QtnAttchId != "" && QtnAttchFileName != "") {
                            var detailId = QtnAttchId;
                            //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                            if (detailId != '') {
                                var CanclIds = document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value;

                                if (CanclIds == '') {
                                    document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = detailId;

                                }
                                else {

                                    document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value + ',' + detailId;
                                }

                            }



                            var detailFileName = QtnAttchFileName;
                            //   var SlNumber = document.getElementById("tdSlNumbr" + x).innerHTML;
                            if (detailFileName != '') {
                                var CanclFileNames = document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value;

                                if (CanclFileNames == '') {
                                    document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = detailFileName;

                                }
                                else {

                                    document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value + ',' + detailFileName;
                                }

                            }

                        }
                    }
                    //iterate through columns
                    //columns would be accessed using the "col" variable assigned in the for loop
                    // alert(col.innerHTML);
                }
            }
    }

        if (document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value == "") {
            ret = false;
            $("#divErrorRsnQtnAttchmntAdditional").html("Please select atleast a file inorder to remove.");
            $("#divErrorRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            }); 
        }
        else{
            document.getElementById("<%=btnQtnAtchmntTenderDelete.ClientID%>").click();
        }     
        return false;
    }
    function CheckForDeleteQtnTenderAttchmntInd(id,nam) {      
        document.getElementById("<%=hiddenCanclFileDtlId.ClientID%>").value = id;
        document.getElementById("<%=hiddenCanclFileDtlName.ClientID%>").value = nam;      
        document.getElementById("<%=btnQtnAtchmntTenderDelete.ClientID%>").click();
        return false;
    }
    function UnCheckQtnTenderAttchmnt() {
        if($("#cphMain_QtnAtchmntTenderFiles").length>0){
            var table = document.getElementById("cphMain_QtnAtchmntTenderFiles");
            for (var i = 0, row; row = table.rows[i]; i++) {

                var QtnAttchId = "";

                //iterate through rows
                //rows would be accessed using the "row" variable assigned in the for loop
                for (var j = 0, col; col = row.cells[j]; j++) {
                    if (j == 0) {
                        QtnAttchId = col.innerHTML;

                    }


                    if (j == 3) {
                        if (document.getElementById('chbx_TenderFl' + QtnAttchId).checked == true && QtnAttchId != "") {


                            document.getElementById('chbx_TenderFl' + QtnAttchId).checked = false;


                        }
                    }
                    //iterate through columns
                    //columns would be accessed using the "col" variable assigned in the for loop
                    // alert(col.innerHTML);
                }
            }
        }
    }
    function UnCheckQtnSupplierQuoteAttchmnt() {
        var table = document.getElementById("cphMain_QtnAtchmntSupplierFiles");
        for (var i = 0, row; row = table.rows[i]; i++) {

            var QtnAttchId = "";

            //iterate through rows
            //rows would be accessed using the "row" variable assigned in the for loop
            for (var j = 0, col; col = row.cells[j]; j++) {
                if (j == 0) {
                    QtnAttchId = col.innerHTML;

                }


                if (j == 3) {
                    if (document.getElementById('chbx_SupplierFl' + QtnAttchId).checked == true && QtnAttchId != "") {


                        document.getElementById('chbx_SupplierFl' + QtnAttchId).checked = false;


                    }
                }
                //iterate through columns
                //columns would be accessed using the "col" variable assigned in the for loop
                // alert(col.innerHTML);
            }
        }
    }
    function CheckQtnAttchmntAdditional() {
        var ret = true;
  
        if (ret == false) {
            $("#divErrorRsnQtnAttchmntAdditional").html("Please select atleast a file to upload.");
            $("#divErrorRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            });      
    }
    else if (ret == true) {
    }
    return ret;
}
    function SuccessInsertAddtnlQtnAttch() {
        $("#divSuccesRsnQtnAttchmntAdditional").html("Files inserted successfully");
        $("#divSuccesRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
        });      
       }
        function SuccessDeleteAddtnlQtnAttch() {
            $("#divSuccesRsnQtnAttchmntAdditional").html("Additional files removed successfully.");
            $("#divSuccesRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            });  
           
        }
        function SuccessStsChngeAddtnlQtnAttch() {
            $("#divSuccesRsnQtnAttchmntAdditional").html("Files attached with mail successfully.");
            $("#divSuccesRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            });          
        }      
        function SuccessDeleteSupplierQtnAttch() {
            $("#divSuccesRsnQtnAttchmntAdditional").html("Supplier quotes removed successfully.");
            $("#divSuccesRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            });          
        }      
        function SuccessDeleteTenderQtnAttch() {
            $("#divSuccesRsnQtnAttchmntAdditional").html("Tender files removed successfully.");
            $("#divSuccesRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            });          
        }
        function SuccessStsChngeAddtnlQtnAttchErr() {
            $("#divErrorRsnQtnAttchmntAdditional").html("Please select atleast a file to upload.");
            $("#divErrorRsnQtnAttchmntAdditional").fadeTo(3000, 500).slideUp(500, function () {
            });         
        }
        
</script>



         
           
    <div id="divOptionsLeadSource" runat="server" style="display: none">
    </div>
    <div id="divOptionsTaskSubject" runat="server" style="display: none">
    </div>
    <div id="divOptionsLossReason" runat="server" style="display: none">
    </div>
    <div id="divOptionsAllocateEmp" runat="server" style="display: none">
    </div>
    <div id="divGoofy" runat="server">
    </div>
      <script type="text/javascript">
          $(document).ready(function(){ 
              $(".cont_contr").scroll(function(){ 
                  if ($(this).scrollTop() > 100) { 
                      $('#scroll').fadeIn();
                      $('.popover.right').fadeOut();
                      $('.popover.top').fadeOut();   
                  } else { 
                      $('#scroll').fadeOut(); 
                  } 
              }); 
              $('#scroll').click(function(){ 
                  $(".cont_contr").animate({ scrollTop: 0 }, 600); 
                  return false; 
              }); 
          });
</script>
<script type="text/javascript">
    $(document).ready(function(){
        $("#myModalFollowUp").on('shown.bs.modal', function(){
            $(this).find('#ddlFollowUpLeadSource').focus();
        }); 
        $("#myModalTask").on('shown.bs.modal', function(){
            $(this).find('#ddlTaskSubject').focus();
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
    isOpen() {
        return this._isOpen;
    }
}

    Popover.TOP = 'top';
    Popover.RIGHT = 'right';
    Popover.BOTTOM = 'bottom';
    Popover.LEFT = 'left';

    document.addEventListener('DOMContentLoaded', function() {
      let btn = document.querySelector('#popoverOpener'),
        template = document.querySelector('.popover'),
        pop = new Popover(template, btn, {
            position: Popover.RIGHT
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
            $('.popover.right').hide("");
        } 
    });
    $(document).on("click", ".popover.right .btn-dz" , function(){
        $('.popover.right').hide("");
    });
</script>

<script>
    $(document).ready(function(){
        $(".dislike").click(function(){
            $(".stat_sbox").toggle();
            $(".stat_sbox1").hide();
            return false;
        });
        $(".opp_btz").click(function(){
            if (document.getElementById("<%=HiddenFieldQuotIcon.ClientID%>").value == "0") {
                $(".stat_sbox1").toggle();
                $(".stat_sbox").hide();
                return false;
            }
        });
        $(".allo_btn, .btn, .cont_contr").click(function(){
            $(".stat_sbox, .stat_sbox1").hide();
        });
        $(document).on('keydown', function(e) { 
            var keyCode = e.keyCode || e.which; 

            if (keyCode == 27) { 
                $('.stat_sbox').hide();
                $('.stat_sbox1').hide();
            } 
        });
    });
</script>

    <script type="text/javascript">
$(function () {
  $('[data-toggle="popover"]').popover();
  $('[data-toggle="tooltip"]').tooltip();
  $('body').popover('disable');
});
$(document).on('keydown', function(e) { 
  var keyCode = e.keyCode || e.which; 

  if (keyCode == 27) { 
   $('.popover.top').hide();
   $('.popover.right').popover('hide');
   $('.bt_fx_crqt').addClass('new_bs');
  } 
});
    $(document).on("click", ".popover .pop_o_cls" , function(){
        $(this).parents(".popover").popover('hide');
    });

</script>

<style type="text/css">
  .popover-content{max-height: 240px;}
  .popover.top{max-width:370px;}
</style>

<style type="text/css">
  .popover-content0{max-height: 300px;}
  .popover0.top0{max-width:500px;}
  .popover.right{min-width:500px;min-height: 400px;}
  .popover.right .popover-content{min-height:400px;}
  .cke_1.cke_chrome {
    min-height: 333px;
    outline:none!important;
    border:none;
    background-color:#fff;
    width:100%;
    box-shadow: none;
}
   .selected {
    background-color: #98bedc !important;
}
    #cke_2_top {
        display:none;
    }
</style>
</asp:Content>

