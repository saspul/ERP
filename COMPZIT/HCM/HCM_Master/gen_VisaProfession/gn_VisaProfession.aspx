<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageCompzit_Hcm.master" AutoEventWireup="true" CodeFile="gn_VisaProfession.aspx.cs" Inherits="Master_gen_VisaProfession_gn_VisaProfession" %>
<%--//emp17--%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
    <style>
        #divGreySection {
            background-color: #efefef;
            border: 1px solid;
            border-color: #cfcfcf;
            padding: 15px;
            height: auto;
            margin-top: 4%;
            width: 100%;
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

        .cont_rght {
            width: 98%;
        }

        #imgMessageArea {
            float: left;
            margin-left: 1%;
            margin-top: -0.2%;
        }
        /*--------------------------------------------------for modal Cancel Reason------------------------------------------------------*/
        .modalCancelView {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 30; /* Sit on top */
            padding-top: 0%; /* Location of the box */
            left: 23%;
            top: 30%;
            width: 50%; /* Full width */
            /*height: 58%;*/ /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: transparent;
        }


        /* Modal Content */
        .modal-CancelView {
            /*position: relative;*/
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            /*border: 1px solid #888;*/
            width: 95.6%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
        }


        /* The Close Button */
        .closeCancelView {
            color: white;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .closeCancelView:hover,
            .closeCancelView:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .modal-headerCancelView {
            /*padding: 1% 1%;*/
            background-color: #91a172;
            color: white;
        }

        .modal-bodyCancelView {
            padding: 4% 4% 7% 4%;
        }

        .modal-footerCancelView {
            padding: 2% 1%;
            background-color: #91a172;
            color: white;
        }

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

        .btnsave {
            float: left;
            font-family: Calibri;
            color: #000;
            font-size: 14px;
            padding: 3px 42px 3px 38px;
            margin: 0 0 7px;
        }
    </style>
   

  
     <script src="../../../JavaScript/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        var $noCon = jQuery.noConflict();
        $noCon(window).load(function () {

            document.getElementById("freezelayer").style.display = "none";
            document.getElementById('MymodalCancelView').style.display = "none";
            var CancelPrimaryId = document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value;
              if (CancelPrimaryId != "") {
                  OpenCancelView();
              }
          });


    </script>



  
    <script type="text/javascript">
        function AlertClearAll() {


            if (document.getElementById("<%=lblAdd.ClientID%>").innerText != "View Visa Profession") {
                if (document.getElementById("<%=txtVisaName.ClientID%>").value != "") {
                    if (confirm("Are you sure you want clear all data in this page?")) {
                        window.location.href = "/HCM/HCM_Master/gen_VisaProfession/gn_VisaProfession.aspx";
                        return false;
                    }
                    else {

                        return false;
                    }
                }
                return false;
            }

        }
        
        </script>
    <script type="text/javascript">
        var $Mo = jQuery.noConflict();

        function OpenCancelView() {

            document.getElementById("MymodalCancelView").style.display = "block";
            document.getElementById("freezelayer").style.display = "";
            document.getElementById("<%=txtCnclReason.ClientID%>").focus();

            return false;

        }
        function CloseCancelView() {
            if (confirm("Do you want to close  without completing cancellation process?")) {
                document.getElementById('divMessageArea').style.display = "none";                
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "";
                document.getElementById("MymodalCancelView").style.display = "none";
                document.getElementById("freezelayer").style.display = "none";
                
                document.getElementById("<%=hiddenCancelPrimaryId.ClientID%>").value = "";
            }
        }
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this Entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }

        function CancelNotPossible() {
            alert("Sorry, cancellation denied. This entry is already selected somewhere or it is a confirmed entry!");
            return false;

        }
        function isTagEnter(evt) {
            document.getElementById('divMessageArea').style.display = "none";          //emp17

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 || keyCodes == 13) {
                ret = false;
            }
            return ret;
        }
        function isTag(evt) {
            document.getElementById('divMessageArea').style.display = "none";          //emp17

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var ret = true;
            if (charCode == 60 || charCode == 62 ) {
                ret = false;
            }
            return ret;
        }
        // for not allowing enter //emp17
        function DisableEnter(evt) {

            evt = (evt) ? evt : window.event;
            var keyCodes = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;
            if (keyCodes == 13) {
                return false;
            }   //emp17
        }
        function CheckSubmitZero() {
            submit = 0;
        }
        function Validate()
        {
            var ret = true;
            var NameWithoutReplace = document.getElementById("<%=txtVisaName.ClientID%>").value;
            var replaceText1 = NameWithoutReplace.replace(/</g, "");
            var replaceText2 = replaceText1.replace(/>/g, "");
            document.getElementById("<%=txtVisaName.ClientID%>").value = replaceText2;

            document.getElementById("<%=txtVisaName.ClientID%>").style.borderColor = "";
            document.getElementById('divMessageArea').style.display = "";
            
            var VisaName = document.getElementById("<%=txtVisaName.ClientID%>").value.trim();
            if (VisaName == "")
            {
                document.getElementById('divMessageArea').style.display = "";
                document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
                document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Some of the information you entered is not correct or missing. Please check the highlighted fields below.";
                document.getElementById("<%=txtVisaName.ClientID%>").style.borderColor = "Red";
                document.getElementById("<%=txtVisaName.ClientID%>").focus();
                ret = false;
            }
            var cbxStatus = document.getElementById("<%=cbxStatus.ClientID%>");
            var cbx = 0;
            if (cbxStatus.checked) {
                cbx = 1;
            }
            else {
                cbx = 0;
            }

            if (ret == true) {

                document.getElementById("<%=HiddenSearchField.ClientID%>").value = VisaName + ',' + cbx;
             }
            if (ret == false) {
                CheckSubmitZero();

            }
            return ret;
        }

        function SearchValidation() {
            ret = true;
            var searchStatus = document.getElementById("<%=ddlStatus.ClientID%>").value;
            var cbxStatus = document.getElementById("<%=cbxCnclStatus.ClientID%>");
             var cbx = 0;
             if (cbxStatus.checked) {
                 cbx = 1;
             }
             else {
                 cbx = 0;
             }
             if (ret == true) {
                 document.getElementById("<%=HiddenSearchField.ClientID%>").value = searchStatus + ',' + cbx;
             }
             return ret;
         }


        //validation when cancel process
        function ValidateCancelReason() {
            // replacing < and > tags
            var NameWithoutReplace = document.getElementById("<%=txtCnclReason.ClientID%>").value;
        var replaceText1 = NameWithoutReplace.replace(/</g, "");
        var replaceText2 = replaceText1.replace(/>/g, "");
        document.getElementById("<%=txtCnclReason.ClientID%>").value = replaceText2;

            var divErrorMsg = document.getElementById('divErrorRsnAWMS').style.visibility = "hidden";
            var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "";
            var Reason = document.getElementById("<%=txtCnclReason.ClientID%>").value.trim();
        if (Reason == "") {
            document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
            document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Please fill this out";
                document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                return false;
            }
            else {
                Reason = Reason.replace(/(^\s*)|(\s*$)/gi, "");
                Reason = Reason.replace(/[ ]{2,}/gi, " ");
                Reason = Reason.replace(/\n /, "\n");
                if (Reason.length < "10") {
                    document.getElementById('divErrorRsnAWMS').style.visibility = "visible";
                    document.getElementById("<%=lblErrorRsnAWMS.ClientID%>").innerHTML = "Cancel reason should be minimum 10 characters";
                    var txthighlit = document.getElementById("<%=txtCnclReason.ClientID%>").style.borderColor = "Red";
                    return false;
                }
            }
        }



        function ChangeStatus(visaId,VisaStatus) {
            if (confirm("Do you want to change the status of this entry?")) {
                var SearchString = document.getElementById("<%=HiddenSearchField.ClientID%>").value;
               
                var Details = PageMethods.ChangeVisaStatus(visaId, VisaStatus, function (response) {                   
                     var SucessDetails = response;                 
                     if (SucessDetails == "success")
                     {
                         //alert(SearchString);
                         if (SearchString == "")              //emp17
                         {
                             window.location = 'gn_VisaProfession.aspx?InsUpd=StsCh';
                         }
                         else
                         {
                             window.location = 'gn_VisaProfession.aspx?InsUpd=StsCh&Srch=' + SearchString + '';
                         }

                     
                         //window.location = 'gn_VisaType.aspx?InsUpd=StsCh';  //emp17
                     }
                else
            {
                         window.location = 'gn_VisaProfession.aspx?InsUpd=Error';
                     }
                 });
             }
             else {
                 return false;
             }
         }


        function getdetails(href) {
            window.location = href;
            return false;
        }
        function CancelAlert(href) {

            if (confirm("Do you want to cancel this entry?")) {
                window.location = href;
                return false;
            }
            else {
                return false;
            }
        }
    </script>
    <%--  for giving pagination to the html table--%>
    <script src="/JavaScript/JavaScriptPagination1.js"></script>
    <script src="/JavaScript/JavaScriptPagination2.js"></script>

    <link rel="Stylesheet" href="/css/StyleSheetPagination.css" type="text/css" />
    <script>
        var $p = jQuery.noConflict();
        $p(document).ready(function () {
            $p('#ReportTable').DataTable({
                "pagingType": "full_numbers",
                "bSort": true,
                "pageLength": 25
            });
        });


    </script>


    <script type="text/javascript">
        function SuccessInsertion() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa profession inserted successfully.";
        }
        function StatusUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa status changed successfully.";
        }
        function FailedUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Duplication error!. Visa name can’t be duplicated..";
        }
        function FailedInsersion() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaWarning.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Duplication error!. Visa name can’t be duplicated..";
        }
        function SuccessUpdation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = " Visa details updated successfully";
        }
        function SuccessCancelation() {
            document.getElementById('divMessageArea').style.display = "";
            document.getElementById('imgMessageArea').src = "/Images/Icons/imgMsgAreaInfo.png";
            document.getElementById("<%=lblMessageArea.ClientID%>").innerHTML = "Visa profession cancelled successfully.";
        }

        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit) {
                field.value = field.value.substring(0, maxlimit);
            } else {

            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <asp:HiddenField ID="HiddenSearchField" runat="server" />
        <asp:HiddenField ID="hiddenupd" runat="server" />
    <asp:HiddenField ID="hiddenName" runat="server" />
    <asp:HiddenField ID="hiddenCancelPrimaryId" runat="server" />
    <asp:LinkButton ID="lnkCancel" runat="server"></asp:LinkButton>
    <div id="divMessageArea" style="display: none">
        <img id="imgMessageArea" src="" />
        <asp:Label ID="lblMessageArea" runat="server"></asp:Label>
    </div>

    <div class="cont_rght">


         <div id="divReportCaption" style="font-size: 24px; font-weight: bold; color: rgb(83, 101, 51); font-family: Calibri">
              <img src="/Images/BigIcons/Visa-Type-Master.png" style="vertical-align: middle;"  />   <asp:Label ID="lblEntry" runat="server">Visa Profession</asp:Label>
            </div>

      

        <div  style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 99.5%; margin-top: 1%;float: left;" class="eachform">    <%-- //emp17--%>
           <asp:Label ID="lblAdd" runat="server" style="font-size: 19px; margin-left: 1%; font-weight: bold; text-decoration:underline; color: rgb(83, 101, 51); font-family: Calibri">    <%-- //emp17 tab index removed name style--%>
            Add Visa Profession
        </asp:Label>
             <div style="float: left; width: 98%">
                 <div style="float:left; width:99%">
                <h2 style="margin-top: 0.5%; margin-left: 57px;">Visa Profession Name* </h2>

                <asp:TextBox ID="txtVisaName" runat="server" class="form1" MaxLength="100" Style="margin-left: 7%;float: left;text-transform:uppercase;"  onkeypress="return isTag(event)"></asp:TextBox>
                 </div>
                 <div style="float:left; width:99%">
                <h2 style="margin-left: 57px; margin-top: 11px;">Status*</h2>

                <asp:CheckBox ID="cbxStatus"  Text="" runat="server" Checked="true" class="form2" Style="margin-left: 107px;margin-top: 6px;" onkeypress="return DisableEnter(event)"/>

                <h2 style="margin-top: 9px;">Active</h2>

                <div class="subform">
                    <asp:Button runat="server" ID="btnSave" Text="Save" class="save"  OnClientClick="return Validate();" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btnCancl" Text="Cancel" class="save"  OnClick="btnCancl_Click" OnClientClick="return AlertClearAll();" />
                </div>
                     </div>
            </div>
            <%-- //emp17     division ended--%>
            </div>

          <div style="border: .5px solid; border-color: #9ba48b; background-color: #f3f3f3; width: 99.5%; margin-top: 1%;float: left;">   <%-- //emp17--%>
          
            <asp:Label ID="Label1" runat="server" style="font-size: 19px; margin-left:1%; font-weight: bold; text-decoration:underline; color: rgb(83, 101, 51); font-family: Calibri">
           Visa Profession List      <%--emp17--%>
        </asp:Label>
               
     
   <div style="float: left; width: 100%">         <%-- //emp17--%>
       <div class="eachform" style="width: 27%;margin-top: 2%;float: left;margin-left: 1%;">       <%-- //emp17--%>

           <h2 style="margin-top: 1%;">Status*</h2>

           <asp:DropDownList ID="ddlStatus" Height="25px"  Width="160px" class="form1" runat="server" Style="float: left; margin-left: 27%;">
                <asp:ListItem Text="All" Value="0"></asp:ListItem> <%-- //emp17--%>
                <asp:ListItem Text="Active"  Value="1"></asp:ListItem>
               <asp:ListItem Text="Inactive" Value="2"></asp:ListItem>

           </asp:DropDownList>


       </div>
       <div class="eachform" style="width: 25%;margin-top: 2%;margin-left: 0%;float: left;">       <%-- //emp17--%>
           <div class="subform" style="width: 187px; margin-left: 21%;float:left;">
               <asp:CheckBox ID="cbxCnclStatus" Text="" runat="server"  Checked="false" class="form2" onkeypress="return DisableEnter(event)"/>
               <h3 style="margin-top: 1%;">Show Deleted Entries</h3>
           </div>
       </div>
       <div class="eachform" style="width: 13%;float: left;margin-top: 2%;margin-left: 3%;">    <%-- //emp17--%>
           <asp:Button ID="btnSearch" Style="cursor: pointer; margin-top: -4.4%;"  runat="server"  class="searchlist_btn_lft" OnClientClick="return SearchValidation();" Text="Search" OnClick="btnSearch_Click" />
       </div>
   </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="divReport" class="table-responsive" runat="server" style="float:left; width:100%">     <%-- //emp17--%>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

</div>

                        <%--------------------------------View for error Reason--------------------------%>
           <div id="MymodalCancelView" class="modalCancelView" >
                <!-- Modal content -->
                <div class="modal-CancelView">
                    <div class="modal-headerCancelView">

                        <img class="closeCancelView" style= "margin-top: 0.6%; margin-right: 0.6%;" cursor: pointer;" onclick="CloseCancelView();" src="/Images/Icons/Cancel-flat-white-color-icon.jpg" alt="X" height="15px" width="15px" />

                        <h3 style="font-family: Calibri; font-size: 18px; margin-left: 37%; padding-bottom: 0.7%; padding-top: 0.6%;">Visa Profession Master</h3>
                    </div>
                    <div class="modal-bodyCancelView">
                        <div id="divErrorRsnAWMS" class="error" style="visibility: hidden; text-align: center;">
                            <asp:Label ID="lblErrorRsnAWMS" runat="server" text_align="center" Width="100%"></asp:Label>
                        </div>

                        <label class="control-label col-sm-3" style="font-family: Calibri; float: left; margin-left: 11%; margin-top: 10%; padding-right: 2%; width: 22%; color: #909c7b;">Cancel Reason*</label>
                        <asp:TextBox ID="txtCnclReason" class="form-control" MaxLength="500" Width="250px" Height="115px" TextMode="MultiLine" Style="resize: none; border: 1px solid #cfcccc;" onblur="RemoveTag(cphMain_txtCnclReason)" onkeypress="return isTag(event)" onkeydown="textCounter(cphMain_txtCnclReason,450)" onkeyup="textCounter(cphMain_txtCnclReason,450)" runat="server"></asp:TextBox>
                        <asp:Button ID="btnRsnSave" class="save" runat="server" Text="Save" OnClientClick="return ValidateCancelReason();" OnClick="btnRsnSave_Click" Style="width: 90px; float: left; margin-left: 39%; margin-top: 3%;" />

                        <asp:Button ID="btnRsnCncl" class="save" Style="width: 90px; float: right; margin-right: 26%; margin-top: 3%;" OnClientClick="CloseCancelView();" runat="server" Text="Close" />
                    </div>
                    
                    <div class="modal-footerCancelView" style="margin-top: 21px;">
                    </div>


                </div>
            </div>   

         <div style="width: 100% !important; position: fixed; top: 0; left: 0; right: 0; bottom: 0; background: #3a3a3a; filter: Alpha(Opacity=90); -moz-opacity: 0.2; opacity: 0.4; z-index: 29; height: auto !important;"
                class="freezelayer" id="freezelayer">
                    </div>

    </div>

</asp:Content>

