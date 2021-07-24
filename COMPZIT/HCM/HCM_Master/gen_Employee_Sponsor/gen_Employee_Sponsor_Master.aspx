<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gen_Employee_Sponsor_Master.aspx.cs" Inherits="HCM_HCM_Master_gen_Employee_Sponsor_Master" %>

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
            if (document.getElementById("<%=hiddenDup.ClientID%>").value != "dup") {
                $noCon("div#divProject input.ui-autocomplete-input").focus();
            }
            document.getElementById("<%=hiddenDup.ClientID%>").value != "";


            $noCon("div#divProject input.ui-autocomplete-input").focus();
            $noCon("div#divProject input.ui-autocomplete-input").select();
        });
    </script>
    <script src="../../../JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="../../../JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>

    <link href="../../../css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {
                $au('#cphMain_ddlExistingCntrctr').selectToAutocomplete1Letter();
                $au('#cphMain_ddlProject').selectToAutocomplete1Letter();
                $au('#cphMain_ddlContractType').selectToAutocomplete1Letter();
                $au('#cphMain_ddlJobCtgry').selectToAutocomplete1Letter();
                $au('#cphMain_ddlParentCntrct').selectToAutocomplete1Letter();
                $au('form').submit(function () {

                    //   alert($au(this).serialize());


                    //   return false;
                });
            });
        })(jQuery);





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
                     window.location.href = "gen_Employee_Sponsor_List.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Employee_Sponsor_List.aspx";

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want to clear all data in this page?")) {
                     window.location.href = "gen_Employee_Sponsor_List.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Employee_Sponsor_List.aspx";
                 return false;
             }
         }
         function ClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want to clear all data in this page?")) {
                     window.location.href = "gen_Employee_Sponsor_Master.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Employee_Sponsor_Master.aspx";
                 return false;
             }
         }

         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sponsor details updated successfully.";
         }
         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sponsor details inserted successfully.";
         }
         function SuccessUpdationPrj() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Project details updated successfully.";
         }
         function SuccessConfirmationPrj() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sponsor details inserted successfully.";
         }
         function DuplicationName() {
            
             document.getElementById('divMessageArea').style.display = "";

             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!.Sponsor name can’t be duplicated.";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
           document.getElementById("<%=txtSponsorName.ClientID%>").focus();
             document.getElementById("<%=txtSponsorName.ClientID%>").style.borderColor = "Red";
         }
         function DuplicationCode() {
             document.getElementById('divMessageArea').style.display = "";
 
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                           }
    </script>
      <script type="text/javascript" >
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



          function Validate()
          {
       
              var ret = true;
             
              // replacing < and > tags
              var NameWithoutReplace = document.getElementById("<%=txtSponsorAddress1.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSponsorAddress1.ClientID%>").value = replaceText2;


            var NameWithoutReplace = document.getElementById("<%=txtSponsorAddress2.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSponsorAddress2.ClientID%>").value = replaceText2;
       
              var NameWithoutReplace = document.getElementById("<%=txtSponsorAddress3.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSponsorAddress3.ClientID%>").value = replaceText2;
            
              var NameWithoutReplace = document.getElementById("<%=txtSponsorName.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSponsorName.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtSponsorDocNo.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtSponsorDocNo.ClientID%>").value = replaceText2;
      
           
              $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divCntrctType input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divJobCtgry input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");

          
              document.getElementById('ErrorMsgMob').style.display = "none";
              document.getElementById('divMessageArea').style.display = "none";
              document.getElementById('imgMessageArea').src = "";
             document.getElementById('ErrorMsgMob1').style.display = "none";

          
              document.getElementById("<%=txtSponsorAddress1.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtSponsorAddress2.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlcountry.ClientID%>").style.borderColor = "";
              document.getElementById("<%=ddlSpnsrType.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtSponsorAddress3.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "";

              document.getElementById("<%=txtSponsorDocNo.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtSponsorFax.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtSponsorPhone.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtSponsorName.ClientID%>").style.borderColor = "";


              var Address = document.getElementById("<%=txtSponsorAddress1.ClientID%>").value.trim();
              var type = document.getElementById("<%=ddlSpnsrType.ClientID%>").value.trim();
              var Country = document.getElementById("<%=ddlcountry.ClientID%>").value;
            //  var CountryName = Country.options[Country.selectedIndex].text;
              var doc = document.getElementById("<%=txtSponsorDocNo.ClientID%>").value;
              var Mobile = document.getElementById("<%=txtMobile.ClientID%>").value;
              var name = document.getElementById("<%=txtSponsorName.ClientID%>").value.trim();
            var Email = document.getElementById("<%=txtSponsorEmail.ClientID%>").value.trim();
                  var phone = document.getElementById("<%=txtSponsorPhone.ClientID%>").value.trim();
        
              var mobileregular = /^(\+91-|\+91|0)?\d{10,50}$/;

              var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;



              //  alert(ret);
              

          if (Email != "") {

              if (!filter.test(Email)) {

                  document.getElementById('divMessageArea').style.visibility = "visible";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    // document.getElementById('divCustomerDetails').style.display = "";
                    // var ErrorMsg = document.getElementById('ErrorMsgEmail').style.display = "";
                    document.getElementById('ErrorMsgEmail').style.display = "";
                    var OrgMobileFocus = document.getElementById("<%=txtSponsorEmail.ClientID%>").focus();
                    document.getElementById("<%=txtSponsorEmail.ClientID%>").style.borderColor = "Red";
                    ret = false;
                }

          } if (phone != "") {

              if (!mobileregular.test(Mobile)) {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                document.getElementById('ErrorMsgMob1').style.display = "";
			         // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number";
			         var OrgMobileFocus = document.getElementById("<%=txtSponsorPhone.ClientID%>").focus();
                  document.getElementById("<%=txtSponsorPhone.ClientID%>").style.borderColor = "Red";
			         ret = false;
			     }
             }
            if (Mobile == "") {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                  document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
			     document.getElementById("<%=txtMobile.ClientID%>").focus();
			     ret = false;
			 }
			 if (Mobile != "") {

			     if (!mobileregular.test(Mobile)) {
			         document.getElementById('divMessageArea').style.display = "";
			         document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
			         document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";

                  document.getElementById('ErrorMsgMob').style.display = "";
                      // document.getElementById('ErrorMsgMob').innerHTML = "Inavalid Mobile Number";
                  var OrgMobileFocus = document.getElementById("<%=txtMobile.ClientID%>").focus();
                       document.getElementById("<%=txtMobile.ClientID%>").style.borderColor = "Red";
                      ret = false;
                  }
              }
              if (Address == "") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
               //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("<%=txtSponsorAddress1.ClientID%>").style.borderColor = "Red";
               document.getElementById("<%=txtSponsorAddress1.ClientID%>").focus();
               ret = false;
              }
              if (type == "--SELECT TYPE--") {

               document.getElementById('divMessageArea').style.display = "";
               document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
               document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                    //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("<%=ddlSpnsrType.ClientID%>").style.borderColor = "Red";
                    document.getElementById("<%=ddlSpnsrType.ClientID%>").focus();
                    ret = false;
                }
                if (Country == "--SELECT COUNTRY--") {
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddlcountry.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=ddlcountry.ClientID%>").focus();
                ret = false;
            }
              if (name == "")
              {

                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
          //     document.getElementById('divCustomerDetails').style.display = "";
                  document.getElementById("<%=txtSponsorName.ClientID%>").style.borderColor = "Red";
          document.getElementById("<%=txtSponsorName.ClientID%>").focus();
          ret = false;
             }
              return ret;

          }

    </script>
    <script>

        function UpdatePanelCustomerLoad(strCustId) {
                     CheckSubmitZero();


            $au('#cphMain_ddlExistingCntrctr').selectToAutocomplete1Letter();

            $au("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");

       
            var a = $au("#cphMain_ddlExistingCntrctr option:selected").text();

            $au("div#divExistingCust input.ui-autocomplete-input").val(a);

      
            $au("#cphMain_ddlExistingCntrctr").select();
        }



        function NewCustPageLoad(obj) {
            var $noC = jQuery.noConflict();


            if (confirm('Do you want to add a new cotractor?') == true) {

                var CustNme = '';

                if (obj == "ddlExistingCntrctr") {

                    CustNme = ''
                }
                var nWindow = window.open('/Master/gen_Customer_Master/gen_Customer_Master.aspx?CFAM=' + CustNme + '&CFTYP=CNTR', 'PoP_Up', 'width=1200,height=500,left=70,top=100,directories=no,navigationbar=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,resizable=yes,scrollbars=yes');
                nWindow.focus();
            }

            return false;
        }


        function closeWindow() {
            window.close();
        }
        function PostbackFun(myVal) {
                }

        function GetValueFromChild(myVal) {

            if (myVal != '') {

                //  alert(myVal);
                PostbackFun(myVal);
                //     alert(myVal);
            }
        }
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
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenNewCustId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDup" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustomerFocus" runat="server" Value="0" />
      <asp:HiddenField ID="HiddnEnableCacel" runat="server" Value="0" />

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
                     <div class="eachform" style="width: 49%; float: left;">
                            <h2 style="margin-left: 8%">Sponsor Name*</h2>
                            <asp:TextBox ID="txtSponsorName" TabIndex="2" class="form1" runat="server" MaxLength="100" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px"></asp:TextBox>
                     </div>


                <div class="eachform" style="width: 47%; float: right; margin-top: 0%;margin-left: 0%;">
                    <h2 style="margin-left: 0%">Nationality* </h2>

                           
                       <asp:DropDownList ID="ddlcountry" class="form1" TabIndex="2"  style="width: 56%; text-transform: uppercase; margin-right: 8.8%; height: 30px" runat="server">
                </asp:DropDownList>


                            </div>
            
                <div class="eachform" style="width: 49%; float: left;margin-left: 4%;">
                    <h2 style="margin-left: 0%">Document Number </h2>

                   <asp:TextBox ID="txtSponsorDocNo" TabIndex="2" class="form1" runat="server"  MaxLength="50" Style="width: 50%; text-transform: uppercase; margin-right: 12.7%; height: 30px"></asp:TextBox>
                   </div>
                  <div class="eachform" style="width: 44%; float: left;">
                    <h2 style="margin-left: 0%">Type* </h2>

                       <asp:DropDownList ID="ddlSpnsrType" class="form1" TabIndex="2"  style="width: 59.3%; text-transform: uppercase; margin-right: 2.8%; height: 30px" runat="server">
                    
                    <%--<asp:ListItem Text="All" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Individual" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Company" Value="2"></asp:ListItem>--%>
                </asp:DropDownList>


                            </div>
                 <div id="divCntrctType" class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Address1*</h2>
                 <asp:TextBox ID="txtSponsorAddress1" TabIndex="4" class="form1" runat="server" MaxLength="50" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px"></asp:TextBox>
           </div>

                   <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Address2</h2>
                     <asp:TextBox ID="txtSponsorAddress2" TabIndex="4" class="form1" runat="server" MaxLength="50" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px"></asp:TextBox>
                     
                </div>
                  <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Address3</h2>
                     <asp:TextBox ID="txtSponsorAddress3" TabIndex="4" class="form1" runat="server" MaxLength="50" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px"></asp:TextBox>
                     
                </div>
                   <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Mobile*</h2>
                     <asp:TextBox ID="txtMobile" TabIndex="4" class="form1" runat="server" MaxLength="50"  Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px" onkeydown="return isNumber(event)"></asp:TextBox>
                     <p class="error" id="ErrorMsgMob" style="display:none;font-family:Calibri">Please Enter Valid Mobile Number</p>
     
                </div>
                     <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Phone</h2>
                     <asp:TextBox ID="txtSponsorPhone" TabIndex="4" class="form1" runat="server" MaxLength="10" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px" onkeydown="return isNumber(event)"></asp:TextBox>
                       <p class="error" id="ErrorMsgMob1" style="display:none;font-family:Calibri">Please Enter Valid Phone Number</p>
   
                </div>
                   <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Email</h2>
                     <asp:TextBox ID="txtSponsorEmail" TabIndex="4" class="form1" runat="server" MaxLength="50" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px" onblur="RemoveTag(this)"></asp:TextBox>
                                     <p class="error" id="ErrorMsgEmail" style="display:none;font-family:Calibri">Please Enter Valid Email Id</p>
                </div>
                       <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Fax</h2>
                     <asp:TextBox ID="txtSponsorFax" TabIndex="4" class="form1" runat="server" MaxLength="10" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px" onblur="RemoveTag(this)" onkeydown="return isNumber(event)"></asp:TextBox>
                     
                </div>
            	
        

     
               
                      <div class="eachform" style="width: 49%; float: left; margin-top: 0%">
                    <h2 style="margin-left: 8%">Status*</h2>
                    <div class="subform" style="width: 30%; margin-right: 26%; padding-top: 7px;">
                        <asp:CheckBox ID="cbxStatus" TabIndex="9" Text="" runat="server" Checked="true" class="form2" />

                        <h3>Active</h3>

                    </div>
                </div>

                <div class="eachform" style="width: 99%; margin-top: 3%; float: none">
                    <div class="subform" style="width: 70%; margin-left: 60%">

                    <asp:Button ID="btnUpdate" TabIndex="10" runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnUpdateClose" TabIndex="11" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnAdd" TabIndex="10" runat="server" class="save" Text="Save"  OnClientClick="return Validate();" OnClick="btnAdd_Click"/>
       
                    <asp:Button ID="btnAddClose" TabIndex="11" runat="server" class="save" Text="Save & Close" OnClientClick="return Validate();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancel" TabIndex="12" runat="server" class="cancel" OnClientClick="return AlertClearAll();" Text="Cancel" PostBackUrl="gen_Employee_Sponsor_List.aspx"  />
                    <asp:Button ID="btnClear" TabIndex="13" runat="server" style="margin-left: 19px;" OnClientClick="return ClearAll();"  class="cancel" Text="Clear"/>
                        <asp:HiddenField ID="Hiddensponsorid" runat="server" />
        
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

