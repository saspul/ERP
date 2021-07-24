<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Min.master" CodeFile="gen_Org_Verification.aspx.cs" Inherits="Master_gen_Org_Verification_OrgVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">

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
    </script>
    <style>
        .fillform {
            width: 100%;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }

        #cphMain_divWait {
            border-radius: 20px;
            background: #F0F0ED;
            padding: 12px;
            width: 100%;
            text-align: center;
            font-family:Calibri;
        }
    </style>
    <script type="text/javascript" language="javascript">
        // for not allowing <> tags
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

        function ValidateSubmit() {
            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtVerification.ClientID%>").value.trim();
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtVerification.ClientID%>").value = replaceText2;

            var VerificationCode = document.getElementById("<%=txtVerification.ClientID%>").value;
            document.getElementById('divErrorTotal').style.visibility = "hidden";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "";
            document.getElementById("<%=txtVerification.ClientID%>").style.borderColor = "";
         
            //   document.getElementById('txtOrgMailID').style.borderColor = "";
            if (VerificationCode == "") {
                // alert('Some of the information you entered is not correct or missing. Please check the highlighted fields below.');
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtVerification.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtVerification.ClientID%>").focus();

                ret= false;
            }
         
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }
        function Validate() {

            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtOrgMailID.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgMailID.ClientID%>").value = replaceText2;

            var OrgMailId = document.getElementById("<%=txtOrgMailID.ClientID%>").value.trim();
            document.getElementById("<%=txtOrgMailID.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtVerification.ClientID%>").style.borderColor = "";
            document.getElementById('divErrorTotal').style.visibility = "hidden";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "";

            if (OrgMailId == "") {
                // alert('Some of the information you entered is not correct or missing. Please check the highlighted fields below.');
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtOrgMailID.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtOrgMailID.ClientID%>").focus();

                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="cont_rght">

       
        <div class="fillform">

             <div id="divErrorTotal" style="visibility: hidden;width: 100%;">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <br />

           
                <div id="divWait" runat="server">
                    <asp:Label ID="Label2" runat="server"> Please do not Refresh the Page while Verification is on Process  </asp:Label>

                </div>
                <br />
       

            <div class="eachform" style="font-family:Calibri">
                <asp:Label ID="lblVerificationMsg" runat="server" Text="Label" Visible="false" ></asp:Label>

                <br />
                <br />
                <br />


            </div>
            <div id="divAppAdmin" runat="server" >

                <div class="eachform" >



                    <div>
                        <table style="text-align: right; width: 100%">
                            <tr>

                                <td style="width: 42%;">
                                    <h2>Enter Registered MailID of Organization:</h2>
                                </td>

                                <td style="width: 48%;">
                                    <asp:TextBox ID="txtOrgMailID" class="form1" runat="server" MaxLength="100" Height="30px" Width="350px"></asp:TextBox>
                                </td>
                                <td style="width: 10%; text-align: left">
                                    <div style="height: 35px;">
                                        <asp:ImageButton ID="ibtnMail" runat="server" src="/Images/Icons/mail.png"  OnClick="ibtnMail_Click" OnClientClick="return Validate();" /></div>
                                </td>
                            </tr>

                        </table>

                    </div>

                </div>

            </div>




          
              
                    <div id="divVerification" runat="server" class="eachform" style="margin-left: 3px; width: 89.5%; font-family:Calibri;">
                     <%--   <asp:Label ID="lblVefCaption" runat="server" Text="Please Enter Your Verification Code *" Font-Bold="true"></asp:Label>--%>
                          <h2>Please Enter Your Verification Code*</h2>
                        
                            <asp:TextBox ID="txtVerification" class="form1" Height="30px" Width="350px" runat="server" MaxLength="11"></asp:TextBox>
                      
                        <p class="error" id="ErrorMsgCountryName" style="visibility: hidden">Please Enter The Code</p>
                    </div>
              
             <br />
          <br />
            <div class="eachform">
                <div class="subform">
                    
                        <asp:Button ID="btnAdd" runat="server" class="save" Text="Submit" OnClick="btnAdd_Click" OnClientClick="return ValidateSubmit();" />
                  
                </div>
            </div>

        </div>
    </div>
</asp:Content>

