<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Notice_Period.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Notice_Period_hcm_Notice_Period" %>

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
            /*width: 52.6%;*/
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
   
    <script src="/JavaScript/Autocomplete/jquery-1.11.1.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery-ui.min.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete.js"></script>
    <script src="/JavaScript/Autocomplete/jquery.select-to-autocomplete_1LETTER.js"></script>
    <link href="/css/Autocomplete/jquery-ui.css" rel="stylesheet" />
    <script>




        var $au = jQuery.noConflict();

        (function ($au) {
            $au(function () {

                $au('#cphMain_ddlDesgntn').selectToAutocomplete1Letter();
                $au('form').submit(function () {


                });
            });
        })(jQuery);
        </script>
      <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>

    <script>

        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {
           
            $noCon("div#divDesg input.ui-autocomplete-input").focus();
            $noCon("div#divDesg input.ui-autocomplete-input").select();
          
           
        });
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
                     window.location.href = "hcm_Notice_Period_List.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "hcm_Notice_Period_List.aspx";
                 return false;

             }
         }
         function AlertClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want to clear all data in this page?")) {
                     window.location.href = "hcm_Notice_Period_List.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "hcm_Notice_Period_List.aspx";
                 return false;
             }
         }
         function ClearAll() {
             if (confirmbox > 0) {
                 if (confirm("Are you sure you want to clear all data in this page?")) {
                     window.location.href = "hcm_Notice_Period.aspx";
                     return false;
                 }
                 else {
                     return false;
                 }
             }
             else {
                 window.location.href = "hcm_Notice_Period.aspx";
                 return false;
             }
         }

         function SuccessUpdation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notice period details updated successfully.";
         }
         function SuccessConfirmation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Notice period details inserted successfully.";
         }
        
        
         function DuplicationCode() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Duplication error!.Designation can’t be duplicated.";
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
         
          // for not allowing enter
          function DisableEnter(evt) {

              evt = (evt) ? evt : window.event;
              var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
              if (keyCodes == 13) {
                  return false;
              }
          }
          function DisableRightClick(event) {

              //For mouse right click

              if (event.button == 2) {

                  return false;

              }

          }
        



          function Validate() {

              var ret = true;

             // replacing < and > tags
             var NameWithoutReplace = document.getElementById("<%=txtNtcPrddays.ClientID%>").value;
             var replaceText1 = NameWithoutReplace.replace(/</g, "");
             var replaceText2 = replaceText1.replace(/>/g, "");
             document.getElementById("<%=txtNtcPrddays.ClientID%>").value = replaceText2;


              $noCon("div#divDesg input.ui-autocomplete-input").css("borderColor", "");
              document.getElementById("<%=txtNtcPrddays.ClientID%>").style.borderColor = "";

              var Days = document.getElementById("<%=txtNtcPrddays.ClientID%>").value.trim();
              var Desg = document.getElementById("<%=ddlDesgntn.ClientID%>").value;
           
             
              if (Days == "") {

                 document.getElementById('divMessageArea').style.display = "";
                 document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                 document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                 document.getElementById("<%=txtNtcPrddays.ClientID%>").style.borderColor = "Red";
                 document.getElementById("<%=txtNtcPrddays.ClientID%>").focus();
                  ret = false;
              }
              if (Desg == "--SELECT DESIGNATION--") {

                  document.getElementById('divMessageArea').style.display = "";
                  document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                  document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                  $noCon("div#divDesg input.ui-autocomplete-input").css("borderColor", "red");
                  $noCon("div#divDesg input.ui-autocomplete-input").focus();
                  ret = false;
              }
            

              if (ret == false) {

                  CheckSubmitZero();

              }
              
              return ret;

          }

    </script>
    <script>

      

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            //at enter
            if (keyCodes == 13 || keyCodes == 16) {

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
        function checkDays() {
            document.getElementById('divMessageArea').style.display = "none";
            var Days = document.getElementById("<%=txtNtcPrddays.ClientID%>").value.trim();
            if (isNaN(parseInt(Days)) == true || Days > 365 || Days < 0) {
                document.getElementById("<%=txtNtcPrddays.ClientID%>").value = 0;
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Please enter days within the range of 0 to 365 .";
            }
            else {               
                document.getElementById("<%=txtNtcPrddays.ClientID%>").value = parseInt(Days);                          
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

        <div id="divList" class="list" onclick="ConfirmMessage();" runat="server" style="position: fixed; right: 0%; top: 49%; height: 26.5px;">

            <%--   <a href="gen_ProjectsList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>

        <div class="fillform" style="width: 100%">
            <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; margin-bottom: 2.5%;">
                <asp:Label ID="lblEntry" runat="server"></asp:Label>
            </div>
                     


            <div>
              
                  <div id="divDesg" class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 0%">Designation* </h2>

                       <asp:DropDownList ID="ddlDesgntn" class="form1"  style="width: 59.3%; text-transform: uppercase; margin-right: 2.8%; height: 30px" runat="server">
                    
                   
                </asp:DropDownList>


                            </div>
                 <div  class="eachform" style="width: 49%; float: left;">
                    <h2 style="margin-left: 15%">Notice Period*</h2>
                 <asp:TextBox ID="txtNtcPrddays"  class="form1" runat="server" MaxLength="3" value="0" Style="width: 5%; text-transform: uppercase; float:left;margin-left:12%; height: 30px" onkeypress="return isNumber(event);" onkeydown="return isNumber(event);"  onblur="checkDays();"></asp:TextBox>
                  <h2 style="margin-left: 1%">Days</h2>
              </div>

                        
                      <div class="eachform" style="width: 49%; float: left; margin-top: 1%">
                    <h2 style="margin-left: 0%">Status*</h2>
                    <div class="subform" style="width: 30%; margin-right: 36%; padding-top: 7px;">
                        <asp:CheckBox ID="cbxStatus"  Text="" runat="server" Checked="true" class="form2" />

                        <h3>Active</h3>

                    </div>
                </div>

                <div class="eachform" style="width: 99%; margin-top: 3%; float: none">
                    <div class="subform" style="width: 70%; margin-left: 60%">

                    <asp:Button ID="btnUpdate"  runat="server" class="save" Text="Update" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnUpdateClose"  runat="server" class="save" Text="Update & Close" OnClientClick="return Validate();" OnClick="btnUpdate_Click"/>
                    <asp:Button ID="btnAdd"  runat="server" class="save" Text="Save"  OnClientClick="return Validate();" OnClick="btnAdd_Click"/>
       
                    <asp:Button ID="btnAddClose"  runat="server" class="save" Text="Save & Close" OnClientClick="return Validate();" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancel"  runat="server" class="cancel" OnClientClick="return ConfirmMessage();" Text="Cancel" PostBackUrl="gen_Employee_Sponsor_List.aspx"  />
                    <asp:Button ID="btnClear"  runat="server" style="margin-left: 19px;" OnClientClick="return ClearAll();"  class="cancel" Text="Clear"/>
                        <asp:HiddenField ID="Hiddensponsorid" runat="server" />
        
               </div>
                </div>


                <br style="clear: both" />
            </div>




        </div>
 

    <style>

        .form1 {
            
            height: 27px;
        }
    </style>
</asp:Content>


