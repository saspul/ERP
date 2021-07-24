<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Requirement_Allocation.aspx.cs" Inherits="HCM_HCM_Master_gen_Requirement_Allocation_gen_Requirement_Allocationaspx" %>

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
            width:92.5%;
            margin-left:1%;
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
         #divErrorMV {
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
     input[type="checkbox"] {
         margin-left:31%;
     }
     </style>
     <%--  for giving pagination to the html table--%>
    <script src="../../../JavaScript/JavaScriptPagination1.js"></script>
    <script src="../../../JavaScript/JavaScriptPagination2.js"></script>
    <link href="../../../css/StyleSheetPagination.css" rel="stylesheet" />
    <script>
        var $p= jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });


    </script>

    <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
      <script type="text/javascript">
          var $noCon = jQuery.noConflict();
          $noCon(window).load(function () {
              

              document.getElementById("<%=HiddenFieldReqrmntIds.ClientID%>").value = "";
              document.getElementById("<%=HiddenFieldReAlctnIds.ClientID%>").value = "";

              if (document.getElementById("<%=hiddenAllocateReallocate.ClientID%>").value == "1") {
                  document.getElementById("divReAllocateAll").style.display = "";
                  document.getElementById("divAllocateAll").style.display = "none";
              }
              else if (document.getElementById("<%=hiddenAllocateReallocate.ClientID%>").value == "0") {
                  document.getElementById("divReAllocateAll").style.display = "none";
                  document.getElementById("divAllocateAll").style.display = "";
              }

              document.getElementById("freezelayer").style.display = "none";
              document.getElementById('divAlocate').style.display = "none";
              var CancelPrimaryId = document.getElementById("<%=hiddenRsnid.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });


          </script>
      <script type="text/javascript">
          var $Mo = jQuery.noConflict();

          function OpenCancelView() {


              $p('#ReportTable').DataTable({
            
                  "bPaginate": false,
                  "bDestroy": true,
              });
              var Alcte = false;
              var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;

              for (var i = 0; i < RowCount; i++) {
                 

                  var RqmntID = document.getElementById("ReqrmntId" + i).innerHTML;

                  //Allocation
                  if (document.getElementById("cbx" + i).checked == true && document.getElementById("cbx" + i).disabled == false) {
                               
                      Alcte = true;

                      var RqrmntIds = document.getElementById("<%=HiddenFieldReqrmntIds.ClientID%>").value;
                      if (RqrmntIds == '') {
                          document.getElementById("<%=HiddenFieldReqrmntIds.ClientID%>").value = RqmntID;

                    }
                    else {

                          document.getElementById("<%=HiddenFieldReqrmntIds.ClientID%>").value = document.getElementById("<%=HiddenFieldReqrmntIds.ClientID%>").value + ',' + RqmntID;
                    }
                  }


                  //Re-Allocation
                  if (document.getElementById("cbxRe" + i).checked == true) {
                      Alcte = true;
                      var RqrmntIds = document.getElementById("<%=HiddenFieldReAlctnIds.ClientID%>").value;
                      if (RqrmntIds == '') {
                          document.getElementById("<%=HiddenFieldReAlctnIds.ClientID%>").value = RqmntID;

                      }
                      else {

                          document.getElementById("<%=HiddenFieldReAlctnIds.ClientID%>").value = document.getElementById("<%=HiddenFieldReAlctnIds.ClientID%>").value + ',' + RqmntID;
                      }

                  }




              }

              $p('#ReportTable').DataTable({
                  "pagingType": "full_numbers",
                  "bSort": true,
                  "pageLength": 25,
                  "bDestroy": true,
              });
              

              if (Alcte == true) {
                  if (document.getElementById("<%=HiddenFieldHRallocation.ClientID%>").value == "true") {
                      document.getElementById("divAlocate").style.display = "block";
                      document.getElementById("freezelayer").style.display = "";
                      document.getElementById("<%=ddlEmployee.ClientID%>").focus();
                      $noCon("#divddlEmp input.ui-autocomplete-input").focus();
                      $noCon("#divddlEmp input.ui-autocomplete-input").select();
                      return false;
                  }

              }
              else {
                  alert('No requirement selected.');
                  return false;
              }

          }
          function CloseCancelView() {
              if (confirm("Do you want to close this window?")) {
                  document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById('imgMessageArea').src = "";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                  document.getElementById("divAlocate").style.display = "none";
                  document.getElementById("freezelayer").style.display = "none";
                  document.getElementById("<%=hiddenRsnid.ClientID%>").value = "";
                  document.getElementById("<%=HiddenFieldReqrmntIds.ClientID%>").value = "";
                  document.getElementById("<%=HiddenFieldReAlctnIds.ClientID%>").value = "";
              }
              return false;
          }

          function changeAll() {
              var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
              
              if (document.getElementById("cphMain_cbxSlctAll").checked == true) {

                  $p('#ReportTable').DataTable({

                      "bPaginate": false,
                      "bDestroy": true,
                  });
                  for (var i = 0; i < RowCount; i++) {
                      if (document.getElementById("cbx" + i).disabled == false) {
                          document.getElementById("cbx" + i).checked = true;
                      }

                  }
                  $p('#ReportTable').DataTable({
                      "pagingType": "full_numbers",
                      "bSort": true,
                      "pageLength": 25,
                      "bDestroy": true,
                  });



              }
              else {
                  $p('#ReportTable').DataTable({

                      "bPaginate": false,
                      "bDestroy": true,
                  });
                  for (var i = 0; i < RowCount; i++) {
                      if (document.getElementById("cbx" + i).disabled == false) {
                          document.getElementById("cbx" + i).checked = false;
                      }

                  }
                  $p('#ReportTable').DataTable({
                      "pagingType": "full_numbers",
                      "bSort": true,
                      "pageLength": 25,
                      "bDestroy": true,
                  });

              }


          }

          function changeAllReAllocate() {
              var RowCount = document.getElementById("<%=HiddenFieldCbxCount.ClientID%>").value;
              $p('#ReportTable').DataTable({

                  "bPaginate": false,
                  "bDestroy": true,
              });
              if (document.getElementById("cphMain_cbxSlctAllRelloct").checked == true) {


                  for (var i = 0; i < RowCount; i++) {
                      if (document.getElementById("cbxRe" + i).disabled == false) {
                          document.getElementById("cbxRe" + i).checked = true;
                      }

                  }



              }
              else {

                  for (var i = 0; i < RowCount; i++) {
                      if (document.getElementById("cbxRe" + i).disabled == false) {
                          document.getElementById("cbxRe" + i).checked = false;
                      }

                  }

              }

              $p('#ReportTable').DataTable({
                  "pagingType": "full_numbers",
                  "bSort": true,
                  "pageLength": 25,
                  "bDestroy": true,
              });
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
          function PrintAlert(href) {

              if (confirm("Do you want to Take a Print?")) {
                  window.location = href;
                  //return false;
              }
              else {
                  return false;
              }
          }
    </script>
    <script>
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
        }
       
        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want to cancel all changes in this page?")) {
                    window.location.href = "gen_Requirement_Allocation.aspx";
                    return false;
                }
                else {
                    return false;
                }
            }
           
        }
        function ChangeCbx() {
            IncrmntConfrmCounter();
        }
        function isEnter(evt) {

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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Requirements allocated Successfully.";
        }
      

        function getdetails(href) {
            window.location = href;
            return false;
        }
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, Cancellation Denied. This Entry is Already Selected Somewhere Or It is a Confirmed Entry!");
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

            $au(function () {
                $au('#cphMain_ddlEmployee').selectToAutocomplete1Letter();
            });





    </script>


    <style>
        #cphMain_divReport {
            float: left;
            width: 96%;
        }

      

        #TableRprtRow .tdT {
            line-height: 100%;
        }


        .cont_rght {
            width: 98%;
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


        function SearchValidation() {
            ret = true;
            document.getElementById('divMessageArea').style.display = "none";
            document.getElementById('imgMessageArea').src = "";

            document.getElementById("<%=ddlProject.ClientID%>").style.borderColor = "";

            var ddlDivision = document.getElementById("<%=ddlDivision.ClientID%>").value;
            if (ddlDivision == "--SELECT DIVISION--") {
                //document.getElementById('divMessageArea').style.display = "";
                //document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                //document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                //document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                ddlDivision = 0;
            }
           

            var ddlDep = document.getElementById("<%=ddlDep.ClientID%>").value;
            if (ddlDep == "--SELECT DEPARTMENT--") {
                ddlDep = 0;

            }
            var ddlPrjct = document.getElementById("<%=ddlProject.ClientID%>").value;
            if (ddlPrjct == "--SELECT PROJECT--") {
               
                ddlPrjct = 0;
            }
           

            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = ddlDivision + ',' + ddlDep + ',' + ddlPrjct;
            }


            return ret;

        }



        function ValidateEmployee() {
          
            document.getElementById('divErrorMV').style.visibility = "hidden";
            document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "";
            if (document.getElementById("<%=ddlEmployee.ClientID%>").value == "--SELECT EMPLOYEE--") {
                document.getElementById('divErrorMV').style.visibility = "visible";
                 document.getElementById("<%=lblErrorMV.ClientID%>").innerHTML = "Please select an employee";
                document.getElementById("<%=ddlEmployee.ClientID%>").style.borderColor = "Red";
                return false;
            }
           
        }




        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
       <asp:HiddenField ID="hiddenDfltCurrencyMstrId" runat="server" />
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenRsnid" runat="server" />
    <%--<asp:HiddenField ID="hiddenDsgnTypId" runat="server" />
    <asp:HiddenField ID="hiddenDsgnControlId" runat="server" />--%>
     <asp:HiddenField ID="hiddenDecimalCount" runat="server" />
    

     <asp:HiddenField ID="HiddenFieldCbxCount" runat="server" />
     <asp:HiddenField ID="HiddenFieldReqrmntIds" runat="server" />
     <asp:HiddenField ID="HiddenFieldHRallocation" runat="server" />
     <asp:HiddenField ID="HiddenFieldSelfAllocation" runat="server" />
     <asp:HiddenField ID="HiddenFieldEditAllocation" runat="server" />
     <asp:HiddenField ID="HiddenFieldReAlctnIds" runat="server" />
         <asp:HiddenField ID="hiddenAllocateReallocate" runat="server" />


    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
   <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

    <div class="cont_rght">


        <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri;">
            <img src="/Images/BigIcons/requirement allocation.png" style="vertical-align: middle;" />
     Requirement Allocation
        </div >
        <div style="border:.5px solid;border-color: #9ba48b;background-color: #f3f3f3;width: 96%;margin-top:0.5%;height:10%;">

            <div style="width:100%;float:left;margin-top:14px">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>

            <div class="eachform" style="width: 30%;margin-top:0.5%;margin-left:3%;float: left;">
            <h2 style="margin-top:1%;"> Department</h2>

            <asp:DropDownList ID="ddlDep" class="form1"   style="height:25px;width:160px;height:25px;width:65%;float:left; margin-left: 8%;" runat="server" onchange="IncrmntConfrmCounter()" AutoPostBack="true" OnSelectedIndexChanged="ddlDep_SelectedIndexChanged">      </asp:DropDownList>
             
        </div>
                        <div class="eachform" style="width: 27%; padding-top:0.5%;float: left;margin-left: 3%;">

                <h2 style="margin-top: 0.5%;margin-left: 0%;">Division</h2>

                <asp:DropDownList ID="ddlDivision" Height="25px"   class="form1" runat="server" Style="height:25px;width:60%;float: left;margin-left: 6%;" onchange="IncrmntConfrmCounter()" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
             
      
                </asp:DropDownList>


            </div> 
                  
                  <div class="eachform" style="width: 30%; padding-top:0.5% ;float: left;">
            <h2 style="margin-top: 0.5%;margin-left: 0%;"> Project</h2>

            <asp:DropDownList ID="ddlProject" class="form1"   style="height:25px;width:60%;float: left;margin-left: 6%;" runat="server" onchange="IncrmntConfrmCounter()">      </asp:DropDownList>
             
        </div> 
           
          <div class="eachform" style="padding-top:0.5%;float: left;">
              <div style="width: 28%; float: left; padding: 5px; border: 1px solid #c3c3c3;margin-left: 3%;">
                  <h2 style="margin-top: 0.5%;margin-left: 0%;"> Allocation*</h2>
                    <div style="float: right; margin-right: 0%; width: 68%;">
                         <asp:RadioButton ID="radioNotAllocated" Text="Not allocated" runat="server" Checked="true" GroupName="RadioSkCer" Style="float: left; font-family: calibri; margin-left: 6%;" OnKeypress="return DisableEnter(event)" />
                        <asp:RadioButton ID="radioAllocated" Text="Allocated" runat="server" GroupName="RadioSkCer" Style="float: left; font-family: calibri" OnKeypress="return DisableEnter(event)" />
                    </div>
                </div>
           </div>
                           
               
                      </ContentTemplate>
   </asp:UpdatePanel>
               
   
                </div>
             <div style="width:10%;float:right;margin-top:-8%;margin-left: 0%;">
        
                <div class="eachform" style="width:95%;float:right;margin-right: 18%;">
                <asp:Button ID="btnSearch" style="cursor:pointer;margin-top: -0.4%;width:100%;"  runat="server" class="searchlist_btn_lft" Text="Search" OnClientClick="return SearchValidation();" OnClick="btnSearch_Click" />
                     </div>
                 </div>
            <br style="clear: both" />
            </div>
        <br />

      <div id="divAllocateAll" class="eachform" style="width:21%; margin-bottom: 1.2%;">               
                <div class="subform" style="width:215px;float:left;">
                    <asp:CheckBox ID="cbxSlctAll" Text="" runat="server" Checked="false" class="form2" onkeydown="return isEnter(event)" onchange="return changeAll()"/>
                    <h3 style="margin-top:1%;">Allocate All</h3>
                  </div>
      </div>

              <div id="divReAllocateAll" class="eachform" style="width:21%; margin-bottom: 1.2%;">               
                <div class="subform" style="width:215px;float:left;">
                    <asp:CheckBox ID="cbxSlctAllRelloct" Text="" runat="server" Checked="false" class="form2" onkeydown="return isEnter(event)" onchange="return changeAllReAllocate()"/>
                    <h3 style="margin-top:1%;">Reallocate All</h3>
                  </div>
      </div>

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


          <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 70%; margin-left: 38%">      
                    <asp:Button ID="btnAllocate"  runat="server" style="margin-left:10%;" class="save" Text="Allocate" OnClientClick="return OpenCancelView();" OnClick="btnAllocation_Click"  />
                    <asp:Button ID="btnCancel"  runat="server" style="width:12%;" class="cancel" OnClientClick="return AlertClearAll();" Text="Cancel" />      
               </div>
                </div>


         <%--------------------------------For Allocation window--------------------------%>

         <div id="divAlocate" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Requirement Allocation</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorMV" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorMV" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>
                        <div id="divddlEmp" class="eachform" style="width: 70%;margin-top:0.5%;margin-left:10%;float: left;">


                <h2 style="margin-top:1%;">Employee*</h2>

                <asp:DropDownList ID="ddlEmployee" Height="25px"   class="form1" runat="server" Style="height:25px;width:160px;height:25px;width:60%;float:left; margin-left: 14%;">
             
      
                </asp:DropDownList>


            </div> 
                       
                         <asp:Button ID="btnOkMV" class="save" runat="server" Text="Ok" OnClientClick="return ValidateEmployee();" style="width: 90px; float:left;margin-left:34%;margin-top: 6%;" OnClick="btnAllocation_Click" />
                        <asp:Button ID="btnCnclMV" class="save" style="width: 90px; float:right;margin-right:32%;margin-top: 6%;" onclientclick="return CloseCancelView();" runat="server" Text="Cancel" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 15%;">
                    </div>


                </div>
            </div>   
       





                                 <%--------------------------------View for error Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Job Description</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                                <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 24%;color: #909c7b; ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                         <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" style="width: 90px; float:left;margin-left:39%;margin-top: 3%;" OnClick="btnRsnSave_Click"/>
                    
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
            display: table-cell;
        }
    </style>



</asp:Content>


