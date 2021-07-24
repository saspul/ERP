<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Consultancy_Master.aspx.cs" Inherits="HCM_HCM_Master_gen_Consultancy_Master_gen_Consultancy" %>

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
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Consultancy details inserted successfully.";
            document.getElementById("<%=txtCnsltyName.ClientID%>").focus();
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function DuplicateConsultancyName() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!. Consultancy name can’t be duplicated.";

            document.getElementById("<%=txtCnsltyName.ClientID%>").focus();
            document.getElementById("<%=txtCnsltyName.ClientID%>").style.borderColor = 'Red';
            var $Mo = jQuery.noConflict();
            $Mo(window).scrollTop(0);
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Consultancy details updated successfully.";
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
                      window.location.href = "gen_Consultancy_MasterList.aspx";
                      return false;
                  }
                  else {
                      return false;
                  }
              }
              else {
                  window.location.href = "gen_Consultancy_MasterList.aspx";
                  return false;
              }
          }
              function ConfirmClear() {
                  if (confirmbox > 0) {
                      if (confirm("Are You Sure You Want To Clear?")) {
                          window.location.href = "gen_Consultancy_Master.aspx";
                          return false;
                      }
                      else {
                          return false;
                      }
                  }
                  else {
                      window.location.href = "gen_Consultancy_Master.aspx";
                      return false;
                  }
              }
              function validateConsultancy() {
                  ret = true;
                  //document.getElementById('divMessageArea').style.display = "none";
                  document.getElementById("<%=txtCnsltyName.ClientID%>").style.borderColor = '';
                  document.getElementById("<%=txtCnsltyEmail.ClientID%>").style.borderColor = '';
                  document.getElementById("<%=txtCntctEmail.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=txtCntctMobile.ClientID%>").style.borderColor = "";
                  document.getElementById("<%=txtCnsltyPhone.ClientID%>").style.borderColor = "";

                  document.getElementById('ErrorMsgMob').style.display = "none";
                  document.getElementById('ErrorMsgEmail').style.display = "none";
                  document.getElementById('ErrorContctMsgEmail').style.display = "none";
                  document.getElementById('ErrorMsgMobcontct').style.display = "none";
                  // replacing < and > tags
                  var NameWithoutReplace = document.getElementById("<%=txtCnsltyName.ClientID%>").value.trim();
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtCnsltyName.ClientID%>").value = replaceText2;
                  
                  var NameWithoutReplace = document.getElementById("<%=txtAddress.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtAddress.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtLocation.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtLocation.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtRegistrationNo.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtRegistrationNo.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtCnsltyEmail.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtCnsltyEmail.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtCnsltyPhone.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtCnsltyPhone.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtCntctName.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtCntctName.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtCntctEmail.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtCntctEmail.ClientID%>").value = replaceText2;

                  var NameWithoutReplace = document.getElementById("<%=txtCntctMobile.ClientID%>").value;
                  var replaceText1 = NameWithoutReplace.replace(/</g, "");
                  var replaceText2 = replaceText1.replace(/>/g, "");
                  document.getElementById("<%=txtCntctMobile.ClientID%>").value = replaceText2;
                  //name and email fields 
                  var ConsltName = document.getElementById("<%=txtCnsltyName.ClientID%>").value.trim();
                  var ConsltEmail = document.getElementById("<%=txtCnsltyEmail.ClientID%>").value;
                  var ContactEmail = document.getElementById("<%=txtCntctEmail.ClientID%>").value;
                  var Phone= document.getElementById("<%=txtCnsltyPhone.ClientID%>").value;
                  var Mobile = document.getElementById("<%=txtCntctMobile.ClientID%>").value;
                 
                  var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

                  var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                  
                  if (Phone.length != 0) {
                      if (!mobileregular.test(Phone)) {
                           document.getElementById("<%=txtCnsltyPhone.ClientID%>").focus();
                          document.getElementById("<%=txtCnsltyPhone.ClientID%>").style.borderColor = "Red";
                          document.getElementById('ErrorMsgMob').style.display = "";
                          var OrgMobileFocus = document.getElementById("<%=txtCnsltyPhone.ClientID%>").focus();
                           ret = false;
                       }
                  }
                  if (Mobile.length != 0) {
                      if (!mobileregular.test(Mobile)) {
                          document.getElementById("<%=txtCntctMobile.ClientID%>").focus();
                          document.getElementById("<%=txtCntctMobile.ClientID%>").style.borderColor = "Red";

                          document.getElementById('ErrorMsgMobcontct').style.display = "";
                          
                          // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number";
                          var OrgMobileFocus = document.getElementById("<%=txtCntctMobile.ClientID%>").focus();
                           ret = false;
                       }
                  }
                  if ((!filter.test(ContactEmail)) && (ContactEmail != "")) {

                      document.getElementById("<%=txtCntctEmail.ClientID%>").focus();
                      document.getElementById("<%=txtCntctEmail.ClientID%>").style.borderColor = "Red";
                      
                      document.getElementById('ErrorContctMsgEmail').style.display = "";
                      var OrgMobileFocus = document.getElementById("<%=txtCntctEmail.ClientID%>").focus();
                        ret = false;
                    }
                  if ((!filter.test(ConsltEmail)) && (ConsltEmail != "")) {

                      document.getElementById("<%=txtCnsltyEmail.ClientID%>").focus();
                      document.getElementById("<%=txtCnsltyEmail.ClientID%>").style.borderColor = "Red";
                      document.getElementById('ErrorMsgEmail').style.display = "";
                      var OrgMobileFocus = document.getElementById("<%=txtCnsltyEmail.ClientID%>").focus();
                        ret = false;
                  }
                  if (ConsltEmail == "") {
                      document.getElementById("<%=txtCnsltyEmail.ClientID%>").focus();
                       document.getElementById("<%=txtCnsltyEmail.ClientID%>").style.borderColor = 'Red';
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
                <h2 style="margin-top: 1%;">Consultancy Name*</h2>

                <asp:TextBox ID="txtCnsltyName" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase; " onkeypress="return isTag(event);" ></asp:TextBox>


            </div>
            <div class="eachform" style="width:47%; padding-left:6%">
                <h2 style="margin-top: 1%;">Consultancy Type</h2>

              <asp:DropDownList ID="ddlCnsltyType" Height="30px" Width="294px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server" ></asp:DropDownList>


            </div>
            
          <div style="float:left;width:100%">
            <div class="eachform" style="width:47%; float:left;">
                <h2 style="margin-top: 1%;">Email*</h2>
                  <asp:TextBox ID="txtCnsltyEmail" Height="30px" Width="275px" class="form1" runat="server" MaxLength="25" onkeypress="return isTag(event);"  Style=" "></asp:TextBox>
                    <p class="error" id="ErrorMsgEmail" style="display:none">Please enter valid email id</p>

            </div>
             
              <div class="eachform" style="width:47%; padding-left:6%">
                <h2 style="margin-top: 1%;">Phone number</h2>

                               <asp:TextBox ID="txtCnsltyPhone" onblur="return removeSpclChrcter('cphMain_txtCnsltyPhone')" Height="30px" Width="275px" class="form1" runat="server" MaxLength="25" Style="text-transform: uppercase; " onkeydown="return isNumber(event)" onkeypress="return isTag(event);" ></asp:TextBox>
                     <p class="error" id="ErrorMsgMob" style="display:none">Please enter valid mobile number</p>

            </div>
                 </div>
                     <div class="eachform" style="width:47%; float:left;">
                <h2 style="margin-top: 1%;">Country</h2>

              <asp:DropDownList ID="ddlCountry" Height="30px" Width="294px" class="form1" onchange="IncrmntConfrmCounter();" onkeypress="return DisableEnter(event);" runat="server" ></asp:DropDownList>


            </div>
             <div class="eachform" style="width:47%; padding-left:6%">
                <h2 style="margin-top: 1%;">Location</h2>

                <asp:TextBox ID="txtLocation" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase; " onkeypress="return isTag(event);" ></asp:TextBox>


            </div>
               
           <%-- <div class="eachform" style="width:47%; float:left;">
                <h2>Registration Status </h2>
<div class="subform" >
                    <asp:CheckBox ID="CheckBox1" style="float:left;" Text="" runat="server" Checked="true" class="form2" />

                    <h3>Registered</h3>

                </div>

            </div>--%>
           
            <div class="eachform" style="width:47%; float:left;">
                <h2 style="margin-top: 1%;">Address</h2>

              <asp:TextBox ID="txtAddress"  class="form1" Height="80px" Width="276px" style="float:right;resize:none;font-family: Calibri;" runat="server" TextMode="MultiLine" onkeypress="return isTagWithEnter(event);"  onkeydown="textCounter(cphMain_txtAddress,450);" onkeyup="textCounter(cphMain_txtAddress,450);" onblur="textCounter(cphMain_txtAddress,450);"  ></asp:TextBox>


            </div>
              <div class="eachform" style="width:47%; padding-left:6%">
                <h2 style="margin-top: 1%;">Registration Number</h2>
<asp:TextBox ID="txtRegistrationNo" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="text-transform: uppercase; " onkeypress="return isTag(event);" ></asp:TextBox>


            </div>
             <div class="eachform" style="width:47%; padding-left:6%">
               <h2 >Registration Status*</h2>

               <div class="subform" style=" margin-left: 0%;">
                    <asp:CheckBox ID="cbRegistrationSts" Text="" runat="server" onchange="IncrmntConfrmCounter();" onkeydown="return DisableEnter(event);" Checked="true" class="form2" />

                    <h3>Registered</h3>

                </div>

            </div>

 <div class="eachform" style="width:47%; padding-left:6%">
               <h2>Status*</h2>

               <div class="subform" style=" margin-left: 0%;">
                    <asp:CheckBox ID="cbStatus" Text="" runat="server" onchange="IncrmntConfrmCounter();" onkeydown="return DisableEnter(event);" Checked="true" class="form2" />

                    <h3>Active</h3>

                </div>

            </div>
                 
            <div class="div-Contact-details" style="float: left;margin-left: -2%;">
                 <div   class="eachform" style="width:100%; float:left;">
            <h2>Contact Person Details</h2>
                     </div>
                 <div   class="eachform" style="width:47%; float:left;">
                <h2 style="margin-top: 1%;">Name</h2>

                <asp:TextBox ID="txtCntctName" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="height:30px;width:275px;text-transform: uppercase; float: left;margin-left: 28%; " onkeypress="return isTag(event);"  ></asp:TextBox>


            </div>
              <div  class="eachform" style="width:47%; float:right; ">
                <div class="eachform"  >
                <h2 style="margin-top: 1%;margin-left: .5%;">Email</h2>
                <asp:TextBox ID="txtCntctEmail" Height="30px" Width="275px" class="form1" runat="server" MaxLength="95" Style="height:30px;width:270px;float: left;margin-left: 29%;" onkeypress="return isTag(event);"></asp:TextBox>
                        <p class="error" id="ErrorContctMsgEmail" style="display:none">Please enter valid email id</p>
            </div>
                </div>
             
             <div id="divPrdctCode" runat="server" class="eachform" style="width:47%; float:left;">
                <h2 style="margin-top: 1%;">Mobile number</h2>

                <asp:TextBox ID="txtCntctMobile"  onblur="return removeSpclChrcter('cphMain_txtCntctMobile')" Height="30px" Width="275px" class="form1" runat="server" MaxLength="25" Style="height:30px;width:275px;text-transform: uppercase; float: left;margin-left: 13.8%; " onkeydown="return isNumber(event)" onkeypress="return isTag(event);"></asp:TextBox>
                    <p class="error" id="ErrorMsgMobcontct" style="display:none">Please enter valid mobile number</p>

            </div>
             
            </div>
                   
            <br />
            <div class="eachform" style="margin-top: 3%;">
                <div class="subform" style="width: 60%;">

                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return validateConsultancy();" />
                      <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close"  OnClick="btnUpdate_Click" OnClientClick="return validateConsultancy();" />
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClientClick="return validateConsultancy();" OnClick="btnAdd_Click" />
                  <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close"  OnClick="btnAdd_Click"  OnClientClick="return validateConsultancy();" />
                     <asp:Button ID="btnClear" runat="server" class="save" Text="Clear" OnClientClick="return ConfirmClear();" />
                       <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return ConfirmMessage();" />
                </div>
            </div>


        </div>
    </div>
</asp:Content>

