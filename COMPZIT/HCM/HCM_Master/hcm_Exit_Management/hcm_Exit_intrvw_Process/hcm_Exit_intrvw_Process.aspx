<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="hcm_Exit_intrvw_Process.aspx.cs" Inherits="HCM_HCM_Master_hcm_Exit_Management_hcm_Exit_intrvw_Process_hcm_Exit_intrvw_Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
          .lblTop {
            width: 232px;
            padding: 0px 8px;
            border: 1px solid #cfcccc;
            float: right;
            color: #000;
            font-size: 14px;
            font-family: calibri;
            word-wrap: break-word;
        }
    </style>
       <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script>
        var $noCon = jQuery.noConflict();

        $noCon(window).load(function () {

            if (document.getElementById("<%=HiddenAnswer.ClientID%>").value != "") {


                var $NoConfi = jQuery.noConflict();

                var str = document.getElementById("<%=HiddenAnswer.ClientID%>").value;
                //alert(str);
                var temp = new Array();
                // this will return an array with strings "1", "2", etc.
                temp = str.split(",");
                // alert('b4' + temp);
                //$a.unique(temp);
                //alert('a' + temp);
                // alert(temp.length);
                var count = temp.length;

                //temp[a] = parseInt(temp[a], 10); // Explicitly include base as per Álvaro's comment

                var rowCount = $NoConfi('#ReportTable tr').length - 1;
                var $add = jQuery.noConflict();
                //  alert(rowCount);
                for (var x = 0; x < rowCount / 2; x++) {
                    if (x != count) {
                        document.getElementById("cphMain_txtanswr" + x).value = temp[x];

                    }
                    else {
                        //     alert("");
                        break;
                    }
                }

                for (var i in temp) {


                }
            }
            else {
                document.getElementById("cphMain_txtanswr" + 0).focus();
            }
        });

        function SuccessIns() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Interview Process saved successfully.";
            $(window).scrollTop(0);
        }
        //old
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Interview Process updated successfully.";
         }
         function SuccessCancelation() {
             document.getElementById('divMessageArea').style.display = "";
             document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
             document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Exit Interview Process cancelled successfully.";
         }
        function txtDisable() {
            var $noCon = jQuery.noConflict();
            var rowCount = $noCon('#ReportTable tr').length - 1;
            for (var x = 0; x < rowCount / 2; x++) {
                document.getElementById("cphMain_txtanswr" + x).disabled = true;

            }
        }
    </script>
    <script>

        function ConfirmMessage() {
            if (confirmbox > 0) {
               
                    if (confirm("Are you sure you want to leave this page?")) {
                        window.location.href = "hcm_Exit_intrvw_Process_List.aspx";

                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    window.location.href = "hcm_Exit_intrvw_Process_List.aspx";
                    return false;
                }
            
        }
        var confirmbox = 0;

        function IncrmntConfrmCounter() {
            confirmbox++;
            
        }
        // for not allowing <> tags  and enter
        function isTag(evt) {
           
            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
          //  alert(keyCodes);
            if (keyCodes == 13) {
                return false;
            }
            if (keyCodes == 126) {
                return false;
            }
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62) {
                ret = false;
            }
           
            return ret;
        }
   
        function RemoveTag() {
     
            var $NoConfi = jQuery.noConflict();
           
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];
            var rowCount = $NoConfi('#ReportTable tr').length - 1; 
            var $add = jQuery.noConflict();
            for (var x = 0; x < rowCount / 2; x++) {
                var SearchWithoutReplace = document.getElementById("cphMain_txtanswr" + x).value;
                var replaceText1 = SearchWithoutReplace.replace(/</g, "");
                var replaceText2 = replaceText1.replace(/>/g, "");
                var replaceText3 = replaceText2.replace(/~/g, "");
                document.getElementById("cphMain_txtanswr" + x).value = replaceText3;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
     <asp:HiddenField ID="HiddenId" runat="server" />
        <asp:HiddenField ID="hiddenUserId" runat="server" />
      <asp:HiddenField ID="HiddenQuestions" Value="" runat="server" />
    <asp:HiddenField ID="HiddenAnswer" Value="" runat="server" />
    <asp:HiddenField ID="HiddenMstrId" Value="" runat="server" />
    <div id="divMessageArea" style="display: none">
            <img id="imgMessageArea" src="" />
            <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
        </div>
     <div class="cont_rght">

          <div class="fillform" style="width: 100%;">
              <div id="divList" class="list"  onclick="ConfirmMessage();"  runat="server" style="height:26.5px;float:right;">

          <%--   <a href="gen_ProductBrandList.aspx">
                 <img src="../../Images/BigIcons/List.png" alt="List" />
            </a>--%>
        </div>
         <div id="divReportCaption" style="width: 100%; font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri; float: left">
             <img src="/Images/BigIcons/Request-for-guarantee.png" style="vertical-align: middle;" /> 
               <asp:Label ID="lblEntry" runat="server">Exit Interview Process</asp:Label>
            </div>
        <div style="width: 97.7%; border: 1px solid #8e8f8e; padding: 10px; background-color: white; float: left;margin-bottom: 2%;">
            

            <div style="float: left; width: 97.7%; padding: 10px; border: 1px solid #929292; background-color: #c9c9c9;">

                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Employee</h2>
                    <asp:Label ID="lblEmpl" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Designation</h2>
                    <asp:Label ID="lblDesign" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: left;">
                    <h2 style="color: #603504;">Pay Grade</h2>
                    <asp:Label ID="lblPay" class="lblTop" runat="server"></asp:Label>
                </div>
                <div class="eachform" style="width: 47%; float: right;">
                    <h2 style="color: #603504;">Division</h2>
                    <asp:Label ID="lblDivision" class="lblTop" runat="server"></asp:Label>
                </div>              
              
            </div>
            
   
        </div>
          <div id="divReport" class="table-responsive" runat="server"  style="width:100%">
             
        </div>
           
            <div style="float: left; width: 100%; padding: 5px; background: white; margin-left: 35%; margin-top: 2%;">
               <asp:Button ID="btnSave" runat="server" class="save" Text="Save" OnClick="btnSave_Click" OnClientClick="return getdataQuestion();" />
                <asp:Button ID="btnUpdate" runat="server" class="save" Text="Update" OnClick="btnUpdate_Click" OnClientClick="return getdataQuestion();" />
                <asp:Button ID="btnSaveCnfrm" runat="server" class="save" Text="Save & Confirm" OnClientClick="return getdataQuestion();" OnClick="btnSave_Click" />
                 <asp:Button ID="btnUpdateCnfrm" runat="server" class="save" Text="Update & Confirm" OnClientClick="return getdataQuestion();" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" class="save" Text="Cancel" OnClientClick="return ConfirmMessage();" OnClick="btnCancel_Click" />

            </div>
              </div>
    </div>
           <script src="/JavaScript/jquery-1.8.3.min.js"></script>
    <script>

        function getdataQuestion() {
            var $NoConfi = jQuery.noConflict();
           
            var tbClientJobSheduling = '';
            tbClientJobSheduling = [];
            var rowCount = $NoConfi('#ReportTable tr').length - 1; 
            var $add = jQuery.noConflict();
            for (var x = 0; x < rowCount / 2; x++) {
                document.getElementById("cphMain_txtanswr" + x).value= document.getElementById("cphMain_txtanswr" + x).value;

                if (document.getElementById("cphMain_txtanswr" + x).value != "") {
                    var Decsn = document.getElementById("cphMain_txtanswr" + x).value;

                    document.getElementById("cphMain_txtanswr" + x).style.borderColor = "";
                    if (x == 0) {
                        document.getElementById("<%=HiddenQuestions.ClientID%>").value = Decsn;
                    }
                    else {
                        document.getElementById("<%=HiddenQuestions.ClientID%>").value = document.getElementById("<%=HiddenQuestions.ClientID%>").value + "~" + Decsn;
                    }
                }
                else {
                    document.getElementById("cphMain_txtanswr" + x).style.borderColor = "Red";
                    document.getElementById('divMessageArea').style.display = "";
                    document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
                    document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Every Answer field is mandatory";
                    document.getElementById("cphMain_txtanswr" + x).focus();
                    return false;
                }
               
                //    var tableid = document.getElementById("tdid" + x).innerHTML;
                            
            }
          /// alert(document.getElementById("cphMain_HiddenQuestions").value);
           
            }
    </script>
</asp:Content>

