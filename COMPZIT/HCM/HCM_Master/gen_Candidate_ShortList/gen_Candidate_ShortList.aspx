<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Candidate_ShortList.aspx.cs" Inherits="HCM_HCM_Master_gen_Candidate_ShortList_gen_Candidate_ShortList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

               <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": false,
                "pageLength": 25
            });
        });
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
    
      
      function selectAll() {

          var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
          var strAmntList = "";
          if (document.getElementById('cbxSelectAll').checked == true) {
              for (i = 0; i < RowCount; i++) {

                  document.getElementById('cblcandidatelist' + i).checked = true;

              }
          }
          else {
              for (i = 0; i < RowCount; i++) {

                  document.getElementById('cblcandidatelist' + i).checked = false;

              }
          }
      }


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

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 7%; top: 39%; height: 26.5px;">
        </div>

        <div style="width: 98.5%; border: 1px solid #8e8f8e; padding: 10px; background-color: whitesmoke;float:left">
            <div id="divReportCaption" style="width:100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;float:left">
                <asp:Label ID="lblEntry" runat="server">Candidate ShortListing</asp:Label>
            </div>

            <div style="float: left; width: 98%;padding: 10px;margin-top: 2%;border: 1px solid #929292;background-color: #c9c9c9;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Ref#</h2>
                    <asp:Label ID="lblRefNum" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Date Of Request</h2>
                    <asp:Label ID="lblDateOfReq" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Number</h2>
                    <asp:Label ID="lblNumber" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesign" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                 <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDeprtmnt" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Project</h2>
                    <asp:Label ID="lblPrjct" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Experience</h2>
                    <asp:Label ID="lblExprnce" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">PayGrade</h2>
                    <asp:Label ID="lblPaygrd" class="form1" runat="server" style ="font-family:Calibri;font-size:14px;"></asp:Label>
                </div>
            </div>
                     <%-- <div style="float:left;width: 8%;padding: 5px;background: white;margin-left: 4%;margin-top: 5%;">
                    <asp:Button ID="Btnsave" runat="server" class="save" Text="Save" OnClientClick="return getselected();" OnClick="Btnsave_Click"/>
                    <asp:Button ID="Btnconfirm" runat="server" class="save" Text="Confirm"   OnClientClick="return validateNotify();" />
                    <asp:Button ID="Btncancl" runat="server" class="save" Text="Clear" OnClientClick="return validateNotify();"  />
                     <asp:Button ID="Btnclr" runat="server" class="save" Text="Cancel" OnClientClick="return validateNotify();"  />
                --%>
                          <asp:HiddenField ID="HiddenreqstId" runat="server" />
                               <asp:HiddenField ID="HiddenShortlistMasterid" runat="server" />
                </div>

            <div style="float:left;width:100%;margin-top: 2%;">
                
                </div>
          
         


            <div style="float:left;width:100%;margin-top: 2%;">
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
      <div class="eachform" style="width: 59%; margin-top: 3%; float: right">             
                       <asp:Button ID="btnAdd" TabIndex="10" runat="server" class="cancel" Text="Save"   OnClientClick="return getselected();" OnClick="btnAdd_Click" />
       
                    <asp:Button ID="btnCnfrm" TabIndex="11" runat="server" style="margin-left: 19px;" class="cancel" Text="Confirm" OnClientClick="return Confirm();" OnClick="btnCnfrm_Click" />
                    <asp:Button ID="btnCancel" TabIndex="12" runat="server" style="margin-left: 19px;" class="cancel" OnClientClick="return ConfirmMessage();" Text="Cancel"   />
                    <asp:Button ID="btnClear" TabIndex="13" runat="server" style="margin-left: 19px;" OnClick="btnClear_Click" OnClientClick="return AlertClearAll()" class="cancel" Text="Clear"/>
                   <asp:HiddenField ID="hiddenRowCount" runat="server" />
                    <asp:HiddenField ID="Hiddenchecklist" runat="server" />
          
                </div>
        </div>
  

    <script>
        var $s = jQuery.noConflict();
        $s('.drop1').css({ opacity: 1.0, visibility: "visible" }).animate({ opacity: 0 }, 200);
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
           
            var tempdata = "";//document.getElementById("<%=Hiddenchecklist.ClientID%>").value;
           //alert(tempdata+"tempdat");
           var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
           var strAmntList = "";
           for (i = 0; i < RowCount; i++) {
               // alert("dddddd");

               if (document.getElementById('cblcandidatelist' + i).checked && document.getElementById('cblcandidatelist' + i).disabled==false) {

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
                       window.location.href = "gen_Candidate_ShortList_List.aspx";
                       return false;
                   }
                   else {
                       return false;
                   }
               }
               else {
                   window.location.href = "gen_Candidate_ShortList_List.aspx";
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
               else {
                   return false;
               }
           }
              
              
           
       </script>
    <script>
        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate shortlist data inserted successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate shortlist data updated successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function SuccessConfirmed() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Candidate shortlist data confirmed successfully.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
    </script>






</asp:Content>

