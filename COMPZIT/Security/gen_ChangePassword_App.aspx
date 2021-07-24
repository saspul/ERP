<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_App.master" AutoEventWireup="true" CodeFile="gen_ChangePassword_App.aspx.cs" Inherits="MasterPage_Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
--%>

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
   
    <script  type="text/javascript">
        
        function PasswordClickMessageVisible()
        {
           
            document.getElementById('divPswMsg').style.visibility = "visible";
          
        }
        function PasswordClickMessageHidden() {
           
            document.getElementById('divPswMsg').style.visibility = "hidden";
          
        }

        function OnCbxChange()
        {
            
            var PwdWithoutReplace = document.getElementById("<%=txtNewPassword.ClientID%>").value;
            var PwdreplaceText1 = PwdWithoutReplace.replace(/</g, "");
            var PwdreplaceText2 = PwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNewPassword.ClientID%>").value = PwdreplaceText2;

            var ConPwdWithoutReplace = document.getElementById("<%=txtConfirmPssword.ClientID%>").value;
            var ConPwdreplaceText1 = ConPwdWithoutReplace.replace(/</g, "");
            var ConPwdreplaceText2 = ConPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtConfirmPssword.ClientID%>").value = ConPwdreplaceText2;

            var CurPwdWithoutReplace = document.getElementById("<%=txtCurrentPassword.ClientID%>").value;
            var CurPwdreplaceText1 = CurPwdWithoutReplace.replace(/</g, "");
            var CurPwdreplaceText2 = CurPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCurrentPassword.ClientID%>").value = CurPwdreplaceText2;
        }
    </script>
    






    <script type="text/javascript">

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



        function SuccessUpdation() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Password has been Successfully Changed.";
        }
        function CurrentPasswordWrong() {
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Current password entered is wrong, Please try again after entering correct password.";
            document.getElementById("<%=txtCurrentPassword.ClientID%>").style.borderColor = "red";
            document.getElementById("<%=txtCurrentPassword.ClientID%>").focus();
        }

        function Validate() {

            var ret = true;
            if (CheckIsRepeat() == true) {
            }
            else {
                ret = false;
                return ret;
            }


            var PwdWithoutReplace = document.getElementById("<%=txtNewPassword.ClientID%>").value;
            var PwdreplaceText1 = PwdWithoutReplace.replace(/</g, "");
            var PwdreplaceText2 = PwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtNewPassword.ClientID%>").value = PwdreplaceText2;

            var ConPwdWithoutReplace = document.getElementById("<%=txtConfirmPssword.ClientID%>").value;
            var ConPwdreplaceText1 = ConPwdWithoutReplace.replace(/</g, "");
            var ConPwdreplaceText2 = ConPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtConfirmPssword.ClientID%>").value = ConPwdreplaceText2;

            var CurPwdWithoutReplace = document.getElementById("<%=txtCurrentPassword.ClientID%>").value;
            var CurPwdreplaceText1 = CurPwdWithoutReplace.replace(/</g, "");
            var CurPwdreplaceText2 = CurPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtCurrentPassword.ClientID%>").value = CurPwdreplaceText2;


            var CurrentPwd = document.getElementById("<%=txtCurrentPassword.ClientID%>").value;
            var NewPwd = document.getElementById("<%=txtNewPassword.ClientID%>").value;
            var ConfirmPwd = document.getElementById("<%=txtConfirmPssword.ClientID%>").value;

            var minNumberofChars = 6;
            var maxNumberofChars = 16;
           //var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[a-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/;
            var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[A-Za-z]).{6,16}/;
            document.getElementById("<%=txtCurrentPassword.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtConfirmPssword.ClientID%>").style.borderColor = "";

            if (CurrentPwd == "" || NewPwd == "" || ConfirmPwd == "" || NewPwd.length < minNumberofChars
                || NewPwd.length > maxNumberofChars || !regularExpression.test(NewPwd) || ConfirmPwd != NewPwd) {
                //ret = false;

                if (CurrentPwd == "") {
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                    document.getElementById("<%=txtCurrentPassword.ClientID%>").style.borderColor = "Red";
                     document.getElementById("<%=txtCurrentPassword.ClientID%>").focus();
                     ret = false;

                 }
               
                else if (NewPwd == "") {
                    
                    document.getElementById('divErrorTotal').style.visibility = "visible";
                    document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                        document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "Red";
                    
                    document.getElementById("<%=txtNewPassword.ClientID%>").focus();
                        ret = false;
                    }
               else  if (ConfirmPwd == "") {
                    
                        document.getElementById('divErrorTotal').style.visibility = "visible";
                        document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                        document.getElementById("<%=txtConfirmPssword.ClientID%>").style.borderColor = "Red";
                    
                    document.getElementById("<%=txtConfirmPssword.ClientID%>").focus();
                        ret = false;
                }
               
                   else if (NewPwd.length < minNumberofChars || NewPwd.length > maxNumberofChars) {
                        
                        document.getElementById('divErrorTotal').style.visibility = "visible";
                        document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Password Must Contain 6-16 Characters with atleast one number,special character and alphabet";
                        document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "Red";
                        document.getElementById("<%=txtNewPassword.ClientID%>").focus();
                        ret = false;
                    }
               else if (!regularExpression.test(NewPwd)) {
                 
                        document.getElementById('divErrorTotal').style.visibility = "visible";
                        document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Password Must Contain 6-16 Characters with atleast one number,special character and alphabet";
                        var OrgPwdFocus = document.getElementById("<%=txtNewPassword.ClientID%>").focus();
                        document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "Red";
                    
                    ret = false;
                    }
                else if (ConfirmPwd != NewPwd) {
                 
                        var ErrorMsg = document.getElementById('divErrorTotal').style.visibility = "visible";
                        document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Sorry, New Password and Confirm Password should match!";
                        var OrgConPwdFocus = document.getElementById("<%=txtConfirmPssword.ClientID%>").focus();
                        document.getElementById("<%=txtConfirmPssword.ClientID%>").style.borderColor = "Red";
                        ret = false;
                    }

                   
                }

            if (ret == false) {
                CheckSubmitZero();

            }
            if (ret == true) {
                ShowLoading();
            }
            return ret;
            }
    </script>


    <script type="text/javascript">
        function controlEnter(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 13) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }
        function controlTab(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }
        function controlTabEnter(obj, event) {
            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if (keyCode == 9) {
                document.getElementById(obj).focus();
                return false;
            }
            else if (keyCode == 13) {
                document.getElementById(obj).focus();
                return false;
            }

            else {
                return true;
            }
        }
    </script>

     <!--0006-->
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("myModalLoadingMail").style.display = "none";

            document.getElementById("freezelayer").style.display = "none";
        });
    </script>
    <script>
        function ShowLoading() {

            document.getElementById("myModalLoadingMail").style.display = "block";

            document.getElementById("freezelayer").style.display = "";
        }
        function HideLoading() {
            document.getElementById("myModalLoadingMail").style.display = "none";

            document.getElementById("freezelayer").style.display = "none";
        }
    </script>

    <style>
        #divErrorTotal {
            border-radius: 20px;
            background: #FFFFCC;
            padding: 15px;
        }
    </style>


  
    <style>
          .modalLoadingMail {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 30; /* Sit on top */
            padding-top: 19%; /* Location of the box */
            left: 0;
            top: 0;
            width: 90%; /* Full width */
            /*height: 58%;*/ /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: transparent;
            padding-left: 45%; /* Location of the box */
        }

        #divPswMsg {
            display: table-cell;
            position: absolute;
            box-sizing: content-box;
            height: 0;
            margin-left: 54.29%;
            margin-top: 2.5%;
            /*margin-bottom: -8px;*/
            cursor: help;
            width: 235px;
            word-break: break-all;
            word-wrap: break-word;
            padding: 4px 5px;
            background: #bbb;
            color: #fff;
            font-weight: 600;
            font-size: 12px;
            /*line-height: 16px;*/
            font-family: Calibri;
             margin-bottom: 0;
            height: auto;
            visibility: visible;
        }
    </style>

    <style>
        .fillform {
            width: 74%;
        }

        .subform {
            float: left;
            margin-left: 38%;
            padding-left: 2%;
        }

        /**/

        /*.aspNetDisabled {
            margin-left: -31%;
        }*/


        /*input[type=text][disabled="disabled"] {
            margin-left: 28% !important;
            height: 30px !important;
        }*/

        .aspNetDisabled {
            margin-left: 31%;
        }


        input[type=text][disabled="disabled"] {
            margin-left: 30% !important;
            height: 30px !important;
            float: right;
        }

        select[disabled="disabled"] {
            margin-left: 29.7% !important;
            width: 358px!important;
            height: 30px !important;
        }
         .leads_form {

            padding: 7% 10% 3%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

    <div class="cont_rght">


        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>


        <br />
        <br />
        <br />


        <div class="fillform">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
                  <div class="leads_form">
            <div class="eachform">

                <h2>Current Password*  </h2>
                <asp:TextBox ID="txtCurrentPassword" class="form1" Height="30px" Width="350px" runat="server" MaxLength="16" Style="margin-left: 15%;"></asp:TextBox>

            </div>

            <div class="eachform">

                <h2>New Password*</h2>
                <asp:TextBox ID="txtNewPassword" class="form1" Height="30px" Width="350px" runat="server" MaxLength="16" OnFocus="PasswordClickMessageVisible();" Onblur="PasswordClickMessageHidden();" ></asp:TextBox>
                <div id="divPswMsg" style ="visibility:hidden;">
                       Password Must Contain 6-16 Characters with atleast one number, special character & alphabet
                      </div>

            </div>

            <div class="eachform">

                <h2>Confirm Password*      </h2>
                <asp:TextBox ID="txtConfirmPssword" class="form1" Height="30px" Width="350px" runat="server" MaxLength="16" Style="margin-left: 15%;"></asp:TextBox>

            </div>


            <div class="eachform" style="margin-left: 83%; width:50%">
                <h2>Show Password</h2>
                <asp:CheckBox ID="cbxPswdVisible" runat="server" AutoPostBack="True" OnCheckedChanged="cbxMakeVisible_CheckedChanged" OnChange="OnCbxChange();"/>

            </div>
                      
  </div>



            <br />
            <div class="eachform">
                <div class="subform">


                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnCancel" runat="server" class="save" Text="Cancel" PostBackUrl="/Home/Compzit_Home/Compzit_Home_App.aspx" />



                </div>
            </div>


        </div>
  <!--0006-->  <!-- The Modal Loading MAIL -->
            <div id="myModalLoadingMail" class="modalLoadingMail">
                   
                <!-- Modal content -->
                <div >
                 
                          <img src="../../Images/Other Images/LoadingMail.gif" style="width:12%;"  />

                    
                </div>

            </div>
           

            <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
            </div>
            <%--test modal stop--%>

    </div>


</asp:Content>
