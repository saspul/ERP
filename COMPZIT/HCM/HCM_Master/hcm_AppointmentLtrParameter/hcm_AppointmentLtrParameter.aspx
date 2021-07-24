<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_AppointmentLtrParameter.aspx.cs" Inherits="HCM_HCM_Master_hcm_AppointmentLtrParameter_hcm_AppointmentLtrParameter" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        .div-Contact-details {
            
       /*border: 1px solid #cad1be;
            padding: 1% 2% 3% 2%;
            margin-top: 0%;
            display: block;
            
            width: 100%;*/
       padding: 1% 2% 3% 2%;
       min-height: 104px;
border: .5px solid;
border-color: #9ba48b;
background-color: #f3f3f3;
width: 100%;
margin-top: 0%;        }
        .eachform {
    width: 100%;
    display: inline-block;
    margin: 0 0 6px;
}

              .error {
               padding-top: 7%;
               padding-left: 29%;
               color: red;
               font-size: small;
                margin-left: 8%;
                font-family: Calibri;
           }
    </style>
    <script type="text/javascript">
        var confirmbox = 0;
        function IncrmntConfrmCounter() {
            confirmbox++;
        }

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

        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Appointment Letter Parameter inserted successfully.";
            document.getElementById("<%=txtCnsltyName.ClientID%>").focus();
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function DuplicateAppointmentLetter_ParameterName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Appointment Letter Parameter name can’t be duplicated.";

            document.getElementById("<%=txtCnsltyName.ClientID%>").focus();
            document.getElementById("<%=txtCnsltyName.ClientID%>").style.borderColor = 'Red';
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Appointment Letter Parameter updated successfully.";
            document.getElementById("<%=txtCnsltyName.ClientID%>").focus();
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function ErrMsg() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        </script>
      <script type="text/javascript" language="javascript">

          // for not allowing <> tags
          function isTag(evt) {
              IncrmntConfrmCounter();
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
          function isTagWithEnter(evt) {
              IncrmntConfrmCounter();
              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              var ret = true;
              if (charCode == 60 || charCode == 62) {
                  ret = false;
              }
              return ret;
          }
          // for not allowing enter
          function DisableEnter(evt) {
              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              if (keyCodes == 13) {
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
          function ConfirmMessage() {
              if (confirmbox > 0) {
                  if (confirm("Are you sure you want to leave this page?")) {
                      window.location.href = "hcm_AppointmentLtrParameterList.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  window.location.href = "hcm_AppointmentLtrParameterList.aspx";
                  return false;
              }
          }
          function ConfirmClear() {
              if (confirmbox > 0) {
                  if (confirm("Are You Sure You Want To Clear?")) {
                      window.location.href = "hcm_AppointmentLtrParameter.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  window.location.href = "hcm_AppointmentLtrParameter.aspx";
                  return false;
              }
          }
          function validateAppointment_Letter_Parameter() {
              ret = true;
              //document.getElementById('divMessageArea').style.display = "none";
              document.getElementById("<%=txtCnsltyName.ClientID%>").style.borderColor = '';
              document.getElementById("<%=txtDescription.ClientID%>").style.borderColor = '';
                 

       
                  // replacing < and > tags
                  var NameWithoutReplace = document.getElementById("<%=txtCnsltyName.ClientID%>").value.trim();
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtCnsltyName.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtDescription.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtDescription.ClientID%>").value = replaceText2;

               
                  //name and email fields 
              var ConsltName = document.getElementById("<%=txtCnsltyName.ClientID%>").value.trim();
              var Description = document.getElementById("<%=txtDescription.ClientID%>").value.trim();
               

              if (Description == "") {
                  document.getElementById("<%=txtDescription.ClientID%>").focus();
                    document.getElementById("<%=txtDescription.ClientID%>").style.borderColor = 'Red';
                    ret = false;
                }
               
                  if (ConsltName == "") {
                      document.getElementById("<%=txtCnsltyName.ClientID%>").focus();
                      document.getElementById("<%=txtCnsltyName.ClientID%>").style.borderColor = 'Red';
                      ret = false;
                  }

             

                  if (ret == false) {
                      ErrMsg();
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
              function isNumber(evt) {
                  evt = (evt) ? evt : window.event;
                  var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
                  var charCode = (evt.which) ? evt.which : evt.keyCode;
                  //enter
                  if (keyCodes == 13) {
                      // return false;
                  }
                      //0-9
                  else if (keyCodes >= 48 && keyCodes <= 57) {
                      return true;
                  }
                      //numpad 0-9
                  else if (keyCodes >= 96 && keyCodes <= 105) {
                      return true;
                  }
                      //left arrow key,right arrow key,home,end ,delete,UP ARROW ,DOWN ARROW
                  else if (keyCodes == 37 || keyCodes == 39 || keyCodes == 36 || keyCodes == 35 || keyCodes == 46 || keyCodes == 38 || keyCodes == 40) {
                      return true;

                  }
                  else {
                      var ret = true;
                      if (charCode > 31 && (charCode < 48 || charCode > 57)) {


                          ret = false;
                      }
                      return ret;
                  }
              }
              function removeSpclChrcter(obj) {

                  var txt = document.getElementById(obj).value;


                  if (txt != "") {

                      if (isNaN(txt)) {
                          document.getElementById(obj).value = "";
                          document.getElementById(obj).focus();
                          return false;

                      }
                      else {
                          var specialChars = "!@#$^&%*()+=-[]\/{}|:<>?,.";
                          if (!specialChars.test(txt)) {
                              document.getElementById(obj).value = "";

                              return false;
                          }
                      }


                  }

              }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="HiddenConsultancyId" runat="server" />
      <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
      <div class="cont_rght">


        <div id="divErrorTotal" style="visibility: hidden">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <br />

          <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="position:fixed; right:5%; top:42%; height:26.5px;">

            <%-- <a href="gen_Product_MasterList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div style="width: 100%;">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
            <br />
            <br />
          
            <div class="eachform" style="width:47%; float:left;">
                <h2 style="margin-top: 1%;">Parameter Name*</h2>

                <asp:TextBox ID="txtCnsltyName" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase; " onkeypress="return isTag(event);" ></asp:TextBox>


            </div>
            <div class="eachform" style="width:47%; padding-left:6%;margin-top: 1%;">
               <h2>Status*</h2>

               <div class="subform" style=" margin-left: 0%;">
                    <asp:CheckBox ID="cbStatus" Text="" runat="server" onchange="IncrmntConfrmCounter();" onkeydown="return DisableEnter(event);" Checked="true" class="form2" />

                    <h3>Active</h3>

                </div>

            </div>
            
       
           <%-- <div class="eachform" style="width:47%; float:left;">
                <h2>Registration Status </h2>
<div class="subform" >
                    <asp:CheckBox ID="CheckBox1" style="float:left;" Text="" runat="server" Checked="true" class="form2" />

                    <h3>Registered</h3>

                </div>

            </div>--%>
           
            <div class="eachform" style="width:100%; float:left;margin-top: 2%;">
                <h2 style="margin-top: 1%;">Description*</h2>

              <asp:TextBox ID="txtDescription"  class="form1" Height="80px" Width="80.8%" style="float:right;resize:none;font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);"  onkeydown="textCounter(cphMain_txtDescription,950);" onkeyup="textCounter(cphMain_txtDescription,950);" onblur="textCounter(cphMain_txtDescription,950);"  ></asp:TextBox>


            </div>
              
             
            
 
                 
            
                   
            <br />
            <div class="eachform" style="margin-top: 3%;">
                <div class="subform" style="width: 60%;">

                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnAdd_Click" OnClientClick="return validateAppointment_Letter_Parameter();" />
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close"  OnClick="btnAdd_Click" OnClientClick="return validateAppointment_Letter_Parameter();" />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClientClick="return validateAppointment_Letter_Parameter();" OnClick="btnAdd_Click" />
                  <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close"  OnClick="btnAdd_Click"  OnClientClick="return validateAppointment_Letter_Parameter();" />
                     <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                       <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                </div>
            </div>


        </div>
    </div>
</asp:Content>

