<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Leave_Approval.aspx.cs" Inherits="HCM_HCM_Master_gen_Candidate_ShortList_gen_Candidate_ShortList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
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
   </script>
  <script>

      var confirmbox = 0;

      function IncrmntConfrmCounter() {

          confirmbox++;
      }
      function ConfirmMessage() {
          if (confirmbox > 0) {
              if (confirm("Are you sure you want to leave this page?")) {
                 window.location.href = "gen_Candidate_ShortList.apsx";
                  return true;
              }
              else {
                  return false;
              }
          }
          else {
            //  window.location.href = "gen_Manpower_Recruitment_List.aspx";

          }
      }
      function ConfirmMessage() {
       
              if (confirm("Are you sure you want to leave this page?")) {
                  window.location.href = "gen_Leave_Approval.apsx";
                  return true;
              }
              else {
                  return false;
              }
          }
  
      function ConfirmMessageReject() {

          if (confirm("Are you sure you want to Reject this Request?")) {
              return OpenCancelView();
              //return true;
          }
          else {
              return false;
          }
      } function ConfirmMessageClose() {

          if (confirm("Are you sure you want to Close this Request?")) {

              return true;
          }
          else {
              return false;
          }
      }
      function ConfirmMessageApprove() {
          var ret = true;
        
          if (document.getElementById("<%=txthrnote.ClientID%>").value =="") {

            //  alert(document.getElementById("<%=txthrnote.ClientID%>").value);
              document.getElementById('divMessageArea').style.display = "block";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              document.getElementById("<%=txthrnote.ClientID%>").style.borderColor = "Red";
              document.getElementById("<%=txthrnote.ClientID%>").focus();
              ret = false;
          }

          if (ret == true) {
              if (confirm("Are you sure you want to Approve this Request?")) {

                  return ret;
              }
          }
              else {
                  return false;
              }
         
         
      }
      function AlertClearAll() {
          if (confirmbox > 0) {
              if (confirm("Are you sure you want clear all data in this page?")) {
                
                  return true;
              }
              else {
                  return false;
              }
          }
          else {
             // window.location.href = "gen_Manpower_Recruitment_List.aspx";
              return true;
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
          <%--     //document.getElementById("<%=ddlDivision.ClientID%>").focus();--%>

            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });
          </script>

      
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        
     
    <asp:HiddenField ID="HiddenConsultancyId" runat="server" />
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 39%; height: 26.5px;">
        </div>

        <div style="width: 98.5%; border: 1px solid #8e8f8e; padding: 10px; background-color: white;float:left">
            <div id="divReportCaption" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">Leave Approval</asp:Label>
            </div>

            <div style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee</h2>
                    <asp:Label ID="lblEmpname" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Leave Type</h2>
                    <asp:Label ID="lblLeaveType" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">From Date</h2>
                    <asp:Label ID="lblFrmDate" class="form5"  runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Section</h2>
                    <asp:Label ID="lblSectn" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div><div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">To Date</h2>
                    <asp:Label ID="LblTodate" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Section</h2>
                    <asp:Label ID="LblSectionto" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;" >
                    <h2 style="color: #603504;">Description</h2>
                    <asp:Label ID="lblDesc" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;word-wrap: break-word;margin-left: 51%;float: left;overflow:auto;height: 100px;margin-top: -3%;"></asp:Label>
               
                      </div>
               
                </div>
           
                  <div style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;">

                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Number Of Leave Days</h2>
                    <asp:Label ID="lbltotdays" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Number Of Leaves-Leave Type</h2>
                    <asp:Label ID="lbllNoleavetypeleave" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;width: 178px;float: left;margin-left: 14%;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Total Number Of Leave</h2>
                    <asp:Label ID="TotalNooflv" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Last Leave Taken</h2>
                    <asp:Label ID="lbllastleave" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                        <div style="float:left;width:50%;margin-top: 2%;">
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
            </div>
            </div>        
            <div id="DivTravlDetails" style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;display:none">
                       <h2 style="color: #603504;">Travel Details</h2>   <br /><br /><br />
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Date Of Travel</h2>
                    <asp:Label ID="lbldateoftravl" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Sector Destination</h2>
                    <asp:Label ID="lbldestination" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Date Of Return</h2>
                    <asp:Label ID="lbldateofret" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Air Line Preferred</h2>
                    <asp:Label ID="lblairlinepref" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;overflow:hidden"></asp:Label>
                </div>
                   <asp:Label ID="Label1" class="form5" runat="server" Text="Family members accompanied if any" style ="font-family:Calibri;font-size:14px;width: 100%;float: left;"></asp:Label>
       
                <div style="float:left;width:50%;margin-top: 2%;">
  <div id="divreportDependent" class="table-responsive" runat="server">
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
            </div>
            </div>      
            
            
              <div id="DivTravlConDetails" style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;display:none">
                              <h2 style="color: #603504;">Contact Details During Leave </h2>
                  <br /><br /><br />    
                 <div class="eachform" style="width: 40%; float: left;margin-right:0%">
                    <h2 style="color: #603504;">Address </h2>

                     <asp:TextBox ID="lbladdr" TextMode="MultiLine" class="form1" runat="server" Enabled="false" style="width: 56%;height: 80px;margin-left: 3%;float:left;font-family: calibri;resize: none;"></asp:TextBox>

                    <%--<asp:Label ID="lbladdr" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;width: 178px;"></asp:Label>--%>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Telephone Number (Including Code)</h2>
                    <asp:Label ID="lblrelph" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;width: 157px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;margin-left: 0%">
                    <h2 style="color: #603504;">Local Contact Number(Qatar)</h2>
                    <asp:Label ID="lblloccontatc" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;width: 178px;float: right;text-align:left;margin-right: -4%;"></asp:Label>
                </div>
                   <div class="eachform" style="clear: both;width: 34%; float: left;margin-left: 6%">
                    <asp:CheckBox ID="chktiktneeded" runat="server" style="float:left"/>   
                          <h2 style="color: #603504;">Include Travel Tickets</h2>
                
                   </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Email address </h2>
                   
                    <asp:Label ID="lblemail" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;width: 157px;overflow:visible"></asp:Label>
                </div>
            </div>


                      <div id="divhApproval" runat="server"   style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292; ">
                           <asp:Label ID="lblRoAprove" class="form5" runat="server" style ="width: 100%;  font-size: 24px; font-weight: bold; color: #603504; font-family: Calibri; margin-bottom: 2%;float:left;margin-left:1%" Text="Reporting Officer*"></asp:Label>  
                          <asp:Label ID="lblDmAprove" class="form5" runat="server" style ="width: 100%;font-size: 24px; font-weight: bold; color: #603504; font-family: Calibri; margin-bottom: 2%;float:left;margin-left:1%" Text="Division Manager*"></asp:Label>  
                           <asp:Label ID="lblGmAprove" class="form5" runat="server" style ="width: 100%;font-size: 24px; font-weight: bold; color:#603504; font-family: Calibri; margin-bottom: 2%;float:left;margin-left:1%" Text="General Manager*"></asp:Label>  
                           <asp:Label ID="lblHrAprove" class="form5" runat="server" style ="width: 100%;font-size: 24px; font-weight: bold; color: #603504; font-family: Calibri; margin-bottom: 2%;float:left;margin-left:1%" Text="HR Department*"></asp:Label>  
                             
        
<%--EVM-0027 11-02-2019--%>
                <div  id="divApprovalPrevNote" runat="server" class="eachform" style="width: 48%; float: left;font-family:Calibri;">
                                       <asp:Label ID="lblPrvRo" class="form5" runat="server" style ="width: 40%;  font-size: 17px; color: #603504; font-family: Calibri; margin-bottom: 2%;float:left;" Text="Notes From Reporting Officer*"></asp:Label>  
                     <asp:TextBox ID="txtPvRO_Note" Visible="false" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 50%; text-transform: uppercase; margin-right: 2.3%; height: 40px; resize:none;font-family: calibri;" onblur="textCounter(cphMain_txthrnote,450)"  onkeydown="textCounter(cphMain_txthrnote,450)" onkeyup="textCounter(cphMain_txthrnote,450)" onkeypress="return isTag(event)"></asp:TextBox>
                                       <asp:Label Visible="false" ID="lblPrvDm" class="form5" runat="server" style ="width: 40%;  font-size: 17px; color:#603504; font-family: Calibri; margin-bottom: 2%;float:left;" Text="Notes From Division Manager*"></asp:Label>  
                     <asp:TextBox ID="txtPvDM_Note" Visible="false" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 50%; text-transform: uppercase; margin-right: 2.3%; height: 40px; resize:none;font-family: calibri;" onblur="textCounter(cphMain_txthrnote,450)"  onkeydown="textCounter(cphMain_txthrnote,450)" onkeyup="textCounter(cphMain_txthrnote,450)" onkeypress="return isTag(event)"></asp:TextBox>
                                       <asp:Label Visible="false" ID="lblPrvGm" class="form5" runat="server" style ="width: 40%;  font-size: 17px; color:#603504; font-family: Calibri; margin-bottom: 2%;float:left;" Text="Notes From General Manager*"></asp:Label>  
                      <asp:TextBox ID="txtprevNote"  class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 50%; text-transform: uppercase; margin-right: 2.3%; height: 40px; resize:none;font-family: calibri;" onblur="textCounter(cphMain_txthrnote,450)"  onkeydown="textCounter(cphMain_txthrnote,450)" onkeyup="textCounter(cphMain_txthrnote,450)" onkeypress="return isTag(event)"></asp:TextBox>

                    </div>
                                <div class="eachform" style="width: 48%; float: right;margin-left:1%;font-family:Calibri;">
                                       <asp:Label ID="lblRoNote" class="form5" runat="server" style ="width: 40%;  font-size: 17px; color: #603504; font-family: Calibri; margin-bottom: 2%;float:left;" Text="Notes From Reporting Officer*"></asp:Label>  
                                       <asp:Label ID="lblDmNote" class="form5" runat="server" style ="width: 40%;  font-size: 17px; color:#603504; font-family: Calibri; margin-bottom: 2%;float:left;" Text="Notes From Division Manager*"></asp:Label>  
                                       <asp:Label ID="lblGmNote" class="form5" runat="server" style ="width: 40%;  font-size: 17px; color:#603504; font-family: Calibri; margin-bottom: 2%;float:left;" Text="Notes From General Manager*"></asp:Label>  
                                       <asp:Label ID="lblHrNote" class="form5" runat="server" style ="width: 40%;  font-size: 17px; color:#603504; font-family: Calibri; margin-bottom: 2%;float:left;" Text="Notes From HR*"></asp:Label>  

                         
                     <asp:TextBox ID="txthrnote" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 50%; text-transform: uppercase; margin-right: 2.3%; height: 90px; resize:none;font-family: calibri;" onblur="textCounter(cphMain_txthrnote,450)"  onkeydown="textCounter(cphMain_txthrnote,450)" onkeyup="textCounter(cphMain_txthrnote,450)" onkeypress="return isTag(event)"></asp:TextBox>
                                     <p class="error" id="P1" style="display:none">Please Enter Valid Email Id</p>
                </div>
                       <%--   end--%>
            </div>
                   
                           
             </div>
                     <%-- <div style="float:left;width: 8%;padding: 5px;background: white;margin-left: 4%;margin-top: 5%;">
                    <asp:Button ID="Btnsave" runat="server" class="save" Text="Save" OnClientClick="return getselected();" OnClick="Btnsave_Click"/>
                    <asp:Button ID="Btnconfirm" runat="server" class="save" Text="Confirm"   OnClientClick="return validateNotify();" />
                    <asp:Button ID="Btncancl" runat="server" class="save" Text="Clear" OnClientClick="return validateNotify();"  />
                     <asp:Button ID="Btnclr" runat="server" class="save" Text="Cancel" OnClientClick="return validateNotify();"  />
                --%>        <asp:HiddenField ID="hiddenRsnid" runat="server" />
                          <asp:HiddenField ID="HiddenreqstId" runat="server" />
                               <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
                </div>

            <div style="float:left;width:100%;margin-top: 2%;">
                
                </div>
          
         


          
      <div class="eachform" style="width: 59%; margin-top: 3%; float: right">             
                       <asp:Button ID="btnAprroveReportngto" TabIndex="10" runat="server" class="cancel" Text="Reporting Officer Approve" onclientclick="return ConfirmMessageApprove();"   OnClick="btnAprroveReportngto_Click" />
        <asp:Button ID="btnAprroveDivMAnager" TabIndex="10" runat="server" class="cancel" Text="Division Manager Approve" onclientclick="return ConfirmMessageApprove()"  OnClick="btnAprroveDivMAnager_Click" />
        <asp:Button ID="btnAprroveHrApproval" TabIndex="10" runat="server" class="cancel" Text="HR Approve" onclientclick="return ConfirmMessageApprove();"  OnClick="btnAprroveHrApproval_Click" />
         <asp:Button ID="btnAprroveGmApproval" TabIndex="10" runat="server" class="cancel" Text="GM Approve" onclientclick="return ConfirmMessageApprove();"  OnClick="btnAprroveGmApproval_Click" />
       <asp:HiddenField ID="Hiddenenablecancl" runat="server" />
             <asp:HiddenField ID="HiddenHrApprove" runat="server" />
               <asp:HiddenField ID="HiddenGMApprove" runat="server" />
            <asp:HiddenField ID="HiddenDivApprove" runat="server" />
               <asp:HiddenField ID="HiddenReprtngApprove" runat="server" />
               <asp:HiddenField ID="HiddenLeaveID" runat="server" />
           <asp:HiddenField ID="HiddenUserId" runat="server" />
      <asp:HiddenField ID="Hiddenenabledit" runat="server" />
               <asp:HiddenField ID="HiddenRjct" runat="server" />
                    <%--<asp:Button ID="btnCnfrm" TabIndex="11" runat="server" style="margin-left: 19px;" class="cancel" Text="Confirm" OnClientClick="return Confirm();" OnClick="btnCnfrm_Click" />--%>
                    <asp:Button ID="btnReject" TabIndex="12" runat="server" style="margin-left: 19px;" class="cancel" OnClientClick="return ConfirmMessageReject();" Text="Reject" OnClick="btnReject_Click"   />
                    <asp:Button ID="btnClose" TabIndex="13" runat="server" style="margin-left: 19px;" OnClick="btnClose_Click" OnClientClick="return ConfirmMessageClose()" class="cancel" Text="Close"/>
                   <asp:Button ID="btncancel" TabIndex="13" runat="server" style="margin-left: 19px;" OnClientClick="return ConfirmMessage()" class="cancel" Text="Cancel"/>
                
          
             <asp:HiddenField ID="hiddenRowCount" runat="server" />
                    <asp:HiddenField ID="Hiddenchecklist" runat="server" />
          
                </div>
        </div>
  

    <script>
        $p('.drop1').css({ opacity: 1.0, visibility: "visible" }).animate({ opacity: 0 }, 200);
    </script>
    <style>
        .cont_rght {
            width: 97%;
        }
    .save {
    width:100%

    }
    </style>
    <script>
        function getselected() {
            var tempdata = document.getElementById("<%=Hiddenchecklist.ClientID%>").value;
           //alert(tempdata+"tempdat");
           var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           var strAmntList = "";
           for (i = 0; i < RowCount; i++) {
               // alert("dddddd");

               if (document.getElementById('cblcandidatelist' + i).checked) {

                   //   alert(document.getElementById('tdcandiateid').innerHTML);
                   strAmntList = strAmntList + document.getElementById('tdcandiateid' + i).innerHTML + ',';

               }
           }
           document.getElementById("<%=Hiddenchecklist.ClientID%>").value = strAmntList;
           //   alert(document.getElementById("<%=Hiddenchecklist.ClientID%>").value);
           // alert(strAmntList + "str");
           if (tempdata == strAmntList) {
               if (confirm("Please select a candidate to confirm")) {
                   return false;
               }
               else {
                   return false;
               }


           }
           else if (strAmntList != "") {
               // alert(strAmntList);
               return true;
           }
           else {
               if (confirm("Please select a candidate to confirm")) {
                   return false;
               }
               else {
                   return false;
               }

           }
       }
    </script>
       <script>
           var confirmbox = 0;
           function ConfirmMessage() {
               if (confirmbox > 0) {
                   if (confirm("Are you sure you want to leave this page?")) {
                       window.location.href = "gen_Leave_Approval_List.aspx";
                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Leave_Approval_List.aspx";
                   return false;
               }
           }
           function Confirm() {
               if (getselected()) {

                   if (confirm("Are you sure you want to confirm this page?")) {
                       return true;
                   }
                   else {
                       return false;
                   }
               }
           }
              
              
           
       </script>
    <script>
        function SuccessApproved() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request  Approved successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function SuccessRejected() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request  Rejected successfully";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function SuccessClose() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leave Request  Closed successfully";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
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
    </script>
     <style>
     .form5 {
    width: 232px;
    height: 28px;
    padding: 0px 8px;
   
    float: right;
    color: #000;
    font-size: 13px;
}

 </style>
      <script>
          function ShowTravalNeededDiv() {
              document.getElementById('DivTravlDetails').style.display = "";
            document.getElementById('DivTravlConDetails').style.display = "";
          }
          function RejectReason() {
              document.getElementById("<%=hiddenRsnid.ClientID%>").value = document.getElementById("<%=txtCnclReason.ClientID%>").value ;
              // alert(document.getElementById("<%=hiddenRsnid.ClientID%>").value);
              document.getElementById("MymodalCancelView").style.display = "none";
              document.getElementById("freezelayer").style.display = "none";

              return true;
          }
          //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
          function textCounter(field, maxlimit) {
           
              removeTag();
              //alert(field.value.length);
              if (field.value.length > maxlimit) {
                  field.value = field.value.substring(0, maxlimit);
              } else {

              }

          }
          function removeTag() {
              //alert();
              var NameWithoutReplace = document.getElementById("<%=txthrnote.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              //0024
              document.getElementById("<%=txthrnote.ClientID%>").value = replaceText2;
          }
          </script>
   

    
                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Leave Approval</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b; ">Reject Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return RejectReason();" OnClick="btnRsnSave_Click"  style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" />
                    
                        <asp:Button ID="btnRsnCncl" class="save" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>
 
</asp:Content>

