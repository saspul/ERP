<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage_Compzit_GMS.master" AutoEventWireup="true" CodeFile="gen_Contract_Master.aspx.cs" Inherits="GMS_GMS_Master_gen_Contract_Master_gen_Contract_Master" %>

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
                 if (confirm("Are You Sure You Want To Leave This Page?")) {
                     window.location.href = "gen_Contract_Master_List.aspx";
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Contract_Master_List.aspx";

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are You Sure You Want Clear All Data In This Page?")) {
                     window.location.href = "gen_Contract_Master.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "gen_Contract_Master.aspx";
                 return false;
             }
         }


         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Contract Details Updated Successfully.";
         }
         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Contract Details Inserted Successfully.";
         }
         function SuccessUpdationPrj() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Project Details Updated Successfully.";
         }
         function SuccessConfirmationPrj() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Project Details Inserted Successfully.";
         }
         function DuplicationName() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById("<%=txtContractName.ClientID%>").style.borderColor = "Red";
             document.getElementById("<%=txtContractName.ClientID%>").focus();
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Contract Name Can’t be Duplicated.";
             document.getElementById("<%=hiddenDup.ClientID%>").value = "dup";
         }
         function DuplicationCode() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById("<%=txtContractCode.ClientID%>").style.borderColor = "Red";
             document.getElementById("<%=txtContractCode.ClientID%>").focus();
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication Error!. Contract Code Can’t be Duplicated.";
             document.getElementById("<%=hiddenDup.ClientID%>").value = "dup";
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



          function Validate() {
              var ret = true;
              if (CheckIsRepeat() == true) {
              }
              else {
                  ret = false;
                  return ret;
              }
              // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtContractName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtContractName.ClientID%>").value = replaceText2;

              var NameWithoutReplace = document.getElementById("<%=txtContractCode.ClientID%>").value;
              var replaceText1 = NameWithoutReplace.replace(/</g, "");
              var replaceText2 = replaceText1.replace(/>/g, "");
              document.getElementById("<%=txtContractCode.ClientID%>").value = replaceText2;

              document.getElementById("<%=txtContractName.ClientID%>").style.borderColor = "";
              document.getElementById("<%=txtContractCode.ClientID%>").style.borderColor = "";
              $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divCntrctType input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divJobCtgry input.ui-autocomplete-input").css("borderColor", "");
              $noCon("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");

              var CntrctName = document.getElementById("<%=txtContractName.ClientID%>").value.trim();
              var CntrctCode = document.getElementById("<%=txtContractCode.ClientID%>").value.trim();

              var ProjectDdl = document.getElementById("<%=ddlProject.ClientID%>");
              var ProjectText = ProjectDdl.options[ProjectDdl.selectedIndex].text;

              var CntrctTypeDdl = document.getElementById("<%=ddlContractType.ClientID%>");
              var CntrctTypeText = CntrctTypeDdl.options[CntrctTypeDdl.selectedIndex].text;

              var JobCtgryDdl = document.getElementById("<%=ddlJobCtgry.ClientID%>");
              var JobCtgryText = JobCtgryDdl.options[JobCtgryDdl.selectedIndex].text;

              var CntrctrDdl = document.getElementById("<%=ddlExistingCntrctr.ClientID%>");
              var CntrctrText = CntrctrDdl.options[CntrctrDdl.selectedIndex].value;


               document.getElementById('divMessageArea').style.display = "none";
               document.getElementById('imgMessageArea').src = "";

              if (CntrctrText == "--SELECT CONTRACTOR--") {

                       document.getElementById('divMessageArea').style.display = "";
                       document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                       document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                       $noCon("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "red");
                       $noCon("div#divExistingCust input.ui-autocomplete-input").focus();
                       $noCon("div#divExistingCust input.ui-autocomplete-input").select();
                       ret = false;
               }
             
              
              if (JobCtgryText == "--SELECT JOB CATEGORY--") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  $noCon("div#divJobCtgry input.ui-autocomplete-input").css("borderColor", "red");
                  $noCon("div#divJobCtgry input.ui-autocomplete-input").focus();
                  $noCon("div#divJobCtgry input.ui-autocomplete-input").select();
                  ret = false;
               }
              if (CntrctTypeText == "--SELECT CONTRACT CATEGORY--") {
                   document.getElementById('divMessageArea').style.display = "";
                   document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                   document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                   $noCon("div#divCntrctType input.ui-autocomplete-input").css("borderColor", "red");
                   $noCon("div#divCntrctType input.ui-autocomplete-input").focus();
                   $noCon("div#divCntrctType input.ui-autocomplete-input").select();
                   ret = false;
               }
              if (CntrctCode == "") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtContractCode.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtContractCode.ClientID%>").focus();
                  ret = false;
              }
              if (CntrctTypeText == "--SELECT CONTRACT CATEGORY--") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=ddlContractType.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=ddlContractType.ClientID%>").focus();
                  ret = false;
              }

              if (CntrctName == "") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  document.getElementById("<%=txtContractName.ClientID%>").style.borderColor = "Red";
                  document.getElementById("<%=txtContractName.ClientID%>").focus();
                  ret = false;
              }
              if (ProjectText == "--SELECT PROJECT--") {
                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  $noCon("div#divProject input.ui-autocomplete-input").css("borderColor", "red");
                  $noCon("div#divProject input.ui-autocomplete-input").focus();
                  $noCon("div#divProject input.ui-autocomplete-input").select();
                  ret = false;
              }



            if (ret == false) {
                CheckSubmitZero();

            }

            return ret;
        }

    </script>
    <script>

        function UpdatePanelCustomerLoad(strCustId) {
            document.getElementById("<%=hiddenNewCustId.ClientID%>").value = "";
             CheckSubmitZero();


            $au('#cphMain_ddlExistingCntrctr').selectToAutocomplete1Letter();

             document.getElementById("<%=ddlExistingCntrctr.ClientID%>").style.borderColor = "";
            $au("div#divExistingCust input.ui-autocomplete-input").css("borderColor", "");

            document.getElementById("<%=ddlExistingCntrctr.ClientID%>").value = strCustId;
            var a = $au("#cphMain_ddlExistingCntrctr option:selected").text();

            $au("div#divExistingCust input.ui-autocomplete-input").val(a);

            document.getElementById("<%=ddlExistingCntrctr.ClientID%>").focus();
            $au("#cphMain_ddlExistingCntrctr").select();
        }



        function NewCustPageLoad(obj) {
            var $noC = jQuery.noConflict();


            if (confirm('Do you want to add a new contractor?') == true) {

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
            document.getElementById("<%=hiddenNewCustId.ClientID%>").value = myVal;
            __doPostBack("<%=btnNewCust.UniqueID %>", "");
            return false;
        }

        function GetValueFromChild(myVal) {

            if (myVal != '') {

                //  alert(myVal);
                PostbackFun(myVal);
                //     alert(myVal);
            }
        }
        //evm-0012 Adding Contracts
        function PassSavedContractToRFG(strContractId) {
            if (window.opener != null && !window.opener.closed) {

                window.opener.GetValueFromChildContract(strContractId);
            }
            window.close();
        }

        
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:HiddenField ID="hiddenNewCustId" runat="server" Value="0" />
     <asp:HiddenField ID="hiddenDup" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenCustomerFocus" runat="server" Value="0" />

    <div class="cont_rght">

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
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>

            <div id="divGreySection">
                <div id="divProject" class="eachform" style="width: 49%; float: left; margin-top: 3%;">
                    <h2 style="margin-left: 8%;margin-top:4px">Project *</h2>

                    <asp:DropDownList ID="ddlProject" TabIndex="1" class="form1" Style="float: right; width: 50% !important; margin-right: 4.5%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>

                </div>


                <div class="eachform" style="width: 49%; float: right; margin-top: 3%;">
                    <h2 style="margin-left: 11%">Ref*</h2>

                    <asp:Label ID="lblRefNumber" class="form1" runat="server" Style="padding-top:2px; margin-right: 18%; border: none;font-family:Calibri;font-size:15px;font-weight: bold"></asp:Label>
                </div>
                    <div class="eachform" style="width: 49%; float: left;">
                            <h2 style="margin-left: 8%">Contract Name *</h2>
                            <asp:TextBox ID="txtContractName" TabIndex="2" class="form1" runat="server" MaxLength="100" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px"></asp:TextBox>
                     </div>
                 <div id="divCntrctType" class="eachform" style="width: 49%; float: right;">
                    <h2 style="margin-left: 11%">Contract Category*</h2>
                    <asp:DropDownList ID="ddlContractType" TabIndex="3" class="form1" Style="float: right; width: 47%!important; margin-right: 10%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>
                </div>

                 <div class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 8%">Contract Code *</h2>
                     <asp:TextBox ID="txtContractCode" TabIndex="4" class="form1" runat="server" MaxLength="100" Style="width: 50%; text-transform: uppercase; margin-right: 4.7%; height: 30px"></asp:TextBox>
                     
                </div>


                 <div id="divJobCtgry" class="eachform" style="width: 49%; float: right;">
                    <h2 style="margin-left: 11%">Job Category*</h2>
                    <asp:DropDownList ID="ddlJobCtgry" TabIndex="5" class="form1" Style="float: right; width: 47%!important; margin-right: 10%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>

                </div>

                  <asp:TextBox ID="txtCustName" TabIndex="4" class="form1" runat="server" MaxLength="100" Style="display:none"></asp:TextBox>
                <div class="eachform" style="width: 49%; float: left">
                    <h2 style="margin-left: 8%">Contractor*</h2>
                        <div style="width: 59%; float: right;">
                           <div id="divExistingCust">
                             <asp:DropDownList ID="ddlExistingCntrctr" TabIndex="7" class="form1" Style="float: left; width: 81%!important; margin-left: 1.5%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                              </asp:DropDownList>
                              <asp:Button ID="btnNewCust" runat="server" class="save" ToolTip="Add Contractor" Style="margin-left: 0.1%; padding: 1%; border-radius: 0px; padding-bottom: 3%;" Text="+" OnClientClick="return NewCustPageLoad('ddlExistingCntrctr')" OnClick="btnNewCust_Click" />
                          </div>
                    </div>
                 </div>

                <div class="eachform" style="width: 49%; float: right;margin-top: 0%;">
                    <h2 style="margin-left: 10.5%;">Parent Contract</h2>

                    <asp:DropDownList ID="ddlParentCntrct" TabIndex="8" class="form1" Style="float: right; width: 47%!important; margin-right: 10%;" runat="server" autofocus="autofocus" autocorrect="off" autocomplete="off">
                    </asp:DropDownList>  

                </div>
                <div class="eachform" style="width: 49%; float: left; margin-top: 0%">
                    <h2 style="margin-left: 15%">Status*</h2>
                    <div class="subform" style="width: 30%; margin-right: 26%; padding-top: 7px;">
                        <asp:CheckBox ID="cbxStatus" TabIndex="9" Text="" runat="server" Checked="true" class="form2" />

                        <h3>Active</h3>

                    </div>
                </div>

                <div class="eachform" style="width: 99%; margin-top: 3%; float: left">
                    <div class="subform" style="width: 70%; margin-left: 38%">

                    <asp:Button ID="btnUpdate" TabIndex="10" runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnUpdateClose" TabIndex="11" runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"  />
                    <asp:Button ID="btnAdd" TabIndex="10" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddNext" runat="server" class="save" Text="Save & Next" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnAddClose" TabIndex="11" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return Validate();" />
                    <asp:Button ID="btnCancel" TabIndex="12" runat="server" class="cancel" Text="Cancel" PostBackUrl="gen_Contract_Master_List.aspx"  />
                    <asp:Button ID="btnClear" TabIndex="13" runat="server" style="margin-left: 19px;" OnClientClick="return AlertClearAll();"  class="cancel" Text="Clear"/>
                    <asp:Button ID="btnSkip" TabIndex="14" runat="server" style="margin-left: 19px;" onclick="btnSkip_Click"  class="cancel" Text="Skip"/>
                    <asp:Button ID="btnCloseWindow" TabIndex="15" runat="server" Visible = "true" style="margin-left: 19px;" OnClientClick="return closeWindow();" class="cancel" Text="Close"/>

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

