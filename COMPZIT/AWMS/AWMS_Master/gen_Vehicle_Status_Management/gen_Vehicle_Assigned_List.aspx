<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Assigned_List.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Assigned_List" %>

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
            <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
         <script>

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
                     window.location.href = "gen_Vehicle_Status_Management.aspx?VhclID=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
                    
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

             function SuccessDelete() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Cancelled Successfully.";
             }
             function SuccessClose() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Closed Successfully.";
             }
             function SuccessConfirm() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Confirmed Successfully.";
             }
             function ConfirmDuplication() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Confirm Denied.Status Can't Be Duplicated In Same Date Period";
             }
             function SuccessUpdate() {
                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Updated Successfully.";
             }
        </script>
    <script>
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            document.getElementById("freezelayer").style.display = "none";



        });


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
                }
                else {
                    return false;
                }
            }

        function DeleteOther(VehAsgnId) {
            OpenCancelView(VehAsgnId);
            return false;
        }


        function EditAssign(VehAsgnId,VehicleId) {
            if (confirm("Do You Want To Edit This Entry?")) {

                if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                    window.location.href = "gen_Vehicle_Other_Status.aspx?VehAsgn=" + VehAsgnId + "," + VehicleId + "&Back=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
                }
                else {
                    window.location.href = "gen_Vehicle_Other_Status.aspx?VehAsgn=" + VehAsgnId + "," + VehicleId + "";
                }
            }
            else {
                return false;
            }
        }
        function ViewAssign(VehAsgnId, VehicleId) {
            if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                window.location.href = "gen_Vehicle_Other_Status.aspx?VehAsgn=" + VehAsgnId + "," + VehicleId + "&Back=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
            }
            else {
                window.location.href = "gen_Vehicle_Other_Status.aspx?VehAsgn=" + VehAsgnId + "," + VehicleId + "";
            }
          
        }
        function DeleteAssignNotPosible() {
            alert("Sorry, Cancellation Denied. This Entry is a Confirmed Entry!");
        }
        function AlreadyConfirmed() {
            alert("This Entry Is Already Confirmed.");
        }
        function CloseStatusNot() {
            alert("It Is Not A Confirmed Entry.");
        }
        var $Mo = jQuery.noConflict();

        function CloseStatus(AsignId) {
            if (confirm("Do you want to close this assigned task?")) {
                var VehId = document.getElementById("<%=hiddenVehicleId.ClientID%>").value;
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
                                  window.location.href = "gen_Vehicle_Assigned_List.aspx?InsUpd=StsCls&VehId=" + VehId + "&Back=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
                              }
                              else {
                                  window.location = 'gen_Vehicle_Assigned_List.aspx?InsUpd=StsCls&&VehId=' + VehId + '';
                              }

                          }
                          else {
                              window.location = 'gen_Vehicle_Assigned_List.aspx?InsUpd=Error';
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
                  var VehId = document.getElementById("<%=hiddenVehicleId.ClientID%>").value;
                  var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
                  var OrgId = document.getElementById("<%=hiddenOrgId.ClientID%>").value;
                  var CorpId = document.getElementById("<%=hiddenCorpId.ClientID%>").value;
                  $Mo.ajax({
                      type: "POST",
                      async: false,
                      contentType: "application/json; charset=utf-8",
                      url: "/AWMS/AWMS_WebServices/Service_Vehicle_Status_Mngmnt.asmx/ConfirmVehicleAssign",
                      data: '{strAsgnId:"' + AsignId + '", strUserId:"' + UserId + '",strOrgId:"' + OrgId + '",strCorpId:"' + CorpId + '"}',
                      dataType: "json",
                      success: function (data) {
                          if (data.d == "success") {

                              if ((document.getElementById("<%=HiddenBackPage.ClientID%>").value) != "") {
                                  window.location.href = "gen_Vehicle_Assigned_List.aspx?InsUpd=CnFrm&VehId=" + VehId + "&Back=" + document.getElementById("<%=HiddenBackPage.ClientID%>").value + "";
                              }
                              else {
                                  window.location.href = 'gen_Vehicle_Assigned_List.aspx?InsUpd=CnFrm&VehId=' + VehId + '';
                              }
                          }
                          else {
                              window.location.href = 'gen_Vehicle_Assigned_List.aspx?InsUpd=CnfrmDup&VehId=' + VehId + '';
                          }
                      }

                  });
                  return true;
              }
              else {
                  return false;
              }
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
    body
    {
        font-family: Arial;
        font-size: 10pt;
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
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenVehAsignCnclId" runat="server" />
    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenVehicleId" runat="server" />
    <asp:HiddenField ID="hiddenRoleCancel" runat="server" />
    <asp:HiddenField ID="hiddenRoleClose" runat="server" />
    <asp:HiddenField ID="hiddenRoleUpdate" runat="server" />
    <asp:HiddenField ID="hiddenRoleConfirm" runat="server" />
    <asp:HiddenField ID="HiddenBackPage" runat="server" />
       <br />
     <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
       </div>
     <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:20%;height:26.5px;">
        </div>
            <div class="cont_rght">

              <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <%--<img src="/Images/BigIcons/Vehicle_Status_Asign_List.png" style="vertical-align: middle;"  />--%>
            <asp:Label ID="lblEntry" runat="server">List Vehicle Status</asp:Label>
                  </div>
            <div style="margin-top:7px">
                 <asp:Button ID="btnSearch" style=" float:right; cursor:pointer; width: 104px;" runat="server" class="searchlist_btn_lft" Text="Search" OnClick="btnSearch_Click"  OnClientClick="return Validate();"/>
     
                <div id="divVehNumbr" style="float: right; width: 35%; margin-top: 0.3%;margin-bottom: 1%;margin-right: 2%;" >
           <span style="color: rgb(144, 156, 123); font-size: 17px; font-family: Calibri;margin-left:0%;float: left;">Status Type</span>
           <asp:DropDownList ID="ddlStatusType" CssClass="leads_field leads_field_dd dd2" style="width: 54% !important; margin-left:12%;margin-top: 0%;-moz-appearance:button;" runat="server"  autofocus="autofocus" onkeypress="return DisableEnter(event);" autocorrect="off" autocomplete="off">      
                 </asp:DropDownList>
           </div>

                  <asp:GridView ID="GridVehicleAssignList" ShowHeaderWhenEmpty="true" AllowPaging="true" OnPageIndexChanging="GridVehicleAssignList_PageIndexChanging" OnRowDataBound="GridVehicleAssignList_RowDataBound" 
                      CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass ="pgr"   runat="server" AutoGenerateColumns="false" Width="100%">
                       <EmptyDataTemplate>
                           
                         <label style="color:#6c6c6c;margin-left:42%;font-family: calibri;font-size: 16px;">No Data Available</label>

                       </EmptyDataTemplate>
                      
                      <Columns>
                        <asp:TemplateField HeaderText="Sl.No:" >
                          <HeaderStyle Font-Bold="True"  Font-Names="calibri" Font-Size="15px" />
                             <ItemTemplate>
                             <%#Container.DataItemIndex+1 %>
                             </ItemTemplate>
                            <ItemStyle  Width="4%" HorizontalAlign="Center"/>
                         
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="Status Type">
                          <HeaderStyle Font-Bold="True" HorizontalAlign="left" Font-Names="calibri" Font-Size="15px"/>
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleStsTyp" style="margin-left:2%;" runat="server" Text='<%#Eval("VHCLSTSTYP_NAME") %>'/>
                           </ItemTemplate>
                           <ItemStyle Width="25%" HorizontalAlign="left"/>
                       </asp:TemplateField>
                          <asp:TemplateField HeaderText="Status">
                          <HeaderStyle Font-Bold="True" HorizontalAlign="left" Font-Names="calibri" Font-Size="15px" />
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleSts" style="margin-left:2%;" runat="server" Text='<%#Eval("VHCLSTS_NAME") %>'/>
                           </ItemTemplate>
                           <ItemStyle  Width="30%" HorizontalAlign="left"/>
                       </asp:TemplateField>
                           <asp:TemplateField HeaderText="From Date">
                          <HeaderStyle Font-Bold="True"  Font-Names="calibri" Font-Size="15px" HorizontalAlign="Center"/>
                            <ItemTemplate>
                              <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FROM_DATE","{0:dd/MM/yyyy}") %>'/>
                           </ItemTemplate>
                           <ItemStyle Width="14%" HorizontalAlign="Center"/>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="To Date">
                          <HeaderStyle Font-Bold="True"  Font-Names="calibri" Font-Size="15px" HorizontalAlign="Center"/>
                            <ItemTemplate>
                              <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("TO_DATE","{0:dd/MM/yyyy}") %>'/>
                           </ItemTemplate>
                           <ItemStyle Width="14%" HorizontalAlign="Center" />
                       </asp:TemplateField>

                  <asp:TemplateField HeaderText="Other Status">
                     <HeaderStyle Font-Bold="True"  Font-Names="calibri" Font-Size="15px" HorizontalAlign="Center"/>
                       <ItemTemplate>
                        <asp:Image id="imgCloseOther" CssClass="tooltip" title="Close" src="/Images/Icons/close.png" runat="server" alt="Clear" style="float: left;margin-top: 7px;margin-left: 10px;cursor: pointer;"  />
                        <asp:Image id="imgCloseOtherNot" src="/Images/Icons/close.png" runat="server" alt="Clear" style="float: left;opacity: 0.2;margin-top: 7px;margin-left: 10px;cursor: pointer;"  />
                        <asp:ImageButton id="imgDeleteOther" CssClass="tooltip" title="Delete" src="/Images/Icons/delete.png" runat="server" alt="Clear" style="float: left;margin-top: 7px;margin-left: 10px;cursor: pointer;" />
                        <asp:ImageButton id="ImageDeleteOtherNot" src="/Images/Icons/delete.png" runat="server" alt="Clear" style="float: left;opacity: 0.2;margin-top: 7px;margin-left: 10px;cursor: pointer;" /> 
                        <asp:Image ID="imgEdit" src="/Images/Icons/edit.png" CssClass="tooltip" title="Edit" alt="Clear" runat="server" style="float: left;margin-top: 7px;margin-left: 10px;cursor: pointer;"/>
                        <asp:Image ID="imgEditNot" src="/Images/Icons/view.png" CssClass="tooltip" title="View" alt="Clear" runat="server" style="float: left;margin-top: 7px;margin-left: 10px;cursor: pointer;"/>
                       <asp:Image ID="imgApproveOther" src="/Images/Icons/confirm.png" CssClass="tooltip" title="Confirm" runat="server" alt="Clear" style="float: left;margin-top: 7px;margin-left:10px;cursor: pointer;"/>
                       <asp:Image ID="imgApproveOtherNot" src="/Images/Icons/confirm.png" runat="server" alt="Clear" style="float: left;margin-top: 7px;margin-left: 10px;cursor: pointer;opacity: 0.2;"/>                               
                        </ItemTemplate>
                        <ItemStyle Width="12%" HorizontalAlign="Center"/>
                   </asp:TemplateField>

               </Columns>

                       <PagerSettings Mode="NumericFirstLast"  FirstPageText="First" LastPageText="Last" />
                      

                      
       </asp:GridView>
                </div>
 </div>
                                                 <%--------------------------------View for cancel Reason--------------------------%>
            <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="return CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />
                      
                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 40%; padding-bottom: 0.7%; padding-top: 0.6%;">Vehicle Status</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                            <div id="divErrorRsnAWMS" class="error" style="visibility:hidden;  text-align: center; ">
                           <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                                </div>
                      <label class="control-label col-sm-3" style="font-family: Calibri;float:left;margin-left: 11%;margin-top:10%; padding-right: 2%;width: 22%;color: #909c7b;font-size:16px ">Cancel Reason*</label>
                        <asp:TextBox ID="txtCancelreason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize:none;border: 1px solid #cfcccc; font-family:Calibri"  onkeydown="textCounter(cphMain_txtCancelreason,450)"  onkeyup="textCounter(cphMain_txtCancelreason,450)" onkeypress="return isTag(event)" onblur="RemoveTag(cphMain_txtCancelreason)" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSaveCancelReasonOther" class="save" style="width: 90px;float:left;margin-left:39%;margin-top: 3%;" runat="server" Text="Save" OnClientClick="return CancelReasonvalidate()" OnClick="btnSaveCancelReasonOther_Click" />
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
</asp:Content>

