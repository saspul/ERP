<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" AutoEventWireup="true" CodeFile="gen_Org_Approval.aspx.cs" Inherits="Master_gen_Org_Approval_Pending_gen_Org_ApprovalAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

    <style>
        .fillform {
            width: 100%;
        }
       
        .subform {
            float: left;
            margin-left: 38.8%;
        }
        .searchlist_btn_rght {
            padding: 3px 20px 3px 20px;
        }

    </style>
    
    <script type="text/javascript">
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

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="cont_rght">

        <div class="fillform">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <table style="line-height: 50px;" class="eachform">
                <tr style="height: 40px ! important;">
                    <td style="text-align: left; width: 17%;">

                        <h2>Organisation Type*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgType" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" Style="text-transform: uppercase" ReadOnly="true"></asp:TextBox>

                    </td>

                    <td style="text-align: left; width: 23%; padding-left: 2%;">
                        <h2>Organisation Name*</h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgName" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" Style="text-transform: uppercase" ReadOnly="true"></asp:TextBox>

                    </td>

                </tr>
                <tr style="height: 40px ! important;">

                    <td style="text-align: left; width: 17%;">
                        <h2>Address 1*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgAdd1" class="form1" runat="server" MaxLength="150" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                    </td>

                    <td style="text-align: left; width: 23%; padding-left: 2%;">
                        <h2>Address 2 </h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgAdd2" class="form1" runat="server" MaxLength="150" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                    </td>

                </tr>
                <tr style="height: 40px ! important;">

                    <td style="text-align: left; width: 17%;">
                        <h2>Address 3 </h2>
                    </td>
                    <td style="text-align: left; width: 32%;">

                        <asp:TextBox ID="txtOrgAdd3" class="form1" runat="server" MaxLength="150" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                    </td>


                    <td style="text-align: left; width: 23%; padding-left: 2%;">
                        <h2>Country*</h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgCountryName" class="form1" runat="server" MaxLength="250" Height="30px" Width="250px" Style="text-transform: uppercase" ReadOnly="true"></asp:TextBox>

                    </td>

                </tr>
                <tr style="height: 40px ! important;">

                    <td style="text-align: left; width: 17%;">
                        <h2>State </h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgStateName" class="form1" runat="server" MaxLength="250" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                    </td>

                    <td style="text-align: left; width: 23%; padding-left: 2%;">

                        <h2>City </h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgCityName" class="form1" runat="server" MaxLength="250" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>


                    </td>
                </tr>
                <tr style="height: 40px ! important;">

                    <td style="text-align: left; width: 17%;">
                        <h2>Zip Code </h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgZip" class="form1" runat="server" MaxLength="10" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                    </td>


                    <td style="text-align: left; width: 23%; padding-left: 2%;">
                        <h2>Phone </h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgPhone" class="form1" runat="server" MaxLength="50" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>


                    </td>
                </tr>
                <tr style="height: 40px ! important;">
                    <td style="text-align: left; width: 17%;">

                        <h2>Mobile*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgMobile" class="form1" runat="server" MaxLength="50" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                    </td>

                    <td style="text-align: left; width: 23%; padding-left: 2%;">
                        <h2>Website </h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgWebsite" class="form1" runat="server" MaxLength="100" Height="30px" ReadOnly="true" Width="250px"></asp:TextBox>

                    </td>

                </tr>
                <tr style="height: 40px ! important;">
                    <td style="text-align: left; width: 17%;">

                        <h2>Email*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgEmail" class="form1" runat="server" MaxLength="100" Height="30px" ReadOnly="true" Width="250px"></asp:TextBox>

                    </td>
                </tr>
                <tr style="height: 40px ! important;">
                    <td style="text-align: left; width: 17%;">

                        <h2>License Pack*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgLicPac" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>


                    </td>
                    <td style="text-align: left; width: 23%; padding-left: 2%;">

                        <h2>License Pack Count </h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgLicPacCount" class="form1" runat="server" MaxLength="4" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>


                    </td>
                </tr>
                <tr style="height: 40px ! important;">
                    <td style="text-align: left; width: 17%;">

                        <h2>Corporate Pack*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgCorPac" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>


                    </td>
                    <td style="text-align: left; width: 23%; padding-left: 2%;">

                        <h2>Corporate Pack Count </h2>
                    </td>
                    <td style="text-align: left; width: 28%;">
                        <asp:TextBox ID="txtOrgCorPacCount" class="form1" runat="server" MaxLength="2" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>


                    </td>
                </tr>
            </table>
            <br />

            <div style="padding-right: 2%;">

          
                <a href="gen_Org_ApprovalList.aspx">
                    <div class="searchlist_btn_rght">Back To Organisation Approval Pending List</div>
                </a>

            </div>
            <div>
            </div>
        </div>
    </div>
</asp:Content>
