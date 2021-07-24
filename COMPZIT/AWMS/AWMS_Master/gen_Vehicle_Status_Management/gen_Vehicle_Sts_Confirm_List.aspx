<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_AWMS.master" AutoEventWireup="true" CodeFile="gen_Vehicle_Sts_Confirm_List.aspx.cs" Inherits="AWMS_AWMS_Master_gen_Vehicle_Status_Management_gen_Vehicle_Sts_Confirm_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
      <script language="javascript" type="text/javascript">


          function EditAssign(VehAsgnId) {
              window.location.href = "gen_Vehicle_Assign.aspx?VehAsgn=" + VehAsgnId + "";
          }


          function SuccessConfirm() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Status Confirmed Successfully.";
          }
          function SuccessUpdation() {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Vehicle Assign Updated Successfully.";
        }
      </script>
  <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">


        function ConfirmAssign(AsignId) {
            alert('call');
            var UserId = document.getElementById("<%=hiddenUserId.ClientID%>").value;
            $.ajax({
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "/AWMS/AWMS_WebServices/Service_Vehicle_Status_Mngmnt.asmx/ConfirmVehicleAssign",
                data: '{strAsgnId:"' + AsignId + '", strUserId:"' + UserId + '"}',
                dataType: "json",
                success: function (data) {
                    if (data.d == "success") {
                        alert('call');
                        window.location = 'gen_Vehicle_Sts_Confirm_List.aspx?InsUpd=CnFrm';

                    }
                    else {
                        window.location = 'gen_Vehicle_Sts_Confirm_List.aspx?InsUpd=Error';
                    }
                }

            });


          }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenUserId" runat="server" />
    <asp:HiddenField ID="hiddenCorpId" runat="server" />
    <asp:HiddenField ID="hiddenOrgId" runat="server" />
    <asp:HiddenField ID="hiddenVehAsignCnclId" runat="server" />
       <br />
     <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
       </div>
            <div class="cont_rght">

              <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
            <img src="/Images/BigIcons/Vehicle_Status_Management.png" style="vertical-align: middle;"  />
            <a id="a_Caption" href="gen_Vehicle_Status_Management.aspx" style="color: rgb(83, 101, 51);">Vehicle Status Confirm Pending</a>
                  </div>
            <div style="margin-top:7px">
                  <asp:GridView ID="GridVehiclePendingStatus" AllowPaging="true" CssClass="main_table" 
                      OnPageIndexChanging="GridVehiclePendingStatus_PageIndexChanging" ShowHeaderWhenEmpty="true" HeaderStyle-CssClass="main_table_head" 
                      RowStyle-CssClass="tdT" runat="server" AutoGenerateColumns="false" Width="100%">

                       <EmptyDataTemplate>
                              <label style="color:green;margin-left:42%">No Data Available !</label>
                         </EmptyDataTemplate>
                     
                      <Columns>
                        <asp:TemplateField HeaderText="Sl.no:" >
                          <HeaderStyle Font-Bold="True" Font-Size="Medium" BackColor="#b5bca9" ForeColor="White" BorderColor="#DEE9CD" />
                             <ItemTemplate>
                             <%#Container.DataItemIndex+1 %>
                             </ItemTemplate>
                            <ItemStyle BorderColor="#E6E6E6" Width="4%" HorizontalAlign="Center"/>
                        </asp:TemplateField>

                       <asp:TemplateField HeaderText="Vehicle Number">
                          <HeaderStyle Font-Bold="True" Font-Size="Medium" BackColor="#b5bca9" ForeColor="White" BorderColor="#DEE9CD"/>
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleNum" runat="server" Text='<%#Eval("VHCL_NUMBR") %>'/>
                           </ItemTemplate>
                           <ItemStyle BorderColor="#E6E6E6" Width="36%"/>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="AssignMode">
                          <HeaderStyle Font-Bold="True" Font-Size="Medium" BackColor="#b5bca9" ForeColor="White" BorderColor="#DEE9CD"/>
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleNum" runat="server" Text='<%#Eval("ASSAIGNED_TO_MODE") %>'/>
                           </ItemTemplate>
                           <ItemStyle BorderColor="#E6E6E6" Width="12%"/>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Assign To">
                          <HeaderStyle Font-Bold="True" Font-Size="Medium" BackColor="#b5bca9" ForeColor="White" BorderColor="#DEE9CD"/>
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleNum" runat="server" Text='<%#Eval("USR_NAME").ToString()==""? Eval("PROJECT_NAME"):Eval("USR_NAME") %>'/>
                           </ItemTemplate>
                           <ItemStyle BorderColor="#E6E6E6" Width="20%"/>
                       </asp:TemplateField>
                           <asp:TemplateField HeaderText="From Date">
                          <HeaderStyle Font-Bold="True" Font-Size="Medium" BackColor="#b5bca9" ForeColor="White" BorderColor="#DEE9CD"/>
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleNum" runat="server" Text='<%#Eval("FROM_DATE","{0:dd/MM/yyyy}") %>'/>
                           </ItemTemplate>
                           <ItemStyle BorderColor="#E6E6E6" Width="10%"/>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="To Date">
                          <HeaderStyle Font-Bold="True" Font-Size="Medium" BackColor="#b5bca9" ForeColor="White" BorderColor="#DEE9CD"/>
                            <ItemTemplate>
                              <asp:Label ID="lblVehicleNum" runat="server" Text='<%#Eval("TO_DATE","{0:dd/MM/yyyy}") %>'/>
                           </ItemTemplate>
                           <ItemStyle BorderColor="#E6E6E6" Width="10%"/>
                       </asp:TemplateField>
                      <asp:TemplateField HeaderText="Edit/Confirm">
                         <HeaderStyle Font-Bold="True" Font-Size="Medium" BackColor="#b5bca9" ForeColor="White" BorderColor="#DEE9CD" />
                           <ItemTemplate>
                             <img id="imgEdit" src="/Images/Icons/edit.png" alt="Clear" style="float: left;margin-top: 7px;margin-left: 20%;cursor: pointer;" onclick="EditAssign('<%#Eval("VHCLASGN_ID") %>')"  />
                             <img id="imgApprove" src="/Images/Icons/Approve.png" alt="Clear" style="float: left;margin-top: 7px;margin-left: 10%;cursor: pointer;" onclick="ConfirmAssign('<%#Eval("VHCLASGN_ID") %>')" />
                          </ItemTemplate>
                          <ItemStyle BorderColor="#E6E6E6" Width="8%"/>

                     </asp:TemplateField>

               </Columns>

                       <PagerStyle BackColor="#b5bca9" ForeColor="White" HorizontalAlign="Right" Height="20px" />
                       <PagerSettings Mode="NumericFirstLast" PageButtonCount="1" FirstPageText="First" LastPageText="Last" />
                      

                      
       </asp:GridView>
                </div>
 </div>


</asp:Content>

