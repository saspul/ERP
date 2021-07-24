<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit.master" AutoEventWireup="true" CodeFile="gen_ResetPassword.aspx.cs" Inherits="MasterPage_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
 <script src="/css/New%20Plugins/libs/jquery-2.1.1.min.js"></script>
 <script src="/js/Common/Common.js"></script>
 <link href="/css/New css/pro_mng.css" rel="stylesheet" />
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
     <script language="javascript" type="text/javascript">
       //start-0006
         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 ezBSAlert({
                     type: "confirm",
                     messageText: "Do you want to leave this page?",
                     alertType: "info"
                 }).done(function (e) {
                     if (e == true) {
                         window.location.href = "gen_ResetPasswordList.aspx";
                         return false;
                     }
                     else {
                         return false;
                     }
                 });
                 return false;
             }
             else {
                 window.location.href = "gen_ResetPasswordList.aspx";

             }
             return false;
         }
         //stop-0006
    </script>
    <script>
        function onChangePwd() {

            IncrmntConfrmCounter();
            if (document.getElementById("<%= cbxPswdVisible.ClientID %>").checked == true) {
              //  alert('dds');
                document.getElementById("<%= txtNewPassword.ClientID %>").type = 'text';
                document.getElementById("<%= txtConfirmPssword.ClientID %>").type = 'text';

            }
            else {
            //    alert('sukh');
                document.getElementById("<%= txtNewPassword.ClientID %>").type = 'password';
                document.getElementById("<%= txtConfirmPssword.ClientID %>").type = 'password';

            }
            return false;
        }
    </script>

    <script type="text/javascript">

        Sys.Application.add_load(MyName);
        function MyName(sender) {
            $get('<%= divName.ClientID %>').innerHTML += "";
        }
        Sys.Application.add_load(MyMail);
        function MyMail(sender) {
            $get('<%= divMail.ClientID %>').innerHTML += "";
        }

        function SuccessUpdation() {
            $("#success-alert").html("Password has been reset successfully.");
            $("#success-alert").fadeTo(3000, 500).slideUp(500, function () {
            });
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


            var NewPwd = document.getElementById("<%=txtNewPassword.ClientID%>").value;

            var ConfirmPwd = document.getElementById("<%=txtConfirmPssword.ClientID%>").value;

            var minNumberofChars = 6;
            var maxNumberofChars = 16;

            
         //var regularExpression = /(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/; 
       //     var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[a-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/; //new
            var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[A-Za-z]).{6,16}/; //new TEST
            


            document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "";
                document.getElementById("<%=txtConfirmPssword.ClientID%>").style.borderColor = "";
        
            if (NewPwd == "" || ConfirmPwd == "" || NewPwd.length < minNumberofChars
                || NewPwd.length > maxNumberofChars || !regularExpression.test(NewPwd) || ConfirmPwd != NewPwd)
            {
                
                if (NewPwd == "") {
                    
                    $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                    $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                    });
                 
                    document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNewPassword.ClientID%>").focus();
                    
                    ret = false;
                }
              else  if (ConfirmPwd == "") {
                    
                  $("#divWarning").html("Some of the information you entered is not correct or missing. Please check the highlighted fields below.");
                  $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                  });

                    document.getElementById("<%=txtConfirmPssword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtConfirmPssword.ClientID%>").focus();
                    ret = false;
                }
               else if (NewPwd.length < minNumberofChars || NewPwd.length > maxNumberofChars) {

                   $("#divWarning").html("Password must contain 6-16 characters with atleast one number, special character and alphabet");
                   $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                   });
                   
                    document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtNewPassword.ClientID%>").focus();
                    ret = false;
                }
             else   if (!regularExpression.test(NewPwd)) {
                 $("#divWarning").html("Password must contain 6-16 characters with atleast one number, special character and alphabet");
                 $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                 });
                    var OrgPwdFocus = document.getElementById("<%=txtNewPassword.ClientID%>").focus();
                    document.getElementById("<%=txtNewPassword.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
              else  if (ConfirmPwd != NewPwd) {
                  $("#divWarning").html("Sorry, New password and confirm password should match!");
                  $("#divWarning").fadeTo(3000, 500).slideUp(500, function () {
                  });
                    var OrgConPwdFocus = document.getElementById("<%=txtConfirmPssword.ClientID%>").focus();
                    document.getElementById("<%=txtConfirmPssword.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
               
            }
            if (ret == false) {
                CheckSubmitZero();

            }
            if (ret == true) {
                //ShowLoading();
            }
            return ret;

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
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
        });
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">

      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:HiddenField ID="hiddenUserId" runat="server" />
     <asp:HiddenField ID="hiddenOldPassword" runat="server" />

     <div class="myAlert-top alert alert-success" id="success-alert">
    </div>
    <div class="myAlert-bottom alert alert-danger" id="divWarning">
    </div>

  <ol class="breadcrumb">
    <li><a href="/Home/Compzit_LandingPage/Compzit_LandingPage.aspx">Home</a></li>
    <li><a href="/Home/Compzit_Home/Compzit_Home_App.aspx">App Administration</a></li>
    <li class="active">Reset Password</li>
  </ol>

  <div class="content_sec2 cont_contr">
    <div class="content_area_container cont_contr">
      
      <div class="content_box1 cont_contr" onmouseover="closesave()">
        <h2>Reset Password</h2>
        
        <div class="fg12">
          <span class="sp_2">
            <span class="sp_1 sp_bo pa_r1">Employee Name
            <span class="flt_r">:</span></span>
            <span class="sp_4 tr_l sp_b" runat="server" id="divName"></span>
          </span>
        </div><br>
        <div class="fg12">
          <span class="sp_2">
            <span class="sp_1 sp_bo pa_r1">Email ID
            <span class="flt_r">:</span></span>
            <span class="sp_4 sp_b" runat="server" id="divMail"></span>
          </span>
        </div>

        <div class="clearfix"></div>
        <div class="free_sp"></div>

        <div class="form-group fg4 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">New Password:<span class="spn1">*</span></label>
          <input autocomplete="new-password" id="txtNewPassword" runat="server" maxlength="16" type="password" class="form-control fg2_inp1 inp_mst" placeholder="New Password" name=""/>
            <div class='form-tooltip'>Password Must Contain 6-16 Characters with atleast one number, special character & alphabet</div>
        </div>
        <div class="form-group fg4 sa_640_i1 sa_480">
          <label for="email" class="fg2_la1">Confirm Password:<span class="spn1">*</span></label>
          <input autocomplete="new-password" onpaste="return false" id="txtConfirmPssword"  runat="server" maxlength="16" type="Password" class="form-control fg2_inp1 inp_mst" placeholder="Confirm Password" name=""/>
        </div>

        <div class="fg4 sa_fg4 sa_640_i">
          <label for="email" class="fg2_la1 pad_l">Show Password:<span class="spn1"></span></label>
          <div class="check1">
            <div class=" tr_l">
              <label class="switch">
                <input  type="checkbox" id="cbxPswdVisible"  runat="server" onchange="return onChangePwd();" >
                <span class="slider_tog round"></span>
              </label>
            </div>
          </div>
        </div>
             
        <div class="clearfix"></div>
        <div class="free_sp"></div>
        <div class="devider"></div>

        <div class="sub_cont pull-right">
          <div class="save_sec">
               <asp:Button ID="btnReset" runat="server" class="btn sub1" Text="Reset" OnClick="btnReset_Click" OnClientClick="return Validate();" />
                <asp:Button ID="btnCancel" runat="server" class="btn sub4" Text="Cancel" OnClientClick="return ConfirmMessage();" />
          </div>
        </div>
           
      </div>
       </div>
      </div>

    <div class="mySave1" id="mySave" runat="server">
  <div class="save_sec">

       <asp:Button ID="btnResetF" runat="server" class="btn sub1 bt_b" Text="Reset" OnClick="btnReset_Click" OnClientClick="return Validate();" />
                <asp:Button ID="btnCancelF" runat="server" class="btn sub4 bt_b" Text="Cancel" OnClientClick="return ConfirmMessage();" />
        </div>
        </div>
<a href="#" onmouseover="opensave()" type="button" class="save_b" title="Save">
<i class="fa fa-save"></i>
</a>

       <!---back_button_fixed_section--->
  <a href="#" type="button" class="list_b" title="Back to List" onclick="return ConfirmMessage();" id="A1" runat="server">
    <i class="fa fa-arrow-circle-left"></i>
  </a>
<!---back_button_fixed_section--->
  <!--save_pop up_open-->
<script>
    function opensave() {
        document.getElementById("cphMain_mySave").style.width = "140px";
    }

    function closesave() {
        document.getElementById("cphMain_mySave").style.width = "0px";
    }
</script>

    <style>
          .form-tooltip {
            display: table-cell;
            visibility: hidden;
            position: absolute;
              box-sizing: content-box;
              height: 0;
              margin-left: 31%;
              margin-top: 4.2%;
              /*margin-bottom: -8px;*/
              cursor: help;
              width: 365px;
              word-break: break-all;
              word-wrap: break-word;
              padding: 4px 5px;
              background: #bbb;
              color: #fff;
              font-weight: 600;
              font-size: 12px;
              /*line-height: 16px;*/
              font-family: Calibri;
          }

        :focus + .form-tooltip {
            margin-bottom: 0;
            height: auto;
            visibility: visible;
        }
        </style>

</asp:Content>

