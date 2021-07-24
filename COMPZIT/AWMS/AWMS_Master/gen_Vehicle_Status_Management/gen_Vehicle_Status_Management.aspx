<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Status_Management.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Status_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

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
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();//evm-20


        $au(function () {
            $au('#cphMain_ddlProject_Employee').selectToAutocomplete1Letter();
        });




        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlVehicleNumber').selectToAutocomplete1Letter();

                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);





                    </script>
     <style>
        .imgDelete {
            visibility:visible;
        }
    </style>
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
            .modal-bodyCancelView1 {
              height: 391px;
             padding: 4% 4% 0% 0%;
         }
         .modal-footerCancelView {
             padding: 2% 1%;
           background-color: #91a172;
             color: white;
         }
           .modalCancelView1 {
             display: none; /* Hidden by default */
             position: fixed; /* Stay in place */
             z-index: 30; /* Sit on top */
             padding-top: 0%; /* Location of the box */
             left: 23%;
             top: 10%;
             width: 50%; /* Full width */
             /*height: 58%;*/ /* Full height */
             /*overflow: auto;*/ /* Enable scroll if needed */
             background-color: transparent;
         }


         /* Modal Content */
         .modal-CancelView1 {
             /*position: relative;*/
             background-color: #fefefe;
             margin: auto;
             padding: 0;
             /*border: 1px solid #888;*/
             width: 95.6%;
             box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
         }
            .modal-bodyCancelView21 {
             padding: 4% 4% 7% 0%;
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
         <script>
             //validation when cancel process
             function CancelReasonvalidate() {
                 // replacing < and > tags
                 var NameWithoutReplace = document.getElementById("<%=txtCancelreason.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtCancelreason.ClientID%>").value = replaceText2;

             var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
             var txthighlit = document.getElementById("<%=txtCancelreason.ClientID%>").style.borderColor = "";
             var Reason = document.getElementById("<%=txtCancelreason.ClientID%>").value.trim();
             if (Reason == "") {
                 document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                 document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                 document.getElementById("<%=txtCancelreason.ClientID%>").style.borderColor = "Red";
                 return false;
             }
             else {
                 Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                 Reason = Reason.replace(/[ ]{2,}/gi, " ");
                 Reason = Reason.replace(/\n /, "\n");
                 if (Reason.length < "10") {
                     document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                     document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                     var txthighlit = document.getElementById("<%=txtCancelreason.ClientID%>").style.borderColor = "Red";
                     return false;
                 }
             }
         }

        </script>
        <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
            <script type="text/javascript">
                var $noCon = jQuery.noConflict();
                $noCon(window).load(function () {

                    document.getElementById("freezelayer").style.display = "none";

                    if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                        document.getElementById('cphMain_divList').style.display = "";
                    }
                    UncheckAll();   
                });

                var $Mo = jQuery.noConflict();

                function OpenCancelView(VehAsgnId) {
                    document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
                    document.getElementById('cphMain_txtCancelreason').style.borderColor = "";
                if (confirm("Do you want to cancel this Entry?")) {
                    document.getElementById("MymodalCancelView").style.display = "block";
                    document.getElementById("freezelayer").style.display = "";
                    document.getElementById("<%=hiddenVehAsignCnclId.ClientID%>").value = VehAsgnId;
                    document.getElementById("<%=txtCancelreason.ClientID%>").value = "";
                    document.getElementById("<%=txtCancelreason.ClientID%>").focus();
                    return false;
                }
                else {
                    return false;
                }
            }
            function CloseCancelView() {
                if (confirm("Do you want to close without completing cancellation process?")) {
                    document.getElementById("MymodalCancelView").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";
                    document.getElementById("DivAssignModal").style.display = "none";
                 

                }
                else {
                    return false;
                }
            }


                function SuccessMakeAvailable() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Make Available Successfully.";
                }
                function SuccessClose() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Closed Successfully.";
                }
                function SuccessAsign() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assigned Successfully.";
                }
                function SuccessOtherStatus() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assigned To Other Status Successfully.";
                }

                function SuccessUpdAsign() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assign Updated Successfully.";
                }
                function SuccessConfirm() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Confirmed Successfully.";
                }
                function SuccessDelete() {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Cancelled Successfully.";
                }
    </script>
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
          function CloseStatusNot() {
              alert("It Is Not A Confirmed Entry.");
          }

          function MakeAvailableNot()
          {
              alert("Sorry, You Do Not Have This Provision.");
          }
          function AlreadyAvailable()
          {
              alert("This Vehicle Is Already Available.");
          }
          function DeleteAssignNotPosible()
          {
              alert("Sorry, Cancellation Denied. This Entry is a Confirmed Entry!");
          }
          function NotAssigned()
          {
              alert("This Vehicle Is Not Assigned.");
          }
          function AlreadyConfirmed() {
              alert("This Entry Is Already Confirmed.");
          }
          function AssignCall(VehId)
          {
              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                  window.location.href = "gen_Vehicle_Assign.aspx?VehId=" + VehId + "&Back="+document.getElementById("<%=HiddenBackPage.ClientID%>").value+"";
              }
              else {
                  window.location.href = "gen_Vehicle_Assign.aspx?VehId=" + VehId + "";
              }

          }

          function EditAssignCall(AsgnId) {
              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                  window.location.href = "gen_Vehicle_Assign.aspx?VehAsgn=" + AsgnId + "&Back=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
              }
              else {
                  window.location.href = "gen_Vehicle_Assign.aspx?VehAsgn=" + AsgnId + "";
              }
          }


          function OtherStatusCall(VehId) {
              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                  window.location.href = "gen_Vehicle_Other_Status.aspx?VehId=" + VehId + "&Back=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
              }
              else {
                  window.location.href = "gen_Vehicle_Other_Status.aspx?VehId=" + VehId + "";
              }
              
          }
          var $Mo = jQuery.noConflict();

          function MakeAvailable(VehId) {
              if (confirm("Are You Sure! Do you want to Make Available This Vehicle?")) {
                  var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                  $Mo.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "/AWMS/AWMS_WebServices/Service_Vehicle_Status_Mngmnt.asmx/MakeAvailable",
                      data: '{VehId:"' + VehId + '",strUserId:"' + UserId + '"}',
                      dataType: "json",
                      success: function (data) {
                          if (data.d == "success") {
                              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                                  window.location = "/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "&InsUpd=MkAvail";
                              }
                              else {

                                  window.location = 'gen_Vehicle_Status_Management.aspx?InsUpd=MkAvail';
                              }
                              }
                        
                          else {
                       
                              window.location = 'gen_Vehicle_Status_Management.aspx?InsUpd=Error';
                          }
                      }

                  });
              }
          }

          function DeleteAssign(VehAsgnId) {
              OpenCancelView(VehAsgnId);
              return false;
          }


          function CloseStatus(AsignId) {
              if (confirm("Do you want to close this assigned task?")) {
                  var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                  $Mo.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "/AWMS/AWMS_WebServices/Service_Vehicle_Status_Mngmnt.asmx/CloseVehicleStatus",
                      data: '{strAsgnId:"' + AsignId + '",strUserId:"' + UserId + '"}',
                      dataType: "json",
                      success: function (data) {
                          if (data.d == "success") {
                              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                                  window.location = "/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "&InsUpd=StsCls";
                              }
                              else {
                                  window.location = 'gen_Vehicle_Status_Management.aspx?InsUpd=StsCls';
                              }
                          }
                          else {
                             
                              window.location = 'gen_Vehicle_Status_Management.aspx?InsUpd=Error';
                          }
                      }

                  });


              }
              else {
                  return false;
              }
          }
        
          function ConfirmAssign(AsignId) {
              if (confirm("Do you want to Confirm this assigned task?")) {
                  var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                  $Mo.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "/AWMS/AWMS_WebServices/Service_Vehicle_Status_Mngmnt.asmx/ConfirmVehicleAssignStatus",
                      data: '{strAsgnId:"' + AsignId + '", strUserId:"' + UserId + '"}',
                      dataType: "json",
                      success: function (data) {
                          if (data.d == "success") {
                              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                                  window.location = "/AWMS/AWMS_Master/gen_Vehicle_Status_Management/gen_Vehicle_Status_Management.aspx?VhclID=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "&InsUpd=CnFrm";
                              }
                              else {
                                  window.location = 'gen_Vehicle_Status_Management.aspx?InsUpd=CnFrm';
                              }
                             
                          }
                          else {
                              window.location = 'gen_Vehicle_Status_Management.aspx?InsUpd=Error';
                          }
                      }

                  });
                  return true;
              }
              else {
                  return false;
              }
        }



          function ViewAssign(VehId) {
              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                  window.location.href = "gen_Vehicle_Assigned_List.aspx?VehId=" + VehId + "&Back=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
              }
              else {
                  window.location.href = "gen_Vehicle_Assigned_List.aspx?VehId=" + VehId + "";
              }
          }

          //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
          function textCounter(field, maxlimit) {
              if (field.value.length > maxlimit) {
                  field.value = field.value.substring(0, maxlimit);
              } else {

              }
          }

          function ConfirmMessage() {
             

                  if (confirm("Are You Sure You Want To Leave This Page?")) {

                      window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master.aspx?Id=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";

                  }
             
          }
        
       
         

    </script>
    <style>
      .main_table {
        word-break: break-all;
        }
    </style>
    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
        background-color:#b5bca9 !important;
    }
    .GridPager a, .GridPager span
    {
        display: block;
        height: 15px;
        width: 15px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }
        #lblVehicleNum {
            padding-left:5px;
        }
        #lblAsgnTo {
            padding-left:5px;
        }
              .Previous {
    background: url(/Images/BigIcons/Previous.png) no-repeat 0 0;
    width: 90px;
}
      .Grid td {
            word-break: break-all;
            word-wrap: break-word;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenVehAsignCnclId" runat="server" />
    <asp:HiddenField ID="hiddenRoleAdd" runat="server" />
    <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
    <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
    <asp:HiddenField ID="hiddenRoleClose" runat="server" />
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
    <asp:HiddenField ID="HiddenBackPage" runat="server" />
      <asp:HiddenField ID="hiddenRowCount" runat="server" />
         <asp:HiddenField ID="HiddenVehicleList" runat="server" />
     <asp:HiddenField ID="HiddenVehcount" runat="server" />
   
        <br />
     <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
     <div id="divList" class="Previous"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:0%; top:31%;height:26.5px;cursor:pointer;display:none;"></div>
        <div class="cont_rght">

              <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/vehicle-management.png" style="vertical-align: middle;"  />
            <a id="a_Caption" href="gen_Vehicle_Status_Management.aspx" style="color: rgb(83, 101, 51);">Vehicle Allotment</a>
                  </div>
            <div style="margin-top:7px">
                <div>
                      <asp:Button ID="BtnBulkAssign" style=" float:left;background: #127c8f;color:white; cursor:pointer; width: 12%;visibility:hidden" runat="server" class="form1" Text="Assign" OnClientClick="return getselected();" />
               
              

                 <div id="divAsignMode" style="float: left; width: 28%; margin-top: 0.3%;margin-bottom: 1%;margin-left: 10%;" >
           <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;float: left;">Assign Mode</span>
        <asp:DropDownList ID="ddlAsignMode" CssClass="leads_field dd2" style="width: 63% !important; margin-left:3%;margin-top: 0%;" runat="server"  autofocus="autofocus" onkeypress="return DisableEnter(event);" autocorrect="off" autocomplete="off">      
                 <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Project" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Employee" Value="2"></asp:ListItem>
                           <asp:ListItem Text="General" Value="3"></asp:ListItem>
              </asp:DropDownList>
           </div>

                <div id="divVehNumbr" style="float: left; width: 35%; margin-top: 0.3%;margin-bottom: 1%;margin-left: 4%;" >
           <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;float: left;">Vehicle Number</span>
        <asp:DropDownList ID="ddlVehicleNumber" CssClass="leads_field leads_field_dd dd2" style="width: 54% !important; margin-left:3%;margin-top: 0%;" runat="server"  autofocus="autofocus" onkeypress="return DisableEnter(event);" autocorrect="off" autocomplete="off">      
                 </asp:DropDownList>
           </div>
                 <asp:Button ID="btnSearch" style=" float:left; cursor:pointer; width: 104px;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click"  OnClientClick="return Validate();"/>
              
                     </div>

                  <asp:GridView ID="GridVehicleStatusMngmnt" OnRowDataBound="GridVehicleStatusMngmnt_RowDataBound" ShowHeaderWhenEmpty="True" AllowPaging="true" 
                      OnPageIndexChanging="GridVehicleStatusMngmnt_PageIndexChanging"  CssClass="Grid" AlternatingRowStyle-CssClass="alt"
                      PagerStyle-CssClass ="pgr" 
                      runat="server" AutoGenerateColumns="false" Width="100%">

                        
                       <EmptyDataTemplate>
                              <label style="color:#6c6c6c;margin-left:42%;font-family: calibri;font-size: 16px;">No Data Available</label>
                         </EmptyDataTemplate>
                      
                      
                      <Columns>
                  <%--       <asp:TemplateField HeaderText="" >
                          <HeaderStyle Font-Bold="True" Font-Names="calibri" Font-Size="15px" />
                             <ItemTemplate>
                          <asp:CheckBox ID="CheckBox1" runat="server" />
                             </ItemTemplate>
                            <ItemStyle  Width="4%" HorizontalAlign="Center" Wrap="true"/>
                        </asp:TemplateField>--%>
     
                        <asp:TemplateField HeaderText="" >
                          <HeaderStyle Font-Bold="True" Font-Names="calibri" Font-Size="15px" />
                             <ItemTemplate>
                                 
                                 <asp:CheckBox ID="ChkVehlceSelect" runat="server" value='<%#Eval("VHCL_ID") %>' />
                                 <%--<%#Container.DataItemIndex+1 %>--%>
                             </ItemTemplate>
                            <ItemStyle BorderColor="#CFCECE" Width="4%" HorizontalAlign="Center" Wrap="true"/>
                        </asp:TemplateField>
                     
                       <asp:TemplateField HeaderText="Vehicle Number">
                          <HeaderStyle Font-Bold="True" Font-Size="15px" HorizontalAlign="left" Font-Names="calibri" />
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleNum"  style="margin-left:2%;" runat="server" Text='<%#Eval("VHCL_NUMBR") %>'/>
                           </ItemTemplate>
                           <ItemStyle Width="18%" Wrap="true"/>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Assign Mode">
                          <HeaderStyle Font-Bold="True" HorizontalAlign="Center" Font-Size="15px" Font-Names="calibri" />
                            <ItemTemplate>
                              <asp:Label ID="lblAsgnMode" runat="server" Text='<%#Eval("ASIGN_MODE") %>'/>
                           </ItemTemplate>
                           <ItemStyle Width="10%" Wrap="true" HorizontalAlign="Center"/>
                       </asp:TemplateField>


                           <asp:TemplateField HeaderText="Division">
                          <HeaderStyle Font-Bold="True" HorizontalAlign="left" Font-Size="15px" Font-Names="calibri" />
                            <ItemTemplate>
                              <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("ASIGN_DIV") %>'/>
                           </ItemTemplate>
                           <ItemStyle Width="14%" Wrap="true" HorizontalAlign="left"/>
                       </asp:TemplateField>

                       <asp:TemplateField HeaderText="Assign To">
                          <HeaderStyle Font-Bold="True" Font-Size="15px"  HorizontalAlign="left" Font-Names="calibri" />
                            <ItemTemplate>
                              <asp:Label ID="lblAsgnTo" style="margin-left:2%;" runat="server" Text='<%#Eval("ASIGN_MODE").ToString()=="EMPLOYEE"? Eval("ASIGN_USR_NAME"):Eval("ASIGN_PRJCT_NAME") %>'/>
                        
                                   </ItemTemplate>
                           <ItemStyle Width="20%" Wrap="true"/>
                       </asp:TemplateField>
                      <asp:TemplateField HeaderText="Assign">
                         <HeaderStyle Font-Bold="True" Font-Size="15px" Font-Names="calibri"  HorizontalAlign="Center" />
                           <ItemTemplate>
                             <asp:Image id="imgAssignVeh"  title="Add" runat="server" src="/Images/Icons/Assign_symbol.png" alt="Clear" style="float: left;margin-top: 7px;margin-left: 12px;cursor: pointer;" />

                              <asp:Image id="imgAssignVehNot" runat="server" src="/Images/Icons/view.png"  title="View" alt="Clear" style="float: left;margin-top: 7px;margin-left: 12px;cursor: pointer;" />

                             <asp:Image id="imgCloseAsgn" src="/Images/Icons/close.png"  title="Close" runat="server" alt="Clear" style="float: left;margin-top: 7px;margin-left: 6px;cursor: pointer;"  />
                               <asp:Image id="imgCloseAsgnNot" src="/Images/Icons/close.png" runat="server" alt="Clear" style="float: left;opacity: 0.2;margin-top: 7px;margin-left: 6px;cursor: pointer;"  />                          
                               <asp:ImageButton id="imgDeleteAsign"  title="Delete" runat="server" src="/Images/Icons/delete.png" alt="Clear" style="float: left;margin-top: 7px;margin-left: 6px;cursor: pointer;" />
                               <asp:ImageButton id="ImageDeleteNotPos" runat="server" src="/Images/Icons/delete.png" alt="Clear" style="float: left;opacity: 0.2;margin-top: 7px;margin-left: 6px;cursor: pointer;" />
                              <asp:Image ID="imgApproveAsign"  title="Confirm" src="/Images/Icons/confirm.png" runat="server" alt="Clear" style="float: left;margin-top: 7px;margin-left: 6px;cursor: pointer;"/>
                              <asp:Image ID="imgApproveAsignNot" src="/Images/Icons/confirm.png" runat="server" alt="Clear" style="float: left;margin-top: 7px;margin-left: 6px;cursor: pointer;opacity: 0.2;"/> 
                                                             
                         </ItemTemplate>
                       <ItemStyle BorderColor="#CFCECE" Width="12%" HorizontalAlign="Center"/>

                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Make Available">
                       <HeaderStyle Font-Bold="True" Font-Size="15px"  Font-Names="calibri" HorizontalAlign="Center"/>
                        <ItemTemplate>
                         <asp:Image ID="imgMakeAvail" src="/Images/Icons/available.png" title="Make Available" runat="server" alt="Clear" style="float: right;margin-right:40%; margin-top:3px;cursor: pointer;" />
                         <asp:Image ID="imgMakeAvailNot" src="/Images/Icons/available.png" runat="server" alt="Clear" style="float: right;margin-right:40%; margin-top: 3px;cursor: pointer;opacity: 0.2;" />
                       </ItemTemplate>
                         <ItemStyle Width="12%" Wrap="true"/>
                     </asp:TemplateField>

                    <asp:TemplateField HeaderText="Other Status">
                     <HeaderStyle Font-Bold="True" Font-Size="15px"  Font-Names="calibri" HorizontalAlign="Center" />
                       <ItemTemplate>
                        <asp:Image id="imgOtherSts" runat="server" src="/Images/Icons/Assign_symbol.png"  title="Add" alt="Clear" style="float: left;margin-top: 7px;margin-left:23px;cursor: pointer;"/>
                        <img id="imgView" src="/Images/Icons/view.png"  title="View" alt="view" style="float: left;margin-top: 10px;margin-left: 6px;cursor: pointer;" onclick="ViewAssign('<%#Eval("VHCL_ID") %>')" />
                      </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center"/>
                   </asp:TemplateField>
               </Columns>

                     
                       <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                      
       </asp:GridView>
                </div>
 </div>

                                             <%--------------------------------View for cancel Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                      
                      <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Vehicle Assign</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                            <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>
                      <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b;font-size:16px  ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCancelreason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc;font-family:Calibri"  onkeydown="textCounter(cphMain_txtCancelreason,450)"  onkeyup="textCounter(cphMain_txtCancelreason,450)" onkeypress="return isTag(event)" onblur="RemoveTag(cphMain_txtCancelreason)" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSaveCancelReasonAsign" class="save" style="width: 90px;float:left;margin-left:39%;margin-top: 3%;" runat="server" Text="Save" OnClientClick="return CancelReasonvalidate()" OnClick="btnSaveCancelReason_Click" />
                        <asp:Button ID="btnCancelCancelReason" class="cancel" style="width: 90px; float:right;margin-right:26%;margin-top: 3%;" onclientclick="return CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                   <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>

                </div>
            </div>

    <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>


    <style>


        .Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 2px #bababa; border-collapse:collapse; font-family:Calibri; color: #474747;}
.Grid td {
      padding: 2px;
      border: solid 1px #dad3d3;}

.Grid tbody tr:hover
{
    background-color: #d8dbd4 ;
    color: black;
}

.Grid th  {
      padding : 4px 2px;
      color: #fff;
      background: #798664  url(Images/grid-header.png) repeat-x top;
      border-left: solid 1px #525252;
      font-size: 0.9em;
       height: 25px;
}
.Grid .alt {
      background: #fcfcfc url(Images/grid-alt.png) repeat-x top; }
.Grid .pgr {background: #798664  url(Images/Icons/grid-pgr.png) repeat-x top; }
.Grid .pgr table { margin: 3px 0; }
.Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #fff; font-weight: bold; color: #fff; line-height: 12px; }  
.Grid .pgr a { color: #0d2977; text-decoration: none; }
.Grid .pgr a:hover { color: #000; text-decoration: none; }
 .Grid .pgr:hover { background: #798664;}
    </style>
     <script>
         var count = 0;
         function selectedcount(i) {

             var index = i;

             //  alert(count);
             if (document.getElementById('cphMain_GridVehicleStatusMngmnt_ChkVehlceSelect_' + i).checked) {
                 //  alert(count);
                 count++;

                 document.getElementById('cphMain_GridVehicleStatusMngmnt_imgAssignVeh_' + index).style.pointerEvents = "none";
                 document.getElementById('cphMain_GridVehicleStatusMngmnt_imgAssignVeh_' + index).style.opacity = .25;

             }
             else {
                 count--;
                 if (count < 0) {
                     count = 0;
                 }
                 document.getElementById('cphMain_GridVehicleStatusMngmnt_imgAssignVeh_' + index).style.display = "";
                 document.getElementById('cphMain_GridVehicleStatusMngmnt_imgAssignVeh_' + index).style.pointerEvents = "";
                 document.getElementById('cphMain_GridVehicleStatusMngmnt_imgAssignVeh_' + index).style.opacity = 1;

             }
             if (count > 0) {
                 
                 document.getElementById("<%=HiddenVehcount.ClientID%>").value = count;
                 document.getElementById("<%=lblVehicleNum.ClientID%>").value = count;
               
                 document.getElementById('cphMain_BtnBulkAssign').style.visibility = "visible";


             }
             else { document.getElementById('cphMain_BtnBulkAssign').style.visibility = "hidden"; }


             //  alert(count);
         }
         function getselected() {
             //   alert();
             document.getElementById("DivAssignModal").style.display = "block";
             document.getElementById("freezelayer").style.display = "";
           //  alert(document.getElementById("<%=HiddenVehcount.ClientID%>").value);
             document.getElementById("<%=lblVehicleNum.ClientID%>").innerHTML =document.getElementById("<%=HiddenVehcount.ClientID%>").value;

             var RowCount = document.getElementById("<%=hiddenRowCount.ClientID%>").value;
            //  alert(RowCount);
            var strAmntList = "";
            for (i = 0; i < RowCount; i++) {

                if (document.getElementById('cphMain_GridVehicleStatusMngmnt_ChkVehlceSelect_' + i).checked) {

                    strAmntList = strAmntList + document.getElementById('cphMain_GridVehicleStatusMngmnt_ChkVehlceSelect_' + i).value + ',';
                    // alert(document.getElementById('cphMain_GridVehicleStatusMngmnt_ChkVehlceSelect_' + i).value);
                    document.getElementById("<%=HiddenVehicleList.ClientID%>").value = strAmntList;
                }
            }
            // BulkAssign();
            return false;
        }
        function BulkAssign() {
            document.getElementById('divassigndetails').focus();
            if ((document.getElementById("<%=HiddenVehicleList.ClientID%>").value) != "") {

        }
            // if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
            //   window.location.href = "gen_Vehicle_Assign.aspx?BulkVehId=" + document.getElementById("<%=HiddenVehicleList.ClientID%>").value + "&Back="+document.getElementById("<%=HiddenBackPage.ClientID%>").value+"";

            //   }
            //  else {
            //   window.location.href = "gen_Vehicle_Assign.aspx?BulkVehId=" + document.getElementById("<%=HiddenVehicleList.ClientID%>").value + "";
            //  /     // waitSeconds(5000);
            //  }
            //  setTimeout(function(){ 
            //do what you need here
            // }, 2000);



        }


    </script>
    <div>
        <asp:HiddenField ID="hiddenVehicleId" runat="server" />
     <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
     <asp:HiddenField ID="HiddenField1" runat="server" /> <asp:HiddenField ID="Hiddenchecklist" runat="server" />
        <br />
                                                 <%--------------------------------View for cancel Reason--------------------------%>
            <div id="DivAssignModal" class="modalCancelView1" style="width:78%;left: 10%;margin-top:0%" >
                <!-- Modal content -->
                <div class="modal-CancelView1">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return AlertClearAll();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                      
                      <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Vehicle Assign</h3>
                    </div>
                    <div class="modal-bodyCancelView1">
                         

        <div style="padding-top: 0%;margin-left:5%;float:left;width:100%">
                 <div id="div1" style="display:none">
            <img id="img1" src="" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
            
    
            <div  style="width:95%;">
                
            <div id="div3" style="margin-top: 1%;font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <%--<img src="../Images/BigIcons/vehicle-management_assign.png" style="vertical-align: middle;"  />--%>
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
                <br/>

                <div id="divassigndetails"style="background-color: #efefef;border: 1px solid;border-color: #c5c5c5;margin-left:8%;float:left">

                     <div style="width:98%;margin-top: 2%;color: red;float: left;margin-left: 1%;">
                         <h2 style="margin-bottom:0%;margin-top: 0.2%;">Number Of Vehicle:</h2>
                          <asp:label id="lblVehicleNum" runat="server" style="font-family:Calibri;word-wrap:break-word; color:#536533;font-size:19px;margin-left: 1%;"></asp:label>
                    </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                     <div id="divContentContainer" style="width: 50%;float: left;margin-top: 8%;">

                    <div id="AssignTo" class="eachform" style="width:95%;float:right">
                     <div id="divAsignCapt">
                 <asp:Label ID="lblAssignTo" runat="server">Assign To*</asp:Label>
                         </div>
               <div id="divRadio" class="subform" style="width:90%;float:right">
                   <div style="width:77px;float:left;margin-left: 5px">
                   <asp:RadioButton  ID ="radioProject" Text="Project" runat="server" onclick="VisibleDropDown();" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup"/> 
                   </div> 
                    <div style="width:95px;float:left;margin-left: 5px">
                   <asp:RadioButton  ID ="radioEmployee" Text="Employee" runat="server" onclick="VisibleDropDown();" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup"/> 
                     </div> 
                    <div style="width:93px;float:left;margin-left: 5px">
                 <asp:RadioButton  ID ="radioGeneral" Text="General" runat="server" onclick="HideDropDown();"  Checked="true" onkeypress="return DisableEnter(event)" GroupName ="RadioGroup" />  
                </div>
                  </div>
           
            </div>


          </div>


                <div style="width:50%;float:right;margin-top:3%">
                   


                 <div id="Division" class="eachform" style="width:90%;float:left">

                <h2>Division*</h2>
               <asp:DropDownList ID="ddlDivision" Height="30px" Width="58%" class="form1" onchange="ddlChangeEvent()" onkeydown="return DisableEnter(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" runat="server" Style="margin-right: 1%;"></asp:DropDownList>
           
            </div>
                <div id="divProject_Employee" class="eachform" style="width:90%;float:left">
               <div style="width: 126px;float: left;">
                <asp:label id="lblproject_emp" runat="server" style="font-family:Calibri;color:#909c7b;font-size:17px">Project/Employee</asp:label>
             </div>
              <asp:DropDownList ID="ddlProject_Employee" Height="30px" Width="54%" class="form1" onkeydown="return DisableEnter(event)" runat="server" Style="margin-right: 0%;"></asp:DropDownList>
           
            </div>
               </div>
          
                          </ContentTemplate>
                    </asp:UpdatePanel>

                     <div style="width:50%;float:right;margin-top:0%">
                  <div class="eachform" style="width:90%;float:left">
                 <h2>From Date*</h2>
               <div id="divFromDate" class="input-append date" style="font-family:Calibri;float:right;width:51%;margin-right: 8%;">
                 <asp:TextBox ID="txtFromDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width:98.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img2" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />
                   <script type="text/javascript" src="/JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="/JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="/JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divFromDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),
                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

                
                <div class="eachform" style="width:90%;float:left">
                 <h2>To Date</h2>
               <div id="divToDate" class="input-append date" style="font-family:Calibri;float:right;width:51%;margin-right: 8%;">
                 <asp:TextBox ID="txtToDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" onkeydown="return DisableEnter(event)" Style="width:98.8%;height:23px; font-family: calibri;" ></asp:TextBox>

                        <img id= "img3" class="add-on" src="../../../Images/Icons/CalandarIcon.png" onclick="IncrmntConfrmCounter()" style=" height:17px; width:12px; cursor:pointer;" />

                        <script type="text/javascript">
                            var $noC = jQuery.noConflict();
                            $noC('#divToDate').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,

                                startDate: new Date(),
                            });

                        </script>
                         <p style="visibility: hidden">Please enter</p>
                    </div>
                 </div>

                    </div>
                 <div class="eachform" style="margin-top: 2%;">
                <div class="subform" style="width: 62%; margin-top:5%;margin-right: 3%;">
                    <asp:Button ID="btnAssign" runat="server" class="save" Text="Assign"  OnClientClick="return AssignValidate();" OnClick="btnAssign_Click"/>
                      <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" Style="display:none"  OnClientClick="return AssignValidate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnCancel" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();" OnClick="btnCancel_Click"  class="cancel" Text="Cancel"/>
               

                </div>
            </div>
        </div>
                
                 </div>
            </div>
                    </div>
                    
                   <div class="modal-footerCancelView" style="">
                    </div>

                </div>
            </div>



    </div>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            var count=document.getElementById("<%=HiddenVehcount.ClientID%>").value
             document.getElementById("<%=lblVehicleNum.ClientID%>").value = count;
               
           // alert(document.getElementById("<%=HiddenVehcount.ClientID%>").value);
            if (document.getElementById("<%=HiddenVehicleList.ClientID%>").value == "") {
                //alert(document.getElementById("<%=HiddenVehicleList.ClientID%>").value);

                //     document.getElementById('divassigndetails').style.display="none";

            } if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
                document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
            }
            else {
                document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee*";
            }
        });


        function InvalidDateAlert() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "The Date You Entered Are Invalid.";
           }
        function AssignValidate() {
         
               document.getElementById('divassigndetails').style.display = "";

               var $noCon = jQuery.noConflict();
               var ret = true;
               if (CheckIsRepeat() == true) {
               }
               else {
                   ret = false;
                   return ret;
               }
               // replacing < and > tags
               var FromDateWithoutReplace = document.getElementById("<%=txtFromDate.ClientID%>").value;
            var replaceText1 = FromDateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtFromDate.ClientID%>").value = replaceText2;

                    var ToDateWithoutReplace = document.getElementById("<%=txtToDate.ClientID%>").value;
            var replaceText1 = ToDateWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtToDate.ClientID%>").value = replaceText2;

            document.getElementById("<%=ddlProject_Employee.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "";

            var FromDate = document.getElementById("<%=txtFromDate.ClientID%>").value.trim();
            var ToDate = document.getElementById("<%=txtToDate.ClientID%>").value.trim();

            var ddlDiv = document.getElementById("<%=ddlDivision.ClientID%>");
            var DivText = ddlDiv.options[ddlDiv.selectedIndex].text;

            var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
            var EmpText = ddlEmp.options[ddlEmp.selectedIndex].text;


            if (FromDate != "" && ToDate != "") {

                var TaskdatepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var CurrentDateDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                        if (dateDateCntrlr > dateCurrentDate) {

                            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtToDate.ClientID%>").focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,  To Date should be Greater than From Date!.";

                            ret = false;
                        }
                    }

                    if (ToDate != "") {
                        var TaskdatepickerDate = document.getElementById("<%=txtToDate.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                        if (dateDateCntrlr < dateCurrentDate) {

                            document.getElementById("<%=txtToDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtToDate.ClientID%>").focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,To Date should be Greater than Current Date!.";

                            ret = false;
                        }
                    }
                    if (FromDate != "") {
                        var TaskdatepickerDate = document.getElementById("<%=txtFromDate.ClientID%>").value;
                        var arrDatePickerDate = TaskdatepickerDate.split("-");
                        var dateDateCntrlr = new Date(arrDatePickerDate[2], arrDatePickerDate[1] - 1, arrDatePickerDate[0]);

                        var CurrentDateDate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
                        var arrCurrentDate = CurrentDateDate.split("-");
                        var dateCurrentDate = new Date(arrCurrentDate[2], arrCurrentDate[1] - 1, arrCurrentDate[0]);

                        if (dateDateCntrlr < dateCurrentDate) {

                            document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtFromDate.ClientID%>").focus();
                            document.getElementById('divMessageArea').style.display = "";
                            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry,  From Date should be greater than Current Date!.";

                            ret = false;
                        }
                    }

                    if (FromDate == "") {
                        document.getElementById('divMessageArea').style.display = "";
                        document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                        document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=txtFromDate.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtFromDate.ClientID%>").focus();
                        ret = false;
                    }

                    if (document.getElementById("<%=radioGeneral.ClientID%>").checked != true) {

                if (EmpText == "--SELECT--") {

                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    document.getElementById("<%=ddlProject_Employee.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlProject_Employee.ClientID%>").focus();
                    ret = false;
                }


            }


            if (DivText == "--SELECT--") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                        document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=ddlDivision.ClientID%>").focus();
                        ret = false;
                    }


                    if (ret == false) {
                        CheckSubmitZero();

                    }
                    return ret;

                }

    </script>
                       
         <%--FOR DATE TIME PICKER--%>
<script type="text/javascript" src="/JavaScript/Date/JavaScriptDate1_8_3.js"></script>                      
<script type="text/javascript" src="/JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
<script type="text/javascript" src="/JavaScript/Date/bootstrap-datepicker.js"></script>
<script type="text/javascript"src="/JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
<link href="/css/Date/StyleSheetDate.css" rel="stylesheet" />
<link href="/css/Date/StyleSheetDate2.css" rel="stylesheet" />
    <style>


        .eachform h2 {
    font-family: Calibri;
    font-size: 17px;
    float: left;
    text-align: left;
    color: #909c7b;
    padding: 0;
    margin: 8px 0 6px;
    line-height: 1;
    font-weight: normal;
    float: left;
}
         .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }
        .textDate {
            border: 1px solid #cfcccc;
        }
         .open > .dropdown-menu {
    display: none;
}
         input[type="radio"] {
    display: block;
    float:left;
}
           #divAsignCapt {
            font-size: 19px;
            color: rgb(83, 101, 51);
            font-family: Calibri;
            width: 128px;
            margin-left:32%;
       

        }
        #divRadio {
           font-size: 15px;
            color: rgb(83, 101, 51);
            font-family: Calibri;
            margin-top:4%;
        }
        .bootstrap-datetimepicker-widget {
            z-index:100;
        }
    </style>
        <script>
            $noCon = jQuery.noConflict();

            function VisibleDropDown() {


                //$noCon("div#divProject_Employee input.ui-autocomplete-input").attr('disabled', 'false');
                var ddlDiv = document.getElementById('cphMain_ddlDivision');
                ddlDiv.options[0].selected = true;
                __doPostBack('<%= ddlDivision.UniqueID%>', '');
                var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
                ddlEmp.options[0].selected = true;
                setTimeout(ddlEnable, 50);

            }
            function ddlEnable() {
                document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee*";
                document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = false;
                setTimeout(SetTime(), 25); //evm-20
            }

            function SetTime() {
                $au(function () {
                    $au('#cphMain_ddlProject_Employee').selectToAutocomplete1Letter();
                });
            }//evm-20

        function HideDropDown() {

            if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                 var ddlDiv = document.getElementById("<%=ddlDivision.ClientID%>");
                 ddlDiv.options[0].selected = true;
                 __doPostBack('<%= ddlDivision.UniqueID%>', '');
                var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
                 ddlEmp.options[0].selected = true;

                 setTimeout(ddlDisable, 50);

             }
         }
         function ddlDisable() {
             document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
             document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
             setTimeout(SetTime(), 25);//evm-20
        }
        function ddlFocusonUpdate() {
            document.getElementById("<%=ddlDivision.ClientID%>").focus();
        }

        function ddlFocus() {
            if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
                ddlEmp.options[0].selected = true;
                document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
                document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
            }
            else {

                document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee*";
                document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = false;
            var ddlEmp = document.getElementById("<%=ddlProject_Employee.ClientID%>");
                ddlEmp.options[0].selected = true;
            }

            document.getElementById("<%=ddlDivision.ClientID%>").focus();
            setTimeout(SetTime(), 25);//evm-20

        }
        function ddlChangeEvent() {
            IncrmntConfrmCounter();

            if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
                document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
            }
            else {
                document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = false;
                document.getElementById("<%=lblproject_emp.ClientID%>").textContent = "Project/Employee*";

            }
        }
</script>  <script language="javascript" type="text/javascript">
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

            var confirmbox = 0;

            function IncrmntConfrmCounter() {
                confirmbox++;
            }
            function ConfirmMessage() {
                if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                    window.location.href = "/AWMS/AWMS_Master/gen_Vehicle_Master/gen_Vehicle_Master_List.aspx";
                }
                else {
                    if (confirmbox > 0) {
                        if (confirm("Are You Sure You Want To Leave This Page?")) {
                            window.location.href = "gen_Vehicle_Status_Management.aspx";
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        window.location.href = "gen_Vehicle_Status_Management.aspx";

                    }
                }
            }

               function AlertClearAll() {
             
                if (confirmbox > 0) {
                    if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                      
                  
                        document.getElementById("cphMain_txtFromDate").value = "";
                        document.getElementById("cphMain_txtToDate").value = "";
                        document.getElementById("cphMain_ddlDivision").value = "--SELECT--";
                        document.getElementById("cphMain_ddlProject_Employee").value = 0;


                        document.getElementById("freezelayer").style.display = "none";
                        document.getElementById("DivAssignModal").style.display = "none";
                    }
                    else {
                        return false;
                    }
                }
                else {
        
                 
                    document.getElementById("cphMain_txtFromDate").value = "";
                    document.getElementById("cphMain_txtToDate").value = "";
                    document.getElementById("cphMain_ddlDivision").value = "--SELECT--";
                    document.getElementById("cphMain_ddlProject_Employee").value = 0;


                    document.getElementById("freezelayer").style.display = "none";
                    document.getElementById("DivAssignModal").style.display = "none";
                    document.getElementById("freezelayer").style.display = "none";
                    document.getElementById("DivAssignModal").style.display = "none";

                }
            }


            var $noCon = jQuery.noConflict();
            $noCon(window).load(function () {

                if (document.getElementById("<%=radioGeneral.ClientID%>").checked == true) {
                   document.getElementById("<%=ddlProject_Employee.ClientID%>").disabled = true;
                   document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee";
               }
               else {
                   document.getElementById('cphMain_lblproject_emp').textContent = "Project/Employee*";
               }
           });


           function InvalidDateAlert() {
               document.getElementById('divMessageArea').style.display = "";
               document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
               document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "The Date You Entered Are Invalid.";
           }
           function UncheckAll() {
               var w = document.getElementsByTagName('input');
               for (var i = 0; i < w.length; i++) {
                   if (w[i].type == 'checkbox') {
                       w[i].checked = false;
                   }
               }
           }

           $noCon('#modal-CancelView1').on('hidden.bs.modal', function (e) {
               $noCon(this)
                 .find("input,textarea,select")
                    .val('')
                    .end()
                 .find("input[type=checkbox], input[type=radio]")
                    .prop("checked", "")
                    .end();
           })
           // for not allowing enter
           function DisableEnter(evt) {

               evt = (evt) ? evt : window.event;
               var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
               if (keyCodes == 13) {
                   return false;
               }
           }
   </script>
</asp:Content>

