<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Resignation_Master.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Resignation_Master_hcm_Resignation_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style>
        #divErrorRsnAWMS {
            border-radius: 4px;
            background: #fff;
            color: #53844E;
            font-size: 12.5px;
            font-family: Calibri;
            font-weight: bold;
            border: 2px solid #53844E;
            margin-top: -3.5%;
            margin-bottom: 2%;
        }
    </style>
    <script src="/JavaScript/jquery-1.8.3.min.js"></script>


    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {



            if (document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value != "") {
                  document.getElementById("cphMain_btnResign").style.display = "none";
                  document.getElementById("divUserform").style.display = "block";
                  document.getElementById("divButtons").style.display = "block";
              }
              if (document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value != "0" &&
                  document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value != "" &&
                  document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value != null) {
                  document.getElementById("divStatus").style.display = "block";
                  document.getElementById("cphMain_Image1").style.pointerEvents = "none";
                  document.getElementById("divButtons").style.display = "none";

                  if (document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value != "7" &&
                  document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value != "8" &&
                  document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value != "9" &&
                 document.getElementById("<%=HiddenFieldCancelUsrRole.ClientID%>").value == "1"

                      ) {
                      document.getElementById("cphMain_divAirptClose").style.visibility = "visible";



                  }
                  if (document.getElementById("<%=HiddenFieldEndServiceSts.ClientID%>").value == "1") {
                      document.getElementById("cphMain_divAirptClose").style.visibility = "hidden";

                  }
                  if (document.getElementById("<%=HiddenFieldResgntnSts.ClientID%>").value == "6") {

                      document.getElementById("cphMain_btnClearanceLink").style.display = "block";
                  }

              }


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

            if (confirm("Are you sure you want to leave this page?")) {
                window.location.href = "gen_Leave_Approval.apsx";
                return true;
            }
            else {
                return false;
            }
        }



        function AlertClearAll() {
            if (confirmbox > 0) {
                if (confirm("Are you sure you want clear all data in this page?")) {
                    window.location.href = "hcm_Resignation_Master.aspx";
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                window.location.href = "hcm_Resignation_Master.aspx";
                return true;
            }
        }


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
        function DisableEnter(evt) {
            //  var b = new Date(); alert(b);

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
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
        function showdivUserform() {

            document.getElementById("divUserform").style.display = "block";
            document.getElementById("divButtons").style.display = "block";
            return false;
        }

        function SuccessAdd() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Resignation details inserted successfully.";
      }
      function SuccessUpd() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Resignation details updated successfully.";
      }
      function SuccessCnfrm() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Resignation details confirmed successfully.";
      }
      function SuccessCancel() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Resignation details cancelled successfully.";
      }


      function SuccessInsClrnce() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance staff form details inserted successfully.";
      }
      function SuccessUpdClrnce() {
          document.getElementById('divMessageArea').style.display = "";
          document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
          document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Clearance staff form details updated successfully.";
            }
            function CloseRqst() {
                if (confirm("Are you sure you want to cancel this resignation request?")) {

                    var UserId = document.getElementById("<%=HiddenFieldEmpId.ClientID%>").value;
              var ResgntnId = document.getElementById("<%=HiddenFieldResgntnId.ClientID%>").value;


              var Details = PageMethods.CancelRqst(ResgntnId, UserId, function (response) {

                  window.location.href = "hcm_Resignation_Master.aspx?Ins=Cncl";

              });
          }
      }

      function ResignValidate(x) {


          var ret = true;
          if (CheckIsRepeat() == true) {

          }
          else {
              ret = false;
              return ret;
          }
          // replacing < and > tags
          document.getElementById("<%=txtPrfrdDate.ClientID%>").style.borderColor = "";
          document.getElementById("<%=txtReason.ClientID%>").style.borderColor = "";

          var CrdExpWithoutReplace = document.getElementById("<%=txtPrfrdDate.ClientID%>").value.trim();
          var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
          var replaceCode2 = replaceCode1.replace(/>/g, "");
          document.getElementById("<%=txtPrfrdDate.ClientID%>").value = replaceCode2;

             var CrdExpWithoutReplace = document.getElementById("<%=txtReason.ClientID%>").value.trim();
          var replaceCode1 = CrdExpWithoutReplace.replace(/</g, "");
          var replaceCode2 = replaceCode1.replace(/>/g, "");
          document.getElementById("<%=txtReason.ClientID%>").value = replaceCode2;

             var PrfrdDate = document.getElementById("<%=txtPrfrdDate.ClientID%>").value;
          var Reason = document.getElementById("<%=txtReason.ClientID%>").value;

          var presenrdate = document.getElementById("<%=hiddenCurrentDate.ClientID%>").value;
          var arrpresenrdate = presenrdate.split("-");
          var datepresenrdate = new Date(arrpresenrdate[2], arrpresenrdate[1] - 1, arrpresenrdate[0]);




          if (Reason == "") {
              document.getElementById('divMessageArea').style.display = "";
              document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
              document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                            document.getElementById("<%=txtReason.ClientID%>").style.borderColor = "Red";
                            document.getElementById("<%=txtReason.ClientID%>").focus();
                            ret = false;
                        }

          //For Current date checking
                        if (PrfrdDate != "") {



                            var arrpresenrdateRetrn = PrfrdDate.split("-");
                            var datepresenrdateRetrn = new Date(arrpresenrdateRetrn[2], arrpresenrdateRetrn[1] - 1, arrpresenrdateRetrn[0]);
                            if (datepresenrdateRetrn <= datepresenrdate) {

                                document.getElementById('divMessageArea').style.display = "";
                                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Sorry, preferred leaving date should be greater than current date !";
                                document.getElementById("<%=txtPrfrdDate.ClientID%>").style.borderColor = "Red";
                                document.getElementById("<%=txtPrfrdDate.ClientID%>").focus();
                                ret = false;

                            }

                        }

                        if (ret != false && x == 1) {
                            if (confirm("Are you sure you want to confirm this resignation request?")) {
                            }
                            else {
                                ret = false;
                            }
                        }
                        if (ret == false) {

                            CheckSubmitZero();

                        }


                        return ret;
                    }
    </script>

    <%--FOR DATE TIME PICKER--%>
    <script type="text/javascript" src="../../../../JavaScript/Date/JavaScriptDate1_8_3.js"></script>
    <script type="text/javascript" src="../../../../JavaScript/Date/JavaScriptDate2_2_2_bootstap.js"></script>
    <script type="text/javascript" src="../../../../JavaScript/Date/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../../../../JavaScript/Date/bootstrap-datepicker_pt_br.js"></script>
    <link href="../../../../css/Date/StyleSheetDate.css" rel="stylesheet" />
    <link href="../../../../css/Date/StyleSheetDate2.css" rel="stylesheet" />

    <style>
        .textDate:focus {
            border: 1px solid #bbf2cf;
            box-shadow: 0px 0px 4px 2.5px #bbf2cf;
        }

        .textDate {
            border: 1px solid #cfcccc;
        }

        .open > .dropdown-menu {
            display: none;
        }

        .bootstrap-datetimepicker-widget {
            z-index: 100;
        }

        .eachform h2 {
            margin: 6px 0 6px;
        }
    </style>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:HiddenField ID="HiddenFieldEndServiceSts" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenFieldCancelUsrRole" runat="server" />
    <asp:HiddenField ID="hiddenCurrentDate" runat="server" />
    <asp:HiddenField ID="HiddenFieldEmpId" runat="server" />
    <asp:HiddenField ID="HiddenFieldResgntnSts" runat="server" />
    <asp:HiddenField ID="HiddenFieldResgntnId" runat="server" />
    <div id="divMessageArea" style="display: none; width: 99%;">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>
    <div class="cont_rght">



        <div style="width: 98.5%; border: 1px solid #8e8f8e; padding: 10px; background-color: white; float: left">
            <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
                <img src="/Images/BigIcons/Resignation.png" style="vertical-align: middle;" />
                <asp:Label ID="lblEntry" runat="server">Resignation</asp:Label>
            </div>





            <div style="float: left; width: 97.5%; padding: 10px; margin-top: 2%; border: 1px solid #929292; background-color: rgb(227, 227, 227);">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee</h2>
                    <asp:Label ID="lblEmpname" class="form5" runat="server" Style="font-family: Calibri; font-size: 14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesg" class="form5" runat="server" Style="font-family: Calibri; font-size: 14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Department</h2>
                    <asp:Label ID="lblDeprtmnt" class="form5" runat="server" Style="font-family: Calibri; font-size: 14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Division</h2>
                    <asp:Label ID="lblDivision" class="form5" runat="server" Style="font-family: Calibri; font-size: 14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblPaygrade" class="form5" runat="server" Style="font-family: Calibri; font-size: 14px;"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <asp:Button ID="btnResign" runat="server" class="cancel" Text="Resign" OnClientClick="return showdivUserform();" />
                </div>
            </div>
            <div id="divUserform" style="float: left; width: 97.5%; padding: 10px; margin-top: 2%; border: 1px solid #929292; display: none;">

                <div class="eachform" style="float: left; margin-top: -1%;">
                    <asp:Label ID="lblResgnMsg" class="form5" runat="server" Style="font-family: Calibri; font-size: 18px; margin-left: -1%; color: red; float: left;"></asp:Label>
                </div>
                <div class="eachform" style="width: 100%; margin-top: 1%;">
                    <h2>Preferred Leaving Date</h2>
                    <div id="Div2" class="input-append date" style="font-family: Calibri; float: left; width: 34.5%; margin-left: 6.2%;">
                        <asp:TextBox ID="txtPrfrdDate" class="textDate" placeholder="DD-MM-YYYY" MaxLength="20" runat="server" Style="width: 83%; height: 23px; font-family: calibri;"></asp:TextBox>

                        <input id="Image1" type="image" class="add-on" src="/Images/Icons/CalandarIcon.png" runat="server" style="height: 17px; width: 12px; cursor: pointer;" />

                        <script type="text/javascript">
                            var $noCo = jQuery.noConflict();
                            var year = (new Date).getFullYear();
                            year = year + 2;
                            var today = new Date();
                            var tomorrow = new Date();
                            tomorrow.setDate(today.getDate() + 1);

                            $noCo('#Div2').datetimepicker({
                                format: 'dd-MM-yyyy',
                                language: 'en',
                                pickTime: false,
                                endDate: new Date(year, '0', '0'),
                                startDate: tomorrow,

                            })



                        </script>
                        <p style="visibility: hidden">Please enter</p>
                    </div>


                </div>
                <div class="eachform" style="width: 100%; float: left;">
                    <h2>Reason*</h2>
                    <asp:TextBox ID="txtReason" class="form1" runat="server" MaxLength="50" TextMode="MultiLine" Style="width: 30%; margin-left: 16.6%; height: 80px; resize: none; font-family: calibri; float: left;" onblur="textCounter(cphMain_txtReason,450)" onkeydown="textCounter(cphMain_txtReason,450)" onkeyup="textCounter(cphMain_txtReason,450)"></asp:TextBox>
                </div>



            </div>



            <div id="divButtons" class="eachform" style="display: none;">
                <div class="subform" style="width: 62%; margin-top: 5%">

                    <asp:Button ID="btnConfirm" runat="server" class="save" Text="Confirm" OnClick="btnConfirm_Click" OnClientClick="return ResignValidate(1);" />
                    <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return ResignValidate(0);" />
                    <%--    <asp:Button ID="btnUpdateClose" runat="server" class="save" Text="Update & Close" OnClick="btnUpdate_Click" OnClientClick="return ResignValidate();"/>--%>
                    <asp:Button ID="btnAdd" runat="server" class="save" Text="Save" OnClick="btnAdd_Click" OnClientClick="return ResignValidate(0);" />
                    <%--                     <asp:Button ID="btnAddClose" runat="server" class="save" Text="Save & Close" OnClick="btnAdd_Click" OnClientClick="return ResignValidate();"/>--%>
                    <%--   <asp:Button ID="btnCancel" runat="server" class="cancel" Text="Cancel" OnClientClick="return CancelAlert();"/>--%>
                    <asp:Button ID="btnClear" runat="server" Style="margin-left: 13px;" OnClientClick="return AlertClearAll();" OnClick="btnClear_Click" class="cancel" Text="Clear" />
                </div>
            </div>


            <div id="divStatus" class="eachform" style="float: left; width: 55%; height: 90px; border: 1px solid; background-color: #e3e3e3; border-color: darkgrey; padding-left: 2%; display: none; margin-top: 2%;">
                <h2 style="font-size: 20px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; width: 100%;">Status</h2>
                <h2 id="status1" runat="server" style="font-size: 17px; font-weight: bold; color: rgb(224, 87, 24); font-family: Calibri; width: 100%;"></h2>
                <h2 id="status2" runat="server" style="font-size: 17px; font-weight: bold; color: rgb(224, 87, 24); font-family: Calibri; width: 100%;"></h2>
            </div>


            <div class="eachform" style="width: 40%; float: right;">
                <div id="divAirptClose" runat="server" style="width: 30%; margin-left: 7%; margin-top: 6%; cursor: pointer; visibility: hidden;" onclick="CloseRqst()">
                    <img id="imgAirptClose" runat="server" src="/Images/Icons/close guarantee.png" style="margin-left: 23%; width: 37%;" />
                    <h2 style="margin-top: 1%; font-size: 15px; margin-left: 23%;">Cancel Resignation Request</h2>
                </div>


                <asp:Button ID="btnClearanceLink" runat="server" class="save" Text="Go To Clearance Form" Style="margin-left: 9%; display: none;" OnClick="btnClrnceLink_Click" />
            </div>











        </div>

    </div>
    <style>
        .form5 {
            width: 70%;
            padding: 0px 8px;
            float: right;
            color: #000;
            font-size: 13px;
            margin-top: 2%;
        }
    </style>

</asp:Content>



