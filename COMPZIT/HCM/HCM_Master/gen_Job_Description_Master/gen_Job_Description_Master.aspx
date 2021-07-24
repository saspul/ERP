<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" CodeFile="gen_Job_Description_Master.aspx.cs" Inherits="HCM_HCM_Master_gen_Job_Description_Master_gen_Job_Description_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">

     <style>
        .cont_rght {
            width: 98%;
        }

        #divGreySection {
            background-color: #efefef;
            border: 1px solid;
            border-color: #cfcfcf;
            padding: 15px;
            height: auto;
        }

        .eachform h2 {
            margin: 8px 0 6px;
        }

        #divAwardedContainer {
            width: 46%;
            float: right;
            margin-top: -17%;
            margin-left: 3%;
            border: 1px solid;
            height: auto;
            border-color: #11839c;
            background-color: white;
            min-height: 180px;
        }

        #divMessageArea {
            border-radius: 8px;
            background: #fff;
            padding: 10px;
            font-weight: bold;
            text-align: center;
            font-size: 17px;
            color: #53844E;
            margin-top: 0%;
            font-family: Calibri;
            border: 2px solid #53844E;
        }

        #imgMessageArea {
            float: left;
            margin-left: 1%;
            margin-top: -0.2%;
        }
    </style>
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
                .error {
               padding-top: 7%;
               padding-left: 35%;
               color: red;
               font-size: small;
                margin-left: 8%;
           }
    </style>
      <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
            document.getElementById("<%=ddlDep.ClientID%>").focus();
         
        });
    </script>
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        //var $au = jQuery.noConflict();

        //(function ($au) {
        //    $au(function () {
        //        $au('#cphMain_ddlExistingCntrctr').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlContractType').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlJobCtgry').selectToAutocomplete1Letter();
        //        $au('#cphMain_ddlParentCntrct').selectToAutocomplete1Letter();
        //        $au('form').submit(function () {

        //            //   alert($au(this).serialize());


        //            //   return false;
        //        });
        //    });
        //})(jQuery);





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
    </script>
     <script>

         var confirmbox = 0;

         function IncrmntConfrmCounter() {
             confirmbox++;
         }
         function ConfirmMessage() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want to leave this page?")) {
                     window.location.href = "gen_Job_Description_Master_List.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Job_Description_Master_List.aspx";

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want cancel this page?")) {
                     window.location.href = "gen_Job_Description_Master_List.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Job_Description_Master_List.aspx";
                 return false;
             }
         }
         function ClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want clear all data in this page?")) {
                     window.location.href = "gen_Job_Description_Master.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Job_Description_Master.aspx";
                 return false;
             }
         }

         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job description updated successfully.";
             $(window).scrollTop(0);
         }
         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job description inserted successfully.";
             $(window).scrollTop(0);
         }
         function SuccessUpdationPrj() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Job description updated successfully.";
             $(window).scrollTop(0);
         }
    
         function DuplicationName() {
             document.getElementById('divMessageArea').style.display = "";

             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!.Sponsor name can’t be duplicated..";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             $(window).scrollTop(0);
       
         }
     
    </script>
      <script type="text/javascript" >

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
          // for not allowing <> tags  and enter
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
          function isTagMultTxt(evt) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

              //if (keyCodes == 13) {
              //    return false;
              //}
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              var ret = true;
              if (charCode == 60 || charCode == 62) {
                  ret = false;
              }
              return ret;
          }
          // for not allowing <> tags
          function isTagEnter(evt) {

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
          }

          //  Beginning of JavaScript - FOR SETTING MAXLENGTH FOR MULTILINE TextBox
          function textCounter(field, maxlimit) {
              if (field.value.length > maxlimit) {
                  field.value = field.value.substring(0, maxlimit);
              } else {

              }
          }



          function Validate() {

              var ret = true;
              if (CheckIsRepeat() == true) {
              }
              else {
                  ret = false;
                  return ret;
              }

              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=txtSumrypos.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSumrypos.ClientID%>").value = replaceText2;

           
            var NameWithoutReplace = document.getElementById("<%=txtDesiredQual.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtDesiredQual.ClientID%>").value = replaceText2;

            var NameWithoutReplace = document.getElementById("<%=txtManSklls.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtManSklls.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtEdu.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtEdu.ClientID%>").value = replaceText2;


              var NameWithoutReplace = document.getElementById("<%=txtCertTrain.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtCertTrain.ClientID%>").value = replaceText2; 

              var NameWithoutReplace = document.getElementById("<%=txt_job_respblty.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txt_job_respblty.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtMinExp.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtMinExp.ClientID%>").value = replaceText2;

              document.getElementById("<%=txtSumrypos.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtDesiredQual.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtManSklls.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtEdu.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtCertTrain.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlDivision.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlDep.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddldesgn.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlpaygrd.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddltyppos.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlreportdesg.ClientID%>").style.borderColor = ""; 
              document.getElementById("<%=txt_job_respblty.ClientID%>").style.borderColor = "";
              
              //document.getElementById('divMessageArea').style.display = "none";
              //document.getElementById('imgMessageArea').src = "";

              var Sumrypos = document.getElementById("<%=txtSumrypos.ClientID%>").value.trim();
              var MinExp = document.getElementById("<%=txtMinExp.ClientID%>").value.trim();
              var tManSklls = document.getElementById("<%=txtManSklls.ClientID%>").value.trim();
              var job_respblty = document.getElementById("<%=txt_job_respblty.ClientID%>").value.trim();
             // var CertTrain = document.getElementById("<%=txtCertTrain.ClientID%>").value.trim();

              var varddldesgn = document.getElementById("<%=ddldesgn.ClientID%>");
              var ddldesgnText = varddldesgn.options[varddldesgn.selectedIndex].text;

              var varddlpaygrd = document.getElementById("<%=ddlpaygrd.ClientID%>");
              var ddlpaygrdText = varddlpaygrd.options[varddlpaygrd.selectedIndex].text;

              var varddltyppos = document.getElementById("<%=ddltyppos.ClientID%>");
              var ddltypposText = varddltyppos.options[varddltyppos.selectedIndex].text;

              var varddlreportdesg = document.getElementById("<%=ddlreportdesg.ClientID%>");
              var ddlreportdesgText = varddlreportdesg.options[varddlreportdesg.selectedIndex].text;


              
              if (MinExp == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtMinExp.ClientID%>").style.borderColor = "Red";
                   document.getElementById("<%=txtMinExp.ClientID%>").focus();

                   ret = false;
               }
              if (job_respblty == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txt_job_respblty.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txt_job_respblty.ClientID%>").focus();

                  ret = false;
              }
              if (tManSklls == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtManSklls.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=txtManSklls.ClientID%>").focus();

                      ret = false;
                  }
          
              if (Sumrypos == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtSumrypos.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtSumrypos.ClientID%>").focus();
               
                  ret = false;
              }

              if (ddlreportdesgText == "--SELECT DESIGNATION--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddlreportdesg.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=ddlreportdesg.ClientID%>").focus();
     
                  ret = false;
              }
              if (ddltypposText == "--SELECT POSITION--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddltyppos.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=ddltyppos.ClientID%>").focus();

                      ret = false;
              }
              if (ddlpaygrdText == "--SELECT PAY GRADE--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddlpaygrd.ClientID%>").style.borderColor = "Red";
                      document.getElementById("<%=ddlpaygrd.ClientID%>").focus();

                      ret = false;
                  }
              if (ddldesgnText == "--SELECT DESIGNATION--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddldesgn.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddldesgn.ClientID%>").focus();

                    ret = false;
              }
              CheckSubmitZero();
              return ret;

          }

    </script>
    <script>

   



        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
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
                //left arrow key,right arrow key,home,end ,delete
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

        function RemoveTag() {
            // replacing < and > tags
            //var NameWithoutReplace = document.getElementById(obj).value;
            //      var replaceText1 = NameWithoutReplace.replace(/</g, "");
            //      var replaceText2 = replaceText1.replace(/>/g, "");
            //      document.getElementById(obj).value = replaceText2.trim();

        }

    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenNewCustId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDup" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustomerFocus" runat="server" Value="0" />
     <asp:HiddenField ID="HiddenJobId" runat="server" />
    <div class="cont_rght" style="padding-top: 1%;">

        <div id="divMessageArea" style="display: none; margin: 0px 0 13px;">
            <img id="imgMessageArea" src="">
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 22%; height: 26.5px;">

            <%--   <a href="gen_ProjectsList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width: 100%">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-bottom: 2%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>

            <div style="width:100%;float:left">    <%-- EMP25--%>
                     <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Conditional" runat="server">
   <ContentTemplate>
                   <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Department </h2>

                           
                       <asp:DropDownList ID="ddlDep" class="form1"   style="width: 50%; text-transform: uppercase; margin-right: 7.8%; height: 30px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDep_SelectedIndexChanged">
                </asp:DropDownList>


                            </div>


                     <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
                            <h2 style="margin-left: 0%">Division</h2>
                         <asp:DropDownList ID="ddlDivision" class="form1"   style="width: 52%; text-transform: uppercase; margin-right: 12.8%; height: 30px" runat="server">
                </asp:DropDownList>
                     </div>

              </ContentTemplate>        
 </asp:UpdatePanel>
             
            
                <div class="eachform" style="width: 49%; float: left;margin-left: 4%;">
                    <h2 style="margin-left: 0%">Designation* </h2>
                    <asp:DropDownList ID="ddldesgn" class="form1"   style="width: 50%; text-transform: uppercase; margin-right: 15.8%; height: 30px" runat="server">
                </asp:DropDownList>
                
                   </div>
                  <div class="eachform" style="width: 44%; float: left;">
                    <h2 style="margin-left: 0%">Pay Grade* </h2>

                       <asp:DropDownList ID="ddlpaygrd" class="form1"   style="width: 56%; text-transform: uppercase; margin-right: 6.4%; height: 30px" runat="server">
                    
                    <%--<asp:ListItem Text="All" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Individual" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Company" Value="2"></asp:ListItem>--%>
                </asp:DropDownList>


                            </div>
                 <div id="divCntrctType" class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Type Of Position*</h2>
                      <asp:DropDownList ID="ddltyppos" class="form1"  style="width: 50%; text-transform: uppercase; margin-right: 7.8%; height: 30px" runat="server">
                          <asp:ListItem Value="0" Selected="True" Text="--SELECT POSITION--"></asp:ListItem>
                     <asp:ListItem Text="Full Type" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Part Type" Value="2"></asp:ListItem>
                           <asp:ListItem Text="Contract" Value="3"></asp:ListItem>
                           <asp:ListItem Text="Intern" Value="4"></asp:ListItem>
                           
                </asp:DropDownList>
               
           </div>

                   <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Position Reports To*</h2>
                      
                    <asp:DropDownList ID="ddlreportdesg" class="form1"  style="width: 50.3%; text-transform: uppercase; margin-right: 7.8%; height: 30px" runat="server">
                      </asp:DropDownList>
                </div>
                </div>
            <div style="width:100%;float:left">
                  <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Summary Of The Position*</h2>
                       <asp:TextBox ID="txtSumrypos"  class="form1" runat="server" TextMode="MultiLine" MaxLength="450" onkeydown="textCounter(cphMain_txtSumrypos,450)" onkeyup="textCounter(cphMain_txtSumrypos,450)" Style="resize:none; width: 46%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 8.5%;"></asp:TextBox>
                    
                     
                </div>
                   <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Desired Qualification</h2>
                         <asp:TextBox ID="txtDesiredQual"  class="form1" runat="server" TextMode="MultiLine" MaxLength="450" onkeydown="textCounter(cphMain_txtDesiredQual,450)" onkeyup="textCounter(cphMain_txtDesiredQual,450)" Style="resize:none; width: 46%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 8.5%;"></asp:TextBox>
                   
                   
     
                </div>
                  </div>
                    <div style="width:100%;float:left">
                <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Mandatory Skills*</h2>
                       <asp:TextBox ID="txtManSklls"  class="form1" runat="server" TextMode="MultiLine" MaxLength="450" onkeydown="textCounter(cphMain_txtManSklls,450)" onkeyup="textCounter(cphMain_txtManSklls,450)" Style="resize:none; width: 46%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 8.5%;"></asp:TextBox>
                    
                     
                </div>
                   <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Education</h2>
                         <asp:TextBox ID="txtEdu"  class="form1" runat="server" TextMode="MultiLine" MaxLength="450" onkeydown="textCounter(cphMain_txtEdu,450)" onkeyup="textCounter(cphMain_txtEdu,450)" Style="resize:none; width: 46%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 8.5%;"></asp:TextBox>
                   
                   
     
                </div>
                            </div>
                  <div style="width:100%;float:left">
           
                <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Certification/Training</h2>
                       <asp:TextBox ID="txtCertTrain"  class="form1" runat="server" TextMode="MultiLine" MaxLength="450" onkeydown="textCounter(cphMain_txtCertTrain,450)" onkeyup="textCounter(cphMain_txtCertTrain,450)" Style="resize:none; width: 46%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 8.5%;"></asp:TextBox>
                    
                     
                </div>

                 <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Job Responsibilities*</h2>
                         <asp:TextBox ID="txt_job_respblty"  class="form1" runat="server" TextMode="MultiLine" MaxLength="450" onkeydown="textCounter(cphMain_txt_job_respblty,450)" onkeyup="textCounter(cphMain_txt_job_respblty,450)" Style="resize:none; width: 46%;height:100px; text-transform: uppercase;font-family:Calibri; margin-right: 8.5%;"></asp:TextBox>
                   
                   
     
                </div>
                
                 
                  
                  </div>
            	    <div style="width:100%;float:left">
                         <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Minimum Experience*</h2>
                        <asp:TextBox ID="txtMinExp"  class="form1" runat="server" MaxLength="2" Style="width: 46%; text-transform: uppercase; margin-right: 8.4%; height: 30px" onblur="return removeSpclChrcter('cphMain_txtMinExp')" onkeydown="return isNumber(event)"></asp:TextBox>
                   
                        
                </div>       
                 </div>

                <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 64%; margin-left: 38%">

                    <asp:Button ID="btnUpdate"  runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnUpdateClose"  runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnAdd"  runat="server" class="save" Text="Save"  OnClientClick="return Validate();" OnClick="btnAdd_Click"/>
       
                    <asp:Button ID="btnAddClose"  runat="server" class="save" Text="Save & Close" OnClientClick="return Validate();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancel"  runat="server" class="cancel" OnClientClick="return AlertClearAll();" Text="Cancel" PostBackUrl="gen_Job_Description_Master.aspx"  />
                    <asp:Button ID="btnClear"  runat="server" style="margin-left: 19px;" OnClientClick="return ClearAll();"  class="cancel" Text="Clear"/>
                       
        
               </div>
                </div>


                <br style="clear: both" />
            </div>




        </div>
    </div>

    <style>

        .form1 {
            
            height: 27px;
        }
    </style>
</asp:Content>


