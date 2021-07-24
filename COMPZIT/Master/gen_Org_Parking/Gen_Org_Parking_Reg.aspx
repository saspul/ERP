<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gen_Org_Parking_Reg.aspx.cs" Inherits="Master_gen_Org_Parking_Gen_Org_Parking_Reg2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Compzit Registration | ERP | Enterprise Solution Optimized</title>
       <link rel="shortcut icon" type="image/x-icon" href="/Images/Design_Images/images/compzit.ico" />
<link rel="stylesheet" type="text/css" href="/css/Design-CSS/main.css"/>
<link rel="stylesheet" type="text/css" href="/css/Design-CSS/responsive.css"/>
<link rel="stylesheet" type="text/css" href="/css/Design-CSS/menu.css" media="all" />

      <script language="javascript" type="text/javascript">
          var submit = 0;
          function CheckIsRepeat() {
              if (++submit > 1) {

                  return false;
              }
              else {
                  return true;
              }
          } function CheckSubmitZero() {
              submit = 0;
          }
    </script>
    <script>
        function onChange() {


            if (document.getElementById("<%= cbxPswdVisible.ClientID %>").checked == true) {
                document.getElementById("<%= txtOrgPwd.ClientID %>").type = 'text';
                document.getElementById("<%= txtOrgConPwd.ClientID %>").type = 'text';

            }
            else {
                document.getElementById("<%= txtOrgPwd.ClientID %>").type = 'password';
                document.getElementById("<%= txtOrgConPwd.ClientID %>").type = 'password';

            }
            return false;
        }
    </script>
    <script>
        function RemoveTag(control) {

            var text = control.value;
            var replaceText1 = text.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            control.value = replaceText2;
        }
    </script>
    <%-- for tooltip --%>
    <style>
        .form11 {
            width: 232px;
            height: 28px;
            padding: 0px 8px;
            border: 1px solid #cfcccc;
            /*float: right;*/
            color: #000;
            font-size: 13px;
        }


        .form-tooltip {
            display: table-cell;
            visibility: hidden;
            position: absolute;
            box-sizing: content-box;
            height: 0;
            margin-left: 21%;
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
        }

        :focus + .form-tooltip {
            margin-bottom: 0;
            height: auto;
            visibility: visible;
        }
    </style>

    <style>
        .fillform {
            width: 100%;
            
        }

        body {
            font-family: Calibri;
            background-color:white;
        }

        .subform {
            float: left;
            margin-left: 38.8%;
        }

        .fillform p {
            color: red;
            padding-left: 6.5%;
            font-size: small;
        }
          .error {
            color: red;
            padding-left: 6.5%;
            font-size: small;
        }
        .eachform h2 {
            margin-top: -10%;
        }

        #cphMain_divWait {
            border-radius: 20px;
            background: #F0F0ED;
            padding: 12px;
            width: 98%;
            text-align: center;

        }
        .eachform1 {
            /*width: 100%;*/
            display: inline-block;
            margin: 0 0 10px;
            
        }
        .eachform1 h2 {
            margin-top: -5%;
            font-size:17px;
        }
    </style>
        <style>
        .cont_rght {
            min-height: 500px;
        }

        .header {
            background-color: white;
        }

        .bottomheader {
            padding-bottom: 1px;
        }

        .foot h4 {
            width: 50%;
            text-align: right;
        }

        .foot h3 {
            width: 50%;
            text-align: left;
        }

        .mob-btn {
            margin-left: 0px;
            height: 30px;
            padding-top: 4px;
        }
        .bh_sub_lft h1 {
        margin-right:80px;
        }
        .cont_rght {
            padding-bottom:2%;
            padding-top: 2%;
        }
        .main_table {
        border: 1px solid #c9c9c9;
        }
        table.dataTable.no-footer {
            border-bottom: 1px solid #c9c9c9;
        }
        table.dataTable tbody td {
            padding-top:0px;
            padding-bottom:0px;
            padding-left:1%;
            padding-right:1%;
        }
         #ReportTable_length select {
            width: 50px;
             font-weight:bold;
             font-family: calibri;
             color: #336B16;
               font-size:14px;
        }
        #ReportTable_length  {
              font-family:Calibri;
               font-weight:bold;
                  font-size:14px;
        }
        #ReportTable_filter input {
            height: 23px;
            width: 200px;
                 color: #336B16;
                    font-size:14px;
        }
        #ReportTable_filter  {
            font-family:Calibri;
            font-weight:bold;
               font-size:14px;
          
        }
        #ReportTable_paginate {
               font-family:Calibri;
                  font-size:13px;
            
        }
        #ReportTable_info {
             font-family:Calibri;
             font-weight: 600;
             font-size:14px;
            
        }
         #divErrorTotal {
            border-radius: 8px;
            background: #edf6dc;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
           margin-top:-1.5%;
           font-family:Calibri;
        } 
          #divSuccessUpd {
            border-radius: 8px;
            background: #edf6dc;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: -1%;
            margin-left: 2%;
            width: 89.5%;
            font-family:Calibri;
        }
       .topheader {
            min-height: 50px;
              z-index:32;
        }
        .bottomheader {
        min-height:30px;
        }
        

       .sub_logo{background-image:linear-gradient(to bottom, #ffffff 40%, #A5DA4F   100%); background-repeat:repeat;position:absolute;float:left;
margin:14px 0 0 }
.sub_logo img{width:151px; float:left; padding:24px 57px 33px 58px} 
    </style>
    <script type="text/javascript">

        function DuplicationName() {


            document.getElementById("<%=txtOrgName.ClientID%>").style.borderColor = "Red";
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Duplication Error!. Organisation Name Can’t be Duplicated.";
            document.getElementById("<%=txtOrgName.ClientID%>").focus();
        }
        function DuplicationEmail() {
            document.getElementById("<%=txtOrgEmail.ClientID%>").style.borderColor = "Red";
            document.getElementById('divErrorTotal').style.visibility = "visible";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Email Address Already Exists, Please Change your Email and Try Again";
            document.getElementById("<%=txtOrgEmail.ClientID%>").focus();
        }
        function ReplaceTag() {

            // replacing < and > tags
            var OrgNameWithoutReplace = document.getElementById("<%=txtOrgName.ClientID%>").value;
            var OrgNamereplaceText1 = OrgNameWithoutReplace.replace(/</g, "");
            var OrgNamereplaceText2 = OrgNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgName.ClientID%>").value = OrgNamereplaceText2;
            var OrgAdd1WithoutReplace = document.getElementById("<%=txtOrgAdd1.ClientID%>").value;
            var OrgAdd1replaceText1 = OrgAdd1WithoutReplace.replace(/</g, "");
            var OrgAdd1replaceText2 = OrgAdd1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd1.ClientID%>").value = OrgAdd1replaceText2;
            var OrgAdd2WithoutReplace = document.getElementById("<%=txtOrgAdd2.ClientID%>").value;
            var OrgAdd2replaceText1 = OrgAdd2WithoutReplace.replace(/</g, "");
            var OrgAdd2replaceText2 = OrgAdd2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd2.ClientID%>").value = OrgAdd2replaceText2;
            var OrgAdd3WithoutReplace = document.getElementById("<%=txtOrgAdd3.ClientID%>").value;
            var OrgAdd3replaceText1 = OrgAdd3WithoutReplace.replace(/</g, "");
            var OrgAdd3replaceText2 = OrgAdd3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd3.ClientID%>").value = OrgAdd3replaceText2;
            var OrgZipWithoutReplace = document.getElementById("<%=txtOrgZip.ClientID%>").value;
            var OrgZipreplaceText1 = OrgZipWithoutReplace.replace(/</g, "");
            var OrgZipreplaceText2 = OrgZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgZip.ClientID%>").value = OrgZipreplaceText2;
            var OrgPhoneWithoutReplace = document.getElementById("<%=txtOrgPhone.ClientID%>").value;
            var OrgPhonereplaceText1 = OrgPhoneWithoutReplace.replace(/</g, "");
            var OrgPhonereplaceText2 = OrgPhonereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgPhone.ClientID%>").value = OrgPhonereplaceText2;
            var OrgWebsiteWithoutReplace = document.getElementById("<%=txtOrgWebsite.ClientID%>").value;
            var OrgWebsitereplaceText1 = OrgWebsiteWithoutReplace.replace(/</g, "");
            var OrgWebsitereplaceText2 = OrgWebsitereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgWebsite.ClientID%>").value = OrgWebsitereplaceText2;
            var OrgEmailWithoutReplace = document.getElementById("<%=txtOrgEmail.ClientID%>").value;
            var OrgEmailreplaceText1 = OrgEmailWithoutReplace.replace(/</g, "");
            var OrgEmailreplaceText2 = OrgEmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgEmail.ClientID%>").value = OrgEmailreplaceText2;
            var OrgPwdWithoutReplace = document.getElementById("<%=txtOrgPwd.ClientID%>").value;
            var OrgPwdreplaceText1 = OrgPwdWithoutReplace.replace(/</g, "");
            var OrgPwdreplaceText2 = OrgPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgPwd.ClientID%>").value = OrgPwdreplaceText2;
            var OrgConPwdWithoutReplace = document.getElementById("<%=txtOrgConPwd.ClientID%>").value;
            var OrgConPwdreplaceText1 = OrgConPwdWithoutReplace.replace(/</g, "");
            var OrgConPwdreplaceText2 = OrgConPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgConPwd.ClientID%>").value = OrgConPwdreplaceText2;
            __doPostBack('', '');
            return false;
        }


        function OrgParkingNullValidation() {
            var ret = true;
            //if (CheckIsRepeat() == true) {
            //}
            //else {
            //    ret = false;
            //    return ret;
            //}
            // replacing < and > tags
            var OrgNameWithoutReplace = document.getElementById("<%=txtOrgName.ClientID%>").value;
            var OrgNamereplaceText1 = OrgNameWithoutReplace.replace(/</g, "");
            var OrgNamereplaceText2 = OrgNamereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgName.ClientID%>").value = OrgNamereplaceText2;
            var OrgAdd1WithoutReplace = document.getElementById("<%=txtOrgAdd1.ClientID%>").value;
            var OrgAdd1replaceText1 = OrgAdd1WithoutReplace.replace(/</g, "");
            var OrgAdd1replaceText2 = OrgAdd1replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd1.ClientID%>").value = OrgAdd1replaceText2;
            var OrgAdd2WithoutReplace = document.getElementById("<%=txtOrgAdd2.ClientID%>").value;
            var OrgAdd2replaceText1 = OrgAdd2WithoutReplace.replace(/</g, "");
            var OrgAdd2replaceText2 = OrgAdd2replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd2.ClientID%>").value = OrgAdd2replaceText2.trim();
            var OrgAdd3WithoutReplace = document.getElementById("<%=txtOrgAdd3.ClientID%>").value;
            var OrgAdd3replaceText1 = OrgAdd3WithoutReplace.replace(/</g, "");
            var OrgAdd3replaceText2 = OrgAdd3replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgAdd3.ClientID%>").value = OrgAdd3replaceText2.trim();
            var OrgZipWithoutReplace = document.getElementById("<%=txtOrgZip.ClientID%>").value;
            var OrgZipreplaceText1 = OrgZipWithoutReplace.replace(/</g, "");
            var OrgZipreplaceText2 = OrgZipreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgZip.ClientID%>").value = OrgZipreplaceText2;
            var OrgPhoneWithoutReplace = document.getElementById("<%=txtOrgPhone.ClientID%>").value;
            var OrgPhonereplaceText1 = OrgPhoneWithoutReplace.replace(/</g, "");
            var OrgPhonereplaceText2 = OrgPhonereplaceText1.replace(/>/g, "");

            document.getElementById("<%=txtOrgPhone.ClientID%>").value = OrgPhonereplaceText2;
            var OrgWebsiteWithoutReplace = document.getElementById("<%=txtOrgWebsite.ClientID%>").value;
            var OrgWebsitereplaceText1 = OrgWebsiteWithoutReplace.replace(/</g, "");
            var OrgWebsitereplaceText2 = OrgWebsitereplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgWebsite.ClientID%>").value = OrgWebsitereplaceText2;

            var OrgEmailWithoutReplace = document.getElementById("<%=txtOrgEmail.ClientID%>").value;
            var OrgEmailreplaceText1 = OrgEmailWithoutReplace.replace(/</g, "");
            var OrgEmailreplaceText2 = OrgEmailreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgEmail.ClientID%>").value = OrgEmailreplaceText2;
            var OrgPwdWithoutReplace = document.getElementById("<%=txtOrgPwd.ClientID%>").value;
            var OrgPwdreplaceText1 = OrgPwdWithoutReplace.replace(/</g, "");
            var OrgPwdreplaceText2 = OrgPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgPwd.ClientID%>").value = OrgPwdreplaceText2;
            var OrgConPwdWithoutReplace = document.getElementById("<%=txtOrgConPwd.ClientID%>").value;
            var OrgConPwdreplaceText1 = OrgConPwdWithoutReplace.replace(/</g, "");
            var OrgConPwdreplaceText2 = OrgConPwdreplaceText1.replace(/>/g, "");
            document.getElementById("<%=txtOrgConPwd.ClientID%>").value = OrgConPwdreplaceText2;

            var re = /^(http[s]?:\/\/){0,1}(www\.){0,1}[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,5}[\.]{0,1}/;

            var web = document.getElementById("<%=txtOrgWebsite.ClientID%>").value;

           
            var OrgnType = document.getElementById("<%=ddlOrgType.ClientID%>");
            var OrgType = OrgnType.options[OrgnType.selectedIndex].text;

            var FrmeWork = document.getElementById("<%=ddlFramework.ClientID%>");
            var Framework = FrmeWork.options[FrmeWork.selectedIndex].text;

            var OrgnCountry = document.getElementById("<%=ddlOrgCountry.ClientID%>");
            var OrgCountry = OrgnCountry.options[OrgnCountry.selectedIndex].text;

            var OrgName = document.getElementById("<%=txtOrgName.ClientID%>").value.trim();

            var OrgAdd = document.getElementById("<%=txtOrgAdd1.ClientID%>").value.trim();

            var OrgMobile = document.getElementById("<%=txtOrgMobile.ClientID%>").value;
            var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

            var EmailAdd = document.getElementById("<%=txtOrgEmail.ClientID%>").value.trim();

            var Email = document.getElementById("<%=txtOrgEmail.ClientID%>");
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var OrgPwd = document.getElementById("<%=txtOrgPwd.ClientID%>").value;

            var minNumberofChars = 6;
            var maxNumberofChars = 16;
            //var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[a-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/;
            var regularExpression = /(?=.*\d)(?=.*[~!@#$%^&*])(?=.*[A-Za-z])|(?=.*[A-Z])[0-9!@#$%^&*].{6,16}/;
            var OrgConPwd = document.getElementById("<%=txtOrgConPwd.ClientID%>").value;

            var OrgnLicPac = document.getElementById("<%=ddlOrgLicPac.ClientID%>");
            var OrgLicPac = OrgnLicPac.options[OrgnLicPac.selectedIndex].text;

            var OrgnCorPac = document.getElementById("<%=ddlOrgCorPac.ClientID%>");
            var OrgCorPac = OrgnCorPac.options[OrgnCorPac.selectedIndex].text;



            document.getElementById("<%=txtOrgConPwd.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgEmail.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlOrgCorPac.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlOrgLicPac.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgMobile.ClientID%>").style.borderColor = "";
            document.getElementById("<%=ddlOrgCountry.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgAdd1.ClientID%>").style.borderColor = "";
            document.getElementById("<%=txtOrgName.ClientID%>").style.borderColor = "";
            document.getElementById("<%= ddlOrgType.ClientID%>").style.borderColor = "";
            document.getElementById("<%= ddlFramework.ClientID%>").style.borderColor = "";

            document.getElementById('ErrorMsgFramework').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgType').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgName').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgAdd1').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgCountry').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgMobile').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgLicPac').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgCorPac').style.visibility = "hidden";
            document.getElementById('ErrorMsgOrgEmail').style.visibility = "hidden";
            document.getElementById('PwdMsg').style.visibility = "hidden";
            document.getElementById('PwdMsg').innerHTML = "";
            document.getElementById('ErrorMsgOrgConPwd').style.visibility = "hidden";
            document.getElementById('divErrorTotal').style.visibility = "hidden";
            document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "";
          
            if (web != "") {
                if (!re.test(web)) {
                   
                    document.getElementById('ErrorMsgOrgWebsite').style.visibility = "";
                    // document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Please Enter Valid Website Address.";
                        document.getElementById("<%=txtOrgWebsite.ClientID%>").focus();
                        document.getElementById("<%=txtOrgWebsite.ClientID%>").style.borderColor = "Red";
                        ret = false;
                    }
               
                }

            if (OrgType == "--Select Organization Type--" || Framework == "--Select Framework--" || OrgName == "" || OrgAdd == "" || OrgCountry == "--Select Your Country--" || OrgMobile.length < "10" || !filter.test(Email.value) || OrgPwd.length < minNumberofChars || OrgPwd.length > maxNumberofChars || !regularExpression.test(OrgPwd) || OrgConPwd != OrgPwd || OrgLicPac == "--Choose Your License Pack--" || OrgCorPac == "--Choose Your Corporate Pack--") {
                document.getElementById('divErrorTotal').style.visibility = "visible";
                document.getElementById("<%=lblErrorTotal.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";



                if (OrgConPwd != OrgPwd) {
                    document.getElementById('ErrorMsgOrgConPwd').style.visibility = "visible";
                    document.getElementById("<%=txtOrgConPwd.ClientID%>").focus();
                    document.getElementById("<%=txtOrgConPwd.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (!regularExpression.test(OrgPwd)) {
                    document.getElementById('PwdMsg').style.visibility = "visible";
                    //document.getElementById('PwdMsg').innerHTML = "Password Must Contain 6-16 Characters with atleast one number, special character and alphabet";
                    document.getElementById("<%=txtOrgPwd.ClientID%>").focus();
                    document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgPwd.length < minNumberofChars || OrgPwd.length > maxNumberofChars) {

                    document.getElementById('PwdMsg').style.visibility = "visible";
                    //document.getElementById('PwdMsg').innerHTML = "Password Must Contain 6-16 Characters with atleast one number, special character and alphabet";
                    document.getElementById("<%=txtOrgPwd.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=txtOrgPwd.ClientID%>").focus();
                    ret = false;
                }
                if (!filter.test(Email.value)) {
                    document.getElementById('ErrorMsgOrgEmail').style.visibility = "visible";
                    EmailAdd = "";
                    document.getElementById("<%=txtOrgEmail.ClientID%>").focus();
                    document.getElementById("<%=txtOrgEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgCorPac == "--Choose Your Corporate Pack--") {

                    document.getElementById("<%=ddlOrgCorPac.ClientID%>").focus();
                    document.getElementById("<%=ddlOrgCorPac.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgLicPac == "--Choose Your License Pack--") {

                    document.getElementById("<%=ddlOrgLicPac.ClientID%>").focus();
                    document.getElementById("<%=ddlOrgLicPac.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (Framework == "--Select Framework--") {
                    document.getElementById("<%=ddlFramework.ClientID%>").focus();
                    document.getElementById("<%=ddlFramework.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (!mobileregular.test(OrgMobile)) {
                    document.getElementById('ErrorMsgOrgMobile').style.visibility = "visible";
                    document.getElementById("<%=txtOrgMobile.ClientID%>").focus();
                    document.getElementById("<%=txtOrgMobile.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgCountry == "--Select Your Country--") {

                    document.getElementById("<%=ddlOrgCountry.ClientID%>").focus();
                    document.getElementById("<%=ddlOrgCountry.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgAdd == "") {

                    document.getElementById("<%=txtOrgAdd1.ClientID%>").focus();
                    document.getElementById("<%=txtOrgAdd1.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgName == "") {
                    document.getElementById("<%=txtOrgName.ClientID%>").focus();
                    document.getElementById("<%=txtOrgName.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }
                if (OrgType == "--Select Organization Type--") {

                    document.getElementById("<%= ddlOrgType.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%= ddlOrgType.ClientID%>").focus();
                    ret = false;
                }
               

            }
            if (ret == false) {
                CheckSubmitZero();

            }
            
            $('html, body').animate({ scrollTop: 0 }, 500);
            return ret;
        }
    </script>
    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //enter
            if (keyCodes == 13) {
                return false;
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
        // for not allowing enter
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
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
        function BlurNotNumber(obj) {
            var txt = document.getElementById(obj).value;

            if (txt != "") {

                if (isNaN(txt)) {
                    document.getElementById(obj).value = "";
                    document.getElementById(obj).focus();
                    return false;

                }


            }
        }
        function Password_Strength(event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            var charCode = (event.which) ? event.which : event.keyCode;
            var OrgPwd = document.getElementById("<%=txtOrgPwd.ClientID%>").value;
            var ErrorMsg = document.getElementById('PwdMsg').style.visibility = "hidden";
            if (keyCode == 13) {

                return false;
            }
            else if (charCode == 60 || charCode == 62) {
                return false;

            }
            else {
                if (OrgPwd.length < 10) {

                    document.getElementById('PwdMsg').style.visibility = "visible";
                    document.getElementById('PwdMsg').style.color = "red";
                    document.getElementById('PwdMsg').innerHTML = "WEAK";
                    return true;
                }
                if (OrgPwd.length >= 10 && OrgPwd.length < 13) {
                    document.getElementById('PwdMsg').style.visibility = "visible";
                    document.getElementById('PwdMsg').style.color = "orange";
                    document.getElementById('PwdMsg').innerHTML = "MEDUIM";
                    return true;
                }
                if (OrgPwd.length >= 13) {
                    document.getElementById('PwdMsg').style.visibility = "visible";
                    document.getElementById('PwdMsg').style.color = "green";
                    document.getElementById('PwdMsg').innerHTML = "STRONG";
                    return true;
                }
                return true;
            }
        }
        function Paste() {

        }

    </script>

     <script src="/JavaScript/Design-Javascript/jquery.min.js"></script>
        <!-- import -->
        <script src="/JavaScript/Design-Javascript/bootstrap.min.js"></script>

     <script type="text/javascript">

         $('.mob-btn').click(function (event) {

             $('body').toggleClass('open');
             event.stopPropagation();

         })

         $('.menu').click(function (event) {

             event.stopPropagation();

         })
         $('.overlay').click(function () {
             if ($('body').hasClass('open')) {
                 $('body').removeClass('open');
             }
         });


         $('ul.menu li:has(ul)').addClass('submenu');
         $('ul.menu li:has(ul)').append("<i></i>");

         $('ul.menu i').click(function () {
             $(this).parent('li').toggleClass('open');
         })





         // MOBILE MENU

        </script>



</head>
<body>
  
    <div class="banner">
    <div class="bannersub">
    	<div class="auto">
            <img src="/Images/Design_Images/images/logo.png" />
            <h2>Organization Registration</h2>
        </div>    
    </div>
    <h3>Please do not refresh the page while Registration is on Process</h3>
</div>
      <form id="form1" runat="server">
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenlblOnCloudOrNot" runat="server" />


    <div class="cont_rght">
        <div id="divErrorTotal" style="visibility: hidden; margin-top: -1.5%">
            <asp:Label ID="lblErrorTotal" runat="server"></asp:Label>
        </div>
            <br />
            
            <table class="eachform">
                <tr>

                    <td style="text-align: left; width: 18%;">
                        <h2>Organization Type*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:DropDownList ID="ddlOrgType" Height="30px" Width="267px" class="form1" runat="server"></asp:DropDownList>

                        <p class="error" id="ErrorMsgOrgType" style="visibility: hidden">Please select</p>

                    </td>


                    <td style="text-align: left; width: 20%; padding-left: 2%;">
                        <h2>Organization Name*</h2>
                    </td>
                    <td style="text-align: left; width: 30%;">
                        <asp:TextBox ID="txtOrgName" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>

                        <p class="error" id="ErrorMsgOrgName" style="visibility: hidden">Please fill this out</p>

                    </td>
                </tr>

                <tr>


                    <td style="text-align: left; width: 18%;">
                        <h2>Address 1*</h2>
                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgAdd1" class="form1" runat="server" MaxLength="150" Height="30px" Width="250px" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>

                        <p class="error" id="ErrorMsgOrgAdd1" style="visibility: hidden">Please fill this out</p>

                    </td>


                    <td style="text-align: left; width: 20%; padding-left: 2%;">
                        <h2>Address 2 </h2>
                    </td>
                    <td style="text-align: left; width: 30%;">
                        <asp:TextBox ID="txtOrgAdd2" class="form1" runat="server" MaxLength="150" Height="30px" Width="250px" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>

                        <p class="error" id="ErrorMsgOrgAdd2" style="visibility: hidden">Please fill this out</p>

                    </td>



                </tr>
                <tr>
                    <td style="text-align: left; width: 18%;">
                        <h2>Address 3 </h2>

                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgAdd3" class="form1" runat="server" MaxLength="150" Height="30px" Width="250px" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>

                        <p class="error" id="ErrorMsgOrgAdd3" style="visibility: hidden">Please fill this out</p>

                    </td>


                    <td style="text-align: left; width: 20%; padding-left: 2%;">
                        <h2>Country*</h2>
                    </td>
                    <td style="text-align: left; width: 30%;">
                        <asp:DropDownList ID="ddlOrgCountry" class="form1" runat="server" Height="30px" Width="267px" onChange="return ReplaceTag();" OnSelectedIndexChanged="ddlOrgCountry_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                        <p class="error" id="ErrorMsgOrgCountry" style="visibility: hidden">Please select</p>
                    </td>


                </tr>
                <tr>


                    <td style="text-align: left; width: 18%;">
                        <h2>State </h2>

                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:DropDownList ID="ddlOrgState" class="form1" Height="30px" Width="267px" runat="server" onChange="return ReplaceTag();" OnSelectedIndexChanged="ddlOrgState_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                        <p class="error" id="ErrorMsgOrgState" style="visibility: hidden">Please fill this out</p>

                    </td>


                    <td style="text-align: left; width: 20%; padding-left: 2%;">
                        <h2>City </h2>
                    </td>
                    <td style="text-align: left; width: 30%;">
                        <asp:DropDownList ID="ddlOrgCity" Width="267px" Height="30px" class="form1" runat="server" AutoPostBack="false"></asp:DropDownList>

                        <p class="error" id="ErrorMsgOrgCity" style="visibility: hidden">Please fill this out</p>
                    </td>


                </tr>
                <tr>

                    <td style="text-align: left; width: 18%;">
                        <h2>Zip Code </h2>

                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgZip" class="form1" runat="server" MaxLength="10" Height="30px" Width="250px" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>

                        <p class="ErrorMsgOrgZip" id="P8" style="visibility: hidden">Please fill this out</p>

                    </td>


                    <td style="text-align: left; width: 20%; padding-left: 2%;">
                        <h2>Phone </h2>
                    </td>
                    <td style="text-align: left; width: 30%;">
                        <asp:TextBox ID="txtOrgPhone" class="form1" runat="server" MaxLength="50" Height="30px" Width="250px" Style="text-transform: uppercase"></asp:TextBox>

                        <p class="error" id="ErrorMsgOrgPhone" style="visibility: hidden">Please fill this out</p>
                    </td>


                </tr>

                <tr>

                    <td style="text-align: left; width: 18%;">
                        <h2>Mobile*</h2>

                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtOrgMobile" class="form1" runat="server" MaxLength="50" Height="30px" Width="250px" onPaste="return false" Style="text-transform: uppercase"></asp:TextBox>

                        <p class="error" id="ErrorMsgOrgMobile" style="visibility: hidden">Please enter valid mobile number</p>
                    </td>


                    <td style="text-align: left; width: 20%; padding-left: 2%;">
                        <h2>Website </h2>
                    </td>
                    <td style="text-align: left; width: 30%;">
                        <asp:TextBox ID="txtOrgWebsite" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" onblur="RemoveTag(this)"></asp:TextBox>

                        <p class="error" id="ErrorMsgOrgWebsite" style="visibility: hidden">Please enter valid website</p>
                    </td>


                </tr>

                <tr>
                    <td style="text-align: left; width: 18%;">
                        <h2 style="margin-top: 0%;">Contact Person</h2>

                    </td>
                    <td style="text-align: left; width: 32%;">
                        <asp:TextBox ID="txtContactPerson" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" Style="text-transform: uppercase" onblur="RemoveTag(this)"></asp:TextBox>

                    </td>
                    <td style="text-align: left; width: 20%; padding-left: 2%;">
                        <h2>Framework*</h2>
                    </td>
                    <td style="text-align: left; width: 30%;">
                       <asp:DropDownList ID="ddlFramework" Height="30px" Width="267px" class="form1" runat="server"></asp:DropDownList>
                        <p class="error" id="ErrorMsgFramework" style="visibility: hidden">Please fill this out</p>
                    </td>

                </tr>
                <tr>

                    <td colspan="4" style="text-align: left; font-size: 18px; font-weight: bold; line-height: 65px; color: rgb(83, 101, 51);">License Information
                    </td>


                </tr>
                <tr>
 <td style="text-align: left; width: 18%;">
                                 <h2>License Pack*</h2>

                                </td>
                            <td style="text-align: left; width: 32%;">
                             <asp:DropDownList ID="ddlOrgLicPac" class="form1" Height="30px" Width="267px" runat="server" onChange="return ReplaceTag();" OnSelectedIndexChanged="ddlOrgLicPac_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                <p class="error" id="ErrorMsgOrgLicPac" style="visibility: hidden">Please select</p>
                            </td>


                            <td style="text-align: left; width: 20%; padding-left: 2%;">
                            <h2>License Pack Count </h2>
                            </td>
                            <td style="text-align: left; width: 30%;">
                              <asp:TextBox ID="txtLicPacCount" onkeydown="return DisableEnter(event);" class="form1" runat="server" MaxLength="4" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                                <p class="error" id="P17" style="visibility: hidden">Please select</p>

                            </td>


                        </tr>
                     
                        <tr>
                              
                                <td style="text-align: left; width: 18%;">
                              <h2>Corporate Pack*</h2>

                                </td>
                            <td style="text-align: left; width: 32%;">
                              <asp:DropDownList ID="ddlOrgCorPac" Height="30px" Width="267px" class="form1" runat="server" onChange="return ReplaceTag();" OnSelectedIndexChanged="ddlOrgCorPac_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                <p id="ErrorMsgOrgCorPac" class="error"style="visibility: hidden">Please fill this out</p>
                            </td>


                            <td style="text-align: left; width: 20%; padding-left: 2%;">
                          <h2>Corporate Pack Count </h2>
                            </td>
                            <td style="text-align: left; width: 30%;">
                             <asp:TextBox ID="txtCorPacCount" onkeydown="return DisableEnter(event);"  class="form1" runat="server" MaxLength="2" Height="30px" Width="250px" ReadOnly="true" Style="text-transform: uppercase"></asp:TextBox>

                                <p class="error" id="P1" style="visibility: hidden">Please fill this out</p>

                            </td>
               

                        </tr>
                  <tr>

                                <td colspan="4" style="text-align: left; font-size:18px; font-weight:bold;line-height: 65px; color: rgb(83, 101, 51);">
                                     Login Information
                            </td>


                        </tr>
                          <tr>

                                <td style="text-align: left; width: 18%;">
                              <h2>Email*</h2>

                                </td>
                            <td style="text-align: left; width: 32%;">
                               <asp:TextBox ID="txtOrgEmail" class="form1" runat="server" MaxLength="100" Height="30px" Width="250px" onblur="RemoveTag(this)"></asp:TextBox>

                                <p class="error" id="ErrorMsgOrgEmail" style="visibility: hidden;font-family:Calibri;">Please enter valid email address</p>
                       
                            </td>


                            


                        </tr>
                         <tr>

                            <td style="text-align: left; width: 18%;">
                              <h2>Password*</h2>
                            </td>
                            <td style="text-align: left; width: 32%;">
                             <asp:TextBox ID="txtOrgPwd" class="form1" onPaste="return false" runat="server" MaxLength="16" Height="30px" Width="250px" TextMode="Password" onblur="RemoveTag(this)"></asp:TextBox>

                                <div class='form-tooltip'>Password Must Contain 6-16 Characters with atleast one number, special character & alphabet</div>
                                <p class="error" id="PwdMsg" style="visibility: hidden;"></p>
                                <asp:CheckBox ID="cbxPswdVisible" Text="Show Password" runat="server" class="form2" Style="margin-left:5.5%;margin-top:0%" onchange="return onChange();" />
                            </td>
                              <td style="text-align: left; width: 20%; padding-left: 2%;">
                              <h2>Confirm Password*</h2>

                                </td>
                            <td style="text-align: left; width: 30%;">
                                <asp:TextBox ID="txtOrgConPwd" class="form1" runat="server" MaxLength="16" onPaste="return false" Height="30px" Width="250px" TextMode="Password" onblur="RemoveTag(this)"></asp:TextBox>

                                <p class="error" id="ErrorMsgOrgConPwd" style="visibility: hidden; font-family:Calibri;padding-left:0%;">Both passwords must be equal</p>
                            </td>

                        </tr>
            </table>


                    
           




            <br />
            <div class="eachform">
                <div class="subform">


                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnOrgSave_Click" OnClientClick="return OrgParkingNullValidation();" />
                    <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" PostBackUrl="~/Security/Login.aspx" />

                    <asp:Label ID="lblRegistration" runat="server" Text="Please don’t Refresh this Page while Registration Process." Visible="False" ForeColor="Red"></asp:Label>


                </div>


            </div>
        </div>
    </div>

           <div class="foot">
            <div class="auto1">
                <h3 id="divcopyright" runat="server">© 2016 Copyright</h3>
                <h4 id="divdevelop" runat="server">Developed by</h4>
            </div>
        </div>
    </form>
</body>
</html>
