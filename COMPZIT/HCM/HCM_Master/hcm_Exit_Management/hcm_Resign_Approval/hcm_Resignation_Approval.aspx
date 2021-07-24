<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Resignation_Approval.aspx.cs" Inherits="HCM_HCM_Master_gen_Candidate_ShortList_gen_Candidate_ShortList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
         

    </style>
     <script src="/JavaScript/jquery-1.8.3.min.js"></script>
        
   
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

      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

         
   </script>
  <script>

      var confirmbox = 0;

      function IncrmntConfrmCounter() {

          confirmbox++;
      }
      function ConfirmMessage() {
          if (confirmbox > 0) {
              if (confirm("Are you sure you want to leave this page?")) {
                  window.location.href = "hcm_Resignation_Approval_List.apsx";
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
                  window.location.href = "hcm_Resignation_Approval_List.apsx";
                  return true;
              }
              else {
                  return false;
              }
          }
  
      function ConfirmMessageReject() {

          if (confirm("Are you sure you want to Reject this Request?")) {
              return OpenCancelView();
        
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
         // alert(document.getElementById("<%=txtreason.ClientID%>").value);
          if (document.getElementById("<%=txtreason.ClientID%>").value =="") {

         
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              document.getElementById("<%=txtreason.ClientID%>").style.borderColor = "Red";
              document.getElementById("<%=txtreason.ClientID%>").focus();
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
      function ConfirmMessagehRApprove() {

          if (confirm("Are you sure you want to Approve this Request?")) {
             // validate();
              return validate();
          }
          else {
              return false;
          }
      }

      function validate()
      
      {
          document.getElementById("<%=txtreason.ClientID%>").style.borderColor = "";
          var reason=document.getElementById("<%=txtreason.ClientID%>").value;
                   document.getElementById("<%=txtlvDate.ClientID%>").style.borderColor = "";
         var ret="true";
          var frmdate = document.getElementById("<%=txtlvDate.ClientID%>").value;
              //alert(frmdate);
          var reason = document.getElementById("<%=txtreason.ClientID%>").value;
       var today = document.getElementById("<%=HiddenToday.ClientID%>").value;
        var dateofrqst = document.getElementById("<%=txtlvDate.ClientID%>").value.trim();
              var arrDatePickerDate1 = dateofrqst.split("-");
              dateofrqst = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
              var arrDatePickerDate1 = today.split("-");
              today = new Date(arrDatePickerDate1[2], arrDatePickerDate1[1] - 1, arrDatePickerDate1[0]);
              
              if(reason=="")
              {
                  document.getElementById("<%=txtreason.ClientID%>").style.borderColor = "Red";

                  document.getElementById("<%=txtreason.ClientID%>").focus();
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";

                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              ret = false;

              }
          
          if (frmdate == "") { //3emp17
       
              document.getElementById("<%=txtlvDate.ClientID%>").style.borderColor = "Red";

              document.getElementById("<%=txtlvDate.ClientID%>").focus();
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";

              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
              ret = false;
          }
          else {
                   if (dateofrqst <= today) { //3emp17
       
              document.getElementById("<%=txtlvDate.ClientID%>").style.borderColor = "Red";

              document.getElementById("<%=txtlvDate.ClientID%>").focus();
                   document.getElementById('divMessageArea').style.display = "";
                   document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";

              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Leaving date should be greater than current date";
              ret = false;
          }

          }

             return ret;

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
                "pageLength": 25,
              
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
                <asp:Label ID="lblEntry" runat="server">Resignation Approval</asp:Label>
            </div>

            <div style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #f3f3f3">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee</h2>
                    <asp:Label ID="lblEmpname" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesig" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDep" class="form5"  runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Division</h2>
                    <asp:Label ID="lblDiv" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div><div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Pay grade</h2>
                    <asp:Label ID="LblPaygrd" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                
               
            </div>        
         
            
            
       
                    <asp:HiddenField ID="hiddenRsnid" runat="server" />
                          <asp:HiddenField ID="HiddenreqstId" runat="server" />
                               <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
                </div>

                    <div style="float: left; width: 98.3%;padding: 10px;margin-top: 2%;border: 1px solid #929292;">
   <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Joining Date</h2>
                    <asp:Label ID="LblJoindte" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;float: left;margin-left: 29%;"></asp:Label>
           
             </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Notice Period</h2>
                    <asp:Label ID="lblNotcprd" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;font-family:Calibri;font-size:14px;float: left;/*! float: left; */margin-left: 14%;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Preffered Leaving Date</h2>
                    <asp:Label ID="lbllPreflvedte" class="form5" runat="server" style ="font-family:Calibri;font-size:14px;width: 178px;float:left;margin-left:16%"></asp:Label>
                </div>
                         <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;"> Leaving Date*</h2>
                              <div id="div1" class="input-append date" style="float:right;margin-right:17%;width: 49%;">

                 
                   
                        <asp:TextBox ID="txtlvDate" class="form1" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Height="30px" Width="71%" Style="height:30px;width:71.6%;margin-top: 0%;float:left;margin-left: -2.3%;"></asp:TextBox>

                        <input type="image" runat="server" id="Image1" class="add-on" src="/Images/Icons/CalandarIcon.png" style=" height:22px; width:22px;pointer-events:none" />
   <link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
                               <link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
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
                            $noC('#div1').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                startDate: new Date(),
                            });

                        </script>




                        <p style="visibility: hidden">Please enter</p>
                       </div>
              

            </div>


                         <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Reason from employee</h2>
                             <asp:TextBox ID="txtEmpReason" TextMode="MultiLine" runat="server"  class="form1" MaxLength="95" Style="width: 50%;  height: 80px; resize:none;font-family:Calibri" onblur="RemoveTag(cphMain_txtEmpReason)" onkeydown="textCounter(cphMain_txtEmpReason,95)" onkeyup="textCounter(cphMain_txtEmpReason,95)"></asp:TextBox>
                </div>
                        
                      </div>

        
            <div id="divComment" runat="server"  style="float: left; width: 98.3%;padding: 10px;margin-top: 2%;border: 1px solid #929292;">
                 <div id="divReason" runat="server" class="eachform" style="width: 47%; float: left;">
             
                   <asp:Label ID="lblRoReason" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From Reporting Officer*"></asp:Label>
                                <asp:Label ID="lblDmReason" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From Division Manager*"></asp:Label>
                                <asp:Label ID="lblHrReason" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From HR*"></asp:Label>
                                <asp:Label ID="lblGmReason" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From General Manager*"></asp:Label>

                              <asp:TextBox ID="txtreason" TextMode="MultiLine" runat="server" TabIndex="2" class="form1" MaxLength="95" Style="width:50%;  height: 80px; resize:none;font-family:Calibri;float:right;" onkeypress="return  isTagEnter(event);" onblur="return textCounter(cphMain_txtreason,450)" onkeydown=" return textCounter(cphMain_txtreason,450)"></asp:TextBox>
                </div>
             <div id="divPrvRsn" runat="server" class="eachform" style="width: 47%; float: right;">
                                <asp:Label ID="lblRoPrvRsn" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From Reporting Officer*"></asp:Label>
                               <asp:Label ID="lblDmPrvRsn" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From Division Manager*"></asp:Label>
                                <asp:Label ID="lblHrPrvRsn" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From HR*"></asp:Label>
                                <asp:Label ID="lblGmPrvRsn" class="form5" runat="server" style ="font-family:Calibri;font-size:17px;color: #603504;float: left;width: 26%; " Text="Notes From General Manager*"></asp:Label>

                             <asp:TextBox ID="txtprvRsn" TextMode="MultiLine" runat="server" class="form1" MaxLength="95" Style="width:50%;  height: 80px; resize:none;font-family:Calibri;float:right;" onblur="RemoveTag(cphMain_txtreason)" onkeydown="textCounter(cphMain_txtreason,450)" onkeyup="textCounter(cphMain_txtreason,450)" onkeypress="return isTag(event)"></asp:TextBox>
                </div>
               
             </div>
                        
                </div>
          
         


          
      <div class="eachform" style="width: 59%; margin-top: 3%; float: right">             
                       <asp:Button ID="btnAprroveReportngto" TabIndex="10" runat="server" class="cancel" Text="Reporting Officer Approve" onclientclick="return ConfirmMessageApprove();"   OnClick="btnAprroveReportngto_Click" />
        <asp:Button ID="btnAprroveDivMAnager" TabIndex="10" runat="server" class="cancel" Text="Division Manager Approve" onclientclick="return ConfirmMessageApprove()"  OnClick="btnAprroveDivMAnager_Click" />
        <asp:Button ID="btnAprroveHrApproval" TabIndex="10" runat="server" class="cancel" Text="Hr Approve" onclientclick="return ConfirmMessagehRApprove();"  OnClick="btnAprroveHrApproval_Click"  />
         <asp:Button ID="btnAprroveGmApproval" TabIndex="10" runat="server" class="cancel" Text="GM Approve" onclientclick="return ConfirmMessageApprove();"  OnClick="btnAprroveGmApproval_Click" />
    
             <asp:HiddenField ID="Hiddenenablecancl" runat="server" />
                <asp:HiddenField ID="HiddenToday" runat="server" />
            <asp:HiddenField ID="HiddenApprovedbyHr" runat="server" />
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
        $('.drop1').css({ opacity: 1.0, visibility: "visible" }).animate({ opacity: 0 }, 200);
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
                       window.location.href = "hcm_Resignation_Approval_List.aspx";
                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "hcm_Resignation_Approval_List.aspx";
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
              var ret = true;
                  var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
       
              document.getElementById("<%=hiddenRsnid.ClientID%>").value = document.getElementById("<%=txtCnclReason.ClientID%>").value ;
              // alert(document.getElementById("<%=hiddenRsnid.ClientID%>").value);
            //  document.getElementById("MymodalCancelView").style.display = "none";
             // document.getElementById("freezelayer").style.display = "none";
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
                ret= false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
               
                if (Reason.length < "10") {
                    document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    ret= false;
                }
            }
              return ret;
          }
          //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
          function textCounter(field, maxlimit) {   // emp0025
              RemoveTag();
              if (field.value.length > maxlimit) {
                  field.value = field.value.substring(0, maxlimit);
              } else {

              }

          }
          function isTagEnter(evt) {    //emp0025

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
   

    
                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Resignation Approval</h3>
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
 <script>
     function enableimg() {
     
         document.getElementById("cphMain_Image1").style.pointerEvents = "";


     }


     function RemoveTag(field) {

         //alert();
         var NameWithoutReplace = document.getElementById("<%=txtreason.ClientID%>").value;
          var replaceText1 = NameWithoutReplace.replace(/</g, "");
          var replaceText2 = replaceText1.replace(/>/g, "");
          document.getElementById("<%=txtreason.ClientID%>").value = replaceText2;


         
     }

          function isTag(evt) {

         evt = (evt) ? evt : window.event;
         var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
         if (keyCodes == 13) {
             return false;
         }
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         var ret = true;
         if (charCode == 60 || charCode == 62) {
             ret = false;
         }
         return ret;
     }
 </script>
    <style>

        .open > .dropdown-menu {
        
        display:none;
        }
    </style>
</asp:Content>

