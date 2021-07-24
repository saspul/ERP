<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Clearance_Form_Approval_List.aspx.cs" Inherits="HCM_HCM_Master_hcm_LeaveMaster_hcm_Clearance_Form_Worker_hcm_Clearance_Form_WorkerList" %>
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
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
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
          }

          function ReCallAlert(href) {

              if (confirm("Do you want to recall this entry?")) {
                  window.location = href;
                  return false;
              }
              else {
                  return false;
              }
          }

    </script>
      <script type="text/javascript">
          function SuccessIns() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details inserted successfully.";
              $(window).scrollTop(0);
          }
          //old
          function SuccessUpdation() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details updated successfully.";
          }
          function SuccessCancelation() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details cancelled successfully.";
          }
          function SuccessRecall() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details recalled successfully.";
          }
          function SuccessStatusChange() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details status changed successfully.";
        }
        function SuccessReOpen() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details reOpened successfully.";
        }
        function SuccessConfirm() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details confirmed successfully.";
        }
        function SuccessClose() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details closed successfully.";
        }
           function SuccessApproved() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details approved successfully.";
          }
          function SuccessRejected() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance form  details rejected successfully.";
          }
        function getdetails(href) {
            window.location = href;
            return false;
        }
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            return false;

        }
        function validateClearanceForm() {

            if (confirm("Are you sure you want to approve?")) {
                return true;
            }
            else {
                return false;
            }

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

   <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });
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
            width: 98%;
        }
    </style>
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
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
          }

          //function ReCallAlert(href) {

          //    if (confirm("Do you want to Recall this Entry?")) {
          //        window.location = href;
          //        return false;
          //    }
          //    else {
          //        return false;
          //    }
          //}

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
         function SearchValidation() {
             ret = true;



             var ddlEmployee = document.getElementById("<%=ddlEmployee.ClientID%>").value;
             if (ddlEmployee == "--SELECT EMPLOYEE--") {
                 ddlEmployee = 0;

             }

             var ddlSts = document.getElementById("<%=ddlStatus.ClientID%>").value;


             var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");

             var cbx = 0;
             var rbtn = 0;

             if (document.getElementById("<%=radioLeave.ClientID%>").checked=="0") {
                 rbtn = 1;
             }
             else {
                 rbtn = 0;
             }


             if (cbxStatus.checked) {
                 cbx = 1;
             }
             else {
                 cbx = 0;
             }

             if (ret == true) {

                 document.getElementById("<%=HiddenSearchField.ClientID%>").value = ddlEmployee + ',' + ddlSts + ',' + radioLeave;
            }


            return ret;

        }
         function WorkrId(id) {

             var nWindow = window.open('/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Worker/hcm_Clearance_Form_Worker.aspx?ViewId=' + id + '&RFGP=VW&Page=View', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
             // nWindow.focus();
         }
         function StaffId(id) {

             var nWindow = window.open('/HCM/HCM_Master/hcm_LeaveMaster/hcm_Clearance_Form_Staff/hcm_Clearance_Form_Staff.aspx?ViewId=' + id + '&RFGP=VW', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
             // nWindow.focus();
         }

         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
      
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
             <asp:HiddenField ID="hiddenRsnid" runat="server" />
    
    <asp:HiddenField ID="hiddenEnableModify" runat="server" />
    <asp:HiddenField ID="hiddenSearch" runat="server" />
    
    <asp:HiddenField ID="hiddenEnableCancl" runat="server" />
      <asp:HiddenField ID="HiddenSearchField" runat="server" />
    

    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
   <div id="divMessageArea" style="display: none;width:91%;">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/consultancy-icon.png" style="vertical-align: middle;" />
           Clearance Form Approval 
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 93.5%;margin-top:1%;">

         <div style="float:left;width:100%;padding-top: 2%;" >
                    <div id="DivCGuarantee" class="eachform" style="width: 25%; float:left">
                <h2 style="margin-top: 2%;margin-left: 3%;">Employee</h2>
                <asp:DropDownList ID="ddlEmployee" Height="30px"  Width="160px" class="form1" runat="server" Style="height:30px;width:160px;float:right;">
         
                             <asp:ListItem Text="All" Value="2"></asp:ListItem>
                          <asp:ListItem Text="Worker" Value="1"></asp:ListItem>

           <asp:ListItem Text="Staff" Value="0"></asp:ListItem>
                     </asp:DropDownList>
            </div>
                 
                <div id="DivProject" class="eachform" style="width: 25%;float:left">
                <h2 style="margin-top: 2%;width: 16%;margin-left: 15%;">Status </h2>
                <asp:DropDownList ID="ddlStatus" Height="30px"  Width="160px" class="form1" runat="server" Style="height:30px;width:160px;float:left; margin-left: 7%;">
                 <Items><asp:ListItem Text="Pending" Selected="True" Value="0" />
                     <asp:ListItem Text="Approved" Value="1" />
                     <asp:ListItem Text="Rejected" Value="2" />
   </Items>
                </asp:DropDownList>
            </div> 
            
      
                
                <div id="Div1" class="eachform" style="width: 25%;display:none">
                <div class="subform" style="width:215px;float: left;margin-left: 30%;display:none">
                    <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server" onkeydown="return DisableEnter(event);" Checked="false" class="form2" />
                    <h3 style="margin-top:1%;">Show Deleted Entries</h3>
                  </div>
            </div>    
               
             <div id="DivRbtn" class="eachform" style="width: 14%;float: left;margin-left: 5%;padding-left: 3%;margin-top: 2px;border: 1px solid #c3c3c3;height: 23px;padding-top: 4px;">

                 <asp:RadioButton ID="radioLeave" Text="Leave" runat="server" Checked="true" OnkeyPress="return DisableEnter(event)" GroupName="RadioCheck" Style="float: left; font-family: calibri;display:block;" />
                 <asp:RadioButton ID="radioExit" Text="Exit" runat="server" GroupName="RadioCheck" OnkeyPress="return DisableEnter(event)" Style="float: left; font-family: calibri; margin-left: 6%;display:block;" />

             </div>
                
              <div class="eachform" style="width:24%;margin-left: -5%;;float:left">
                <asp:Button ID="btnSearch" style="cursor:pointer;float:right;margin-right: 4%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" onclick="btnSearch_Click" />
                     </div>
                
                 </div>
            <br style="clear: both" />
            </div>
        <br />
        <div onclick="location.href='hcm_Clearance_Form_Worker.aspx'" id="divAdd" class="add" runat="server" style=" position: fixed; height:26.5px; right:1%;display:none">

          <%--  <a href="gen_Projects.aspx">
                <img src="../../Images/BigIcons/add.png" alt="Add" />
            </a>--%>
        </div>
        <%--  <br />
        <br />--%>
        <div id="divReport" class="table-responsive"  runat="server">
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

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Clearance Form Worker</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 25%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="CloseCancelView();" runat="server" Text="Close" />
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
        input[type="radio"] {
    display: initial;
}
    </style>
</asp:Content>
