<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Leave_Approval_List.aspx.cs" Inherits="HCM_HCM_Master_gen_Manpower_Recruitment_gen_Manpower_Recruitment_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
     <style>
              #divMessageArea {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #imgMessageArea {
            float: left;
            margin-left: 1%;
            margin-top: -0.2%;
        }
               /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
         .modalCancelView {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 30%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             overflow: auto; /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }


         /* The Close Button */
         .closeCancelView {
             color: white;
             float: right;
             font-size: 28px;
             font-weight: bold;
         }

             .closeCancelView:hover,
             .closeCancelView:focus {
                 color: #000;
                 text-decoration: none;
                 cursor: pointer;
             }

         .modal-headerCancelView {
             /*padding: 1% 1%;*/
            background-color: #91a172;
             color: white;
         }

         .modal-bodyCancelView {
             padding: 4% 4% 7% 4%;
         }

         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
         #divErrorRsnAWMS {
    border-radius: 4px;
    background: #fff;
    color: #53844E;
    font-size: 12.5px;
    font-family: Calibri;
    font-weight: bold;
    border: 2px solid #53844E;
    margin-top: -3.5%;
    margin-bottom: 2%;
}

     </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('MymodalCancelView').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });

          function getdetails(href) {
              window.location = href;
              return false;
          }
          </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

          function OpenCancelView() {



              document.getElementById("MymodalCancelView").style.display = "block";
              document.getElementById("freezelayer").style.display = "";
              document.getElementById("<%=txtCnclReason.ClientID%>").focus();

              return false;

          }
          function CloseCancelView() {
              if (confirm("Do you want to close  without completing cancellation process?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("MymodalCancelView").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
              }
              return false;
          }

          function ReCallAlert(href) {

              if (confirm("Do you want to Recall this Entry?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }
              function SuccessClose() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request  Closed successfully";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
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
    <script type="text/javascript">
        function SuccessConfirmation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower inserted successfully.";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower updated successfully.";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML =" Manpower cancelled successfully.";
        }
        function SuccessRecall() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower recalled Successfully.";
        }
        function SuccessStatusChange() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower status changed successfully.";
        }
        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request reopened successfully.";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request confirmed successfully.";
        }
        
        function SuccessApproved() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request  approved successfully.";
        }
        function SuccessVerified() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Manpower details verified.";
        }
        function SuccessRejected() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave details rejected successfully.";
        }
        function SuccessApprovedRep() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request successfully  approved by reporting officer";
          }
        function SuccessApprovedDivmanager() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request successfully approved by division manager";
          }
        function SuccessApprovedHr() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request successfully  approved by HR";
        }
              function SuccessApprovedGm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request successfully  approved by GM.";
        }
        
         function getdetails(href) {
             window.location = href;
             return false;
         }
         function CancelAlert(href) {

             if (confirm("Do you want to cancel this Entry?")) {
                 window.location = href;
                 return true;
             }
             else {
                 return false;
             }
         }

         function CancelNotPossible() {
             alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
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
         function ChangeEntryStatus(CatId, CatStatus) {
             if (confirm("Do you want to change the status of this entry?")) {
                 var SearchString = document.getElementById("<%=HiddenSearchField.ClientID%>").value;
                 var corpid = document.getElementById("<%=Hiddencorpid.ClientID%>").value;
                 var orgid = document.getElementById("<%=Hiddenorgid.ClientID%>").value;
                 var edit = document.getElementById("<%=Hiddenenabledit.ClientID%>").value;
                 var cancel = document.getElementById("<%=Hiddenenablecancl.ClientID%>").value;
            
                 var Details = PageMethods.ChangeEntryStatus(CatId, CatStatus,corpid,orgid,edit,cancel,SearchString, function (response) {
                   
                     var SucessDetails = response.strRet;
                     document.getElementById("<%=divReport.ClientID%>").innerHTML = response.strhtml;
                  //   alert(SucessDetails);
                     if (SucessDetails == "success") {
               
                         if (SearchString == "") {
                             // window.location = 'gen_Manpower_Recruitment_List.aspx?InsUpd=StsCh';
                             //   response.strRet;
                            // divReport.innerHTML = response.strhtml;
                             //alert(response.strhtml);
                         }
                         else {
                             window.location = 'gen_Manpower_Recruitment_List.aspx?InsUpd=StsCh&Srch=' + SearchString + '';
                         }


                     }
                     else {
                         window.location = 'gen_Employee_Sponsor_List.aspx?InsUpd=Error';
                     }
                     $p('#ReportTable').DataTable({
                         "pagingType": "full_numbers",
                         "bSort": true,
                         "pageLength": 25
                     });
                 });
             }
             else {
                 return false;
             }
         }
        function ConfirmMessageApprove() {

            if (confirm("Are you sure you want to approve this request?")) {

                return true;
            }
            else {
                return false;
            }
        }
        function SearchValidation() {
            ret = true;
          
               document.getElementById("<%=txtfrmdate.ClientID%>").style.borderColor = "";
               document.getElementById("<%=txttodate.ClientID%>").style.borderColor = "";
          
            var frmdate = document.getElementById("<%=txtfrmdate.ClientID%>").value;
           // alert(frmdate);
            var arrDatePickerDate1 = frmdate.split("-");
            frmdate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
          //  alert(frmdate);
           // alert(frmdate);
             var todate = document.getElementById("<%=txttodate.ClientID%>").value.trim();
            var arrDatePickerDate1 = todate.split("-");
            todate = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
         //   alert(todate);
            if (frmdate > todate) { //3emp17
            //  alert("divMessageArea");
                  document.getElementById("<%=txtfrmdate.ClientID%>").style.borderColor = "Red";
                
                  document.getElementById("<%=txtfrmdate.ClientID%>").focus();
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,from date cannot be greater than to date !.";
                   ret = false;
               }


             return ret;

         }

        </script>

   <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
          <%--     //document.getElementById("<%=ddlDivision.ClientID%>").focus();--%>

            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });


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
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>

    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />

    <script>


        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
                $au('#cphMain_ddlCustomer').selectToAutocomplete1Letter();


            });
        })(jQuery);
    </script>


    <style>
        #cphMain_divReport {
            float: left;
            width: 93.5%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 100%;
             margin-left: 1%;
        }
    </style>

    <script>

        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }

        //validation when cancel process
        function ValidateCancelReason() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
            if (Reason == "") {
                document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }



         function ChangeStatus(CatId, CatStatus) {
             if (confirm("Do You Want To Change The Status Of This Entry?")) {
                 var SearchString = document.getElementById("<%=HiddenSearchField.ClientID%>").value;

                 var Details = PageMethods.ChangeContractStatus(CatId, CatStatus, function (response) {
                     var SucessDetails = response;

                     if (SucessDetails == "success") {
                         if (SearchString == "") {
                             window.location = 'gen_Manpower_Recruitment_List.aspx?InsUpd=StsCh';
                         }
                         else {
                             window.location = 'gen_Manpower_Recruitment_List.aspx?InsUpd=StsCh&Srch=' + SearchString + '';
                         }


                     }
                     else {
                         window.location = 'gen_Manpower_Recruitment_List.aspx?InsUpd=Error';
                     }
                 });
             }
             else {
                 return false;
             }
         }


        function LeavApprvlId(id) {

            var nWindow = window.open('/HCM/HCM_Master/hcm_LeaveMaster/hcm_Leave_Approval/gen_Leave_Approval.aspx?Id=' + id + '&RFGP=VW', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
            // nWindow.focus();
        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
      <asp:HiddenField ID="Hiddencorpid" runat="server" />
      <asp:HiddenField ID="Hiddenorgid" runat="server" />
          <asp:HiddenField ID="Hiddenenablecancl" runat="server" />
             <asp:HiddenField ID="HiddenHrCnfrm" runat="server" />
               <asp:HiddenField ID="HiddenDMApprove" runat="server" />
      <asp:HiddenField ID="Hiddenenabledit" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
   

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Leave approval.png" style="vertical-align: middle;" />
           LEAVE APPROVAL
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:1%;">

           <div id="divDivision " class="eachform" style="width: 25%;margin-top: 1%;margin-left: 4%;">
                    <h2 style="margin-top: 1%;width: 16%;">Mode</h2>
                   
                    <asp:DropDownList ID="ddlMode" style="width: 64%;" tabindex="2" class="form1"  runat="server" >
                   <asp:ListItem Text="LEAVE REQUEST" Value="1"> </asp:ListItem>
                   <asp:ListItem Text="CANCEL LEAVE" Value="2">   
                   </asp:ListItem>
                         </asp:DropDownList>
                </div>
 <div class="eachform" style="width: 25%;margin-top: 1%;margin-left: 4%;">

                <h2 style="margin-top:1%;">Status</h2>

                <asp:DropDownList ID="ddlStatus" style="width: 64%;" TabIndex="3"  class="form1" runat="server" >
                       <asp:ListItem Text="PENDING" Value="0" ></asp:ListItem>
                    <asp:ListItem Text="APPROVED" Value="1"></asp:ListItem>
                    <asp:ListItem Text="REJECTED" Value="2"></asp:ListItem>
                    <asp:ListItem Text="ALL" Value="3"></asp:ListItem>
                </asp:DropDownList>


            </div>
             <div class="eachform" style="width: 25%;margin-top: 1%;margin-left: 4%;">

                <h2 style="margin-top:1%;">Role*</h2>

                <asp:DropDownList ID="ddrole" style="width: 64%;margin-right: 5%;" TabIndex="3"  class="form1" runat="server" >
                    
                 
                </asp:DropDownList>


            </div>
      
                   <div class="eachform" style="width:10%;float: right;margin-top: 1%;margin-right: 1%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: -0.4%;" TabIndex="5" runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();"  OnClick="btnSearch_Click" />
                     </div>
            <div style="float:left;width:100%">
                  
        <div style="width:100%;clear:both;">
          
                <div id="DivCGuarantee" class="eachform" style="width: 25%;margin-top:1%;margin-left: 4%;">

                   <div id="divDateTime" runat="server" class="subform"  style="width: 100%; float: left; margin-top: 0%;">


                                       
                           <div id="datetimepickerFrm" class="input-append date" style=style="font-family: Calibri; width: 98%;  float: left; "    >
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri; margin-left: 0%;float: left;">From Date</span>
                                <div style="float:right; margin-right: 0%;width: 70%;">
                                    <asp:TextBox ID="txtfrmdate" runat="server" class="form1" placeholder="DD-MM-YYYY" onkeydown="return DisableEnter(event);" style="width: 65%;  font-family: calibri; float: left;height:30px; font-size:15px;margin-left:9%" type="text"></asp:TextBox>
                                    <img class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; float:left;/*! margin-left:280%; *//*! margin-bottom:20%; */ cursor:pointer">
                                    <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                                    <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                                <script type="text/javascript"
                                    src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                                </script>
                                <script type="text/javascript"
                                    src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                                </script>
                                 <script type="text/javascript"
                                    src="/JavaScript/Date/bootstrap-datepicker.js">
                                </script>
                                <script type="text/javascript"
                                    src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                                </script>
                                <script type="text/javascript">
                                    var $noC = jQuery.noConflict();
                                    $noC('#datetimepickerFrm').datetimepicker({
                                        format: 'dd-MM-yyyy',
                                        language: 'en',
                                        pickTime: false,



                                    });
                                    function ReloadTodate() {
                                        $noCo('#datetimepickerTo').datetimepicker({
                                            format: 'dd-MM-yyyy',
                                            language: 'en',
                                            pickTime: false,
                                            //defaultDate: null
                                            //startDate: new Date(),

                                        });
                                    }
                                </script>
                            &nbsp;</div>
                               </div>   
                  </div>
       


            </div>
             <div id="DivCGuaranteej" class="eachform" style="width: 25%;margin-top:1%;margin-left: 4%;margin-bottom: 0.5%;">              
           <div id="div1" runat="server" class="subform"  style="width: 100%; float: left; margin-top: 0%; ">


                                       
                           <div id="datetimepickerTo" class="input-append date" style="font-family: Calibri; width: 100%;  float: left; /*! margin-right: 48%; */ margin-top: 0%;"    >
                                <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri; margin-left: 0%;float: left;">To Date</span>
                                <div style="float:right; margin-right: 0%;width: 70%;">
                                    <asp:TextBox ID="txttodate" runat="server" class="form1" placeholder="DD-MM-YYYY" onkeydown="return DisableEnter(event);" style="width: 64%;  font-family: calibri; float: left;height:30px; font-size:15px;margin-left: 10%;" type="text"></asp:TextBox>
                                     <img class="add-on" src="/Images/Icons/CalandarIcon.png" style="height: 22px; float:left;/*! margin-left:280%; *//*! margin-bottom:20%; */ cursor:pointer">
                                    <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
                                    <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                                <script type="text/javascript"
                                    src="/JavaScript/Date/JavaScriptDate1_8_3.js">
                                </script>
                                <script type="text/javascript"
                                    src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js">
                                </script>
                                 <script type="text/javascript"
                                    src="/JavaScript/Date/bootstrap-datepicker.js">
                                </script>
                                <script type="text/javascript"
                                    src="/JavaScript/Date/bootstrap-datepicker_pt_br.js">
                                </script>
                                <script type="text/javascript">
                                    var $noC = jQuery.noConflict();
                                    $noC('#datetimepickerTo').datetimepicker({
                                        format: 'dd-MM-yyyy',
                                        language: 'en',
                                        pickTime: false,



                                    });
                                    function ReloadTodate() {
                                        $noCo('#datetimepickerTo').datetimepicker({
                                            format: 'dd-MM-yyyy',
                                            language: 'en',
                                            pickTime: false,
                                            //defaultDate: null
                                            //startDate: new Date(),

                                        });
                                    }
                                </script>
                            &nbsp;</div>
                               </div>   
                  </div>
       
                </div>
               
   
            </div>


           
         
               </div>
            <br style="clear: both" />
            </div>
        <br />

        <div onclick="location.href='gen_Leave_Approval.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;display:none">

          <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
        <%--  <br />
        <br />--%>
        <div id="divReport" class="table-responsive" runat="server">
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
        </div>

                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Manpower Requirement</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click"  style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
    </div>
    <style>
          #ReportTable_filter input {
          height:17px;
        }


    </style>
</asp:Content>

